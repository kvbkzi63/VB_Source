Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP

''' <summary>
''' 程式說明：
''' 開發人員：
''' 開發日期：
''' </summary>
''' <修改註記>
''' </修改註記>
Public Class UCLOmOFavorBO_E1

    Private tableName1 = "OMO_Favor"
    Private tableName = "OMO_Favor"

    Public Shared ReadOnly Property getInstance()
        Get
            Return New UCLOmOFavorBO_E1
        End Get
    End Property

    ''' <summary>
    ''' Get SQL connection.
    ''' </summary>
    ''' <returns>sql connection</returns>
    ''' <remarks></remarks>
    Private Function getConnection() As SqlConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function

    Private Function getEISDBConnection() As SqlConnection
        Return SQLConnFactory.getInstance.getEisDBSqlConn
    End Function

    Private Function getPUBDBConnection() As SqlConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    Private Function getPCSDBConnection() As SqlConnection
        Return SQLConnFactory.getInstance.getPcsDBSqlConn
    End Function

    ''' <summary>
    ''' 常用資料查詢
    ''' </summary>
    ''' <param name="queryData">查詢參數</param>
    ''' <returns>常用醫令初始化資料</returns>
    ''' <remarks></remarks>
    Public Function queryOMOOrderFavorInit(ByVal queryData As DataSet) As DataSet

        Dim pvtFavorTypeId, pvtDoctorCode, pvtDeptCode, pvtUserDeptCode, pvtChartNo, pvtOutpaientSn, pvtDrugType, pvtSubDrugType, pvtSourceType, pvtFavorUseType, pvtIsChoiceDcOrder As String
        Dim dsCateDoc, dsCateDept, dsDept, dsSpec, dsPart, dsAllergy, dsSheetDept, dsSheetDeptData, dsPharmacyClass, _
            dsInitialData, dsOpMenu, dsInpCategory, dsInpStation, dsChoiceDcOrder As New DataSet

        pvtSourceType = ""
        pvtFavorTypeId = ""
        pvtDoctorCode = ""
        pvtDeptCode = ""
        pvtUserDeptCode = ""
        pvtChartNo = ""
        pvtDrugType = ""
        pvtSubDrugType = ""
        pvtFavorUseType = ""
        pvtOutpaientSn = ""
        pvtIsChoiceDcOrder = "N"

        Try
            '取得傳入參數
            If queryData.Tables(0).Columns.Count > 7 Then
                pvtSourceType = queryData.Tables(0).Rows(0).Item("Source_Type").ToString.Trim
            Else
                pvtSourceType = "O"
            End If
            pvtFavorTypeId = queryData.Tables(0).Rows(0).Item("Favor_Type_Id").ToString.Trim
            pvtDoctorCode = queryData.Tables(0).Rows(0).Item("Doctor_Code").ToString.Trim
            pvtDeptCode = queryData.Tables(0).Rows(0).Item("Dept_Code").ToString.Trim

            If queryData.Tables(0).Columns.Contains("User_Dept_Code") Then
                pvtUserDeptCode = queryData.Tables(0).Rows(0).Item("User_Dept_Code").ToString.Trim
            End If

            pvtChartNo = queryData.Tables(0).Rows(0).Item("Chart_No").ToString.Trim
            pvtDrugType = queryData.Tables(0).Rows(0).Item("Drug_Type").ToString.Trim
            pvtSubDrugType = queryData.Tables(0).Rows(0).Item("Sub_Drug_Type").ToString.Trim
            pvtFavorUseType = queryData.Tables(0).Rows(0).Item("FavorUse_Type").ToString.Trim

            '11.取得選取醫令註記(因查詢一令會用到此註記，故提前至最前面來，但在回傳的位置索引不變)
            dsChoiceDcOrder = queryPUBConfigChoiceDcOrder()
            If dsChoiceDcOrder IsNot Nothing AndAlso dsChoiceDcOrder.Tables IsNot Nothing AndAlso dsChoiceDcOrder.Tables(0).Rows.Count > 0 Then
                pvtIsChoiceDcOrder = dsChoiceDcOrder.Tables(0).Rows(0).Item("Config_Value").ToString.Trim
            End If


            '0.取得醫師常用分類
            dsCateDoc = queryOMOFavorCategory2(pvtSourceType, _
                                               "1", _
                                               pvtFavorTypeId, _
                                               pvtDoctorCode, _
                                               pvtIsChoiceDcOrder)
            If dsCateDoc.Tables.Count > 0 Then
                dsCateDoc.Tables(0).TableName = "Doctor_Category"
            End If

            '1.取得科常用分類
            Dim pvtIsUserDept As Boolean = False
            dsCateDept = queryOMOFavorCategory2(pvtSourceType, _
                                                "2", _
                                                pvtFavorTypeId, _
                                                pvtDeptCode, _
                                                pvtIsChoiceDcOrder)
            If dsCateDept.Tables.Count > 0 And dsCateDept.Tables(0).Rows.Count > 0 Then
                dsCateDept.Tables(0).TableName = "Dept_Category"

            ElseIf pvtUserDeptCode <> "" Then
                '若醫療科別查不到資料，再另以行政科別查詢
                dsCateDept = queryOMOFavorCategory2(pvtSourceType, _
                                                "2", _
                                                pvtFavorTypeId, _
                                                pvtUserDeptCode, _
                                                pvtIsChoiceDcOrder)
                If dsCateDept.Tables.Count > 0 And dsCateDept.Tables(0).Rows.Count > 0 Then
                    pvtIsUserDept = True
                    dsCateDept.Tables(0).TableName = "Dept_Category"
                End If

            End If

            '2.取得細分科
            dsDept = queryPUBDepartmentAll_D2(pvtSourceType)

            If dsDept.Tables.Count > 0 Then
                If pvtIsUserDept Then
                    Dim pvtIndex As Integer
                    pvtIndex = dsDept.Tables(0).Rows.Count
                    dsDept.Tables(0).Rows.Add()
                    dsDept.Tables(0).NewRow()
                    dsDept.Tables(0).Rows(pvtIndex).Item("Dept_Code") = pvtUserDeptCode
                    dsDept.Tables(0).Rows(pvtIndex).Item("Dept_Name") = pvtUserDeptCode
                    dsDept.Tables(0).Rows(pvtIndex).Item("Dept_En_Name") = pvtUserDeptCode
                End If
                dsDept.Tables(0).TableName = "PUB_Department"
            End If

            '3.取得檢體
            dsSpec = queryPUBSysCodeAll2(pvtSourceType, "46")
            If dsSpec.Tables.Count > 0 Then
                dsSpec.Tables(0).TableName = "PUB_Spec"
            End If

            '4.取得部位
            dsPart = queryPUBBodySiteMainSiteData()
            If dsPart.Tables.Count > 0 Then
                dsPart.Tables(0).TableName = "PUB_Body_Site"
            End If

            '5.取得病患過敏藥物
            dsAllergy = queryPUBPatientAllergyByCond(pvtChartNo)
            If dsAllergy.Tables.Count > 0 Then
                dsAllergy.Tables(0).TableName = "PUB_Patient_Allergy"
            End If

            '6.取得全院藥品分類
            dsPharmacyClass = queryOPHPharmacyClassByCodeLen()
            If dsPharmacyClass.Tables.Count > 0 Then
                dsPharmacyClass.Tables(0).TableName = "OPH_Pharmacy_Class"
            End If

            '7.取得醫師常用資料，若找不到再進一步查詢科常用資料
            Dim PharmacyQueryFlag() As String = {"Y", "Y", "Y", "Y", "N", "", "N", pvtSubDrugType}

            If pvtDrugType.Equals("3") AndAlso PharmacyQueryFlag(7).Length > 0 Then
                If PharmacyQueryFlag(7).Equals("2") OrElse PharmacyQueryFlag(7).Equals("3") Then
                    pvtDrugType = "1"
                End If
                pvtDeptCode = "PHCT"
            End If

            Dim pvtFavorCategory As String = ""

            If pvtSourceType.Equals("E") AndAlso pvtFavorTypeId.Equals("A") Then
                pvtFavorCategory = "常用診斷"
            End If

            If pvtSourceType <> "O" OrElse pvtFavorTypeId <> "H" Then
                dsInitialData = queryOMOOrderFavorByCond3(pvtSourceType, "1", pvtFavorTypeId, pvtDoctorCode, pvtFavorCategory, "", "", pvtDrugType, PharmacyQueryFlag, pvtChartNo, pvtOutpaientSn, pvtIsChoiceDcOrder)
                If dsInitialData.Tables(0).Rows.Count = 0 Then
                    dsInitialData = queryOMOOrderFavorByCond3(pvtSourceType, "2", pvtFavorTypeId, pvtDeptCode, pvtFavorCategory, "", "", pvtDrugType, PharmacyQueryFlag, pvtChartNo, pvtOutpaientSn, pvtIsChoiceDcOrder)
                    If dsInitialData.Tables(0).Rows.Count = 0 Then
                        dsInitialData = queryOMOOrderFavorByCond3(pvtSourceType, "2", pvtFavorTypeId, pvtUserDeptCode, pvtFavorCategory, "", "", pvtDrugType, PharmacyQueryFlag, pvtChartNo, pvtOutpaientSn, pvtIsChoiceDcOrder)
                    End If
                    '設定常用類別註記,For前端UI進行相關設定
                    dsInitialData.Tables.Add("FavorData")
                    dsInitialData.Tables(1).Columns.Add("Favor_Type_Id")
                    dsInitialData.Tables(1).Rows.Add()
                    If pvtIsUserDept Then
                        dsInitialData.Tables(1).Rows(0).Item("Favor_Type_Id") = "3"
                    Else
                        dsInitialData.Tables(1).Rows(0).Item("Favor_Type_Id") = "2"
                    End If
                Else
                    '設定常用類別註記,For前端UI進行相關設定
                    dsInitialData.Tables.Add("FavorData")
                    dsInitialData.Tables(1).Columns.Add("Favor_Type_Id")
                    dsInitialData.Tables(1).Rows.Add()
                    dsInitialData.Tables(1).Rows(0).Item("Favor_Type_Id") = "1"
                End If
            Else
                dsInitialData = queryOMOOrderFavorSheetDept2(pvtSourceType, pvtFavorTypeId)
            End If

            '8.取得急診手術分類 2011-09-13 Add By Alan
            If pvtSourceType = "E" Then
                dsOpMenu = queryEMOOpMenuData()
            End If

            '9.取得住院全院護理套裝分類 2012-06-04 Add By Alan
            If (pvtSourceType = "I" AndAlso pvtFavorTypeId = "D") OrElse _
               (pvtFavorUseType = "2" AndAlso pvtFavorTypeId = "D") Then
                dsInpCategory = queryInpCategoryData()
            End If

            '10.取得住院全院護理套裝護理站 2012-06-04 Add By Alan
            If (pvtSourceType = "I" AndAlso pvtFavorTypeId = "D") OrElse _
               (pvtFavorUseType = "2" AndAlso pvtFavorTypeId = "D") Then
                dsInpStation = queryINPStationData
            End If


            Using ds As DataSet = New DataSet
                ds.Merge(dsCateDoc)
                ds.Merge(dsCateDept)
                ds.Merge(dsDept)
                ds.Merge(dsSpec)
                ds.Merge(dsPart)
                ds.Merge(dsAllergy)
                ds.Merge(dsPharmacyClass)
                ds.Merge(dsInitialData)
                ds.Merge(dsOpMenu)
                ds.Merge(dsInpCategory)
                ds.Merge(dsInpStation)
                ds.Merge(dsChoiceDcOrder)
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            If (dsCateDoc IsNot Nothing) Then dsCateDoc.Dispose()
            If (dsCateDept IsNot Nothing) Then dsCateDept.Dispose()
            If (dsDept IsNot Nothing) Then dsDept.Dispose()
            If (dsSpec IsNot Nothing) Then dsSpec.Dispose()
            If (dsPart IsNot Nothing) Then dsPart.Dispose()
            If (dsAllergy IsNot Nothing) Then dsAllergy.Dispose()
            If (dsPharmacyClass IsNot Nothing) Then dsPharmacyClass.Dispose()
            If (dsInitialData IsNot Nothing) Then dsInitialData.Dispose()
            If (dsOpMenu IsNot Nothing) Then dsOpMenu.Dispose()
            If (dsInpCategory IsNot Nothing) Then dsInpCategory.Dispose()
            If (dsInpStation IsNot Nothing) Then dsInpStation.Dispose()
            If (dsChoiceDcOrder IsNot Nothing) Then dsChoiceDcOrder.Dispose()
        End Try
    End Function

    ''' <summary>
    ''' 取得常用醫令分類
    ''' </summary>    
    Public Function queryOMOFavorCategory2(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, ByVal IsChoiceDcOrder As String) As DataSet
        Dim sqlString As New System.Text.StringBuilder
        Dim pvtMergeSQL As String = ""

        Select Case SourceType
            Case "O"
                pvtMergeSQL = "A.Is_Opd = 'Y'"
            Case "E"
                pvtMergeSQL = "A.Is_Emg = 'Y'"
            Case "I"
                pvtMergeSQL = "A.Is_Ipd = 'Y'"
        End Select

        If FavorTypeId.Equals("H") Then
            If IsChoiceDcOrder <> "Y" Then
                sqlString.Append("SELECT DISTINCT A.Favor_Category, A.Category_View_Seq" & _
                             " FROM OMO_Favor A WITH(NOLOCK)" & _
                            " INNER JOIN PUB_Order B WITH(NOLOCK) ON B.Order_Code=A.Order_Code" & _
                                                               " AND B.Effect_Date <= @Now" & _
                                                               " AND B.End_Date >= @Now" & _
                                                               " AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y'))" & _
                                                               " AND B.Treatment_Type_Id IN ('3','4')" & _
                            " WHERE " & pvtMergeSQL)
            Else
                sqlString.Append("SELECT DISTINCT A.Favor_Category, A.Category_View_Seq" & _
                             " FROM OMO_Favor A WITH(NOLOCK)" & _
                            " INNER JOIN PUB_Order B WITH(NOLOCK) ON B.Order_Code=A.Order_Code" & _
                                                               " AND B.Treatment_Type_Id IN ('3','4') AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y')) " & _
                            " WHERE " & pvtMergeSQL)
            End If
           

            If FavorId.Trim.Length > 0 Then
                sqlString.Append(" AND A.Favor_Id = @Favor_Id")
            End If

            If FavorTypeId.Trim.Length > 0 Then
                sqlString.Append(" AND A.Favor_Type_Id = @Favor_Type_Id")
            End If

            If DoctorDeptCode.Trim.Length > 0 Then
                sqlString.Append(" AND A.Doctor_Dept_Code = @Doctor_Dept_Code")
            End If

        ElseIf FavorTypeId.Equals("D") Then
            If IsChoiceDcOrder <> "Y" Then
                sqlString.Append("SELECT DISTINCT A.Favor_Category, A.Category_View_Seq" & _
                              " FROM OMO_Favor A WITH(NOLOCK)" & _
                             " INNER JOIN PUB_Order B WITH(NOLOCK) ON B.Order_Code = A.Order_Code" & _
                                                                " AND B.Effect_Date <= @Now" & _
                                                                " AND B.End_Date >= @Now" & _
                                                                " AND B.Dc = 'N'" & _
                                                                " AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y')) " & _
                                                                " AND (B.Treatment_Type_Id NOT IN ('3','4')" & _
                                                                 " OR B.Treatment_Type_Id IS NULL" & _
                                                                 " OR B.Treatment_Type_Id = '')" & _
                             " WHERE " & pvtMergeSQL)

            Else
                sqlString.Append("SELECT DISTINCT A.Favor_Category, A.Category_View_Seq" & _
                              " FROM OMO_Favor A WITH(NOLOCK)" & _
                             " INNER JOIN PUB_Order B WITH(NOLOCK) ON B.Order_Code = A.Order_Code" & _
                                                                " AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y')) " & _
                                                                " AND (B.Treatment_Type_Id NOT IN ('3','4')" & _
                                                                 " OR B.Treatment_Type_Id IS NULL" & _
                                                                 " OR B.Treatment_Type_Id = '')" & _
                             " WHERE " & pvtMergeSQL)

            End If
            

            If FavorId.Trim.Length > 0 Then
                sqlString.Append(" AND A.Favor_Id = @Favor_Id")
            End If
            If FavorTypeId.Trim.Length > 0 Then
                If SourceType.Equals("O") Then
                    sqlString.Append(" AND (A.Favor_Type_Id IN ('D','H')")
                Else
                    sqlString.Append(" AND (A.Favor_Type_Id IN ('D','H','T')")
                End If
                sqlString.Append(" OR (A.Favor_Type_Id = 'J' AND A.Doctor_Dept_Code IN ('32','33','35','39','70')))" & _
                                " AND A.Favor_Category <> '開刀房手術'")
            End If

            If DoctorDeptCode.Trim.Length > 0 Then
                sqlString.Append(" AND A.Doctor_Dept_Code = @Doctor_Dept_Code")
            End If

        Else
            sqlString.Append("SELECT DISTINCT A.Favor_Category, A.Category_View_Seq" & _
                              " FROM OMO_Favor A WITH(NOLOCK)" & _
                             " WHERE " & pvtMergeSQL)
            If FavorId.ToString.Length > 0 Then
                sqlString.Append(" AND A.Favor_Id = @Favor_Id")
            End If
            If FavorTypeId.ToString.Length > 0 Then
                sqlString.Append(" AND A.Favor_Type_Id = @Favor_Type_Id")
            End If
            If DoctorDeptCode.ToString.Length > 0 Then
                sqlString.Append(" AND A.Doctor_Dept_Code = @Doctor_Dept_Code")
            End If

        End If

        sqlString.Append(" ORDER By A.Category_View_Seq, A.Favor_Category ")

        Try
            Using conn As SqlConnection = getConnection()
                Using Command As SqlCommand = conn.CreateCommand

                    Command.CommandText = sqlString.ToString

                    Command.Parameters.AddWithValue("@Favor_Id", FavorId)
                    Command.Parameters.AddWithValue("@Favor_Type_Id", FavorTypeId)
                    Command.Parameters.AddWithValue("@Doctor_Dept_Code", DoctorDeptCode)
                    Command.Parameters.AddWithValue("@Now", Now.ToString("yyyy/M/d"))

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                        Using ds As DataSet = New DataSet("OMO_Favor_Category")
                            adapter.Fill(ds, "OMO_Favor_Category")
                            Return ds
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 取得細分科
    ''' </summary>    
    Public Function queryPUBDepartmentAll_D2(ByVal SourceType As String) As System.Data.DataSet

        Dim cmdStr As New StringBuilder

        Try
            'SQL
            cmdStr.AppendLine("SELECT RTRIM(Dept_Code) AS Dept_Code")
            Select Case SourceType
                Case "O"
                    cmdStr.AppendLine(", RTRIM(Dept_Name) AS Dept_Name" & _
                                      ", RTRIM(Dept_En_Name) AS Dept_En_Name")
                Case "E"
                    cmdStr.AppendLine(", RTRIM(Emg_Dept_Name) AS Dept_Name" & _
                                      ", RTRIM(Emg_Dept_En_Name) AS Dept_En_Name")
                Case "I"
                    cmdStr.AppendLine(", RTRIM(Ipd_Dept_Name) AS Dept_Name" & _
                                      ", RTRIM(Ipd_Dept_En_Name) AS Dept_En_Name")
            End Select

            cmdStr.AppendLine(", Short_Name, '' AS Health_Opd_Dept_Code, '' AS Health_Ipd_Dept_Code, Effect_Date, End_Date, Belong_Dept_Code" & _
                          " FROM PUB_Department WITH(NOLOCK)" & _
                         " WHERE DC = 'N'" & _
                           " AND Belong_Dept_Code IS NOT NULL")

            Select Case SourceType
                Case "O"
                    cmdStr.AppendLine(" AND Is_Reg_Dept = 'Y'" & _
                                    " ORDER BY Dept_Code")
                Case "E"
                    cmdStr.AppendLine(" AND Is_Emg_Dept = 'Y'" & _
                                    " ORDER BY Emg_Sort_Value, Dept_Code")
                Case "I"
                    cmdStr.AppendLine(" AND Is_Ipd_Dept = 'Y'" & _
                                    " ORDER BY Ipd_Sort_Value, Dept_Code")
            End Select

            Try
                Using conn As SqlConnection = getConnection()
                    Using Command As SqlCommand = conn.CreateCommand

                        Command.CommandText = cmdStr.ToString

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                            Using ds As DataSet = New DataSet
                                adapter.Fill(ds, "table0")
                                Return ds
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryOMOOrderFavorByCond3(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, _
                                             ByVal FavorCategory As String, ByVal OrderCode As String, ByVal OrderName As String, _
                                             ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal ChartNo As String, _
                                             ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As DataSet
        Dim returnDS As New DataSet

        Dim sqlString As New System.Text.StringBuilder
        Dim sqlString2 As New System.Text.StringBuilder

        Dim pvtMergeSQL As String = ""
        Dim pvtMergeSQL2 As String = ""
        Dim pvtIsCoverOPD As Boolean = False
        Dim pvtQueryField As String = ""
        Dim pvtQueryTimes As Integer = 1
        Dim pvtIsQuery As Boolean = False

        'If (SourceType = "E" ORELSE SourceType = "I" ) AndAlso FavorTypeId = "H" AndAlso queryEMOMedicalRecordGetRegStateId(ChartNo, OutpatientSn) Then
        '    pvtIsCoverOPD = True
        'End If

        'Select Case SourceType
        '    Case "O"
        '        pvtMergeSQL = "Is_Opd='Y' "
        '    Case "E"
        '        pvtMergeSQL = "Is_Emg='Y' "
        '    Case "I"
        '        pvtMergeSQL = "Is_Ipd='Y' "
        'End Select

        Select Case SourceType
            Case "O"
                pvtMergeSQL2 = "Insu_Cover_Opd='Y' "
            Case "E"
                pvtMergeSQL2 = "Insu_Cover_Emg='Y' "
            Case "I"
                pvtMergeSQL2 = "Insu_Cover_Ipd='Y' "
        End Select

        If FavorTypeId = "E" AndAlso DrugType = "2" Then
            pvtQueryField = "'' As Property_Id"
        Else
            pvtQueryField = "C.Property_Id"
        End If

        OrderName = Replace(OrderName, "'", "''")

        'A(-診斷)
        'D(-治療處置)
        'G(-衛材)
        'E(-藥品)
        'H(-檢驗檢查)
        'J(-手術)
        '----常用醫令查詢(藥品)----
        If FavorId = 1 OrElse FavorId = 2 Then
            If FavorTypeId = "E" Then

                If PharmacyQueryFlag(6) = "Y" Then
                    sqlString.Append("SELECT * From ( ")
                End If

                '2011-09-01 Modify By Alan
                If PharmacyQueryFlag.Length > 8 AndAlso PharmacyQueryFlag(8).Trim = "Y" Then
                    pvtQueryTimes = 5
                End If

                For m = 0 To pvtQueryTimes - 1

                    '2011-09-01 Modify By Alan-若為急診藥品索引查詢，則需將Favor_Category更改為傳入的"索引值"
                    If pvtQueryTimes = 5 Then

                        If PharmacyQueryFlag(9 + m).Trim = "" Then
                            Continue For
                        Else
                            pvtIsQuery = True
                        End If


                        If pvtIsQuery AndAlso sqlString.ToString.Trim <> "" Then
                            sqlString.Append(" Union ")
                        End If

                        sqlString.Append("SELECT distinct '" & PharmacyQueryFlag(9 + m).Trim & "'  as Favor_Category,'" & PharmacyQueryFlag(9 + m).Trim & "' as Order_Code,'' as Favor_Name,'' as Order_Name,'' as Chinese_Name, ")
                        sqlString.Append("       null as Dosage,'' as Dosage_Unit , '' as Frequency_Code , '' as Usage_Code , null as Days , null as Qty , '' as Unit, ")
                        sqlString.Append("       '' as Body_Site_Code,'' as Specimen_Id,null as Sort_Value,'' as Is_Package, ")
                        sqlString.Append("       '' as OPD_Lack_Id , '' as IPD_Lack_Id , '' as EMG_Lack_Id ,'' as Is_Total_Qty, ")
                        sqlString.Append("       '' as Class_Code, '' as Form_Kind_Id  ,'' As Property_Id,'' as Pharmacy_12_Code,'' As Nhi_Price,'' As Own_Price,'E' As Order_Type_Id ")

                        Select Case DrugType
                            Case "1"
                                sqlString.Append(" ,'E' As Drug_Type ")
                            Case "2"
                                sqlString.Append(" ,'T' As Drug_Type ")
                            Case "3"
                                sqlString.Append(" ,'C' As Drug_Type ")
                            Case "4", "5"
                                sqlString.Append(" ,'' As Drug_Type ")
                        End Select

                        '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                        If (SourceType = "E" OrElse SourceType = "I") Then
                            sqlString.Append(" ,'' As Is_OrderStanding," & m & " As Category_View_Seq ")

                            '2012-10-24 Add By Alan-需再回傳Times與Remark
                            sqlString.Append(" ,'' As Times,'' As Remark ")
                        End If

                        '2016-07-19 Add By Alan-選取停用醫令替代藥處理
                        sqlString.Append(" ,'Y' As Is_Valid_Order ")

                        sqlString.Append("FROM OMO_Favor WITH(NOLOCK) ")

                        sqlString.Append(" Union ")

                        sqlString.Append("SELECT distinct '" & PharmacyQueryFlag(9 + m).Trim & "'  as Favor_Category,A.Order_Code,A.Favor_Name,B.Order_Name,B.Chinese_Name, ")
                    Else
                        sqlString.Append("SELECT distinct A.Favor_Category,A.Order_Code,A.Favor_Name,B.Order_Name,B.Chinese_Name, ")
                    End If

                    sqlString.Append("       A.Dosage, A.Dosage_Unit , A.Frequency_Code , A.Usage_Code , A.Days , A.Qty , A.Unit, ")
                    sqlString.Append("       A.Body_Site_Code,A.Specimen_Id,A.Sort_Value,A.Is_Package, ")
                    sqlString.Append("       B.OPD_Lack_Id , B. IPD_Lack_Id , B.EMG_Lack_Id ,B. Is_Total_Qty, ")
                    sqlString.Append("       B.Class_Code, B.Form_Kind_Id  ," & pvtQueryField & ",C.Pharmacy_12_Code,'' As Nhi_Price,'' As Own_Price,'E' As Order_Type_Id ")

                    '2010-03-18 Add By Alan
                    Select Case DrugType
                        Case "1"
                            sqlString.Append(" ,'E' As Drug_Type ")
                        Case "2"
                            sqlString.Append(" ,'T' As Drug_Type ")
                        Case "3"
                            sqlString.Append(" ,'C' As Drug_Type ")
                        Case "4", "5"
                            sqlString.Append(" ,'' As Drug_Type ")
                    End Select

                    '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                    If (SourceType = "E" OrElse SourceType = "I") Then
                        sqlString.Append(" ,D.Order_Code As Is_OrderStanding," & m & " As Category_View_Seq ")

                        '2012-10-24 Add By Alan-需再回傳Times與Remark
                        sqlString.Append(" , A.Times, '' As Remark ")
                    End If

                    '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
                    If IsChoiceDcOrder <> "Y" Then
                        sqlString.Append(",'Y' As Is_Valid_Order ")
                    Else
                        sqlString.Append(",CASE WHEN ( '" & Now.ToShortDateString & "' >= PO.Effect_Date and ")
                        sqlString.Append("             '" & Now.ToShortDateString & "' <= PO.End_Date ) and ")
                        sqlString.Append("             PO.Dc <> 'Y' THEN 'Y' ")
                        sqlString.Append("       ELSE 'N'  ")
                        sqlString.Append(" END As Is_Valid_Order ")

                    End If


                    sqlString.Append("FROM OMO_Favor A WITH(NOLOCK) ")

                    sqlString.Append(" INNER JOIN PUB_Order PO WITH(NOLOCK) ON ")
                    sqlString.Append("           PO.Order_Code = A.Order_Code AND (PO.Dc = 'N' or (PO.Dc='Y' and PO.Is_Alternative='Y')) ")

                    If IsChoiceDcOrder <> "Y" Then
                        sqlString.Append("           and PO.DC<>'Y' ")
                        sqlString.Append("           and PO.Effect_Date <= '" & Now.ToShortDateString & "' ")
                        sqlString.Append("           and PO.End_Date >= '" & Now.ToShortDateString & "' ")
                    End If

                    sqlString.Append(", OPH_Pharmacy_Base B WITH(NOLOCK) ")

                    '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                    If (SourceType = "E" OrElse SourceType = "I") Then
                        sqlString.Append(" LEFT JOIN PUB_Order_Standing D WITH(NOLOCK) ON ")
                        sqlString.Append(" D.Dept_Code='ER' And D.Order_Code=B.Order_Code And D.DC = 'N' ")
                    End If

                    Select Case DrugType
                        Case "1"
                            If pvtQueryTimes = 5 Then
                                sqlString.Append(" LEFT JOIN OPH_Property C WITH(NOLOCK) ON ")
                                sqlString.Append("         C.Pharmacy_12_Code = B.Pharmacy_12_Code ")
                            Else
                                sqlString.Append(" LEFT JOIN OPH_Property C WITH(NOLOCK) ON ")
                                sqlString.Append("         C.Pharmacy_12_Code = B.Pharmacy_12_Code ")
                            End If

                            If SourceType = "O" Then
                                sqlString.Append(" And C.Property_Id not in ('08','09','10','14','16') ")
                            End If

                        Case "2"
                            sqlString.Append(" ,OPH_Tpn_Pharmacy C WITH(NOLOCK) ")
                        Case "3", "4"
                            sqlString.Append(" ,OPH_Property C WITH(NOLOCK) ")
                        Case Else
                            sqlString.Append(" LEFT JOIN OPH_Property C WITH(NOLOCK) ON ")
                            sqlString.Append("         C.Pharmacy_12_Code = B.Pharmacy_12_Code ")
                    End Select

                    sqlString.Append("WHERE  ")
                    If FavorId <> "" Then
                        sqlString.Append(" A.Favor_Id = '" & FavorId & "' And ")
                    End If

                    If FavorTypeId <> "" Then
                        sqlString.Append(" A.Favor_Type_Id = '" & FavorTypeId & "' And ")
                    End If

                    If DoctorDeptCode <> "" Then
                        sqlString.Append(" A.Doctor_Dept_Code = '" & DoctorDeptCode & "' And ")
                    End If

                    If FavorCategory <> "" Then
                        sqlString.Append(" A.Favor_Category = '" & FavorCategory & "' And ")
                    End If

                    If OrderCode <> "" Then
                        sqlString.Append(" A.Order_Code = '" & OrderCode & "' And ")
                    End If

                    sqlString.Append("       A.Dc = 'N' And A.Is_Package <> 'Y' And ")
                    If pvtMergeSQL <> "" Then
                        If pvtIsCoverOPD Then
                            sqlString.Append(" (A." & pvtMergeSQL & " OR A.Is_Opd='Y') And ")
                        Else
                            sqlString.Append(" A." & pvtMergeSQL & " And ")
                        End If
                    End If

                    sqlString.Append(" B.Order_Code = A.Order_Code And B.Dc = 'N'  ")

                    '2012-04-19 Add By Alan
                    If (SourceType = "E" OrElse SourceType = "I") AndAlso DrugType = "1" Then

                        '2012-10-24 Modify By Alan-若為急診一般藥品，則僅需排除Property_Id='16'(大量點滴)
                        If SourceType = "E" Then
                            sqlString.Append(" And (Select  Count(*) ")
                            sqlString.Append("      From (Select Pharmacy_12_Code From OPH_Property WITH(NOLOCK) ")
                            sqlString.Append("            Where  Property_Id in ('16') ")
                            sqlString.Append("                   Group by Pharmacy_12_Code) E ")
                            sqlString.Append("      Where B.Pharmacy_12_Code=E.Pharmacy_12_Code) = 0  ")
                        Else
                            If DrugType = "2" Then
                                sqlString.Append(" And (Select  Count(*) ")
                                sqlString.Append("      From (Select Pharmacy_12_Code From OPH_Property WITH(NOLOCK) ")
                                sqlString.Append("            Where  Property_Id in ('08','09','10','14','16') ")
                                sqlString.Append("                   Group by Pharmacy_12_Code) E ")
                                sqlString.Append("      Where B.Pharmacy_12_Code=E.Pharmacy_12_Code) = 0  ")
                            End If
                        End If

                    End If

                    '2011-09-02 Add By Alan
                    If pvtQueryTimes = 5 Then
                        sqlString.Append(getIndexQueryStr(PharmacyQueryFlag, "B", 9 + m))
                    End If


                    If OrderName <> "" Then

                        If PharmacyQueryFlag(4) = "N" Then
                            sqlString.Append(" And ( B.Order_Name like '%" & OrderName & "%' ")

                            If PharmacyQueryFlag(0) = "Y" Then
                                sqlString.Append(" OR  B.Scientific_Name like '%" & OrderName & "%' ")
                            End If

                            If PharmacyQueryFlag(1) = "Y" Then
                                sqlString.Append(" OR  B.Trade_Name like '%" & OrderName & "%' ")
                            End If

                            If PharmacyQueryFlag(2) = "Y" Then
                                sqlString.Append(" OR  B.Alias_Name like '%" & OrderName & "%' ")
                            End If

                            If PharmacyQueryFlag(3) = "Y" Then
                                sqlString.Append(" OR  B.Chinese_Name like '%" & OrderName & "%' ")
                            End If
                        Else
                            sqlString.Append(" And ( B.Order_Name like '%" & OrderName & "%' ")

                            If PharmacyQueryFlag(0) = "Y" Then
                                sqlString.Append(" OR  B.Scientific_Name like '%" & OrderName & "%' ")
                            End If

                            If PharmacyQueryFlag(1) = "Y" Then
                                sqlString.Append(" OR  B.Trade_Name like '%" & OrderName & "%' ")
                            End If

                            If PharmacyQueryFlag(2) = "Y" Then
                                sqlString.Append(" OR  B.Alias_Name like '%" & OrderName & "%' ")
                            End If

                            If PharmacyQueryFlag(3) = "Y" Then
                                sqlString.Append(" OR  B.Chinese_Name like '%" & OrderName & "%' ")
                            End If
                        End If


                        sqlString.Append(") ")

                    End If


                    Select Case DrugType
                        Case "1"
                            'If (SourceType = "E" OrElse SourceType = "I") Then
                            '    sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code ")
                            'End If

                        Case "2"
                            sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code ")

                            Select Case PharmacyQueryFlag(7)
                                Case "1" 'TPN
                                    sqlString.Append(" And C.Tpn_Kind_Id in ('1','2') ")
                                Case "3" '混合
                                    sqlString.Append(" And C.Tpn_Kind_Id = '4' ")
                                Case "4" '添加
                                    sqlString.Append(" And C.Tpn_Kind_Id = '5' ")
                            End Select


                        Case "3"
                            sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '10' And  C.Property_Id <> '08' ")
                        Case "4"
                            sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '14' And  C.Property_Id <> '08' ")
                        Case "5"
                            If (SourceType = "E" OrElse SourceType = "I") Then
                                sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '16' ")
                            End If
                    End Select
                    '********************************以下為整合急診醫囑所做修改*********************************************************
                    If (SourceType = "E" OrElse SourceType = "I") AndAlso DrugType = "1" Then
                        sqlString.Append(" Union ")

                        '2011-09-01 Modify By Alan-若為急診藥品索引查詢，則需將Favor_Category更改為傳入的"索引值"
                        If pvtQueryTimes = 5 Then
                            sqlString.Append("SELECT distinct '" & PharmacyQueryFlag(9 + m).Trim & "' As Favor_Category,J.Order_Code,J.Favor_Name,J.Favor_Name As Order_Name,J.Favor_Name As Chinese_Name, ")
                        Else
                            sqlString.Append("SELECT distinct J.Favor_Category,J.Order_Code,J.Favor_Name,J.Favor_Name As Order_Name,J.Favor_Name As Chinese_Name, ")
                        End If

                        sqlString.Append("       J.Dosage, J.Dosage_Unit , J.Frequency_Code , J.Usage_Code , J.Days , J.Qty , J.Unit, ")
                        sqlString.Append("       J.Body_Site_Code,J.Specimen_Id,J.Sort_Value,J.Is_Package, ")
                        sqlString.Append("       'N' As OPD_Lack_Id , 'N' As IPD_Lack_Id , 'N' As EMG_Lack_Id ,'' As Is_Total_Qty, ")
                        sqlString.Append("       '' As Class_Code ,'' As Form_Kind_Id  ,'' As Property_Id ,'' As Pharmacy_12_Code,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,'E' As Order_Type_Id  ")

                        '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                        If (SourceType = "E" OrElse SourceType = "I") Then
                            sqlString.Append(" ,E.Order_Code As Is_OrderStanding," & m & " As Category_View_Seq ")

                            '2012-10-24 Add By Alan-需再回傳Times與Remark
                            sqlString.Append(" , J.Times,'' As Remark ")
                        End If

                        '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
                        If IsChoiceDcOrder <> "Y" Then
                            sqlString.Append(" ,'Y' As Is_Valid_Order ")
                        Else
                            sqlString.Append(",CASE WHEN ( '" & Now.ToShortDateString & "' >= PO.Effect_Date and ")
                            sqlString.Append("             '" & Now.ToShortDateString & "' <= PO.End_Date ) and ")
                            sqlString.Append("             PO.Dc <> 'Y' THEN 'Y' ")
                            sqlString.Append("       ELSE 'N'  ")
                            sqlString.Append(" END As Is_Valid_Order ")

                        End If

                        sqlString.Append("FROM OMO_Favor J WITH(NOLOCK) ")

                        '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                        If (SourceType = "E" OrElse SourceType = "I") Then
                            sqlString.Append(" LEFT JOIN PUB_Order_Standing E WITH(NOLOCK) ON ")
                            sqlString.Append(" E.Dept_Code='ER' And E.Order_Code=J.Order_Code And E.DC = 'N' ")
                        End If

                        sqlString.Append(" INNER JOIN PUB_Order PO WITH(NOLOCK) ON ")
                        sqlString.Append("           PO.Order_Code = J.Order_Code AND (PO.Dc = 'N' or (PO.Dc='Y' and PO.Is_Alternative='Y')) ")

                        If IsChoiceDcOrder <> "Y" Then
                            sqlString.Append("           and PO.DC<>'Y' ")
                            sqlString.Append("           and PO.Effect_Date <= '" & Now.ToShortDateString & "' ")
                            sqlString.Append("           and PO.End_Date >= '" & Now.ToShortDateString & "' ")
                        End If

                        sqlString.Append("WHERE  ")

                        If FavorId <> "" Then
                            sqlString.Append(" J.Favor_Id = '" & FavorId & "' And ")
                        End If

                        If FavorTypeId <> "" Then
                            sqlString.Append(" J.Favor_Type_Id = '" & FavorTypeId & "' And ")
                        End If

                        If DoctorDeptCode <> "" Then
                            sqlString.Append(" J.Doctor_Dept_Code = '" & DoctorDeptCode & "' And ")
                        End If

                        If FavorCategory <> "" Then
                            sqlString.Append(" J.Favor_Category = '" & FavorCategory & "' And ")
                        End If

                        If OrderCode <> "" Then
                            sqlString.Append(" J.Order_Code = '" & OrderCode & "' And ")
                        End If

                        sqlString.Append("       J.Dc = 'N' And J.Is_Package = 'Y'  ")

                        '2011-09-02 Add By Alan
                        If pvtQueryTimes = 5 Then
                            sqlString.Append(" And  J.Favor_Name like '%" & PharmacyQueryFlag(9 + m) & "%' ")
                        End If

                        If OrderName <> "" Then
                            sqlString.Append(" And  J.Favor_Name like '%" & OrderName & "%' ")
                        End If

                        If pvtMergeSQL <> "" Then
                            If pvtIsCoverOPD Then
                                sqlString.Append(" And (J." & pvtMergeSQL & " OR J.Is_Opd='Y') ")
                            Else
                                sqlString.Append(" And J." & pvtMergeSQL)
                            End If
                        End If
                    End If


                    If PharmacyQueryFlag(6) = "Y" Then
                        sqlString.Append(" Union ")
                        '2011-09-01 Modify By Alan
                        If pvtQueryTimes = 5 Then
                            sqlString.Append(queryOMOOrderFavorNormalSQL2(SourceType, FavorId, FavorTypeId, DoctorDeptCode, FavorCategory, OrderCode, OrderName, "1", PharmacyQueryFlag, ChartNo, OutpatientSn, IsChoiceDcOrder))
                        Else
                            sqlString.Append(queryOMOOrderFavorNormalSQL3(SourceType, FavorId, FavorTypeId, DoctorDeptCode, FavorCategory, OrderCode, OrderName, "1", PharmacyQueryFlag, ChartNo, OutpatientSn, m, IsChoiceDcOrder))
                        End If

                        sqlString.Append(" )  KK ")
                        sqlString.Append(" Order By KK.Favor_Category, KK.Sort_Value,KK.Order_Code ")
                    Else
                        If pvtQueryTimes = 1 Then
                            sqlString.Append(" Order By A.Favor_Category, A.Sort_Value,A.Order_Code ")
                        End If

                    End If

                Next

                If pvtQueryTimes = 5 Then
                    sqlString.Append(" Order By Category_View_Seq,Favor_Category,Sort_Value,Order_Code ")
                End If

                '----常用醫令查詢(非藥品)----
            Else

                '----非手術醫令與診斷----
                If FavorTypeId <> "J" AndAlso FavorTypeId <> "A" Then

                    sqlString.Append("SELECT * From ( ")

                    sqlString.Append("SELECT A.Favor_Category,A.Order_Code,A.Favor_Name, B.Order_Name,B.Order_En_Name, ")
                    sqlString.Append("       A.Dosage,A.Dosage_Unit,A.Frequency_Code,A.Usage_Code,A.Days,A.Qty, ")
                    sqlString.Append("       A.Unit,A.Body_Site_Code As Default_Body_Site_Code,A.Specimen_Id,A.Is_Package,A.Sort_Value, ")
                    sqlString.Append("       B.Account_Id,B.Is_Cure,B.Cure_Type_Id,B.Treatment_Type_Id,B.Charge_Unit, ")
                    sqlString.Append("       B.Nhi_Transrate,B.Nhi_Unit,B.Is_Order_Check,'' AS Is_Indication,B.Fix_Order_Id, ")
                    sqlString.Append("       B.Is_Exclude_Drug,B.Order_Memo, '' AS Order_Flag,B.Is_Agree_Sheet, ")
                    sqlString.Append("       B.Is_Nhi_Sheet,'' AS Is_Nhi_Index,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,B.Order_Type_Id,B.Is_Prior_Review,A.Category_View_Seq ")

                    '若為急診檢驗檢查
                    '=>1.需於名稱後面新增檢體名稱()
                    '=>2.加入檢查替換部位Order判斷欄位
                    '=>3.新增Sheet_Group欄位
                    If (SourceType = "E" OrElse SourceType = "I") AndAlso FavorTypeId = "H" Then
                        sqlString.Append(" ,C.Code_Name As Specimen_Name,D.Order_Code As Option_Order ")
                        sqlString.Append(" ,(SELECT CASE A.Specimen_Id WHEN '' Then F.Sheet_Group WHEN Null Then F.Sheet_Group ELSE E.Sheet_Group END) AS Sheet_Group ")
                        sqlString.Append(" ,(SELECT CASE A.Specimen_Id WHEN '' Then F.Sheet_Group_Name WHEN Null Then F.Sheet_Group_Name ELSE E.Sheet_Group_Name END) AS Sheet_Group_Name ")
                    End If

                    '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
                    If IsChoiceDcOrder <> "Y" Then
                        sqlString.Append(",'Y' As Is_Valid_Order ")
                    Else
                        sqlString.Append(",CASE WHEN ( '" & Now.ToShortDateString & "' >= B.Effect_Date and ")
                        sqlString.Append("             '" & Now.ToShortDateString & "' <= B.End_Date ) and ")
                        sqlString.Append("             B.Dc <> 'Y' THEN 'Y' ")
                        sqlString.Append("       ELSE 'N'  ")
                        sqlString.Append(" END As Is_Valid_Order ")

                    End If

                    sqlString2.Append("SELECT A.Favor_Category ")

                    Select Case FavorTypeId
                        Case "D"
                            sqlString.Append("      ,C.Default_Side_Id  ")
                            sqlString.Append("FROM OMO_Favor A WITH(NOLOCK) LEFT JOIN PUB_Order_Or_Treat C WITH(NOLOCK) ON ( C.Order_Code = A.ORDER_CODE ) ")
                            sqlString.Append(", PUB_Order B WITH(NOLOCK) ")

                            sqlString2.Append("FROM OMO_Favor A WITH(NOLOCK) LEFT JOIN PUB_Order_Or_Treat C WITH(NOLOCK) ON ( C.Order_Code = A.ORDER_CODE ) ")
                            sqlString2.Append(", PUB_Order B WITH(NOLOCK) ")

                        Case Else
                            '若為急診檢驗檢查
                            '=>1.需於名稱後面新增檢體名稱()
                            '=>2.加入檢查替換部位Order判斷欄位
                            '=>3.新增Sheet_Group欄位
                            If (SourceType = "E" OrElse SourceType = "I") AndAlso FavorTypeId = "H" Then
                                sqlString.Append("FROM OMO_Favor A WITH(NOLOCK) ")
                                sqlString.Append("     Left Join PUB_SysCode C WITH(NOLOCK) On ")

                                '2012-10-24 Modify By Alan
                                If SourceType = "E" Then
                                    sqlString.Append("     C.Type_Id='46' and C.Code_Id=A.Specimen_Id and C.DC<>'Y' ")
                                ElseIf SourceType = "I" Then
                                    sqlString.Append("     C.Type_Id='46' and C.Code_Id=A.Specimen_Id and C.DC<>'Y'  ")
                                End If

                                sqlString.Append("     Left Join PUB_Exam_Item D WITH(NOLOCK) On D.Order_Code=A.Order_Code ")
                                sqlString.Append("     Left Join PUB_Sheet_Group E WITH(NOLOCK) On E.Sheet_Group=A.Specimen_Id and E.Sheet_Code=SubString(A.Order_Code,0,5) And E.Order_Code=A.Order_Code ")
                                sqlString.Append("     Left Join PUB_Sheet_Group F WITH(NOLOCK) On F.Sheet_Group=A.Body_Site_Code and E.Sheet_Code=SubString(A.Order_Code,0,5)  And E.Order_Code=A.Order_Code ")
                                sqlString.Append(", PUB_Order B WITH(NOLOCK) ")

                                sqlString2.Append("FROM OMO_Favor A WITH(NOLOCK) ")
                                sqlString2.Append("     Left Join PUB_SysCode C WITH(NOLOCK) On ")

                                '2012-10-24 Modify By Alan
                                If SourceType = "E" Then
                                    sqlString2.Append("          C.Type_Id='46' and C.Code_Id=A.Specimen_Id and C.DC<>'Y'  ")
                                ElseIf SourceType = "I" Then
                                    sqlString2.Append("          C.Type_Id='46' and C.Code_Id=A.Specimen_Id and C.DC<>'Y'  ")
                                End If


                                sqlString2.Append("     Left Join PUB_Exam_Item D WITH(NOLOCK) On ")
                                sqlString2.Append("          D.Order_Code=A.Order_Code ")
                                sqlString2.Append("     Left Join PUB_Sheet_Group E WITH(NOLOCK) On E.Sheet_Group=A.Specimen_Id and E.Sheet_Code=SubString(A.Order_Code,0,5)  And E.Order_Code=A.Order_Code ")
                                sqlString2.Append("     Left Join PUB_Sheet_Group F WITH(NOLOCK) On F.Sheet_Group=A.Body_Site_Code and E.Sheet_Code=SubString(A.Order_Code,0,5)  And E.Order_Code=A.Order_Code ")
                                sqlString2.Append(", PUB_Order  B  ")
                            Else
                                sqlString.Append("FROM OMO_Favor A WITH(NOLOCK) ")
                                sqlString.Append(", PUB_Order B WITH(NOLOCK) ")

                                sqlString2.Append("FROM OMO_Favor A WITH(NOLOCK) ")
                                sqlString2.Append(", PUB_Order B WITH(NOLOCK) ")
                            End If

                    End Select

                    sqlString.Append("WHERE  ")
                    sqlString2.Append("WHERE  ")

                    If FavorId <> "" Then
                        sqlString.Append(" A.Favor_Id = '" & FavorId & "' And A.DC<>'Y' And  A.Is_Package<>'Y' And ")
                        sqlString2.Append(" A.Favor_Id = '" & FavorId & "' And A.DC<>'Y' And  A.Is_Package<>'Y' And ")
                    End If

                    If FavorTypeId <> "" Then

                        Select Case FavorTypeId
                            Case "H"
                                sqlString.Append("  A.Favor_Type_Id = '" & FavorTypeId & "' And  B.Treatment_Type_Id in ('3' , '4') And ")
                                sqlString2.Append("  A.Favor_Type_Id = '" & FavorTypeId & "' And  B.Treatment_Type_Id in ('3' , '4') And ")
                            Case "D"
                                'sqlString.Append("  A.Favor_Type_Id IN ('D','J','H')   And  ")
                                If SourceType <> "E" AndAlso SourceType <> "I" Then
                                    sqlString.Append(" ( A.Favor_Type_Id in ('D','H') ")
                                    sqlString2.Append(" ( A.Favor_Type_Id in ('D','H') ")
                                Else
                                    '2011-10-04 Modify By Alan
                                    '若為急診護理計價查詢(以DrugType='D'判斷)，則不顯示虛擬醫囑
                                    If DoctorDeptCode <> "ENR" Then
                                        If DrugType = "D" Then
                                            sqlString.Append(" ( A.Favor_Type_Id in ('D','H') ")
                                            sqlString2.Append(" ( A.Favor_Type_Id in ('D','H') ")
                                        Else
                                            sqlString.Append(" ( A.Favor_Type_Id in ('D','H','T') ")
                                            sqlString2.Append(" ( A.Favor_Type_Id in ('D','H','T') ")
                                        End If
                                    Else
                                        sqlString.Append(" ( A.Favor_Type_Id in ('D','H','G') ")
                                        sqlString2.Append(" ( A.Favor_Type_Id in ('D','H','G') ")
                                    End If

                                End If
                                sqlString.Append("      or ( A.Favor_Type_Id ='J' and A.Doctor_Dept_Code in ('32','33','35','39','70') ) ) And ")
                                sqlString.Append("  A.Favor_Category <>'開刀房手術' And ")

                                sqlString2.Append("      or ( A.Favor_Type_Id ='J' and A.Doctor_Dept_Code in ('32','33','35','39','70') ) ) And ")
                                sqlString2.Append("  A.Favor_Category <>'開刀房手術' And ")
                            Case Else
                                sqlString.Append(" A.Favor_Type_Id = '" & FavorTypeId & "' And ")
                                sqlString2.Append(" A.Favor_Type_Id = '" & FavorTypeId & "' And ")
                        End Select

                    End If

                    If DoctorDeptCode <> "" Then
                        sqlString.Append(" A.Doctor_Dept_Code = '" & DoctorDeptCode & "' And ")
                        sqlString2.Append(" A.Doctor_Dept_Code = '" & DoctorDeptCode & "' And ")
                    End If

                    If FavorCategory <> "" Then
                        sqlString.Append(" A.Favor_Category = '" & FavorCategory & "' And ")
                        sqlString2.Append(" A.Favor_Category = '" & FavorCategory & "' And ")
                    End If

                    If OrderCode <> "" Then
                        sqlString.Append(" A.Order_Code like %'" & OrderCode & "%' And ")
                        sqlString2.Append(" A.Order_Code like %'" & OrderCode & "%' And ")
                    End If

                    If pvtMergeSQL <> "" Then
                        If pvtIsCoverOPD Then
                            sqlString.Append(" (A." & pvtMergeSQL & " OR A.Is_Opd='Y') And ")
                            sqlString2.Append(" (A." & pvtMergeSQL & " OR A.Is_Opd='Y') And ")
                        Else
                            sqlString.Append(" A." & pvtMergeSQL & " And ")
                            sqlString2.Append(" A." & pvtMergeSQL & " And ")
                        End If
                    End If

                    sqlString.Append(" B.Order_Code=A.Order_Code AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y')) ")
                    sqlString2.Append(" B.Order_Code=A.Order_Code AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y')) ")

                    If IsChoiceDcOrder <> "Y" Then
                        sqlString.Append(" And B.Effect_Date<='" & Now.ToShortDateString & "' And  ")
                        sqlString.Append(" B.Dc<>'Y'  And ")
                        sqlString.Append(" B.End_Date>= '" & Now.ToShortDateString & "' ")

                        sqlString2.Append(" And B.Effect_Date<='" & Now.ToShortDateString & "' And  ")
                        sqlString2.Append(" B.Dc<>'Y'  And ")
                        sqlString2.Append(" B.End_Date>= '" & Now.ToShortDateString & "' ")
                    End If


                    If FavorTypeId = "D" Then
                        sqlString.Append(" And ( B.Treatment_Type_Id not in ('3' , '4')  ")
                        sqlString.Append(" OR  B.Treatment_Type_Id IS NULL )  ")

                        sqlString2.Append(" And ( B.Treatment_Type_Id not in ('3' , '4')  ")
                        sqlString2.Append(" OR  B.Treatment_Type_Id IS NULL )  ")
                    End If



                    If OrderName <> "" Then
                        If PharmacyQueryFlag(4) = "N" Then
                            If SourceType = "E" Then
                                sqlString.Append(" And ( A.Favor_Name like '%" & OrderName & "%'  OR ")
                                sqlString.Append("       B.Order_Name like '%" & OrderName & "%'  OR  ")
                                sqlString.Append("       B.Order_En_Name like '%" & OrderName & "%' )  ")
                            Else
                                sqlString.Append(" And ( B.Order_Name like '%" & OrderName & "%'  OR ")
                                sqlString.Append("   B.Order_En_Name like '%" & OrderName & "%' )  ")
                            End If

                            sqlString2.Append(" And ( B.Order_Name like '%" & OrderName & "%'  OR ")
                            sqlString2.Append("   B.Order_En_Name like '%" & OrderName & "%' )  ")
                        Else
                            If SourceType = "E" Then
                                sqlString.Append(" And ( A.Favor_Name like '%" & OrderName & "%'  OR  ")
                                sqlString.Append("       B.Order_Name like '%" & OrderName & "%'  OR ")
                                sqlString.Append("       B.Order_En_Name like '%" & OrderName & "%' )  ")
                            Else
                                sqlString.Append(" And ( B.Order_Name like '%" & OrderName & "%'  OR ")
                                sqlString.Append("   B.Order_En_Name like '%" & OrderName & "%' )  ")
                            End If


                            sqlString2.Append(" And ( B.Order_Name like '%" & OrderName & "%'  OR ")
                            sqlString2.Append("   B.Order_En_Name like '%" & OrderName & "%' )  ")
                        End If

                    End If

                    '********************************以下為整合急診醫囑所做修改*********************************************************
                    sqlString.Append(" Union ")
                    sqlString.Append("SELECT M.Favor_Category,M.Order_Code,M.Favor_Name, M.Favor_Name As Order_Name,M.Favor_Name As Order_En_Name, ")
                    sqlString.Append("       M.Dosage,M.Dosage_Unit,M.Frequency_Code,M.Usage_Code,M.Days,M.Qty, ")
                    sqlString.Append("       M.Unit,M.Body_Site_Code As Default_Body_Site_Code,M.Specimen_Id,M.Is_Package,M.Sort_Value, ")
                    sqlString.Append("       '' As Account_Id,'' As Is_Cure,'' As Cure_Type_Id,'' As Treatment_Type_Id,'' As Charge_Unit, ")
                    sqlString.Append("       Null As Nhi_Transrate,'' As Nhi_Unit,'' As Is_Order_Check,'' As Is_Indication,'' As Fix_Order_Id, ")
                    sqlString.Append("       '' As Is_Exclude_Drug,'' As Order_Memo, '' As Order_Flag,'' As Is_Agree_Sheet, ")
                    sqlString.Append("       '' As Is_Nhi_Sheet,'' As Is_Nhi_Index,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,'' As Order_Type_Id,'' As Is_Prior_Review,M.Category_View_Seq ")

                    '若為急診檢驗檢查
                    '=>1.需於名稱後面新增檢體名稱()
                    '=>2.加入檢查替換部位Order判斷欄位
                    '=>3.新增Sheet_Group欄位
                    If (SourceType = "E" OrElse SourceType = "I") AndAlso FavorTypeId = "H" Then
                        sqlString.Append(" ,N.Code_Name  As Specimen_Name,O.Order_Code As Option_Order,'' As Sheet_Group,'' As Sheet_Group_Name ")
                    End If

                    '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
                    If IsChoiceDcOrder <> "Y" Then
                        sqlString.Append(",'Y' As Is_Valid_Order ")
                    Else
                        sqlString.Append(",CASE WHEN ( '" & Now.ToShortDateString & "' >= PO.Effect_Date and ")
                        sqlString.Append("             '" & Now.ToShortDateString & "' <= PO.End_Date ) and ")
                        sqlString.Append("             PO.Dc <> 'Y' THEN 'Y' ")
                        sqlString.Append("       ELSE 'N'  ")
                        sqlString.Append(" END As Is_Valid_Order ")

                    End If

                    sqlString2.Append(" Union ")
                    sqlString2.Append("SELECT M.Favor_Category ")

                    If FavorTypeId = "D" Then
                        sqlString.Append("       ,'' AS Default_Side_Id ")
                    End If

                    '若為急診檢驗檢查
                    '=>1.需於名稱後面新增檢體名稱()
                    '=>2.加入檢查替換部位Order判斷欄位
                    '=>3.新增Sheet_Group欄位
                    If (SourceType = "E" OrElse SourceType = "I") AndAlso FavorTypeId = "H" Then
                        sqlString.Append("FROM OMO_Favor M WITH(NOLOCK) ")
                        sqlString.Append("     Left Join PUB_SysCode N WITH(NOLOCK) On ")


                        '2012-10-24 Modify By Alan
                        If SourceType = "E" Then
                            sqlString.Append("     N.Type_Id='46' and N.Code_Id=M.Specimen_Id and N.DC<>'Y'  ")
                        ElseIf SourceType = "I" Then
                            sqlString.Append("     N.Type_Id='46' and N.Code_Id=M.Specimen_Id and N.DC<>'Y'  ")
                        End If


                        sqlString.Append("     Left Join PUB_Exam_Item O WITH(NOLOCK) On O.Order_Code=M.Order_Code ")
                        'sqlString.Append("     Left Join PUB_Sheet_Group P On P.Sheet_Code=SubString(M.Order_Code,0,5)  And P.Order_Code=M.Order_Code ")

                        sqlString.Append(" INNER JOIN PUB_Order PO WITH(NOLOCK) ON ")
                        sqlString.Append("           PO.Order_Code = M.Order_Code AND (PO.Dc = 'N' or (PO.Dc='Y' and PO.Is_Alternative='Y')) ")

                        If IsChoiceDcOrder <> "Y" Then
                            sqlString.Append("           and PO.DC<>'Y' ")
                            sqlString.Append("           and PO.Effect_Date <= '" & Now.ToShortDateString & "' ")
                            sqlString.Append("           and PO.End_Date >= '" & Now.ToShortDateString & "' ")
                        End If

                        sqlString.Append("WHERE  ")

                        sqlString2.Append("FROM OMO_Favor M WITH(NOLOCK) ")
                        sqlString2.Append("     Left Join PUB_SysCode N WITH(NOLOCK) On ")

                        '2012-10-24 Modify By Alan
                        If SourceType = "E" Then
                            sqlString2.Append("     N.Type_Id='46' and N.Code_Id=M.Specimen_Id and N.DC<>'Y'  ")
                        ElseIf SourceType = "I" Then
                            sqlString2.Append("     N.Type_Id='46' and N.Code_Id=M.Specimen_Id and N.DC<>'Y'  ")
                        End If


                        sqlString2.Append("     Left Join PUB_Exam_Item O WITH(NOLOCK) On O.Order_Code=M.Order_Code ")
                        'sqlString2.Append("     Left Join PUB_Sheet_Group P On SubString(M.Order_Code,0,5)=P.Sheet_Code  And P.Order_Code=M.Order_Code ")
                        sqlString2.Append(" INNER JOIN PUB_Order PO WITH(NOLOCK) ON ")
                        sqlString2.Append("           PO.Order_Code = M.Order_Code AND (PO.Dc = 'N' or (PO.Dc='Y' and PO.Is_Alternative='Y')) ")

                        If IsChoiceDcOrder <> "Y" Then
                            sqlString2.Append("           and PO.DC<>'Y' ")
                            sqlString2.Append("           and PO.Effect_Date <= '" & Now.ToShortDateString & "' ")
                            sqlString2.Append("           and PO.End_Date >= '" & Now.ToShortDateString & "' ")
                        End If

                        sqlString2.Append("WHERE  ")

                    Else
                        sqlString.Append("FROM OMO_Favor M WITH(NOLOCK) ")

                        sqlString.Append(" INNER JOIN PUB_Order PO WITH(NOLOCK) ON ")
                        sqlString.Append("           PO.Order_Code = M.Order_Code AND (PO.Dc = 'N' or (PO.Dc='Y' and PO.Is_Alternative='Y')) ")

                        If IsChoiceDcOrder <> "Y" Then
                            sqlString.Append("           and PO.DC<>'Y' ")
                            sqlString.Append("           and PO.Effect_Date <= '" & Now.ToShortDateString & "' ")
                            sqlString.Append("           and PO.End_Date >= '" & Now.ToShortDateString & "' ")
                        End If

                        sqlString.Append("WHERE  ")

                        sqlString2.Append("FROM OMO_Favor M WITH(NOLOCK) ")
                        sqlString2.Append(" INNER JOIN PUB_Order PO WITH(NOLOCK) ON ")
                        sqlString2.Append("           PO.Order_Code = M.Order_Code AND (PO.Dc = 'N' or (PO.Dc='Y' and PO.Is_Alternative='Y')) ")

                        If IsChoiceDcOrder <> "Y" Then
                            sqlString2.Append("           and PO.DC<>'Y' ")
                            sqlString2.Append("           and PO.Effect_Date <= '" & Now.ToShortDateString & "' ")
                            sqlString2.Append("           and PO.End_Date >= '" & Now.ToShortDateString & "' ")
                        End If

                        sqlString2.Append("WHERE  ")

                    End If


                    If FavorId <> "" Then
                        sqlString.Append(" M.Favor_Id = '" & FavorId & "' And M.DC<>'Y' And M.Is_Package='Y' ")
                        sqlString2.Append(" M.Favor_Id = '" & FavorId & "' And M.DC<>'Y' And M.Is_Package='Y' ")
                    End If

                    If FavorTypeId <> "" Then

                        If DoctorDeptCode <> "ENR" Then
                            sqlString.Append(" And M.Favor_Type_Id = '" & FavorTypeId & "'  ")
                            sqlString2.Append(" And M.Favor_Type_Id = '" & FavorTypeId & "'  ")
                        Else
                            sqlString.Append(" And M.Favor_Type_Id IN ('G','D') ")
                            sqlString2.Append(" And M.Favor_Type_Id IN ('G','D')  ")
                        End If


                    End If

                    If DoctorDeptCode <> "" Then
                        sqlString.Append(" And M.Doctor_Dept_Code = '" & DoctorDeptCode & "'  ")
                        sqlString2.Append(" And M.Doctor_Dept_Code = '" & DoctorDeptCode & "'  ")
                    End If

                    If FavorCategory <> "" Then
                        sqlString.Append(" And M.Favor_Category = '" & FavorCategory & "'  ")
                        sqlString2.Append(" And M.Favor_Category = '" & FavorCategory & "'  ")
                    End If

                    If OrderCode <> "" Then
                        sqlString.Append(" And M.Order_Code like %'" & OrderCode & "%'  ")
                        sqlString2.Append(" And M.Order_Code like %'" & OrderCode & "%'  ")
                    End If

                    If OrderName <> "" Then
                        sqlString.Append(" And  M.Favor_Name like '%" & OrderName & "%'   ")
                        sqlString2.Append(" And  M.Favor_Name like '%" & OrderName & "%'   ")
                    End If

                    If pvtMergeSQL <> "" Then
                        If pvtIsCoverOPD Then
                            sqlString.Append(" And (M." & pvtMergeSQL & " OR M.Is_Opd='Y') ")
                            sqlString2.Append(" And (M." & pvtMergeSQL & " OR M.Is_Opd='Y') ")
                        Else
                            sqlString.Append(" And M." & pvtMergeSQL)
                            sqlString2.Append(" And M." & pvtMergeSQL)
                        End If
                    End If

                    '若為急診且醫令類別為H(檢驗檢查)或D(治療處置)，則將分類展開至Grid中
                    'If (SourceType = "E" OrElse SourceType = "I") AndAlso (FavorTypeId = "H" OrElse (FavorTypeId = "D" AndAlso DoctorDeptCode <> "++") OrElse _
                    '   (FavorTypeId = "D" AndAlso DoctorDeptCode = "++")) AndAlso DrugType <> "D" AndAlso FavorCategory = "" Then
                    '    sqlString.Append(getCategorySQLString(SourceType, FavorId, FavorTypeId, DoctorDeptCode, DrugType, sqlString2.ToString))
                    'End If

                    '若為住院，則需再查詢護理站套裝=>P類
                    'If SourceType = "I" AndAlso FavorTypeId = "D" Then
                    '    sqlString.Append(getCategorySQLStringForPCS(SourceType, FavorId, FavorTypeId, DoctorDeptCode, DrugType, sqlString2.ToString))
                    'End If

                    sqlString.Append(" )  TT ")

                    If (SourceType = "E" OrElse SourceType = "I") Then
                        sqlString.Append(" Order By TT.Category_View_Seq,TT.Favor_Category,TT.Sort_Value,TT.Order_Code ")
                    Else
                        sqlString.Append(" Order By TT.Favor_Category,TT.Sort_Value,TT.Order_Code ")
                    End If



                    '----手術醫令----
                ElseIf FavorTypeId = "J" Then
                    sqlString.Append("SELECT Distinct '' as Favor_Category,A.Order_Code,C.Favor_Name, B.Order_Name,B.Order_En_Name, ")
                    sqlString.Append("       '' as Dosage,'' as Dosage_Unit,'' as Frequency_Code,'' as Usage_Code,'' as Days,'' as Qty, ")
                    sqlString.Append("       '' as Unit,''  As Default_Body_Site_Code,'' as Specimen_Id,'' as Is_Package,'' as Sort_Value, ")
                    sqlString.Append("       B.Account_Id,B.Is_Cure,B.Cure_Type_Id,B.Treatment_Type_Id,B.Charge_Unit, ")
                    sqlString.Append("       B.Nhi_Transrate,B.Nhi_Unit,B.Is_Order_Check,'' AS Is_Indication,B.Fix_Order_Id, ")
                    sqlString.Append("       B.Is_Exclude_Drug,B.Order_Memo, '' AS Order_Flag,B.Is_Agree_Sheet, ")
                    sqlString.Append("       B.Is_Nhi_Sheet,'' AS Is_Nhi_Index,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,B.Order_Type_Id,A.Nameplate_Name, ")
                    sqlString.Append("       A.Doctor_Dept_Code,A.Age_Group_Id,A.Op_Nameplate_Id ")

                    '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
                    If IsChoiceDcOrder <> "Y" Then
                        sqlString.Append(",'Y' As Is_Valid_Order ")
                    Else
                        sqlString.Append(",CASE WHEN ( '" & Now.ToShortDateString & "' >= B.Effect_Date and ")
                        sqlString.Append("             '" & Now.ToShortDateString & "' <= B.End_Date ) and ")
                        sqlString.Append("             B.Dc <> 'Y' THEN 'Y' ")
                        sqlString.Append("       ELSE 'N'  ")
                        sqlString.Append(" END As Is_Valid_Order ")

                    End If

                    sqlString.Append("FROM SUR_Op_Year_Nameplate A WITH(NOLOCK), PUB_Order B WITH(NOLOCK), OMO_Favor C WITH(NOLOCK) ")
                    sqlString.Append("WHERE  ")

                    If FavorId <> "" Then
                        sqlString.Append(" A.User_Type_Id = '" & FavorId & "' And A.DC<>'Y' And  ")
                    End If

                    If DoctorDeptCode <> "" Then
                        sqlString.Append(" A.Doctor_Dept_Code = '" & DoctorDeptCode & "' And ")
                    End If

                    If OrderCode <> "" Then
                        sqlString.Append(" A.Order_Code like %'" & OrderCode & "%' And ")
                    End If

                    sqlString.Append(" B.Order_Code=A.Order_Code AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y'))  ")

                    If IsChoiceDcOrder <> "Y" Then
                        sqlString.Append("And B.Effect_Date<='" & Now.ToShortDateString & "' And  ")
                        sqlString.Append(" B.Dc<>'Y'  And ")
                        sqlString.Append(" B.End_Date>= '" & Now.ToShortDateString & "' ")
                    End If


                    If OrderName <> "" Then
                        If PharmacyQueryFlag(4) = "N" Then
                            sqlString.Append(" And ( B.Order_Name like '%" & OrderName & "%'  OR ")
                            sqlString.Append("   B.Order_En_Name like '%" & OrderName & "%' OR  ")
                            sqlString.Append("   C.Favor_Name like '%" & OrderName & "%' )  ")
                        Else
                            sqlString.Append(" And ( B.Order_Name like '%" & OrderName & "%'  OR ")
                            sqlString.Append("   B.Order_En_Name like '%" & OrderName & "%' OR  ")
                            sqlString.Append("   C.Favor_Name like '%" & OrderName & "%' )  ")
                        End If

                    End If

                    If FavorCategory <> "" Then
                        sqlString.Append(" And C.Favor_Category = '" & FavorCategory & "'  ")
                    End If

                    sqlString.Append(" And C.Favor_Id =A.User_Type_Id And C.Doctor_Dept_Code =A.Doctor_Dept_Code ")
                    sqlString.Append(" And C.Order_Code=A.Order_Code  ")
                    If pvtMergeSQL <> "" Then
                        If pvtIsCoverOPD Then
                            sqlString.Append(" And (C." & pvtMergeSQL & " OR C.Is_Opd='Y') ")
                        Else
                            sqlString.Append("  And C." & pvtMergeSQL)
                        End If
                    End If

                    sqlString.Append(" Order By Order_Code ")

                    '********************************急診醫囑手術沒有套餐*******************

                    '----常用診斷----
                ElseIf FavorTypeId = "A" Then
                    If (SourceType = "E" OrElse SourceType = "I") AndAlso FavorCategory = "" Then
                        sqlString.Append("SELECT distinct '' As Favor_Category,A.Order_Code,A.Favor_Name, B.Disease_Name AS Order_Name,B.Disease_En_Name AS Order_En_Name, ")
                    Else
                        sqlString.Append("SELECT A.Favor_Category,A.Order_Code,A.Favor_Name, B.Disease_Name AS Order_Name,B.Disease_En_Name AS Order_En_Name, ")
                    End If

                    sqlString.Append("       A.Dosage,A.Dosage_Unit,A.Frequency_Code,A.Usage_Code,A.Days,A.Qty, ")
                    sqlString.Append("       A.Unit,A.Body_Site_Code As Default_Body_Site_Code,A.Specimen_Id,A.Is_Package,A.Sort_Value, ")
                    sqlString.Append("       B.Disease_Type_Id,B.Effect_Date,B.Disease_Hosp_Name,B.Majorcare_Code,B.Limit_Sex_Id, ")
                    sqlString.Append("       B.Infection_Type_Id,B.Limit_Age,B.Age_Start_Year,B.Age_Start_Month,B.Age_Start_Day, ")
                    sqlString.Append("       B.Age_End_Year,B.Age_End_Month,B.Age_End_Day,B.Is_Exclude_Labdiscount,B.Is_Chronic_Disease, ")
                    sqlString.Append("       B.Is_Severe_Disease,B.Is_Psy_Severe_Disease,B.Is_Rare_Diseases,B.Is_Major_P,B.Is_Minor_P, ")
                    sqlString.Append("       B.Is_Mcc,B.Is_Cc,End_Date ")
                    sqlString.Append("FROM OMO_Favor A WITH(NOLOCK), PUB_Disease B WITH(NOLOCK) ")
                    sqlString.Append("WHERE  ")

                    If FavorId <> "" Then
                        sqlString.Append(" A.Favor_Id = '" & FavorId & "' And A.DC<>'Y' And  ")
                    End If

                    If DoctorDeptCode <> "" Then
                        sqlString.Append(" A.Doctor_Dept_Code = '" & DoctorDeptCode & "' And ")
                    End If

                    If OrderCode <> "" Then
                        sqlString.Append(" A.Order_Code like %'" & OrderCode & "%' And ")
                    End If

                    sqlString.Append(" B.Effect_Date<='" & Now.ToShortDateString & "' And  ")
                    sqlString.Append(" B.ICD_Code=A.Order_Code  And   B.Dc<>'Y'  And ")
                    sqlString.Append(" B.End_Date>= '" & Now.ToShortDateString & "' And B.Disease_Type_id='1'  ")

                    If OrderName <> "" Then

                        If (SourceType = "E" OrElse SourceType = "I") Then
                            sqlString.Append(" And ( A.Favor_Name like '%" & OrderName & "%' OR ")
                            sqlString.Append("   B.Disease_En_Name like '%" & OrderName & "%' OR  ")
                            sqlString.Append("   B.Disease_Name like '%" & OrderName & "%'  OR")
                            sqlString.Append("   A.Order_Code like '" & OrderName & "%' )  ")
                        Else
                            sqlString.Append(" And ( A.Favor_Name like '%" & OrderName & "%' OR ")
                            sqlString.Append("   B.Disease_En_Name like '%" & OrderName & "%' OR  ")
                            sqlString.Append("   B.Disease_Name like '%" & OrderName & "%' )  ")
                        End If
                    End If

                    If FavorCategory <> "" Then
                        sqlString.Append(" And A.Favor_Category = '" & FavorCategory & "'  ")
                    End If

                    If pvtMergeSQL <> "" Then
                        If pvtIsCoverOPD Then
                            sqlString.Append(" And (A." & pvtMergeSQL & " OR A.Is_Opd='Y') ")
                        Else
                            sqlString.Append("  And A." & pvtMergeSQL)
                        End If
                    End If

                    sqlString.Append(" Order By Order_Code ")
                End If

                End If

        ElseIf FavorId = 3 Then 'For 檢驗檢查單位&檢驗檢查單查詢
            sqlString.Append("Select A.Dept_Code,A.Sheet_Code,B.Order_Code ,C.Dept_Name,A.Sheet_Name, ")
            sqlString.Append("       D.Order_En_Name ,D.Order_Name , ")
            sqlString.Append("       E.Default_Body_Site_Code, E.Default_Side_Id, E.Default_Specimen_Id As Specimen_Id, E.Default_Vessel_Id ")

            '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
            If IsChoiceDcOrder <> "Y" Then
                sqlString.Append(",'Y' As Is_Valid_Order ")
            Else
                sqlString.Append(",CASE WHEN ( '" & Now.ToShortDateString & "' >= D.Effect_Date and ")
                sqlString.Append("             '" & Now.ToShortDateString & "' <= D.End_Date ) and ")
                sqlString.Append("             D.Dc <> 'Y' THEN 'Y' ")
                sqlString.Append("       ELSE 'N'  ")
                sqlString.Append(" END As Is_Valid_Order ")

            End If

            sqlString.Append("From PUB_Sheet A WITH(NOLOCK), PUB_Sheet_Detail B WITH(NOLOCK), PUB_Department C WITH(NOLOCK), PUB_Order D WITH(NOLOCK), PUB_Order_Examination E WITH(NOLOCK) ")
            sqlString.Append("Where 1=1 And A.Dc<>'Y' And ")
            sqlString.Append("      B.Sheet_Code =A.Sheet_Code AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y')) And ")
            sqlString.Append("      C.Dept_Code =A.Dept_Code And ")
            sqlString.Append("      D.Order_Code =B.Order_Code And ")

            If IsChoiceDcOrder <> "Y" Then
                sqlString.Append("           and D.DC<>'Y' ")
                sqlString.Append("           and D.Effect_Date <= '" & Now.ToShortDateString & "' ")
                sqlString.Append("           and D.End_Date >= '" & Now.ToShortDateString & "' ")
            End If

            If pvtMergeSQL2 <> "" Then
                If pvtIsCoverOPD Then
                    sqlString.Append(" (D." & pvtMergeSQL2 & " OR D.Insu_Cover_Opd='Y') And ")
                Else
                    sqlString.Append(" D." & pvtMergeSQL2 & " And ")
                End If
            End If
            sqlString.Append("      E.Order_Code = B.Order_Code  ")

            sqlString.Append("Order By A.Dept_Code ,A.Sheet_Sort_Value,A.Sheet_Code ,B.Sheet_Detail_Sort_Value,B.Order_Code   ")

        ElseIf FavorId = 4 Then
            sqlString.Append("Select A.Dept_Code,A.Sheet_Code,A.Sheet_Name,A.Sheet_Type_Id,B.Dept_Name ")
            sqlString.Append("From PUB_Sheet A WITH(NOLOCK), PUB_Department B WITH(NOLOCK) ")
            sqlString.Append("Where 1=1 And A.Dc<>'Y' And ")
            If pvtMergeSQL2 <> "" Then
                If pvtIsCoverOPD Then
                    sqlString.Append(" (A." & pvtMergeSQL2 & " OR A.Insu_Cover_Opd='Y') And ")
                Else
                    sqlString.Append(" A." & pvtMergeSQL2 & " And ")
                End If
            End If

            sqlString.Append("      B.Dept_Code =A.Dept_Code  ")
            sqlString.Append("Order By A.Dept_Code ,A.Sheet_Sort_Value,A.Sheet_Code ")

        End If

        Try
            'If pvtQueryTimes = 1 Then
            If SourceType = "I" AndAlso FavorTypeId = "D" Then
                Using _sqlConnection As SqlConnection = getPCSDBConnection()
                    Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlString.ToString, _sqlConnection)
                    _dataAdapter.Fill(returnDS, tableName1)
                End Using
            Else
                Using _sqlConnection As SqlConnection = getConnection()
                    Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlString.ToString, _sqlConnection)
                    _dataAdapter.Fill(returnDS, tableName1)
                End Using
            End If

            'End If
        Catch ex As Exception
            Throw ex
        End Try

        Return returnDS
    End Function

    Public Function queryOMOOrderFavorSheetDept2(ByVal SourceType As String, ByVal Favor_Type_Id As String, Optional ByVal inHospCode As String = "") As DataSet
        Try
            Using sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Using command As SqlCommand = sqlConn.CreateCommand()
                    Dim pvtMergeSQL As String = ""

                    If inHospCode = "" Then

                        Select Case SourceType
                            Case "O"
                                pvtMergeSQL = " AND A.Insu_Cover_Opd = 'Y'"
                            Case "E"
                                pvtMergeSQL = " AND A.Insu_Cover_Emg = 'Y'"
                            Case "I"
                                pvtMergeSQL = " AND A.Insu_Cover_Ipd = 'Y'"
                        End Select

                        If Favor_Type_Id = "H1" Then
                            pvtMergeSQL = " AND A.Sheet_Type_Id = '1'"

                        ElseIf Favor_Type_Id = "H2" Then
                            pvtMergeSQL = " AND A.Sheet_Type_Id = '2'"

                        End If

                        command.CommandText = "SELECT A.Dept_Code, A.Sheet_Code, A.Sheet_Name, A.Sheet_Type_Id, A.Sheet_Sort_Value, B.Dept_Name" & _
                                                   ", CASE A.Dept_Code " & _
                                                        " WHEN '8200' THEN '0000'" & _
                                                        " WHEN '8100' THEN '0001'" & _
                                                        " WHEN '9100' THEN '0002'" & _
                                                        " WHEN '9300' THEN '0003'" & _
                                                        " WHEN 'ICCP' THEN '0004'" & _
                                                        " WHEN '0000' THEN '0005'" & _
                                                        " ELSE A.Dept_Code" & _
                                                    " END AS Sort_Dept" & _
                                               " FROM PUB_Sheet A WITH(NOLOCK)" & _
                                              " INNER JOIN PUB_Department B WITH(NOLOCK) ON B.Dept_Code = A.Dept_Code" & _
                                              " WHERE A.Dc = 'N'" & pvtMergeSQL & _
                                              " ORDER BY Sort_Dept, A.Sheet_Sort_Value, A.Sheet_Code"

                    Else
                        If inHospCode = "KMUH" AndAlso Favor_Type_Id = "H2" Then
                            command.CommandText = "Select Sheet_Main_Display  As Dept_Code,Sheet_Sub_Display  As Sheet_Code,A.Sheet_Sub_Display_Name  As Sheet_Name, " & _
                                                  "'      2' As Sheet_Type_Id,Sheet_Sub_Display As Sheet_Sort_Value,A.Sheet_Main_Display_Name As Dept_Name, " & _
                                                  "       Sheet_Main_Display As Sort_Dept " & _
                                                  "From PUB_Sheet_Display A " & _
                                                  "Where A.Sheet_Type_Id ='2' "
                        End If

                    End If


                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        Using ds As DataSet = New DataSet("PUB_Sheet")
                            adapter.Fill(ds, "PUB_Sheet")
                            Return ds
                        End Using
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function querySTAPackageDataByCategory(ByVal inCategory As String, ByVal inStation As String, ByVal inCategoryStr As String, ByVal inQueryStr As String) As DataSet
        Try
            Dim ds As New DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getPCSDBConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSQL As String

            pvtMergeSQL = "Where A.Is_Doctor='Y' and B.Type_Id='7411' and B.Code_Id=A.Treat_Kind_Id "

            If inCategory <> "" Then
                If inCategory <> "D1" Then
                    pvtMergeSQL &= "And A.Treat_Kind_Id='" & inCategory & "' "
                End If
            End If

            If inStation <> "" Then
                pvtMergeSQL &= "And A.Station_No='" & inStation & "' "
            End If

            If inCategoryStr <> "" Then
                pvtMergeSQL &= "And A.Treat_Kind_Id='" & inCategoryStr & "' "
            End If

            If inQueryStr <> "" Then
                pvtMergeSQL &= "And A.Package_Name like '%" & inQueryStr & "%' "
            End If

            If inCategoryStr <> "" Then
                command.CommandText = "Select * From ( " & _
                                                "Select B.Code_Name As Favor_Category,A.Package_Code As Order_Code,A.Package_Name As Favor_Name,A.Package_Name As Order_Name,A.Package_Name As Order_En_Name, " & _
                                                " '' As Dosage,'' As Dosage_Unit,'' As Frequency_Code,'' As Usage_Code,'' As Days,'' As Qty, " & _
                                                " '' As Unit,'' As Default_Body_Site_Code,'' As Specimen_Id,'' As Is_Package,B.Sort_Value As Sort_Value,  " & _
                                                " '' As Account_Id,'' As Is_Cure,'' As Cure_Type_Id,'' As Treatment_Type_Id,'' As Charge_Unit," & _
                                                " '' As Nhi_Transrate,'' As Nhi_Unit,'' As Is_Order_Check,'' As Is_Indication,'' As Fix_Order_Id," & _
                                                " '' As Is_Exclude_Drug,'' As Order_Memo, '' As Order_Flag,'' As Is_Agree_Sheet," & _
                                                " '' As Is_Nhi_Sheet,'' As Is_Nhi_Index,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,'' As Order_Type_Id,'' As Is_Prior_Review,'' As Category_View_Seq,'' As Default_Side_Id " & _
                                                "From STA_Package A,PUB_SysCode B " & _
                                                  pvtMergeSQL & _
                                                " ) AA " & _
                                                "Order By Sort_Value,Favor_Category,Order_Code  "
            Else
                command.CommandText = "Select * From ( " & _
                                "Select B.Code_Name As Favor_Category,A.Package_Code As Order_Code,A.Package_Name As Favor_Name,A.Package_Name As Order_Name,A.Package_Name As Order_En_Name, " & _
                                " '' As Dosage,'' As Dosage_Unit,'' As Frequency_Code,'' As Usage_Code,'' As Days,'' As Qty, " & _
                                " '' As Unit,'' As Default_Body_Site_Code,'' As Specimen_Id,'' As Is_Package,B.Sort_Value As Sort_Value,  " & _
                                " '' As Account_Id,'' As Is_Cure,'' As Cure_Type_Id,'' As Treatment_Type_Id,'' As Charge_Unit," & _
                                " '' As Nhi_Transrate,'' As Nhi_Unit,'' As Is_Order_Check,'' As Is_Indication,'' As Fix_Order_Id," & _
                                " '' As Is_Exclude_Drug,'' As Order_Memo, '' As Order_Flag,'' As Is_Agree_Sheet," & _
                                " '' As Is_Nhi_Sheet,'' As Is_Nhi_Index,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,'' As Order_Type_Id,'' As Is_Prior_Review,'' As Category_View_Seq,'' As Default_Side_Id " & _
                                "From STA_Package A,PUB_SysCode B " & _
                                  pvtMergeSQL & _
                                "Union " & _
                                "Select distinct B.Code_Name As Favor_Category,'' As Order_Code,'' As Favor_Name,'' As Order_Name,'' As Order_En_Name, " & _
                                " '' As Dosage,'' As Dosage_Unit,'' As Frequency_Code,'' As Usage_Code,'' As Days,'' As Qty, " & _
                                " '' As Unit,'' As Default_Body_Site_Code,'' As Specimen_Id,'' As Is_Package,B.Sort_Value As Sort_Value,  " & _
                                " '' As Account_Id,'' As Is_Cure,'' As Cure_Type_Id,'' As Treatment_Type_Id,'' As Charge_Unit," & _
                                " '' As Nhi_Transrate,'' As Nhi_Unit,'' As Is_Order_Check,'' As Is_Indication,'' As Fix_Order_Id," & _
                                " '' As Is_Exclude_Drug,'' As Order_Memo, '' As Order_Flag,'' As Is_Agree_Sheet," & _
                                " '' As Is_Nhi_Sheet,'' As Is_Nhi_Index,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,'' As Order_Type_Id,'' As Is_Prior_Review,'' As Category_View_Seq,'' As Default_Side_Id " & _
                                "From STA_Package A,PUB_SysCode B " & _
                                  pvtMergeSQL & _
                                " ) AA " & _
                                "Order By Sort_Value,Favor_Category,Order_Code  "
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("STA_Package")
                adapter.Fill(ds, "STA_Package")
            End Using

            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryOMOOrderFavorSheetDetailByLabGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, _
                                                            ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, _
                                                            ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSql, pvtMergeSql2 As String
            pvtMergeSql = ""
            pvtMergeSql2 = ""

            If SheetGroup <> "" Then
                If SheetGroup <> "不分檢體" Then
                    pvtMergeSql = "       C.Sheet_Group='" & SheetGroup & "' And "
                Else
                    pvtMergeSql = "  C.Sheet_Group is null And"
                End If
            End If


            Select Case SourceType
                Case "O"
                    pvtMergeSql2 = " F.Insu_Cover_Opd='Y' "
                Case "E"
                    '若為急診且急診病患狀態=離院(EMO_Medical_Record.Reg_Status_Id=(A, D, D1, D2)時，可搜尋到門診的項目PUB_Order.Insu_Cover_Opd='Y'
                    If queryEMOMedicalRecordGetRegStateId(ChartNo, OutpatientSn) Then
                        pvtMergeSql2 = " (F.Insu_Cover_Opd='Y' OR F.Insu_Cover_Emg='Y') "
                    Else
                        pvtMergeSql2 = " F.Insu_Cover_Emg='Y' "
                    End If
                Case "I"
                    pvtMergeSql2 = " F.Insu_Cover_Ipd='Y'  And "
                    pvtMergeSql2 &= " (F.Order_En_Name like '%" & inQueryStr & "%' or F.Order_En_Short_Name like '%" & inQueryStr & "%' or F.Order_Name like '%" & inQueryStr & "%') "
            End Select

            Dim pvtL5_SQL As String = ""

            If SheetCode = "L5" Then
                pvtL5_SQL = "       E.Vessel_Id <>'11'  And  "
            End If

            If IsChoiceDcOrder <> "Y" Then
                command.CommandText = "Select A.Dept_Code,A.Sheet_Code,A.Sheet_Name,A.Sheet_Type_Id, A.Sheet_Sort_Value , " & _
                                  "       B.Dept_Name, " & _
                                  "       (Case  When C.Sheet_Group IS NULL  THEN '不分檢體' ELSE C.Sheet_Group END) AS Sheet_Group, " & _
                                  "       (Case  When C.Sheet_Group_Name IS NULL  THEN '不分檢體' ELSE C.Sheet_Group_Name END) AS Sheet_Group_Name, " & _
                                  "       D.Order_Code, " & _
                                  "       D.Is_Indication,D.Separate_Mark,D.Sheet_Detail_Sort_Value, " & _
                                  "       E.Vessel_Id,'' as Default_Body_Site_Code,'' as Default_Side_Id, " & _
                                  "       F.Order_En_Name,F.Order_Name,F.Order_En_Short_Name,F.Order_Short_Name,F.Order_Type_Id ,E.Specimen_Id,G.Code_Name As Vessel_Name,'' As Nhi_Price,'' As Own_Price, " & _
                                  "       '' As  Option_Order, " & _
                                  "       'Y' As Is_Valid_Order " & _
                                  "From  PUB_Sheet A,PUB_Department B, " & _
                                  "      PUB_Sheet_Detail D Left Join PUB_Sheet_Group C " & _
                                  "      ON (D.Sheet_Code =C.Sheet_Code And D.Order_Code =C.Order_Code ) " & _
                                  "      LEFT OUTER JOIN PUB_Order_Mapping_Specimen E  " & _
                                  "      ON(C.Order_Code =E.Order_Code AND C.Sheet_Group =E.Specimen_Id ) " & _
                                  "      LEFT JOIN PUB_SysCode G ON G.Type_Id='47' And G.Code_Id=E.Vessel_Id " & _
                                  "      ,PUB_Order F " & _
                                  "Where  A.Sheet_Code ='" & SheetCode & "' And A.Dc<>'Y' And  B.Dept_Code =A.Dept_Code And " & _
                                          pvtMergeSql & _
                                  "       D.Sheet_Code=A.Sheet_Code And " & _
                                  "       D.Dc<>'Y' And " & _
                                          pvtL5_SQL & _
                                  "       F.Order_Code=C.Order_Code And F.Effect_Date<='" & Now.ToShortDateString & "' And F.End_Date >='" & Now.ToShortDateString & "' AND (F.Dc = 'N' or (F.Dc='Y' and F.Is_Alternative='Y')) And " & pvtMergeSql2 & _
                                  "Order by C.Sheet_Group,D.Sheet_Detail_Sort_Value,D.Order_Code "
            Else
                command.CommandText = "Select A.Dept_Code,A.Sheet_Code,A.Sheet_Name,A.Sheet_Type_Id, A.Sheet_Sort_Value , " & _
                                  "       B.Dept_Name, " & _
                                  "       (Case  When C.Sheet_Group IS NULL  THEN '不分檢體' ELSE C.Sheet_Group END) AS Sheet_Group, " & _
                                  "       (Case  When C.Sheet_Group_Name IS NULL  THEN '不分檢體' ELSE C.Sheet_Group_Name END) AS Sheet_Group_Name, " & _
                                  "       D.Order_Code, " & _
                                  "       D.Is_Indication,D.Separate_Mark,D.Sheet_Detail_Sort_Value, " & _
                                  "       E.Vessel_Id,'' as Default_Body_Site_Code,'' as Default_Side_Id, " & _
                                  "       F.Order_En_Name,F.Order_Name,F.Order_En_Short_Name,F.Order_Short_Name,F.Order_Type_Id ,E.Specimen_Id,G.Code_Name As Vessel_Name,'' As Nhi_Price,'' As Own_Price, " & _
                                  "       '' As  Option_Order, " & _
                                  "       CASE WHEN ( '" & Now.ToShortDateString & "' >= F.Effect_Date and " & _
                                  "                   '" & Now.ToShortDateString & "' <= F.End_Date ) and " & _
                                  "                   F.Dc <> 'Y' THEN 'Y' " & _
                                  "             ELSE 'N'  " & _
                                  "       END As Is_Valid_Order " & _
                                  "From  PUB_Sheet A,PUB_Department B, " & _
                                  "      PUB_Sheet_Detail D Left Join PUB_Sheet_Group C " & _
                                  "      ON (D.Sheet_Code =C.Sheet_Code And D.Order_Code =C.Order_Code ) " & _
                                  "      LEFT OUTER JOIN PUB_Order_Mapping_Specimen E  " & _
                                  "      ON(C.Order_Code =E.Order_Code AND C.Sheet_Group =E.Specimen_Id ) " & _
                                  "      LEFT JOIN PUB_SysCode G ON G.Type_Id='47' And G.Code_Id=E.Vessel_Id " & _
                                  "      ,PUB_Order F " & _
                                  "Where  A.Sheet_Code ='" & SheetCode & "' And A.Dc<>'Y' And  B.Dept_Code =A.Dept_Code And " & _
                                          pvtMergeSql & _
                                  "       D.Sheet_Code=A.Sheet_Code And " & _
                                  "       D.Dc<>'Y' And " &
                                          pvtL5_SQL & _
                                  "       F.Order_Code=C.Order_Code AND (F.Dc = 'N' or (F.Dc='Y' and F.Is_Alternative='Y'))  And " & pvtMergeSql2 & _
                                  "Order by C.Sheet_Group,D.Sheet_Detail_Sort_Value,D.Order_Code "

            End If
            

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryOMOOrderFavorSheetDetailByExamGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, _
                                                             ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, _
                                                             ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSql, pvtMergeSql2 As String
            pvtMergeSql = ""
            pvtMergeSql2 = ""

            If SheetGroup <> "" Then
                If SheetGroup <> "不分部位" Then
                    pvtMergeSql = "       C.Sheet_Group='" & SheetGroup & "' And "
                Else
                    pvtMergeSql = "  C.Sheet_Group is null And"
                End If
            End If


            Select Case SourceType
                Case "O"
                    pvtMergeSql2 = " F.Insu_Cover_Opd='Y' "
                Case "E"
                    '若為急診且急診病患狀態=離院(EMO_Medical_Record.Reg_Status_Id=(A, D, D1, D2)時，可搜尋到門診的項目PUB_Order.Insu_Cover_Opd='Y'
                    If queryEMOMedicalRecordGetRegStateId(ChartNo, OutpatientSn) Then
                        pvtMergeSql2 = " (F.Insu_Cover_Opd='Y' OR F.Insu_Cover_Emg='Y') "
                    Else
                        pvtMergeSql2 = " F.Insu_Cover_Emg='Y' "
                    End If
                Case "I"
                    pvtMergeSql2 = " F.Insu_Cover_Ipd='Y' "
                    pvtMergeSql2 &= " And (F.Order_En_Name like '%" & inQueryStr & "%' or F.Order_En_Short_Name like '%" & inQueryStr & "%' or F.Order_Name like '%" & inQueryStr & "%') "
            End Select

            If IsChoiceDcOrder <> "Y" Then
                command.CommandText = "Select A.Dept_Code,A.Sheet_Code,A.Sheet_Name,A.Sheet_Type_Id, A.Sheet_Sort_Value , " & _
                                  "       B.Dept_Name, " & _
                                  "       (Case  When C.Sheet_Group IS NULL  THEN '不分部位' ELSE C.Sheet_Group END) AS Sheet_Group, " & _
                                  "       (Case  When C.Sheet_Group_Name IS NULL  THEN '不分部位' ELSE C.Sheet_Group_Name END) AS Sheet_Group_Name, " & _
                                  "       D.Order_Code, " & _
                                  "       D.Is_Indication,D.Separate_Mark,D.Sheet_Detail_Sort_Value, " & _
                                  "       E.Default_Body_Site_Code,E.Default_Side_Id, " & _
                                  "       F.Order_En_Name,F.Order_Name,F.Order_En_Short_Name,F.Order_Short_Name,F.Order_Type_Id,'' as Specimen_Id,'' as Vessel_Id ,'' As Nhi_Price,'' As Own_Price, " & _
                                  "       '' As Option_Order, " & _
                                  "       'Y' As Is_Valid_Order  " & _
                                  "From  PUB_Sheet A,PUB_Department B, " & _
                                  "      PUB_Sheet_Detail D Left Join PUB_Sheet_Group C " & _
                                  "      ON (D.Sheet_Code =C.Sheet_Code And D.Order_Code =C.Order_Code ) " & _
                                  "      LEFT OUTER JOIN PUB_Order_Examination E  " & _
                                  "      ON(C.Order_Code =E.Order_Code And C.Sheet_Group =E.Default_Main_Body_Site_Code) " & _
                                  "     ,PUB_Order F " & _
                                  "Where  A.Sheet_Code ='" & SheetCode & "' And A.Dc<>'Y' And  B.Dept_Code =A.Dept_Code And " & _
                                          pvtMergeSql & _
                                  "       D.Sheet_Code=A.Sheet_Code And " & _
                                  "       D.Dc<>'Y' And " & _
                                  "       F.Order_Code=D.Order_Code And F.Effect_Date<='" & Now.ToShortDateString & "' And F.End_Date >='" & Now.ToShortDateString & "' AND (F.Dc = 'N' or (F.Dc='Y' and F.Is_Alternative='Y')) And " & pvtMergeSql2 & _
                                  "Order by Sheet_Group,D.Sheet_Detail_Sort_Value,D.Order_Code "
            Else
                command.CommandText = "Select A.Dept_Code,A.Sheet_Code,A.Sheet_Name,A.Sheet_Type_Id, A.Sheet_Sort_Value , " & _
                                  "       B.Dept_Name, " & _
                                  "       (Case  When C.Sheet_Group IS NULL  THEN '不分部位' ELSE C.Sheet_Group END) AS Sheet_Group, " & _
                                  "       (Case  When C.Sheet_Group_Name IS NULL  THEN '不分部位' ELSE C.Sheet_Group_Name END) AS Sheet_Group_Name, " & _
                                  "       D.Order_Code, " & _
                                  "       D.Is_Indication,D.Separate_Mark,D.Sheet_Detail_Sort_Value, " & _
                                  "       E.Default_Body_Site_Code,E.Default_Side_Id, " & _
                                  "       F.Order_En_Name,F.Order_Name,F.Order_En_Short_Name,F.Order_Short_Name,F.Order_Type_Id,'' as Specimen_Id,'' as Vessel_Id ,'' As Nhi_Price,'' As Own_Price, " & _
                                  "       '' As Option_Order, " & _
                                  "       CASE WHEN ( '" & Now.ToShortDateString & "' >= F.Effect_Date and " & _
                                  "                   '" & Now.ToShortDateString & "' <= F.End_Date ) and " & _
                                  "                   D.Dc <> 'Y' THEN 'Y' " & _
                                  "             ELSE 'N'  " & _
                                  "From  PUB_Sheet A,PUB_Department B, " & _
                                  "      PUB_Sheet_Detail D Left Join PUB_Sheet_Group C " & _
                                  "      ON (D.Sheet_Code =C.Sheet_Code And D.Order_Code =C.Order_Code ) " & _
                                  "      LEFT OUTER JOIN PUB_Order_Examination E  " & _
                                  "      ON(C.Order_Code =E.Order_Code And C.Sheet_Group =E.Default_Main_Body_Site_Code) " & _
                                  "     ,PUB_Order F " & _
                                  "Where  A.Sheet_Code ='" & SheetCode & "' And A.Dc<>'Y' And  B.Dept_Code =A.Dept_Code And " & _
                                          pvtMergeSql & _
                                  "       D.Sheet_Code=A.Sheet_Code And " & _
                                  "       D.Dc<>'Y' AND (F.Dc = 'N' or (F.Dc='Y' and F.Is_Alternative='Y')) And " & pvtMergeSql2 & _
                                  "Order by Sheet_Group,D.Sheet_Detail_Sort_Value,D.Order_Code "

            End If


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryOMOOrderFavorSheetDetailByExamGroupForKMUH(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, _
                                                                    ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, _
                                                                    ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSql, pvtMergeSql2 As String
            pvtMergeSql = ""
            pvtMergeSql2 = ""

            Select Case SourceType
                Case "O"
                    pvtMergeSql = " and D.Insu_Cover_Opd<>'H' "
                    pvtMergeSql2 = " D.Insu_Cover_Opd='Y' "
                Case "E"
                    pvtMergeSql = " and D.Insu_Cover_Emg<>'H' "
                    pvtMergeSql2 = " D.Insu_Cover_Emg='Y' "

                Case "I"
                    pvtMergeSql = " and D.Insu_Cover_Ipd<>'H' "
                    pvtMergeSql2 = " D.Insu_Cover_Ipd='Y' "
                    pvtMergeSql2 &= " And (D.Order_En_Name like '%" & inQueryStr & "%' or D.Order_En_Short_Name like '%" & inQueryStr & "%' or D.Order_Name like '%" & inQueryStr & "%') "

            End Select

            If IsChoiceDcOrder <> "Y" Then
                command.CommandText = "Select A.Sheet_Main_Display As Dept_Code,A.Sheet_Sub_Display As Sheet_Code,A.Sheet_Sub_Display_Name As Sheet_Name, " & _
                                  "       '2' As Sheet_Type_Id,A.Sheet_Sub_Display Sheet_Sort_Value , A.Sheet_Main_Display_Name As Dept_Name, " & _
                                  "       '' AS Sheet_Group, '' AS Sheet_Group_Name, C.Order_Code, C.Is_Indication,C.Separate_Mark,C.Sheet_Detail_Sort_Value, " & _
                                  "       B.Default_Body_Site_Code As Default_Body_Site_Code,B.Default_Side_Id As Default_Side_Id, " & _
                                  "       B.Order_Display_Name AS Order_En_Name,D.Order_Name,D.Order_En_Short_Name,D.Order_Short_Name,D.Order_Type_Id, " & _
                                  "       '' as Specimen_Id,'' as Vessel_Id ,'' As Nhi_Price,'' As Own_Price, " & _
                                  "       '' As Option_Order , B.Default_Main_Body_Site_Code,B.Default_Body_Site_Code, " & _
                                  "       'Y' As Is_Valid_Order  " & _
                                  "From   PUB_Sheet_Display A,PUB_Sheet_Display_Order B " & _
                                  "             INNER Join PUB_Sheet_Detail C ON C.Order_Code = B.Order_Code and C.DC<>'Y' " & _
                                  "             INNER Join PUb_Order D ON D.Order_Code = B.Order_Code AND (D.Dc = 'N' or (D.Dc='Y' and D.Is_Alternative='Y')) " & _
                                  "                                      and D.Effect_Date<='" & Now.ToShortDateString & "' And D.End_Date >='" & Now.ToShortDateString & "' And " & pvtMergeSql2 & _
                                  "Where  A.Sheet_Type_Id='2' and A.Sheet_Main_Display ='" & SheetGroup & "' and A.Sheet_Sub_Display ='" & SheetCode & "' " & _
                                  "       and B.Sheet_Sub_Display = A.Sheet_Sub_Display " & pvtMergeSql & _
                                  " Order By B.Display_Sort_Value       "
            Else
                command.CommandText = "Select A.Sheet_Main_Display As Dept_Code,A.Sheet_Sub_Display As Sheet_Code,A.Sheet_Sub_Display_Name As Sheet_Name, " & _
                                  "       '2' As Sheet_Type_Id,A.Sheet_Sub_Display Sheet_Sort_Value , A.Sheet_Main_Display_Name As Dept_Name, " & _
                                  "       '' AS Sheet_Group, '' AS Sheet_Group_Name, C.Order_Code, C.Is_Indication,C.Separate_Mark,C.Sheet_Detail_Sort_Value, " & _
                                  "       B.Default_Body_Site_Code As Default_Body_Site_Code,B.Default_Side_Id As Default_Side_Id, " & _
                                  "       B.Order_Display_Name AS Order_En_Name,D.Order_Name,D.Order_En_Short_Name,D.Order_Short_Name,D.Order_Type_Id, " & _
                                  "       '' as Specimen_Id,'' as Vessel_Id ,'' As Nhi_Price,'' As Own_Price, " & _
                                  "       '' As Option_Order , B.Default_Main_Body_Site_Code,B.Default_Body_Site_Code, " & _
                                  "       CASE WHEN ( '" & Now.ToShortDateString & "' >= D.Effect_Date and " & _
                                  "                   '" & Now.ToShortDateString & "' <= D.End_Date ) and " & _
                                  "                   D.Dc <> 'Y' THEN 'Y' " & _
                                  "             ELSE 'N'  " & _
                                  "       END As Is_Valid_Order " & _
                                  "From   PUB_Sheet_Display A,PUB_Sheet_Display_Order B " & _
                                  "             INNER Join PUB_Sheet_Detail C ON C.Order_Code = B.Order_Code and C.DC<>'Y' " & _
                                  "             INNER Join PUb_Order D ON D.Order_Code = B.Order_Code AND (D.Dc = 'N' or (D.Dc='Y' and D.Is_Alternative='Y')) and  " & pvtMergeSql2 & _
                                  "Where  A.Sheet_Type_Id='2' and A.Sheet_Main_Display ='" & SheetGroup & "' and A.Sheet_Sub_Display ='" & SheetCode & "' " & _
                                  "       and B.Sheet_Sub_Display = A.Sheet_Sub_Display " & pvtMergeSql & _
                                  " Order By B.Display_Sort_Value       "

            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function querySTAPackageDataCategory(ByVal inCategory As String, ByVal inStation As String) As DataSet
        Try
            Dim ds As New DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getPCSDBConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSQL As String

            pvtMergeSQL = "Where A.Is_Doctor='Y' and B.Type_Id='7411' and B.Code_Id=A.Treat_Kind_Id "

            If inCategory <> "" Then
                If inCategory <> "D1" Then
                    pvtMergeSQL &= "And A.Treat_Kind_Id='" & inCategory & "' "
                End If
            End If

            If inStation <> "" Then
                pvtMergeSQL &= "And A.Station_No='" & inStation & "' "
            End If

            command.CommandText = " Select distinct B.Code_Name ,B.Code_Id,B.Sort_Value " & _
                                  " From STA_Package A,PUB_SysCode B " & _
                                  pvtMergeSQL & _
                                  " Order By B.Sort_Value"
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("STA_Package")
                adapter.Fill(ds, "STA_Package")
            End Using

            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryOMOOrderFavorSheetDetailByLab2(ByVal SourceType As String, ByVal SheetCode As String, _
                                                        ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSQL As String
            pvtMergeSQL = ""

            Select Case SourceType
                Case "O"
                    pvtMergeSQL = " F.Insu_Cover_Opd='Y'  "
                Case "E"
                    pvtMergeSQL = " F.Insu_Cover_Emg='Y'  "
                Case "I"
                    pvtMergeSQL = " F.Insu_Cover_Ipd='Y'  "
            End Select

            If IsChoiceDcOrder <> "Y" Then
                command.CommandText = "Select A.Dept_Code,A.Sheet_Code,A.Sheet_Name,A.Sheet_Type_Id, A.Sheet_Sort_Value , " & _
                                  "       B.Dept_Name, " & _
                                  "       (Case  When C.Sheet_Group IS NULL  THEN '不分檢體' ELSE C.Sheet_Group END) AS Sheet_Group, " & _
                                  "       (Case  When C.Sheet_Group_Name IS NULL  THEN '不分檢體' ELSE C.Sheet_Group_Name END) AS Sheet_Group_Name, " & _
                                  "       D.Order_Code, " & _
                                  "       D.Is_Indication,D.Separate_Mark,D.Sheet_Detail_Sort_Value, " & _
                                  "       E.Vessel_Id,'' as Default_Body_Site_Code,'' as Default_Side_Id, " & _
                                  "       F.Order_En_Name,F.Order_Name,F.Order_En_Short_Name,F.Order_Short_Name,F.Order_Type_Id,F.Treatment_Type_Id ,E.Specimen_Id,G.Code_Name As Vessel_Name,'' As Nhi_Price,'' As Own_Price, " & _
                                  "       'Y' As Is_Valid_Order " & _
                                  "From  PUB_Sheet A,PUB_Department B, " & _
                                  "      PUB_Sheet_Detail D Left Join PUB_Sheet_Group C " & _
                                  "      ON (D.Sheet_Code =C.Sheet_Code And D.Order_Code =C.Order_Code ) " & _
                                  "      LEFT OUTER JOIN PUB_Order_Mapping_Specimen E  " & _
                                  "      ON(C.Order_Code =E.Order_Code AND C.Sheet_Group =E.Specimen_Id  ) " & _
                                  "      Left Join PUB_SysCode G ON G.Type_Id='47' And G.Code_Id=E.Vessel_Id " & _
                                  "      ,PUB_Order F " & _
                                  "Where  A.Sheet_Code ='" & SheetCode & "' And A.Dc<>'Y' And  B.Dept_Code =A.Dept_Code And " & _
                                  "       D.Sheet_Code=A.Sheet_Code And " & _
                                  "       D.Dc<>'Y' And " & _
                                  "       F.Order_Code=C.Order_Code And F.Effect_Date<='" & Now.ToShortDateString & "' And F.End_Date >='" & Now.ToShortDateString & "' AND (F.Dc = 'N' or (F.Dc='Y' and F.Is_Alternative='Y')) And " & pvtMergeSQL & _
                                  "Order by C.Sheet_Group,D.Sheet_Detail_Sort_Value,D.Order_Code "
            Else
                command.CommandText = "Select A.Dept_Code,A.Sheet_Code,A.Sheet_Name,A.Sheet_Type_Id, A.Sheet_Sort_Value , " & _
                                  "       B.Dept_Name, " & _
                                  "       (Case  When C.Sheet_Group IS NULL  THEN '不分檢體' ELSE C.Sheet_Group END) AS Sheet_Group, " & _
                                  "       (Case  When C.Sheet_Group_Name IS NULL  THEN '不分檢體' ELSE C.Sheet_Group_Name END) AS Sheet_Group_Name, " & _
                                  "       D.Order_Code, " & _
                                  "       D.Is_Indication,D.Separate_Mark,D.Sheet_Detail_Sort_Value, " & _
                                  "       E.Vessel_Id,'' as Default_Body_Site_Code,'' as Default_Side_Id, " & _
                                  "       F.Order_En_Name,F.Order_Name,F.Order_En_Short_Name,F.Order_Short_Name,F.Order_Type_Id,F.Treatment_Type_Id ,E.Specimen_Id,G.Code_Name As Vessel_Name,'' As Nhi_Price,'' As Own_Price, " & _
                                  "       CASE WHEN ( '" & Now.ToShortDateString & "' >= F.Effect_Date and " & _
                                  "                   '" & Now.ToShortDateString & "' <= F.End_Date ) and " & _
                                  "                   F.Dc <> 'Y' THEN 'Y' " & _
                                  "             ELSE 'N'  " & _
                                  "       END As Is_Valid_Order " & _
                                  "From  PUB_Sheet A,PUB_Department B, " & _
                                  "      PUB_Sheet_Detail D Left Join PUB_Sheet_Group C " & _
                                  "      ON (D.Sheet_Code =C.Sheet_Code And D.Order_Code =C.Order_Code ) " & _
                                  "      LEFT OUTER JOIN PUB_Order_Mapping_Specimen E  " & _
                                  "      ON(C.Order_Code =E.Order_Code AND C.Sheet_Group =E.Specimen_Id  ) " & _
                                  "      Left Join PUB_SysCode G ON G.Type_Id='47' And G.Code_Id=E.Vessel_Id " & _
                                  "      ,PUB_Order F " & _
                                  "Where  A.Sheet_Code ='" & SheetCode & "' And A.Dc<>'Y' And  B.Dept_Code =A.Dept_Code And " & _
                                  "       D.Sheet_Code=A.Sheet_Code And " & _
                                  "       D.Dc<>'Y' And " & _
                                  "       F.Order_Code=C.Order_Code AND (F.Dc = 'N' or (F.Dc='Y' and F.Is_Alternative='Y')) And " & pvtMergeSQL & _
                                  "Order by C.Sheet_Group,D.Sheet_Detail_Sort_Value,D.Order_Code "

            End If
            

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryOMOOrderFavorSheetDetailByExam2(ByVal SourceType As String, ByVal SheetCode As String, _
                                                         ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSQL As String = ""


            Select Case SourceType
                Case "O"
                    pvtMergeSQL = " F.Insu_Cover_Opd='Y' "
                Case "E"
                    pvtMergeSQL = " F.Insu_Cover_Emg='Y' "
                Case "I"
                    pvtMergeSQL = " F.Insu_Cover_Ipd='Y' "
            End Select

            If IsChoiceDcOrder <> "Y" Then
                command.CommandText = "Select A.Dept_Code,A.Sheet_Code,A.Sheet_Name,A.Sheet_Type_Id, A.Sheet_Sort_Value , " & _
                                  "       B.Dept_Name, " & _
                                  "       (Case  When C.Sheet_Group IS NULL  THEN '不分部位' ELSE C.Sheet_Group END) AS Sheet_Group, " & _
                                  "       (Case  When C.Sheet_Group_Name IS NULL  THEN '不分部位' ELSE C.Sheet_Group_Name END) AS Sheet_Group_Name, " & _
                                  "       D.Order_Code, " & _
                                  "       D.Is_Indication,D.Separate_Mark,D.Sheet_Detail_Sort_Value, " & _
                                  "       E.Default_Body_Site_Code,E.Default_Side_Id, " & _
                                  "       F.Order_En_Name,F.Order_Name,F.Order_En_Short_Name,F.Order_Short_Name,F.Order_Type_Id,F.Treatment_Type_Id,'' as Specimen_Id,'' as Vessel_Id ,'' As Nhi_Price,'' As Own_Price, " & _
                                  "       'Y' As Is_Valid_Order  " & _
                                  "From  PUB_Sheet A,PUB_Department B, " & _
                                  "      PUB_Sheet_Detail D Left Join PUB_Sheet_Group C " & _
                                  "      ON (D.Sheet_Code =C.Sheet_Code And D.Order_Code =C.Order_Code ) " & _
                                  "      LEFT OUTER JOIN PUB_Order_Examination E  " & _
                                  "      ON(C.Order_Code =E.Order_Code And C.Sheet_Group =E.Default_Main_Body_Site_Code) " & _
                                  "     ,PUB_Order F " & _
                                  "Where  A.Sheet_Code ='" & SheetCode & "' And A.Dc<>'Y' And  B.Dept_Code =A.Dept_Code And " & _
                                  "       D.Sheet_Code=A.Sheet_Code And " & _
                                  "       D.Dc<>'Y' And " & _
                                  "       F.Order_Code=D.Order_Code And F.Effect_Date<='" & Now.ToShortDateString & "' And F.End_Date >='" & Now.ToShortDateString & "' AND (F.Dc = 'N' or (F.Dc='Y' and F.Is_Alternative='Y')) And " & pvtMergeSQL & _
                                  "Order by Sheet_Group,D.Sheet_Detail_Sort_Value,D.Order_Code "
            Else
                command.CommandText = "Select A.Dept_Code,A.Sheet_Code,A.Sheet_Name,A.Sheet_Type_Id, A.Sheet_Sort_Value , " & _
                                  "       B.Dept_Name, " & _
                                  "       (Case  When C.Sheet_Group IS NULL  THEN '不分部位' ELSE C.Sheet_Group END) AS Sheet_Group, " & _
                                  "       (Case  When C.Sheet_Group_Name IS NULL  THEN '不分部位' ELSE C.Sheet_Group_Name END) AS Sheet_Group_Name, " & _
                                  "       D.Order_Code, " & _
                                  "       D.Is_Indication,D.Separate_Mark,D.Sheet_Detail_Sort_Value, " & _
                                  "       E.Default_Body_Site_Code,E.Default_Side_Id, " & _
                                  "       F.Order_En_Name,F.Order_Name,F.Order_En_Short_Name,F.Order_Short_Name,F.Order_Type_Id,F.Treatment_Type_Id,'' as Specimen_Id,'' as Vessel_Id ,'' As Nhi_Price,'' As Own_Price, " & _
                                  "       CASE WHEN ( '" & Now.ToShortDateString & "' >= F.Effect_Date and " & _
                                  "                   '" & Now.ToShortDateString & "' <= F.End_Date ) and " & _
                                  "                   F.Dc <> 'Y' THEN 'Y' " & _
                                  "             ELSE 'N'  " & _
                                  "       END As Is_Valid_Order " & _
                                  "From  PUB_Sheet A,PUB_Department B, " & _
                                  "      PUB_Sheet_Detail D Left Join PUB_Sheet_Group C " & _
                                  "      ON (D.Sheet_Code =C.Sheet_Code And D.Order_Code =C.Order_Code ) " & _
                                  "      LEFT OUTER JOIN PUB_Order_Examination E  " & _
                                  "      ON(C.Order_Code =E.Order_Code And C.Sheet_Group =E.Default_Main_Body_Site_Code) " & _
                                  "     ,PUB_Order F " & _
                                  "Where  A.Sheet_Code ='" & SheetCode & "' And A.Dc<>'Y' And  B.Dept_Code =A.Dept_Code And " & _
                                  "       D.Sheet_Code=A.Sheet_Code And " & _
                                  "       D.Dc<>'Y' AND (F.Dc = 'N' or (F.Dc='Y' and F.Is_Alternative='Y')) And " & pvtMergeSQL & _
                                  "Order by Sheet_Group,D.Sheet_Detail_Sort_Value,D.Order_Code "

            End If
            

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryOMOOrderFavorDetailOrder3(ByVal SourceType As String, _
                                                   ByVal OrderTypeId As String, _
                                                   ByVal DrugType As String, _
                                                   ByVal FavorId As String, _
                                                   ByVal DoctorDeptCode As String, _
                                                   ByVal PackageCode As String, _
                                                   ByVal ChartNo As String, _
                                                   ByVal OutpatientSn As String, _
                                                   ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSQL As String = ""

            Select Case SourceType
                Case "O"
                    pvtMergeSQL = " B.Insu_Cover_Opd='Y' "
                Case "E"
                    '若為急診且急診病患狀態=離院(EMO_Medical_Record.Reg_Status_Id=(A, D, D1, D2)時，可搜尋到門診的項目PUB_Order.Insu_Cover_Opd='Y'
                    If OrderTypeId = "H" AndAlso queryEMOMedicalRecordGetRegStateId(ChartNo, OutpatientSn) Then
                        pvtMergeSQL = " (B.Insu_Cover_Opd='Y' OR B.Insu_Cover_Emg='Y') "
                    Else
                        pvtMergeSQL = " B.Insu_Cover_Emg='Y' "
                    End If
                Case "I"
                    pvtMergeSQL = " B.Insu_Cover_Ipd='Y' "
            End Select
            If OrderTypeId <> "E" Then

                command.CommandText = "Select A.*,A.Body_Site_Code As Default_Body_Site_Code,B.Order_Name,B.Order_En_Name,B.Order_Type_Id,'' As Nhi_Price,'' As Own_Price "

                If OrderTypeId = "D" Then
                    command.CommandText &= "       ,'' AS Default_Side_Id "
                End If

                If (SourceType = "E" OrElse SourceType = "I") AndAlso OrderTypeId = "H" Then
                    command.CommandText &= " ,(SELECT CASE A.Specimen_Id WHEN '' Then D.Sheet_Group WHEN Null Then D.Sheet_Group ELSE C.Sheet_Group END) AS Sheet_Group "
                    command.CommandText &= " ,(SELECT CASE A.Specimen_Id WHEN '' Then D.Sheet_Group_Name WHEN Null Then D.Sheet_Group_Name ELSE C.Sheet_Group_Name END) AS Sheet_Group_Name "
                End If

                '2016-07-19 Add By Alan-選取停用醫令替代藥處理
                If IsChoiceDcOrder <> "Y" Then
                    command.CommandText &= ",'Y' As Is_Valid_Order "
                    command.CommandText &= "From  OMO_Package_Content A  " & _
                                       "       INNER JOIN PUB_Order B ON B.Order_Code=A.Order_Code AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y')) " & _
                                       "      Left Join PUB_Sheet_Group C ON ( C.Sheet_Group=A.Specimen_Id and C.Sheet_Code =SubString(B.Order_Code,0,5) And C.Order_Code =B.Order_Code ) " & _
                                       "      Left Join PUB_Sheet_Group D ON ( D.Sheet_Group=A.Body_Site_Code and D.Sheet_Code =SubString(B.Order_Code,0,5) And D.Order_Code =B.Order_Code ) " & _
                                       "Where RTrim(A.User_Type_Id) ='" & FavorId & "' And " & _
                                       "      RTrim(Doctor_Dept_Code)='" & DoctorDeptCode & "' And " & _
                                       "      Rtrim(Package_Code) ='" & PackageCode & "' And " & _
                                       "      Rtrim(Package_Type_Code) ='" & OrderTypeId & "' And " & _
                                       "      A.DC<>'Y' And A.Cancel<>'Y' And " & _
                                       "      B.Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "' And " & _
                                       "      B.End_Date>='" & Now.ToString("yyyy/MM/dd") & "' And B.DC<>'Y' And " & pvtMergeSQL

                Else
                    command.CommandText &= ",CASE WHEN ( '" & Now.ToShortDateString & "' >= B.Effect_Date and "
                    command.CommandText &= "             '" & Now.ToShortDateString & "' <= B.End_Date ) and "
                    command.CommandText &= "             B.Dc <> 'Y' THEN 'Y' "
                    command.CommandText &= "       ELSE 'N'  "
                    command.CommandText &= " END As Is_Valid_Order "

                    command.CommandText &= "From  OMO_Package_Content A  " & _
                                       "       INNER JOIN PUB_Order B ON B.Order_Code=A.Order_Code AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y'))  " & _
                                       "      Left Join PUB_Sheet_Group C ON ( C.Sheet_Group=A.Specimen_Id and C.Sheet_Code =SubString(B.Order_Code,0,5) And C.Order_Code =B.Order_Code ) " & _
                                       "      Left Join PUB_Sheet_Group D ON ( D.Sheet_Group=A.Body_Site_Code and D.Sheet_Code =SubString(B.Order_Code,0,5) And D.Order_Code =B.Order_Code ) " & _
                                       "Where RTrim(A.User_Type_Id) ='" & FavorId & "' And " & _
                                       "      RTrim(Doctor_Dept_Code)='" & DoctorDeptCode & "' And " & _
                                       "      Rtrim(Package_Code) ='" & PackageCode & "' And " & _
                                       "      Rtrim(Package_Type_Code) ='" & OrderTypeId & "' And " & _
                                       "      A.DC<>'Y' And A.Cancel<>'Y' And " & pvtMergeSQL

                End If

            Else
                command.CommandText = "Select A.Package_Content,A.Dosage,A.Dosage_Unit,A.Frequency_Code,A.Usage_Code,A.Days,A.Times," & _
                                      "       A.User_Type_Id,A.Doctor_Dept_Code,A.Package_Category,A.Package_Code,A.Package_Type_Code," & _
                                      "       A.Package_No,A.Order_Code,A.Qty,A.Unit,A.Body_Site_Code,A.Specimen_Id, " & _
                                      "       A.Consumption_Dept,A.Is_Force,A.Dc,A.Create_User,A.Create_Time,A.Modified_User,A.Modified_Time, " & _
                                      "       A.Cancel,A.Cancel_User,A.Cancel_Time , " & _
                                      "       B.Order_Name,B.Order_En_Name,B.Order_Type_Id,'' As Nhi_Price,'' As Own_Price, " & _
                                      "       C.OPD_Lack_Id, C.IPD_Lack_Id, C.EMG_Lack_Id, C.Is_Total_Qty, " & _
                                      "       C.Class_Code  ,'' As Property_Id ,C.Pharmacy_12_Code,'' as Remark "
                Select Case DrugType
                    Case "1"
                        command.CommandText &= " ,'E' As Drug_Type "
                    Case "2"
                        command.CommandText &= " ,'T' As Drug_Type "
                    Case "3"
                        command.CommandText &= " ,'C' As Drug_Type "
                    Case "4"
                        command.CommandText &= " ,'' As Drug_Type "
                End Select

                '2016-07-19 Add By Alan-選取停用醫令替代藥處理
                If IsChoiceDcOrder <> "Y" Then
                    command.CommandText &= ",'Y' As Is_Valid_Order "

                    command.CommandText &= "From  OMO_Package_Content A,PUB_Order B,OPH_Pharmacy_Base C " & _
                                       "Where RTrim(A.User_Type_Id) ='" & FavorId & "' And " & _
                                       "      RTrim(Doctor_Dept_Code)='" & DoctorDeptCode & "' And " & _
                                       "      Rtrim(Package_Code) ='" & PackageCode & "' And " & _
                                       "      Rtrim(Package_Type_Code) ='" & OrderTypeId & "' And " & _
                                       "      A.DC<>'Y' And A.Cancel<>'Y' And " & _
                                       "      B.Order_Code=A.Order_Code And B.Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "' And " & _
                                       "      B.End_Date>='" & Now.ToString("yyyy/MM/dd") & "'AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y')) And " & pvtMergeSQL & " And " & _
                                       "      C.Order_Code=A.Order_Code And C.DC<>'Y' "

                Else
                    command.CommandText &= ",CASE WHEN ( '" & Now.ToShortDateString & "' >= B.Effect_Date and "
                    command.CommandText &= "             '" & Now.ToShortDateString & "' <= B.End_Date ) and "
                    command.CommandText &= "             B.Dc <> 'Y' THEN 'Y' "
                    command.CommandText &= "       ELSE 'N'  "
                    command.CommandText &= " END As Is_Valid_Order "

                    command.CommandText &= "From  OMO_Package_Content A,PUB_Order B,OPH_Pharmacy_Base C " & _
                                       "Where RTrim(A.User_Type_Id) ='" & FavorId & "' And " & _
                                       "      RTrim(Doctor_Dept_Code)='" & DoctorDeptCode & "' And " & _
                                       "      Rtrim(Package_Code) ='" & PackageCode & "' And " & _
                                       "      Rtrim(Package_Type_Code) ='" & OrderTypeId & "' And " & _
                                       "      A.DC<>'Y' And A.Cancel<>'Y' And " & _
                                       "      B.Order_Code=A.Order_Code AND (B.Dc = 'N' or (B.Dc='Y' and B.Is_Alternative='Y')) And " & pvtMergeSQL & " And " & _
                                       "      C.Order_Code=A.Order_Code And C.DC<>'Y' "

                End If
                
                If (SourceType = "E" OrElse SourceType = "I") Then
                    command.CommandText &= " Order By  A.Package_No "
                End If
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryOPHPharmacyByCond3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, _
                                            ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim returnDS As DataSet
            Dim OPHtableName As String = "OPH_Pharmacy_Base"
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSQL As String = ""
            Dim pvtQueryField As String = ""
            Dim pvtQueryTimes As Integer = 1
            Dim pvtIsQuery As Boolean = False

            Select Case SourceType
                Case "O"
                    pvtMergeSQL = " E.Insu_Cover_Opd='Y' "
                Case "E"
                    pvtMergeSQL = " E.Insu_Cover_Emg='Y' "
                Case "I"
                    pvtMergeSQL = " E.Insu_Cover_Ipd='Y' "
            End Select

            If DrugType = "2" Then
                pvtQueryField = "'' As Property_Id"
            Else
                pvtQueryField = "C.Property_Id"
            End If

            If PharmacyQueryFlag(6) = "Y" Then
                command.CommandText &= "Select * From ( "
            End If

            '2011-09-01 Modify By Alan
            If PharmacyQueryFlag.Length > 8 AndAlso PharmacyQueryFlag(8).Trim = "Y" Then
                pvtQueryTimes = 5
            End If

            For m = 0 To pvtQueryTimes - 1

                '2011-09-01 Modify By Alan-若為急診藥品索引查詢，則需將Favor_Category更改為傳入的"索引值"
                If pvtQueryTimes = 5 Then

                    If PharmacyQueryFlag(9 + m).Trim = "" Then
                        Continue For
                    Else
                        pvtIsQuery = True
                    End If

                    If pvtIsQuery AndAlso command.CommandText.ToString.Trim <> "" Then
                        command.CommandText &= " Union "
                    End If

                    command.CommandText &= _
                        "Select '" & PharmacyQueryFlag(9 + m).Trim & "'  as Favor_Category,'" & PharmacyQueryFlag(9 + m).Trim & "' as Order_Code,'' as Order_Name,'' as Chinese_Name,'' as Usage_Code,'' as Frequency_Code,'' as OPD_Lack_Id,'' as IPD_Lack_Id,'' as EMG_Lack_Id," & _
                        "       '' as Is_Total_Qty,'' as Class_Code,'' As Property_Id,'' as Pharmacy_12_Code,'' as Form_Kind_Id,null As Nhi_Price,null As Own_Price,'' as Order_Type_Id "

                    Select Case DrugType
                        Case "1"
                            command.CommandText &= " ,'E' As Drug_Type "
                        Case "2"
                            command.CommandText &= " ,'T' As Drug_Type "
                        Case "3"
                            command.CommandText &= " ,'C' As Drug_Type "
                        Case "4"
                            command.CommandText &= " ,'' As Drug_Type "
                    End Select

                    If (SourceType = "E" OrElse SourceType = "I") Then
                        command.CommandText &= " ,'' As Is_OrderStanding," & m & " As Category_View_Seq "
                    End If

                    '2016-07-19 Add By Alan-選取停用醫令替代藥處理
                    command.CommandText &= ",'' As Is_Valid_Order "

                    command.CommandText &= "FROM OPH_Pharmacy_Base   "

                    command.CommandText &= " Union "

                    command.CommandText &= _
                        "Select '" & PharmacyQueryFlag(9 + m).Trim & "'  as Favor_Category,B.Order_Code,B.Order_Name,B.Chinese_Name,B.Usage_Code,B.Frequency_Code,B.OPD_Lack_Id,B.IPD_Lack_Id,B.EMG_Lack_Id," & _
                        "       B.Is_Total_Qty,B.Class_Code," & pvtQueryField & ",B.Pharmacy_12_Code,B.Form_Kind_Id,'' As Nhi_Price,'' As Own_Price,E.Order_Type_Id "

                Else
                    If SourceType = "I" Then
                        command.CommandText &= _
                        "Select '" & PharmacyQueryFlag(9 + m).Trim & "'  as Favor_Category,B.Order_Code,B.Order_Name,B.Chinese_Name,B.Usage_Code,B.Frequency_Code,B.OPD_Lack_Id,B.IPD_Lack_Id,B.EMG_Lack_Id," & _
                        "       B.Is_Total_Qty,B.Class_Code," & pvtQueryField & ",B.Pharmacy_12_Code,B.Form_Kind_Id,'' As Nhi_Price,'' As Own_Price,E.Order_Type_Id "
                    Else
                        command.CommandText &= _
                        "Select '' as Favor_Category,B.Order_Code,B.Order_Name,B.Chinese_Name,B.Usage_Code,B.Frequency_Code,B.OPD_Lack_Id,B.IPD_Lack_Id,B.EMG_Lack_Id," & _
                        "       B.Is_Total_Qty,B.Class_Code," & pvtQueryField & ",B.Pharmacy_12_Code,B.Form_Kind_Id,'' As Nhi_Price,'' As Own_Price,E.Order_Type_Id "

                    End If

                End If

                '2010-03-18 Add By Alan
                Select Case DrugType
                    Case "1"
                        command.CommandText &= " ,'E' As Drug_Type "
                    Case "2"
                        command.CommandText &= " ,'T' As Drug_Type "
                    Case "3"
                        command.CommandText &= " ,'C' As Drug_Type "
                    Case "4"
                        command.CommandText &= " ,'' As Drug_Type "
                End Select

                '?隤亦?嚙質那嚗??????PUB_Order_Standing?憌斗?嚙賢?嚙賢虜?嚙質
                If (SourceType = "E" OrElse SourceType = "I") Then
                    command.CommandText &= " ,P.Order_Code As Is_OrderStanding ," & m & " As Category_View_Seq "
                End If

                '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
                If IsChoiceDcOrder <> "Y" Then
                    command.CommandText &= ",'Y' As Is_Valid_Order "
                Else
                    command.CommandText &= ",CASE WHEN ( '" & Now.ToShortDateString & "' >= E.Effect_Date and "
                    command.CommandText &= "             '" & Now.ToShortDateString & "' <= E.End_Date ) and "
                    command.CommandText &= "             E.Dc <> 'Y' THEN 'Y' "
                    command.CommandText &= "       ELSE 'N'  "
                    command.CommandText &= " END As Is_Valid_Order "

                End If

                command.CommandText &= "From OPH_Pharmacy_Base B   "

                '?嚙賜?嚙質那嚗??????PUB_Order_Standing?憌斗?嚙賢?嚙賢虜?嚙質
                If (SourceType = "E" OrElse SourceType = "I") Then
                    command.CommandText &= " LEFT JOIN PUB_Order_Standing P ON "
                    command.CommandText &= " P.Dept_Code='ER' And P.Order_Code=B.Order_Code And P.DC<>'Y' "
                End If

                Select Case DrugType
                    Case "1"
                        command.CommandText &= " Left Join OPH_Property C  ON C.Pharmacy_12_Code=B.Pharmacy_12_Code "
                        command.CommandText &= " And C.Property_Id not in ('08','09','10','14') "
                    Case "2"
                        command.CommandText &= " ,OPH_Tpn_Pharmacy C "
                    Case "3", "4"
                        command.CommandText &= " ,OPH_Property C "
                    Case "5"
                        If SourceType = "I" Then
                            command.CommandText &= " Inner Join OPH_Property C  ON C.Pharmacy_12_Code=B.Pharmacy_12_Code and C.Property_Id like '16%' "
                        Else
                            command.CommandText &= " Left Join OPH_Property C  ON C.Pharmacy_12_Code=B.Pharmacy_12_Code "
                        End If

                    Case Else
                        command.CommandText &= " Left Join OPH_Property C  ON C.Pharmacy_12_Code=B.Pharmacy_12_Code "
                End Select

                If PharmacyQueryFlag(5) <> "" Then
                    command.CommandText &= " ,OPH_Pharmacy_Class D "
                End If

                command.CommandText &= " ,PUB_Order E "

                command.CommandText &= " Where 1=1 And B.Dc<>'Y'   "

                '2011-09-02 Add By Alan
                If pvtQueryTimes = 5 Then
                    command.CommandText &= getIndexQueryStr(PharmacyQueryFlag, "B", 9 + m)
                End If


                If OrderName <> "" Then

                    If (SourceType = "E" OrElse SourceType = "I") Then
                        command.CommandText &= " And ( B.Order_Name like '" & OrderName & "%'  "

                        If PharmacyQueryFlag(0) = "Y" Then
                            command.CommandText &= " OR  B.Scientific_Name like '" & OrderName & "%' "
                        End If

                        If PharmacyQueryFlag(1) = "Y" Then
                            command.CommandText &= " OR  B.Trade_Name like '" & OrderName & "%' "
                        End If

                        If PharmacyQueryFlag(2) = "Y" Then
                            command.CommandText &= " OR  B.Alias_Name like '" & OrderName & "%' "
                        End If

                        If PharmacyQueryFlag(3) = "Y" Then
                            command.CommandText &= " OR  B.Chinese_Name like '" & OrderName & "%' "
                        End If
                    Else
                        If PharmacyQueryFlag(4) = "N" Then
                            command.CommandText &= " And ( B.Order_Name like '%" & OrderName & "%'  "

                            If PharmacyQueryFlag(0) = "Y" Then
                                command.CommandText &= " OR  B.Scientific_Name like '%" & OrderName & "%' "
                            End If

                            If PharmacyQueryFlag(1) = "Y" Then
                                command.CommandText &= " OR  B.Trade_Name like '%" & OrderName & "%' "
                            End If

                            If PharmacyQueryFlag(2) = "Y" Then
                                command.CommandText &= " OR  B.Alias_Name like '%" & OrderName & "%' "
                            End If

                            If PharmacyQueryFlag(3) = "Y" Then
                                command.CommandText &= " OR  B.Chinese_Name like '%" & OrderName & "%' "
                            End If
                        Else
                            command.CommandText &= " And ( B.Order_Name like '%" & OrderName & "%'  "

                            If PharmacyQueryFlag(0) = "Y" Then
                                command.CommandText &= " OR  B.Scientific_Name like '%" & OrderName & "%' "
                            End If

                            If PharmacyQueryFlag(1) = "Y" Then
                                command.CommandText &= " OR  B.Trade_Name like '%" & OrderName & "%' "
                            End If

                            If PharmacyQueryFlag(2) = "Y" Then
                                command.CommandText &= " OR  B.Alias_Name like '%" & OrderName & "%' "
                            End If

                            If PharmacyQueryFlag(3) = "Y" Then
                                command.CommandText &= " OR  B.Chinese_Name like '%" & OrderName & "%' "
                            End If
                        End If
                    End If


                    command.CommandText &= ") "


                End If

                Select Case DrugType
                    'Case "1"
                    '    If (SourceType = "E" orelse SourceType = "I") Then
                    '        command.CommandText &= " And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id <> '16' "
                    '    End If
                    Case "2"
                        command.CommandText &= " And C.Pharmacy_12_Code =B.Pharmacy_12_Code "
                        Select Case PharmacyQueryFlag(7)
                            Case "1" 'TPN
                                command.CommandText &= " And C.Tpn_Kind_Id in ('1','2') "
                            Case "3" '瘛瑕?
                                command.CommandText &= " And C.Tpn_Kind_Id = '4' "
                            Case "4" '瘛餃?
                                command.CommandText &= " And C.Tpn_Kind_Id = '5' "
                        End Select
                    Case "3"
                        command.CommandText &= " And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id ='10' And C.Property_Id <> '08' "
                    Case "4"
                        command.CommandText &= " And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '14' And C.Property_Id <> '08' "
                        'Case "5"
                        '    If (SourceType = "E" orelse SourceType = "I") Then
                        '        command.CommandText &= " And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '16' "
                        '    End If
                End Select

                If PharmacyQueryFlag(5) <> "" Then
                    command.CommandText &= " AND (D.Class_Code='" & PharmacyQueryFlag(5) & "' OR D.Class_En_Name='" & PharmacyQueryFlag(5) & "') AND  D.Class_Code=B.Class_Code "
                End If

                command.CommandText &= " And E.Order_Code=B.Order_Code AND (E.Dc = 'N' or (E.Dc='Y' and E.Is_Alternative='Y')) "

                If IsChoiceDcOrder <> "Y" Then
                    command.CommandText &= "  and E.DC<>'Y' "
                    command.CommandText &= "  and E.Effect_Date <= '" & Now.ToShortDateString & "' "
                    command.CommandText &= "  and E.End_Date >= '" & Now.ToShortDateString & "' "
                End If

                command.CommandText &= " And " & pvtMergeSQL

                If PharmacyQueryFlag(6) = "Y" Then
                    command.CommandText &= " Union "

                    command.CommandText &= queryOPHPharmacyMergeSQL2(SourceType, OrderCode, OrderName, "1", PharmacyQueryFlag, IsChoiceDcOrder)
                    command.CommandText &= " ) KK "
                    command.CommandText &= " Order By KK.Order_Name "
                Else
                    If pvtQueryTimes = 1 Then
                        command.CommandText &= " Order By B.Order_Name "
                    End If
                End If
            Next

            If pvtQueryTimes = 5 Then
                command.CommandText &= " Order By Category_View_Seq,Order_Name "
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                returnDS = New DataSet(OPHtableName)
                adapter.Fill(returnDS, OPHtableName)
                adapter.FillSchema(returnDS, SchemaType.Mapped, OPHtableName)
            End Using
            Return returnDS
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function queryOPHPharmacyMergeSQL2(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, _
                                              ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal IsChoiceDcOrder As String) As String
        Dim SqlStr As String = ""
        Dim pvtMergeSQL As String = ""
        Dim pvtQueryField As String = ""

        Select Case SourceType
            Case "O"
                pvtMergeSQL = " E.Insu_Cover_Opd='Y' "
            Case "E"
                pvtMergeSQL = " E.Insu_Cover_Emg='Y' "
            Case "I"
                pvtMergeSQL = " E.Insu_Cover_Ipd='Y' "
        End Select

        If DrugType = "2" Then
            pvtQueryField = "'' As Property_Id"
        Else
            pvtQueryField = "C.Property_Id"
        End If

        SqlStr = _
        "Select B.Order_Code,B.Order_Name,B.Chinese_Name,B.Usage_Code,B.Frequency_Code,B.OPD_Lack_Id,B.IPD_Lack_Id,B.EMG_Lack_Id," & _
        "       B.Is_Total_Qty,B.Class_Code," & pvtQueryField & ",B.Pharmacy_12_Code,B.Form_Kind_Id,'' As Nhi_Price,'' As Own_Price "

        '2010-03-18 Add By Alan
        Select Case DrugType
            Case "1"
                SqlStr &= " ,'E' As Drug_Type "
            Case "2"
                SqlStr &= " ,'T' As Drug_Type "
            Case "3"
                SqlStr &= " ,'C' As Drug_Type "
            Case "4"
                SqlStr &= " ,'' As Drug_Type "
        End Select

        '?嚙賜?嚙質那嚗??????PUB_Order_Standing?憌斗?嚙賢?嚙賢虜?嚙質
        If SourceType = "E" Then
            SqlStr &= " ,P.Order_Code As Is_OrderStanding "
        End If

        '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
        If IsChoiceDcOrder <> "Y" Then
            SqlStr &= ",'Y' As Is_Valid_Order "
        Else
            SqlStr &= ",CASE WHEN ( '" & Now.ToShortDateString & "' >= E.Effect_Date and "
            SqlStr &= "             '" & Now.ToShortDateString & "' <= E.End_Date ) and "
            SqlStr &= "             E.Dc <> 'Y' THEN 'Y' "
            SqlStr &= "       ELSE 'N'  "
            SqlStr &= " END As Is_Valid_Order "
        End If

        SqlStr &= "From OPH_Pharmacy_Base B   "

        '?嚙賜?嚙質那嚗??????PUB_Order_Standing?憌斗?嚙賢?嚙賢虜?嚙質
        If SourceType = "E" Then
            SqlStr &= " LEFT JOIN PUB_Order_Standing P ON "
            SqlStr &= " P.Dept_Code='ER' And P.Order_Code=B.Order_Code And P.DC<>'Y' "
        End If

        Select Case DrugType
            Case "1"
                SqlStr &= " Left Join OPH_Property C  ON C.Pharmacy_12_Code=B.Pharmacy_12_Code "
                SqlStr &= " And C.Property_Id not in ('09','10','14') "
            Case "2"
                SqlStr &= " ,OPH_Tpn_Pharmacy C "
            Case "3", "4"
                SqlStr &= " ,OPH_Property C "
            Case Else
                SqlStr &= " Left Join OPH_Property C  ON C.Pharmacy_12_Code=B.Pharmacy_12_Code "
        End Select

        If PharmacyQueryFlag(5) <> "" Then
            SqlStr &= " ,OPH_Pharmacy_Class D "
        End If

        SqlStr &= " ,PUB_Order E "

        SqlStr &= " Where 1=1 And B.Dc<>'Y'   "


        If OrderName <> "" Then

            If SourceType = "E" Then
                SqlStr &= " And ( B.Order_Name like '" & OrderName & "%'  "

                If PharmacyQueryFlag(0) = "Y" Then
                    SqlStr &= " OR  B.Scientific_Name like '" & OrderName & "%' "
                End If

                If PharmacyQueryFlag(1) = "Y" Then
                    SqlStr &= " OR  B.Trade_Name like '" & OrderName & "%' "
                End If

                If PharmacyQueryFlag(2) = "Y" Then
                    SqlStr &= " OR  B.Alias_Name like '" & OrderName & "%' "
                End If

                If PharmacyQueryFlag(3) = "Y" Then
                    SqlStr &= " OR  B.Chinese_Name like '" & OrderName & "%' "
                End If
            Else
                If PharmacyQueryFlag(4) = "N" Then
                    SqlStr &= " And ( B.Order_Name like '%" & OrderName & "%'  "

                    If PharmacyQueryFlag(0) = "Y" Then
                        SqlStr &= " OR  B.Scientific_Name like '%" & OrderName & "%' "
                    End If

                    If PharmacyQueryFlag(1) = "Y" Then
                        SqlStr &= " OR  B.Trade_Name like '%" & OrderName & "%' "
                    End If

                    If PharmacyQueryFlag(2) = "Y" Then
                        SqlStr &= " OR  B.Alias_Name like '%" & OrderName & "%' "
                    End If

                    If PharmacyQueryFlag(3) = "Y" Then
                        SqlStr &= " OR  B.Chinese_Name like '%" & OrderName & "%' "
                    End If
                Else
                    SqlStr &= " And ( B.Order_Name like '%" & OrderName & "%'  "

                    If PharmacyQueryFlag(0) = "Y" Then
                        SqlStr &= " OR  B.Scientific_Name like '%" & OrderName & "%' "
                    End If

                    If PharmacyQueryFlag(1) = "Y" Then
                        SqlStr &= " OR  B.Trade_Name like '%" & OrderName & "%' "
                    End If

                    If PharmacyQueryFlag(2) = "Y" Then
                        SqlStr &= " OR  B.Alias_Name like '%" & OrderName & "%' "
                    End If

                    If PharmacyQueryFlag(3) = "Y" Then
                        SqlStr &= " OR  B.Chinese_Name like '%" & OrderName & "%' "
                    End If
                End If
            End If

            SqlStr &= ") "


        End If

        Select Case DrugType
            Case "2"
                SqlStr &= " And C.Pharmacy_12_Code =B.Pharmacy_12_Code  "
                Select Case PharmacyQueryFlag(7)
                    Case "1" 'TPN
                        SqlStr &= " And C.Tpn_Kind_Id in ('1','2') "
                    Case "3" '瘛瑕?
                        SqlStr &= " And C.Tpn_Kind_Id = '4' "
                    Case "4" '瘛餃?
                        SqlStr &= " And C.Tpn_Kind_Id = '5' "
                End Select
            Case "3"
                SqlStr &= " And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id ='10' "
            Case "4"
                SqlStr &= " And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '14' "
        End Select

        If PharmacyQueryFlag(5) <> "" Then
            SqlStr &= " AND D.Class_Code='" & PharmacyQueryFlag(5) & "' AND  D.Class_Code=B.Class_Code "
        End If

        SqlStr &= " And E.Order_Code=B.Order_Code AND (E.Dc = 'N' or (E.Dc='Y' and E.Is_Alternative='Y')) "

        If IsChoiceDcOrder <> "Y" Then
            SqlStr &= " and E.DC<>'Y' "
            SqlStr &= " and E.Effect_Date <= '" & Now.ToShortDateString & "' "
            SqlStr &= " and E.End_Date >= '" & Now.ToShortDateString & "' "
        End If

        SqlStr &= " And " & pvtMergeSQL

        Return SqlStr

    End Function

    Public Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, _
                                             ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, _
                                             ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String, _
                                             ByVal IsChoiceDcOrder As String) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSQL As String = ""
            Dim pvtIsCoverOPD As Boolean = False

            If (SourceType = "E" OrElse SourceType = "I") AndAlso (OrderTypeId = "H" Or OrderTypeId = "H1" Or OrderTypeId = "H2") AndAlso queryEMOMedicalRecordGetRegStateId(ChartNo, OutpatientSn) Then
                pvtIsCoverOPD = True
            End If


            Select Case SourceType
                Case "O"
                    pvtMergeSQL = " A.Insu_Cover_Opd='Y' "
                Case "E"
                    If pvtIsCoverOPD Then
                        pvtMergeSQL = " (A.Insu_Cover_Emg='Y' OR A.Insu_Cover_Opd='Y' ) "
                    Else
                        pvtMergeSQL = " A.Insu_Cover_Emg='Y' "
                    End If
                Case "I"
                    If pvtIsCoverOPD Then
                        pvtMergeSQL = " (A.Insu_Cover_Ipd='Y' OR A.Insu_Cover_Opd='Y' ) "
                    Else
                        pvtMergeSQL = " A.Insu_Cover_Ipd='Y' "
                    End If
            End Select

            pvtMergeSQL &= " AND (A.Dc = 'N' or (A.Dc='Y' and A.Is_Alternative='Y')) "

            If OrderTypeId = "J" Then
                command.CommandText = " Select distinct A.Order_Code,A.Order_En_Name,A.Order_Name,B.Nameplate_Name "
            Else
                command.CommandText = " Select A.Order_Code,A.Order_En_Name,A.Order_Name "
            End If


            '若為急診檢驗檢查
            '=>1.需於名稱後面新增檢體名稱()
            '=>2.加入檢查替換部位Order判斷欄位
            If OrderTypeId = "H" Or OrderTypeId = "H1" Or OrderTypeId = "H2" Then
                command.CommandText &= " ,B.Default_Body_Site_Code,B.Default_Side_Id,'' As Is_Labdiscount,B.Is_Scheduled, " & _
                                       "  B.Is_Same_Specimen_Add,B.Default_Specimen_Id AS Specimen_Id,B.Default_Vessel_Id,  " & _
                                       "  C.Code_Name  As Specimen_Name,D.Order_Code As Option_Order "
                command.CommandText &= "  ,(SELECT CASE B.Default_Specimen_Id WHEN '' Then F.Sheet_Group WHEN Null Then F.Sheet_Group ELSE E.Sheet_Group END) AS Sheet_Group "
                command.CommandText &= "  ,(SELECT CASE B.Default_Specimen_Id WHEN '' Then F.Sheet_Group_Name WHEN Null Then F.Sheet_Group_Name ELSE E.Sheet_Group_Name END) AS Sheet_Group_Name "

            End If

            command.CommandText &= " ,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,A.Order_Type_Id,A.Order_En_Short_Name,A.Charge_Unit,A.Is_Prior_Review,A.Treatment_Type_Id "

            '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
            If IsChoiceDcOrder <> "Y" Then
                command.CommandText &= ",'Y' As Is_Valid_Order "
            Else
                command.CommandText &= ",CASE WHEN ( '" & Now.ToShortDateString & "' >= A.Effect_Date and "
                command.CommandText &= "             '" & Now.ToShortDateString & "' <= A.End_Date ) and "
                command.CommandText &= "             A.Dc <> 'Y' THEN 'Y' "
                command.CommandText &= "       ELSE 'N'  "
                command.CommandText &= " END As Is_Valid_Order "

            End If
            command.CommandText &= " From PUB_Order A  "

            If OrderTypeId = "J" Then
                command.CommandText &= " , SUR_Op_Year_Nameplate B  "
            End If

            If OrderTypeId = "H" Or OrderTypeId = "H1" Or OrderTypeId = "H2" Then
                command.CommandText &= "                  Left Join PUB_Order_Examination B ON (B.Order_Code=A.Order_Code) "
                command.CommandText &= "                  Left Join  PUB_SysCode  C On  "
                command.CommandText &= "                  C.Type_Id='46' and C.Code_Id=B.Default_Specimen_Id and C.DC<>'Y'   "
                command.CommandText &= "                  Left Join  PUB_Exam_Item D On D.Order_Code=A.Order_Code "
                command.CommandText &= "                  Left Join  PUB_Sheet_Group E On E.Sheet_Group=B.Default_Specimen_Id and E.Sheet_Code=SubString(A.Order_Code,0,5) And E.Order_Code =A.Order_Code "
                command.CommandText &= "                  Left Join  PUB_Sheet_Group F On F.Sheet_Group=B.Default_Body_Site_Code and  F.Sheet_Code=SubString(A.Order_Code,0,5) And F.Order_Code =A.Order_Code "
            End If

            If IsChoiceDcOrder <> "Y" Then
                command.CommandText &= " Where A.Effect_Date <= '" & Now.ToShortDateString & "'  "
                command.CommandText &= " and A.DC<>'Y' "
                command.CommandText &= " and A.End_Date >= '" & Now.ToShortDateString & "' And "
            Else
                command.CommandText &= " Where 1=1 And "

            End If

            If (SourceType = "E" OrElse SourceType = "I") And OrderTypeId = "J" Then
                command.CommandText &= "       A.Order_Code >= '" & OrderCode & "'  And "
                command.CommandText &= "       A.Order_Code<= '" & OrderName & "'  And "
            Else
                If OrderCode <> "ENR" AndAlso OrderCode <> "" Then
                    command.CommandText &= "       A.Order_Code Like '" & OrderCode & "%'  And "
                End If

                If OrderName <> "" Then

                    '2012-10-24 Add by Alan-若為住院檢驗檢查，可以依Order_En_Short_Name進行檢索
                    If SourceType = "I" AndAlso OrderTypeId = "H" Then
                        command.CommandText &= "     (A.Order_En_Name Like '%" & OrderName & "%'  OR "
                        command.CommandText &= "      A.Order_Name Like '%" & OrderName & "%'  OR "
                        command.CommandText &= "      A.Order_En_Short_Name Like '%" & OrderName & "%' ) And "
                    Else
                        If Chinese_Flag = "N" Then
                            command.CommandText &= "     (A.Order_En_Name Like '%" & OrderName & "%'  OR "
                            command.CommandText &= "      A.Order_Name Like '%" & OrderName & "%' ) And "
                        Else
                            command.CommandText &= "     (A.Order_En_Name Like '%" & OrderName & "%'  OR "
                            command.CommandText &= "      A.Order_Name Like '%" & OrderName & "%' ) And "
                        End If

                    End If

                End If
            End If

            If OrderTypeId = "H" Or OrderTypeId = "H1" Or OrderTypeId = "H2" Then

                command.CommandText &= "       A.Order_Type_Id ='H' "

                If Specimen <> "" Then
                    command.CommandText &= " And B.Default_Specimen_Id ='" & Specimen & "'   "
                End If

                If Body_Site <> "" Then
                    command.CommandText &= " And B.Default_Body_Site_Code ='" & Body_Site & "'   "
                End If

                If OrderTypeId = "H1" Then
                    command.CommandText &= "     And A.Treatment_Type_Id in ('3' ) "
                ElseIf OrderTypeId = "H2" Then
                    command.CommandText &= "     And A.Treatment_Type_Id in ('4') "
                End If


                command.CommandText &= "     And " & pvtMergeSQL

            ElseIf OrderTypeId = "D" Then

                '2012-05-16 Add By Alan-急診護理計價調整
                If OrderCode <> "ENR" Then
                    If FavorCategory = "" Then
                        command.CommandText &= "  A.Order_Type_Id IN ('D','H','J') "
                        command.CommandText &= " And ( A.Order_Type_Id='H' And A.Treatment_Type_Id not in ('3' , '4') OR A.Treatment_Type_Id IS NULL  )  "

                    ElseIf FavorCategory = "治療處置" Then
                        command.CommandText &= "  A.Order_Type_Id IN ('D','H') "
                        command.CommandText &= " And ( A.Order_Type_Id='H' And A.Treatment_Type_Id not in ('3' , '4') OR A.Treatment_Type_Id IS NULL  )  "

                    ElseIf FavorCategory = "手術" Then
                        command.CommandText &= "  A.Order_Type_Id IN ('J') "
                    End If

                    command.CommandText &= " And " & pvtMergeSQL
                Else
                    If FavorCategory = "" Then
                        command.CommandText &= "  A.Order_Type_Id IN ('D','H','J','G') "
                        command.CommandText &= " And ( A.Order_Type_Id='H' And A.Treatment_Type_Id not in ('3' , '4') OR A.Treatment_Type_Id IS NULL  )  "

                    ElseIf FavorCategory = "治療處置" Then
                        command.CommandText &= "  A.Order_Type_Id IN ('D','H','G') "
                        command.CommandText &= " And ( A.Order_Type_Id='H' And A.Treatment_Type_Id not in ('3' , '4') OR A.Treatment_Type_Id IS NULL  )  "

                    ElseIf FavorCategory = "手術" Then
                        command.CommandText &= "  A.Order_Type_Id IN ('J') "
                    End If

                    command.CommandText &= " And " & pvtMergeSQL
                End If

            Else

                command.CommandText &= "       A.Order_Type_Id ='" & OrderTypeId & "' And " & pvtMergeSQL

                If OrderTypeId = "J" Then
                    If SourceType = "O" Then
                        command.CommandText &= " And B.Order_Code=A.Order_Code And B.Is_Opd='Y' "
                    ElseIf SourceType = "E" Then
                        command.CommandText &= " And B.Order_Code=A.Order_Code And B.Is_Emg='Y' "
                    Else
                        command.CommandText &= " And B.Order_Code=A.Order_Code "
                    End If

                End If

            End If


            command.CommandText &= " Order By A.Order_En_Name   "


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Order")
                adapter.Fill(ds, "PUB_Order")
                adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Order")
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSQL As String = ""

            Select Case SourceType
                Case "O"
                    pvtMergeSQL = " Is_Opd='Y' "
                Case "E"
                    pvtMergeSQL = " Is_Emg='Y' "
                Case "I"
                    pvtMergeSQL = " Is_Ipd='Y' "
            End Select

            command.CommandText = " Select Icd_Code  As Order_Code, Disease_En_Name As Order_En_Name ,Disease_Type_Id, " & _
                                  "        Effect_Date ,Disease_Name As Order_Name,Disease_Hosp_Name,Majorcare_Code,Limit_Sex_Id," & _
                                  "        Infection_Type_Id,Limit_Age,Age_Start_Year,Age_Start_Month,Age_Start_Day," & _
                                  "        Age_End_Year,Age_End_Month,Age_End_Day,Is_Exclude_Labdiscount,Is_Chronic_Disease," & _
                                  "        Is_Severe_Disease,Is_Psy_Severe_Disease,Is_Rare_Diseases,Is_Major_P,Is_Minor_P," & _
                                  "        Is_Mcc,Is_Cc,End_Date " & _
                                  " From   PUB_Disease " & _
                                  " Where  '" & Now().ToString("yyyy/M/d") & "' >= Effect_Date And '" & _
                                               Now().ToString("yyyy/M/d") & "'<= End_Date "

            If code <> "" Then
                command.CommandText += " And Icd_Code like '%" & code & "%' "
            End If

            If DiseaseTypeId.Trim <> "" Then
                command.CommandText += " And Disease_Type_Id in (" & DiseaseTypeId & ") "
            End If

            If codeName <> "" Then
                If (SourceType = "E" OrElse SourceType = "I") Then
                    command.CommandText += " And (Disease_Name like '%" & codeName & "%' "
                    command.CommandText += " OR Icd_Code like '" & codeName & "%') "
                Else
                    command.CommandText += " And Disease_Name like '%" & codeName & "%' "
                End If

            End If

            If codeEnName <> "" Then
                If (SourceType = "E" OrElse SourceType = "I") Then
                    command.CommandText += " And ( Disease_En_Name like '%" & codeEnName & "%' "
                    command.CommandText += " OR Icd_Code like '" & codeEnName & "%') "
                Else
                    command.CommandText += " And Disease_En_Name like '%" & codeEnName & "%' "
                End If

            End If

            If IsSevereDisease.Trim = "Y" Then
                command.CommandText += " And Is_Severe_Disease='Y' "
            End If

            command.CommandText += " And DC<>'Y' And Is_Opd='Y' And " & pvtMergeSQL

            If codeName <> "" Then
                command.CommandText += " Order By Disease_Name"
            Else
                command.CommandText += " Order By Disease_En_Name"
            End If


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Disease")
                adapter.Fill(ds, "PUB_Disease")
                adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Disease")
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function queryPUBExamItemByOrder(ByVal inOrderCode As String) As DataSet

        Try
            Dim returnDS As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select *  " & _
                                  " From PUB_Exam_Item " & _
                                  " Where Order_Code ='" & inOrderCode & "' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                returnDS = New DataSet("PUB_Exam_Item")
                adapter.Fill(returnDS, "PUB_Exam_Item")
                adapter.FillSchema(returnDS, SchemaType.Mapped, "PUB_Exam_Item")
            End Using
            Return returnDS
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As DataSet

        Dim sqlStr As String
        Dim returnDS As New DataSet
        Dim pvttableName1 = "OrderPrice"

        sqlStr = "SELECT Price As Own_Price" & _
                      ", Null as Nhi_Price " & _
                  " FROM PUB_Order_Price" & _
                 " WHERE Effect_Date <= @Now" & _
                   " AND End_Date >= @Now" & _
                   " AND Order_Code = @OrderCode" & _
                   " AND Main_Identity_Id = '1'" & _
                   " AND Dc = 'N'" & _
                 " UNION" & _
                " SELECT Null AS Own_Price" & _
                      ", Price AS Nhi_Price" & _
                  " FROM PUB_Order_Price" & _
                 " WHERE Effect_Date <= @Now" & _
                   " AND End_Date >= @Now " & _
                   " AND Order_Code = @OrderCode" & _
                   " AND Main_Identity_Id = '2'" & _
                   " AND Dc = 'N'"

        Try
            Using conn As SqlConnection = CType(getConnection(), SqlConnection)
                Using common As SqlCommand = conn.CreateCommand
                    common.CommandText = sqlStr
                    common.Parameters.AddWithValue("@Now", Now.ToString("yyyy/M/d"))
                    common.Parameters.AddWithValue("@OrderCode", OrderCode)

                    Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(common)
                    _dataAdapter.Fill(returnDS, pvttableName1)
                End Using
            End Using

            If returnDS IsNot Nothing AndAlso returnDS.Tables IsNot Nothing AndAlso returnDS.Tables(0).Rows.Count > 0 Then
                If returnDS.Tables(0).Rows.Count > 1 Then
                    returnDS.Tables(0).Rows(0).Item("Nhi_Price") = returnDS.Tables(0).Rows(1).Item("Nhi_Price")
                    returnDS.Tables(0).Rows.RemoveAt(1)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return returnDS

    End Function


    '========================================================================================================================

    ''' <summary>
    ''' 取得檢體
    ''' </summary>    
    Public Function queryPUBSysCodeAll2(ByVal SourceType As String, ByVal TypeID As String, Optional ByVal multiCodeIdFlag As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet

        Dim cmdStr As New StringBuilder
        Dim pvtMergeSQL As String = " "

        'Select Case SourceType
        '    Case "O"
        '        pvtMergeSQL = " AND Is_Opd='Y' "
        '    Case "E"
        '        pvtMergeSQL = " AND Is_Emg='Y' "
        '    Case "I"
        '        pvtMergeSQL = " AND Is_Ipd='Y' "
        'End Select

        Try
            Dim typeIDArray() As String = TypeID.Split(New Char() {","})
            Dim tbName(typeIDArray.Length - 1) As String

            For iIndex As Integer = 0 To typeIDArray.Length - 1

                tbName(iIndex) = "typeId" & typeIDArray(iIndex)

                'SQL
                cmdStr.AppendLine("SELECT RTRIM(Code_Id) AS Code_Id" & _
                                       ", RTRIM(Code_Name) AS Code_Name" & _
                                       ", RTRIM(Code_En_Name) AS Code_En_Name" & _
                                       ", Is_Default" & _
                                   " FROM PUB_SYSCODE WITH(NOLOCK)" & _
                                  " WHERE DC = 'N'" & _
                                    " AND Type_Id= '" & typeIDArray(iIndex) & "'" & _
                                    pvtMergeSQL & _
                                  " ORDER BY Sort_Value, Code_Id" & _
                                  "---------------------------------------")

                If Not multiCodeIdFlag Then
                    Exit For
                End If
            Next

            '執行SQL
            If multiCodeIdFlag Then
                Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select2", tbName, conn)
            Else
                '原Code
                Dim ds As DataSet
                Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = cmdStr.ToString
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet("PUB_SYSCODE")
                    adapter.Fill(ds, "PUB_SYSCODE")
                    adapter.FillSchema(ds, SchemaType.Mapped, "PUB_SYSCODE")
                End Using
                Return ds
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢大分類部位資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBBodySiteMainSiteData(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim cmdStr As String

        Try
            'SQL
            cmdStr = "SELECT RTRIM(Body_Site_Code) AS Body_Site_Code" & _
                          ", RTRIM(Body_Site_Name) AS Body_Site_Name" & _
                      " FROM PUB_Body_Site WITH(NOLOCK)" & _
                     " WHERE Main_Body_Site_Code = Body_Site_Code" & _
                       " AND DC = 'N'"

            '執行SQL
            Try
                If conn Is Nothing Then
                    conn = getConnection()
                End If

                Using Command As SqlCommand = CType(conn, SqlConnection).CreateCommand

                    Command.CommandText = cmdStr.ToString

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                        Using ds As DataSet = New DataSet
                            adapter.Fill(ds, "PUB_Body_Site")
                            Return ds
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得病患過敏藥物
    ''' </summary>  
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
                        Using ds As DataSet = New DataSet("PUB_Patient_Allergy")
                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            adapter.Fill(ds, "PUB_Patient_Allergy")
                            Return ds
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得全院藥品分類
    ''' </summary>  
    Public Function queryOPHPharmacyClassByCodeLen() As DataSet
        Try
            Using conn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Dim command As SqlCommand = conn.CreateCommand()
                command.CommandText = "SELECT RTRIM(Class_Code) AS Class_Code, RTRIM(Class_En_Name) AS Class_En_Name" & _
                                       " FROM OPH_Pharmacy_Class WITH(NOLOCK)" & _
                                      " ORDER BY Class_Code"

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    Using ds As DataSet = New DataSet("OPH_Pharmacy_Class")
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                        adapter.Fill(ds, "OPH_Pharmacy_Class")
                        Return ds
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得急診手術分類
    ''' </summary>  
    Public Function queryEMOOpMenuData() As DataSet
        Try
            Dim ds As New DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getEISDBConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select * " & _
                                  "From  EMO_Op_Menu " & _
                                  "Order By Parent_Category_Code,Display_Seq  "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("EMO_Op_Menu")
                adapter.Fill(ds, "EMO_Op_Menu")
            End Using

            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得住院全院護理套裝分類 
    ''' </summary>  
    Public Function queryInpCategoryData() As DataSet
        Try
            Dim ds As New DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getPUBDBConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select Code_Id,Code_Name " & _
                                  "From PUB_SYSCode " & _
                                  "Where TYPE_ID ='7411' and DC<>'Y'  " & _
                                  "Order By Sort_Value "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("INP_Category")
                adapter.Fill(ds, "INP_Category")
            End Using

            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得住院全院護理套裝護理站 
    ''' </summary> 
    Public Function queryINPStationData() As DataSet
        Try
            Dim ds As New DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getPUBDBConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select Station_No,Station_Name " & _
                                  "From PUB_Station " & _
                                  "Order By Station_No "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Station")
                adapter.Fill(ds, "PUB_Station")
            End Using

            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getIndexQueryStr(ByVal PharmacyQueryFlag() As String, ByVal pvtTableNo As String, ByVal pvtIndex As Integer) As String
        Dim pvtSqlStr As String = ""

        If PharmacyQueryFlag(pvtIndex).Trim <> "" Then

            If pvtSqlStr = "" Then
                pvtSqlStr = " And ( " & pvtTableNo & ".Order_Name like '" & PharmacyQueryFlag(pvtIndex) & "%' "
            Else
                pvtSqlStr = " OR " & pvtTableNo & ".Order_Name like '" & PharmacyQueryFlag(pvtIndex) & "%' "
            End If

            If PharmacyQueryFlag(0) = "Y" Then
                pvtSqlStr &= " OR  " & pvtTableNo & ".Scientific_Name like '" & PharmacyQueryFlag(pvtIndex) & "%' "
            End If

            If PharmacyQueryFlag(1) = "Y" Then
                pvtSqlStr &= " OR  " & pvtTableNo & ".Trade_Name like '" & PharmacyQueryFlag(pvtIndex) & "%' "
            End If

            If PharmacyQueryFlag(2) = "Y" Then
                pvtSqlStr &= " OR  " & pvtTableNo & ".Alias_Name like '" & PharmacyQueryFlag(pvtIndex) & "%' "
            End If

            If PharmacyQueryFlag(3) = "Y" Then
                pvtSqlStr &= " OR  " & pvtTableNo & ".Chinese_Name like '" & PharmacyQueryFlag(pvtIndex) & "%' "
            End If

            pvtSqlStr &= ") "


        End If

        Return pvtSqlStr

    End Function

    Public Function queryOMOOrderFavorNormalSQL2(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, _
                                             ByVal FavorCategory As String, ByVal OrderCode As String, ByVal OrderName As String, _
                                             ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal ChartNo As String, ByVal OutpatientSn As String, _
                                             ByVal IsChoiceDcOrder As String) As String

        Dim sqlString As New System.Text.StringBuilder
        Dim pvtMergeSQL As String = ""
        Dim pvtIsCoverOPD As Boolean = False
        Dim pvtQueryField As String = ""

        If SourceType = "E" AndAlso FavorTypeId = "H" AndAlso queryEMOMedicalRecordGetRegStateId(ChartNo, OutpatientSn) Then
            pvtIsCoverOPD = True
        End If


        Select Case SourceType
            Case "O"
                pvtMergeSQL = "Is_Opd='Y' "
            Case "E"
                pvtMergeSQL = "Is_Emg='Y' "
            Case "I"
                pvtMergeSQL = "Is_Ipd='Y' "
        End Select

        If FavorTypeId = "E" AndAlso DrugType = "2" Then
            pvtQueryField = "'' As Property_Id"
        Else
            pvtQueryField = "C.Property_Id"
        End If

        If FavorId = 1 OrElse FavorId = 2 Then
            If FavorTypeId = "E" Then

                sqlString.Append("SELECT distinct A.Favor_Category,A.Order_Code,A.Favor_Name,B.Order_Name,B.Chinese_Name, ")
                sqlString.Append("       A.Dosage, A.Dosage_Unit , A.Frequency_Code , A.Usage_Code , A.Days , A.Qty , A.Unit, ")
                sqlString.Append("       A.Body_Site_Code,A.Specimen_Id,A.Sort_Value,A.Is_Package, ")
                sqlString.Append("       B.OPD_Lack_Id , B. IPD_Lack_Id , B.EMG_Lack_Id ,B. Is_Total_Qty, ")
                sqlString.Append("       B.Class_Code, B.Form_Kind_Id  ," & pvtQueryField & ",C.Pharmacy_12_Code,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type  ")

                '2010-03-18 Add By Alan
                Select Case DrugType
                    Case "1"
                        sqlString.Append(" ,'E' As Drug_Type ")
                    Case "2"
                        sqlString.Append(" ,'T' As Drug_Type ")
                    Case "3"
                        sqlString.Append(" ,'C' As Drug_Type ")
                    Case "4"
                        sqlString.Append(" ,'' As Drug_Type ")
                End Select

                '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                If SourceType = "E" Then
                    sqlString.Append(" ,P.Order_Code As Is_OrderStanding ")

                    '2012-10-24 Add By Alan-需再回傳Times與Remark
                    sqlString.Append(" , A.Times, '' As Remark ")

                End If

                '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
                If IsChoiceDcOrder <> "Y" Then
                    sqlString.Append(",'Y' As Is_Valid_Order ")
                Else
                    sqlString.Append(",CASE WHEN ( '" & Now.ToShortDateString & "' >= PO.Effect_Date and ")
                    sqlString.Append("             '" & Now.ToShortDateString & "' <= PO.End_Date ) and ")
                    sqlString.Append("             PO.Dc <> 'Y' THEN 'Y' ")
                    sqlString.Append("       ELSE 'N'  ")
                    sqlString.Append(" END As Is_Valid_Order ")

                End If

                sqlString.Append("FROM OMO_Favor A ")

                sqlString.Append(", OPH_Pharmacy_Base B  ")

                '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                If SourceType = "E" Then
                    sqlString.Append(" LEFT JOIN PUB_Order_Standing P ON ")
                    sqlString.Append(" P.Dept_Code='ER' And P.Order_Code=B.Order_Code And P.DC<>'Y' ")
                End If

                Select Case DrugType
                    Case "1"
                        sqlString.Append(" LEFT JOIN OPH_Property C ON ")
                        sqlString.Append("         C.Pharmacy_12_Code = B.Pharmacy_12_Code And ")
                        sqlString.Append(" C.Property_Id not in ('08','09','10','14') ")
                    Case "2"
                        sqlString.Append(" ,OPH_Tpn_Pharmacy C ")
                    Case "3", "4"
                        sqlString.Append(" ,OPH_Property C ")
                    Case Else
                        sqlString.Append(" LEFT JOIN OPH_Property C ON ")
                        sqlString.Append("         C.Pharmacy_12_Code = B.Pharmacy_12_Code ")
                End Select


                sqlString.Append(" INNER JOIN PUB_Order PO WITH(NOLOCK) ON ")
                sqlString.Append("           PO.Order_Code = A.Order_Code AND (PO.Dc = 'N' or (PO.Dc='Y' and PO.Is_Alternative='Y')) ")

                If IsChoiceDcOrder <> "Y" Then
                    sqlString.Append("           and PO.DC<>'Y' ")
                    sqlString.Append("           and PO.Effect_Date <= '" & Now.ToShortDateString & "' ")
                    sqlString.Append("           and PO.End_Date >= '" & Now.ToShortDateString & "' ")
                End If

                sqlString.Append("WHERE  ")
                If FavorId <> "" Then
                    sqlString.Append(" A.Favor_Id = '" & FavorId & "' And ")
                End If

                If FavorTypeId <> "" Then
                    sqlString.Append(" A.Favor_Type_Id = '" & FavorTypeId & "' And ")
                End If

                If DoctorDeptCode <> "" Then
                    sqlString.Append(" A.Doctor_Dept_Code = '" & DoctorDeptCode & "' And ")
                End If

                If FavorCategory <> "" Then
                    sqlString.Append(" A.Favor_Category = '" & FavorCategory & "' And ")
                End If

                If OrderCode <> "" Then
                    sqlString.Append(" A.Order_Code = '" & OrderCode & "' And ")
                End If

                sqlString.Append("       A.Dc <> 'Y' And A.Is_Package <> 'Y' And ")
                If pvtMergeSQL <> "" Then
                    If pvtIsCoverOPD Then
                        sqlString.Append(" (A." & pvtMergeSQL & "OR A.Is_Opd='Y') " & " And ")
                    Else
                        sqlString.Append(" A." & pvtMergeSQL & " And ")
                    End If
                End If

                sqlString.Append(" B.Order_Code = A.Order_Code And B.Dc <> 'Y'  ")

                If OrderName <> "" Then

                    If PharmacyQueryFlag(4) = "N" Then
                        sqlString.Append(" And ( B.Order_Name like '%" & OrderName & "%' ")

                        If PharmacyQueryFlag(0) = "Y" Then
                            sqlString.Append(" OR  B.Scientific_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(1) = "Y" Then
                            sqlString.Append(" OR  B.Trade_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(2) = "Y" Then
                            sqlString.Append(" OR  B.Alias_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(3) = "Y" Then
                            sqlString.Append(" OR  B.Chinese_Name like '%" & OrderName & "%' ")
                        End If
                    Else
                        sqlString.Append(" And ( B.Order_Name like '%" & OrderName & "%' ")

                        If PharmacyQueryFlag(0) = "Y" Then
                            sqlString.Append(" OR  B.Scientific_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(1) = "Y" Then
                            sqlString.Append(" OR  B.Trade_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(2) = "Y" Then
                            sqlString.Append(" OR  B.Alias_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(3) = "Y" Then
                            sqlString.Append(" OR  B.Chinese_Name like '%" & OrderName & "%' ")
                        End If
                    End If


                    sqlString.Append(") ")

                End If


                Select Case DrugType
                    Case "1"
                        'If SourceType = "E" Then
                        '    sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code ")
                        'End If
                    Case "2"
                        sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code ")

                        Select Case PharmacyQueryFlag(7)
                            Case "1" 'TPN
                                sqlString.Append(" And C.Tpn_Kind_Id in ('1','2') ")
                            Case "3" '混合
                                sqlString.Append(" And C.Tpn_Kind_Id = '4' ")
                            Case "4" '添加
                                sqlString.Append(" And C.Tpn_Kind_Id = '5' ")
                        End Select


                    Case "3"
                        sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '10' ")
                    Case "4"
                        sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '14' ")
                    Case "5"
                        If SourceType = "E" Then
                            sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '16' ")
                        End If

                End Select

                '********************************以下為整合急診醫囑所做修改*********************************************************
                sqlString.Append(" Union ")

                sqlString.Append("SELECT distinct K.Favor_Category,K.Order_Code,K.Favor_Name,K.Favor_Name As Order_Name,K.Favor_Name As Chinese_Name, ")
                sqlString.Append("       K.Dosage, K.Dosage_Unit , K.Frequency_Code , K.Usage_Code , K.Days , K.Qty , K.Unit, ")
                sqlString.Append("       K.Body_Site_Code,K.Specimen_Id,K.Sort_Value,K.Is_Package, ")
                sqlString.Append("       'N' As OPD_Lack_Id ,'N' As IPD_Lack_Id , 'N' As EMG_Lack_Id ,'' As  Is_Total_Qty, ")
                sqlString.Append("       '' As Class_Code, '' As Form_Kind_Id ,'' As Property_Id ,'' As Pharmacy_12_Code,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type  ")

                '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                If SourceType = "E" Then
                    sqlString.Append(" ,Q.Order_Code As Is_OrderStanding ")

                    '2012-10-24 Add By Alan-需再回傳Times與Remark
                    sqlString.Append(" , K.Times,'' as Remark ")

                End If

                '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
                If IsChoiceDcOrder <> "Y" Then
                    sqlString.Append(",'Y' As Is_Valid_Order ")
                Else
                    sqlString.Append(",CASE WHEN ( '" & Now.ToShortDateString & "' >= PO.Effect_Date and ")
                    sqlString.Append("             '" & Now.ToShortDateString & "' <= PO.End_Date ) and ")
                    sqlString.Append("             PO.Dc <> 'Y' THEN 'Y' ")
                    sqlString.Append("       ELSE 'N'  ")
                    sqlString.Append(" END As Is_Valid_Order ")

                End If

                sqlString.Append("FROM OMO_Favor K ")

                '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                If SourceType = "E" Then
                    sqlString.Append(" LEFT JOIN PUB_Order_Standing Q ON ")
                    sqlString.Append(" Q.Dept_Code='ER' And Q.Order_Code=K.Order_Code And Q.DC<>'Y' ")
                End If

                sqlString.Append(" INNER JOIN PUB_Order PO WITH(NOLOCK) ON ")
                sqlString.Append("           PO.Order_Code = K.Order_Code AND (PO.Dc = 'N' or (PO.Dc='Y' and PO.Is_Alternative='Y')) ")

                If IsChoiceDcOrder <> "Y" Then
                    sqlString.Append("           and PO.DC<>'Y' ")
                    sqlString.Append("           and PO.Effect_Date <= '" & Now.ToShortDateString & "' ")
                    sqlString.Append("           and PO.End_Date >= '" & Now.ToShortDateString & "' ")
                End If

                sqlString.Append("WHERE  ")
                If FavorId <> "" Then
                    sqlString.Append(" K.Favor_Id = '" & FavorId & "' And ")
                End If

                If FavorTypeId <> "" Then
                    sqlString.Append(" K.Favor_Type_Id = '" & FavorTypeId & "' And ")
                End If

                If DoctorDeptCode <> "" Then
                    sqlString.Append(" K.Doctor_Dept_Code = '" & DoctorDeptCode & "' And ")
                End If

                If FavorCategory <> "" Then
                    sqlString.Append(" K.Favor_Category = '" & FavorCategory & "' And ")
                End If

                If OrderCode <> "" Then
                    sqlString.Append(" K.Order_Code = '" & OrderCode & "' And ")
                End If

                sqlString.Append("       K.Dc <> 'Y' And K.Is_Package = 'Y' ")

                If OrderName <> "" Then

                    sqlString.Append(" And  K.Favor_Name like '%" & OrderName & "%' ")

                End If

                If pvtMergeSQL <> "" Then
                    If pvtMergeSQL <> "" Then
                        If pvtIsCoverOPD Then
                            sqlString.Append(" And (K." & pvtMergeSQL & "OR K.Is_Opd='Y') ")
                        Else
                            sqlString.Append(" And K." & pvtMergeSQL)
                        End If
                    End If
                End If

            End If

        End If

        Return sqlString.ToString

    End Function

    Public Function queryOMOOrderFavorNormalSQL3(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, _
                                             ByVal FavorCategory As String, ByVal OrderCode As String, ByVal OrderName As String, _
                                             ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal ChartNo As String, ByVal OutpatientSn As String, _
                                             ByVal QueryIndex As Integer, ByVal IsChoiceDcOrder As String) As String

        Dim sqlString As New System.Text.StringBuilder
        Dim pvtMergeSQL As String = ""
        Dim pvtIsCoverOPD As Boolean = False
        Dim pvtQueryField As String = ""

        If SourceType = "E" AndAlso FavorTypeId = "H" AndAlso queryEMOMedicalRecordGetRegStateId(ChartNo, OutpatientSn) Then
            pvtIsCoverOPD = True
        End If


        Select Case SourceType
            Case "O"
                pvtMergeSQL = "Is_Opd='Y' "
            Case "E"
                pvtMergeSQL = "Is_Emg='Y' "
            Case "I"
                pvtMergeSQL = "Is_Ipd='Y' "
        End Select

        If FavorTypeId = "E" AndAlso DrugType = "2" Then
            pvtQueryField = "'' As Property_Id"
        Else
            pvtQueryField = "C.Property_Id"
        End If

        If FavorId = 1 OrElse FavorId = 2 Then
            If FavorTypeId = "E" Then
                sqlString.Append("SELECT distinct '" & PharmacyQueryFlag(9 + QueryIndex).Trim & "'  as Favor_Category,A.Order_Code,A.Favor_Name,B.Order_Name,B.Chinese_Name, ")
                sqlString.Append("       A.Dosage, A.Dosage_Unit , A.Frequency_Code , A.Usage_Code , A.Days , A.Qty , A.Unit, ")
                sqlString.Append("       A.Body_Site_Code,A.Specimen_Id,A.Sort_Value,A.Is_Package, ")
                sqlString.Append("       B.OPD_Lack_Id , B. IPD_Lack_Id , B.EMG_Lack_Id ,B. Is_Total_Qty, ")
                sqlString.Append("       B.Class_Code, B.Form_Kind_Id  ," & pvtQueryField & ",C.Pharmacy_12_Code,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type  ")

                '2010-03-18 Add By Alan
                Select Case DrugType
                    Case "1"
                        sqlString.Append(" ,'E' As Drug_Type ")
                    Case "2"
                        sqlString.Append(" ,'T' As Drug_Type ")
                    Case "3"
                        sqlString.Append(" ,'C' As Drug_Type ")
                    Case "4"
                        sqlString.Append(" ,'' As Drug_Type ")
                End Select

                '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                If SourceType = "E" Then
                    sqlString.Append(" ,P.Order_Code As Is_OrderStanding ")

                    '2012-10-24 Add By Alan-需再回傳Times與Remark
                    sqlString.Append(" , A.Times, '' as Remark ")

                End If

                '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
                If IsChoiceDcOrder <> "Y" Then
                    sqlString.Append(",'Y' As Is_Valid_Order ")
                Else
                    sqlString.Append(",CASE WHEN ( '" & Now.ToShortDateString & "' >= PO.Effect_Date and ")
                    sqlString.Append("             '" & Now.ToShortDateString & "' <= PO.End_Date ) and ")
                    sqlString.Append("             PO.Dc <> 'Y' THEN 'Y' ")
                    sqlString.Append("       ELSE 'N'  ")
                    sqlString.Append(" END As Is_Valid_Order ")

                End If

                sqlString.Append("FROM OMO_Favor A ")

                sqlString.Append(", OPH_Pharmacy_Base B  ")

                '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                If SourceType = "E" Then
                    sqlString.Append(" LEFT JOIN PUB_Order_Standing P ON ")
                    sqlString.Append(" P.Dept_Code='ER' And P.Order_Code=B.Order_Code And P.DC<>'Y' ")
                End If

                Select Case DrugType
                    Case "1"
                        sqlString.Append(" LEFT JOIN OPH_Property C ON ")
                        sqlString.Append("         C.Pharmacy_12_Code = B.Pharmacy_12_Code And ")
                        sqlString.Append(" C.Property_Id not in ('08','09','10','14','16') ")
                    Case "2"
                        sqlString.Append(" ,OPH_Tpn_Pharmacy C ")
                    Case "3", "4"
                        sqlString.Append(" ,OPH_Property C ")
                    Case Else
                        sqlString.Append(" LEFT JOIN OPH_Property C ON ")
                        sqlString.Append("         C.Pharmacy_12_Code = B.Pharmacy_12_Code ")
                End Select

                sqlString.Append(" INNER JOIN PUB_Order PO WITH(NOLOCK) ON ")
                sqlString.Append("           PO.Order_Code = A.Order_Code AND (PO.Dc = 'N' or (PO.Dc='Y' and PO.Is_Alternative='Y')) ")

                If IsChoiceDcOrder <> "Y" Then
                    sqlString.Append("           and PO.DC<>'Y' ")
                    sqlString.Append("           and PO.Effect_Date <= '" & Now.ToShortDateString & "' ")
                    sqlString.Append("           and PO.End_Date >= '" & Now.ToShortDateString & "' ")
                End If

                sqlString.Append("WHERE  ")
                If FavorId <> "" Then
                    sqlString.Append(" A.Favor_Id = '" & FavorId & "' And ")
                End If

                If FavorTypeId <> "" Then
                    sqlString.Append(" A.Favor_Type_Id = '" & FavorTypeId & "' And ")
                End If

                If DoctorDeptCode <> "" Then
                    sqlString.Append(" A.Doctor_Dept_Code = '" & DoctorDeptCode & "' And ")
                End If

                If FavorCategory <> "" Then
                    sqlString.Append(" A.Favor_Category = '" & FavorCategory & "' And ")
                End If

                If OrderCode <> "" Then
                    sqlString.Append(" A.Order_Code = '" & OrderCode & "' And ")
                End If

                sqlString.Append("       A.Dc <> 'Y' And A.Is_Package <> 'Y' And ")
                If pvtMergeSQL <> "" Then
                    If pvtIsCoverOPD Then
                        sqlString.Append(" (A." & pvtMergeSQL & "OR A.Is_Opd='Y') " & " And ")
                    Else
                        sqlString.Append(" A." & pvtMergeSQL & " And ")
                    End If
                End If

                sqlString.Append(" B.Order_Code = A.Order_Code And B.Dc <> 'Y'  ")

                sqlString.Append(getIndexQueryStr(PharmacyQueryFlag, "B", 9 + QueryIndex))

                If OrderName <> "" Then

                    If PharmacyQueryFlag(4) = "N" Then
                        sqlString.Append(" And ( B.Order_Name like '%" & OrderName & "%' ")

                        If PharmacyQueryFlag(0) = "Y" Then
                            sqlString.Append(" OR  B.Scientific_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(1) = "Y" Then
                            sqlString.Append(" OR  B.Trade_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(2) = "Y" Then
                            sqlString.Append(" OR  B.Alias_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(3) = "Y" Then
                            sqlString.Append(" OR  B.Chinese_Name like '%" & OrderName & "%' ")
                        End If
                    Else
                        sqlString.Append(" And ( B.Order_Name like '%" & OrderName & "%' ")

                        If PharmacyQueryFlag(0) = "Y" Then
                            sqlString.Append(" OR  B.Scientific_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(1) = "Y" Then
                            sqlString.Append(" OR  B.Trade_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(2) = "Y" Then
                            sqlString.Append(" OR  B.Alias_Name like '%" & OrderName & "%' ")
                        End If

                        If PharmacyQueryFlag(3) = "Y" Then
                            sqlString.Append(" OR  B.Chinese_Name like '%" & OrderName & "%' ")
                        End If
                    End If


                    sqlString.Append(") ")

                End If


                Select Case DrugType
                    Case "1"
                        'If SourceType = "E" Then
                        '    sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code ")
                        'End If
                    Case "2"
                        sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code ")

                        Select Case PharmacyQueryFlag(7)
                            Case "1" 'TPN
                                sqlString.Append(" And C.Tpn_Kind_Id in ('1','2') ")
                            Case "3" '混合
                                sqlString.Append(" And C.Tpn_Kind_Id = '4' ")
                            Case "4" '添加
                                sqlString.Append(" And C.Tpn_Kind_Id = '5' ")
                        End Select


                    Case "3"
                        sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '10' ")
                    Case "4"
                        sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id = '14' ")
                    Case "1"
                        If SourceType = "E" Then
                            sqlString.Append(" And C.Pharmacy_12_Code =B.Pharmacy_12_Code And C.Property_Id= '16' ")
                        End If
                End Select

                '********************************以下為整合急診醫囑所做修改*********************************************************
                sqlString.Append(" Union ")

                sqlString.Append("SELECT distinct '" & PharmacyQueryFlag(9 + QueryIndex).Trim & "' As Favor_Category,K.Order_Code,K.Favor_Name,K.Favor_Name As Order_Name,K.Favor_Name As Chinese_Name, ")
                sqlString.Append("       K.Dosage, K.Dosage_Unit , K.Frequency_Code , K.Usage_Code , K.Days , K.Qty , K.Unit, ")
                sqlString.Append("       K.Body_Site_Code,K.Specimen_Id,K.Sort_Value,K.Is_Package, ")
                sqlString.Append("       'N' As OPD_Lack_Id ,'N' As IPD_Lack_Id , 'N' As EMG_Lack_Id ,'' As  Is_Total_Qty, ")
                sqlString.Append("       '' As Class_Code, '' As Form_Kind_Id ,'' As Property_Id ,'' As Pharmacy_12_Code,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type  ")

                '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                If SourceType = "E" Then
                    sqlString.Append(" ,Q.Order_Code As Is_OrderStanding ")

                    '2012-10-24 Add By Alan-需再回傳Times與Remark
                    sqlString.Append(" , K.Times, '' AS Remark ")

                End If

                '2016-07-19 Add By Alan-選取停用醫令替代藥處理  
                If IsChoiceDcOrder <> "Y" Then
                    sqlString.Append(",'Y' As Is_Valid_Order ")
                Else
                    sqlString.Append(",CASE WHEN ( '" & Now.ToShortDateString & "' >= PO.Effect_Date and ")
                    sqlString.Append("             '" & Now.ToShortDateString & "' <= PO.End_Date ) and ")
                    sqlString.Append("             PO.Dc <> 'Y' THEN 'Y' ")
                    sqlString.Append("       ELSE 'N'  ")
                    sqlString.Append(" END As Is_Valid_Order ")

                End If

                sqlString.Append("FROM OMO_Favor K ")

                '若為急診，則需再關連PUB_Order_Standing判斷是否為常備藥
                If SourceType = "E" Then
                    sqlString.Append(" LEFT JOIN PUB_Order_Standing Q ON ")
                    sqlString.Append(" Q.Dept_Code='ER' And Q.Order_Code=K.Order_Code And Q.DC<>'Y' ")
                End If

                sqlString.Append(" INNER JOIN PUB_Order PO WITH(NOLOCK) ON ")
                sqlString.Append("           PO.Order_Code = K.Order_Code AND (PO.Dc = 'N' or (PO.Dc='Y' and PO.Is_Alternative='Y')) ")

                If IsChoiceDcOrder <> "Y" Then
                    sqlString.Append("           and PO.DC<>'Y' ")
                    sqlString.Append("           and PO.Effect_Date <= '" & Now.ToShortDateString & "' ")
                    sqlString.Append("           and PO.End_Date >= '" & Now.ToShortDateString & "' ")
                End If

                sqlString.Append("WHERE  ")
                If FavorId <> "" Then
                    sqlString.Append(" K.Favor_Id = '" & FavorId & "' And ")
                End If

                If FavorTypeId <> "" Then
                    sqlString.Append(" K.Favor_Type_Id = '" & FavorTypeId & "' And ")
                End If

                If DoctorDeptCode <> "" Then
                    sqlString.Append(" K.Doctor_Dept_Code = '" & DoctorDeptCode & "' And ")
                End If

                If FavorCategory <> "" Then
                    sqlString.Append(" K.Favor_Category = '" & FavorCategory & "' And ")
                End If

                If OrderCode <> "" Then
                    sqlString.Append(" K.Order_Code = '" & OrderCode & "' And ")
                End If

                sqlString.Append("       K.Dc <> 'Y' And K.Is_Package = 'Y' ")

                sqlString.Append(" And  K.Favor_Name like '%" & PharmacyQueryFlag(9 + QueryIndex) & "%' ")

                If OrderName <> "" Then

                    sqlString.Append(" And  K.Favor_Name like '%" & OrderName & "%' ")

                End If

                If pvtMergeSQL <> "" Then
                    If pvtMergeSQL <> "" Then
                        If pvtIsCoverOPD Then
                            sqlString.Append(" And (K." & pvtMergeSQL & "OR K.Is_Opd='Y') ")
                        Else
                            sqlString.Append(" And K." & pvtMergeSQL)
                        End If
                    End If
                End If

            End If

        End If

        Return sqlString.ToString

    End Function

    Public Function queryEMOMedicalRecordGetRegStateId(ByVal ChartNo As String, ByVal OutpatientSn As String) As Boolean
        Try
            Dim ds As New DataSet
            Dim returnFlag As Boolean = False
            Dim sqlConn As SqlClient.SqlConnection = CType(getEISDBConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select Reg_State_Id " & _
                                  "From  EMO_Medical_Record " & _
                                  "Where Chart_No ='" & ChartNo & "' And Outpatient_Sn='" & OutpatientSn & "'"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("EMO_Medical_Record")
                adapter.Fill(ds, "EMO_Medical_Record")
            End Using

            If ds IsNot Nothing AndAlso ds.Tables IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                Dim pvtRegStateId As String = ds.Tables(0).Rows(0).Item("Reg_State_Id").ToString.Trim
                If pvtRegStateId = "A" OrElse pvtRegStateId = "D" OrElse pvtRegStateId = "D1" OrElse _
                   pvtRegStateId = "D2" Then
                    returnFlag = True
                End If
            End If

            Return returnFlag

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCategorySQLString(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, ByVal DrugType As String, ByVal SubSql As String) As String
        Dim sqlString As New System.Text.StringBuilder
        Dim pvtMergeSQL As String = ""

        '2012-10-24 Modify By Alan
        If SourceType = "E" Then
            pvtMergeSQL = " And P.Is_Emg='Y' "
        ElseIf SourceType = "I" Then
            pvtMergeSQL = " And P.Is_Ipd='Y' "
        End If


        sqlString.Append(" Union ")
        sqlString.Append("SELECT distinct ")
        sqlString.Append("       P.Favor_Category,'' AS Order_Code,'' AS Favor_Name, '' As Order_Name,'' As Order_En_Name,  ")
        sqlString.Append("       NULL AS Dosage,'' AS Dosage_Unit,'' AS Frequency_Code,'' AS Usage_Code,NULL AS Days,NULL AS Qty, ")
        sqlString.Append("       '' AS Unit,'' AS Default_Body_Site_Code,'' AS Specimen_Id,'' AS Is_Package,'' AS Sort_Value, ")
        sqlString.Append("       '' As Account_Id,'' As Is_Cure,'' As Cure_Type_Id,'' As Treatment_Type_Id,'' As Charge_Unit,")
        sqlString.Append("       Null As Nhi_Transrate,'' As Nhi_Unit,'' As Is_Order_Check,'' As Is_Indication,'' As Fix_Order_Id, ")
        sqlString.Append("       '' As Is_Exclude_Drug,'' As Order_Memo, '' As Order_Flag,'' As Is_Agree_Sheet, ")
        sqlString.Append("       '' As Is_Nhi_Sheet,'' As Is_Nhi_Index,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,'' As Order_Type_Id,'' As Is_Prior_Review,P.Category_View_Seq ")

        If FavorTypeId = "H" Then
            '若為急診檢驗檢查
            '=>1.需於名稱後面新增檢體名稱()
            '=>2.加入檢查替換部位Order判斷欄位
            '=>3.新增Sheet_Group欄位
            sqlString.Append(" ,'' As Specimen_Name ,'' As Option_Order,'' As Sheet_Group,'' As Sheet_Group_Name ")

            sqlString.Append("FROM OMO_Favor P  Left Join PUB_Order Q ")
            sqlString.Append(" On Q.Effect_Date <='" & Now.ToString("yyyy/M/d") & "'")
            sqlString.Append(" and Q.Order_Code=P.Order_Code ")
            sqlString.Append(" and Q.End_Date >='" & Now.ToString("yyyy/M/d") & "'")
            sqlString.Append(" and (Q.Dc = 'N' or (Q.Dc='Y' and Q.Is_Alternative='Y')) And Q.Treatment_Type_Id IN ('3','4') ")

            sqlString.Append("WHERE 1=1 ")
            If FavorId.ToString <> "" Then
                sqlString.Append(" and P.Favor_Id = '" & FavorId & "'")
            End If
            If FavorTypeId.ToString <> "" Then
                sqlString.Append(" and P.Favor_Type_Id ='H' ")
            End If

            If DoctorDeptCode.ToString <> "" Then
                sqlString.Append(" and P.Doctor_Dept_Code = '" & DoctorDeptCode & "'")
            End If
            sqlString.Append(pvtMergeSQL)

        ElseIf FavorTypeId = "D" Then
            sqlString.Append(",'' AS Default_Side_Id ")
            sqlString.Append("FROM OMO_Favor P Left Join PUB_Order Q ")
            sqlString.Append(" On Q.Effect_Date <='" & Now.ToString("yyyy/M/d") & "'")
            sqlString.Append(" and Q.Order_Code=P.Order_Code ")
            sqlString.Append(" and Q.End_Date >='" & Now.ToString("yyyy/M/d") & "'")
            sqlString.Append(" and (Q.Dc = 'N' or (Q.Dc='Y' and Q.Is_Alternative='Y'))  and ( Q.Treatment_Type_Id NOT IN ('3','4')  OR Q.Treatment_Type_Id IS NULL ) ")
            sqlString.Append("WHERE 1=1 ")
            If FavorId.ToString <> "" Then
                sqlString.Append(" and P.Favor_Id = '" & FavorId & "'")
            End If
            If FavorTypeId.ToString <> "" Then
                'sqlString.Append(" and P.Favor_Type_Id in ('D','J','H') ")
                If DoctorDeptCode <> "ENR" Then
                    If DrugType = "D" Then
                        sqlString.Append(" and ( P.Favor_Type_Id in ('D','H') ")
                    Else
                        sqlString.Append(" and ( P.Favor_Type_Id in ('D','H','T') ")
                    End If
                Else
                    sqlString.Append(" and ( P.Favor_Type_Id in ('D','H','G') ")
                End If


                sqlString.Append("      or ( P.Favor_Type_Id ='J' and P.Doctor_Dept_Code in ('32','33','35','39','70') ) ) ")
                sqlString.Append(" and  P.Favor_Category <>'開刀房手術' ")
            End If

            If DoctorDeptCode.ToString <> "" Then
                sqlString.Append(" and P.Doctor_Dept_Code = '" & DoctorDeptCode & "'")
            End If
            sqlString.Append(pvtMergeSQL)

        End If

        sqlString.Append(" and P.Favor_Category in (" & SubSql & ") ")

        Return sqlString.ToString

    End Function

    Public Function getCategorySQLStringForPCS(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, ByVal DrugType As String, ByVal SubSql As String) As String
        Dim sqlString As New System.Text.StringBuilder
        Dim pvtMergeSQL As String = ""


        If FavorId.ToString <> "" Then
            pvtMergeSQL &= " V.Favor_Id = '" & FavorId & "' and V.DC<>'Y' And  V.Is_Package<>'Y'  And V.Favor_Type_Id='P' "
        End If

        If DoctorDeptCode.ToString <> "" Then
            pvtMergeSQL &= " and V.Doctor_Dept_Code = '" & DoctorDeptCode & "' "
        End If

        pvtMergeSQL &= " And  V.Is_Ipd='Y' And  V.Order_Code=W.Package_Code  And W.Is_Doctor='Y' and U.Type_Id='7411' and U.Code_Id=W.Treat_Kind_Id  "

        sqlString.Append(" Union ")
        sqlString.Append("SELECT distinct ")
        sqlString.Append("       U.Code_Name As Favor_Category,'' AS Order_Code,'' AS Favor_Name, '' As Order_Name,'' As Order_En_Name,  ")
        sqlString.Append("       NULL AS Dosage,'' AS Dosage_Unit,'' AS Frequency_Code,'' AS Usage_Code,NULL AS Days,NULL AS Qty, ")
        sqlString.Append("       '' AS Unit,'' AS Default_Body_Site_Code,'' AS Specimen_Id,'' AS Is_Package,'' AS Sort_Value, ")
        sqlString.Append("       '' As Account_Id,'' As Is_Cure,'' As Cure_Type_Id,'' As Treatment_Type_Id,'' As Charge_Unit,")
        sqlString.Append("       Null As Nhi_Transrate,'' As Nhi_Unit,'' As Is_Order_Check,'' As Is_Indication,'' As Fix_Order_Id, ")
        sqlString.Append("       '' As Is_Exclude_Drug,'' As Order_Memo, '' As Order_Flag,'' As Is_Agree_Sheet, ")
        sqlString.Append("       '' As Is_Nhi_Sheet,'' As Is_Nhi_Index,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,'P' As Order_Type_Id,'' As Is_Prior_Review,V.Category_View_Seq,'' AS Default_Side_Id ")
        sqlString.Append("From OMO_Favor V,STA_Package W,PUB_SysCode U  ")

        sqlString.Append("WHERE  " & pvtMergeSQL)

        sqlString.Append(" Union ")
        sqlString.Append("SELECT ")
        sqlString.Append("       U.Code_Name As Favor_Category,W.Package_Code As Order_Code,W.Package_Name As Favor_Name,W.Package_Name As Order_Name,W.Package_Name As Order_En_Name,   ")
        sqlString.Append("       NULL AS Dosage,'' AS Dosage_Unit,'' AS Frequency_Code,'' AS Usage_Code,NULL AS Days,NULL AS Qty, ")
        sqlString.Append("       '' AS Unit,'' AS Default_Body_Site_Code,'' AS Specimen_Id,'' AS Is_Package,'' AS Sort_Value, ")
        sqlString.Append("       '' As Account_Id,'' As Is_Cure,'' As Cure_Type_Id,'' As Treatment_Type_Id,'' As Charge_Unit,")
        sqlString.Append("       Null As Nhi_Transrate,'' As Nhi_Unit,'' As Is_Order_Check,'' As Is_Indication,'' As Fix_Order_Id, ")
        sqlString.Append("       '' As Is_Exclude_Drug,'' As Order_Memo, '' As Order_Flag,'' As Is_Agree_Sheet, ")
        sqlString.Append("       '' As Is_Nhi_Sheet,'' As Is_Nhi_Index,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,'P' As Order_Type_Id,'' As Is_Prior_Review,V.Category_View_Seq,'' AS Default_Side_Id ")
        sqlString.Append("From OMO_Favor V,STA_Package W,PUB_SysCode U  ")

        sqlString.Append("WHERE  " & pvtMergeSQL)



        Return sqlString.ToString

    End Function

    ''' <summary>
    ''' 常用診斷資料查詢
    ''' </summary>
    ''' <param name="SourceTypeId"></param>
    ''' <param name="DiagType"></param>
    ''' <param name="DoctorCode"></param>
    ''' <param name="DeptCode"></param>
    ''' <param name="DiagCode"></param>
    ''' <param name="DiagDesc"></param>
    ''' <returns>常用診斷初始化資料</returns>
    ''' <remarks></remarks>
    Public Function queryOMODiagFavorInit(ByVal SourceTypeId As String, ByVal DiagType As String,
                                          ByVal DoctorCode As String, ByVal DeptCode As String,
                                          ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet

        Dim dsDept, dsInsuDept, dsDoctorFavor, dsDeptFavor As New DataSet

        Try

            '1.取得細分科
            dsDept = queryPUBDepartmentAll_D2(SourceTypeId)
            If dsDept.Tables.Count > 0 Then
                dsDept.Tables(0).TableName = "PUB_Department"
            End If

            '2.取得健保科
            dsInsuDept = queryPUBInsuDeptAll(SourceTypeId, DiagType)
            If dsInsuDept.Tables.Count > 0 Then
                dsInsuDept.Tables(0).TableName = "PUB_Insu_Dept"
            End If

            '取得醫師常用分類
            dsDoctorFavor = queryDiagFavorCategory(SourceTypeId, "1", DoctorCode, DiagType, DiagCode, DiagDesc)
            If dsDoctorFavor.Tables.Count > 0 Then
                dsDoctorFavor.Tables(0).TableName = "OMO_Favor_Diag_Doctor"
            End If

            '取得科別常用分類
            dsDeptFavor = queryDiagFavorCategory(SourceTypeId, "2", DeptCode, DiagType, DiagCode, DiagDesc)
            If dsDeptFavor.Tables.Count > 0 Then
                dsDeptFavor.Tables(0).TableName = "OMO_Favor_Diag_Dept"
            End If

            Using ds As DataSet = New DataSet
                ds.Merge(dsDept)
                ds.Merge(dsInsuDept)
                ds.Merge(dsDoctorFavor)
                ds.Merge(dsDeptFavor)
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            If (dsDept IsNot Nothing) Then dsDept.Dispose()
            If (dsInsuDept IsNot Nothing) Then dsInsuDept.Dispose()
            If (dsDoctorFavor IsNot Nothing) Then dsDoctorFavor.Dispose()
            If (dsDeptFavor IsNot Nothing) Then dsDeptFavor.Dispose()
        End Try
    End Function

    ''' <summary>
    ''' 取得健保科(For ComboBox)
    ''' </summary>    
    Public Function queryPUBInsuDeptAll(ByVal SourceTypeId As String, ByVal DiagType As String) As System.Data.DataSet

        Dim cmdStr As New StringBuilder

        Try
            '門急診Kind_Code固定為"O"
            If SourceTypeId = "E" Then
                SourceTypeId = "O"
            End If

            cmdStr.AppendLine("Select distinct RTrim(A.Insu_Dept_Code) As Insu_Dept_Code, RTrim(B.Insu_Dept_Code_Name) As Insu_Dept_Code_Name " & vbCrLf)
            cmdStr.AppendLine("From PUB_ICD10_Dept A " & vbCrLf)
            cmdStr.AppendLine("   Inner Join PUB_Insu_Dept B On A.Insu_Dept_Code = B.Insu_Dept_Code " & vbCrLf)
            cmdStr.AppendLine("Where A.Kind_Code ='" & SourceTypeId & "' and A.Disease_Type_Id='" & DiagType & "' " & vbCrLf)
            cmdStr.AppendLine("Order By Insu_Dept_Code " & vbCrLf)

            Try
                Using conn As SqlConnection = getConnection()
                    Using Command As SqlCommand = conn.CreateCommand

                        Command.CommandText = cmdStr.ToString

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                            Using ds As DataSet = New DataSet
                                adapter.Fill(ds, "PUB_Insu_Dept")
                                Return ds
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得健保次分科(For ComboBox)
    ''' </summary>    
    Public Function queryPUBInsuSubDept(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal InsuDeptCode As String) As System.Data.DataSet

        Dim cmdStr As New StringBuilder

        Try
            '門急診Kind_Code固定為"O"
            If SourceTypeId = "E" Then
                SourceTypeId = "O"
            End If
            cmdStr.AppendLine("Select distinct RTrim(A.Insu_Dept_Code) As Insu_Dept_Code, RTrim(B.Insu_Dept_Code_Name) As Insu_Dept_Code_Name " & vbCrLf)
            cmdStr.AppendLine("From PUB_ICD10_Dept A " & vbCrLf)
            cmdStr.AppendLine("   Inner Join PUB_Insu_Dept B On A.Insu_Sub_Dept_Code = B.Insu_Dept_Code " & vbCrLf)
            cmdStr.AppendLine("Where A.Kind_Code ='" & SourceTypeId & "' and A.Disease_Type_Id='" & DiagType & "' and A.Insu_Dept_Code='" & InsuDeptCode & "' " & vbCrLf)
            cmdStr.AppendLine("Order By Insu_Dept_Code " & vbCrLf)
            Try
                Using conn As SqlConnection = getConnection()
                    Using Command As SqlCommand = conn.CreateCommand

                        Command.CommandText = cmdStr.ToString

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                            Using ds As DataSet = New DataSet
                                adapter.Fill(ds, "PUB_Insu_Sub_Dept")
                                Return ds
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得常用診斷分類(For ComboBox)
    ''' </summary>    
    Public Function queryDiagFavorCategory(ByVal SourceTypeId As String, ByVal FavorId As String, _
                                           ByVal DoctorOrDeptCode As String, ByVal DiagType As String, _
                                           ByVal DiagCode As String, ByVal DiagDesc As String) As System.Data.DataSet

        Dim cmdStr As New StringBuilder

        Try

            Dim pvtMergeSQL As String = ""

            Select Case SourceTypeId
                Case "O"
                    pvtMergeSQL = " A.Is_Opd='Y' "
                Case "E"
                    pvtMergeSQL = " A.Is_Emg='Y' "
                Case "I"
                    pvtMergeSQL = " A.Is_Ipd='Y' "
            End Select

            cmdStr.AppendLine("SELECT DISTINCT A.Favor_Category " & vbCrLf)
            'cmdStr.AppendLine("FROM OMO_Favor_Icd A WITH(NOLOCK),PUB_Disease B WITH(NOLOCK)  " & vbCrLf)
            cmdStr.AppendLine("FROM OMO_Favor_Icd A WITH(NOLOCK)  " & vbCrLf)
            cmdStr.AppendLine("      ")
            cmdStr.AppendLine("WHERE A.Favor_Id = '" & FavorId & "' AND A.Doctor_Dept_Code = '" & DoctorOrDeptCode & "' AND A.DC<>'Y' " & vbCrLf)

            If DiagType <> "" Then
                cmdStr.AppendLine(" And A.Disease_Type_Id ='" & DiagType & "' ")
            End If

            If DiagCode <> "" Then
                cmdStr.AppendLine(" And A.ICD_Code LIKE '" & DiagCode & "%' ")
            End If

            If DiagDesc <> "" Then
                cmdStr.AppendLine(" And A.Favor_Name LIKE '%" & DiagDesc & "%' ")
            End If

            If pvtMergeSQL <> "" Then
                cmdStr.AppendLine(" And " & pvtMergeSQL)
            End If

            'cmdStr.AppendLine(" And B.Effect_Date <= '" & Now.ToString("yyyy/MM/dd") & "' And   B.ICD_Code=A.ICD_Code  And   B.Dc<>'Y' ")
            'cmdStr.AppendLine(" And B.End_Date>= '" & Now.ToString("yyyy/MM/dd") & "' And B.Disease_Type_id='" & DiagType & "' ")

            Try
                Using conn As SqlConnection = getConnection()
                    Using Command As SqlCommand = conn.CreateCommand

                        Command.CommandText = cmdStr.ToString

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                            Using ds As DataSet = New DataSet
                                adapter.Fill(ds, "OMO_Favor_Diag")
                                Return ds
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得診斷分類(For ComboBox)
    ''' </summary>    
    Public Function queryDiagCategory(ByVal DiagType As String, ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet

        Dim cmdStr As New StringBuilder

        Try
            Dim pvtMergeSql As String = ""

            If DiagCode <> "" Then
                pvtMergeSql &= " And A.Icd_Code Like '" & DiagCode & "%' "
            End If

            If DiagDesc <> "" Then
                pvtMergeSql &= " And A.Disease_En_Name Like '%" & DiagDesc & "%' "
            End If

            cmdStr.AppendLine("Select A.ICD_Code+' ' +A.Disease_En_Name As Favor_Category,A.ICD_Code " & vbCrLf)
            cmdStr.AppendLine("From PUB_Disease A  " & vbCrLf)
            cmdStr.AppendLine("Where A.Effect_Date <= '" & Now.ToString("yyyy/MM/dd") & "' And  A.Dc<>'Y' And ")
            cmdStr.AppendLine("      A.End_Date>= '" & Now.ToString("yyyy/MM/dd") & "' And A.Disease_Type_id='" & DiagType & "' " & vbCrLf)
            cmdStr.AppendLine("      " & pvtMergeSql & vbCrLf)
            cmdStr.AppendLine(" ORDER By A.ICD_Code")

            Try
                Using conn As SqlConnection = getConnection()
                    Using Command As SqlCommand = conn.CreateCommand

                        Command.CommandText = cmdStr.ToString

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                            Using ds As DataSet = New DataSet
                                adapter.Fill(ds, "PUB_Disease")
                                Return ds
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得診斷分類(For ComboBox)
    ''' </summary>    
    Public Function queryICD10Category(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal IsInsu As String) As DataSet

        Dim cmdStr As New StringBuilder

        Try

            If IsInsu = "N" Then
                cmdStr.AppendLine("Select Rtrim(Code_Id) +' '+ Rtrim(Code_En_Name) as Favor_Category,Code_Id as ICD_Code " & vbCrLf)
                cmdStr.AppendLine("From PUB_SysCode " & vbCrLf)
                cmdStr.AppendLine("Where Type_Id='2006' and DC<>'Y' " & vbCrLf)
                cmdStr.AppendLine("Order By Sort_Value " & vbCrLf)

            Else
                cmdStr.AppendLine("Select distinct Rtrim(A.Insu_Dept_Code) +' '+Rtrim(B.Insu_Dept_Code_Name) As Favor_Category,A.Insu_Dept_Code " & vbCrLf)
                cmdStr.AppendLine("From PUB_ICD10_Dept A ")
                cmdStr.AppendLine("          Inner Join PUB_Insu_Dept B on A.Insu_Dept_Code=B.Insu_Dept_Code " & vbCrLf)
                cmdStr.AppendLine("Where A.Kind_Code ='" & SourceTypeId & "' and A.Disease_Type_Id ='" & DiagType & "' " & vbCrLf)
                cmdStr.AppendLine("Order By A.Insu_Dept_Code " & vbCrLf)

            End If

            Try
                Using conn As SqlConnection = getConnection()
                    Using Command As SqlCommand = conn.CreateCommand

                        Command.CommandText = cmdStr.ToString

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                            Using ds As DataSet = New DataSet
                                adapter.Fill(ds, "PUB_Disease")
                                Return ds
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得診斷明細
    ''' </summary>    
    Public Function queryICDDetail(ByVal SelType As String, ByVal SourceTypeId As String, ByVal DiagType As String, _
                                   ByVal FavorId As String, ByVal DoctorDeptCode As String, ByVal FavorCategory As String, _
                                   ByVal ICDCode As String, ByVal ICD10ChapterId As String, ByVal InsuDeptCode As String, _
                                   ByVal InsuSubDeptCode As String, ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet

        Dim cmdStr As New StringBuilder

        Try

            Select Case SelType
                Case "1", "2"
                    Dim pvtMergeSQL As String = ""

                    Select Case SourceTypeId
                        Case "O"
                            pvtMergeSQL = " and A.Is_Opd='Y' "
                        Case "E"
                            pvtMergeSQL = " and A.Is_Emg='Y' "
                        Case "I"
                            pvtMergeSQL = " and A.Is_Ipd='Y' "
                    End Select
                    cmdStr.AppendLine("Select distinct ")
                    cmdStr.AppendLine("       CASE WHEN C.Disease_En_Name IS NOT NULL THEN ")
                    cmdStr.AppendLine("            CASE WHEN  A.ICD_Code IS NOT NULL THEN ")
                    cmdStr.AppendLine("                 LEFT(CAST(Rtrim(A.ICD_Code)  as NVARCHAR) + REPLICATE(' ',10), 10) + ' - ' + LEFT(CAST(RTRIM(A.ICD10_Code) as NVARCHAR) + REPLICATE(' ',10), 10) + ' - ' +  C.Disease_En_Name ")
                    cmdStr.AppendLine("            ELSE ")
                    cmdStr.AppendLine("                 ' - ' + LEFT(CAST(RTRIM(A.ICD10_Code) as NVARCHAR) + REPLICATE(' ',10), 10) + ' - ' +  C.Disease_En_Name  ")
                    cmdStr.AppendLine("            END ")
                    cmdStr.AppendLine("       ELSE ")
                    cmdStr.AppendLine("            CASE WHEN  A.ICD_Code IS NOT NULL THEN ")
                    cmdStr.AppendLine("                 LEFT(CAST(Rtrim(A.ICD_Code)  as NVARCHAR) + REPLICATE(' ',10), 10) + ' - ' + LEFT(CAST(RTRIM(A.ICD_Code) as NVARCHAR) + REPLICATE(' ',10), 10) + ' - ' +  D.Disease_En_Name ")
                    cmdStr.AppendLine("            ELSE ")
                    cmdStr.AppendLine("                 ' - ' + LEFT(CAST(RTRIM(A.ICD_Code) as NVARCHAR) + REPLICATE(' ',10), 10) + ' - ' +  D.Disease_En_Name ")
                    cmdStr.AppendLine("            END ")
                    cmdStr.AppendLine("       END As Diag_Name, ")
                    cmdStr.AppendLine("       A.ICD_Code , A.ICD10_Code , A.Sort_Value  ,'N' As Is_Doubt,C.Disease_En_Name As ICD10_Name,C.Infection_Type_Id,C.Is_Chronic_Disease,C.Is_Severe_Disease ")
                    cmdStr.AppendLine("From OMO_Favor_Icd A  ")
                    cmdStr.AppendLine("         Left join PUB_Disease_ICD10_Mapping B  on B.Disease_Type_Id= A.Disease_Type_Id ")
                    cmdStr.AppendLine("                    and B.Icd10_Code =A.ICD10_Code ")
                    cmdStr.AppendLine("         Left join PUB_Disease_ICD10 C on  ")
                    cmdStr.AppendLine("                C.Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "' ")
                    cmdStr.AppendLine("                and C.ICD_Code =B.ICD10_Code ")
                    cmdStr.AppendLine("                and C.Disease_Type_Id = '" & DiagType & "' ")
                    cmdStr.AppendLine("                and C.End_Date>='" & Now.ToString("yyyy/MM/dd") & "' ")
                    cmdStr.AppendLine("                and C.DC <> 'Y' ")
                    cmdStr.AppendLine("         Left Join PUB_Disease D on ")
                    cmdStr.AppendLine("                D.Effect_Date <='" & Now.ToString("yyyy/MM/dd") & "' ")
                    cmdStr.AppendLine("                and D.Icd_Code = A.ICD_Code ")
                    cmdStr.AppendLine("                and D.Disease_Type_Id=A.Disease_Type_Id ")
                    cmdStr.AppendLine("                and D.End_Date>='" & Now.ToString("yyyy/MM/dd") & "' ")
                    cmdStr.AppendLine("                and D.DC<>'Y' ")
                    cmdStr.AppendLine("Where A.Favor_Id='" & FavorId & "'   ")
                    cmdStr.AppendLine("      and A.Doctor_Dept_Code='" & DoctorDeptCode & "' ")

                    If DiagType <> "" Then
                        cmdStr.AppendLine("      and A.Disease_Type_Id ='" & DiagType & "' ")
                    End If

                    If FavorCategory <> "" Then
                        cmdStr.AppendLine("      and A.Favor_Category ='" & FavorCategory & "' ")
                    End If

                    cmdStr.AppendLine("      and A.DC<>'Y' ")

                    If DiagCode <> "" Then
                        cmdStr.AppendLine("      and (A.ICD_Code Like '" & DiagCode & "%' ")
                        cmdStr.AppendLine("      or A.ICD10_Code Like '" & DiagCode & "%') ")
                    End If

                    If DiagDesc <> "" Then
                        cmdStr.AppendLine("      and A.Favor_Name Like '%" & DiagDesc & "%' ")
                    End If

                    cmdStr.AppendLine(pvtMergeSQL)
                    cmdStr.AppendLine("      and B.ICD10_Code IS NOT NULL  ")
                    cmdStr.AppendLine("Order By A.Sort_Value  ")

                Case "3"
                    cmdStr.AppendLine("Select LEFT(CAST(RTRIM(B.ICD10_Code) as NVARCHAR) + REPLICATE(' ',10), 10) + ' - ' + C.Disease_En_Name + ' - ' + Rtrim(B.ICD_Code) As Diag_Name ,  ")
                    cmdStr.AppendLine("       B.ICD_Code , B.ICD10_Code ,'N' As Is_Doubt,C.Disease_En_Name As ICD10_Name,C.Infection_Type_Id,C.Is_Chronic_Disease,C.Is_Severe_Disease ")
                    cmdStr.AppendLine("From PUB_Disease A  ")
                    cmdStr.AppendLine("          Left join PUB_Disease_ICD10_Mapping B  on B.Disease_Type_Id='" & DiagType & "' ")
                    cmdStr.AppendLine("                    and A.Icd_Code =B.ICD_Code ")
                    cmdStr.AppendLine("          Left join PUB_Disease_ICD10 C on C.Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "' ")
                    cmdStr.AppendLine("                                           and C.ICD_Code =B.ICD10_Code ")
                    cmdStr.AppendLine("                                           and C.Disease_Type_Id = A.Disease_Type_Id  ")
                    cmdStr.AppendLine("                                           and C.End_Date>='" & Now.ToString("yyyy/MM/dd") & "'  ")
                    cmdStr.AppendLine("                                           and C.DC <> 'Y' ")
                    cmdStr.AppendLine("Where A.Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "'  ")

                    If ICDCode <> "" Then
                        cmdStr.AppendLine("      and A.ICD_Code='" & ICDCode & "'  ")
                    End If

                    cmdStr.AppendLine("      and A.End_Date>='" & Now.ToString("yyyy/MM/dd") & "'")
                    cmdStr.AppendLine("      and A.Disease_Type_Id='" & DiagType & "' ")
                    cmdStr.AppendLine("      and A.DC<>'Y' ")

                    If DiagCode <> "" Then
                        cmdStr.AppendLine("      and (B.ICD_Code Like '" & DiagCode & "%' ")
                        cmdStr.AppendLine("      or B.ICD10_Code Like '" & DiagCode & "%') ")
                    End If

                    If DiagDesc <> "" Then
                        cmdStr.AppendLine("      and C.Disease_En_Name Like '%" & DiagDesc & "%' ")
                    End If

                    cmdStr.AppendLine("      and B.ICD10_Code IS NOT NULL ")
                    cmdStr.AppendLine("Order By ICD10_code  ")

                Case "4"
                    cmdStr.AppendLine("Select LEFT(CAST(RTRIM(B.ICD10_Code) as NVARCHAR) + REPLICATE(' ',10), 10) + ' - ' + C.Disease_En_Name + ' - ' + Rtrim(B.ICD_Code) As Diag_Name,  ")
                    cmdStr.AppendLine("       B.ICD_Code , B.ICD10_Code ,'N' As Is_Doubt,A.Disease_En_Name As ICD10_Name,A.Infection_Type_Id,A.Is_Chronic_Disease,A.Is_Severe_Disease ")
                    cmdStr.AppendLine("From PUB_Disease_ICD10 A  ")
                    cmdStr.AppendLine("       Left join  PUB_Disease_ICD10_Mapping B  on B.Disease_Type_Id='" & DiagType & "' ")
                    cmdStr.AppendLine("                                     and B.ICD10_Code =A.Icd_Code ")
                    cmdStr.AppendLine("       Left Join  PUB_Disease C  On  C.Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "'  ")
                    cmdStr.AppendLine("                                     and C.Icd_Code =B.ICD_Code ")
                    cmdStr.AppendLine("                                     and C.Disease_Type_Id = A.Disease_Type_Id ")
                    cmdStr.AppendLine("                                     and C.End_Date>='" & Now.ToString("yyyy/MM/dd") & "' ")
                    cmdStr.AppendLine("                                     and C.DC <> 'Y' ")
                    cmdStr.AppendLine("Where A.Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "'   ")
                     
                    If ICD10ChapterId <> "" Then
                        cmdStr.AppendLine("      and A.ICD10_Chapter_Id='" & ICD10ChapterId & "'")
                    End If

                    cmdStr.AppendLine("      and A.Disease_Type_Id='" & DiagType & "' ")
                    cmdStr.AppendLine("      and A.End_Date>='" & Now.ToString("yyyy/MM/dd") & "'   ")
                    cmdStr.AppendLine("      and A.DC<>'Y' ")

                    If DiagCode <> "" Then
                        cmdStr.AppendLine("      and B.ICD10_Code Like '" & DiagCode & "%' ")
                    End If

                    If DiagDesc <> "" Then
                        cmdStr.AppendLine("      and A.Disease_En_Name Like '%" & DiagDesc & "%' ")
                    End If

                    cmdStr.AppendLine("      and B.ICD10_Code IS NOT NULL ")
                    cmdStr.AppendLine("Order By B.ICD10_Code   ")

                Case "5"

                    If SourceTypeId = "E" Then
                        SourceTypeId = "O"
                    End If

                    cmdStr.AppendLine("Select LEFT(CAST(RTRIM(C.ICD10_Code) as NVARCHAR) + REPLICATE(' ',10), 10) + ' - ' + D.Disease_En_Name + ' - ' + Rtrim(C.ICD_Code) As Diag_Name,  ")
                    cmdStr.AppendLine("       C.ICD_Code , C.ICD10_Code ,'N' As Is_Doubt,B.Disease_En_Name As ICD10_Name,B.Infection_Type_Id,B.Is_Chronic_Disease,B.Is_Severe_Disease  ")
                    cmdStr.AppendLine("From  PUB_ICD10_Dept A  ")
                    cmdStr.AppendLine("          Left Join PUB_Disease_ICD10 B ON B.Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "'  ")
                    cmdStr.AppendLine("                                             and B.Icd_Code = A.ICD10_Code ")
                    cmdStr.AppendLine("                                             and B.Disease_Type_Id='" & DiagType & "' ")
                    cmdStr.AppendLine("                                             and B.End_Date>='" & Now.ToString("yyyy/MM/dd") & "' ")
                    cmdStr.AppendLine("                                             and B.DC<>'Y' ")
                    cmdStr.AppendLine("          Left join  PUB_Disease_ICD10_Mapping C  on C.Disease_Type_Id='" & DiagType & "' ")
                    cmdStr.AppendLine("                                        and C.ICD10_Code =B.Icd_Code ")

                    cmdStr.AppendLine("          Left Join  PUB_Disease D  On  D.Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "' ")
                    cmdStr.AppendLine("                                        and D.Icd_Code =C.ICD_Code ")
                    cmdStr.AppendLine("                                        and D.Disease_Type_Id = B.Disease_Type_Id ")
                    cmdStr.AppendLine("                                        and D.End_Date>='" & Now.ToString("yyyy/MM/dd") & "' ")
                    cmdStr.AppendLine("                                        and D.DC <> 'Y' ")
                    cmdStr.AppendLine("Where A.Kind_Code='" & SourceTypeId & "'   ")
                    cmdStr.AppendLine("      and A.Disease_Type_Id ='" & DiagType & "' ")
                    cmdStr.AppendLine("      and A.Insu_Dept_Code ='" & InsuDeptCode & "' ")

                    If InsuSubDeptCode <> "" Then
                        cmdStr.AppendLine("      and A.Insu_Sub_Dept_Code='" & InsuSubDeptCode & "' ")
                    End If

                    If DiagCode <> "" Then
                        cmdStr.AppendLine("      and C.ICD10_Code Like '" & DiagCode & "%' ")
                    End If

                    If DiagDesc <> "" Then
                        cmdStr.AppendLine("      and B.Disease_En_Name Like '%" & DiagDesc & "%' ")
                    End If

                    cmdStr.AppendLine("      and C.ICD10_Code IS NOT NULL ")
                    cmdStr.AppendLine("Order By C.ICD10_Code  ")

            End Select

            Try
                Using conn As SqlConnection = getConnection()
                    Using Command As SqlCommand = conn.CreateCommand

                        Command.CommandText = cmdStr.ToString

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                            Using ds As DataSet = New DataSet
                                adapter.Fill(ds, "PUB_Disease")
                                Return ds
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢醫令選取註記
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBConfigChoiceDcOrder(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim cmdStr As String

        Try
            'SQL
            cmdStr = "SELECT Config_Value " & _
                     " FROM PUB_Config " & _
                     " WHERE Config_Name='Choice_Dc_Order'"

            '執行SQL
            Try
                If conn Is Nothing Then
                    conn = getConnection()
                End If

                Using Command As SqlCommand = CType(conn, SqlConnection).CreateCommand

                    Command.CommandText = cmdStr.ToString

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                        Using ds As DataSet = New DataSet
                            adapter.Fill(ds, "PUB_Config")
                            Return ds
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
