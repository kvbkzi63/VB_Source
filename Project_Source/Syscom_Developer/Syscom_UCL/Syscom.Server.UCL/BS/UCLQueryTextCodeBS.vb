Imports System.Data.SqlClient
Imports System.IO
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports System.Transactions
Imports Syscom.Server.PUB
Imports Syscom.Comm.BASE

Public Class UCLQueryTextCodeBS
    Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn

    Dim log As LOGDelegate = LOGDelegate.getInstance
    Dim pvtCondField As New ArrayList
    Dim pvtCondValue As New ArrayList


    Public Function queryOpenWindow(ByVal prmQueryTable As Integer, ByVal prmCondField As String, ByVal prmCondValue As String, ByVal prmCondType As String, Optional ByVal OtherQueryConditionDS As DataSet = Nothing) As DataSet
        Dim SqlCmd As SqlCommand
        Dim cmdStr As String = ""
        Dim myReader As SqlDataReader = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds As DataSet = Nothing
        Dim pvtSysDate = Now().ToString("yyyy/M/d")
        Dim pub As PUBDelegate = PUBDelegate.getInstance
        Dim IsCheckTime As String = "Y"
        Dim IsCheckDrLicense As String = "Y"

        Dim uclRoles As String = ""

        If OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Count > 0 AndAlso OtherQueryConditionDS.Tables.Contains("UseBaseDate") AndAlso OtherQueryConditionDS.Tables("UseBaseDate").Rows.Count > 0 AndAlso IsDate(OtherQueryConditionDS.Tables(0).Rows(0).Item("baseDate")) Then
            pvtSysDate = CDate(OtherQueryConditionDS.Tables("UseBaseDate").Rows(0).Item("baseDate")).ToShortDateString
        End If

        prmCondValue = prmCondValue.Replace("'", "")

        Select Case prmQueryTable
            Case 1

                'cmdStr = "   Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                '       "          RTRIM(C.Dept_Code)+ ' ' +  RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級' , " & _
                '       "          RTRIM(B.Idno) as '身分證號' , RTRIM(B.Employee_En_Name) as '醫師英文姓名' , ''  AS '醫師證書號碼' " & _
                '       "    From  PUB_Doctor A  , " & _
                '       "          PUB_Department C  ,  " & _
                '       "          PUB_Employee B    " & _
                '       " Where " & prmCondField & prmCondType & "'" & prmCondValue & "' " & _
                '       " And C.Dept_Code = B.Dept_Code And C.DC <>'Y' And B.Employee_Code = A.Employee_Code  " & _
                '       " Order By B.Dept_Code , A.Doctor_Code "

                If (OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Contains("IsCheckDrLicense") AndAlso OtherQueryConditionDS.Tables("IsCheckDrLicense").Rows(0).Item("IsCheckDrLicense").ToString.Trim = "N") Then
                    IsCheckDrLicense = "N"
                End If

                If HospConfigUtil.HospConfig = HospConfigUtil.hospConfigList.Tw_TPEHOSP OrElse IsCheckDrLicense = "N" Then
                    cmdStr = "   Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                        "          RTRIM(C.Dept_Code)+ ' ' +  RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級' , " & _
                        "          RTRIM(B.Idno) as '身分證號' , RTRIM(B.Employee_En_Name) as '醫師英文姓名' , ''  AS '醫師證書號碼' " & _
                        "    From  PUB_Doctor A  , " & _
                        "          PUB_Employee B  Left Join  PUB_Department C On C.Dept_Code = B.Dept_Code And C.DC <>'Y'   " & _
                        " Where " & prmCondField & prmCondType & "'" & prmCondValue & "' And " & _
                        "      A.Announce_Effect_Date <= '" & pvtSysDate & "' And " & _
                        "      A.Announce_End_Date >= '" & pvtSysDate & "' " & _
                        " And  B.Employee_Code = A.Employee_Code  " & _
                        " Order By B.Dept_Code , A.Doctor_Code "

                Else
                    cmdStr = "   Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                        "          RTRIM(D.License_Dept_Code)+ ' ' +  RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級' , " & _
                        "          RTRIM(B.Idno) as '身分證號' , RTRIM(B.Employee_En_Name) as '醫師英文姓名' , Rtrim(D.License_No)  AS '醫師證書號碼' " & _
                        "    From  PUB_Doctor A   " & _
                        "Left Join PMS_Emp_License D ON D.Employee_Code = A.Employee_Code And D.License_Id='DR' And D.License_Effect_Date<='" & pvtSysDate & "' And '" & pvtSysDate & "'<= D.License_End_Date And D.Is_Major = 'Y'   " & _
                        "Left Join PUB_Department C  On C.Dept_Code = D.License_Dept_Code And C.DC <>'Y'" & _
                        "inner Join PUB_Employee B  On B.Employee_Code = A.Employee_Code" & _
                        " Where " & prmCondField & prmCondType & "'" & prmCondValue & "' And " & _
                        "      A.Announce_Effect_Date <= '" & pvtSysDate & "' And " & _
                        "      A.Announce_End_Date >= '" & pvtSysDate & "' " & _
                        " Order By D.License_Dept_Code , A.Doctor_Code "

                End If
                
                'cmdStr = "                Select A.Reg_Date as '日期' , " & _
                '       "   Case  " & _
                '        "    When datepart(weekday,A.Reg_Date)=1 Then '星期日'  " & _
                '         "  When datepart(weekday,A.Reg_Date)=2 Then '星期一'  " & _
                '          "  When datepart(weekday,A.Reg_Date)=3 Then '星期二'  " & _
                '           " When datepart(weekday,A.Reg_Date)=4 Then '星期三'  " & _
                '          "  When datepart(weekday,A.Reg_Date)=5 Then '星期四'  " & _
                '          "  When datepart(weekday,A.Reg_Date)=6 Then '星期五'  " & _
                '          "  When datepart(weekday,A.Reg_Date)=7 Then '星期六'  " & _
                '          " End as '星期' ,  " & _
                '" D.Noon_Name() '午別' , B.Dept_Name as '科別' , C.Code_Name as '診別' , A.Noon_Code as 'Noon_Code' , A.Dept_Code  as 'Dept_Code', A.Section_Id  as 'Section_Id'    " & _
                '  "         From      REG_Day_Schedule A , PUB_Department B , PUB_SYSCODE C  , REG_Noon_Config D " & _
                '   "         Where  A.Doctor_Code like'D001%' And A.Dept_Code=B.Dept_Code And C.Type_Id='11' And A.Section_Id=C.Code_Id And A.Noon_Code=D.Noon_Code  " & _
                '    "       Order By Reg_Date  "


                '多選
            Case 101
                cmdStr = " Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                         "       RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級'" & _
                         " From  PUB_Doctor A Left Join PUB_Department C  On C.Dept_Code = A.Dept_Code And C.DC <>'Y' , PUB_Employee B,PUB_Department C " & _
                         " Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And " & _
                         "      A.Announce_Effect_Date <= '" & pvtSysDate & "' And " & _
                         "      A.Announce_End_Date >= '" & pvtSysDate & "' And " & _
                         "      B.Employee_Code = A.Employee_Code And " & _
                         " Order By A.Doctor_Code "

            Case 2

                setCond(prmCondField, prmCondValue)

                cmdStr = " Select RTRIM(Room_Code) as '診間號', RTRIM(Room_Name) as '診間名稱', RTRIM(Room_En_Name) as '診間英文名稱', RTRIM(Tel_Ext_No) as '分機號碼', RTRIM(Zone_Id)  as Zone_Id " & _
                         " From  PUB_Zone_Room " & _
                         " Where     " & pvtCondField.Item(1) & prmCondType & "'" & pvtCondValue.Item(1) & "' " & _
                         " Order By Zone_Id"

            Case 3
                cmdStr = " Select RTRIM(Chart_No) as '病歷號' , RTRIM(Patient_Name) as '姓名' , Case Sex_Id When '1' then '男' When '2' then '女' Else '不明' End as '性別', RTRIM(Idno) as '証號' , Case  When Birth_Date is null then ''  Else  right('0000'+ltrim(dbo.AdToRocDate (Birth_Date)),9)  End as '生日'  , RTRIM(Tel_Home) as '電話(家)' , RTRIM(Tel_Mobile) as '電話(手機)'  , RTRIM(Address) as '住址' , RTRIM(Postal_Code) as '郵遞區號' , Reserve_Chart_No as '合併病歷號' " & _
                         " From  PUB_Patient " & _
                         " Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  "

                'convert(varchar(10), Birth_Date ,111) as '生日'
            Case 4
                cmdStr = " Select RTRIM(A.Icd_Code) as '疾病分類碼' , RTRIM(A.Disease_En_Name) as '英文名稱'  , RTRIM(A.Disease_Name) as '中文名稱' , RTRIM(B.Code_Name) as '診斷類型'  " & _
                         " From  PUB_Disease A , PUB_SYSCODE B " & _
                         " Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And B.Type_Id='33' And A.Disease_Type_Id=B.Code_ID And A.DC<>'Y' And '" & _
                                pvtSysDate & "' >= A.Effect_Date And ('" & _
                                pvtSysDate & "'<= A.End_Date or A.End_Date is null ) " & _
                         " Order By A.Icd_Code "

            Case 5
                cmdStr = " Select RTRIM(A.Order_Code) as '醫令項目代碼' , RTRIM(B.Order_En_Name) as '英文名稱'  , RTRIM(B.Order_Name) as '中文名稱' , RTRIM(C.Code_Name) as '醫令類型'  " & _
                         " From  PUB_Order_Examination A , PUB_Order B , PUB_SYSCODE C" & _
                         "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And A.Is_Scheduled='Y' And A.Order_Code=B.Order_Code And C.Type_Id='31' And B.Order_Type_Id=C.Code_ID   And B.DC<>'Y' And '" & _
                               pvtSysDate & "' >= B.Effect_Date And '" & _
                               pvtSysDate & "'<= B.End_Date  " & _
                         " Order By A.Order_Code "

            Case 105
                cmdStr = " Select RTRIM(A.Order_Code) as '醫令項目代碼' , RTRIM(B.Order_En_Name) as '英文名稱'  , RTRIM(B.Order_Name) as '中文名稱' , RTRIM(C.Code_Name) as '醫令類型'  " & _
                         " From  PUB_Order_Examination A , PUB_Order B , PUB_SYSCODE C" & _
                         "  Where " & prmCondField & prmCondType & " ( " & prmCondValue & ")  And A.Is_Scheduled='Y' And A.Order_Code=B.Order_Code And C.Type_Id='31' And B.Order_Type_Id=C.Code_ID   And B.DC<>'Y' And '" & _
                               pvtSysDate & "' >= B.Effect_Date And '" & _
                               pvtSysDate & "'<= B.End_Date  " & _
                         " Order By A.Order_Code "

            Case 6
                cmdStr = " Select RTRIM(Dept_Code) as '科別代碼' , RTRIM(Dept_Name) as '科別中文名稱'  , RTRIM(Dept_En_Name) as '科別英文名稱' " & _
                       " From  PUB_Department " & _
                       " Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  "

                If Not (OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Contains("CheckDc") AndAlso OtherQueryConditionDS.Tables("CheckDc").Rows(0).Item("IsCheckDc").ToString.Trim = "N") Then
                    cmdStr += " And DC<>'Y'   "
                End If


                If OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Contains("DeptType") Then

                    If OtherQueryConditionDS.Tables("DeptType").Rows(0).Item("Type").ToString.Trim = "Dept" Then
                        cmdStr += " And (Is_Reg_Dept='N' and  Is_Emg_Dept='N' and Is_ipd_Dept='N') And DC<>'Y' "

                    ElseIf OtherQueryConditionDS.Tables("DeptType").Rows(0).Item("Type").ToString.Trim = "OEIDept" Then
                        cmdStr += " And (Is_Reg_Dept='Y' or  Is_Emg_Dept='Y' or Is_ipd_Dept='Y') And DC<>'Y' "

                    ElseIf OtherQueryConditionDS.Tables("DeptType").Rows(0).Item("Type").ToString.Trim = "ODept" Then
                        cmdStr += " And (Is_Reg_Dept='Y') And DC<>'Y' "
                    ElseIf OtherQueryConditionDS.Tables("DeptType").Rows(0).Item("Type").ToString.Trim = "EDept" Then
                        cmdStr += " And (Is_Emg_Dept='Y') And DC<>'Y' "
                    ElseIf OtherQueryConditionDS.Tables("DeptType").Rows(0).Item("Type").ToString.Trim = "IDept" Then
                        cmdStr += " And (Is_ipd_Dept='Y') And DC<>'Y' "
                    End If

                End If

                cmdStr += " Order By Dept_Code "

            Case 106
                cmdStr = " Select RTRIM(Dept_Code) as '科別代碼' , RTRIM(Dept_Name) as '科別中文名稱'  , RTRIM(Dept_En_Name) as '科別英文名稱' " & _
                         " From  PUB_Department " & _
                         " Where " & prmCondField & prmCondType & " (" & prmCondValue & ")   And DC<>'Y' " & _
                         " Order By Dept_Code "


            Case 7
                cmdStr = " Select RTRIM(Sheet_Code) as '表單代碼' , RTRIM(Sheet_Name) as '表單名稱'   " & _
                        " From  PUB_Sheet " & _
                        " Where " & prmCondField & prmCondType & "'" & prmCondValue & "' And DC<>'Y' " & _
                        " Order By Sheet_Code "

            Case 107
                cmdStr = " Select RTRIM(Sheet_Code) as '表單代碼' , RTRIM(Sheet_Name) as '表單名稱'   " & _
                          " From  PUB_Sheet " & _
                          " Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And DC<>'Y' " & _
                          " Order By Sheet_Code "

            Case 8

                'If OtherQueryConditionDS.Tables.Contains("AllHospital") Then

                cmdStr = " Select RTRIM(A.Hospital_Code) as '醫院代碼' , RTRIM(A.Hospital_Name) as '醫院名稱'  ,  RTRIM(A.TEL1) as '電話一' , RTRIM(A.TEL2) as '電話二' , RTRIM(A.Mobile_Phone) as '行動電話' , RTRIM(A.FAX) as '傳真號碼',RTRIM(A.Address)               AS '地址' ,  Case A.Is_Exist When 'Y' then '是' When 'N' then '否' Else '不明' End    as '是否存在' " & _
                         " From  REF_Referral_Hospital  A " & _
                         " Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And A.DC<>'Y'  " & _
                         " Order By A.Common , A.Hospital_Code "

                'ElseIf OtherQueryConditionDS.Tables.Contains("AllIncludeDC") Then

                '    cmdStr = " Select RTRIM(A.Hospital_Code) as '醫院代碼' , RTRIM(A.Hospital_Name) as '醫院名稱'  , RTRIM(B.Code_Name) as '類別' , RTRIM(A.TEL1) as '電話一' , RTRIM(A.TEL2) as '電話二' , RTRIM(A.Mobile_Phone) as '行動電話' , RTRIM(A.FAX) as '傳真號碼' ,  Case A.Is_Exist When 'Y' then '是' When 'N' then '否' Else '不明' End    as '是否存在' , RTRIM(A.Is_Strategic_Alliance) as '策略聯盟' , RTRIM(A.Is_Health_Care) as '健保特約醫院' " & _
                '             " From  REF_Referral_Hospital  A , PUB_SYSCODE B " & _
                '             " Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And B.Type_Id='200' And A.Hospital_Type_Id=B.Code_ID   " & _
                '             " Order By A.Hospital_Code "

                'ElseIf OtherQueryConditionDS.Tables.Contains("SouthArea") Then

                '    cmdStr = " Select RTRIM(A.Hospital_Code) as '醫院代碼' , RTRIM(A.Hospital_Name) as '醫院名稱'  , RTRIM(B.Code_Name) as '類別' , RTRIM(A.TEL1) as '電話一' , RTRIM(A.TEL2) as '電話二' , RTRIM(A.Mobile_Phone) as '行動電話' , RTRIM(A.FAX) as '傳真號碼' ,  Case A.Is_Exist When 'Y' then '是' When 'N' then '否' Else '不明' End    as '是否存在' , RTRIM(A.Is_Strategic_Alliance) as '策略聯盟' , RTRIM(A.Is_Health_Care) as '健保特約醫院' " & _
                '             " From  REF_Referral_Hospital  A , PUB_SYSCODE B " & _
                '             " Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And B.Type_Id='200' And A.Hospital_Type_Id=B.Code_ID And Is_South_Area='Y' And A.DC<>'Y'  " & _
                '             " Order By A.Hospital_Code "

                'ElseIf OtherQueryConditionDS.Tables.Contains("NotSouthArea") Then


                '    cmdStr = " Select RTRIM(A.Hospital_Code) as '醫院代碼' , RTRIM(A.Hospital_Name) as '醫院名稱'  , RTRIM(B.Code_Name) as '類別' , RTRIM(A.TEL1) as '電話一' , RTRIM(A.TEL2) as '電話二' , RTRIM(A.Mobile_Phone) as '行動電話' , RTRIM(A.FAX) as '傳真號碼' ,  Case A.Is_Exist When 'Y' then '是' When 'N' then '否' Else '不明' End    as '是否存在' , RTRIM(A.Is_Strategic_Alliance) as '策略聯盟' , RTRIM(A.Is_Health_Care) as '健保特約醫院' " & _
                '             " From  REF_Referral_Hospital  A , PUB_SYSCODE B " & _
                '             " Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And B.Type_Id='200' And A.Hospital_Type_Id=B.Code_ID And Is_South_Area='N' And A.DC<>'Y'  " & _
                '             " Order By A.Hospital_Code "

                'ElseIf OtherQueryConditionDS.Tables.Contains("IsDialysisCenter") Then

                '    cmdStr = " Select RTRIM(A.Hospital_Code) as '醫院代碼' , RTRIM(A.Hospital_Name) as '醫院名稱'  , RTRIM(B.Code_Name) as '類別' , RTRIM(A.TEL1) as '電話一' , RTRIM(A.TEL2) as '電話二' , RTRIM(A.Mobile_Phone) as '行動電話' , RTRIM(A.FAX) as '傳真號碼' ,  Case A.Is_Exist When 'Y' then '是' When 'N' then '否' Else '不明' End    as '是否存在' , RTRIM(A.Is_Strategic_Alliance) as '策略聯盟' , RTRIM(A.Is_Health_Care) as '健保特約醫院' " & _
                '    " From  REF_Referral_Hospital  A , PUB_SYSCODE B " & _
                '    " Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And B.Type_Id='200' And A.Hospital_Type_Id=B.Code_ID And Is_Dialysis_Center='Y' And A.DC<>'Y'  " & _
                '    " Order By A.Hospital_Code "


                'End If


            Case 108
                cmdStr = " Select RTRIM(A.Hospital_Code) as '醫院代碼' , RTRIM(A.Hospital_Name) as '醫院名稱'  ,  RTRIM(A.TEL1) as '電話一' , RTRIM(A.TEL2) as '電話二' , RTRIM(A.Mobile_Phone) as '行動電話' , RTRIM(A.FAX) as '傳真號碼',RTRIM(A.Address)               AS '地址' ,  Case A.Is_Exist When 'Y' then '是' When 'N' then '否' Else '不明' End    as '是否存在'  From  REF_Referral_Hospital  A where Common='Y' "


            Case 9
                '2010-07-26 Modify by Alan
                'cmdStr = " Select RTRIM(A.Order_Code) as '醫令項目代碼' , RTRIM(A.Order_En_Name) as '英文名稱'  , RTRIM(A.Order_Name) as '中文名稱' , RTRIM(B.Code_Name) as '醫令類型'  " & _

                If prmCondField <> "Insu_Code" Then
                    cmdStr = " Select RTRIM(A.Order_Code) as '醫令項目代碼' , RTRIM(A.Order_En_Name) as '英文名稱'  , RTRIM(A.Order_Name) as '中文名稱' , " & _
                        " CASE RTRIM(A.Order_Type_Id) + ISNULL(RTRIM(A.Treatment_Type_Id),' ') " & _
                        "      When 'H3' THEN '檢驗檢查'" & _
                        "      When 'H4' THEN '檢驗檢查'" & _
                        "      When 'H ' THEN '治療處置'" & _
                        "      When 'D3' THEN '檢驗檢查'" & _
                        "      When 'D4' THEN '檢驗檢查'" & _
                        "      ELSE RTRIM(B.Code_Name)" & _
                        " End as '醫令類型'    " & _
                        " From      PUB_Order A , PUB_SYSCODE B " & _
                        "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'      And B.Type_Id='31' And A.Order_Type_Id=B.Code_ID   And A.DC<>'Y' And '" & _
                              pvtSysDate & "' >= A.Effect_Date And '" & _
                              pvtSysDate & "'<= A.End_Date  " & _
                        " Order By A.Order_Code "


                    cmdStr += " Select A.* " & _
                     " From      PUB_Order A , PUB_SYSCODE B " & _
                     "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'      And B.Type_Id='31' And A.Order_Type_Id=B.Code_ID   And A.DC<>'Y' And '" & _
                           pvtSysDate & "' >= A.Effect_Date And '" & _
                           pvtSysDate & "'<= A.End_Date  " & _
                     " Order By A.Order_Code "

                Else
                    'prmCondValue = prmCondValue.Replace("%", "")
                    'ds = pub.Ext_InsuCode_To_OrderCodeDs(prmCondValue.Trim, Now, True)
                    'If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                    '    ds.Tables(0).Columns(0).ColumnName = "健保碼"
                    '    ds.Tables(0).Columns(2).ColumnName = "醫令項目代碼"
                    '    ds.Tables(0).Columns(3).ColumnName = "英文名稱"
                    '    ds.Tables(0).Columns(4).ColumnName = "中文名稱"


                    'End If
                    'Return ds

                End If


                '多選
            Case 109
                cmdStr = " Select RTRIM(A.Order_Code) as '醫令項目代碼' , RTRIM(A.Order_En_Name) as '英文名稱'  , RTRIM(A.Order_Name) as '中文名稱' , RTRIM(B.Code_Name) as '醫令類型'  " & _
                          " From      PUB_Order A , PUB_SYSCODE B " & _
                          "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ")      And B.Type_Id='31' And A.Order_Type_Id=B.Code_ID   And A.DC<>'Y' And '" & _
                                pvtSysDate & "' >= A.Effect_Date And '" & _
                                pvtSysDate & "'<= A.End_Date  " & _
                          " Order By A.Order_Code "


            Case 10
                cmdStr = " Select RTRIM(Apparatus_Code) as '儀器代碼' , RTRIM(Apparatus_Name) as '儀器名稱'     " & _
                         " From      SCH_Apparatus  " & _
                         "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'   And  DC<>'Y'   " & _
                         " Order By Apparatus_Code "

            Case 11
                'cmdStr = " Select A.Reg_Date as '日期' , " & _
                '         " Case " & _
                '         "  When datepart(weekday,A.Reg_Date)=1 Then '星期日' " & _
                '         "  When datepart(weekday,A.Reg_Date)=2 Then '星期一' " & _
                '         "  When datepart(weekday,A.Reg_Date)=3 Then '星期二' " & _
                '         "  When datepart(weekday,A.Reg_Date)=4 Then '星期三' " & _
                '         "  When datepart(weekday,A.Reg_Date)=5 Then '星期四' " & _
                '         "  When datepart(weekday,A.Reg_Date)=6 Then '星期五' " & _
                '         "  When datepart(weekday,A.Reg_Date)=7 Then '星期六' " & _
                '         " End as '星期' , " & _
                '         "   RTRIM(D.Noon_Name) '午別' , RTRIM(B.Dept_Name) as '科別' , RTRIM(C.Code_Name) as '診別' ,  A.Noon_Code as 'Noon_Code' , A.Dept_Code  as 'Dept_Code', A.Section_Id  as 'Section_Id'  " & _
                '         " From      REG_Day_Schedule A , PUB_Department B , PUB_SYSCODE C  , REG_Noon_Config D " & _
                '         "  Where " & prmCondField & prmCondType & " '" & prmCondValue & "' And A.Dept_Code=B.Dept_Code And C.Type_Id='11' And A.Section_Id=C.Code_Id And A.Noon_Code=D.Noon_Code " & _
                '         " Order By A.Reg_Date "

                cmdStr = " Select A.Reg_Date as '日期' , " & _
                       " '      ' as '星期' , " & _
                       "   RTRIM(D.Noon_Name) '午別' , RTRIM(B.Dept_Name) as '科別' , RTRIM(C.Code_Name) as '診別' ,  A.Noon_Code as 'Noon_Code' , A.Dept_Code  as 'Dept_Code', A.Section_Id  as 'Section_Id'  " & _
                       " From      REG_Day_Schedule A , PUB_Department B , PUB_SYSCODE C  , REG_Noon_Config D " & _
                       "  Where " & prmCondField & prmCondType & " '" & prmCondValue & "' And A.Dept_Code=B.Dept_Code And C.Type_Id='11' And A.Section_Id=C.Code_Id And A.Noon_Code=D.Noon_Code " & _
                       " Order By A.Reg_Date "

            Case 12

                If OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Contains("IsCheckTime") AndAlso OtherQueryConditionDS.Tables("IsCheckTime").Rows.Count > 0 Then
                    IsCheckTime = OtherQueryConditionDS.Tables("IsCheckTime").Rows(0).Item("IsCheckTime").ToString.Trim
                End If

                cmdStr = " Select RTRIM(Employee_Code) as '員工代碼' , RTRIM(Employee_Name) as '姓名'   ,RTRIM(Employee_En_Name) as '英文姓名',RTRIM(Idno) as '身份證號',  Assume_Effect_Date  as '到職日期'  , '' as '離職日期' , Rtrim(Dept_Code) AS '科室' " & _
                         " From      PUB_Employee  " & _
                         "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "' "

                If IsCheckTime = "Y" Then
                    cmdStr += " And '" & pvtSysDate & "' >= Assume_Effect_Date "
                    cmdStr += " And '" & pvtSysDate & "'<= Assume_End_Date  "
                End If

                cmdStr += " Order By Employee_Code "

            Case 13

                setCond(prmCondField, prmCondValue)

                If OtherQueryConditionDS IsNot Nothing AndAlso IsDate(OtherQueryConditionDS.Tables(0).Rows(0).Item("baseDate")) Then
                    pvtSysDate = CDate(OtherQueryConditionDS.Tables(0).Rows(0).Item("baseDate")).ToShortDateString
                End If

                cmdStr = " Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                         "        RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級'  " & _
                         " From  PUB_Doctor A,PUB_Employee B,PUB_Department C " & _
                         " Where " & pvtCondField.Item(0) & "='" & pvtCondValue.Item(0) & "'  And " & _
                         "       " & pvtCondField.Item(1) & prmCondType & "'" & pvtCondValue.Item(1) & "' And " & _
                         "       A.Announce_Effect_Date <= '" & pvtSysDate & "' And " & _
                         "       A.Announce_End_Date >= '" & pvtSysDate & "' And " & _
                         "       B.Employee_Code = A.Employee_Code And " & _
                         "       C.Dept_Code = A.Dept_Code And " & _
                         "       C.DC <>'Y' " & _
                         " Order By A.Doctor_Code "


            Case 14

                setCond(prmCondField, prmCondValue)

                If OtherQueryConditionDS IsNot Nothing AndAlso IsDate(OtherQueryConditionDS.Tables(0).Rows(0).Item("baseDate")) Then
                    pvtSysDate = CDate(OtherQueryConditionDS.Tables(0).Rows(0).Item("baseDate")).ToShortDateString
                End If

                cmdStr = " Select RTRIM(A.Order_Code) as '醫令項目代碼' , RTRIM(A.Order_En_Name) as '英文名稱'  , RTRIM(A.Order_Name) as '中文名稱'  , A.*  " & _
                         " From      PUB_Order A   " & _
                         "  Where   A.DC<>'Y' And '" & _
                               pvtSysDate & "' >= A.Effect_Date And '" & _
                               pvtSysDate & "'<= A.End_Date  "


                If pvtCondValue.Item(0) <> "Nothing" Then
                    If prmCondType = "=" Then
                        If Not pvtCondValue.Item(0).ToString.Contains("︿") Then
                            cmdStr += "And " & pvtCondField.Item(0) & " = '" & pvtCondValue.Item(0) & "' "

                        End If

                    Else
                        If Not pvtCondValue.Item(0).ToString.Contains("︿") Then
                            cmdStr += "And " & pvtCondField.Item(0) & " like '" & pvtCondValue.Item(0) & "%' "
                        Else
                            cmdStr += "And " & pvtCondField.Item(0) & " like '%' "
                        End If

                    End If


                End If

                If Not pvtCondValue.Item(0).ToString.Contains("︿") Then


                    If pvtCondValue.Item(1) = "H" Then
                        cmdStr += "And  A.Order_Type_Id='H' And A.Treatment_Type_Id not in ('3' , '4')  "
                    ElseIf pvtCondValue.Item(1) = "D" Then
                        cmdStr += "And  ( A.Order_Type_Id='D' Or ( A.Order_Type_Id='H' And  A.Treatment_Type_Id not in ('3' , '4') ) ) "
                    Else
                        cmdStr += "And  A.Order_Type_Id='" & pvtCondValue.Item(1) & "' "

                    End If

                Else

                    If pvtCondValue.Item(0).ToString.Replace("︿", "").Trim = "H" Then
                        cmdStr += "And  A.Order_Type_Id='H' And A.Treatment_Type_Id not in ('3' , '4')  "
                    ElseIf pvtCondValue.Item(0).ToString.Replace("︿", "").Trim = "D" Then
                        cmdStr += "And  ( A.Order_Type_Id='D' Or ( A.Order_Type_Id='H' And  A.Treatment_Type_Id not in ('3' , '4') ) ) "
                    Else
                        cmdStr += "And  A.Order_Type_Id='" & pvtCondValue.Item(0).ToString.Replace("︿", "").Trim & "' "

                    End If


                End If

                cmdStr += " Order By A.Order_Code "

            Case 114

                setCond(prmCondField, prmCondValue)

                cmdStr = " Select RTRIM(A.Order_Code) as '醫令項目代碼' , RTRIM(A.Order_En_Name) as '英文名稱'  , RTRIM(A.Order_Name) as '中文名稱'    " & _
                         " From      PUB_Order A   " & _
                         "  Where   A.DC<>'Y' And '" & _
                               pvtSysDate & "' >= A.Effect_Date And '" & _
                               pvtSysDate & "'<= A.End_Date  "


                If pvtCondValue.Item(0) <> "Nothing" Then
                    If Not pvtCondValue.Item(0).ToString.Contains("︿") Then
                        cmdStr += "And " & pvtCondField.Item(0) & " like '" & pvtCondValue.Item(0) & "%' "
                    Else
                        cmdStr += "And " & pvtCondField.Item(0) & " like '%' "
                    End If
                End If

                If pvtCondValue.Item(1) = "H" Then
                    cmdStr += "And  A.Order_Type_Id='H' And A.Treatment_Type_Id not in ('3' , '4')  "
                ElseIf pvtCondValue.Item(1) = "D" Then
                    cmdStr += "And  ( A.Order_Type_Id='D' Or ( A.Order_Type_Id='H' And  A.Treatment_Type_Id not in ('3' , '4') ) ) "
                Else
                    cmdStr += "And  A.Order_Type_Id='" & pvtCondValue.Item(1) & "' "

                End If
                cmdStr += " Order By A.Order_Code "



            Case 15
                cmdStr = " Select RTRIM(A.Employee_Code) as '員工代碼' , RTRIM(A.Employee_Name) as '姓名'   ,  RTRIM(B.Pharmacist_Duty_Id) as '職務代碼' , RTRIM(B.Pharmacist_Duty_Name) as '職務名稱'  , A.Assume_Effect_Date  as '到職日期'  , A.Assume_End_Date as '離職日期' , RTRIM(A.Idno) as '證號'  " & _
                         " From      OPH_Pharmacist A Left Join  OPH_Pharmacist_Duty B On A.Pharmacist_Duty_Id=B.Pharmacist_Duty_Id And B.DC<>'Y'  " & _
                         "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'   And A.DC<>'Y'    " & _
                         " Order By A.Employee_Code "

            Case 16
                cmdStr = " Select RTRIM(Professional_Code) as '次專科代碼' , RTRIM(Professional_Name) as '次專科名稱'   , RTRIM(Professional_En_Name) as '次專科英文名稱'     " & _
                         " From      REG_Profess_Base  " & _
                         "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'   And DC<>'Y' " & _
                         " Order By Professional_Code "


            Case 17
                cmdStr = " Select RTRIM(Class_Code) as '代碼' , RTRIM(Class_En_Name) as '英文名稱'   , RTRIM(Class_Name) as  '中文名稱'   , RTRIM(Class_Memo) as '備註'  " & _
                         " From      OPH_Pharmacy_Class  " & _
                         "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'   " & _
                         " Order By Class_Code "


            Case 18 ' OPH_Code Type_Id='19'

                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '中文名稱'   , RTRIM(Code_En_Name) as  '英文名稱'   , RTRIM(Code_Memo) as '備註'  " & _
                       " From      OPH_Code  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And Type_Id='19' And Dc<>'Y' " & _
                        " Order By Code_Id , Sort_Value "


                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '中文名稱'   , RTRIM(Code_En_Name) as  '英文名稱'   , RTRIM(Code_Memo) as '備註'  " & _
                           " From      OPH_Code  " & _
                           "  Where   Type_Id='19' And Dc<>'Y'   " & _
                           " Order By Code_Id , Sort_Value "

                    Else
                        Dim arrStr() As String = Split(prmCondValue, ",")
                        Dim strCondValue As String = ""
                        For i = 0 To arrStr.Length - 1
                            strCondValue = strCondValue & "'" & arrStr(i).ToString.Trim & "',"
                        Next
                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '中文名稱'   , RTRIM(Code_En_Name) as  '英文名稱'   , RTRIM(Code_Memo) as '備註'  " & _
                           " From      OPH_Code  " & _
                           "  Where " & prmCondField & prmCondType & " (" & strCondValue.Substring(0, strCondValue.Length - 1) & ") And Type_Id='19' And Dc<>'Y'   " & _
                           " Order By Code_Id , Sort_Value "
                    End If
                End If

            Case 303 ' OPH_Code Type_Id='303'

                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '中文名稱'   , RTRIM(Code_En_Name) as  '英文名稱'   , RTRIM(Code_Memo) as '備註' " & _
                       " From      OPH_Code  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And Type_Id='303' And Dc<>'Y' " & _
                        " Order By Code_Id , Sort_Value "


                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '中文名稱'   , RTRIM(Code_En_Name) as  '英文名稱'   , RTRIM(Code_Memo) as '備註'  " & _
                           " From      OPH_Code  " & _
                           "  Where   Type_Id='303' And Dc<>'Y'   " & _
                           " Order By Code_Id , Sort_Value "

                    Else


                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '中文名稱'   , RTRIM(Code_En_Name) as  '英文名稱'   , RTRIM(Code_Memo) as '備註'  " & _
                           " From      OPH_Code  " & _
                           "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And Type_Id='303' And Dc<>'Y'   " & _
                           " Order By Code_Id , Sort_Value "
                    End If
                End If

            Case 191


                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Pharmacy_12_Code) as '藥品碼' , RTRIM(Order_Code) as '醫令項目代碼'  , RTRIM(Scientific_Name) as '學名'  ,RTRIM(Trade_Name) as '商品名'  , RTRIM(Chinese_Name) as '中文名稱' ,    RTRIM(Alias_Name) as '俗名' ,  RTRIM(Insu_Code) as '健保碼' ,  RTRIM(License) as '衛署字號' ,  RTRIM(License) as '衛署字號' , RTRIM(Class_Code) as '藥理代碼'  " & _
                       " From  OPH_Pharmacy_Base     " & _
                      "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And   Dc<>'Y' " & _
                       " Order By Class_Code "


                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Pharmacy_12_Code) as '藥品碼' , RTRIM(Order_Code) as '醫令項目代碼'  , RTRIM(Scientific_Name) as '學名'   ,RTRIM(Trade_Name) as '商品名' , RTRIM(Chinese_Name) as '中文名稱' , RTRIM(Class_Code) as '藥理分類' ,RTRIM(Alias_Name) as '俗名'  , RTRIM(Insu_Code) as '健保碼' ,  RTRIM(License) as '衛署字號' , RTRIM(Class_Code) as '藥理代碼' " & _
                       " From  OPH_Pharmacy_Base     " & _
                          "  Where    Dc<>'Y'   " & _
                          " Order By Class_Code "

                    Else

                        cmdStr = " Select RTRIM(Pharmacy_12_Code) as '藥品碼' , RTRIM(Order_Code) as '醫令項目代碼'  , RTRIM(Scientific_Name) as '學名'   ,RTRIM(Trade_Name) as '商品名' , RTRIM(Chinese_Name) as '中文名稱' , RTRIM(Class_Code) as '藥理分類'  ,RTRIM(Alias_Name) as '俗名'  , RTRIM(Insu_Code) as '健保碼' ,  RTRIM(License) as '衛署字號' , RTRIM(Class_Code) as '藥理代碼' " & _
                      " From  OPH_Pharmacy_Base     " & _
                         "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And   Dc<>'Y'   " & _
                         " Order By Class_Code "
                    End If
                End If


            Case 201

                If OtherQueryConditionDS Is Nothing Then


                    If prmCondValue.Contains("%") Then

                        cmdStr = " Select RTRIM(B.Rule_Reason_Code) as '代碼' , RTRIM(A.Phrase_Name) as '名稱'  " & _
                           " From  OPH_Phrase A , OPH_Rule_Reason B     " & _
                         "  Where A.Phrase_Code=B.Rule_Reason_Code    And A.Phrase_Code_Id='01' " & _
                          " Order By A.Phrase_Code "

                    Else

                        If prmCondValue.Trim.Replace("%", "") = "" Then

                            cmdStr = " Select RTRIM(B.Rule_Reason_Code) as '代碼' , RTRIM(A.Phrase_Name) as '名稱'  " & _
                            " From  OPH_Phrase A , OPH_Rule_Reason B     " & _
                              "  Where   A.Phrase_Code=B.Rule_Reason_Code    And A.Phrase_Code_Id='01' " & _
                              " Order By A.Phrase_Code  "

                        Else


                            cmdStr = " Select RTRIM(B.Rule_Reason_Code) as '代碼' , RTRIM(A.Phrase_Name) as '名稱'  " & _
                              " From  OPH_Phrase A , OPH_Rule_Reason B     " & _
                               "  Where A.Phrase_Code=B.Rule_Reason_Code    And A.Phrase_Code_Id='01' " & _
                               " Order By A.Phrase_Code "
                        End If
                    End If

                Else
                    '指定Phrase_Code_Id
                    Dim Phrase_Code_Id As String = OtherQueryConditionDS.Tables(0).TableName.Trim

                    If prmCondValue.Contains("%") Then

                        cmdStr = " Select RTRIM(B.Rule_Reason_Code) as '代碼' , RTRIM(A.Phrase_Name) as '名稱'  " & _
                           " From  OPH_Phrase A , OPH_Rule_Reason B     " & _
                         "  Where A.Phrase_Code=B.Rule_Reason_Code    And A.Phrase_Code_Id='" & Phrase_Code_Id & "' " & _
                          " Order By A.Phrase_Code "

                    Else

                        If prmCondValue.Trim.Replace("%", "") = "" Then

                            cmdStr = " Select RTRIM(B.Rule_Reason_Code) as '代碼' , RTRIM(A.Phrase_Name) as '名稱'  " & _
                            " From  OPH_Phrase A , OPH_Rule_Reason B     " & _
                              "  Where   A.Phrase_Code=B.Rule_Reason_Code    And A.Phrase_Code_Id='" & Phrase_Code_Id & "' " & _
                              " Order By A.Phrase_Code  "

                        Else


                            cmdStr = " Select RTRIM(B.Rule_Reason_Code) as '代碼' , RTRIM(A.Phrase_Name) as '名稱'  " & _
                              " From  OPH_Phrase A , OPH_Rule_Reason B     " & _
                               "  Where A.Phrase_Code=B.Rule_Reason_Code    And A.Phrase_Code_Id='" & Phrase_Code_Id & "' " & _
                               " Order By A.Phrase_Code "
                        End If
                    End If

                End If

            Case 21 '牙科約診
                cmdStr = " Select RTRIM(A.Order_Code) as '醫令項目代碼' , RTRIM(A.Order_En_Name) as '英文名稱'  , RTRIM(A.Order_Name) as '中文名稱' , RTRIM(B.Code_Name) as '醫令類型'  " & _
                         " From      PUB_Order A , PUB_SYSCODE B " & _
                         "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'      And B.Type_Id='31' And A.Order_Type_Id=B.Code_ID   And A.DC<>'Y' And A.Treatment_Type_Id='2' And '" & _
                               Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                               Now().ToString("yyyy/M/d") & "'<= A.End_Date  " & _
                         " Order By A.Order_Code "



            Case 221 ' 

                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱' " & _
                       " From      PUB_SYSCODE  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And Type_Id='626' And  DC<>'Y' Order By Code_Id "



                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'   " & _
                           " From      PUB_SYSCODE    " & _
                           "  Where   Type_Id='626' And  DC<>'Y' Order By Code_Id   "


                    Else

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'  " & _
                           " From      PUB_SYSCODE  " & _
                           "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And Type_Id='626' And  DC<>'Y' Order By Code_Id    "

                    End If
                End If



            Case 231 ' 

                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱' " & _
                       " From      PUB_SYSCODE  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And Type_Id='628' And  DC<>'Y' Order By Code_Id "



                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'   " & _
                           " From      PUB_SYSCODE    " & _
                           "  Where   Type_Id='628' And  DC<>'Y' Order By Code_Id   "


                    Else

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'  " & _
                           " From      PUB_SYSCODE  " & _
                           "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And Type_Id='628' And  DC<>'Y' Order By Code_Id    "

                    End If
                End If


            Case 241 ' 
                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱' " & _
                       " From      PUB_SYSCODE  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And Type_Id='666' And  DC<>'Y' Order By Code_Id "



                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'   " & _
                           " From      PUB_SYSCODE    " & _
                           "  Where   Type_Id='666' And  DC<>'Y' Order By Code_Id   "


                    Else

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'  " & _
                           " From      PUB_SYSCODE  " & _
                           "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And Type_Id='666' And  DC<>'Y' Order By Code_Id    "

                    End If
                End If

            Case 251 ' 
                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱' " & _
                       " From      PUB_SYSCODE  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And Type_Id='631' And  DC<>'Y' Order By Code_Id "



                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'   " & _
                           " From      PUB_SYSCODE    " & _
                           "  Where   Type_Id='631' And  DC<>'Y' Order By Code_Id   "


                    Else

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'  " & _
                           " From      PUB_SYSCODE  " & _
                           "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And Type_Id='631' And  DC<>'Y' Order By Code_Id    "

                    End If
                End If

            Case 261 ' 
                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱' " & _
                       " From      PUB_SYSCODE  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And Type_Id='632' And  DC<>'Y' Order By Code_Id "



                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'   " & _
                           " From      PUB_SYSCODE    " & _
                           "  Where   Type_Id='632' And  DC<>'Y' Order By Code_Id   "


                    Else

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'  " & _
                           " From      PUB_SYSCODE  " & _
                           "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And Type_Id='632' And  DC<>'Y' Order By Code_Id    "

                    End If
                End If

            Case 27 ' 
                cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'   " & _
                         " From    PUB_SYSCODE " & _
                         "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "' And Type_Id='98' And  DC<>'Y' Order By Code_Id "


            Case 28 ' 轉介病人檔 REF_Referral_Patient
                cmdStr = " Select RTRIM(A.Idno) as '身分證號' , RTRIM(A.Chart_No) as '病歷號'  ,RTRIM(A.Patient_Name) '姓名' , RTRIM(A.Treatment_Date) '看診日期' ,  RTRIM(D.Noon_Name) '午別', RTRIM(E.Dept_Name) as '科別' , RTRIM(F.Code_Name) as '診別' , " & _
                         " RTRIM(A.Hospital_Code) as '轉介醫院代碼' ,  RTRIM(G.Hospital_Name) as '轉介醫院名稱' , RTRIM(A.Referral_Doctor_Name) as '轉介醫師姓名' , " & _
                         " RTRIM(B.Code_Name) as '看診類別' , RTRIM(C.Code_Name) as '轉入原因' , RTRIM(H.Employee_Code) as '醫師代號' , RTRIM(H.Employee_Name) as '醫師姓名' , RTRIM(A.Ref_Patient_Sn) as '轉介病人檔序號'   " & _
                         " From    REF_Referral_Patient A Left Join PUB_Syscode B On  B.Type_Id='201' And A.Treatment_Type_Id=B.Code_Id " & _
                         "                                Left Join PUB_Syscode C On  C.Type_Id='202' And A.Refferral_Reason_Id=C.Code_Id  " & _
                         "                                Left Join REG_Noon_Config D On A.Noon_Code=D.Noon_Code  " & _
                         "                                Left Join PUB_Department E On A.Dept_Code=E.Dept_Code  " & _
                         "                                Left Join PUB_Syscode F On F.Type_Id='11' And A.Section_Id=F.Code_Id " & _
                         "                                Left Join REF_Referral_Hospital G On A.Hospital_Code=G.Hospital_Code  " & _
                         "                                Left Join PUB_Employee H  On  A.Doctor_Code=H.Employee_Code And '" & Now().ToString("yyyy/M/d") & "' >= H.Assume_Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= H.Assume_End_Date  " & _
                         " Where " & prmCondField & prmCondType & "'" & prmCondValue & "' And    A.Cancel<>'Y' Order By A.Idno , A.Chart_No  "


            Case 29 ' 轉出病人檔 REF_Referral_Out_Patient


                cmdStr = " Select RTRIM(A.Idno) as '身分證號' , RTRIM(A.Chart_No) as '病歷號'  ,RTRIM(A.Patient_Name) '姓名' ,RTRIM(A.Referral_Out_Date) '轉出日期' ,  RTRIM(D.Noon_Name) '午別', RTRIM(E.Dept_Name) as '科別' , RTRIM(F.Code_Name) as '診別' , " & _
                         " RTRIM(A.Hospital_Code) as '轉介醫院代碼' ,  RTRIM(G.Hospital_Name) as '轉介醫院名稱'   ," & _
                         " RTRIM(B.Code_Name) as '轉出原因' , RTRIM(C.Code_Name) as '轉出來源' , RTRIM(H.Employee_Code) as '醫師代號' , RTRIM(H.Employee_Name) as '醫師姓名' , RTRIM(A.Ref_Out_Patient_Sn) as '轉出病人檔序號'   " & _
                         " From    REF_Referral_Out_Patient A Left Join PUB_Syscode B On  B.Type_Id='203' And A.Referral_Out_Reason_Id=B.Code_Id " & _
                         "                                    Left Join PUB_Syscode C On  C.Type_Id='205' And A.Referral_Out_Source_Id=C.Code_Id  " & _
                         "                                    Left Join REG_Noon_Config D On A.Noon_Code=D.Noon_Code  " & _
                         "                                    Left Join PUB_Department E On A.Dept_Code=E.Dept_Code  " & _
                         "                                    Left Join PUB_Syscode F On F.Type_Id='11' And A.Section_Id=F.Code_Id " & _
                         "                                    Left Join REF_Referral_Hospital G On A.Hospital_Code=G.Hospital_Code  " & _
                         "                                    Left Join PUB_Employee H  On  A.Doctor_Code=H.Employee_Code And '" & Now().ToString("yyyy/M/d") & "' >= H.Assume_Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= H.Assume_End_Date  " & _
                         " Where " & prmCondField & prmCondType & "'" & prmCondValue & "' And    A.Cancel<>'Y' Order By A.Idno , A.Chart_No  "


            Case 30
                cmdStr = " Select RTRIM(Pharmacy_12_Code) as '藥品碼' , RTRIM(Order_Code) as '醫令項目代碼'  , RTRIM(Scientific_Name) as '學名'   ,RTRIM(Trade_Name) as '商品名' , RTRIM(Chinese_Name) as '中文名稱' , RTRIM(Class_Code) as '藥理分類'  ,RTRIM(Alias_Name) as '俗名'  , RTRIM(Insu_Code) as '健保碼' ,  RTRIM(License) as '衛署字號'  , RTRIM(Pharmacy_Name) as '藥袋藥名'   " & _
                         " From      OPH_Pharmacy_Base  " & _
                         "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'   And Dc<>'Y'   " & _
                         " Order By Pharmacy_12_Code ,Order_Code "


            Case 311 ' 
                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Dept_Code) as '代碼' , RTRIM(Dept_Name) as '名稱' " & _
                       " From      PUB_Department  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And    DC<>'Y' Order By Dept_Code "



                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Dept_Code) as '代碼' , RTRIM(Dept_Name) as '名稱'   " & _
                           " From      PUB_Department    " & _
                           "  Where     DC<>'Y' Order By Dept_Code   "


                    Else

                        cmdStr = " Select RTRIM(Dept_Code) as '代碼' , RTRIM(Dept_Name) as '名稱'  " & _
                           " From      PUB_Department  " & _
                           "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And    DC<>'Y' Order By Dept_Code    "

                    End If
                End If


            Case 321 ' 
                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Station_no) as '代碼' , RTRIM(Station_name) as '名稱' " & _
                       " From      INP_Station  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'    Order By Station_no "



                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Station_no) as '代碼' , RTRIM(Station_name) as '名稱'   " & _
                           " From      INP_Station    " & _
                           "  Where   1=1 Order By Station_no   "


                    Else

                        cmdStr = " Select RTRIM(Station_no) as '代碼' , RTRIM(Station_name) as '名稱'  " & _
                           " From      INP_Station  " & _
                           "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ")   Order By Station_no    "

                    End If
                End If


            Case 33

                If prmCondField <> "Insu_Code︿A.Order_Type_Id" Then


                    setCond(prmCondField, prmCondValue)

                    cmdStr = " Select RTRIM(A.Order_Code) as '醫令項目代碼' , RTRIM(A.Order_En_Name) as '英文名稱'  , RTRIM(A.Order_Name) as '中文名稱'  , A.*  " & _
                             " From      PUB_Order A   " & _
                             "  Where   A.DC<>'Y' And '" & _
                                   Now().ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                                   Now().ToString("yyyy/M/d") & "'<= A.End_Date  "


                    If pvtCondValue.Item(0) <> "Nothing" Then
                        If prmCondType = "=" Then
                            If Not pvtCondValue.Item(0).ToString.Contains("︿") Then
                                cmdStr += "And " & pvtCondField.Item(0) & " = '" & pvtCondValue.Item(0) & "' "

                            End If

                        Else
                            If Not pvtCondValue.Item(0).ToString.Contains("︿") Then
                                cmdStr += "And " & pvtCondField.Item(0) & " like '" & pvtCondValue.Item(0) & "%' "
                            Else
                                cmdStr += "And " & pvtCondField.Item(0) & " like '%' "
                            End If

                        End If


                    End If

                    If Not pvtCondValue.Item(0).ToString.Contains("︿") Then

                        cmdStr += "And  A.Order_Type_Id='" & pvtCondValue.Item(1) & "' "

                    Else

                        cmdStr += "And  A.Order_Type_Id='" & pvtCondValue.Item(0).ToString.Replace("︿", "").Trim & "' "

                    End If

                    cmdStr += " Order By A.Order_Code "

                Else

                    If prmCondValue.Contains("︿") Then
                        prmCondValue = Split(prmCondValue, "︿")(0).Replace("%", "").Trim

                    Else
                        prmCondValue = prmCondValue.Replace("%", "")

                    End If

                    ds = pub.Ext_InsuCode_To_OrderCodeDs(prmCondValue.Trim, Now, True)
                    If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                        ds.Tables(0).Columns(0).ColumnName = "健保碼"
                        ds.Tables(0).Columns(2).ColumnName = "醫令項目代碼"
                        ds.Tables(0).Columns(3).ColumnName = "英文名稱"
                        ds.Tables(0).Columns(4).ColumnName = "中文名稱"
                    End If

                    Return ds

                End If

            Case 34

                If prmCondField <> "Insu_Code" Then

                    setCond(prmCondField, prmCondValue)

                    cmdStr = " Select RTRIM(A.Order_Code) as '醫令項目代碼' ,RTRIM(A.Order_Name) as '藥囑藥名' , RTRIM(A.Scientific_Name) as '學名'  , RTRIM(A.Trade_Name) as '商品名' , " & _
                             "        RTRIM(A.Alias_Name) as '俗名'  ,  A.*  " & _
                             " From      OPH_Pharmacy_Base A   " & _
                             "  Where   A.DC<>'Y'   "


                    If pvtCondValue.Item(0) <> "Nothing" Then
                        If prmCondType = "=" Then
                            If Not pvtCondValue.Item(0).ToString.Contains("︿") Then
                                cmdStr += "And " & pvtCondField.Item(0) & " = '" & pvtCondValue.Item(0) & "' "

                            End If

                        Else
                            If Not pvtCondValue.Item(0).ToString.Contains("︿") Then
                                cmdStr += "And " & pvtCondField.Item(0) & " like '" & pvtCondValue.Item(0) & "%' "
                            Else
                                cmdStr += "And " & pvtCondField.Item(0) & " like '%' "
                            End If

                        End If


                    End If

                    'If Not pvtCondValue.Item(0).ToString.Contains("︿") Then

                    '    'cmdStr += "And  A.Order_Type_Id='" & pvtCondValue.Item(1) & "' "

                    'Else

                    '    cmdStr += "And  A.Order_Type_Id='" & pvtCondValue.Item(0).ToString.Replace("︿", "").Trim & "' "

                    'End If

                    cmdStr += " Order By A.Order_Code "


                Else

                    'prmCondValue = prmCondValue.Replace("%", "")
                    'ds = pub.Ext_InsuCode_To_OrderCodeDs(prmCondValue.Trim, Now, True)
                    'If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                    '    ds.Tables(0).Columns(0).ColumnName = "健保碼"
                    '    ds.Tables(0).Columns(2).ColumnName = "醫令項目代碼"
                    '    ds.Tables(0).Columns(3).ColumnName = "英文名稱"
                    '    ds.Tables(0).Columns(4).ColumnName = "中文名稱"


                    'End If
                    Return ds

                End If


            Case 351 ' 
                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱' " & _
                       " From      PUB_SYSCODE  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And Type_Id='29' And  DC<>'Y' Order By Code_Id "



                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'   " & _
                           " From      PUB_SYSCODE    " & _
                           "  Where   Type_Id='29' And  DC<>'Y' Order By Code_Id   "


                    Else

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'  " & _
                           " From      PUB_SYSCODE  " & _
                           "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And Type_Id='29' And  DC<>'Y' Order By Code_Id    "

                    End If
                End If

            Case 36
                'cmdStr = " Select A.Reg_Date as '日期' , " & _
                '         " Case " & _
                '         "  When datepart(weekday,A.Reg_Date)=1 Then '星期日' " & _
                '         "  When datepart(weekday,A.Reg_Date)=2 Then '星期一' " & _
                '         "  When datepart(weekday,A.Reg_Date)=3 Then '星期二' " & _
                '         "  When datepart(weekday,A.Reg_Date)=4 Then '星期三' " & _
                '         "  When datepart(weekday,A.Reg_Date)=5 Then '星期四' " & _
                '         "  When datepart(weekday,A.Reg_Date)=6 Then '星期五' " & _
                '         "  When datepart(weekday,A.Reg_Date)=7 Then '星期六' " & _
                '         " End as '星期' , " & _
                '         "   RTRIM(D.Noon_Name) '午別' , RTRIM(B.Dept_Name) as '科別' , RTRIM(C.Code_Name) as '診別' ,  A.Noon_Code as 'Noon_Code' , A.Dept_Code  as 'Dept_Code', A.Section_Id  as 'Section_Id'  " & _
                '         " From      REG_Day_Schedule A , PUB_Department B , PUB_SYSCODE C  , REG_Noon_Config D " & _
                '         "  Where " & prmCondField & prmCondType & " '" & prmCondValue & "' And A.Dept_Code=B.Dept_Code And C.Type_Id='11' And A.Section_Id=C.Code_Id And A.Noon_Code=D.Noon_Code " & _
                '         " Order By A.Reg_Date "

                cmdStr = " Select  " & _
                       " A.Week_Id as '星期' , " & _
                       "   RTRIM(D.Noon_Name) '午別' , RTRIM(B.Dept_Name) as '科別' , RTRIM(C.Code_Name) as '診別' ,  A.Noon_Code as 'Noon_Code' , A.Dept_Code  as 'Dept_Code', A.Section_Id  as 'Section_Id'  " & _
                       " From      REG_Week_Schedule A , PUB_Department B , PUB_SYSCODE C  , REG_Noon_Config D " & _
                       "  Where " & prmCondField & prmCondType & " '" & prmCondValue & "' And A.Dept_Code=B.Dept_Code And C.Type_Id='11' And A.Section_Id=C.Code_Id And A.Noon_Code=D.Noon_Code " & _
                       " Order By A.Week_Id "
            Case 37
                cmdStr = " Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                         "       RTRIM(C.Dept_Code)+ ' ' +  RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級' , " & _
                         "       RTRIM(B.Idno) as '身分證號' , RTRIM(B.Employee_En_Name) as '醫師英文姓名' " & _
                         " From  PUB_Doctor A,PUB_Employee B,PUB_Department C " & _
                         " Where " & prmCondField & prmCondType & "'" & prmCondValue & "' And " & _
                         "      A.Announce_Effect_Date <= '" & pvtSysDate & "' And " & _
                         "      A.Announce_End_Date >= '" & pvtSysDate & "' And " & _
                         "      B.Employee_Code = A.Employee_Code And '" & Now().ToString("yyyy/M/d") & "' >= B.Assume_Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= B.Assume_End_Date  And " & _
                         "      C.Dept_Code = A.Dept_Code And " & _
                         "      C.DC <>'Y' and A.Level_Id='V' " & _
                         " Order By A.Doctor_Code "

            Case 38
                cmdStr = " Select Distinct RTRIM(Contract_Code) as '合約機關代碼', RTRIM(Contract_Name) as '合約機關名稱' " & _
                         " From  PUB_Contract  " & _
                         " Where " & prmCondField & prmCondType & "'" & prmCondValue & "' And " & _
                         "      DC <>'Y' "

            Case 391 ' 
                If prmCondValue.Contains("%") Then

                    cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱' " & _
                       " From      PUB_SYSCODE  " & _
                       "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And Type_Id='629' And  DC<>'Y' Order By Code_Id "



                Else

                    If prmCondValue.Trim.Replace("%", "") = "" Then

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'   " & _
                           " From      PUB_SYSCODE    " & _
                           "  Where   Type_Id='629' And  DC<>'Y' Order By Code_Id   "


                    Else

                        cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '名稱'  " & _
                           " From      PUB_SYSCODE  " & _
                           "  Where " & prmCondField & prmCondType & " (" & prmCondValue & ") And Type_Id='629' And  DC<>'Y' Order By Code_Id    "

                    End If
                End If

            Case 40

                setCond(prmCondField, prmCondValue)

                cmdStr = " Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                         "       RTRIM(C.Dept_Code)+ ' ' +  RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級' , " & _
                         "       RTRIM(B.Idno) as '身分證號' , RTRIM(B.Employee_En_Name) as '醫師英文姓名' " & _
                         " From  PUB_Doctor A Left Join PUB_Department C  On C.Dept_Code = A.Dept_Code And C.DC <>'Y' , PUB_Employee B" & _
                         " Where " & pvtCondField.Item(0) & prmCondType & " '" & pvtCondValue.Item(0) & "' And " & _
                         "      B.Employee_Code = A.Employee_Code And '" & pvtCondValue.Item(1) & _
                         "' >= B.Assume_Effect_Date And '" & pvtCondValue.Item(1) & "'<= B.Assume_End_Date  " & _
                         " Order By A.Doctor_Code "



            Case 41
                cmdStr = " Select RTRIM(Dept_Code) as '科別代碼' , RTRIM(Emg_Dept_Name) as '科別中文名稱'  , RTRIM(Emg_Dept_En_Name) as '科別英文名稱'   " & _
                         " From  PUB_Department " & _
                         " Where " & prmCondField & prmCondType & "'" & prmCondValue & "'   And DC<>'Y' And   Is_Emg_Dept='Y' " & _
                         " Order By Dept_Code "

            Case 42

                cmdStr = " Select RTRIM(A.Employee_Code) as '員工編號' , RTRIM(A.Employee_Name) as '姓名'   ,RTRIM(B.Code_Name) as '職稱',RTRIM(A.Dept_Code) as '科室代號',RTRIM(C.Dept_Name) as '科室名稱' ,  A.Assume_Effect_Date  as '到職日期'  , '' as '離職日期'  " & _
                         " From      PUB_Employee A Left Join PUB_Department C  On C.Dept_Code = A.Dept_Code And C.DC <>'Y' , PUB_Syscode B  " & _
                         "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  And B.Type_Id='1101' And A.Professal_Kind_Id  = B.Code_Id  And B.DC<>'Y'  And   '" & _
                                pvtSysDate & "' >= A.Assume_Effect_Date And '" & _
                                pvtSysDate & "'<= A.Assume_End_Date  "

                If OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Contains("PUBEmployeeProfessalKindId") Then
                    cmdStr += " And  A.Professal_Kind_Id ='" & OtherQueryConditionDS.Tables("PUBEmployeeProfessalKindId").Rows(0).Item("Professal_Kind_Id").ToString.Trim & "' "
                End If

                cmdStr += " Order By A.Employee_Code "

            Case 43

                'Dim DeptBO As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance

                'Dim DeptDS As DataSet = DeptBO.queryByDeptCodeOnly(prmCondValue.Substring(0, 2))

                'Dim SectDS As DataSet = pub.queryPUBSysCodebyTypeId("11")
                'Dim SectionName = ""
                'If SectDS.Tables(0).Select("Code_Id='" & prmCondValue.Substring(2, 2) & "'").Count > 0 Then
                '    SectionName = SectDS.Tables(0).Select("Code_Id='" & prmCondValue.Substring(2, 2) & "'")(0).Item("Code_Name")
                'End If


                'Dim ReturnDS As New DataSet

                'ReturnDS.Tables.Add()
                'ReturnDS.Tables(0).Columns.Add("Detp_Code")
                'ReturnDS.Tables(0).Columns.Add("Section_Id")
                'ReturnDS.Tables(0).Columns.Add("DeptAndSectionName")
                'ReturnDS.Tables(0).Columns.Add("DeptName")
                'ReturnDS.Tables(0).Columns.Add("SectionName")

                'If DeptDS.Tables(0).Rows.Count > 0 AndAlso SectionName <> "" Then
                '    ReturnDS.Tables(0).Rows.Add()
                '    ReturnDS.Tables(0).Rows(0).Item("DeptName") = DeptDS.Tables(0).Rows(0).Item("Dept_Name").ToString.Trim
                '    ReturnDS.Tables(0).Rows(0).Item("SectionName") = SectionName
                '    ReturnDS.Tables(0).Rows(0).Item("DeptAndSectionName") = DeptDS.Tables(0).Rows(0).Item("Dept_Name").ToString.Trim & SectionName

                '    ReturnDS.Tables(0).Rows(0).Item("Detp_Code") = prmCondValue.Substring(0, 2).Trim
                '    ReturnDS.Tables(0).Rows(0).Item("Section_Id") = prmCondValue.Substring(2, 2).Trim

                'End If

                'Return ReturnDS


                Dim varname1 As New System.Text.StringBuilder
                varname1.Append("SELECT Dept_Code      AS 'DeptName', " & vbCrLf)
                varname1.Append("       Section_Id     AS 'SectionName', " & vbCrLf)
                varname1.Append("       Dept_Sect_Name AS 'DeptAndSectionName', " & vbCrLf)
                varname1.Append("       Dept_Code, " & vbCrLf)
                varname1.Append("       Section_Id " & vbCrLf)
                varname1.Append("FROM   PUB_Dept_Sect " & vbCrLf)
                varname1.Append("WHERE  Dept_Code = '" & prmCondValue.Substring(0, 2).Trim & "' " & vbCrLf)
                varname1.Append("       AND Section_Id = '" & prmCondValue.Substring(2, 2).Trim & "' " & vbCrLf)
                varname1.Append("ORDER  BY Dept_Code, " & vbCrLf)
                varname1.Append("          Section_Id")

                cmdStr = varname1.ToString

            Case 50

                If prmCondField = "Icd9_Code" Then
                    Dim varname1 As New System.Text.StringBuilder
                    varname1.Append("SELECT Distinct A.Icd_Code as 'Icd9', " & vbCrLf)
                    varname1.Append("       C.Icd_Code as 'Icd10', " & vbCrLf)
                    varname1.Append("	   C.Disease_En_Name as '診斷英文名稱', " & vbCrLf)
                    varname1.Append("	   C.Disease_Name as '診斷中文名稱' , " & vbCrLf)
                    varname1.Append("	   RTRIM(D.Code_Name) as '診斷類型', " & vbCrLf)
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
                    varname1.Append(" FROM   PUB_Disease A " & vbCrLf)
                    varname1.Append(" Left Join PUB_Disease_ICD10_Mapping B  on A.Icd_Code =B.ICD_Code And A.Disease_Type_Id = B.Disease_Type_Id " & vbCrLf)
                    varname1.Append(" Left Join PUB_Disease_ICD10 C on B.ICD10_Code =C.Icd_Code And B.Disease_Type_Id = C.Disease_Type_Id  And  C.DC <> 'Y' " & vbCrLf)
                    varname1.Append(" Left Join PUB_Syscode D on  D.Type_Id='33' And A.Disease_Type_Id=D.Code_ID " & vbCrLf)
                    varname1.Append(" WHERE  A.DC <> 'Y' AND A.Icd_Code LIKE '" & prmCondValue & "%' ")
                    cmdStr = varname1.ToString
                    cmdStr += " And '" & Now().ToString("yyyy/M/d") & "' >=A.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= A.End_Date "
                    cmdStr += " Order By A.Icd_Code"

                ElseIf prmCondField = "Icd10_Code" Then

                    Dim varname1 As New System.Text.StringBuilder
                    varname1.Append("SELECT Distinct A.Icd_Code as 'Icd9', " & vbCrLf)
                    varname1.Append("       C.Icd_Code as 'Icd10', " & vbCrLf)
                    varname1.Append("	   C.Disease_En_Name as '診斷英文名稱', " & vbCrLf)
                    varname1.Append("	   C.Disease_Name as '診斷中文名稱' , " & vbCrLf)
                    varname1.Append("	   RTRIM(D.Code_Name) as '診斷類型', " & vbCrLf)
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
                    varname1.Append(" Left Join PUB_Syscode D on  D.Type_Id='33' And C.Disease_Type_Id=D.Code_ID " & vbCrLf)
                    varname1.Append(" WHERE   C.DC <> 'Y' AND C.Icd_Code LIKE '" & prmCondValue & "%' ")

                    cmdStr = varname1.ToString

                    cmdStr += "And '" & Now().ToString("yyyy/M/d") & "' >=C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date "

                    cmdStr += " Order By C.Icd_Code"

                ElseIf prmCondField = "Icd10_Name" Then

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
                    varname1.Append(" Left Join  PUB_Disease_ICD10_Mapping B  on B.ICD10_Code =C.Icd_Code And B.Disease_Type_Id = C.Disease_Type_Id  " & vbCrLf)
                    varname1.Append(" Left Join  PUB_Disease A  On A.Icd_Code =B.ICD_Code And A.Disease_Type_Id = B.Disease_Type_Id  And  A.DC <> 'Y' " & vbCrLf)
                    varname1.Append(" Left Join PUB_Syscode D on  D.Type_Id='33' And C.Disease_Type_Id=D.Code_ID " & vbCrLf)
                    varname1.Append(" WHERE   C.DC <> 'Y' AND C.Disease_En_Name LIKE '%" & prmCondValue & "%' ")

                    cmdStr = varname1.ToString

                    cmdStr += "And '" & Now().ToString("yyyy/M/d") & "' >=C.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= C.End_Date "

                    cmdStr += " Order By C.Icd_Code"


                End If
            Case 51
                '
                cmdStr = " Select RTRIM(Insu_Dept_Code) as '科別代碼' , RTRIM(Insu_Dept_Code_Name) as '科別中文名稱'  , RTRIM(Insu_Dept_Code_En_Name) as '科別英文名稱' " & _
                       " From  PUB_Insu_Dept " & _
                       " Where " & prmCondField & prmCondType & "'" & prmCondValue & "'  "

                If Not (OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Contains("CheckDc") AndAlso OtherQueryConditionDS.Tables("CheckDc").Rows(0).Item("IsCheckDc").ToString.Trim = "N") Then
                    cmdStr += " And DC<>'Y'   "
                End If

                cmdStr += " Order By Insu_Dept_Code "

            Case 52
                '地區
                Dim varname1 As New System.Text.StringBuilder
                'varname1.Append(" SELECT distinct PUB_Area_Code_N.Area_Code as '地區代碼', " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_N.Area_Name as '地區名稱', " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_N.County_Code, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.Postal_Code, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.Postal_Name, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.Town_Name, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.County_Name, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Gov_County_Code, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Gov_County_Name, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Dist_Code , " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Dist_Name " & vbCrLf)
                'varname1.Append(" FROM   PUB_Postal_Area, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_N, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Gov_Area " & vbCrLf)
                'varname1.Append(" WHERE  PUB_Postal_Area.Area_Code = PUB_Area_Code_N.Orig_Area_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Area.Postal_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Gov_Area.Postal_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Postal_Gov_Area.Dist_Code = PUB_Area_Code_Gov.Dist_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Area_Code_Gov.Gov_County_Code ='64' " & vbCrLf)
                'varname1.Append("       AND " & prmCondField & prmCondType & "'" & prmCondValue & "'  " & vbCrLf)

                'varname1.Append(" UNION ALL " & vbCrLf)

                varname1.Append(" SELECT distinct PUB_Area_Code_N.Area_Code as '地區代碼', " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.Area_Name as '地區名稱', " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.County_Code, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Postal_Code, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Postal_Name, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Town_Name, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.County_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Gov_County_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Gov_County_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Dist_Code , " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Dist_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.Sort_Value " & vbCrLf)
                varname1.Append(" FROM   PUB_Postal_Area, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov, " & vbCrLf)
                varname1.Append("       PUB_Postal_Gov_Area " & vbCrLf)
                varname1.Append(" WHERE  PUB_Postal_Area.Area_Code = PUB_Area_Code_N.Orig_Area_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Area.Postal_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Gov_Area.Postal_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Gov_Area.Dist_Code = PUB_Area_Code_Gov.Dist_Code " & vbCrLf)
                'varname1.Append("	    AND PUB_Area_Code_Gov.Gov_County_Code <>'64'")
                If prmCondValue.Replace("%", "") <> "" Then
                    varname1.Append("       AND " & prmCondField & prmCondType & "'" & prmCondValue & "'  " & vbCrLf)
                End If
                varname1.Append(" ORDER  BY PUB_Area_Code_N.Sort_Value, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_N.Area_Code, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_N.Area_Name, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_N.County_Code, " & vbCrLf)
                varname1.Append("          PUB_Postal_Code.Postal_Code, " & vbCrLf)
                varname1.Append("          PUB_Postal_Code.Postal_Name, " & vbCrLf)
                varname1.Append("          PUB_Postal_Code.Town_Name, " & vbCrLf)
                varname1.Append("          PUB_Postal_Code.County_Name, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_Gov.Gov_County_Code, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_Gov.Gov_County_Name, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_Gov.Dist_Code, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_Gov.Dist_Name")

                cmdStr = varname1.ToString

            Case 53
                '里
                Dim Area_Code As String = ""
                If OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Count > 0 Then
                    Area_Code = OtherQueryConditionDS.Tables(0).TableName
                End If
                Dim varname1 As New System.Text.StringBuilder
                varname1.Append(" SELECT  PUB_Area_Code_Gov.Vil_Name as '里名稱', " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.Area_Name as '地區名稱',  " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.Area_Code as '地區代碼', " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Vil_Code as '里代碼', " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.County_Code, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Postal_Code, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Postal_Name, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Town_Name, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.County_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Gov_County_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Gov_County_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Dist_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Dist_Name " & vbCrLf)
                varname1.Append(" FROM   PUB_Postal_Area, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov, " & vbCrLf)
                varname1.Append("       PUB_Postal_Gov_Area " & vbCrLf)
                varname1.Append(" WHERE  PUB_Postal_Area.Area_Code = PUB_Area_Code_N.Orig_Area_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Area.Postal_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Gov_Area.Postal_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Gov_Area.Dist_Code = PUB_Area_Code_Gov.Dist_Code " & vbCrLf)

                If prmCondValue.Replace("%", "") <> "" Then
                    varname1.Append("       AND " & prmCondField & prmCondType & "'" & prmCondValue & "'  " & vbCrLf)
                End If

                If Area_Code <> "" Then
                    varname1.Append("   AND PUB_Area_Code_N.Area_Code ='" & Area_Code & "' " & vbCrLf)
                End If

                varname1.Append(" ORDER  BY PUB_Area_Code_N.Sort_Value , PUB_Area_Code_N.Area_Code")

                cmdStr = varname1.ToString
            Case 54
                '健保碼Insu_Name

                Dim varname1 As New System.Text.StringBuilder
                varname1.Append(" SELECT  PUB_NHI_Code.Insu_Code as '健保碼', " & vbCrLf)
                varname1.Append("         PUB_NHI_Code.Insu_Name as '健保碼中文名稱',  " & vbCrLf)
                varname1.Append("         PUB_NHI_Code.Insu_En_Name as '健保碼英文名稱'  " & vbCrLf)
                varname1.Append(" FROM   PUB_NHI_Code " & vbCrLf)
                varname1.Append(" WHERE  '" & Now.ToString("yyyy/MM/dd") & "' between Effect_Date and End_Date " & vbCrLf)
                If prmCondValue.Replace("%", "") <> "" Then
                    varname1.Append("   AND PUB_NHI_Code.Insu_Code ='" & prmCondValue & "'  " & vbCrLf)
                End If

                varname1.Append("       AND Dc <> 'Y' " & vbCrLf)



                varname1.Append(" ORDER  BY PUB_NHI_Code.Effect_Date")

                cmdStr = varname1.ToString
            Case 60

                Dim Content As New System.Text.StringBuilder
                Content.AppendLine("select Drg_Code as 'TW_DRGs碼' , Drg_En_Name as 'TW_DRGs英文名稱' , Drg_Name as 'TW_DRGs名稱' ")
                Content.AppendLine("from DRG_Drg_Base")
                Content.AppendLine("WHERE  " & prmCondField & prmCondType & "'" & prmCondValue & "'")
                Content.AppendLine("AND Effect_Date <=  '" & pvtSysDate & "'")
                Content.AppendLine("AND End_Date >=  '" & pvtSysDate & "'")
                Content.AppendLine("AND DC <> 'Y'")
                Content.AppendLine("Order By Drg_Code")

                cmdStr = Content.ToString

            Case 61

                Dim Content As New System.Text.StringBuilder
                Content.AppendLine("select MDC_Code as '主要疾病類別MDC碼' , MDC_En_Name as '主要疾病類別MDC英文名稱' , MDC_Name as '主要疾病類別MDC名稱' from DRG_Mdc_Base ")
                Content.AppendLine("WHERE  " & prmCondField & prmCondType & "'" & prmCondValue & "'")
                Content.AppendLine("AND Effect_Date <=  '" & pvtSysDate & "'")
                Content.AppendLine("AND End_Date >=  '" & pvtSysDate & "'")
                Content.AppendLine("Order By MDC_Code")

                cmdStr = Content.ToString
            Case 62

                Dim Content As New System.Text.StringBuilder
                Content.AppendLine("SELECT  Station_No as '護理站代碼'")
                Content.AppendLine("      ,Station_Name as '護理站名稱'")
                Content.AppendLine("      ,Floor as '樓層'")
                Content.AppendLine("      ,Consumption_Unit as '消耗單位'")
                Content.AppendLine("      ,Consumption_Name as '消耗單位名稱'")
                Content.AppendLine("  FROM PUB_Station")
                Content.AppendLine("  where Dc='N'")
                Content.AppendLine("    And  " & prmCondField & prmCondType & "'" & prmCondValue & "'")
                If OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Count > 0 AndAlso OtherQueryConditionDS.Tables(0).Rows.Count > 0 AndAlso OtherQueryConditionDS.Tables("RegionKind").Rows(0).Item("Region_Kind").ToString.Trim.Replace("'", "") <> "" Then
                    Content.AppendLine(" And Region_Kind In(" & OtherQueryConditionDS.Tables("RegionKind").Rows(0).Item("Region_Kind").ToString.Trim & ")")
                End If
                cmdStr = Content.ToString

            Case 63

                Dim Content As New System.Text.StringBuilder
                Content.AppendLine("SELECT Consumpation_Unit as '消耗單位代碼'")
                Content.AppendLine("      ,Consumpation_Name as '消耗單位名稱'")
                Content.AppendLine("  FROM STA_Consumpation")
                Content.AppendLine("  where Dc='N'")
                If OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Contains("RegionKind") AndAlso OtherQueryConditionDS.Tables("RegionKind").Rows.Count > 0 AndAlso Replace(OtherQueryConditionDS.Tables("RegionKind").Rows(0).Item("Region_Kind").ToString.Trim, "'", "") <> "" Then
                    Content.AppendLine("    And Consumpation_Unit in (" & OtherQueryConditionDS.Tables("RegionKind").Rows(0).Item("Region_Kind").ToString.Trim & ")")
                Else
                    Content.AppendLine("    And  " & prmCondField & prmCondType & "'" & prmCondValue & "'")
                End If
                cmdStr = Content.ToString
            Case 70
                '
                cmdStr = " Select BacOrgan_Code '代碼' ,BacOrgan_Name '名稱'  From LAB_BacOrgan Where DC<>'Y'　 " & _
                       " And " & prmCondField & prmCondType & "'" & prmCondValue & "'  "

                cmdStr += " Order By BacOrgan_Code "

            Case 98
                '所有醫師 (不限時間)
                cmdStr = " Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                       "       RTRIM(C.Dept_Code)+ ' ' +  RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級' , " & _
                       "       RTRIM(B.Idno) as '身分證號' , RTRIM(B.Employee_En_Name) as '醫師英文姓名' , B.Assume_Effect_Date as  '員工生效起日' , B.Assume_End_Date as '員工生效迄日' , A.Announce_Effect_Date as '醫師生效起日' , A.Announce_End_Date as '醫師生效迄日' " & _
                       " From  PUB_Doctor A Left Join PUB_Department C  On C.Dept_Code = A.Dept_Code And C.DC <>'Y' , PUB_Employee B " & _
                       " Where " & prmCondField & prmCondType & "'" & prmCondValue & "' And " & _
                       "      B.Employee_Code = A.Employee_Code  " & _
                       " Order By A.Doctor_Code  , B.Assume_Effect_Date DESC "


            Case 99
                '給OHD申報用
                cmdStr = " Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                       "       RTRIM(C.Dept_Code)+ ' ' +  RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級' , " & _
                       "       RTRIM(B.Idno) as '身分證號' , RTRIM(B.Employee_En_Name) as '醫師英文姓名' " & _
                       " From  PUB_Doctor A Left Join PUB_Department C  On C.Dept_Code = A.Dept_Code And C.DC <>'Y' , PUB_Employee B" & _
                       " Where " & prmCondField & prmCondType & "'" & prmCondValue & "' And " & _
                       "      A.Announce_Effect_Date <= '" & pvtSysDate & "' And " & _
                       "      A.Announce_End_Date >= dateadd(year,-1,'" & pvtSysDate & "') And " & _
                       "      B.Employee_Code = A.Employee_Code And '" & pvtSysDate & "' >= B.Assume_Effect_Date And dateadd(year,-1,'" & pvtSysDate & "') <= B.Assume_End_Date  " & _
                       " Order By A.Doctor_Code "

            Case 500
                cmdStr = " Select Item_Code as '檢驗代碼' , Item_Name as '檢驗名稱' , Sheet_Code as '檢驗單代碼'  From LAB_Item  "
                cmdStr += "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "' "

            Case 501
                '員工檔-角色
                If OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Contains("IsCheckTime") AndAlso OtherQueryConditionDS.Tables("IsCheckTime").Rows.Count > 0 Then
                    IsCheckTime = OtherQueryConditionDS.Tables("IsCheckTime").Rows(0).Item("IsCheckTime").ToString.Trim
                End If

                If OtherQueryConditionDS IsNot Nothing AndAlso OtherQueryConditionDS.Tables.Contains("uclRoles") AndAlso OtherQueryConditionDS.Tables("uclRoles").Rows.Count > 0 Then
                    uclRoles = OtherQueryConditionDS.Tables("uclRoles").Rows(0).Item("uclRoles").ToString.Trim
                End If

                cmdStr = " Select RTRIM(A.Employee_Code) as '員工代碼' , RTRIM(A.Employee_Name) as '姓名'   ,RTRIM(A.Employee_En_Name) as '英文姓名',RTRIM(A.Idno) as '身份證號',  A.Assume_Effect_Date  as '到職日期'  , '' as '離職日期' , Rtrim(A.Dept_Code) AS '科室' "
                cmdStr += " From      PUB_Employee A "

                If uclRoles.Trim <> "" Then
                    cmdStr += " Inner Join ARM_Roles B On A.Employee_Code =B.Employee_Code And B.Role in (" & uclRoles.Trim & ") "
                End If

                cmdStr += "  Where " & prmCondField & prmCondType & "'" & prmCondValue & "' "

                If IsCheckTime = "Y" Then
                    cmdStr += " And '" & pvtSysDate & "' >= A.Assume_Effect_Date "
                    cmdStr += " And '" & pvtSysDate & "'<= A.Assume_End_Date  "
                End If

                cmdStr += " Order By A.Employee_Code "


            Case 502 'OPH_Code19
                'cmdStr = " Select A.Order_Code as '代碼' , A.Order_Name as '名稱' ,B.Property_Id as '屬性'  , A.Pharmacy_12_Code  From  OPH_Pharmacy_Base A ,OPH_Property B Where A.Pharmacy_12_Code =B.Pharmacy_12_Code And " & prmCondField & prmCondType & "'" & prmCondValue & "' And A.DC<>'Y' Order By A.Order_Code ,B.Property_Id  "
                cmdStr = " Select RTRIM(Code_Id) as '代碼' , RTRIM(Code_Name) as '中文名稱'   , RTRIM(Code_En_Name) as  '英文名稱'   , RTRIM(Code_Memo) as '備註'  From      OPH_Code    Where  Type_Id='19' And Dc<>'Y'  Order By Code_Id , Sort_Value "

        End Select

        'ds = New DataSet("resultDB")
        Try
            conn.Open()
            SqlCmd = New SqlCommand(cmdStr, conn)
            da = New SqlDataAdapter(New SqlCommand(cmdStr, conn))
            ''da.FillSchema(ds, SchemaType.Source, "resulttable")
            'da.Fill(ds.Tables("resulttable"))

            ds = New DataSet()
            da.Fill(ds)
            'da.FillSchema(ds, SchemaType.Mapped)

            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            conn.Close()
        End Try
    End Function

    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    Private Sub setCond(ByVal prmCondField As String, ByVal prmCondValue As String)
        Dim pvtCutStr = ""
        Dim pvtCount As Integer

        Do
            pvtCount = prmCondField.IndexOf("︿")
            If (pvtCount > 0) Then
                pvtCutStr = prmCondField.Substring(0, pvtCount)
                prmCondField = prmCondField.Substring(pvtCount + 1)
            Else
                pvtCutStr = prmCondField
            End If
            pvtCondField.Add(pvtCutStr)
        Loop While pvtCount > 0

        Do
            pvtCount = prmCondValue.IndexOf("︿")
            If (pvtCount > 0) Then
                pvtCutStr = prmCondValue.Substring(0, pvtCount)
                prmCondValue = prmCondValue.Substring(pvtCount + 1)
            Else
                pvtCutStr = prmCondValue
            End If
            pvtCondValue.Add(pvtCutStr)
        Loop While pvtCount > 0

    End Sub

End Class