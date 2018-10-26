Imports System.Data.SqlClient
Imports System.IO
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports Syscom.Server.PUB
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports System.Transactions
Imports System.Text

Public Class UCLComboBoxGridBO_E1

    Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
    Dim log As LOGDelegate = LOGDelegate.getInstance
    Dim tableName As String = "OMO_Favor"

    Public Function queryOMOFavorByFavorId(ByVal favorId As String, _
                                           ByVal doctorDeptCode As String, _
                                           ByVal favorTypeId As String, _
                                           ByVal favorCategory As String, _
                                           ByVal code As String, _
                                           ByVal codeName As String _
                                         ) As DataSet




        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            If code <> "" Then
                command.CommandText = " Select Icd_Code  , Disease_En_Name   " & _
                                      " From  PUB_Disease " & _
                                      " Where  DC<>'Y' And Icd_Code like  '" & code & "%'" & _
                                      " Order By Icd_Code"
            ElseIf codeName <> "" Then
                command.CommandText = " Select Icd_Code  , Disease_En_Name   " & _
                                      " From  PUB_Disease " & _
                                      " Where  DC<>'Y' And Disease_En_Name like  '" & codeName & "%'" & _
                                      " Order By Disease_En_Name "
            End If


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)

            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    '隨輸隨選 醫囑診斷 PUB_Disease
    Public Function queryOMOOrderDiagnosis(ByVal code As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            If code <> "" Or codeName <> "" Then 'Modify on 2011-04-28 by Lits
                If code <> "" Then

                    Dim Content As New StringBuilder
                    Content.AppendLine("Select Icd_Code  , Disease_En_Name  ,Disease_Type_Id, ")
                    Content.AppendLine("         Effect_Date ,Disease_Name,Disease_Hosp_Name,Majorcare_Code,Limit_Sex_Id, ")
                    Content.AppendLine("         Infection_Type_Id,Limit_Age,Age_Start_Year,Age_Start_Month,Age_Start_Day, ")
                    Content.AppendLine("         Age_End_Year,Age_End_Month,Age_End_Day,Is_Exclude_Labdiscount,Is_Chronic_Disease, ")
                    Content.AppendLine("         Is_Severe_Disease,Is_Psy_Severe_Disease,Is_Rare_Diseases,Is_Major_P,Is_Minor_P, ")
                    Content.AppendLine("         Is_Mcc,Is_Cc,End_Date,Is_Pre5_Diagnosis,Is_Or,Is_Drg ")
                    Content.AppendLine("   From   PUB_Disease ")
                    Content.AppendLine("  Where   DC<>'Y' And Icd_Code_Nodot like  '" & code.Replace(".", "") & "%' And '" & Now().ToString("yyyy/M/d") & "' >= Effect_Date And  '" & Now().ToString("yyyy/M/d") & " '<= End_Date  ")
                    If DiseaseTypeId.Trim <> "" Then
                        Content.AppendLine("    And Disease_Type_Id in (" & DiseaseTypeId & ")  ")
                    End If
                    If IsSevereDisease.Trim = "Y" Then
                        Content.AppendLine("    And Is_Severe_Disease='Y'  ")
                    End If
                     Content.AppendLine("union all")
                    Content.AppendLine("     Select Icd_Code  , Disease_En_Name  ,Disease_Type_Id, ")
                    Content.AppendLine("         Effect_Date ,Disease_Name,Disease_Hosp_Name,Majorcare_Code,Limit_Sex_Id, ")
                    Content.AppendLine("         Infection_Type_Id,Limit_Age,Age_Start_Year,Age_Start_Month,Age_Start_Day, ")
                    Content.AppendLine("         Age_End_Year,Age_End_Month,Age_End_Day,Is_Exclude_Labdiscount,Is_Chronic_Disease, ")
                    Content.AppendLine("         Is_Severe_Disease,Is_Psy_Severe_Disease,Is_Rare_Diseases,Is_Major_P,Is_Minor_P, ")
                    Content.AppendLine("         Is_Mcc,Is_Cc,End_Date,Is_Pre5_Diagnosis,Is_Or,Is_Drg ")
                    Content.AppendLine("   From   PUB_Disease_ICD10 ")
                    Content.AppendLine("  Where   DC<>'Y' And Icd_Code_Nodot like  '" & code.Replace(".", "") & "%' And '" & Now().ToString("yyyy/M/d") & "' >= Effect_Date And  '" & Now().ToString("yyyy/M/d") & " '<= End_Date  ")
                    If DiseaseTypeId.Trim <> "" Then
                        Content.AppendLine("    And Disease_Type_Id in (" & DiseaseTypeId & ")  ")
                    End If
                    If IsSevereDisease.Trim = "Y" Then
                        Content.AppendLine("    And Is_Severe_Disease='Y'  ")
                    End If
                    Content.AppendLine("    Order By 1")
                    command.CommandText = Content.ToString


                ElseIf codeName <> "" Then
                    command.CommandText = " Select Icd_Code  , Disease_En_Name  ,Disease_Type_Id, " & _
                                          "        Effect_Date ,Disease_Name,Disease_Hosp_Name,Majorcare_Code,Limit_Sex_Id," & _
                                          "        Infection_Type_Id,Limit_Age,Age_Start_Year,Age_Start_Month,Age_Start_Day," & _
                                          "        Age_End_Year,Age_End_Month,Age_End_Day,Is_Exclude_Labdiscount,Is_Chronic_Disease," & _
                                          "        Is_Severe_Disease,Is_Psy_Severe_Disease,Is_Rare_Diseases,Is_Major_P,Is_Minor_P," & _
                                          "        Is_Mcc,Is_Cc,End_Date,Is_Pre5_Diagnosis,Is_Or,Is_Drg " & _
                                          " From  PUB_Disease " & _
                                          " Where DC<>'Y' And Disease_En_Name like  '" & codeName & "%' And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= End_Date "

                    If DiseaseTypeId.Trim <> "" Then
                        command.CommandText += " And Disease_Type_Id in (" & DiseaseTypeId & ") "
                    End If

                    If IsSevereDisease.Trim = "Y" Then
                        command.CommandText += " And Is_Severe_Disease='Y' "
                    Else
                        command.CommandText += " And Is_Opd ='Y' "
                    End If

                    command.CommandText += " Order By Disease_En_Name "
                End If


                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet(tableName)
                    adapter.Fill(ds, tableName)

                End Using
                Return ds
            Else
                ds = New DataSet(tableName)
                Return ds
            End If

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    '隨輸隨選 藥品 OPH_Pharmacy_Base
    Public Function queryOPHPharmacyBase(ByVal code As String, ByVal codeName As String, ByVal DrugType As String, Optional ByVal IsEqualMatch As String = "N") As DataSet
        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            If code <> "" Then

                If DrugType = "NormalDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  , E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                     " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                       Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                       Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                     " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                       Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                       Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If


                ElseIf DrugType = "NormalDrug2" Then


                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification ,A.Order_Code ,A.Supply_Status_Memo  , E.Code_Name As 'Drug_Reminder_Name'  ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                          " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                          " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                          " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                          " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code  , A.Is_Control_Rule   ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  , PUB_Order B  " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                        Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                        Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  , PUB_Order B  " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                        Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                        Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                    End If




                ElseIf DrugType = "TPNDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                        " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                        " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If

                    'command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    'command.CommandText += " And C.Property_Id ='09' "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id <>'5' And  C.DC<>'Y'  "



                ElseIf DrugType = "TPNDrug2----------" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification ,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule, A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio, Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content  "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,    OPH_Property C  , PUB_Order B " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,    OPH_Property C  , PUB_Order B " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='09' "

                ElseIf DrugType = "TPNDrug2" Then

                    'Tpn類別為OPH_TPN_Pharmacy.TPN_KIND_ID <> ‘5’

                    '混合類別為OPH_TPN_Pharmacy.TPN_KIND_ID = ‘5’

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification ,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule, A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio, Y.Add_Price , B.Is_Icd_Check  , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,    OPH_TPN_Pharmacy C , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,    OPH_TPN_Pharmacy C , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id in ( '1', '2' ) And  C.DC<>'Y'  " 'modified on 2011-03-16 TPN藥的 Tpn_Kind_Id = 1 or 2


                ElseIf DrugType = "ChemoDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                ElseIf DrugType = "ChemoDrug2" Then


                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                           " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                           " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                           " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                           " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code  , A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio, Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Alert_Content "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  ,   OPH_Property C  , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  ,   OPH_Property C  , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                ElseIf DrugType = "VaccineDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='14' "

                ElseIf DrugType = "VaccineDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio, Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder  , A.Package_Qty , A.Alert_Content  "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  ,   OPH_Property C , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                        Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                        Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  ,   OPH_Property C , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                        Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                        Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='14' "




                ElseIf DrugType = "ChemoAndNormalDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                     " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                       Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                       Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                     " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                       Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                       Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If


                    command.CommandText += " Union All"

                    command.CommandText += " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                    End If

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                ElseIf DrugType = "ChemoAndNormalDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                         " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                          " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                          " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                          " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                          " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio, Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content  "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' )  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                    " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                      Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                      Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' )  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                    " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                      Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                      Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If

                    command.CommandText += " Union All"

                    command.CommandText += " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content  "


                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_Property C , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_Property C , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "


                ElseIf DrugType = "TPNAndNormalDrug" Then

                    'command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    'command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) , PUB_Order B  " & _
                    '                   " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                    '                     Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                    '                     Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                    'command.CommandText += " Union All"

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                             Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                             Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                             Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                             Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If


                    'command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    'command.CommandText += " And C.Property_Id ='09' "


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='4' And  C.DC<>'Y'  " 'modify on 2011-03-16 混合的 Tpn_Kind_Id = 4


                ElseIf DrugType = "TPNAndNormalDrug2" Then

                    'command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                    '                     " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                    '                       " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                    '                       " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                    '                       " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                    '                       " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check  "

                    'command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) , PUB_Order B  " & _
                    '                       " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                    '                       " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                    '                  " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                    '                    Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                    '                    Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                    'command.CommandText += " Union All"

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check  , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content   "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C  , PUB_Order B " & _
                                        " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                        " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C  , PUB_Order B " & _
                                        " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                        " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If

                    'command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    'command.CommandText += " And C.Property_Id ='09' "
                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='4' And  C.DC<>'Y'  "  'modify on 2011-03-16 混合的 Tpn_Kind_Id = 4


                ElseIf DrugType = "TPNAddDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                        " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                       " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                       " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                       " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                       " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check  , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content   "


                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C  , PUB_Order B " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "



                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C  , PUB_Order B " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='5' And  C.DC<>'Y'  "  'modify on 2011-03-16 添加的 Tpn_Kind_Id = 5



                ElseIf DrugType = "OMOChemoDiluteMap" Then

                    Dim var1 As New System.Text.StringBuilder
                    var1.Append("SELECT DISTINCT A.Dilute_Name              AS Order_En_Name, " & vbCrLf)
                    var1.Append("                RTRIM(A.Dilute_Order_Code) AS Order_Code, " & vbCrLf)
                    var1.Append("                RTRIM(A.Drip)              AS Drip, " & vbCrLf)
                    var1.Append("                A.Dilute_Qty, " & vbCrLf)
                    var1.Append("                RTRIM(B.Charge_Unit)       AS Charge_Unit, " & vbCrLf)
                    var1.Append("                A.Dilute_Kind, " & vbCrLf)
                    var1.Append("                RTRIM(B.Order_Type_Id)     AS Order_Type_Id, " & vbCrLf)
                    var1.Append("                A.Dosage_Weight_B, " & vbCrLf)
                    var1.Append("                A.Dosage_Weight_E, " & vbCrLf)
                    var1.Append("                A.Is_BSA, " & vbCrLf)
                    var1.Append("                A.Is_61_Weight, " & vbCrLf)
                    var1.Append("                X.Price                    AS [Self_Price], " & vbCrLf)
                    var1.Append("                Y.Price                    AS [Price], " & vbCrLf)
                    var1.Append("                X.Order_Ratio              AS [Self_Order_Ratio], " & vbCrLf)
                    var1.Append("                X.Material_Ratio           AS Self_Material_Ratio, " & vbCrLf)
                    var1.Append("                Y.Order_Ratio, " & vbCrLf)
                    var1.Append("                Y.Material_Ratio, " & vbCrLf)
                    var1.Append("                Y.Add_Price, " & vbCrLf)
                    var1.Append("                B.Is_Icd_Check, " & vbCrLf)
                    var1.Append("                B.Include_Order_Mark, " & vbCrLf)
                    var1.Append("                RTRIM(C.Pharmacy_12_Code)  AS Pharmacy_12_Code, " & vbCrLf)
                    var1.Append("                RTRIM(C.Alert_Content)  AS Alert_Content, " & vbCrLf)
                    var1.Append("                RTRIM(C.Form_Kind_Id)  AS Form_Kind_Id, " & vbCrLf)
                    var1.Append("                RTRIM(C.Opd_Lack_Id)       AS Opd_Lack_Id ," & vbCrLf)
                    var1.Append("                RTRIM(B.Is_Prior_Review)       AS Is_Prior_Review " & vbCrLf)
                    var1.Append("FROM   OMO_Chemo_Dilute_Map A " & vbCrLf)
                    var1.Append("       INNER JOIN PUB_Order B " & vbCrLf)
                    var1.Append("         ON A.Dilute_Order_Code = B.Order_Code " & vbCrLf)
                    var1.Append("       LEFT JOIN OPH_Pharmacy_Base C " & vbCrLf)
                    var1.Append("         ON A.Dilute_Order_Code = C.Order_Code " & vbCrLf)
                    var1.Append("            AND C.Dc = 'N' " & vbCrLf)
                    var1.Append("       LEFT JOIN PUB_Order_Price X " & vbCrLf)
                    var1.Append("         ON X.DC = 'N' " & vbCrLf)
                    var1.Append("            AND A.Dilute_Order_Code = X.Order_Code " & vbCrLf)
                    var1.Append("            AND X.Main_Identity_Id = '1' " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' <= X.End_Date " & vbCrLf)
                    var1.Append("       LEFT JOIN PUB_Order_Price Y " & vbCrLf)
                    var1.Append("         ON Y.DC = 'N' " & vbCrLf)
                    var1.Append("            AND A.Dilute_Order_Code = Y.Order_Code " & vbCrLf)
                    var1.Append("            AND Y.Main_Identity_Id = '2' " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' <= Y.End_Date " & vbCrLf)
                    var1.Append("WHERE  B.Dc = 'N' " & vbCrLf)

                    If IsEqualMatch = "Y" Then
                        var1.AppendFormat("       AND A.Dilute_Order_Code = '{0}'  " & vbCrLf, code.TrimEnd)


                    Else

                        var1.AppendFormat("       AND A.Dilute_Order_Code like '{0}%'  " & vbCrLf, code.TrimEnd)

                    End If


                    'Dim var1 As New System.Text.StringBuilder
                    'var1.Append("SELECT DISTINCT A.Dilute_Name              AS Order_En_Name, " & vbCrLf)
                    'var1.Append("                RTRIM(A.Dilute_Order_Code) AS Order_Code, " & vbCrLf)
                    'var1.Append("                RTRIM(A.Drip)              AS Drip, " & vbCrLf)
                    'var1.Append("                A.Dilute_Qty, " & vbCrLf)
                    'var1.Append("                RTRIM(B.Charge_Unit)       AS Charge_Unit, " & vbCrLf)
                    'var1.Append("                A.Dilute_Kind, " & vbCrLf)
                    'var1.Append("                RTRIM(B.Order_Type_Id)     AS Order_Type_Id, " & vbCrLf)
                    'var1.Append("                A.Dosage_Weight_B, " & vbCrLf)
                    'var1.Append("                A.Dosage_Weight_E, " & vbCrLf)
                    'var1.Append("                A.Is_BSA, " & vbCrLf)
                    'var1.Append("                A.Is_61_Weight , " & vbCrLf)
                    'var1.Append("                X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check " & vbCrLf)
                    'var1.Append(" FROM   OMO_Chemo_Dilute_Map A " & vbCrLf)
                    'var1.Append("       INNER JOIN PUB_Order B " & vbCrLf)
                    'var1.Append("         ON A.Dilute_Order_Code = B.Order_Code " & vbCrLf)
                    'var1.Append("        Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & vbCrLf)
                    'var1.Append("        Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & vbCrLf)
                    'var1.Append(" WHERE  B.Dc = 'N' " & vbCrLf)
                    'var1.AppendFormat("       AND A.Dilute_Order_Code like '{0}%'  " & vbCrLf, code.TrimEnd)

                    command.CommandText = var1.ToString

                    'command.CommandText = " Select Distinct A.Dilute_Name , Rtrim(A.Dilute_Order_Code) as Dilute_Order_Code   , A.Dilute_Kind ,A.Dilute_Qty ,A.Drip ,A.Dosage_Weight_B ,A.Dosage_Weight_E ,A.Is_BSA ,A.Is_61_Weight " & _
                    '                      " From  OMO_Chemo_Dilute_Map A Where A.Dilute_Order_Code like '" & code & "%'  "

                    command.CommandText += " Order By A.Dilute_Name "
                End If

                If DrugType <> "OMOChemoDiluteMap" Then
                    command.CommandText += " Order By A.Order_Code "
                End If

            ElseIf codeName <> "" Then


                If DrugType = "NormalDrug" Then
                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "

                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                         Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                         Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                ElseIf DrugType = "NormalDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                        " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                        " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                        " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                        " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Alert_Content "

                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                      " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%' ) And '" & _
                                        Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                        Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "



                ElseIf DrugType = "TPNDrug" Then
                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "
                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    'command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    'command.CommandText += " And C.Property_Id ='09' "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id in ( '1', '2' ) And  C.DC<>'Y'  " 'TPN藥的 Tpn_Kind_Id = 1 or 2




                ElseIf DrugType = "TPNDrug2" Then


                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                          " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                          " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                          " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                          " B.Is_Prior_Review,  B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio'  ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content  "


                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C , PUB_Order B  " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                              " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                                 Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                                 Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id in ( '1', '2' ) And  C.DC<>'Y'  " 'TPN藥的 Tpn_Kind_Id = 1 or 2



                ElseIf DrugType = "ChemoDrug" Then
                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "
                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                ElseIf DrugType = "ChemoDrug2" Then


                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                           " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                           " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                           " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                           " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark  , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content "


                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_Property C , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                             " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                                Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                                Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "




                ElseIf DrugType = "VaccineDrug" Then
                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "
                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='14' "

                ElseIf DrugType = "VaccineDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                         " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                       " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                       " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                       " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                       " B.Is_Prior_Review,  B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio'  ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content  "


                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_Property C  , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='14' "





                ElseIf DrugType = "ChemoAndNormalDrug" Then


                    command.CommandText = " Select  Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "
                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                    command.CommandText += " Union All "

                    command.CommandText += " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*  "
                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' )  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                         Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                         Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                ElseIf DrugType = "ChemoAndNormalDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio'  ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Alert_Content "


                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  ,   OPH_Property C , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                             Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                             Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                    command.CommandText += " Union All "

                    command.CommandText += " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                        " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                        " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                        " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                        " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio  , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark  , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content "


                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                     " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'  ) And '" & _
                                       Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                       Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "



                ElseIf DrugType = "TPNAndNormalDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "
                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    'command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    'command.CommandText += " And C.Property_Id ='09' "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='4' And  C.DC<>'Y'  " '混合藥的Tpn_Kind_Id = 4



                    'command.CommandText += " Union All "

                    'command.CommandText += " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo , A.* , B.*   "
                    'command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) , PUB_Order B  " & _
                    '                   " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                    '                     Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                    '                     Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                ElseIf DrugType = "TPNAndNormalDrug2" Then


                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio  , Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content "

                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                        " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='4' And  C.DC<>'Y'  " '混合藥的Tpn_Kind_Id = 4


                    'command.CommandText += " Union All "

                    'command.CommandText += " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Order_Code ,A.Supply_Status_Memo ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                    '                      " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                    '                      " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                    '                      " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                    '                      " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                    '                      " B.Is_Prior_Review,  B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio'  ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check  "

                    'command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) , PUB_Order B  " & _
                    '                       " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                    '                       " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                    '                  " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'  ) And '" & _
                    '                    Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                    '                    Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                ElseIf DrugType = "TPNAddDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                      " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                     " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                     " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                     " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                     " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio  , Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Alert_Content "

                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                        " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='5' And  C.DC<>'Y'  " '添加藥的Tpn_Kind_Id = 5

                ElseIf DrugType = "OMOChemoDiluteMap" Then

                    Dim var1 As New System.Text.StringBuilder
                    var1.Append("SELECT DISTINCT A.Dilute_Name              AS Order_En_Name, " & vbCrLf)
                    var1.Append("                RTRIM(A.Dilute_Order_Code) AS Order_Code, " & vbCrLf)
                    var1.Append("                RTRIM(A.Drip)              AS Drip, " & vbCrLf)
                    var1.Append("                A.Dilute_Qty, " & vbCrLf)
                    var1.Append("                RTRIM(B.Charge_Unit)       AS Charge_Unit, " & vbCrLf)
                    var1.Append("                A.Dilute_Kind, " & vbCrLf)
                    var1.Append("                RTRIM(B.Order_Type_Id)     AS Order_Type_Id, " & vbCrLf)
                    var1.Append("                A.Dosage_Weight_B, " & vbCrLf)
                    var1.Append("                A.Dosage_Weight_E, " & vbCrLf)
                    var1.Append("                A.Is_BSA, " & vbCrLf)
                    var1.Append("                A.Is_61_Weight, " & vbCrLf)
                    var1.Append("                X.Price                    AS [Self_Price], " & vbCrLf)
                    var1.Append("                Y.Price                    AS [Price], " & vbCrLf)
                    var1.Append("                X.Order_Ratio              AS [Self_Order_Ratio], " & vbCrLf)
                    var1.Append("                X.Material_Ratio           AS Self_Material_Ratio, " & vbCrLf)
                    var1.Append("                Y.Order_Ratio, " & vbCrLf)
                    var1.Append("                Y.Material_Ratio, " & vbCrLf)
                    var1.Append("                Y.Add_Price, " & vbCrLf)
                    var1.Append("                B.Is_Icd_Check, " & vbCrLf)
                    var1.Append("                B.Include_Order_Mark, " & vbCrLf)
                    var1.Append("                RTRIM(C.Pharmacy_12_Code)  AS Pharmacy_12_Code, " & vbCrLf)
                    var1.Append("                RTRIM(C.Alert_Content)  AS Alert_Content, " & vbCrLf)
                    var1.Append("                RTRIM(C.Form_Kind_Id)  AS Form_Kind_Id, " & vbCrLf)
                    var1.Append("                RTRIM(C.Opd_Lack_Id)       AS Opd_Lack_Id, " & vbCrLf)
                    var1.Append("                RTRIM(B.Is_Prior_Review)       AS Is_Prior_Review " & vbCrLf)
                    var1.Append("FROM   OMO_Chemo_Dilute_Map A " & vbCrLf)
                    var1.Append("       INNER JOIN PUB_Order B " & vbCrLf)
                    var1.Append("         ON A.Dilute_Order_Code = B.Order_Code " & vbCrLf)
                    var1.Append("       LEFT JOIN OPH_Pharmacy_Base C " & vbCrLf)
                    var1.Append("         ON A.Dilute_Order_Code = C.Order_Code " & vbCrLf)
                    var1.Append("            AND C.Dc = 'N' " & vbCrLf)
                    var1.Append("       LEFT JOIN PUB_Order_Price X " & vbCrLf)
                    var1.Append("         ON X.DC = 'N' " & vbCrLf)
                    var1.Append("            AND A.Dilute_Order_Code = X.Order_Code " & vbCrLf)
                    var1.Append("            AND X.Main_Identity_Id = '1' " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' <= X.End_Date " & vbCrLf)
                    var1.Append("       LEFT JOIN PUB_Order_Price Y " & vbCrLf)
                    var1.Append("         ON Y.DC = 'N' " & vbCrLf)
                    var1.Append("            AND A.Dilute_Order_Code = Y.Order_Code " & vbCrLf)
                    var1.Append("            AND Y.Main_Identity_Id = '2' " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' <= Y.End_Date " & vbCrLf)
                    var1.Append("WHERE  B.Dc = 'N' " & vbCrLf)
                    var1.AppendFormat("       AND A.Dilute_Name like '{0}%'  " & vbCrLf, codeName.TrimEnd)

                    'Dim var1 As New System.Text.StringBuilder
                    'var1.Append("SELECT DISTINCT A.Dilute_Name              AS Order_En_Name, " & vbCrLf)
                    'var1.Append("                RTRIM(A.Dilute_Order_Code) AS Order_Code, " & vbCrLf)
                    'var1.Append("                RTRIM(A.Drip)              AS Drip, " & vbCrLf)
                    'var1.Append("                A.Dilute_Qty, " & vbCrLf)
                    'var1.Append("                RTRIM(B.Charge_Unit)       AS Charge_Unit, " & vbCrLf)
                    'var1.Append("                A.Dilute_Kind, " & vbCrLf)
                    'var1.Append("                RTRIM(B.Order_Type_Id)     AS Order_Type_Id, " & vbCrLf)
                    'var1.Append("                A.Dosage_Weight_B, " & vbCrLf)
                    'var1.Append("                A.Dosage_Weight_E, " & vbCrLf)
                    'var1.Append("                A.Is_BSA, " & vbCrLf)
                    'var1.Append("                A.Is_61_Weight, " & vbCrLf)
                    'var1.Append("                X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check " & vbCrLf)
                    'var1.Append(" FROM   OMO_Chemo_Dilute_Map A " & vbCrLf)
                    'var1.Append("       INNER JOIN PUB_Order B " & vbCrLf)
                    'var1.Append("         ON A.Dilute_Order_Code = B.Order_Code " & vbCrLf)
                    'var1.Append("        Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & vbCrLf)
                    'var1.Append("        Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & vbCrLf)
                    'var1.Append(" WHERE  B.Dc = 'N' " & vbCrLf)
                    'var1.AppendFormat("       AND A.Dilute_Name like '{0}%'  " & vbCrLf, codeName.TrimEnd)

                    command.CommandText = var1.ToString

                    'command.CommandText = " Select Distinct A.Dilute_Name ,Rtrim(A.Dilute_Order_Code) as Dilute_Order_Code  , A.Dilute_Kind ,A.Dilute_Qty ,A.Drip ,A.Dosage_Weight_B ,A.Dosage_Weight_E ,A.Is_BSA ,A.Is_61_Weight " & _
                    '                      " From  OMO_Chemo_Dilute_Map A Where A.Dilute_Name like '" & codeName & "%' "

                    command.CommandText += " Order By A.Dilute_Name "
                End If

                If DrugType <> "OMOChemoDiluteMap" Then
                    command.CommandText += " Order By A.Order_Code "
                End If

            End If

            command.CommandText += "; Select * From OPH_Property ;"



            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)

            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    '隨輸隨選 醫令 PUB_Order
    Public Function queryPUBOrder(ByVal OrderCode As String, ByVal OrderEnName As String, ByVal OrderTypeId As String, Optional ByVal BasicDateStr As String = "") As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim BasicDate As Date = Now

            Dim IsOpdOnly As String = "N"

            If BasicDateStr <> "" AndAlso IsDate(BasicDateStr) Then
                BasicDate = CDate(BasicDateStr)
            End If
            Dim IsEqualMatch As String = "N"

            If BasicDateStr = "EqualMatch" Then
                IsEqualMatch = "Y"
            End If

            If BasicDateStr = "IsOpdOnly" Then
                IsOpdOnly = "Y"
            End If


            If OrderCode <> "" Then

                If OrderTypeId = "G" Then '衛材
                    'command.CommandText = " Select   A.Order_En_Name ,A.Order_Code,CAST( C.Price AS DECIMAL(18,1)) as Price , CAST( D.Price AS DECIMAL(18,1)) as Price, A.Is_Order_Check , A.Charge_Unit   "  'Charge_Unit =Tqty_Unit
                    command.CommandText = " Select   A.Order_En_Name ,A.Order_Code   , A.Is_Order_Check , A.Is_Icd_Check  , A.Charge_Unit  , A.Is_IC_Card_Order , A.Order_Note , A.Is_Prior_Review  , A.Include_Order_Mark ,   C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio' ,D.Order_Ratio , D.Material_Ratio , D.Add_Price    "  'Charge_Unit =Tqty_Unit

                ElseIf OrderTypeId = "D" Then '治療處置
                    ' command.CommandText = " Select   A.Order_En_Name ,A.Order_Code, CAST( C.Price AS DECIMAL(18,1)) as Price , CAST( D.Price AS DECIMAL(18,1)) as Price ,  A.Is_Cure , A.Treatment_Type_Id , A.Cure_Type_Id  ,A.Is_Order_Check ,  A.Charge_Unit , A.Order_Type_Id ,B.* "
                    command.CommandText = " Select   A.Order_En_Name ,A.Order_Code,     A.Is_Cure , A.Treatment_Type_Id , A.Cure_Type_Id  , A.Include_Order_Mark ,A.Is_Order_Check , A.Is_Icd_Check  ,  A.Charge_Unit , A.Order_Type_Id , A.Is_IC_Card_Order , A.Order_Note ,  A.Is_Prior_Review ,   C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio'  ,D.Order_Ratio , D.Material_Ratio , D.Add_Price     , B.* "

                ElseIf OrderTypeId = "H" Then '檢驗檢查
                    'command.CommandText = " Select   A.Order_En_Name , A.Order_Code,   A.Is_Order_Check , B.Is_Scheduled , B.Is_Same_Specimen_Add , A.Is_Prior_Review , B.Default_Body_Site_Code ,B.Default_Main_Body_Site_Code ,B.Default_Side_Id ,B.Default_Specimen_Id, A.Treatment_Type_Id , A.Charge_Unit ,C.Sheet_Code ,D.Is_Emergency_Sheet , B.Is_Main_Body_Site , B.Is_Body_Site , B.Is_Side_Id , A.Is_IC_Card_Order , B.Deliver_System  , B.Is_With_Contrast, B.Nhi_Body_Site_Code , A.Order_Note ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price "

                    command.CommandText = " Select   (Case When A.Treatment_Type_Id='3' and A.Order_En_Short_Name<>'' and A.Order_En_Short_Name is not null then A.Order_En_Short_Name  When A.Treatment_Type_Id='3' and (A.Order_En_Short_Name='' or A.Order_En_Short_Name is   null) then A.Order_En_Name When A.Treatment_Type_Id='4'   then A.Order_En_Name end ) as 'Order_En_Name' , A.Order_Code,  A.Include_Order_Mark , A.Is_Order_Check , A.Is_Icd_Check , B.Is_Scheduled , B.Is_Same_Specimen_Add , A.Is_Prior_Review , B.Default_Body_Site_Code ,B.Default_Main_Body_Site_Code ,B.Default_Side_Id ,B.Default_Specimen_Id, A.Treatment_Type_Id , A.Charge_Unit ,C.Sheet_Code , C.Separate_Mark ,D.Is_Emergency_Sheet , B.Is_Main_Body_Site , B.Is_Body_Site , B.Is_Side_Id , A.Is_IC_Card_Order , B.Deliver_System  , B.Is_With_Contrast, B.Nhi_Body_Site_Code , B.Is_No_Separate , A.Order_Note ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price "


                ElseIf OrderTypeId = "J" Then '手術法
                    command.CommandText = " Select S.Doctor_Dept_Code , A.Order_Name,  A.Order_En_Name , A.Order_Code, S.Age_Group_Id , S.Op_Nameplate_Id, S.Nameplate_Name , A.Include_Order_Mark , A.Is_Order_Check , A.Is_Icd_Check  ,  A.Is_Prior_Review   , A.Treatment_Type_Id , A.Charge_Unit , B.Is_Single_Or ,B.Is_Body_Site , B.Default_Body_Site_Code , B.Default_Side_Id , A.Is_IC_Card_Order  , A.Order_Note  ,   C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio' ,D.Order_Ratio , D.Material_Ratio  , D.Add_Price  "
                ElseIf OrderTypeId = "J1" Then '批價手術法
                    command.CommandText = " Select A.*," + _
                                          " rtrim(POE.Deliver_System) as Deliver_System," + _
                                          " rtrim(POE.Nhi_Body_Site_Code) as Nhi_Body_Site_Code ,  C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio'  ,D.Order_Ratio , D.Material_Ratio , D.Add_Price, B.Is_Single_Or"
                ElseIf OrderTypeId = "NckuCode" Then '成大碼轉健保碼
                    command.CommandText = " Select  PP.Order_Code,  Case when DD.Insu_Code is null then PP.Insu_Code  else DD.Insu_Code End as detail_Insu_Code, PO.Order_En_Name, PO.Order_Name  "

                Else


                    command.CommandText = " Select A.*," + _
                                          " rtrim(POE.Deliver_System) as Deliver_System," + _
                                          " rtrim(POE.Nhi_Body_Site_Code) as Nhi_Body_Site_Code ,  C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio'  ,D.Order_Ratio , D.Material_Ratio , D.Add_Price "


                End If


                If OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId <> "H" AndAlso OrderTypeId <> "D" AndAlso OrderTypeId <> "J" AndAlso OrderTypeId <> "J1" AndAlso OrderTypeId <> "G" AndAlso OrderTypeId <> "NckuCode" Then


                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   PUB_Order  A " & _
                                  " left join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                                  " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                  " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                  " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code = '" & OrderCode & "')     And '" & _
                                    Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                    Now().ToString("yyyy/M/d") & "'<= A.End_Date  "
                    Else
                        command.CommandText += " From   PUB_Order  A " & _
                                  " left join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                                  " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                  " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                  " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                    Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                    Now().ToString("yyyy/M/d") & "'<= A.End_Date  "


                        If IsOpdOnly = "Y" Then
                            command.CommandText += " And A.Insu_Cover_Opd='Y' "
                        End If

                    End If

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "G" Then '衛材


                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   PUB_Order  A " & _
                                " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code = '" & OrderCode & "')     And '" & _
                                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                  Now().ToString("yyyy/M/d") & "'<= A.End_Date  "

                    Else
                        command.CommandText += " From   PUB_Order  A " & _
                                " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                  Now().ToString("yyyy/M/d") & "'<= A.End_Date  "

                        If IsOpdOnly = "Y" Then
                            command.CommandText += " And A.Insu_Cover_Opd='Y' "
                        End If

                    End If


                    '" Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '" Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "H" Then  '檢驗檢查

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   PUB_Order A  Left Join PUB_Sheet_Detail C Left Join PUB_Sheet D On C.Sheet_Code = D.Sheet_Code And C.Dc <>'Y' And D.Dc <>'Y' On  A.Order_Code =C.Order_Code  And C.Dc <>'Y' " & _
                                " Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                " Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                "  , PUB_Order_Examination B " & _
                                " Where   (A.DC<>'Y' or A.DC is null) And A.Order_Code=B.Order_Code  And ( A.Order_Code = '" & OrderCode & "')     And '" & _
                                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                  Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                    Else
                        command.CommandText += " From   PUB_Order A  Left Join PUB_Sheet_Detail C Left Join PUB_Sheet D On C.Sheet_Code = D.Sheet_Code And C.Dc <>'Y' And D.Dc <>'Y' On  A.Order_Code =C.Order_Code  And C.Dc <>'Y' " & _
                                " Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                " Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                "  , PUB_Order_Examination B " & _
                                " Where   (A.DC<>'Y' or A.DC is null) And A.Order_Code=B.Order_Code  And ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                  Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                        If IsOpdOnly = "Y" Then
                            command.CommandText += " And A.Insu_Cover_Opd='Y' "
                        End If

                    End If

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "D" Then  '治療處置

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   PUB_Order A   Left Join PUB_Cure_Control B On A.Cure_Type_Id=B.Cure_Type_Id     " & _
                                     " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                     " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                     " Where   (A.DC<>'Y' or A.DC is null) And  ( A.Order_Code = '" & OrderCode & "')   And '" & _
                                     Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                     Now().ToString("yyyy/M/d") & "'<= A.End_Date    "
                    Else
                        command.CommandText += " From   PUB_Order A   Left Join PUB_Cure_Control B On A.Cure_Type_Id=B.Cure_Type_Id     " & _
                                     " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                     " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                     " Where   (A.DC<>'Y' or A.DC is null) And  ( A.Order_Code like '" & OrderCode & "%')   And '" & _
                                     Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                     Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                        If IsOpdOnly = "Y" Then
                            command.CommandText += " And A.Insu_Cover_Opd='Y' "
                        End If

                    End If


                    '" Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '" Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "J" Then  '手術法

                    'command.CommandText += " From   PUB_Order A   Left Join PUB_Order_Or_Treat B On A.Order_Code=B.Order_Code " & _
                    '                       " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '                       " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                    '                  " Where   (A.DC<>'Y' or A.DC is null) And  ( A.Order_Code like '" & OrderCode & "%')   And '" & _
                    '                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                    '                  Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                    If OrderCode.Contains("|") Then

                        'command.CommandText += " From   PUB_Order A    " & _
                        '               " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                        '               " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                        '               " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                        '          " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And ( S.Doctor_Dept_Code='" & Split(OrderCode, "|")(1).Trim & "' Or S.Doctor_Dept_Code='" & Split(OrderCode, "|")(2).Trim & "' ) And   ( S.Order_Code like '" & Split(OrderCode, "|")(0).Trim & "%')   And '" & _
                        '          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                        '          Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                        If IsEqualMatch = "Y" Then
                            command.CommandText += " From   PUB_Order A    " & _
                                   " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                   " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                   " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                              " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And ( S.Order_Code = '" & Split(OrderCode, "|")(0).Trim & "')   And '" & _
                              Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                              Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                        Else
                            command.CommandText += " From   PUB_Order A    " & _
                                   " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                   " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                   " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                              " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And ( S.Order_Code like '" & Split(OrderCode, "|")(0).Trim & "%')   And '" & _
                              Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                              Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                            If IsOpdOnly = "Y" Then
                                command.CommandText += " And A.Insu_Cover_Opd='Y' "
                            End If

                        End If



                    Else

                        If IsEqualMatch = "Y" Then
                            command.CommandText += " From   PUB_Order A    " & _
                                      " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                      " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                      " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                                 " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And  ( S.Order_Code = '" & OrderCode & "')   And '" & _
                                 Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                 Now().ToString("yyyy/M/d") & "'<= A.End_Date    "
                        Else
                            command.CommandText += " From   PUB_Order A    " & _
                                      " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                      " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                      " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                                 " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And  ( S.Order_Code like '" & OrderCode & "%')   And '" & _
                                 Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                 Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                            If IsOpdOnly = "Y" Then
                                command.CommandText += " And A.Insu_Cover_Opd='Y' "
                            End If

                        End If



                    End If

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "J1" Then  '批價手術法

                    'command.CommandText += " From   PUB_Order A   Left Join PUB_Order_Or_Treat B On A.Order_Code=B.Order_Code " & _
                    '                       " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '                       " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                    '                  " Where   (A.DC<>'Y' or A.DC is null) And  ( A.Order_Code like '" & OrderCode & "%')   And '" & _
                    '                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                    '                  Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                    If OrderCode.Contains("|") Then

                        'command.CommandText += " From   PUB_Order A    " & _
                        '               " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                        '               " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                        '               " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                        '          " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And ( S.Doctor_Dept_Code='" & Split(OrderCode, "|")(1).Trim & "' Or S.Doctor_Dept_Code='" & Split(OrderCode, "|")(2).Trim & "' ) And   ( S.Order_Code like '" & Split(OrderCode, "|")(0).Trim & "%')   And '" & _
                        '          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                        '          Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                        If IsEqualMatch = "Y" Then
                            command.CommandText += " From   PUB_Order  A " & _
                                  " left join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                                  " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                  " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                  " Left Join PUB_Order_Or_Treat B On B.Order_Code = A.Order_Code" & _
                                  " Where   (A.Insu_Cover_Emg = 'Y' OR A.Insu_Cover_Opd = 'Y' ) And (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                    Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                    Now().ToString("yyyy/M/d") & "'<= A.End_Date  " & _
                             "and (A.order_code in (  " & _
                             " select order_code  from pub_order_price " & _
                             "where Main_Identity_Id='2' and  Dc='N' and (insu_code  between '62001C' and '88054B' or insu_Code Between '92201B' and '92229B'  ) " & _
                             "or (A.Order_Type_Id='J' and  SUBSTRING(A.Order_Code,1,1) = 'J')))"
                        Else
                            command.CommandText += " From   PUB_Order  A " & _
                                   " left join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                                   " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                   " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                   " Left Join PUB_Order_Or_Treat B On B.Order_Code = A.Order_Code" & _
                                   " Where (A.Insu_Cover_Emg = 'Y' OR A.Insu_Cover_Opd = 'Y' ) And  (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                     Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                     Now().ToString("yyyy/M/d") & "'<= A.End_Date  " & _
                              "and (A.order_code in (  " & _
                              " select order_code  from pub_order_price " & _
                            "where Main_Identity_Id='2' and  Dc='N' and (insu_code  between '62001C' and '88054B' or insu_Code Between '92201B' and '92229B'  ) " & _
                             "or (A.Order_Type_Id='J' and  SUBSTRING(A.Order_Code,1,1) = 'J')))"

                            If IsOpdOnly = "Y" Then
                                command.CommandText += " And A.Insu_Cover_Opd='Y' "
                            End If

                        End If



                    Else

                        If IsEqualMatch = "Y" Then
                            command.CommandText += " From   PUB_Order  A " & _
                                    " left join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                                    " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                    " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                    " Left Join PUB_Order_Or_Treat B On B.Order_Code = A.Order_Code" & _
                                    " Where   (A.Insu_Cover_Emg = 'Y' OR A.Insu_Cover_Opd = 'Y' ) and (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                      Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                      Now().ToString("yyyy/M/d") & "'<= A.End_Date  " & _
                              "and (A.order_code in (  " & _
                               " select order_code  from pub_order_price " & _
                                 "where Main_Identity_Id='2' and  Dc='N' and (insu_code  between '62001C' and '88054B' or insu_Code Between '92201B' and '92229B'  ) " & _
                             "or (A.Order_Type_Id='J' and  SUBSTRING(A.Order_Code,1,1) = 'J')))"
                        Else
                            command.CommandText += " From   PUB_Order  A " & _
                                  " left join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                                  " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                  " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                  " Left Join PUB_Order_Or_Treat B On B.Order_Code = A.Order_Code" & _
                                  " Where   (A.Insu_Cover_Emg = 'Y' OR A.Insu_Cover_Opd = 'Y' ) and (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                    Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                    Now().ToString("yyyy/M/d") & "'<= A.End_Date  " & _
                            "and (A.order_code in (  " & _
                             " select order_code  from pub_order_price " & _
                              "where Main_Identity_Id='2' and  Dc='N' and (insu_code  between '62001C' and '88054B' or insu_Code Between '92201B' and '92229B'  ) " & _
                             "or (A.Order_Type_Id='J' and  SUBSTRING(A.Order_Code,1,1) = 'J')))"

                            If IsOpdOnly = "Y" Then
                                command.CommandText += " And A.Insu_Cover_Opd='Y' "
                            End If

                        End If



                    End If

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "NckuCode" Then  '成大碼轉健保碼

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From    dbo.PUB_Order_Price PP  left outer join dbo.PUB_Insu_Code as DD on ( PP.Order_Code = DD.Order_Code )   inner join PUB_Order as PO on ( PP.Order_Code = PO.Order_Code and '" & BasicDate.ToString("yyyy/M/d") & "' >= PO.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "' <= PO.End_Date  )  " & _
                                          " Where PP.Order_Code = '" & OrderCode & "' And " & _
                                          "'" & BasicDate.ToString("yyyy/M/d") & "' >= PP.Effect_Date And " & _
                                          "'" & BasicDate.ToString("yyyy/M/d") & "' <= PP.End_Date And PP.Main_Identity_Id ='2' "
                    Else
                        command.CommandText += " From    dbo.PUB_Order_Price PP  left outer join dbo.PUB_Insu_Code as DD on ( PP.Order_Code = DD.Order_Code )   inner join PUB_Order as PO on ( PP.Order_Code = PO.Order_Code and '" & BasicDate.ToString("yyyy/M/d") & "' >= PO.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "' <= PO.End_Date  )  " & _
                                          " Where PP.Order_Code like '" & OrderCode & "%' And " & _
                                          "'" & BasicDate.ToString("yyyy/M/d") & "' >= PP.Effect_Date And " & _
                                          "'" & BasicDate.ToString("yyyy/M/d") & "' <= PP.End_Date And PP.Main_Identity_Id ='2' "
                    End If



                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Split(",").Length > 1 Then
                    '2010.04.01 Add by Nick, 傳入多個Order_Type_Id
                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   PUB_Order  A " & _
                                          " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code = '" & OrderCode & "')     And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= A.End_Date  "
                    Else
                        command.CommandText += " From   PUB_Order  A " & _
                                          " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= A.End_Date  "

                        If IsOpdOnly = "Y" Then
                            command.CommandText += " And A.Insu_Cover_Opd='Y' "
                        End If

                    End If

                Else
                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   NCKUH_common.dbo.SysOrderLabItem  A  " & _
                               " Where   ( A.OrderCode = '" & OrderCode & "')      "


                    Else
                        command.CommandText += " From   NCKUH_common.dbo.SysOrderLabItem  A  " & _
                               " Where   ( A.OrderCode like '" & OrderCode & "%')      "

                    End If


                End If


                If OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim.Length = 1 AndAlso OrderTypeId.Trim <> "H" AndAlso OrderTypeId.Trim <> "D" AndAlso OrderTypeId.Trim <> "J" AndAlso OrderTypeId.Trim <> "J1" Then
                    command.CommandText += " And A.Order_Type_Id='" & OrderTypeId & "' "

                ElseIf OrderTypeId.Trim = "J" Then
                    command.CommandText += " And A.Order_Type_Id='J' "
                ElseIf OrderTypeId.Trim = "H" Then
                    command.CommandText += " And A.Order_Type_Id='H' And  A.Treatment_Type_Id in ('3' , '4')  "

                ElseIf OrderTypeId.Trim = "D" Then
                    command.CommandText += " And ( A.Order_Type_Id='D' Or  A.Order_Type_Id='J' Or  ( A.Order_Type_Id='H' And ( A.Treatment_Type_Id not in ('3' , '4','5') Or A.Treatment_Type_Id is Null ) ) ) "

                ElseIf OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim = "Often" Then
                    '醫令 -常用處置維護
                    command.CommandText += " And ( A.Order_Type_Id in ('D','K','I') Or (A.Order_Type_Id='H' And A.Treatment_Type_Id<>'3' And A.Treatment_Type_Id<>'4' And A.Treatment_Type_Id<>'5' ) ) "

                ElseIf OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim = "DepOften" Then

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Split(",").Length > 1 Then
                    '2010.04.01 Add by Nick, 傳入多個Order_Type_Id
                    command.CommandText += " And A.Order_Type_Id in (" & OrderTypeId & ")"
                End If

                If OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim <> "H" AndAlso OrderTypeId.Trim <> "J" AndAlso OrderTypeId.Trim <> "J1" Then
                    command.CommandText += " Order By  A.Order_Code "
                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "J" Then
                    command.CommandText += " Order By  A.Order_Code "
                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "J1" Then
                    command.CommandText += " Order By  A.Order_Code "
                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "H" Then
                    command.CommandText += " Order By  A.Order_Code "
                Else
                    command.CommandText += " Order By  A.OrderCode "
                End If


            ElseIf OrderEnName <> "" Then

                If OrderTypeId = "G" Then '衛材
                    'command.CommandText = " Select   A.Order_En_Name ,A.Order_Code, CAST( C.Price AS DECIMAL(18,1)) as Price , CAST( D.Price AS DECIMAL(18,1)) as Price , A.Is_Order_Check ,  A.Charge_Unit  "
                    command.CommandText = " Select   A.Order_En_Name ,A.Order_Code,   A.Is_Order_Check , A.Is_Icd_Check  ,  A.Charge_Unit  , A.Is_IC_Card_Order , A.Order_Note , A.Is_Prior_Review , A.Include_Order_Mark ,C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio'  ,D.Order_Ratio , D.Material_Ratio , D.Add_Price  "


                ElseIf OrderTypeId = "D" Then '治療處置
                    'command.CommandText = " Select   A.Order_En_Name ,A.Order_Code, CAST( C.Price AS DECIMAL(18,1)) as Price , CAST( D.Price AS DECIMAL(18,1)) as Price ,  A.Is_Cure , A.Treatment_Type_Id,A.Cure_Type_Id  ,A.Is_Order_Check  , A.Charge_Unit ,A.Order_Type_Id ,B.* "
                    command.CommandText = " Select   A.Order_En_Name ,A.Order_Code,     A.Is_Cure , A.Treatment_Type_Id,A.Cure_Type_Id  , A.Include_Order_Mark , A.Is_Order_Check , A.Is_Icd_Check  , A.Charge_Unit ,A.Order_Type_Id , A.Is_IC_Card_Order , A.Order_Note , A.Is_Prior_Review , C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio'  ,D.Order_Ratio , D.Material_Ratio , D.Add_Price   ,B.* "



                ElseIf OrderTypeId = "H" Then '檢驗檢查
                    'command.CommandText = " Select   A.Order_En_Name , A.Order_Code,   A.Is_Order_Check , B.Is_Scheduled ,B.Is_Same_Specimen_Add , A.Is_Prior_Review ,  B.Default_Body_Site_Code ,B.Default_Main_Body_Site_Code, B.Default_Specimen_Id,B.Default_Side_Id , A.Treatment_Type_Id  , A.Charge_Unit  , C.Sheet_Code ,D.Is_Emergency_Sheet, B.Is_Main_Body_Site , B.Is_Body_Site , B.Is_Side_Id , A.Is_IC_Card_Order , B.Deliver_System , B.Is_With_Contrast ,  B.Nhi_Body_Site_Code , A.Order_Note  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio  , Y.Add_Price  "
                    command.CommandText = " Select   (Case When A.Treatment_Type_Id='3' and A.Order_En_Short_Name<>'' and A.Order_En_Short_Name is not null then A.Order_En_Short_Name  When A.Treatment_Type_Id='3' and (A.Order_En_Short_Name='' or A.Order_En_Short_Name is   null) then A.Order_En_Name When A.Treatment_Type_Id='4'   then A.Order_En_Name end ) as 'Order_En_Name' , A.Order_Code , A.Include_Order_Mark  , A.Is_Order_Check , A.Is_Icd_Check  , B.Is_Scheduled , B.Is_Same_Specimen_Add , A.Is_Prior_Review , B.Default_Body_Site_Code ,B.Default_Main_Body_Site_Code ,B.Default_Side_Id ,B.Default_Specimen_Id, A.Treatment_Type_Id , A.Charge_Unit ,C.Sheet_Code , C.Separate_Mark ,D.Is_Emergency_Sheet , B.Is_Main_Body_Site , B.Is_Body_Site , B.Is_Side_Id , A.Is_IC_Card_Order , B.Deliver_System  , B.Is_With_Contrast, B.Nhi_Body_Site_Code  , B.Is_No_Separate , A.Order_Note ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price "

                ElseIf OrderTypeId = "J" Then '手術法
                    command.CommandText = " Select  S.Doctor_Dept_Code , A.Order_Name, A.Order_En_Name , A.Order_Code, S.Age_Group_Id , S.Op_Nameplate_Id, S.Nameplate_Name ,     A.Include_Order_Mark , A.Is_Order_Check , A.Is_Icd_Check  ,  A.Is_Prior_Review   , A.Treatment_Type_Id , A.Charge_Unit , B.Is_Single_Or ,B.Is_Body_Site , B.Default_Body_Site_Code , B.Default_Side_Id , A.Is_IC_Card_Order  , A.Order_Note  ,   C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio' ,D.Order_Ratio , D.Material_Ratio  , D.Add_Price  "

                ElseIf OrderTypeId = "NckuCode" Then '輸成大碼轉健保碼
                    command.CommandText = " Select  PP.Order_Code,  Case when DD.Insu_Code is null then PP.Insu_Code  else DD.Insu_Code End as detail_Insu_Code, PO.Order_En_Name, PO.Order_Name  "

                Else
                    command.CommandText = " Select A.*," + _
                                      " rtrim(POE.Deliver_System) as Deliver_System," + _
                                      " rtrim(POE.Nhi_Body_Site_Code) as Nhi_Body_Site_Code ,  C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio'  ,D.Order_Ratio , D.Material_Ratio , D.Add_Price "


                End If


                If OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim <> "H" AndAlso OrderTypeId <> "D" AndAlso OrderTypeId <> "J" AndAlso OrderTypeId <> "G" Then

                    command.CommandText += " From   PUB_Order  A " & _
                                         " left join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code " & _
                                         " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                         " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                         " Where   (A.DC<>'Y' or A.DC is null) And  (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= A.End_Date  "

                    If IsOpdOnly = "Y" Then
                        command.CommandText += " And A.Insu_Cover_Opd='Y' "
                    End If

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "G" Then '衛材

                    command.CommandText += " From   PUB_Order  A " & _
                                        " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                        " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                        " Where   (A.DC<>'Y' or A.DC is null) And  (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= A.End_Date  "

                    If IsOpdOnly = "Y" Then
                        command.CommandText += " And A.Insu_Cover_Opd='Y' "
                    End If

                    '" Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '" Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _


                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "H" Then '檢驗檢查

                    command.CommandText += " From   PUB_Order A  Left Join PUB_Sheet_Detail C Left Join PUB_Sheet D On C.Sheet_Code = D.Sheet_Code And C.Dc <>'Y' And D.Dc <>'Y' On  A.Order_Code =C.Order_Code  And C.Dc <>'Y'   " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                           "  , PUB_Order_Examination B " & _
                                        " Where   (A.DC<>'Y' or A.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                    If IsOpdOnly = "Y" Then
                        command.CommandText += " And A.Insu_Cover_Opd='Y' "
                    End If

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "D" Then  '治療處置
                    command.CommandText += " From   PUB_Order A   Left Join PUB_Cure_Control B On A.Cure_Type_Id=B.Cure_Type_Id     " & _
                                          " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                          " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                          " Where   (A.DC<>'Y' or A.DC is null) And  (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                    If IsOpdOnly = "Y" Then
                        command.CommandText += " And A.Insu_Cover_Opd='Y' "
                    End If

                    '" Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '" Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _


                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "J" Then  '手術

                    'command.CommandText += " From   PUB_Order A   Left Join PUB_Order_Or_Treat B On A.Order_Code=B.Order_Code " & _
                    '                       " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '                       " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                    '                      " Where   (A.DC<>'Y' or A.DC is null) And  (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                    '                      Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                    '                      Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                    If OrderEnName.Trim.Contains("|") Then


                        'command.CommandText += " From   PUB_Order A   " & _
                        '           " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                        '           " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                        '           " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                        '          " Where  S.Order_Code=A.Order_Code And (A.DC<>'Y' or A.DC is null) And ( S.Doctor_Dept_Code='" & Split(OrderEnName, "|")(1).Trim & "' Or S.Doctor_Dept_Code='" & Split(OrderEnName, "|")(2).Trim & "' )  And (  A.Order_En_Name like '" & Split(OrderEnName, "|")(0).Trim & "%')   And '" & _
                        '          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                        '          Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                        '不綁科別了
                        command.CommandText += " From   PUB_Order A   " & _
                                   " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                   " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                   " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                                  " Where  S.Order_Code=A.Order_Code And (A.DC<>'Y' or A.DC is null)   And (  A.Order_En_Name like '" & Split(OrderEnName, "|")(0).Trim & "%')   And '" & _
                                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                  Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                        If IsOpdOnly = "Y" Then
                            command.CommandText += " And A.Insu_Cover_Opd='Y' "
                        End If

                    Else

                        command.CommandText += " From   PUB_Order A   " & _
                                   " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                   " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                   " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                                  " Where  S.Order_Code=A.Order_Code And (A.DC<>'Y' or A.DC is null) And  (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                  Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                        If IsOpdOnly = "Y" Then
                            command.CommandText += " And A.Insu_Cover_Opd='Y' "
                        End If
                    End If


                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "NckuCode" Then  '成大碼轉健保碼
                    'command.CommandText += " FROM PUB_Order A ,PUB_Order_Price B  " & _
                    '                       " Where A.Order_Code =B.Order_Code And B.Main_Identity_Id = '2' And B.Insu_Code <> '' And '" & _
                    '                         BasicDate.ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                    '                         BasicDate.ToString("yyyy/M/d") & "'<= B.End_Date    And " & _
                    '                        " B.Insu_Code<>'ZZZZZZ' And (  A.Order_En_Name like '" & OrderEnName & "%' ) And A.Dc='N' "


                    '只能用Order_Code 去找 ( 成大碼轉健保碼 )
                    command.CommandText += " From    dbo.PUB_Order_Price PP  left outer join dbo.PUB_Insu_Code as DD on ( PP.Order_Code = DD.Order_Code )   inner join PUB_Order as PO on ( PP.Order_Code = PO.Order_Code and '" & BasicDate.ToString("yyyy/M/d") & "' >= PO.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "' <= PO.End_Date  )  " & _
                                          " Where PP.Order_Code like '" & OrderCode & "%' And " & _
                                          "'" & BasicDate.ToString("yyyy/M/d") & "' >= PP.Effect_Date And " & _
                                          "'" & BasicDate.ToString("yyyy/M/d") & "' <= PP.End_Date And PP.Main_Identity_Id ='2' "


                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Split(",").Length > 1 Then
                    '2010.04.01 Add by Nick, 傳入多個Order_Type_Id
                    command.CommandText += " From   PUB_Order  A " & _
                                           " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= A.End_Date  "
                Else

                    command.CommandText += " From   NCKUH_common.dbo.SysOrderLabItem A   " & _
                               " Where   ( A.OrderCode like '" & OrderCode & "%')      "

                End If

                If OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim.Length = 1 AndAlso OrderTypeId.Trim <> "H" AndAlso OrderTypeId.Trim <> "D" AndAlso OrderTypeId.Trim <> "J" Then
                    command.CommandText += " And A.Order_Type_Id='" & OrderTypeId & "' "

                ElseIf OrderTypeId.Trim = "J" Then
                    command.CommandText += " And A.Order_Type_Id='J' "

                ElseIf OrderTypeId.Trim = "H" Then
                    command.CommandText += " And A.Order_Type_Id='H' And  A.Treatment_Type_Id in ('3' , '4')  "

                ElseIf OrderTypeId.Trim = "D" Then
                    command.CommandText += " And ( A.Order_Type_Id='D' Or  A.Order_Type_Id='J' Or  ( A.Order_Type_Id='H' And  ( A.Treatment_Type_Id not in ('3' , '4','5') Or A.Treatment_Type_Id is Null ) ) ) "

                ElseIf OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim = "Often" Then
                    '醫令 -常用處置維護
                    command.CommandText += " And ( A.Order_Type_Id in ('D','K','I') Or (A.Order_Type_Id='H' And A.Treatment_Type_Id<>'3' And A.Treatment_Type_Id<>'4' And A.Treatment_Type_Id<>'5' ) ) "

                ElseIf OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim = "DepOftenH" Then

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Split(",").Length > 1 Then
                    '2010.04.01 Add by Nick, 傳入多個Order_Type_Id
                    command.CommandText += " And A.Order_Type_Id in (" & OrderTypeId & ")"

                End If


                If OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim <> "H" AndAlso OrderTypeId.Trim <> "J" Then
                    command.CommandText += " Order By  A.Order_Code "
                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "J" Then
                    command.CommandText += " Order By  A.Order_Code "
                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "H" Then
                    command.CommandText += " Order By  A.Order_Code "
                Else
                    command.CommandText += " Order By  A.OrderCode "
                End If

            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)

            End Using
            Return ds


        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

#Region "控管項目維護-同類藥 ADD BY MARKWU"

    ''' <summary>
    ''' 查詢藥名
    ''' </summary>
    ''' <param name="Pharmacy_12_code">成大十二碼藥名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OPHControlItemQueryDrug(ByVal Pharmacy_12_code As String) As DataSet
        Try
            Dim returnDS As DataSet
            Dim tableName As String = "OPH_Pharmacy_Base"
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "SELECT  OPB.Pharmacy_12_code, RTRIM(OPB.Pharmacy_Name)  from OPH_Pharmacy_Base as OPB Where OPB.Pharmacy_12_code like '%" + Pharmacy_12_code + "%'"
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                returnDS = New DataSet(tableName)
                adapter.Fill(returnDS, tableName)

            End Using


            Return returnDS

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

#Region "急住"


    Public Function DoUclAction(ByVal ds As DataSet) As DataSet

        Try

            If ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Disease_IcdCode" Then
                Return queryPUBDiseaseE(ds)
            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Disease_Package" Then
                Return queryPUBDiseasePackage(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Disease_IsSevereDisease" Then
                Return queryPUBDiseaseE(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Order_Mixed" Then
                Return queryPUBOrderMixed(ds)
            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Order_Insu" Then
                Return queryPUBOrderInsu(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "NormalDrug2" Then
                Return queryOPHPharmacyBaseE(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Order" Then
                Return queryPUBOrderE(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Order_Material" Then
                Return queryPUBOrderE(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Order_Cure" Then
                Return queryPUBOrderE(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Order_Examine" Then
                Return queryPUBOrderE(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Order_Operation" Then
                Return queryPUBOrderE(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Order_Often" Then
                Return queryPUBOrderE(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Order_DepOftenH" Then
                Return queryPUBOrderE(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Order_InsuCode" Then
                Return queryPUBOrderE(ds)
            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Add_Order" Then
                Return queryPUBAddOrder()
            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_Add_Order_Detail" Then
                Return queryPUBAddOrderDetail(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "PUB_NHI_Hospital" Then
                Return queryPubNhiHospital(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "UclSaveClientLog" Then
                ' 儲存Client Log
                Return UclSaveClientLog(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "IHD_Appeal_Dispute_Reason" Then
                ' 儲存Client Log
                Return queryIHDAppealDisputeReason(ds)
            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "QueryComboBoxUCDataSource" Then
                ' 快捷平台查詢下拉選單資料來源
                Return QueryComboBoxUCDataSource(ds)

            Else
                Return Nothing
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    '隨輸隨選 混合開立 PUB_Order_Mixed
    Public Function queryPUBOrderMixed(ByVal DataDS As DataSet) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim BasicDate As Date = Now

            Dim BasicDateStr As String = ""

            Dim OrderCode As String = DataDS.Tables(0).Rows(0).Item("Code").ToString.Trim
            Dim OrderEnName As String = DataDS.Tables(0).Rows(0).Item("Name").ToString.Trim
            Dim OrderTypeId As String = DataDS.Tables(0).Rows(0).Item("OrderTypeId").ToString.Trim
            Dim MultiOrderTypeId As String = ""

            Dim Is_OPD As String = DataDS.Tables(0).Rows(0).Item("Is_OPD").ToString.Trim
            Dim Is_IPD As String = DataDS.Tables(0).Rows(0).Item("Is_IPD").ToString.Trim
            Dim Is_EPD As String = DataDS.Tables(0).Rows(0).Item("Is_EPD").ToString.Trim
            Dim Is_ShowPrice As String = DataDS.Tables(0).Rows(0).Item("Is_ShowPrice").ToString.Trim
            Dim Is_ChemoDrug As String = "N"
            Dim Is_AllChemoDrug As String = "N"
            Dim Is_Prior_Review As String = ""
            Dim IsEqualMatch As String = "N"
            Dim IsCheckPubOrderDc As String = "Y"
            Dim IsChoiceDcOrder As String = "N"
            Dim Form_Kind_Id As String = ""
            Dim FormKindIdSQL As String = ""

            Dim pub As PUBDelegate = PUBDelegate.getInstance
            Dim IsChoiceDcOrderDS As DataSet = pub.queryPUBConfigByPK("Choice_Dc_Order")
            If IsChoiceDcOrderDS IsNot Nothing AndAlso IsChoiceDcOrderDS.Tables(0).Rows.Count > 0 AndAlso IsChoiceDcOrderDS.Tables(0).Rows(0).Item("Config_Value").ToString.Trim = "Y" Then
                IsChoiceDcOrder = "Y"
            End If

            If DataDS.Tables(0).Columns.Contains("Choice_Dc_Order") Then
                IsChoiceDcOrder = DataDS.Tables(0).Rows(0).Item("Choice_Dc_Order").ToString.Trim
            End If

            If DataDS.Tables(0).Columns.Contains("MultiOrderTypeId") Then
                MultiOrderTypeId = DataDS.Tables(0).Rows(0).Item("MultiOrderTypeId").ToString.Trim
            End If

            If DataDS.Tables(0).Columns.Contains("Is_ChemoDrug") AndAlso DataDS.Tables(0).Rows(0).Item("Is_ChemoDrug").ToString.Trim = "Y" Then
                Is_ChemoDrug = "Y"
            End If

            If DataDS.Tables(0).Columns.Contains("Is_AllChemoDrug") AndAlso DataDS.Tables(0).Rows(0).Item("Is_AllChemoDrug").ToString.Trim = "Y" Then
                Is_AllChemoDrug = "Y"
            End If

            If DataDS.Tables(0).Columns.Contains("IsEqualMatch") AndAlso DataDS.Tables(0).Rows(0).Item("IsEqualMatch").ToString.Trim = "Y" Then
                IsEqualMatch = "Y"
            End If

            If DataDS.Tables(0).Columns.Contains("Is_Prior_Review") AndAlso DataDS.Tables(0).Rows(0).Item("Is_Prior_Review").ToString.Trim = "Y" Then
                Is_Prior_Review = "Y"
            End If

            If DataDS.Tables(0).Columns.Contains("IsCheckPubOrderDc") AndAlso DataDS.Tables(0).Rows(0).Item("IsCheckPubOrderDc").ToString.Trim = "Y" Then
                IsCheckPubOrderDc = "Y"
            End If

            If DataDS.Tables(0).Columns.Contains("BasicDateStr") Then
                BasicDateStr = DataDS.Tables(0).Rows(0).Item("BasicDateStr").ToString.Trim
            End If

            If BasicDateStr <> "" AndAlso IsDate(BasicDateStr) Then
                BasicDate = CDate(BasicDateStr)
            End If

            If DataDS.Tables(0).Columns.Contains("Form_Kind_Id") Then
                Form_Kind_Id = DataDS.Tables(0).Rows(0).Item("Form_Kind_Id").ToString.Trim
                If Form_Kind_Id <> "" Then
                    FormKindIdSQL = " And B.Form_Kind_Id='" & Form_Kind_Id & "' "
                End If
            End If

            If FormKindIdSQL = "" Then
                If Is_AllChemoDrug = "Y" Then
                    FormKindIdSQL = ""
                Else
                    FormKindIdSQL = " And B.Form_Kind_Id='O'"
                End If
            End If


            Dim SourceFlag As String = ""

            If Is_OPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='Y' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='Y' "
                End If
            ElseIf Is_OPD.Trim = "C" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                End If
            ElseIf Is_OPD.Trim = "H" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='H' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='H' "
                End If
            End If

            If Is_IPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Ipd='Y' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Ipd='Y' "
                End If
            ElseIf Is_IPD.Trim = "C" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                End If
            ElseIf Is_IPD.Trim = "H" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Ipd='H' Or A.Insu_Cover_Ipd='H' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Ipd='H' Or A.Insu_Cover_Ipd='H' "
                End If
            End If

            If Is_EPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Emg='Y' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Emg='Y' "
                End If
            ElseIf Is_EPD.Trim = "C" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                End If
            ElseIf Is_EPD.Trim = "H" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Emg='H' Or A.Insu_Cover_Emg='H' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Emg='H' Or A.Insu_Cover_Emg='H' "
                End If
            End If
            '====================
            If OrderCode <> "" Then
                'Order_Code
                command.CommandText = " Select Distinct RTRIM(A.Order_Code) as 'Order_Code' , RTRIM(A.Order_En_Name) as 'Order_En_Name', RTRIM(B.Scientific_Name) as 'Scientific_Name' , RTRIM(B.Trade_Name) as 'Trade_Name' , RTRIM(B.Specification) as 'Specification' , Rtrim(B.Supply_Status_Memo) as  'Supply_Status_Memo' ,B.Opd_Lack_Id , B.Emg_Lack_Id , B.Ipd_Lack_Id ,B.Pharmacy_12_Code , B.Usage_Code , B.Frequency_Code ,B.Order_Default_Dosage  ,B.Dosage_unit ,B.Base_Dosage , B.Base_Dosage_Unit,B.Order_Unit1 , B.Order_Unit2 ,B.Order_Unit3 ,B.Order_Unit4 ,B.Order_Unit5 ,B.Class_Code  , B.Is_Control_Rule ,B.Form_Kind_Id , B.Is_Non_Powder , B.Package_Qty , B.Pharmacy_Name , B.Alert_Content, B.Order_Default_Days ,'' as 'ATC_Code' , A.Is_Order_Check , A.Is_Icd_Check , A.Charge_Unit  , A.Is_IC_Card_Order ,   A.Is_Prior_Review,  A.Include_Order_Mark ,A.Is_Cure , A.Account_Id ,A.DC , A.Dc_Reason , A.Order_Name , A.Is_Alternative ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio', X.Opd_Add_Order_Code as 'Self_Opd_Add_Order_Code' ,  X.Emg_Add_Order_Code as 'Self_Emg_Add_Order_Code' , X.Ipd_Add_Order_Code as 'Self_Ipd_Add_Order_Code' , X.Charge_Flag  as 'Self_Charge_Flag' , X.Add_Price  as 'Self_Add_Price' , Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , Y.Opd_Add_Order_Code as 'Opd_Add_Order_Code' ,  Y.Emg_Add_Order_Code as 'Emg_Add_Order_Code' , Y.Ipd_Add_Order_Code as 'Ipd_Add_Order_Code' , Y.Charge_Flag  as 'Nhi_Charge_Flag' , Y.Insu_Code , A.Order_Type_Id  ,A.Treatment_Type_Id   , POE.Is_Scheduled , POE.Is_Same_Specimen_Add ,   POE.Default_Body_Site_Code ,POE.Default_Main_Body_Site_Code ,POE.Default_Side_Id ,POE.Default_Specimen_Id,  E.Sheet_Code , E.Separate_Mark ,E.Is_InstantlyRpt ,F.Is_Emergency_Sheet , POE.Is_Main_Body_Site , POE.Is_Body_Site , POE.Is_Side_Id  , POE.Deliver_System  , POE.Is_With_Contrast, POE.Nhi_Body_Site_Code , POE.Is_No_Separate , POE.Is_No_Check_In ,   G.* , Case When (Select count(Pharmacy_12_Code) from OPH_Property Where Pharmacy_12_Code=A.Order_Code And Property_Id In('11B','11C','11D','11E'))> 0 Then 'True' Else 'False' End  Is_Needed_Consultation , Case When  ('" & BasicDate.ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "'<= A.End_Date ) And A.Dc <>'Y' Then 'Y' else 'N' End As Is_Valid_Order, POMS.Vessel_Id as Vessel_Id "
                command.CommandText += " From   PUB_Order  A "
                If Is_ChemoDrug = "N" Then
                    command.CommandText += " Left Join OPH_Pharmacy_Base B On A.Order_Code=B.Order_Code   Left Join OPH_Property C  ON B.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ) Left Join  OPH_Code D On D.Type_Id ='8' And B.Omo_Reminder_Id =D.Code_Id And D.DC<>'Y'   "
                Else
                    command.CommandText += " Inner Join OPH_Pharmacy_Base B On A.Order_Code=B.Order_Code  Left Join OPH_Property C  ON B.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id ='10' Left Join  OPH_Code D On D.Type_Id ='8' And B.Omo_Reminder_Id =D.Code_Id And D.DC<>'Y'  "
                End If

                command.CommandText += " Left Join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                              " Left Join PUB_Sheet_Detail E Left Join PUB_Sheet F On E.Sheet_Code = F.Sheet_Code And E.Dc <>'Y' And F.Dc <>'Y' On  A.Order_Code =E.Order_Code  And E.Dc <>'Y' " & _
                              " Left Join PUB_Cure_Control G On A.Cure_Type_Id=G.Cure_Type_Id " & _
                              " Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & BasicDate.ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "'<= X.End_Date " & _
                              " Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & BasicDate.ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                              " left Join PUB_Order_Mapping_Specimen POMS On E.Order_Code = POMS.Order_Code and E.DC<>'Y' And POMS.Vessel_Id='11' And E.Sheet_Code='L5' " & _
                              " Where   1=1 And "



                If IsEqualMatch = "Y" Then
                    command.CommandText += " ( A.Order_Code = '" & OrderCode & "')  And (ISNULL(C.Property_Id,'') not in ('09','10')  Or (ISNULL(C.Property_Id,'') = '10'  " & FormKindIdSQL & "  ))" '2016/10/13 sophia :醫囑開立藥品可開化療藥
                Else
                    command.CommandText += " ( A.Order_Code like '" & OrderCode & "%')  And (ISNULL(C.Property_Id,'') not in ('09','10')  Or (ISNULL(C.Property_Id,'') = '10' " & FormKindIdSQL & " ))" '2016/10/13 sophia :醫囑開立藥品可開化療藥
                End If

                If OrderTypeId <> "" Then
                    If OrderTypeId = "D" Then
                        '處置
                        command.CommandText += " And ( A.Order_Type_Id='D'  Or  ( A.Order_Type_Id='H' And ( A.Treatment_Type_Id not in ('3','4') Or A.Treatment_Type_Id is Null ) ) ) "

                    ElseIf OrderTypeId = "H" Then
                        '檢驗查
                        command.CommandText += " And  A.Order_Type_Id = '" & OrderTypeId & "' "
                        command.CommandText += " And  A.Treatment_Type_Id in ('3','4')   "
                    Else
                        '其他
                        command.CommandText += " And  A.Order_Type_Id = '" & OrderTypeId & "' "
                    End If
                End If

                If Is_ChemoDrug = "Y" Then
                    command.CommandText += " And  A.Order_Type_Id = 'E' "
                End If

                If IsChoiceDcOrder = "N" Then

                    command.CommandText += " And '" & BasicDate.ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                 BasicDate.ToString("yyyy/M/d") & "'<= A.End_Date  "

                    command.CommandText += " And (A.DC<>'Y' or A.DC is null) "
                End If

                'If IsCheckPubOrderDc = "Y" Then
                '    command.CommandText += " And (A.DC<>'Y' or A.DC is null) "
                'End If

                If MultiOrderTypeId <> "" Then
                    If MultiOrderTypeId.Contains("D") Then
                        command.CommandText += " And A.Order_Type_Id in (" & MultiOrderTypeId & ",'H') And ((isnull(A.Treatment_Type_Id,'') Not in('3','4')) or (substring(A.order_code,1,2) = '28')) "
                    Else
                        command.CommandText += " And A.Order_Type_Id in (" & MultiOrderTypeId & ")  "
                    End If
                End If

                If SourceFlag <> "" Then
                    command.CommandText += " And  ( " & SourceFlag & " )   "
                End If

                If Is_Prior_Review <> "" Then
                    command.CommandText += " And  A.Is_Prior_Review='" & Is_Prior_Review & "'   "
                End If

                'command.CommandText += " Order By  A.Order_Code "
                command.CommandText += " Order By  Is_Valid_Order DESC , Order_Code "

            Else
                'Order_En_Name
                command.CommandText = " Select Distinct RTRIM(A.Order_Code) as 'Order_Code' , RTRIM(A.Order_En_Name) as 'Order_En_Name', RTRIM(B.Scientific_Name) as 'Scientific_Name' , RTRIM(B.Trade_Name) as 'Trade_Name' , RTRIM(B.Specification) as 'Specification' , Rtrim(B.Supply_Status_Memo) as  'Supply_Status_Memo' ,B.Opd_Lack_Id , B.Emg_Lack_Id , B.Ipd_Lack_Id ,B.Pharmacy_12_Code , B.Usage_Code , B.Frequency_Code ,B.Order_Default_Dosage  ,B.Dosage_unit ,B.Base_Dosage , B.Base_Dosage_Unit,B.Order_Unit1 , B.Order_Unit2 ,B.Order_Unit3 ,B.Order_Unit4 ,B.Order_Unit5 ,B.Class_Code  , B.Is_Control_Rule ,B.Form_Kind_Id , B.Is_Non_Powder , B.Package_Qty , B.Pharmacy_Name , B.Alert_Content , B.Order_Default_Days ,'' as 'ATC_Code' , A.Is_Order_Check , A.Is_Icd_Check , A.Charge_Unit  , A.Is_IC_Card_Order ,   A.Is_Prior_Review,  A.Include_Order_Mark ,A.Is_Cure , A.Account_Id ,A.DC , A.Dc_Reason , A.Order_Name  , A.Is_Alternative ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio', X.Opd_Add_Order_Code as 'Self_Opd_Add_Order_Code' ,  X.Emg_Add_Order_Code as 'Self_Emg_Add_Order_Code' , X.Ipd_Add_Order_Code as 'Self_Ipd_Add_Order_Code' , X.Charge_Flag  as 'Self_Charge_Flag' , X.Add_Price  as 'Self_Add_Price' , Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , Y.Opd_Add_Order_Code as 'Opd_Add_Order_Code' ,  Y.Emg_Add_Order_Code as 'Emg_Add_Order_Code' , Y.Ipd_Add_Order_Code as 'Ipd_Add_Order_Code' , Y.Charge_Flag  as 'Nhi_Charge_Flag' , Y.Insu_Code , A.Order_Type_Id  ,A.Treatment_Type_Id   , POE.Is_Scheduled , POE.Is_Same_Specimen_Add ,   POE.Default_Body_Site_Code ,POE.Default_Main_Body_Site_Code ,POE.Default_Side_Id ,POE.Default_Specimen_Id,  E.Sheet_Code , E.Separate_Mark ,E.Is_InstantlyRpt ,F.Is_Emergency_Sheet , POE.Is_Main_Body_Site , POE.Is_Body_Site , POE.Is_Side_Id  , POE.Deliver_System  , POE.Is_With_Contrast, POE.Nhi_Body_Site_Code , POE.Is_No_Separate , POE.Is_No_Check_In ,   G.* , Case When (Select count(Pharmacy_12_Code) from OPH_Property Where Pharmacy_12_Code=A.Order_Code And Property_Id In('11B','11C','11D','11E'))> 0 Then 'True' Else 'False' End  Is_Needed_Consultation , Case When  ('" & BasicDate.ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "'<= A.End_Date ) And A.Dc <>'Y' Then 'Y' else 'N' End As Is_Valid_Order, CASE WHEN POMS.Vessel_Id IS NOT NULL AND POMS.Vessel_Id <>'' THEN '11' ELSE '' END AS VESSEL_ID "
                command.CommandText += " From   PUB_Order  A "
                If Is_ChemoDrug = "N" Then
                    command.CommandText += " Left Join OPH_Pharmacy_Base B On A.Order_Code=B.Order_Code   Left Join OPH_Property C  ON B.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10'  ) Left Join  OPH_Code D On D.Type_Id ='8' And B.Omo_Reminder_Id =D.Code_Id And D.DC<>'Y' "
                Else
                    command.CommandText += " Inner Join OPH_Pharmacy_Base B On A.Order_Code=B.Order_Code  Left Join OPH_Property C  ON B.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id ='10'  Left Join  OPH_Code D On D.Type_Id ='8' And B.Omo_Reminder_Id =D.Code_Id And D.DC<>'Y'   "
                End If

                command.CommandText += " Left Join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                                 " Left Join PUB_Sheet_Detail E Left Join PUB_Sheet F On E.Sheet_Code = F.Sheet_Code And E.Dc <>'Y' And F.Dc <>'Y' On  A.Order_Code =E.Order_Code  And E.Dc <>'Y' " & _
                                 " Left Join PUB_Cure_Control G On A.Cure_Type_Id=G.Cure_Type_Id " & _
                                 " Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & BasicDate.ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                 " Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & BasicDate.ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                 " Left Join PUB_Order_Mapping_Specimen POMS On E.Order_Code = POMS.Order_Code and E.DC<>'Y' And POMS.Vessel_Id='11' And E.Sheet_Code='L5' " & _
                                 " Where   ( A.Order_En_Name like '%" & OrderEnName & "%' Or B.Scientific_Name like '%" & OrderEnName & "%' Or B.Trade_Name like '%" & OrderEnName & "%' )    "


                If OrderTypeId <> "" Then
                    If OrderTypeId = "D" Then
                        '處置
                        command.CommandText += " And ( A.Order_Type_Id='D'  Or  ( A.Order_Type_Id='H' And ( A.Treatment_Type_Id not in ('3','4') Or A.Treatment_Type_Id is Null ) ) ) "

                    ElseIf OrderTypeId = "H" Then
                        '檢驗查
                        command.CommandText += " And  A.Order_Type_Id = '" & OrderTypeId & "' "
                        command.CommandText += " And  A.Treatment_Type_Id in ('3','4')   "
                    Else
                        '其他
                        command.CommandText += " And  A.Order_Type_Id = '" & OrderTypeId & "' "
                    End If
                End If

                If Is_ChemoDrug = "Y" Then
                    command.CommandText += " And  A.Order_Type_Id = 'E' " & FormKindIdSQL
                End If

                If IsChoiceDcOrder = "N" Then

                    command.CommandText += " And '" & BasicDate.ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                 BasicDate.ToString("yyyy/M/d") & "'<= A.End_Date  "

                    command.CommandText += " And (A.DC<>'Y' or A.DC is null) "
                End If

                'If IsCheckPubOrderDc = "Y" Then
                '    command.CommandText += " And (A.DC<>'Y' or A.DC is null) "
                'End If

                If MultiOrderTypeId <> "" Then
                    If MultiOrderTypeId.Contains("D") Then
                        command.CommandText += " And A.Order_Type_Id in (" & MultiOrderTypeId & ",'H') And ((isnull(A.Treatment_Type_Id,'') Not in('3','4')) or (substring(A.order_code,1,2) = '28')) "
                    Else
                        command.CommandText += " And A.Order_Type_Id in (" & MultiOrderTypeId & ")  "
                    End If
                End If

                If SourceFlag <> "" Then
                    command.CommandText += " And  ( " & SourceFlag & " )   "
                End If

                If Is_Prior_Review <> "" Then
                    command.CommandText += " And  A.Is_Prior_Review='" & Is_Prior_Review & "'   "
                End If

                'command.CommandText += " Order By  A.Order_Code "
                command.CommandText += " Order By  Is_Valid_Order DESC , Order_Code "
            End If

            command.CommandText += ";     "
            command.CommandText += " select Config_Value  from PUB_Config where Config_Name ='UclOrderMixedNew'   "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Try
                If ds.Tables(ds.Tables.Count - 1).Rows.Count > 0 AndAlso ds.Tables(ds.Tables.Count - 1).Rows(0).Item("Config_Value").ToString.Trim = "Y" Then
                    ds.Tables(0).Columns.Add("UclOrderMixedNew")
                    ds.Tables.RemoveAt(ds.Tables.Count - 1)
                End If
            Catch ex As Exception

            End Try
          
            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    '隨輸隨選   queryPUBOrderInsu
    Public Function queryPUBOrderInsu(ByVal DataDS As DataSet) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim BasicDate As Date = Now

            Dim BasicDateStr As String = ""

            Dim InsuCode As String = DataDS.Tables(0).Rows(0).Item("Code").ToString.Trim
            Dim OrderEnName As String = DataDS.Tables(0).Rows(0).Item("Name").ToString.Trim
            Dim OrderTypeId As String = DataDS.Tables(0).Rows(0).Item("OrderTypeId").ToString.Trim
            Dim MultiOrderTypeId As String = ""

            Dim Is_OPD As String = DataDS.Tables(0).Rows(0).Item("Is_OPD").ToString.Trim
            Dim Is_IPD As String = DataDS.Tables(0).Rows(0).Item("Is_IPD").ToString.Trim
            Dim Is_EPD As String = DataDS.Tables(0).Rows(0).Item("Is_EPD").ToString.Trim
            Dim Is_ShowPrice As String = DataDS.Tables(0).Rows(0).Item("Is_ShowPrice").ToString.Trim
            Dim Is_Prior_Review As String = ""
            Dim IsEqualMatch As String = "N"

            If DataDS.Tables(0).Columns.Contains("MultiOrderTypeId") Then
                MultiOrderTypeId = DataDS.Tables(0).Rows(0).Item("MultiOrderTypeId").ToString.Trim
            End If

            If DataDS.Tables(0).Columns.Contains("IsEqualMatch") AndAlso DataDS.Tables(0).Rows(0).Item("IsEqualMatch").ToString.Trim = "Y" Then
                IsEqualMatch = "Y"
            End If

            If DataDS.Tables(0).Columns.Contains("Is_Prior_Review") AndAlso DataDS.Tables(0).Rows(0).Item("Is_Prior_Review").ToString.Trim = "Y" Then
                Is_Prior_Review = "Y"
            End If

            If BasicDateStr <> "" AndAlso IsDate(BasicDateStr) Then
                BasicDate = CDate(BasicDateStr)
            End If

            Dim SourceFlag As String = ""

            If Is_OPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='Y' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='Y' "
                End If
            ElseIf Is_OPD.Trim = "C" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                End If
            ElseIf Is_OPD.Trim = "H" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='H' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='H' "
                End If
            End If

            If Is_IPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Ipd='Y' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Ipd='Y' "
                End If
            ElseIf Is_IPD.Trim = "C" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                End If
            ElseIf Is_IPD.Trim = "H" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Ipd='H' Or A.Insu_Cover_Ipd='H' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Ipd='H' Or A.Insu_Cover_Ipd='H' "
                End If
            End If

            If Is_EPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Emg='Y' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Emg='Y' "
                End If
            ElseIf Is_EPD.Trim = "C" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                End If
            ElseIf Is_EPD.Trim = "H" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Emg='H' Or A.Insu_Cover_Emg='H' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Emg='H' Or A.Insu_Cover_Emg='H' "
                End If
            End If
            '====================
            If InsuCode <> "" Then
                'Insu_Code
                command.CommandText = " Select Distinct RTRIM(Y.Insu_Code) as 'Insu_Code' ,  RTRIM(A.Order_En_Name) as 'Order_En_Name', RTRIM(A.Order_Code) as 'Order_Code' , RTRIM(B.Scientific_Name) as 'Scientific_Name' , RTRIM(B.Trade_Name) as 'Trade_Name' , RTRIM(B.Specification) as 'Specification' , Rtrim(B.Supply_Status_Memo) as  'Supply_Status_Memo' ,B.Opd_Lack_Id , B.Emg_Lack_Id , B.Ipd_Lack_Id ,B.Pharmacy_12_Code , B.Usage_Code , B.Frequency_Code ,B.Order_Default_Dosage  ,B.Dosage_unit ,B.Base_Dosage , B.Base_Dosage_Unit,B.Order_Unit1 , B.Order_Unit2 ,B.Order_Unit3 ,B.Order_Unit4 ,B.Order_Unit5 ,B.Class_Code  , B.Is_Control_Rule ,B.Form_Kind_Id , B.Is_Non_Powder , B.Package_Qty , B.Pharmacy_Name , B.Alert_Content, A.Is_Order_Check , A.Is_Icd_Check , A.Charge_Unit  , A.Is_IC_Card_Order ,   A.Is_Prior_Review,  A.Include_Order_Mark ,A.Is_Cure , A.Account_Id ,     Y.Price as 'Price' ,    Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , Y.Opd_Add_Order_Code as 'Opd_Add_Order_Code' ,  Y.Emg_Add_Order_Code as 'Emg_Add_Order_Code' , Y.Ipd_Add_Order_Code as 'Ipd_Add_Order_Code' , Y.Insu_Code , A.Order_Type_Id  ,A.Treatment_Type_Id        "
                command.CommandText += " From   PUB_Order  A " & _
                                 " Left Join OPH_Pharmacy_Base B On A.Order_Code=B.Order_Code And B.Dc <>'Y' Left Join OPH_Property C  ON B.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10'  ) Left Join  OPH_Code D On D.Type_Id ='8' And B.Omo_Reminder_Id =D.Code_Id And D.DC<>'Y' " & _
                                 " Inner Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                 " Where   (A.DC<>'Y' or A.DC is null) And "
                If IsEqualMatch = "Y" Then
                    command.CommandText += " ( Y.Insu_Code = '" & InsuCode & "') And '"
                Else
                    command.CommandText += " ( Y.Insu_Code like '" & InsuCode & "%') And '"
                End If

                command.CommandText += Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                   Now().ToString("yyyy/M/d") & "'<= A.End_Date  "

                If OrderTypeId <> "" Then
                    command.CommandText += " And A.Order_Type_Id = '" & OrderTypeId & "'  "

                    If OrderTypeId = "H" Then
                        command.CommandText += " And  ( A.Treatment_Type_Id = '3' Or A.Treatment_Type_Id = '4' )   "
                    End If
                End If

                If MultiOrderTypeId <> "" Then
                    command.CommandText += " And A.Order_Type_Id in (" & MultiOrderTypeId & ")  "
                End If

                If SourceFlag <> "" Then
                    command.CommandText += " And  ( " & SourceFlag & " )   "
                End If

                If Is_Prior_Review <> "" Then
                    command.CommandText += " And  A.Is_Prior_Review='" & Is_Prior_Review & "'   "
                End If

                'command.CommandText += " Order By  A.Order_Code "
            Else
                Return Nothing
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    '隨輸隨選 醫令 PUB_Order
    Public Function queryPUBOrderE(ByVal DataDS As DataSet) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim BasicDate As Date = Now

            Dim BasicDateStr As String = ""

            Dim OrderCode As String = DataDS.Tables(0).Rows(0).Item("Code").ToString.Trim
            Dim OrderEnName As String = DataDS.Tables(0).Rows(0).Item("Name").ToString.Trim
            Dim OrderTypeId As String = DataDS.Tables(0).Rows(0).Item("OrderTypeId").ToString.Trim

            Dim Is_OPD As String = DataDS.Tables(0).Rows(0).Item("Is_OPD").ToString.Trim
            Dim Is_IPD As String = DataDS.Tables(0).Rows(0).Item("Is_IPD").ToString.Trim
            Dim Is_EPD As String = DataDS.Tables(0).Rows(0).Item("Is_EPD").ToString.Trim

            Dim IsEqualMatch As String = "N"

            If DataDS.Tables(0).Columns.Contains("IsEqualMatch") AndAlso DataDS.Tables(0).Rows(0).Item("IsEqualMatch").ToString.Trim = "Y" Then
                IsEqualMatch = "Y"
            End If


            If BasicDateStr <> "" AndAlso IsDate(BasicDateStr) Then
                BasicDate = CDate(BasicDateStr)
            End If


            Dim SourceFlag As String = ""

            If Is_OPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Opd='Y' Or A.Insu_Cover_Opd='C' "
                End If

            End If

            If Is_IPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Ipd='Y' Or A.Insu_Cover_Ipd='C' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Ipd='Y' Or A.Insu_Cover_Ipd='C' "
                End If
            End If

            If Is_EPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += "    A.Insu_Cover_Emg='Y' Or A.Insu_Cover_Emg='C' "
                Else
                    SourceFlag += " Or A.Insu_Cover_Emg='Y' Or A.Insu_Cover_Emg='C' "
                End If
            End If


            '====================
            If OrderCode <> "" Then

                If OrderTypeId = "G" Then '衛材
                    'command.CommandText = " Select   A.Order_En_Name ,A.Order_Code,CAST( C.Price AS DECIMAL(18,1)) as Price , CAST( D.Price AS DECIMAL(18,1)) as Price, A.Is_Order_Check , A.Charge_Unit   "  'Charge_Unit =Tqty_Unit
                    command.CommandText = " Select   A.Order_En_Name ,A.Order_Code   , A.Is_Order_Check , A.Is_Icd_Check  , A.Charge_Unit  , A.Is_IC_Card_Order , A.Order_Note , A.Is_Prior_Review  , A.Include_Order_Mark ,   C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio' ,D.Order_Ratio , D.Material_Ratio , D.Add_Price    "  'Charge_Unit =Tqty_Unit

                ElseIf OrderTypeId = "D" Then '治療處置
                    ' command.CommandText = " Select   A.Order_En_Name ,A.Order_Code, CAST( C.Price AS DECIMAL(18,1)) as Price , CAST( D.Price AS DECIMAL(18,1)) as Price ,  A.Is_Cure , A.Treatment_Type_Id , A.Cure_Type_Id  ,A.Is_Order_Check ,  A.Charge_Unit , A.Order_Type_Id ,B.* "
                    command.CommandText = " Select   A.Order_En_Name ,A.Order_Code,     A.Is_Cure , A.Treatment_Type_Id , A.Cure_Type_Id  , A.Include_Order_Mark ,A.Is_Order_Check , A.Is_Icd_Check  ,  A.Charge_Unit , A.Order_Type_Id , A.Is_IC_Card_Order , A.Order_Note ,  A.Is_Prior_Review ,   C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio'  ,D.Order_Ratio , D.Material_Ratio , D.Add_Price   , A.Is_Emg_Nursing_Charge  , B.* "

                ElseIf OrderTypeId = "H" Then '檢驗檢查
                    'command.CommandText = " Select   A.Order_En_Name , A.Order_Code , A.Is_Order_Check , B.Is_Scheduled , B.Is_Same_Specimen_Add , A.Is_Prior_Review , B.Default_Body_Site_Code ,B.Default_Main_Body_Site_Code ,B.Default_Side_Id ,B.Default_Specimen_Id, A.Treatment_Type_Id , A.Charge_Unit ,C.Sheet_Code ,D.Is_Emergency_Sheet , B.Is_Main_Body_Site , B.Is_Body_Site , B.Is_Side_Id , A.Is_IC_Card_Order , B.Deliver_System  , B.Is_With_Contrast, B.Nhi_Body_Site_Code , A.Order_Note ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price "

                    command.CommandText = " Select   (Case When A.Treatment_Type_Id='3' and A.Order_En_Short_Name<>'' and A.Order_En_Short_Name is not null then A.Order_En_Short_Name  When A.Treatment_Type_Id='3' and (A.Order_En_Short_Name='' or A.Order_En_Short_Name is   null) then A.Order_En_Name When A.Treatment_Type_Id='4'   then A.Order_En_Name end ) as 'Order_En_Name' , A.Order_Code , A.Include_Order_Mark , A.Is_Order_Check , A.Is_Icd_Check , B.Is_Scheduled , B.Is_Same_Specimen_Add , A.Is_Prior_Review , B.Default_Body_Site_Code ,B.Default_Main_Body_Site_Code ,B.Default_Side_Id ,B.Default_Specimen_Id, A.Treatment_Type_Id , A.Charge_Unit ,C.Sheet_Code , C.Separate_Mark ,D.Is_Emergency_Sheet , B.Is_Main_Body_Site , B.Is_Body_Site , B.Is_Side_Id , A.Is_IC_Card_Order , B.Deliver_System  , B.Is_With_Contrast, B.Nhi_Body_Site_Code , B.Is_No_Separate , A.Order_Note ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price "


                ElseIf OrderTypeId = "J" Then '手術法
                    command.CommandText = " Select S.Doctor_Dept_Code , A.Order_Name,  A.Order_En_Name , A.Order_Code, S.Age_Group_Id , S.Op_Nameplate_Id, S.Nameplate_Name , A.Include_Order_Mark , A.Is_Order_Check , A.Is_Icd_Check  ,  A.Is_Prior_Review   , A.Treatment_Type_Id , A.Charge_Unit , B.Is_Single_Or ,B.Is_Body_Site , B.Default_Body_Site_Code , B.Default_Side_Id , A.Is_IC_Card_Order  , A.Order_Note  ,   C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio' ,D.Order_Ratio , D.Material_Ratio  , D.Add_Price  "

                ElseIf OrderTypeId = "NckuCode" Then '成大碼轉健保碼
                    command.CommandText = " Select  PP.Order_Code,  Case when DD.Insu_Code is null then PP.Insu_Code  else DD.Insu_Code End as detail_Insu_Code, PO.Order_En_Name, PO.Order_Name  "

                Else
                    command.CommandText = " Select A.*," + _
                   " rtrim(POE.Deliver_System) as Deliver_System," + _
                   " rtrim(POE.Nhi_Body_Site_Code) as Nhi_Body_Site_Code , C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio' ,D.Order_Ratio , D.Material_Ratio , D.Add_Price    " + _
                   ", C.Insu_Apply_Price,D.Insu_Apply_Price , D.Insu_Account_Id, D.Insu_Order_Type_Id, PA.Receipt_Account_Id, D.Insu_code,  " + _
                   "E.Usage_Code , E.Frequency_Code "

                End If


                If OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId <> "H" AndAlso OrderTypeId <> "D" AndAlso OrderTypeId <> "J" AndAlso OrderTypeId <> "G" AndAlso OrderTypeId <> "NckuCode" Then

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   PUB_Order  A " & _
                                  " left join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                                  " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                  " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                  " Left Join PUB_Account PA On A.Account_Id = PA.Account_Id And PA.DC='N'" & _
                                  " Left Join OPH_Pharmacy_Base E On A.Order_Code=E.Order_Code And  (E.DC<>'Y' or E.DC is null) " & _
                                  " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code = '" & OrderCode & "')     And '" & _
                                    Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                    Now().ToString("yyyy/M/d") & "'<= A.End_Date  "
                    Else
                        command.CommandText += " From   PUB_Order  A " & _
                                  " left join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                                  " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                  " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                  " Left Join PUB_Account PA On A.Account_Id = PA.Account_Id And PA.DC='N'" & _
                                  " Left Join OPH_Pharmacy_Base E On A.Order_Code=E.Order_Code And  (E.DC<>'Y' or E.DC is null) " & _
                                  " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                    Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                    Now().ToString("yyyy/M/d") & "'<= A.End_Date  "
                    End If




                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "G" Then '衛材

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   PUB_Order  A " & _
                               " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                               " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                               " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code = '" & OrderCode & "')     And '" & _
                                 Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                 Now().ToString("yyyy/M/d") & "'<= A.End_Date  "

                    Else
                        command.CommandText += " From   PUB_Order  A " & _
                               " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                               " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                               " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                 Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                 Now().ToString("yyyy/M/d") & "'<= A.End_Date  "

                    End If

                    '" Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '" Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "H" Then  '檢驗檢查

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   PUB_Order A  Left Join PUB_Sheet_Detail C Left Join PUB_Sheet D On C.Sheet_Code = D.Sheet_Code And C.Dc <>'Y' And D.Dc <>'Y' On  A.Order_Code =C.Order_Code  And C.Dc <>'Y' " & _
                                  " Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                  " Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                  "  , PUB_Order_Examination B " & _
                                  " Where   (A.DC<>'Y' or A.DC is null) And A.Order_Code=B.Order_Code  And ( A.Order_Code = '" & OrderCode & "')     And '" & _
                                    Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                    Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                    Else
                        command.CommandText += " From   PUB_Order A  Left Join PUB_Sheet_Detail C Left Join PUB_Sheet D On C.Sheet_Code = D.Sheet_Code And C.Dc <>'Y' And D.Dc <>'Y' On  A.Order_Code =C.Order_Code  And C.Dc <>'Y' " & _
                                  " Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                  " Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                  "  , PUB_Order_Examination B " & _
                                  " Where   (A.DC<>'Y' or A.DC is null) And A.Order_Code=B.Order_Code  And ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                    Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                    Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                    End If

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "D" Then  '治療處置

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   PUB_Order A   Left Join PUB_Cure_Control B On A.Cure_Type_Id=B.Cure_Type_Id     " & _
                                    " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                    " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                    " Where   (A.DC<>'Y' or A.DC is null) And  ( A.Order_Code = '" & OrderCode & "')   And '" & _
                                    Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                    Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                    Else
                        command.CommandText += " From   PUB_Order A   Left Join PUB_Cure_Control B On A.Cure_Type_Id=B.Cure_Type_Id     " & _
                                    " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                    " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                    " Where   (A.DC<>'Y' or A.DC is null) And  ( A.Order_Code like '" & OrderCode & "%')   And '" & _
                                    Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                    Now().ToString("yyyy/M/d") & "'<= A.End_Date    "
                    End If


                    '" Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '" Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "J" Then  '手術法

                    'command.CommandText += " From   PUB_Order A   Left Join PUB_Order_Or_Treat B On A.Order_Code=B.Order_Code " & _
                    '                       " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '                       " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                    '                  " Where   (A.DC<>'Y' or A.DC is null) And  ( A.Order_Code like '" & OrderCode & "%')   And '" & _
                    '                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                    '                  Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                    If OrderCode.Contains("|") Then

                        'command.CommandText += " From   PUB_Order A    " & _
                        '               " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                        '               " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                        '               " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                        '          " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And ( S.Doctor_Dept_Code='" & Split(OrderCode, "|")(1).Trim & "' Or S.Doctor_Dept_Code='" & Split(OrderCode, "|")(2).Trim & "' ) And   ( S.Order_Code like '" & Split(OrderCode, "|")(0).Trim & "%')   And '" & _
                        '          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                        '          Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                        If IsEqualMatch = "Y" Then
                            command.CommandText += " From   PUB_Order A    " & _
                                    " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                    " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                    " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                               " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And ( S.Order_Code = '" & Split(OrderCode, "|")(0).Trim & "') And S.Is_Emg='Y'   And '" & _
                               Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                               Now().ToString("yyyy/M/d") & "'<= A.End_Date    "
                        Else
                            command.CommandText += " From   PUB_Order A    " & _
                                    " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                    " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                    " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                               " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And ( S.Order_Code like '" & Split(OrderCode, "|")(0).Trim & "%')  And S.Is_Emg='Y'  And '" & _
                               Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                               Now().ToString("yyyy/M/d") & "'<= A.End_Date    "
                        End If



                    Else

                        If IsEqualMatch = "Y" Then
                            command.CommandText += " From   PUB_Order A    " & _
                                      " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                      " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                      " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                                 " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And  ( S.Order_Code = '" & OrderCode & "')  And S.Is_Emg='Y'  And '" & _
                                 Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                 Now().ToString("yyyy/M/d") & "'<= A.End_Date    "
                        Else
                            command.CommandText += " From   PUB_Order A    " & _
                                      " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                      " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                      " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                                 " Where  S.Order_Code=A.Order_Code And  (A.DC<>'Y' or A.DC is null) And  ( S.Order_Code like '" & OrderCode & "%') And S.Is_Emg='Y'   And '" & _
                                 Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                 Now().ToString("yyyy/M/d") & "'<= A.End_Date    "
                        End If



                    End If



                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "NckuCode" Then  '成大碼轉健保碼

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From    dbo.PUB_Order_Price PP  left outer join dbo.PUB_Insu_Code as DD on ( PP.Order_Code = DD.Order_Code )   inner join PUB_Order as PO on ( PP.Order_Code = PO.Order_Code and '" & BasicDate.ToString("yyyy/M/d") & "' >= PO.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "' <= PO.End_Date  )  " & _
                                           " Where PP.Order_Code = '" & OrderCode & "' And " & _
                                           "'" & BasicDate.ToString("yyyy/M/d") & "' >= PP.Effect_Date And " & _
                                           "'" & BasicDate.ToString("yyyy/M/d") & "' <= PP.End_Date And PP.Main_Identity_Id ='2' "
                    Else
                        command.CommandText += " From    dbo.PUB_Order_Price PP  left outer join dbo.PUB_Insu_Code as DD on ( PP.Order_Code = DD.Order_Code )   inner join PUB_Order as PO on ( PP.Order_Code = PO.Order_Code and '" & BasicDate.ToString("yyyy/M/d") & "' >= PO.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "' <= PO.End_Date  )  " & _
                                           " Where PP.Order_Code like '" & OrderCode & "%' And " & _
                                           "'" & BasicDate.ToString("yyyy/M/d") & "' >= PP.Effect_Date And " & _
                                           "'" & BasicDate.ToString("yyyy/M/d") & "' <= PP.End_Date And PP.Main_Identity_Id ='2' "
                    End If


                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Split(",").Length > 1 Then
                    '2010.04.01 Add by Nick, 傳入多個Order_Type_Id
                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   PUB_Order  A " & _
                                           " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code = '" & OrderCode & "')     And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= A.End_Date  "
                    Else
                        command.CommandText += " From   PUB_Order  A " & _
                                           " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= A.End_Date  "
                    End If

                Else
                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From   NCKUH_common.dbo.SysOrderLabItem  A  " & _
                               " Where   ( A.OrderCode = '" & OrderCode & "')      "

                    Else
                        command.CommandText += " From   NCKUH_common.dbo.SysOrderLabItem  A  " & _
                               " Where   ( A.OrderCode like '" & OrderCode & "%')      "


                    End If


                End If


                If OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim.Length = 1 AndAlso OrderTypeId.Trim <> "H" AndAlso OrderTypeId.Trim <> "D" AndAlso OrderTypeId.Trim <> "J" Then
                    command.CommandText += " And A.Order_Type_Id='" & OrderTypeId & "' "

                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If


                ElseIf OrderTypeId.Trim = "J" Then
                    command.CommandText += " And A.Order_Type_Id='J' "
                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                ElseIf OrderTypeId.Trim = "H" Then
                    command.CommandText += " And A.Order_Type_Id='H' And  A.Treatment_Type_Id in ('3' , '4')  "
                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                ElseIf OrderTypeId.Trim = "D" Then

                    command.CommandText += " And ( A.Order_Type_Id='D' Or A.Order_Type_Id='T' Or A.Order_Type_Id='G' Or  A.Order_Type_Id='J' Or  ( A.Order_Type_Id='H' And ( A.Treatment_Type_Id not in ('3' , '4','5') Or A.Treatment_Type_Id is Null ) ) ) "

                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                ElseIf OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim = "Often" Then
                    '醫令 -常用處置維護
                    command.CommandText += " And ( A.Order_Type_Id in ('D','K','I','T') Or (A.Order_Type_Id='H' And A.Treatment_Type_Id<>'3' And A.Treatment_Type_Id<>'4' ) ) "

                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                ElseIf OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim = "DepOften" Then

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Split(",").Length > 1 Then
                    '2010.04.01 Add by Nick, 傳入多個Order_Type_Id
                    command.CommandText += " And A.Order_Type_Id in (" & OrderTypeId & ") "

                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                End If



                If OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim <> "H" AndAlso OrderTypeId.Trim <> "J" Then
                    command.CommandText += " Order By  A.Order_Code "
                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "J" Then
                    command.CommandText += " Order By  A.Order_Code "
                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "H" Then
                    command.CommandText += " Order By  A.Order_Code "
                Else
                    command.CommandText += " Order By  A.OrderCode "
                End If


            ElseIf OrderEnName <> "" Then

                If OrderTypeId = "G" Then '衛材
                    'command.CommandText = " Select   A.Order_En_Name ,A.Order_Code, CAST( C.Price AS DECIMAL(18,1)) as Price , CAST( D.Price AS DECIMAL(18,1)) as Price , A.Is_Order_Check ,  A.Charge_Unit  "
                    command.CommandText = " Select   A.Order_En_Name ,A.Order_Code,   A.Is_Order_Check , A.Is_Icd_Check  ,  A.Charge_Unit  , A.Is_IC_Card_Order , A.Order_Note , A.Is_Prior_Review , A.Include_Order_Mark ,C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio'  ,D.Order_Ratio , D.Material_Ratio , D.Add_Price  "


                ElseIf OrderTypeId = "D" Then '治療處置
                    'command.CommandText = " Select   A.Order_En_Name ,A.Order_Code, CAST( C.Price AS DECIMAL(18,1)) as Price , CAST( D.Price AS DECIMAL(18,1)) as Price ,  A.Is_Cure , A.Treatment_Type_Id,A.Cure_Type_Id  ,A.Is_Order_Check  , A.Charge_Unit ,A.Order_Type_Id ,B.* "
                    command.CommandText = " Select   A.Order_En_Name ,A.Order_Code,     A.Is_Cure , A.Treatment_Type_Id,A.Cure_Type_Id  , A.Include_Order_Mark , A.Is_Order_Check , A.Is_Icd_Check  , A.Charge_Unit ,A.Order_Type_Id , A.Is_IC_Card_Order , A.Order_Note , A.Is_Prior_Review , C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio'  ,D.Order_Ratio , D.Material_Ratio , D.Add_Price , A.Is_Emg_Nursing_Charge  ,B.* "



                ElseIf OrderTypeId = "H" Then '檢驗檢查
                    'command.CommandText = " Select   A.Order_En_Name , A.Order_Code , A.Is_Order_Check , B.Is_Scheduled ,B.Is_Same_Specimen_Add , A.Is_Prior_Review ,  B.Default_Body_Site_Code ,B.Default_Main_Body_Site_Code, B.Default_Specimen_Id,B.Default_Side_Id , A.Treatment_Type_Id  , A.Charge_Unit  , C.Sheet_Code ,D.Is_Emergency_Sheet, B.Is_Main_Body_Site , B.Is_Body_Site , B.Is_Side_Id , A.Is_IC_Card_Order , B.Deliver_System , B.Is_With_Contrast ,  B.Nhi_Body_Site_Code , A.Order_Note  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio  , Y.Add_Price  "
                    command.CommandText = " Select   (Case When A.Treatment_Type_Id='3' and A.Order_En_Short_Name<>'' and A.Order_En_Short_Name is not null then A.Order_En_Short_Name  When A.Treatment_Type_Id='3' and (A.Order_En_Short_Name='' or A.Order_En_Short_Name is   null) then A.Order_En_Name When A.Treatment_Type_Id='4'   then A.Order_En_Name end ) as 'Order_En_Name' , A.Order_Code , A.Include_Order_Mark  , A.Is_Order_Check , A.Is_Icd_Check  , B.Is_Scheduled , B.Is_Same_Specimen_Add , A.Is_Prior_Review , B.Default_Body_Site_Code ,B.Default_Main_Body_Site_Code ,B.Default_Side_Id ,B.Default_Specimen_Id, A.Treatment_Type_Id , A.Charge_Unit ,C.Sheet_Code , C.Separate_Mark ,D.Is_Emergency_Sheet , B.Is_Main_Body_Site , B.Is_Body_Site , B.Is_Side_Id , A.Is_IC_Card_Order , B.Deliver_System  , B.Is_With_Contrast, B.Nhi_Body_Site_Code  , B.Is_No_Separate , A.Order_Note ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price "

                ElseIf OrderTypeId = "J" Then '手術法
                    command.CommandText = " Select  S.Doctor_Dept_Code , A.Order_Name, A.Order_En_Name , A.Order_Code, S.Age_Group_Id , S.Op_Nameplate_Id, S.Nameplate_Name ,A.Include_Order_Mark , A.Is_Order_Check , A.Is_Icd_Check  ,  A.Is_Prior_Review   , A.Treatment_Type_Id , A.Charge_Unit , B.Is_Single_Or ,B.Is_Body_Site , B.Default_Body_Site_Code , B.Default_Side_Id , A.Is_IC_Card_Order  , A.Order_Note  ,   C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio' ,D.Order_Ratio , D.Material_Ratio  , D.Add_Price  "

                ElseIf OrderTypeId = "NckuCode" Then '輸成大碼轉健保碼
                    command.CommandText = " Select  PP.Order_Code,  Case when DD.Insu_Code is null then PP.Insu_Code  else DD.Insu_Code End as detail_Insu_Code, PO.Order_En_Name, PO.Order_Name  "

                Else
                    command.CommandText = " Select A.*," + _
                                          " rtrim(POE.Deliver_System) as Deliver_System," + _
                                          " rtrim(POE.Nhi_Body_Site_Code) as Nhi_Body_Site_Code ,  C.Price as 'Self_Price' , D.Price as 'Price' , C.Order_Ratio as 'Self_Order_Ratio' , C.Material_Ratio as 'Self_Material_Ratio'  ,D.Order_Ratio , D.Material_Ratio , D.Add_Price "

                End If


                If OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim <> "H" AndAlso OrderTypeId <> "D" AndAlso OrderTypeId <> "J" AndAlso OrderTypeId <> "G" Then

                    command.CommandText += " From   PUB_Order  A " & _
                                        " left join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code " & _
                                        " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                        " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                        " Left Join PUB_Account PA On A.Account_Id = PA.Account_Id And PA.DC='N'" & _
                                        " Left Join OPH_Pharmacy_Base E On A.Order_Code=E.Order_Code And  (E.DC<>'Y' or E.DC is null) " & _
                                        " Where   (A.DC<>'Y' or A.DC is null) And  (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= A.End_Date  "

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "G" Then '衛材

                    command.CommandText += " From   PUB_Order  A " & _
                                        " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                        " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                        " Where   (A.DC<>'Y' or A.DC is null) And  (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= A.End_Date  "

                    '" Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '" Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _


                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "H" Then '檢驗檢查

                    command.CommandText += " From   PUB_Order A  Left Join PUB_Sheet_Detail C Left Join PUB_Sheet D On C.Sheet_Code = D.Sheet_Code And C.Dc <>'Y' And D.Dc <>'Y' On  A.Order_Code =C.Order_Code  And C.Dc <>'Y'   " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                           "  , PUB_Order_Examination B " & _
                                        " Where   (A.DC<>'Y' or A.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "D" Then  '治療處置
                    command.CommandText += " From   PUB_Order A   Left Join PUB_Cure_Control B On A.Cure_Type_Id=B.Cure_Type_Id     " & _
                                          " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                          " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                          " Where   (A.DC<>'Y' or A.DC is null) And  (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= A.End_Date    "

                    '" Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '" Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _


                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "J" Then  '手術

                    'command.CommandText += " From   PUB_Order A   Left Join PUB_Order_Or_Treat B On A.Order_Code=B.Order_Code " & _
                    '                       " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                    '                       " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                    '                      " Where   (A.DC<>'Y' or A.DC is null) And  (  A.Order_En_Name like '" & OrderEnName & "%')   And '" & _
                    '                      Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                    '                      Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                    If OrderEnName.Trim.Contains("|") Then


                        'command.CommandText += " From   PUB_Order A   " & _
                        '           " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                        '           " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                        '           " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                        '          " Where  S.Order_Code=A.Order_Code And (A.DC<>'Y' or A.DC is null) And ( S.Doctor_Dept_Code='" & Split(OrderEnName, "|")(1).Trim & "' Or S.Doctor_Dept_Code='" & Split(OrderEnName, "|")(2).Trim & "' )  And (  A.Order_En_Name like '" & Split(OrderEnName, "|")(0).Trim & "%')   And '" & _
                        '          Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                        '          Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                        '不綁科別了
                        command.CommandText += " From   PUB_Order A   " & _
                                   " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                   " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                   " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                                  " Where  S.Order_Code=A.Order_Code And (A.DC<>'Y' or A.DC is null)   And (  A.Order_En_Name like '" & Split(OrderEnName, "|")(0).Trim & "%')  And S.Is_Emg='Y'  And '" & _
                                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                  Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                    Else

                        command.CommandText += " From   PUB_Order A   " & _
                                   " Left Join PUB_Order_Price C On C.DC='N' And A.Order_Code=C.Order_Code And  C.Main_Identity_Id='1'  And  '" & Now().ToString("yyyy/M/d") & "' >= C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date " & _
                                   " Left Join PUB_Order_Price D On D.DC='N' And A.Order_Code=D.Order_Code And  D.Main_Identity_Id='2'  And  '" & Now().ToString("yyyy/M/d") & "' >= D.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= D.End_Date " & _
                                   " , SUR_Op_Year_Nameplate S Left Join PUB_Order_Or_Treat B On S.Order_Code=B.Order_Code " & _
                                  " Where  S.Order_Code=A.Order_Code And (A.DC<>'Y' or A.DC is null) And  (  A.Order_En_Name like '" & OrderEnName & "%') And S.Is_Emg='Y'   And '" & _
                                  Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                  Now().ToString("yyyy/M/d") & "'<= A.End_Date    "


                    End If


                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId = "NckuCode" Then  '成大碼轉健保碼
                    'command.CommandText += " FROM PUB_Order A ,PUB_Order_Price B  " & _
                    '                       " Where A.Order_Code =B.Order_Code And B.Main_Identity_Id = '2' And B.Insu_Code <> '' And '" & _
                    '                         BasicDate.ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                    '                         BasicDate.ToString("yyyy/M/d") & "'<= B.End_Date    And " & _
                    '                        " B.Insu_Code<>'ZZZZZZ' And (  A.Order_En_Name like '" & OrderEnName & "%' ) And A.Dc='N' "


                    '只能用Order_Code 去找 ( 成大碼轉健保碼 )
                    command.CommandText += " From    dbo.PUB_Order_Price PP  left outer join dbo.PUB_Insu_Code as DD on ( PP.Order_Code = DD.Order_Code )   inner join PUB_Order as PO on ( PP.Order_Code = PO.Order_Code and '" & BasicDate.ToString("yyyy/M/d") & "' >= PO.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "' <= PO.End_Date  )  " & _
                                          " Where PP.Order_Code like '" & OrderCode & "%' And " & _
                                          "'" & BasicDate.ToString("yyyy/M/d") & "' >= PP.Effect_Date And " & _
                                          "'" & BasicDate.ToString("yyyy/M/d") & "' <= PP.End_Date And PP.Main_Identity_Id ='2' "


                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Split(",").Length > 1 Then
                    '2010.04.01 Add by Nick, 傳入多個Order_Type_Id
                    command.CommandText += " From   PUB_Order  A " & _
                                           " Where   (A.DC<>'Y' or A.DC is null) And   ( A.Order_Code like '" & OrderCode & "%')     And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= A.End_Date  "
                Else

                    command.CommandText += " From   NCKUH_common.dbo.SysOrderLabItem A   " & _
                               " Where   ( A.OrderCode like '" & OrderCode & "%')      "

                End If

                If OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim.Length = 1 AndAlso OrderTypeId.Trim <> "H" AndAlso OrderTypeId.Trim <> "D" AndAlso OrderTypeId.Trim <> "J" Then
                    command.CommandText += " And A.Order_Type_Id='" & OrderTypeId & "' "

                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                ElseIf OrderTypeId.Trim = "J" Then
                    command.CommandText += " And A.Order_Type_Id='J' "

                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                ElseIf OrderTypeId.Trim = "H" Then
                    command.CommandText += " And A.Order_Type_Id='H' And  A.Treatment_Type_Id in ('3' , '4')  "

                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                ElseIf OrderTypeId.Trim = "D" Then
                    command.CommandText += " And ( A.Order_Type_Id='D' Or  A.Order_Type_Id='T' Or  A.Order_Type_Id='J' Or  ( A.Order_Type_Id='H' And  ( A.Treatment_Type_Id not in ('3' , '4','5') Or A.Treatment_Type_Id is Null ) ) ) "

                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                ElseIf OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim = "Often" Then
                    '醫令 -常用處置維護
                    command.CommandText += " And ( A.Order_Type_Id in ('D','K','I','T') Or (A.Order_Type_Id='H' And A.Treatment_Type_Id<>'3' And A.Treatment_Type_Id<>'4' ) ) "

                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                ElseIf OrderTypeId.Trim <> "" AndAlso OrderTypeId.Trim = "DepOftenH" Then

                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Split(",").Length > 1 Then
                    '2010.04.01 Add by Nick, 傳入多個Order_Type_Id
                    command.CommandText += " And A.Order_Type_Id in (" & OrderTypeId & ")"

                    If SourceFlag <> "" Then
                        command.CommandText += " And  (" & SourceFlag & ") "
                    End If

                End If


                If OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim <> "H" AndAlso OrderTypeId.Trim <> "J" Then
                    command.CommandText += " Order By  A.Order_Code "
                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "J" Then
                    command.CommandText += " Order By  A.Order_Code "
                ElseIf OrderTypeId.Trim <> "DepOftenH" AndAlso OrderTypeId.Trim = "H" Then
                    command.CommandText += " Order By  A.Order_Code "
                Else
                    command.CommandText += " Order By  A.OrderCode "
                End If

            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)

            End Using
            Return ds


        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    '隨輸隨選 醫囑診斷 PUB_Disease
    Public Function queryPUBDiseaseE(ByVal DataDS As DataSet) As DataSet

        Try

            Dim code As String = DataDS.Tables(0).Rows(0).Item("Code").ToString.Trim
            Dim codeName As String = DataDS.Tables(0).Rows(0).Item("Name").ToString.Trim
            Dim DiseaseTypeId As String = DataDS.Tables(0).Rows(0).Item("DiseaseTypeId").ToString.Trim
            Dim IsSevereDisease As String = DataDS.Tables(0).Rows(0).Item("IsSevereDisease").ToString.Trim

            Dim Is_OPD As String = DataDS.Tables(0).Rows(0).Item("Is_OPD").ToString.Trim
            Dim Is_IPD As String = DataDS.Tables(0).Rows(0).Item("Is_IPD").ToString.Trim
            Dim Is_EPD As String = DataDS.Tables(0).Rows(0).Item("Is_EPD").ToString.Trim
            Dim IcdType As String = DataDS.Tables(0).Rows(0).Item("IcdType").ToString.Trim
            Dim IsAllowIcd9Empty As String = DataDS.Tables(0).Rows(0).Item("IsAllowIcd9Empty").ToString.Trim
            Dim IsAllowIcd10Empty As String = DataDS.Tables(0).Rows(0).Item("IsAllowIcd10Empty").ToString.Trim

            Dim IsEqualMatch As String = "N"

            If DataDS.Tables(0).Columns.Contains("IsEqualMatch") AndAlso DataDS.Tables(0).Rows(0).Item("IsEqualMatch").ToString.Trim = "Y" Then
                IsEqualMatch = "Y"
            End If

            Dim SourceFlag As String = ""
            If IcdType = "Icd9" Then
                If Is_OPD.Trim = "Y" Then
                    If SourceFlag = "" Then
                        SourceFlag += " A.Is_Opd='Y' "
                    Else
                        SourceFlag += " Or A.Is_Opd='Y' "
                    End If

                End If

                If Is_IPD.Trim = "Y" Then
                    If SourceFlag = "" Then
                        SourceFlag += " A.Is_Ipd='Y' "
                    Else
                        SourceFlag += " Or A.Is_Ipd='Y' "
                    End If
                End If

                If Is_EPD.Trim = "Y" Then
                    If SourceFlag = "" Then
                        SourceFlag += " A.Is_Emg='Y' "
                    Else
                        SourceFlag += " Or A.Is_Emg='Y' "
                    End If
                End If

            ElseIf IcdType = "Icd10" Then

                If Is_OPD.Trim = "Y" Then
                    If SourceFlag = "" Then
                        SourceFlag += " C.Is_Opd='Y' "
                    Else
                        SourceFlag += " Or C.Is_Opd='Y' "
                    End If

                End If

                If Is_IPD.Trim = "Y" Then
                    If SourceFlag = "" Then
                        SourceFlag += " C.Is_Ipd='Y' "
                    Else
                        SourceFlag += " Or C.Is_Ipd='Y' "
                    End If
                End If

                If Is_EPD.Trim = "Y" Then
                    If SourceFlag = "" Then
                        SourceFlag += " C.Is_Emg='Y' "
                    Else
                        SourceFlag += " Or C.Is_Emg='Y' "
                    End If
                End If
            End If

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            If code <> "" Or codeName <> "" Then 'Modify on 2011-04-28 by Lits

                command.CommandText = getQueryPUBDiseaseSQL(IcdType, code, codeName, IsEqualMatch, DiseaseTypeId, IsSevereDisease, SourceFlag)

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet(tableName)
                    adapter.Fill(ds, tableName)

                End Using

                If ds IsNot Nothing Then
                    If IsAllowIcd9Empty = "N" AndAlso ds.Tables(0).Columns.Contains("Icd9") Then
                        For i As Integer = ds.Tables(0).Rows.Count - 1 To 0 Step -1
                            If ds.Tables(0).Rows(i).Item("Icd9").ToString.Trim = "" Then
                                ds.Tables(0).Rows.RemoveAt(i)
                            End If
                        Next
                    End If

                    If IsAllowIcd10Empty = "N" AndAlso ds.Tables(0).Columns.Contains("Icd10") Then
                        For i As Integer = ds.Tables(0).Rows.Count - 1 To 0 Step -1
                            If ds.Tables(0).Rows(i).Item("Icd10").ToString.Trim = "" Then
                                ds.Tables(0).Rows.RemoveAt(i)
                            End If
                        Next
                    End If

                End If

                Return ds
            Else
                ds = New DataSet(tableName)
                Return ds
            End If

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function


    Public Function getQueryPUBDiseaseSQL(ByVal IcdType As String, ByVal code As String, ByVal codeName As String, ByVal IsEqualMatch As String, ByVal DiseaseTypeId As String, ByVal IsSevereDisease As String, ByVal SourceFlag As String)
        Try

            Dim SqlStr As String = ""
            Dim varname1 As New System.Text.StringBuilder

            If code <> "" Then
                If IcdType = "Icd9" Then

                    varname1.Append("SELECT DISTINCT Rtrim(A.Icd_Code) AS 'Icd9', " & vbCrLf)
                    varname1.Append("                Rtrim(C.Icd_Code) AS 'Icd10', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Disease_En_Name IS NOT NULL THEN Rtrim(C.Disease_En_Name) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Disease_En_Name) " & vbCrLf)
                    varname1.Append("                END               AS 'Disease_En_Name', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Disease_En_Name IS NOT NULL THEN Rtrim(C.Disease_Name) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Disease_Name) " & vbCrLf)
                    varname1.Append("                END               AS 'Disease_Name', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Disease_Type_Id IS NOT NULL THEN Rtrim(C.Disease_Type_Id) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Disease_Type_Id) " & vbCrLf)
                    varname1.Append("                END               AS 'Disease_Type_Id', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Effect_Date IS NOT NULL THEN Rtrim(C.Effect_Date) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Effect_Date) " & vbCrLf)
                    varname1.Append("                END               AS 'Effect_Date', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Disease_Hosp_Name IS NOT NULL THEN Rtrim(C.Disease_Hosp_Name) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Disease_Hosp_Name) " & vbCrLf)
                    varname1.Append("                END               AS 'Disease_Hosp_Name', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Majorcare_Code IS NOT NULL THEN Rtrim(C.Majorcare_Code) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Majorcare_Code) " & vbCrLf)
                    varname1.Append("                END               AS 'Majorcare_Code', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Limit_Sex_Id IS NOT NULL THEN Rtrim(C.Limit_Sex_Id) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Limit_Sex_Id) " & vbCrLf)
                    varname1.Append("                END               AS 'Limit_Sex_Id', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Infection_Type_Id IS NOT NULL THEN Rtrim(C.Infection_Type_Id) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Infection_Type_Id) " & vbCrLf)
                    varname1.Append("                END               AS 'Infection_Type_Id', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Limit_Age IS NOT NULL THEN Rtrim(C.Limit_Age) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Limit_Age) " & vbCrLf)
                    varname1.Append("                END               AS 'Limit_Age', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Age_Start_Year IS NOT NULL THEN Rtrim(C.Age_Start_Year) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Disease_Type_Id) " & vbCrLf)
                    varname1.Append("                END               AS 'Age_Start_Year', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Age_Start_Month IS NOT NULL THEN Rtrim(C.Age_Start_Month) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Age_Start_Month) " & vbCrLf)
                    varname1.Append("                END               AS 'Age_Start_Month', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Age_Start_Day IS NOT NULL THEN Rtrim(C.Age_Start_Day) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Age_Start_Day) " & vbCrLf)
                    varname1.Append("                END               AS 'Age_Start_Day', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Age_End_Year IS NOT NULL THEN Rtrim(C.Age_End_Year) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Age_End_Year) " & vbCrLf)
                    varname1.Append("                END               AS 'Age_End_Year', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Age_End_Month IS NOT NULL THEN Rtrim(C.Age_End_Month) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Age_End_Month) " & vbCrLf)
                    varname1.Append("                END               AS 'Age_End_Month', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Age_End_Day IS NOT NULL THEN Rtrim(C.Age_End_Day) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Age_End_Day) " & vbCrLf)
                    varname1.Append("                END               AS 'Age_End_Day', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Exclude_Labdiscount IS NOT NULL THEN Rtrim(C.Is_Exclude_Labdiscount) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Exclude_Labdiscount) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Exclude_Labdiscount', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Chronic_Disease IS NOT NULL THEN Rtrim(C.Is_Chronic_Disease) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Chronic_Disease) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Chronic_Disease', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Severe_Disease IS NOT NULL THEN Rtrim(C.Is_Severe_Disease) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Severe_Disease) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Severe_Disease', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Psy_Severe_Disease IS NOT NULL THEN Rtrim(C.Is_Psy_Severe_Disease) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Psy_Severe_Disease) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Psy_Severe_Disease', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Rare_Diseases IS NOT NULL THEN Rtrim(C.Is_Rare_Diseases) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Rare_Diseases) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Rare_Diseases', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Major_P IS NOT NULL THEN Rtrim(C.Is_Major_P) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Major_P) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Major_P', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Minor_P IS NOT NULL THEN Rtrim(C.Is_Minor_P) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Minor_P) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Minor_P', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Mcc IS NOT NULL THEN Rtrim(C.Is_Mcc) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Mcc) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Mcc', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Cc IS NOT NULL THEN Rtrim(C.Is_Cc) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Cc) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Cc', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.End_Date IS NOT NULL THEN Rtrim(C.End_Date) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.End_Date) " & vbCrLf)
                    varname1.Append("                END               AS 'End_Date', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Pre5_Diagnosis IS NOT NULL THEN Rtrim(C.Is_Pre5_Diagnosis) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Pre5_Diagnosis) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Pre5_Diagnosis', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Or IS NOT NULL THEN Rtrim(C.Is_Or) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Or) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Or', " & vbCrLf)
                    varname1.Append("                CASE " & vbCrLf)
                    varname1.Append("                  WHEN C.Is_Drg IS NOT NULL THEN Rtrim(C.Is_Drg) " & vbCrLf)
                    varname1.Append("                  ELSE Rtrim(a.Is_Drg) " & vbCrLf)
                    varname1.Append("                END               AS 'Is_Drg'")
                    varname1.Append(" FROM  PUB_Disease_ICD10 C  " & vbCrLf)
                    varname1.Append(" Left Join PUB_Disease_ICD10_Mapping B  on C.Icd_Code =B.ICD10_Code And C.Disease_Type_Id = B.Disease_Type_Id " & vbCrLf)
                    varname1.Append(" Left Join PUB_Disease A on B.ICD_Code =A.Icd_Code And B.Disease_Type_Id = A.Disease_Type_Id  And  C.DC <> 'Y' " & vbCrLf)

                    varname1.Append(" WHERE  1=1 ")

                    If DiseaseTypeId.Trim <> "" Then
                        varname1.Append(" And A.Disease_Type_Id in (" & DiseaseTypeId & ") ")
                    End If

                    If IsEqualMatch = "Y" Then
                        varname1.Append(" AND  A.DC <> 'Y' AND A.Icd_Code = '" & code & "' ")
                    Else
                        varname1.Append(" AND  A.DC <> 'Y' AND A.Icd_Code LIKE '" & code & "%' ")
                    End If

                    varname1.Append(" And C.Is_End_Flag ='Y' And '" & Now().ToString("yyyy/M/d") & "' >=A.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= A.End_Date ")

                    If IsSevereDisease.Trim = "Y" Then
                        varname1.Append(" And A.Is_Severe_Disease='Y' ")
                    End If

                    If SourceFlag <> "" Then
                        varname1.Append(" And  (" & SourceFlag & ") ")
                    End If

                    varname1.Append(" Order By Icd9 ,Icd10 ")

                ElseIf IcdType = "Icd10" Then

                    varname1.Append("SELECT Distinct RTRIM(A.Icd_Code) as 'Icd9', " & vbCrLf)
                    varname1.Append("       RTRIM(C.Icd_Code) as 'Icd10', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_En_Name) as 'Disease_En_Name', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_Name) as 'Disease_Name', " & vbCrLf)
                    varname1.Append("       C.Disease_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Effect_Date, " & vbCrLf)
                    varname1.Append("       C.Disease_Hosp_Name, " & vbCrLf)
                    varname1.Append("       C.Majorcare_Code, " & vbCrLf)
                    varname1.Append("       C.Limit_Sex_Id, " & vbCrLf)
                    varname1.Append("       C.Infection_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Limit_Age, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Year, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Month, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Day, " & vbCrLf)
                    varname1.Append("       C.Age_End_Year, " & vbCrLf)
                    varname1.Append("       C.Age_End_Month, " & vbCrLf)
                    varname1.Append("       C.Age_End_Day, " & vbCrLf)
                    varname1.Append("       C.Is_Exclude_Labdiscount, " & vbCrLf)
                    varname1.Append("       C.Is_Chronic_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Psy_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Rare_Diseases, " & vbCrLf)
                    varname1.Append("       C.Is_Major_P, " & vbCrLf)
                    varname1.Append("       C.Is_Minor_P, " & vbCrLf)
                    varname1.Append("       C.Is_Mcc, " & vbCrLf)
                    varname1.Append("       C.Is_Cc, " & vbCrLf)
                    varname1.Append("       C.End_Date, " & vbCrLf)
                    varname1.Append("       C.Is_Pre5_Diagnosis, " & vbCrLf)
                    varname1.Append("       C.Is_Or, " & vbCrLf)
                    varname1.Append("       C.Is_Drg " & vbCrLf)
                    varname1.Append(" FROM   PUB_Disease_ICD10 C " & vbCrLf)
                    varname1.Append(" Left Join  PUB_Disease_ICD10_Mapping B  on B.ICD10_Code =C.Icd_Code And B.Disease_Type_Id = C.Disease_Type_Id " & vbCrLf)
                    varname1.Append(" Left Join  PUB_Disease A  On A.Icd_Code =B.ICD_Code And A.Disease_Type_Id = B.Disease_Type_Id   And  A.DC <> 'Y' " & vbCrLf)


                    varname1.Append(" WHERE  1=1 ")

                    If DiseaseTypeId.Trim <> "" Then
                        varname1.Append(" And C.Disease_Type_Id in (" & DiseaseTypeId & ") ")
                    End If

                    If IsEqualMatch = "Y" Then
                        varname1.Append(" AND  C.DC <> 'Y' AND C.Icd_Code = '" & code & "' ")
                    Else
                        varname1.Append(" AND  C.DC <> 'Y' AND C.Icd_Code LIKE '" & code & "%' ")
                    End If

                    varname1.Append(" And C.Is_End_Flag ='Y' And '" & Now().ToString("yyyy/M/d") & "' >=C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date ")

                    If IsSevereDisease.Trim = "Y" Then
                        varname1.Append(" And C.Is_Severe_Disease='Y' ")
                    End If

                    If SourceFlag <> "" Then
                        varname1.Append(" And  (" & SourceFlag & ") ")
                    End If

                    varname1.Append(" Order By Icd9 ,Icd10 ")

                ElseIf IcdType = "OnlyIcd9" Then

                    varname1.Append("SELECT Distinct RTRIM(A.Icd_Code) as 'Icd9', " & vbCrLf)

                    varname1.Append("	   RTRIM(A.Disease_En_Name) as 'Disease_En_Name', " & vbCrLf)
                    varname1.Append("	   RTRIM(A.Disease_Name) as 'Disease_Name', " & vbCrLf)
                    varname1.Append("       A.Disease_Type_Id, " & vbCrLf)
                    varname1.Append("       A.Effect_Date, " & vbCrLf)
                    varname1.Append("       A.Disease_Hosp_Name, " & vbCrLf)
                    varname1.Append("       A.Majorcare_Code, " & vbCrLf)
                    varname1.Append("       A.Limit_Sex_Id, " & vbCrLf)
                    varname1.Append("       A.Infection_Type_Id, " & vbCrLf)
                    varname1.Append("       A.Limit_Age, " & vbCrLf)
                    varname1.Append("       A.Age_Start_Year, " & vbCrLf)
                    varname1.Append("       A.Age_Start_Month, " & vbCrLf)
                    varname1.Append("       A.Age_Start_Day, " & vbCrLf)
                    varname1.Append("       A.Age_End_Year, " & vbCrLf)
                    varname1.Append("       A.Age_End_Month, " & vbCrLf)
                    varname1.Append("       A.Age_End_Day, " & vbCrLf)
                    varname1.Append("       A.Is_Exclude_Labdiscount, " & vbCrLf)
                    varname1.Append("       A.Is_Chronic_Disease, " & vbCrLf)
                    varname1.Append("       A.Is_Severe_Disease, " & vbCrLf)
                    varname1.Append("       A.Is_Psy_Severe_Disease, " & vbCrLf)
                    varname1.Append("       A.Is_Rare_Diseases, " & vbCrLf)
                    varname1.Append("       A.Is_Major_P, " & vbCrLf)
                    varname1.Append("       A.Is_Minor_P, " & vbCrLf)
                    varname1.Append("       A.Is_Mcc, " & vbCrLf)
                    varname1.Append("       A.Is_Cc, " & vbCrLf)
                    varname1.Append("       A.End_Date, " & vbCrLf)
                    varname1.Append("       A.Is_Pre5_Diagnosis, " & vbCrLf)
                    varname1.Append("       A.Is_Or, " & vbCrLf)
                    varname1.Append("       A.Is_Drg " & vbCrLf)
                    varname1.Append(" FROM   PUB_Disease A " & vbCrLf)

                    If IsEqualMatch = "Y" Then
                        varname1.Append(" WHERE  A.DC <> 'Y' AND A.Icd_Code = '" & code & "' ")
                    Else
                        varname1.Append(" WHERE  A.DC <> 'Y' AND A.Icd_Code LIKE '" & code & "%' ")
                    End If

                    varname1.Append(" And '" & Now().ToString("yyyy/M/d") & "' >=A.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= A.End_Date ")

                    If DiseaseTypeId.Trim <> "" Then
                        varname1.Append(" And A.Disease_Type_Id in (" & DiseaseTypeId & ") ")
                    End If

                    If IsSevereDisease.Trim = "Y" Then
                        varname1.Append(" And A.Is_Severe_Disease='Y' ")
                    End If

                    If SourceFlag <> "" Then
                        varname1.Append(" And  (" & SourceFlag & ") ")
                    End If

                    varname1.Append(" Order By Icd9  ")


                ElseIf IcdType = "OnlyIcd10" Then

                    varname1.Append("SELECT Distinct  " & vbCrLf)
                    varname1.Append("       RTRIM(C.Icd_Code) as 'Icd10', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_En_Name) as 'Disease_En_Name', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_Name) as 'Disease_Name', " & vbCrLf)
                    varname1.Append("       C.Disease_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Effect_Date, " & vbCrLf)
                    varname1.Append("       C.Disease_Hosp_Name, " & vbCrLf)
                    varname1.Append("       C.Majorcare_Code, " & vbCrLf)
                    varname1.Append("       C.Limit_Sex_Id, " & vbCrLf)
                    varname1.Append("       C.Infection_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Limit_Age, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Year, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Month, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Day, " & vbCrLf)
                    varname1.Append("       C.Age_End_Year, " & vbCrLf)
                    varname1.Append("       C.Age_End_Month, " & vbCrLf)
                    varname1.Append("       C.Age_End_Day, " & vbCrLf)
                    varname1.Append("       C.Is_Exclude_Labdiscount, " & vbCrLf)
                    varname1.Append("       C.Is_Chronic_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Psy_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Rare_Diseases, " & vbCrLf)
                    varname1.Append("       C.Is_Major_P, " & vbCrLf)
                    varname1.Append("       C.Is_Minor_P, " & vbCrLf)
                    varname1.Append("       C.Is_Mcc, " & vbCrLf)
                    varname1.Append("       C.Is_Cc, " & vbCrLf)
                    varname1.Append("       C.End_Date, " & vbCrLf)
                    varname1.Append("       C.Is_Pre5_Diagnosis, " & vbCrLf)
                    varname1.Append("       C.Is_Or, " & vbCrLf)
                    varname1.Append("       C.Is_Drg " & vbCrLf)
                    varname1.Append(" FROM   PUB_Disease_ICD10 C " & vbCrLf)

                    If IsEqualMatch = "Y" Then
                        varname1.Append(" WHERE  C.DC <> 'Y' AND C.Icd_Code = '" & code & "' ")
                    Else
                        varname1.Append(" WHERE  C.DC <> 'Y' AND C.Icd_Code LIKE '" & code & "%' ")
                    End If

                    varname1.Append("And C.Is_End_Flag ='Y' And '" & Now().ToString("yyyy/M/d") & "' >=C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date ")

                    If DiseaseTypeId.Trim <> "" Then
                        varname1.Append(" And C.Disease_Type_Id in (" & DiseaseTypeId & ") ")
                    End If

                    If IsSevereDisease.Trim = "Y" Then
                        varname1.Append(" And C.Is_Severe_Disease='Y' ")
                    End If

                    If SourceFlag <> "" Then
                        varname1.Append(" And  (" & SourceFlag & ") ")
                    End If

                    varname1.Append(" Order By  Icd10 ")

                End If

            ElseIf codeName <> "" Then

                If IcdType = "Icd9" Then

                    varname1.Append("SELECT Distinct RTRIM(A.Icd_Code) as 'Icd9', " & vbCrLf)
                    varname1.Append("       RTRIM(C.Icd_Code) as 'Icd10', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_En_Name) as 'Disease_En_Name', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_Name) as 'Disease_Name', " & vbCrLf)
                    varname1.Append("       C.Disease_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Effect_Date, " & vbCrLf)
                    varname1.Append("       C.Disease_Hosp_Name, " & vbCrLf)
                    varname1.Append("       C.Majorcare_Code, " & vbCrLf)
                    varname1.Append("       C.Limit_Sex_Id, " & vbCrLf)
                    varname1.Append("       C.Infection_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Limit_Age, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Year, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Month, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Day, " & vbCrLf)
                    varname1.Append("       C.Age_End_Year, " & vbCrLf)
                    varname1.Append("       C.Age_End_Month, " & vbCrLf)
                    varname1.Append("       C.Age_End_Day, " & vbCrLf)
                    varname1.Append("       C.Is_Exclude_Labdiscount, " & vbCrLf)
                    varname1.Append("       C.Is_Chronic_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Psy_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Rare_Diseases, " & vbCrLf)
                    varname1.Append("       C.Is_Major_P, " & vbCrLf)
                    varname1.Append("       C.Is_Minor_P, " & vbCrLf)
                    varname1.Append("       C.Is_Mcc, " & vbCrLf)
                    varname1.Append("       C.Is_Cc, " & vbCrLf)
                    varname1.Append("       C.End_Date, " & vbCrLf)
                    varname1.Append("       C.Is_Pre5_Diagnosis, " & vbCrLf)
                    varname1.Append("       C.Is_Or, " & vbCrLf)
                    varname1.Append("       C.Is_Drg " & vbCrLf)
                    varname1.Append(" FROM   PUB_Disease C " & vbCrLf)
                    varname1.Append(" Left Join  PUB_Disease_ICD10_Mapping B  on B.ICD10_Code =C.Icd_Code And B.Disease_Type_Id = C.Disease_Type_Id  " & vbCrLf)
                    varname1.Append(" Left Join  PUB_Disease_ICD10 A  On A.Icd_Code =B.ICD_Code And A.Disease_Type_Id = B.Disease_Type_Id  And  A.DC <> 'Y' " & vbCrLf)

                    If IsEqualMatch = "Y" Then
                        varname1.Append(" WHERE  C.DC <> 'Y' AND C.Disease_En_Name = '" & codeName & "' ")
                    Else
                        varname1.Append(" WHERE  C.DC <> 'Y' AND C.Disease_En_Name like '%" & codeName & "%' ")
                    End If

                    varname1.Append(" And '" & Now().ToString("yyyy/M/d") & "' >=C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date ")

                    If DiseaseTypeId.Trim <> "" Then
                        varname1.Append(" And C.Disease_Type_Id in (" & DiseaseTypeId & ") ")
                    End If

                    If IsSevereDisease.Trim = "Y" Then
                        varname1.Append(" And C.Is_Severe_Disease='Y' ")
                    End If

                    If SourceFlag <> "" Then
                        varname1.Append(" And  (" & SourceFlag & ") ")
                    End If

                    varname1.Append(" Order By Icd9 ,Icd10 ")



                ElseIf IcdType = "Icd10" Then

                    varname1.Append("SELECT Distinct RTRIM(A.Icd_Code) as 'Icd9', " & vbCrLf)
                    varname1.Append("       RTRIM(C.Icd_Code) as 'Icd10', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_En_Name) as 'Disease_En_Name', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_Name) as 'Disease_Name', " & vbCrLf)
                    varname1.Append("       C.Disease_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Effect_Date, " & vbCrLf)
                    varname1.Append("       C.Disease_Hosp_Name, " & vbCrLf)
                    varname1.Append("       C.Majorcare_Code, " & vbCrLf)
                    varname1.Append("       C.Limit_Sex_Id, " & vbCrLf)
                    varname1.Append("       C.Infection_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Limit_Age, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Year, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Month, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Day, " & vbCrLf)
                    varname1.Append("       C.Age_End_Year, " & vbCrLf)
                    varname1.Append("       C.Age_End_Month, " & vbCrLf)
                    varname1.Append("       C.Age_End_Day, " & vbCrLf)
                    varname1.Append("       C.Is_Exclude_Labdiscount, " & vbCrLf)
                    varname1.Append("       C.Is_Chronic_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Psy_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Rare_Diseases, " & vbCrLf)
                    varname1.Append("       C.Is_Major_P, " & vbCrLf)
                    varname1.Append("       C.Is_Minor_P, " & vbCrLf)
                    varname1.Append("       C.Is_Mcc, " & vbCrLf)
                    varname1.Append("       C.Is_Cc, " & vbCrLf)
                    varname1.Append("       C.End_Date, " & vbCrLf)
                    varname1.Append("       C.Is_Pre5_Diagnosis, " & vbCrLf)
                    varname1.Append("       C.Is_Or, " & vbCrLf)
                    varname1.Append("       C.Is_Drg " & vbCrLf)
                    varname1.Append(" FROM   PUB_Disease_ICD10 C " & vbCrLf)
                    varname1.Append(" Left Join  PUB_Disease_ICD10_Mapping B  on B.ICD10_Code =C.Icd_Code And B.Disease_Type_Id = C.Disease_Type_Id  " & vbCrLf)
                    varname1.Append(" Left Join  PUB_Disease A  On A.Icd_Code =B.ICD_Code And A.Disease_Type_Id = B.Disease_Type_Id  And  A.DC <> 'Y' " & vbCrLf)

                    If IsEqualMatch = "Y" Then
                        varname1.Append(" WHERE  C.DC <> 'Y' AND C.Disease_En_Name = '" & codeName & "' ")
                    Else
                        varname1.Append(" WHERE  C.DC <> 'Y' AND C.Disease_En_Name like '%" & codeName & "%' ")
                    End If

                    varname1.Append(" And C.Is_End_Flag ='Y'  And '" & Now().ToString("yyyy/M/d") & "' >=C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date ")

                    If DiseaseTypeId.Trim <> "" Then
                        varname1.Append(" And C.Disease_Type_Id in (" & DiseaseTypeId & ") ")
                    End If

                    If IsSevereDisease.Trim = "Y" Then
                        varname1.Append(" And C.Is_Severe_Disease='Y' ")
                    End If

                    If SourceFlag <> "" Then
                        varname1.Append(" And  (" & SourceFlag & ") ")
                    End If

                    varname1.Append(" Order By Icd9 ,Icd10 ")



                ElseIf IcdType = "OnlyIcd9" Then

                    varname1.Append("SELECT Distinct   " & vbCrLf)
                    varname1.Append("       RTRIM(C.Icd_Code) as 'Icd9', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_En_Name) as 'Disease_En_Name', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_Name) as 'Disease_Name', " & vbCrLf)
                    varname1.Append("       C.Disease_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Effect_Date, " & vbCrLf)
                    varname1.Append("       C.Disease_Hosp_Name, " & vbCrLf)
                    varname1.Append("       C.Majorcare_Code, " & vbCrLf)
                    varname1.Append("       C.Limit_Sex_Id, " & vbCrLf)
                    varname1.Append("       C.Infection_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Limit_Age, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Year, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Month, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Day, " & vbCrLf)
                    varname1.Append("       C.Age_End_Year, " & vbCrLf)
                    varname1.Append("       C.Age_End_Month, " & vbCrLf)
                    varname1.Append("       C.Age_End_Day, " & vbCrLf)
                    varname1.Append("       C.Is_Exclude_Labdiscount, " & vbCrLf)
                    varname1.Append("       C.Is_Chronic_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Psy_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Rare_Diseases, " & vbCrLf)
                    varname1.Append("       C.Is_Major_P, " & vbCrLf)
                    varname1.Append("       C.Is_Minor_P, " & vbCrLf)
                    varname1.Append("       C.Is_Mcc, " & vbCrLf)
                    varname1.Append("       C.Is_Cc, " & vbCrLf)
                    varname1.Append("       C.End_Date, " & vbCrLf)
                    varname1.Append("       C.Is_Pre5_Diagnosis, " & vbCrLf)
                    varname1.Append("       C.Is_Or, " & vbCrLf)
                    varname1.Append("       C.Is_Drg " & vbCrLf)
                    varname1.Append(" FROM   PUB_Disease C " & vbCrLf)

                    If IsEqualMatch = "Y" Then
                        varname1.Append(" WHERE  C.DC <> 'Y' AND C.Disease_En_Name = '" & codeName & "' ")
                    Else
                        varname1.Append(" WHERE  C.DC <> 'Y' AND C.Disease_En_Name like '%" & codeName & "%' ")
                    End If

                    varname1.Append("And '" & Now().ToString("yyyy/M/d") & "' >=C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date ")

                    If DiseaseTypeId.Trim <> "" Then
                        varname1.Append(" And C.Disease_Type_Id in (" & DiseaseTypeId & ") ")
                    End If

                    If IsSevereDisease.Trim = "Y" Then
                        varname1.Append(" And C.Is_Severe_Disease='Y' ")
                    End If

                    If SourceFlag <> "" Then
                        varname1.Append(" And  (" & SourceFlag & ") ")
                    End If

                    varname1.Append(" Order By  Icd9 ")


                ElseIf IcdType = "OnlyIcd10" Then

                    varname1.Append("SELECT Distinct   " & vbCrLf)
                    varname1.Append("       RTRIM(C.Icd_Code) as 'Icd10', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_En_Name) as 'Disease_En_Name', " & vbCrLf)
                    varname1.Append("	   RTRIM(C.Disease_Name) as 'Disease_Name', " & vbCrLf)
                    varname1.Append("       C.Disease_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Effect_Date, " & vbCrLf)
                    varname1.Append("       C.Disease_Hosp_Name, " & vbCrLf)
                    varname1.Append("       C.Majorcare_Code, " & vbCrLf)
                    varname1.Append("       C.Limit_Sex_Id, " & vbCrLf)
                    varname1.Append("       C.Infection_Type_Id, " & vbCrLf)
                    varname1.Append("       C.Limit_Age, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Year, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Month, " & vbCrLf)
                    varname1.Append("       C.Age_Start_Day, " & vbCrLf)
                    varname1.Append("       C.Age_End_Year, " & vbCrLf)
                    varname1.Append("       C.Age_End_Month, " & vbCrLf)
                    varname1.Append("       C.Age_End_Day, " & vbCrLf)
                    varname1.Append("       C.Is_Exclude_Labdiscount, " & vbCrLf)
                    varname1.Append("       C.Is_Chronic_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Psy_Severe_Disease, " & vbCrLf)
                    varname1.Append("       C.Is_Rare_Diseases, " & vbCrLf)
                    varname1.Append("       C.Is_Major_P, " & vbCrLf)
                    varname1.Append("       C.Is_Minor_P, " & vbCrLf)
                    varname1.Append("       C.Is_Mcc, " & vbCrLf)
                    varname1.Append("       C.Is_Cc, " & vbCrLf)
                    varname1.Append("       C.End_Date, " & vbCrLf)
                    varname1.Append("       C.Is_Pre5_Diagnosis, " & vbCrLf)
                    varname1.Append("       C.Is_Or, " & vbCrLf)
                    varname1.Append("       C.Is_Drg " & vbCrLf)
                    varname1.Append(" FROM   PUB_Disease_ICD10 C " & vbCrLf)
                    varname1.Append(" Left Join  PUB_Disease_ICD10_Mapping B  on B.ICD10_Code =C.Icd_Code And B.Disease_Type_Id = C.Disease_Type_Id  " & vbCrLf)
                    varname1.Append(" Left Join  PUB_Disease A  On A.Icd_Code =B.ICD_Code And A.Disease_Type_Id = B.Disease_Type_Id  And  A.DC <> 'Y' " & vbCrLf)

                    If IsEqualMatch = "Y" Then
                        varname1.Append(" WHERE  C.DC <> 'Y' AND C.Disease_En_Name = '" & codeName & "' ")
                    Else
                        varname1.Append(" WHERE  C.DC <> 'Y' AND C.Disease_En_Name like '%" & codeName & "%' ")
                    End If

                    varname1.Append(" And C.Is_End_Flag ='Y' And '" & Now().ToString("yyyy/M/d") & "' >=C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date ")

                    If DiseaseTypeId.Trim <> "" Then
                        varname1.Append(" And C.Disease_Type_Id in (" & DiseaseTypeId & ") ")
                    End If

                    If IsSevereDisease.Trim = "Y" Then
                        varname1.Append(" And C.Is_Severe_Disease='Y' ")
                    End If

                    If SourceFlag <> "" Then
                        varname1.Append(" And  (" & SourceFlag & ") ")
                    End If

                    varname1.Append(" Order By  Icd10 ")

                End If

            End If


            Return varname1.ToString

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function

    '套裝ICD
    Public Function queryPUBDiseasePackage(ByVal DataDS As DataSet) As DataSet

        Try
            '以Icd10為主

            Dim Icd9 As String = DataDS.Tables(0).Rows(0).Item("Icd9").ToString.Trim
            Dim Icd10 As String = DataDS.Tables(0).Rows(0).Item("Icd10").ToString.Trim
            Dim DiseaseTypeId As String = DataDS.Tables(0).Rows(0).Item("DiseaseTypeId").ToString.Trim
            Dim IsSevereDisease As String = DataDS.Tables(0).Rows(0).Item("IsSevereDisease").ToString.Trim

            Dim Is_OPD As String = DataDS.Tables(0).Rows(0).Item("Is_OPD").ToString.Trim
            Dim Is_IPD As String = DataDS.Tables(0).Rows(0).Item("Is_IPD").ToString.Trim
            Dim Is_EPD As String = DataDS.Tables(0).Rows(0).Item("Is_EPD").ToString.Trim

            Dim SourceFlag As String = ""

            If Is_OPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += " C.Is_Opd='Y' "
                Else
                    SourceFlag += " Or C.Is_Opd='Y' "
                End If

            End If

            If Is_IPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += " C.Is_Ipd='Y' "
                Else
                    SourceFlag += " Or C.Is_Ipd='Y' "
                End If
            End If

            If Is_EPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += " C.Is_Emg='Y' "
                Else
                    SourceFlag += " Or C.Is_Emg='Y' "
                End If
            End If


            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            'icd10================

            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT Distinct A.Icd_Code as 'Icd9', " & vbCrLf)
            varname1.Append("       C.Icd_Code as 'Icd10', " & vbCrLf)
            varname1.Append("	   C.Disease_En_Name, " & vbCrLf)
            varname1.Append("	   C.Disease_Name, " & vbCrLf)
            varname1.Append("       C.Disease_Type_Id, " & vbCrLf)
            varname1.Append("       C.Effect_Date, " & vbCrLf)
            varname1.Append("       C.Disease_Hosp_Name, " & vbCrLf)
            varname1.Append("       C.Majorcare_Code, " & vbCrLf)
            varname1.Append("       C.Limit_Sex_Id, " & vbCrLf)
            varname1.Append("       C.Infection_Type_Id, " & vbCrLf)
            varname1.Append("       C.Limit_Age, " & vbCrLf)
            varname1.Append("       C.Age_Start_Year, " & vbCrLf)
            varname1.Append("       C.Age_Start_Month, " & vbCrLf)
            varname1.Append("       C.Age_Start_Day, " & vbCrLf)
            varname1.Append("       C.Age_End_Year, " & vbCrLf)
            varname1.Append("       C.Age_End_Month, " & vbCrLf)
            varname1.Append("       C.Age_End_Day, " & vbCrLf)
            varname1.Append("       C.Is_Exclude_Labdiscount, " & vbCrLf)
            varname1.Append("       C.Is_Chronic_Disease, " & vbCrLf)
            varname1.Append("       C.Is_Severe_Disease, " & vbCrLf)
            varname1.Append("       C.Is_Psy_Severe_Disease, " & vbCrLf)
            varname1.Append("       C.Is_Rare_Diseases, " & vbCrLf)
            varname1.Append("       C.Is_Major_P, " & vbCrLf)
            varname1.Append("       C.Is_Minor_P, " & vbCrLf)
            varname1.Append("       C.Is_Mcc, " & vbCrLf)
            varname1.Append("       C.Is_Cc, " & vbCrLf)
            varname1.Append("       C.End_Date, " & vbCrLf)
            varname1.Append("       C.Is_Pre5_Diagnosis, " & vbCrLf)
            varname1.Append("       C.Is_Or, " & vbCrLf)
            varname1.Append("       C.Is_Drg " & vbCrLf)
            varname1.Append(" FROM   PUB_Disease_ICD10 C " & vbCrLf)
            varname1.Append(" Left Join  PUB_Disease_ICD10_Mapping B  on B.ICD10_Code =C.Icd_Code And B.Icd_Code = '" & Icd9 & "' And B.Disease_Type_Id = C.Disease_Type_Id " & vbCrLf)
            varname1.Append(" Left Join  PUB_Disease A  On A.Icd_Code =B.ICD_Code And A.Icd_Code = '" & Icd9 & "' And A.Disease_Type_Id = B.Disease_Type_Id   And  A.DC <> 'Y' " & vbCrLf)
            varname1.Append(" WHERE   C.DC <> 'Y' AND C.Icd_Code = '" & Icd10 & "' ")

            command.CommandText = varname1.ToString

            command.CommandText += "And '" & Now().ToString("yyyy/M/d") & "' >=C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date "

            If DiseaseTypeId.Trim <> "" Then
                command.CommandText += " And C.Disease_Type_Id in (" & DiseaseTypeId & ") "
            End If

            If IsSevereDisease.Trim = "Y" Then
                command.CommandText += " And C.Is_Severe_Disease='Y' "
            End If

            'If SourceFlag <> "" Then
            '    command.CommandText += " And  (" & SourceFlag & ") "
            'End If


            command.CommandText += " Order By C.Icd_Code"


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)

            End Using
            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    '隨輸隨選 藥品 OPH_Pharmacy_Base
    Public Function queryOPHPharmacyBaseE(ByVal DataDS As DataSet) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            Dim code As String = DataDS.Tables(0).Rows(0).Item("Code").ToString.Trim
            Dim codeName As String = DataDS.Tables(0).Rows(0).Item("Name").ToString.Trim
            Dim DrugType As String = DataDS.Tables(0).Rows(0).Item("Action").ToString.Trim

            Dim Is_OPD As String = DataDS.Tables(0).Rows(0).Item("Is_OPD").ToString.Trim
            Dim Is_IPD As String = DataDS.Tables(0).Rows(0).Item("Is_IPD").ToString.Trim
            Dim Is_EPD As String = DataDS.Tables(0).Rows(0).Item("Is_EPD").ToString.Trim

            Dim IsEqualMatch As String = "N"

            If DataDS.Tables(0).Columns.Contains("IsEqualMatch") AndAlso DataDS.Tables(0).Rows(0).Item("IsEqualMatch").ToString.Trim = "Y" Then
                IsEqualMatch = "Y"
            End If


            Dim SourceFlag As String = ""

            If Is_OPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += " A.Is_Opd='Y' Or A.Is_Opd='C' "
                Else
                    SourceFlag += " Or A.Is_Opd='Y' Or A.Is_Opd='C' "
                End If

            End If

            If Is_IPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += " A.Is_Ipd='Y' "
                Else
                    SourceFlag += " Or A.Is_Ipd='Y' Or A.Is_Ipd='C' "
                End If
            End If

            If Is_EPD.Trim = "Y" Then
                If SourceFlag = "" Then
                    SourceFlag += " A.Is_Emg='Y' "
                Else
                    SourceFlag += " Or A.Is_Emg='Y' Or A.Is_Emg='C' "
                End If
            End If




            If code <> "" Then

                If DrugType = "NormalDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  , E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                      " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                        Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                        Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                      " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                        Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                        Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If

                ElseIf DrugType = "NormalDrug2" Then


                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification ,A.Order_Code ,A.Supply_Status_Memo  , E.Code_Name As 'Drug_Reminder_Name'  ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                          " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                          " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                          " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                          " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code  , A.Is_Control_Rule   ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Pharmacy_Name , A.Alert_Content "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  , PUB_Order B  " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                       Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                       Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  , PUB_Order B  " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                       Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                       Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If




                ElseIf DrugType = "TPNDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If

                    'command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    'command.CommandText += " And C.Property_Id ='09' "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id <>'5' And  C.DC<>'Y'  "



                ElseIf DrugType = "TPNDrug2----------" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification ,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule, A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio, Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty   , A.Pharmacy_Name  , A.Alert_Content  "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,    OPH_Property C  , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,    OPH_Property C  , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='09' "

                ElseIf DrugType = "TPNDrug2" Then

                    'Tpn類別為OPH_TPN_Pharmacy.TPN_KIND_ID <> ‘5’

                    '混合類別為OPH_TPN_Pharmacy.TPN_KIND_ID = ‘5’

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification ,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule, A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio, Y.Add_Price , B.Is_Icd_Check  , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Pharmacy_Name , A.Alert_Content   "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,    OPH_TPN_Pharmacy C , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,    OPH_TPN_Pharmacy C , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id in ( '1', '2' ) And  C.DC<>'Y'  " 'modified on 2011-03-16 TPN藥的 Tpn_Kind_Id = 1 or 2


                ElseIf DrugType = "ChemoDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                             Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                             Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                             Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                             Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                ElseIf DrugType = "ChemoDrug2" Then


                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                           " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                           " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                           " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                           " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code  , A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio, Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Pharmacy_Name , A.Alert_Content  "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  ,   OPH_Property C  , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  ,   OPH_Property C  , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                ElseIf DrugType = "VaccineDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='14' "

                ElseIf DrugType = "VaccineDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio, Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder  , A.Package_Qty , A.Pharmacy_Name , A.Alert_Content  "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  ,   OPH_Property C , PUB_Order B " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                        " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                         Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                         Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  ,   OPH_Property C , PUB_Order B " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                        " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                         Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                         Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='14' "




                ElseIf DrugType = "ChemoAndNormalDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                      " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                        Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                        Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                      " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                        Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                        Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If



                    command.CommandText += " Union All"

                    command.CommandText += " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                                                 " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                                                    Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                                                    Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                ElseIf DrugType = "ChemoAndNormalDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                         " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                          " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                          " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                          " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                          " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio, Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Pharmacy_Name , A.Alert_Content "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' )  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                    " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                      Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                      Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' )  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                    " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                      Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                      Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If

                    command.CommandText += " Union All"

                    command.CommandText += " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Pharmacy_Name , A.Alert_Content  "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_Property C , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_Property C , PUB_Order B " & _
                                         " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                         " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                          Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                          Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "


                ElseIf DrugType = "TPNAndNormalDrug" Then

                    'command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    'command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) , PUB_Order B  " & _
                    '                   " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                    '                     Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                    '                     Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                    'command.CommandText += " Union All"

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "  'A.Pharmacy_Name , A.* , B.*  

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                             Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                             Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                             Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                             Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    'command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    'command.CommandText += " And C.Property_Id ='09' "


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='4' And  C.DC<>'Y'  " 'modify on 2011-03-16 混合的 Tpn_Kind_Id = 4


                ElseIf DrugType = "TPNAndNormalDrug2" Then

                    'command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                    '                     " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                    '                       " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                    '                       " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                    '                       " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                    '                       " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check  "

                    'command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) , PUB_Order B  " & _
                    '                       " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                    '                       " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                    '                  " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                    '                    Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                    '                    Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                    'command.CommandText += " Union All"

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check  , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Pharmacy_Name , A.Alert_Content "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C  , PUB_Order B " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C  , PUB_Order B " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "
                    End If


                    'command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    'command.CommandText += " And C.Property_Id ='09' "
                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='4' And  C.DC<>'Y'  "  'modify on 2011-03-16 混合的 Tpn_Kind_Id = 4


                ElseIf DrugType = "TPNAddDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                        " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                       " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                       " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                       " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                       " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check  , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Pharmacy_Name , A.Alert_Content "

                    If IsEqualMatch = "Y" Then
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C  , PUB_Order B " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code = '" & code & "'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    Else
                        command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C  , PUB_Order B " & _
                                          " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                          " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                         " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  B.Order_Code like '" & code & "%'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    End If


                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='5' And  C.DC<>'Y'  "  'modify on 2011-03-16 添加的 Tpn_Kind_Id = 5



                ElseIf DrugType = "OMOChemoDiluteMap" Then

                    Dim var1 As New System.Text.StringBuilder
                    var1.Append("SELECT DISTINCT A.Dilute_Name              AS Order_En_Name, " & vbCrLf)
                    var1.Append("                RTRIM(A.Dilute_Order_Code) AS Order_Code, " & vbCrLf)
                    var1.Append("                RTRIM(A.Drip)              AS Drip, " & vbCrLf)
                    var1.Append("                A.Dilute_Qty, " & vbCrLf)
                    var1.Append("                RTRIM(B.Charge_Unit)       AS Charge_Unit, " & vbCrLf)
                    var1.Append("                A.Dilute_Kind, " & vbCrLf)
                    var1.Append("                RTRIM(B.Order_Type_Id)     AS Order_Type_Id, " & vbCrLf)
                    var1.Append("                A.Dosage_Weight_B, " & vbCrLf)
                    var1.Append("                A.Dosage_Weight_E, " & vbCrLf)
                    var1.Append("                A.Is_BSA, " & vbCrLf)
                    var1.Append("                A.Is_61_Weight, " & vbCrLf)
                    var1.Append("                X.Price                    AS [Self_Price], " & vbCrLf)
                    var1.Append("                Y.Price                    AS [Price], " & vbCrLf)
                    var1.Append("                X.Order_Ratio              AS [Self_Order_Ratio], " & vbCrLf)
                    var1.Append("                X.Material_Ratio           AS Self_Material_Ratio, " & vbCrLf)
                    var1.Append("                Y.Order_Ratio, " & vbCrLf)
                    var1.Append("                Y.Material_Ratio, " & vbCrLf)
                    var1.Append("                Y.Add_Price, " & vbCrLf)
                    var1.Append("                B.Is_Icd_Check, " & vbCrLf)
                    var1.Append("                B.Include_Order_Mark, " & vbCrLf)
                    var1.Append("                RTRIM(C.Pharmacy_12_Code)  AS Pharmacy_12_Code, " & vbCrLf)
                    var1.Append("                RTRIM(C.Alert_Content)  AS Alert_Content, " & vbCrLf)
                    var1.Append("                RTRIM(C.Form_Kind_Id)  AS Form_Kind_Id, " & vbCrLf)
                    var1.Append("                RTRIM(C.Opd_Lack_Id)       AS Opd_Lack_Id ," & vbCrLf)
                    var1.Append("                RTRIM(C.Pharmacy_Name)       AS Pharmacy_Name, " & vbCrLf)
                    var1.Append("                RTRIM(B.Is_Prior_Review)       AS Is_Prior_Review " & vbCrLf)
                    var1.Append("FROM   OMO_Chemo_Dilute_Map A " & vbCrLf)
                    var1.Append("       INNER JOIN PUB_Order B " & vbCrLf)
                    var1.Append("         ON A.Dilute_Order_Code = B.Order_Code " & vbCrLf)
                    var1.Append("       LEFT JOIN OPH_Pharmacy_Base C " & vbCrLf)
                    var1.Append("         ON A.Dilute_Order_Code = C.Order_Code " & vbCrLf)
                    var1.Append("            AND C.Dc = 'N' " & vbCrLf)
                    var1.Append("       LEFT JOIN PUB_Order_Price X " & vbCrLf)
                    var1.Append("         ON X.DC = 'N' " & vbCrLf)
                    var1.Append("            AND A.Dilute_Order_Code = X.Order_Code " & vbCrLf)
                    var1.Append("            AND X.Main_Identity_Id = '1' " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' <= X.End_Date " & vbCrLf)
                    var1.Append("       LEFT JOIN PUB_Order_Price Y " & vbCrLf)
                    var1.Append("         ON Y.DC = 'N' " & vbCrLf)
                    var1.Append("            AND A.Dilute_Order_Code = Y.Order_Code " & vbCrLf)
                    var1.Append("            AND Y.Main_Identity_Id = '2' " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' <= Y.End_Date " & vbCrLf)
                    var1.Append("WHERE  B.Dc = 'N' " & vbCrLf)

                    If IsEqualMatch = "Y" Then
                        var1.AppendFormat("       AND A.Dilute_Order_Code = '{0}'  " & vbCrLf, code.TrimEnd)
                    Else
                        var1.AppendFormat("       AND A.Dilute_Order_Code like '{0}%'  " & vbCrLf, code.TrimEnd)
                    End If


                    'Dim var1 As New System.Text.StringBuilder
                    'var1.Append("SELECT DISTINCT A.Dilute_Name              AS Order_En_Name, " & vbCrLf)
                    'var1.Append("                RTRIM(A.Dilute_Order_Code) AS Order_Code, " & vbCrLf)
                    'var1.Append("                RTRIM(A.Drip)              AS Drip, " & vbCrLf)
                    'var1.Append("                A.Dilute_Qty, " & vbCrLf)
                    'var1.Append("                RTRIM(B.Charge_Unit)       AS Charge_Unit, " & vbCrLf)
                    'var1.Append("                A.Dilute_Kind, " & vbCrLf)
                    'var1.Append("                RTRIM(B.Order_Type_Id)     AS Order_Type_Id, " & vbCrLf)
                    'var1.Append("                A.Dosage_Weight_B, " & vbCrLf)
                    'var1.Append("                A.Dosage_Weight_E, " & vbCrLf)
                    'var1.Append("                A.Is_BSA, " & vbCrLf)
                    'var1.Append("                A.Is_61_Weight , " & vbCrLf)
                    'var1.Append("                X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check " & vbCrLf)
                    'var1.Append(" FROM   OMO_Chemo_Dilute_Map A " & vbCrLf)
                    'var1.Append("       INNER JOIN PUB_Order B " & vbCrLf)
                    'var1.Append("         ON A.Dilute_Order_Code = B.Order_Code " & vbCrLf)
                    'var1.Append("        Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & vbCrLf)
                    'var1.Append("        Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & vbCrLf)
                    'var1.Append(" WHERE  B.Dc = 'N' " & vbCrLf)
                    'var1.AppendFormat("       AND A.Dilute_Order_Code like '{0}%'  " & vbCrLf, code.TrimEnd)

                    command.CommandText = var1.ToString

                    'command.CommandText = " Select Distinct A.Dilute_Name , Rtrim(A.Dilute_Order_Code) as Dilute_Order_Code   , A.Dilute_Kind ,A.Dilute_Qty ,A.Drip ,A.Dosage_Weight_B ,A.Dosage_Weight_E ,A.Is_BSA ,A.Is_61_Weight " & _
                    '                      " From  OMO_Chemo_Dilute_Map A Where A.Dilute_Order_Code like '" & code & "%'  "

                    command.CommandText += " Order By A.Dilute_Name "
                End If

                If DrugType <> "OMOChemoDiluteMap" Then
                    command.CommandText += " Order By A.Order_Code "
                End If

            ElseIf codeName <> "" Then


                If DrugType = "NormalDrug" Then
                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "

                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                         Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                         Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                ElseIf DrugType = "NormalDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                        " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                        " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                        " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                        " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Pharmacy_Name , A.Alert_Content "

                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                      " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%' ) And '" & _
                                        Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                        Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "



                ElseIf DrugType = "TPNDrug" Then
                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "
                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    'command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    'command.CommandText += " And C.Property_Id ='09' "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id in ( '1', '2' ) And  C.DC<>'Y'  " 'TPN藥的 Tpn_Kind_Id = 1 or 2




                ElseIf DrugType = "TPNDrug2" Then


                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                          " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                          " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                          " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                          " B.Is_Prior_Review,  B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio'  ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Pharmacy_Name , A.Alert_Content "


                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C , PUB_Order B  " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                              " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                                 Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                                 Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id in ( '1', '2' ) And  C.DC<>'Y'  " 'TPN藥的 Tpn_Kind_Id = 1 or 2



                ElseIf DrugType = "ChemoDrug" Then
                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "
                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                ElseIf DrugType = "ChemoDrug2" Then


                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                           " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                           " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                           " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                           " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark  , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Pharmacy_Name , A.Alert_Content "


                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_Property C , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                             " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                                Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                                Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "




                ElseIf DrugType = "VaccineDrug" Then
                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "
                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                            Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                            Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='14' "

                ElseIf DrugType = "VaccineDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                         " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                       " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                       " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                       " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                       " B.Is_Prior_Review,  B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio'  ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Pharmacy_Name , A.Alert_Content "


                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_Property C  , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='14' "





                ElseIf DrugType = "ChemoAndNormalDrug" Then


                    command.CommandText = " Select  Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "
                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_Property C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                    command.CommandText += " Union All "

                    command.CommandText += " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*  "
                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' )  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                       " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                         Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                         Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                ElseIf DrugType = "ChemoAndNormalDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio'  ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Pharmacy_Name , A.Alert_Content "


                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y'  ,   OPH_Property C , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                          " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                             Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                             Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Property_Id ='10' "

                    command.CommandText += " Union All "

                    command.CommandText += " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Order_Code ,A.Supply_Status_Memo   ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                        " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                        " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                        " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                        " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio  , Y.Add_Price , B.Is_Icd_Check , B.Include_Order_Mark  , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty  , A.Pharmacy_Name , A.Alert_Content "


                    command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B  " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                     " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'  ) And '" & _
                                       Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                       Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "



                ElseIf DrugType = "TPNAndNormalDrug" Then

                    command.CommandText = " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' , A.* , B.*   "
                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' , PUB_Order B ,   OPH_TPN_Pharmacy C " & _
                                           " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                                              Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                              Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    'command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    'command.CommandText += " And C.Property_Id ='09' "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='4' And  C.DC<>'Y'  " '混合藥的Tpn_Kind_Id = 4



                    'command.CommandText += " Union All "

                    'command.CommandText += " Select Distinct A.Order_Name , A.Order_Code, A.Supply_Status_Memo , A.* , B.*   "
                    'command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) , PUB_Order B  " & _
                    '                   " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Order_Name like '" & codeName & "%'  ) And '" & _
                    '                     Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                    '                     Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "


                ElseIf DrugType = "TPNAndNormalDrug2" Then


                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                          " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                         " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                         " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                         " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                         " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio  , Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Pharmacy_Name , A.Alert_Content "

                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                        " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='4' And  C.DC<>'Y'  " '混合藥的Tpn_Kind_Id = 4


                    'command.CommandText += " Union All "

                    'command.CommandText += " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Order_Code ,A.Supply_Status_Memo ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                    '                      " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                    '                      " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                    '                      " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                    '                      " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                    '                      " B.Is_Prior_Review,  B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule  ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio'  ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check  "

                    'command.CommandText += " From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) , PUB_Order B  " & _
                    '                       " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                    '                       " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                    '                  " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'  ) And '" & _
                    '                    Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                    '                    Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                ElseIf DrugType = "TPNAddDrug2" Then

                    command.CommandText = " Select Distinct A.Scientific_Name , A.Trade_Name ,A.Specification,A.Order_Code ,A.Supply_Status_Memo  ,  E.Code_Name As 'Drug_Reminder_Name' ,  A.Order_Name   , A.Pharmacy_12_Code ," & _
                                      " A.Base_Dosage , A.Usage_Code , A.Frequency_Code , " & _
                                     " A.Order_Unit1 , A.Order_Unit2 ,A.Order_Unit3 ,A.Order_Unit4 ,A.Order_Unit5 ," & _
                                     " A.Charge_Unit , A.Dosage_unit , A.Base_Dosage_Unit , A.Opd_Lack_Id, " & _
                                     " B.Order_Type_Id , B.Is_Cure , B.Cure_Type_Id , B.Treatment_Type_Id , B.Is_Order_Check ,   " & _
                                     " B.Is_Prior_Review,   B.Is_IC_Card_Order , A.Class_Code , A.Is_Control_Rule ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio  , Y.Add_Price  , B.Is_Icd_Check , B.Include_Order_Mark , A.Form_Kind_Id , A.Is_Non_Powder , A.Package_Qty , A.Pharmacy_Name , A.Alert_Content "

                    command.CommandText += " From  OPH_Pharmacy_Base A  Left Join  OPH_Code E On E.Type_Id ='8' And A.Omo_Reminder_Id =E.Code_Id And E.DC<>'Y' ,   OPH_TPN_Pharmacy C , PUB_Order B " & _
                                           " Left Join PUB_Order_Price X On X.DC='N' And B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                                           " Left Join PUB_Order_Price Y On Y.DC='N' And B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                                        " Where  (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And (  A.Scientific_Name like '" & codeName & "%' Or A.Trade_Name like '" & codeName & "%'   ) And '" & _
                                           Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & _
                                           Now().ToString("yyyy/M/d") & "'<= B.End_Date  And B.Order_Type_Id='E'   "

                    command.CommandText += " And A.Pharmacy_12_Code=C.Pharmacy_12_Code "
                    command.CommandText += " And C.Tpn_Kind_Id ='5' And  C.DC<>'Y'  " '添加藥的Tpn_Kind_Id = 5

                ElseIf DrugType = "OMOChemoDiluteMap" Then

                    Dim var1 As New System.Text.StringBuilder
                    var1.Append("SELECT DISTINCT A.Dilute_Name              AS Order_En_Name, " & vbCrLf)
                    var1.Append("                RTRIM(A.Dilute_Order_Code) AS Order_Code, " & vbCrLf)
                    var1.Append("                RTRIM(A.Drip)              AS Drip, " & vbCrLf)
                    var1.Append("                A.Dilute_Qty, " & vbCrLf)
                    var1.Append("                RTRIM(B.Charge_Unit)       AS Charge_Unit, " & vbCrLf)
                    var1.Append("                A.Dilute_Kind, " & vbCrLf)
                    var1.Append("                RTRIM(B.Order_Type_Id)     AS Order_Type_Id, " & vbCrLf)
                    var1.Append("                A.Dosage_Weight_B, " & vbCrLf)
                    var1.Append("                A.Dosage_Weight_E, " & vbCrLf)
                    var1.Append("                A.Is_BSA, " & vbCrLf)
                    var1.Append("                A.Is_61_Weight, " & vbCrLf)
                    var1.Append("                X.Price                    AS [Self_Price], " & vbCrLf)
                    var1.Append("                Y.Price                    AS [Price], " & vbCrLf)
                    var1.Append("                X.Order_Ratio              AS [Self_Order_Ratio], " & vbCrLf)
                    var1.Append("                X.Material_Ratio           AS Self_Material_Ratio, " & vbCrLf)
                    var1.Append("                Y.Order_Ratio, " & vbCrLf)
                    var1.Append("                Y.Material_Ratio, " & vbCrLf)
                    var1.Append("                Y.Add_Price, " & vbCrLf)
                    var1.Append("                B.Is_Icd_Check, " & vbCrLf)
                    var1.Append("                B.Include_Order_Mark, " & vbCrLf)
                    var1.Append("                RTRIM(C.Pharmacy_12_Code)  AS Pharmacy_12_Code, " & vbCrLf)
                    var1.Append("                RTRIM(C.Alert_Content)  AS Alert_Content, " & vbCrLf)
                    var1.Append("                RTRIM(C.Form_Kind_Id)  AS Form_Kind_Id, " & vbCrLf)
                    var1.Append("                RTRIM(C.Opd_Lack_Id)       AS Opd_Lack_Id, " & vbCrLf)
                    var1.Append("                RTRIM(C.Pharmacy_Name)       AS Pharmacy_Name, " & vbCrLf)
                    var1.Append("                RTRIM(B.Is_Prior_Review)       AS Is_Prior_Review " & vbCrLf)
                    var1.Append("FROM   OMO_Chemo_Dilute_Map A " & vbCrLf)
                    var1.Append("       INNER JOIN PUB_Order B " & vbCrLf)
                    var1.Append("         ON A.Dilute_Order_Code = B.Order_Code " & vbCrLf)
                    var1.Append("       LEFT JOIN OPH_Pharmacy_Base C " & vbCrLf)
                    var1.Append("         ON A.Dilute_Order_Code = C.Order_Code " & vbCrLf)
                    var1.Append("            AND C.Dc = 'N' " & vbCrLf)
                    var1.Append("       LEFT JOIN PUB_Order_Price X " & vbCrLf)
                    var1.Append("         ON X.DC = 'N' " & vbCrLf)
                    var1.Append("            AND A.Dilute_Order_Code = X.Order_Code " & vbCrLf)
                    var1.Append("            AND X.Main_Identity_Id = '1' " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' <= X.End_Date " & vbCrLf)
                    var1.Append("       LEFT JOIN PUB_Order_Price Y " & vbCrLf)
                    var1.Append("         ON Y.DC = 'N' " & vbCrLf)
                    var1.Append("            AND A.Dilute_Order_Code = Y.Order_Code " & vbCrLf)
                    var1.Append("            AND Y.Main_Identity_Id = '2' " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date " & vbCrLf)
                    var1.Append("            AND '" & Now().ToString("yyyy/M/d") & "' <= Y.End_Date " & vbCrLf)
                    var1.Append("WHERE  B.Dc = 'N' " & vbCrLf)
                    var1.AppendFormat("       AND A.Dilute_Name like '{0}%'  " & vbCrLf, codeName.TrimEnd)

                    'Dim var1 As New System.Text.StringBuilder
                    'var1.Append("SELECT DISTINCT A.Dilute_Name              AS Order_En_Name, " & vbCrLf)
                    'var1.Append("                RTRIM(A.Dilute_Order_Code) AS Order_Code, " & vbCrLf)
                    'var1.Append("                RTRIM(A.Drip)              AS Drip, " & vbCrLf)
                    'var1.Append("                A.Dilute_Qty, " & vbCrLf)
                    'var1.Append("                RTRIM(B.Charge_Unit)       AS Charge_Unit, " & vbCrLf)
                    'var1.Append("                A.Dilute_Kind, " & vbCrLf)
                    'var1.Append("                RTRIM(B.Order_Type_Id)     AS Order_Type_Id, " & vbCrLf)
                    'var1.Append("                A.Dosage_Weight_B, " & vbCrLf)
                    'var1.Append("                A.Dosage_Weight_E, " & vbCrLf)
                    'var1.Append("                A.Is_BSA, " & vbCrLf)
                    'var1.Append("                A.Is_61_Weight, " & vbCrLf)
                    'var1.Append("                X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' ,Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , B.Is_Icd_Check " & vbCrLf)
                    'var1.Append(" FROM   OMO_Chemo_Dilute_Map A " & vbCrLf)
                    'var1.Append("       INNER JOIN PUB_Order B " & vbCrLf)
                    'var1.Append("         ON A.Dilute_Order_Code = B.Order_Code " & vbCrLf)
                    'var1.Append("        Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & vbCrLf)
                    'var1.Append("        Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & vbCrLf)
                    'var1.Append(" WHERE  B.Dc = 'N' " & vbCrLf)
                    'var1.AppendFormat("       AND A.Dilute_Name like '{0}%'  " & vbCrLf, codeName.TrimEnd)

                    command.CommandText = var1.ToString

                    'command.CommandText = " Select Distinct A.Dilute_Name ,Rtrim(A.Dilute_Order_Code) as Dilute_Order_Code  , A.Dilute_Kind ,A.Dilute_Qty ,A.Drip ,A.Dosage_Weight_B ,A.Dosage_Weight_E ,A.Is_BSA ,A.Is_61_Weight " & _
                    '                      " From  OMO_Chemo_Dilute_Map A Where A.Dilute_Name like '" & codeName & "%' "

                    command.CommandText += " Order By A.Dilute_Name "
                End If

                If DrugType <> "OMOChemoDiluteMap" Then
                    command.CommandText += " Order By A.Order_Code "
                End If

            End If

            command.CommandText += "; Select * From OPH_Property ;"



            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)

            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    '處理連帶醫令 PUB_Add_Order
    Public Function queryPUBAddOrder() As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText += " Select * From  PUB_Add_Order Where Dc<>'Y' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    '處理連帶醫令 PUB_Add_Order_Detail
    Public Function queryPUBAddOrderDetail(ByVal DataDS As DataSet) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim Add_Order_Code As String = DataDS.Tables(0).Rows(0).Item("Add_Order_Code").ToString.Trim

            command.CommandText += " Select * From PUB_Add_Order_Detail PAOD Left Join PUB_Order_Examination POE On POE.Order_Code=PAOD.Order_Code "
            command.CommandText += "  Where PAOD.Add_Order_Code='" & Add_Order_Code & "' And PAOD.Dc<>'Y' Order By PAOD.Add_Order_Code , PAOD.Add_Order_Detail_No "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    '查詢queryPubNhiHospital
    Public Function queryPubNhiHospital(ByVal DataDS As DataSet) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim Hospital_Code As String = DataDS.Tables(0).Rows(0).Item("Hospital_Code").ToString.Trim

            command.CommandText += " Select * From PUB_NHI_Hospital Where 1=1 "

            If Hospital_Code <> "" Then
                command.CommandText += " And Hospital_Code='" & Hospital_Code & "'  "
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    '查詢queryIHDAppealDisputeReason
    Public Function queryIHDAppealDisputeReason(ByVal DataDS As DataSet) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            'Dim Hospital_Code As String = DataDS.Tables(0).Rows(0).Item("Reason_Code").ToString.Trim
            Dim OrderCode As String = DataDS.Tables(0).Rows(0).Item("Code").ToString.Trim
            Dim OrderEnName As String = DataDS.Tables(0).Rows(0).Item("Name").ToString.Trim
            Dim OrderTypeId As String = DataDS.Tables(0).Rows(0).Item("OrderTypeId").ToString.Trim

            Dim Is_OPD As String = DataDS.Tables(0).Rows(0).Item("Is_OPD").ToString.Trim
            Dim Is_IPD As String = DataDS.Tables(0).Rows(0).Item("Is_IPD").ToString.Trim
            Dim Is_EPD As String = DataDS.Tables(0).Rows(0).Item("Is_EPD").ToString.Trim

            command.CommandText += " Select * From IHD_Appeal_Dispute_Reason Where 1=1  And Substract_Kind_Id = 1 "

            If OrderCode <> "" Then
                command.CommandText += " And Reason_Code = '" & OrderCode & "'  "
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

#Region " 快捷平台查詢下拉選單資料來源 "

    ''' <summary>
    ''' 快捷平台查詢下拉選單資料來源
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-11-14</remarks>
    Public Function QueryComboBoxUCDataSource(ByVal ds As DataSet) As DataSet


        Try

            conn = getConnection()
            conn.Open()

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = ds.Tables(0).Rows(0).Item("Cbo_Source_Data").ToString.Trim

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try

    End Function

#End Region


#End Region

#Region "儲存Client Log"

    Public Function UclSaveClientLog(ByVal ds As DataSet) As DataSet
        Try

            Dim Msg As String = "UclSaveClientLog-" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "-" & ds.Tables(0).Rows(0).Item("Msg").ToString.Trim
            Syscom.Server.CMM.LOGDelegate.getInstance.dbDebugMsg(Msg)
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
     
#End Region

End Class
