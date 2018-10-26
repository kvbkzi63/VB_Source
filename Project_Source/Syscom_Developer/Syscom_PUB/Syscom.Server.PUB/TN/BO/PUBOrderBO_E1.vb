Imports System.Text
Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.EXP

Public Class PUBOrderBO_E1
    Inherits PubOrderBO

    Private tableName1 = "PUB_Order"


#Region "########## getInstance ##########"
    Private Shared instance As PUBOrderBO_E1
    Public Overloads Shared Function getInstance() As PUBOrderBO_E1
        If instance Is Nothing Then
            instance = New PUBOrderBO_E1
        End If
        Return instance
    End Function
#End Region

    Private Function getEISDBConnection() As SqlConnection
        Return SQLConnFactory.getInstance.getEisDBSqlConn
    End Function

    Private Function getPUBDBConnection() As SqlConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

#Region "2016/9/20 新增PUB_Order "

    ''' <summary>
    '''新增PUB_Order
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function insertPubOrder(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Effect_Date , Order_Code , Order_En_Name , Order_Name , Order_En_Short_Name ,  " & _
             " Order_Short_Name , Order_Type_Id , Account_Id , Is_Cure , Cure_Type_Id ,  " & _
             " Treatment_Type_Id , Charge_Unit , Nhi_Transrate , Nhi_Unit , Is_Order_Check ,  " & _
             " Fix_Order_Id , Is_Exclude_Drug , Order_Note , Order_Memo , Is_Agree_Sheet ,  " & _
             " Is_Nhi_Sheet , Is_Prior_Review , Is_IC_Card_Order , Is_Order_Price_Special , Dc_Reason ,  " & _
             " Dc , End_Date , Create_User , Create_Time , Modified_User ,  " & _
             " Modified_Time , Old_Order_Code , Material_Used_Cnt , Include_Order_Mark , Insu_Cover_Opd ,  " & _
             " Insu_Cover_Emg , Insu_Cover_Ipd , Is_Icd_Check , Is_Emg_Nursing_Charge , Majorcare_Code ,  " & _
             " Cost_Price ) " & _
             " values( @Effect_Date , @Order_Code , @Order_En_Name , @Order_Name , @Order_En_Short_Name ,  " & _
             " @Order_Short_Name , @Order_Type_Id , @Account_Id , @Is_Cure , @Cure_Type_Id ,  " & _
             " @Treatment_Type_Id , @Charge_Unit , @Nhi_Transrate , @Nhi_Unit , @Is_Order_Check ,  " & _
             " @Fix_Order_Id , @Is_Exclude_Drug , @Order_Note , @Order_Memo , @Is_Agree_Sheet ,  " & _
             " @Is_Nhi_Sheet , @Is_Prior_Review , @Is_IC_Card_Order , @Is_Order_Price_Special , @Dc_Reason ,  " & _
             " @Dc , @End_Date , @Create_User , @Create_Time , @Modified_User ,  " & _
             " @Modified_Time , @Old_Order_Code , @Material_Used_Cnt , @Include_Order_Mark , @Insu_Cover_Opd ,  " & _
             " @Insu_Cover_Emg , @Insu_Cover_Ipd , @Is_Icd_Check , @Is_Emg_Nursing_Charge , @Majorcare_Code ,  " & _
             " @Cost_Price             )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Order_En_Name", row.Item("Order_En_Name"))
                    command.Parameters.AddWithValue("@Order_Name", row.Item("Order_Name"))
                    command.Parameters.AddWithValue("@Order_En_Short_Name", row.Item("Order_En_Short_Name"))
                    command.Parameters.AddWithValue("@Order_Short_Name", row.Item("Order_Short_Name"))
                    command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                    command.Parameters.AddWithValue("@Account_Id", row.Item("Account_Id"))
                    command.Parameters.AddWithValue("@Is_Cure", row.Item("Is_Cure"))
                    command.Parameters.AddWithValue("@Cure_Type_Id", row.Item("Cure_Type_Id"))
                    command.Parameters.AddWithValue("@Treatment_Type_Id", row.Item("Treatment_Type_Id"))
                    command.Parameters.AddWithValue("@Charge_Unit", row.Item("Charge_Unit"))
                    command.Parameters.AddWithValue("@Nhi_Transrate", row.Item("Nhi_Transrate"))
                    command.Parameters.AddWithValue("@Nhi_Unit", row.Item("Nhi_Unit"))
                    command.Parameters.AddWithValue("@Is_Order_Check", row.Item("Is_Order_Check"))
                    command.Parameters.AddWithValue("@Fix_Order_Id", row.Item("Fix_Order_Id"))
                    command.Parameters.AddWithValue("@Is_Exclude_Drug", row.Item("Is_Exclude_Drug"))
                    command.Parameters.AddWithValue("@Order_Note", row.Item("Order_Note"))
                    command.Parameters.AddWithValue("@Order_Memo", row.Item("Order_Memo"))
                    command.Parameters.AddWithValue("@Is_Agree_Sheet", row.Item("Is_Agree_Sheet"))
                    command.Parameters.AddWithValue("@Is_Nhi_Sheet", row.Item("Is_Nhi_Sheet"))
                    command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                    command.Parameters.AddWithValue("@Is_IC_Card_Order", row.Item("Is_IC_Card_Order"))
                    command.Parameters.AddWithValue("@Is_Order_Price_Special", row.Item("Is_Order_Price_Special"))
                    command.Parameters.AddWithValue("@Dc_Reason", row.Item("Dc_Reason"))
                    command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", CType(row.Item("Create_Time"), DateTime)) 'Ctype(NewOrderDS.Tables(0).Rows(0).Item("Create_Time"),datetime)
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    command.Parameters.AddWithValue("@Old_Order_Code", row.Item("Old_Order_Code"))
                    command.Parameters.AddWithValue("@Material_Used_Cnt", row.Item("Material_Used_Cnt"))
                    command.Parameters.AddWithValue("@Include_Order_Mark", row.Item("Include_Order_Mark"))
                    command.Parameters.AddWithValue("@Insu_Cover_Opd", row.Item("Insu_Cover_Opd"))
                    command.Parameters.AddWithValue("@Insu_Cover_Emg", row.Item("Insu_Cover_Emg"))
                    command.Parameters.AddWithValue("@Insu_Cover_Ipd", row.Item("Insu_Cover_Ipd"))
                    command.Parameters.AddWithValue("@Is_Icd_Check", row.Item("Is_Icd_Check"))
                    command.Parameters.AddWithValue("@Is_Emg_Nursing_Charge", row.Item("Is_Emg_Nursing_Charge"))
                    command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                    command.Parameters.AddWithValue("@Cost_Price", row.Item("Cost_Price"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "For OPCAPI用 2009/07/08/ Add By Nick"

    ''' <summary>
    ''' 規則2：
    ''' Order_Code為下列結果中第一筆的資料
    ''' SELECT Main_Identity_Id,Dept_Code,Medical_Type_Id, Order_Code 
    ''' FROM PUB_Register_Fee 
    ''' WHERE Main_Identity_Id=保險別(身份1) 
    ''' AND (Dept_Code=院內科別代碼 OR Dept_Code=' ') 
    ''' AND (Medical_Type_Id = 就醫類型 OR Medical_Type_Id = ' ') 
    ''' AND Dc=N
    ''' ORDER BY Main_Identity_Id,Dept_Code,Medical_Type_Id DESC
    ''' 
    ''' 再把Order_Code值代入如下：
    ''' Order_Type_Id值為O.Order_Type_Id
    ''' Account_Id值為O.Account_Id
    ''' SELECT O.Order_Type_Id,O.Account_Id 
    ''' FROM PUB_Order O 
    ''' WHERE O.Dc=N
    ''' AND O.Order_Code = Order_Code
    ''' AND O.Effect_Date ＜＝ 掛號日期、就醫日
    ''' AND O.End_Date ＞ 掛號日期、就醫日
    ''' </summary>
    ''' <param name="keyValue">
    ''' Key = Order_Code
    ''' Key = DATE：REG_DATE(掛號日)、OPD_VISIT_DATE(就醫日)
    ''' </param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getPubOrderDataForOPCAPI(ByVal keyValue As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select")
        cmdStr.AppendLine("Order_Type_Id,")
        cmdStr.AppendLine("Account_Id,")
        cmdStr.AppendLine("rtrim(Charge_Unit) as Charge_Unit")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from " + tableName)
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where 1=1")
        '20121105 by ccr 因有傳入批價日,拿掉DC=N條件,避免當批價日落在已DC之日子讀不到資料,直接以有效日期控管
        'cmdStr.AppendLine("and Dc=@Dc")
        cmdStr.AppendLine("and Order_Code=@Order_Code")
        cmdStr.AppendLine("and Effect_Date<=@DATE")
        cmdStr.AppendLine("and End_Date>=@DATE")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------

        Try
            Dim paramDT As DataTable = DataSetUtil.GenDataTable("paramDT", New String() {"Dc", "Order_Code", "DATE"})
            paramDT.Rows.Add(New Object() {"N", _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Order_Code")), _
                                           CDate(keyValue.Tables(0).Rows(0).Item("DATE")).ToShortDateString})

            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, paramDT, "select1", Nothing, conn)
            'Using conn As System.Data.SqlClient.SqlConnection = getConnection()
            '    Using sqlCmd As SqlCommand = New SqlCommand
            '        With sqlCmd
            '            .CommandText = cmdStr.ToString
            '            .CommandType = CommandType.Text
            '            .Connection = conn

            '            With keyValue.Tables(0).Rows(0)
            '                sqlCmd.Parameters.AddWithValue("@Dc", "N")
            '                sqlCmd.Parameters.AddWithValue("@Order_Code", .Item("Order_Code").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@DATE", Date.Parse(.Item("DATE")).ToString("yyyy/M/d"))
            '            End With
            '        End With

            '        conn.Open()

            '        Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
            '            Using dt As DataTable = New DataTable("returnValue")

            '                da.Fill(dt)

            '                Return dt
            '            End Using
            '        End Using

            '    End Using
            'End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "2009/09/07, Add By 谷官, 慢箋醫令處理(OPCChronicDetailOperationUI)"

    ''' <summary>
    ''' 取得Order_En_Name by Order_Code
    ''' </summary>
    ''' <param name="orderCode">批價碼</param>
    ''' <returns>Order_En_Name</returns>
    ''' <remarks></remarks>
    Public Function getOrderEnNameByOrderCode(ByVal orderCode As String) As String
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select")
        cmdStr.AppendLine("Order_En_Name")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from PUB_Order")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where 1=1")
        cmdStr.AppendLine("and Order_Code = @Order_Code")
        cmdStr.AppendLine("and Dc <> @DcY")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@DcY", "Y")
                        sqlCmd.Parameters.AddWithValue("@Order_Code", orderCode)

                    End With

                    conn.Open()

                    Dim returnValue As String = sqlCmd.ExecuteScalar()

                    If returnValue Is Nothing Then
                        Return ""
                    Else
                        Return returnValue
                    End If

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "一般醫令查詢 2009/9/18/ Add By Alan"

    Public Function queryPUBOrderAllTypeByCond(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, _
                                               ByVal Specimen As String, ByVal Body_Site As String) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            command.CommandText = " Select A.Order_Code,A.Order_En_Name,A.Order_Name "
            If OrderTypeId = "H" Then
                command.CommandText &= " ,B.Default_Body_Site_Code,B.Default_Side_Id,B.Is_Labdiscount,B.Is_Scheduled, " & _
                                       "  B.Is_Same_Specimen_Add,B.Default_Specimen_Id AS Specimen_Id,B.Default_Vessel_Id "

            End If

            command.CommandText &= " From PUB_Order A  "

            If OrderTypeId = "H" Then
                command.CommandText &= "                  Left Join PUB_Order_Examination B ON B.Order_Code=A.Order_Code "
            End If


            command.CommandText &= " Where A.Effect_Date<='" & Now.ToShortDateString & "' And  "
            command.CommandText &= "       A.End_Date>= '" & Now.ToShortDateString & "'  And "

            If OrderCode <> "" Then
                command.CommandText &= "       A.Order_Code Like '" & OrderCode & "%'  And "
            End If

            If OrderName <> "" Then
                command.CommandText &= "     (A.Order_En_Name Like '" & OrderName & "%'  OR "
                command.CommandText &= "      A.Order_Name Like '" & OrderName & "%' ) And "
            End If


            If OrderTypeId = "H" Then

                command.CommandText &= "       A.Order_Type_Id ='" & OrderTypeId & "'  And A.DC<>'Y'  "

                If Specimen <> "" Then
                    command.CommandText &= " And B.Default_Specimen_Id ='" & Specimen & "'   "
                End If

                If Body_Site <> "" Then
                    command.CommandText &= " And B.Default_Body_Site_Code ='" & Body_Site & "'   "
                End If

                command.CommandText &= "     And A.Treatment_Type_Id in ('3' , '4') "

            ElseIf OrderTypeId = "D" Then

                command.CommandText &= " ( A.Order_Type_Id ='" & OrderTypeId & "' "

                command.CommandText &= " Or ( A.Order_Type_Id='H' And A.Treatment_Type_Id not in ('3' , '4') ) )  And A.DC<>'Y' "
            Else

                command.CommandText &= "       A.Order_Type_Id ='" & OrderTypeId & "'  And A.DC<>'Y'  "

            End If
            command.CommandText &= " Order By A.Order_Code   "


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function queryPUBOrderAllTypeByCond2(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, _
                                               ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, _
                                               ByVal Chinese_Flag As String) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            command.CommandText = " Select A.Order_Code,A.Order_En_Name,A.Order_Name "
            If OrderTypeId = "H" Then
                command.CommandText &= " ,B.Default_Body_Site_Code,B.Default_Side_Id,B.Is_Labdiscount,B.Is_Scheduled, " & _
                                       "  B.Is_Same_Specimen_Add,B.Default_Specimen_Id AS Specimen_Id,B.Default_Vessel_Id "

            End If

            command.CommandText &= " ,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,A.Order_Type_Id "

            command.CommandText &= " From PUB_Order A  "

            If OrderTypeId = "H" Then
                command.CommandText &= "                  Left Join PUB_Order_Examination B ON (B.Order_Code=A.Order_Code) "
            End If

            'command.CommandText &= " Left Join PUB_Order_Price C "
            'command.CommandText &= " ON ( C.Effect_Date <= '" & Now.ToString("yyyy/M/d") & "' And C.Order_Code=A.Order_Code And C.Main_Identity_Id='2' "
            'command.CommandText &= " And C.End_Date >= '" & Now.ToString("yyyy/M/d") & "' And  C.DC<>'Y' ) "

            'command.CommandText &= " Left Join PUB_Order_Price D "
            'command.CommandText &= " ON ( D.Effect_Date <= '" & Now.ToString("yyyy/M/d") & "' And D.Order_Code=A.Order_Code And D.Main_Identity_Id='1' "
            'command.CommandText &= " And D.End_Date >= '" & Now.ToString("yyyy/M/d") & "' And  D.DC<>'Y' ) "


            command.CommandText &= " Where A.Effect_Date<='" & Now.ToShortDateString & "' And  "
            command.CommandText &= "       A.End_Date>= '" & Now.ToShortDateString & "'  And "

            If OrderCode <> "" Then
                command.CommandText &= "       A.Order_Code Like '" & OrderCode & "%'  And "
            End If

            If OrderName <> "" Then
                If Chinese_Flag = "N" Then
                    command.CommandText &= "     (A.Order_En_Name Like '%" & OrderName & "%'  OR "
                    command.CommandText &= "      A.Order_Name Like '%" & OrderName & "%' ) And "
                Else
                    command.CommandText &= "     (A.Order_En_Name Like '%" & OrderName & "%'  OR "
                    command.CommandText &= "      A.Order_Name Like '%" & OrderName & "%' ) And "
                End If

            End If


            If OrderTypeId = "H" Then

                command.CommandText &= "       A.Order_Type_Id ='" & OrderTypeId & "'  And A.DC<>'Y'  "

                If Specimen <> "" Then
                    command.CommandText &= " And B.Default_Specimen_Id ='" & Specimen & "'   "
                End If

                If Body_Site <> "" Then
                    command.CommandText &= " And B.Default_Body_Site_Code ='" & Body_Site & "'   "
                End If

                command.CommandText &= "     And A.Treatment_Type_Id in ('3' , '4') "

            ElseIf OrderTypeId = "D" Then

                If FavorCategory = "" Then
                    command.CommandText &= "  A.Order_Type_Id IN ('D','H','J') "
                    command.CommandText &= " And ( A.Order_Type_Id='H' And A.Treatment_Type_Id not in ('3' , '4') OR A.Treatment_Type_Id IS NULL  )  "

                ElseIf FavorCategory = "治療處置" Then
                    command.CommandText &= "  A.Order_Type_Id IN ('D','H') "
                    command.CommandText &= " And ( A.Order_Type_Id='H' And A.Treatment_Type_Id not in ('3' , '4') OR A.Treatment_Type_Id IS NULL  )  "

                ElseIf FavorCategory = "手術" Then
                    command.CommandText &= "  A.Order_Type_Id IN ('J') "
                End If

                command.CommandText &= " And A.DC<>'Y' "
            Else

                command.CommandText &= "       A.Order_Type_Id ='" & OrderTypeId & "'  And A.DC<>'Y'  "

            End If


            command.CommandText &= " Order By A.Order_En_Name   "


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function queryPUBOrderAllTypeByCond3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, _
                                                  ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, _
                                                  ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSQL As String = ""
            Dim pvtIsCoverOPD As Boolean = False

            If (SourceType = "E" OrElse SourceType = "I") AndAlso OrderTypeId = "H" AndAlso queryEMOMedicalRecordGetRegStateId(ChartNo, OutpatientSn) Then
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

            If OrderTypeId = "J" Then
                command.CommandText = " Select distinct A.Order_Code,A.Order_En_Name,A.Order_Name,B.Nameplate_Name "
            Else
                command.CommandText = " Select A.Order_Code,A.Order_En_Name,A.Order_Name "
            End If


            '若為急診檢驗檢查
            '=>1.需於名稱後面新增檢體名稱()
            '=>2.加入檢查替換部位Order判斷欄位
            If OrderTypeId = "H" Then
                command.CommandText &= " ,B.Default_Body_Site_Code,B.Default_Side_Id,B.Is_Labdiscount,B.Is_Scheduled, " & _
                                       "  B.Is_Same_Specimen_Add,B.Default_Specimen_Id AS Specimen_Id,B.Default_Vessel_Id,  " & _
                                       "  C.Code_Name  As Specimen_Name,D.Order_Code As Option_Order "
                command.CommandText &= "  ,(SELECT CASE B.Default_Specimen_Id WHEN '' Then F.Sheet_Group WHEN Null Then F.Sheet_Group ELSE E.Sheet_Group END) AS Sheet_Group "
                command.CommandText &= "  ,(SELECT CASE B.Default_Specimen_Id WHEN '' Then F.Sheet_Group_Name WHEN Null Then F.Sheet_Group_Name ELSE E.Sheet_Group_Name END) AS Sheet_Group_Name "

            End If

            command.CommandText &= " ,'' As Nhi_Price,'' As Own_Price,'' As Drug_Type,A.Order_Type_Id,A.Order_En_Short_Name,A.Charge_Unit,A.Is_Prior_Review,A.Treatment_Type_Id "

            command.CommandText &= " From PUB_Order A  "

            If OrderTypeId = "J" Then
                command.CommandText &= " , SUR_Op_Year_Nameplate B  "
            End If

            If OrderTypeId = "H" Then
                command.CommandText &= "                  Left Join PUB_Order_Examination B ON (B.Order_Code=A.Order_Code) "
                command.CommandText &= "                  Left Join  PUB_SysCode  C On  "
                command.CommandText &= "                  C.Type_Id='46' and C.Code_Id=B.Default_Specimen_Id and C.DC<>'Y' and C.Is_Emg='Y'  "
                command.CommandText &= "                  Left Join  PUB_Exam_Item D On D.Order_Code=A.Order_Code "
                command.CommandText &= "                  Left Join  PUB_Sheet_Group E On E.Sheet_Group=B.Default_Specimen_Id and E.Sheet_Code=SubString(A.Order_Code,0,5) And E.Order_Code =A.Order_Code "
                command.CommandText &= "                  Left Join  PUB_Sheet_Group F On F.Sheet_Group=B.Default_Body_Site_Code and  F.Sheet_Code=SubString(A.Order_Code,0,5) And F.Order_Code =A.Order_Code "
            End If

            command.CommandText &= " Where A.Effect_Date<='" & Now.ToShortDateString & "' And  "
            command.CommandText &= "       A.End_Date>= '" & Now.ToShortDateString & "'  And "

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

            If OrderTypeId = "H" Then

                command.CommandText &= "       A.Order_Type_Id ='" & OrderTypeId & "'  And A.DC<>'Y'  "

                If Specimen <> "" Then
                    command.CommandText &= " And B.Default_Specimen_Id ='" & Specimen & "'   "
                End If

                If Body_Site <> "" Then
                    command.CommandText &= " And B.Default_Body_Site_Code ='" & Body_Site & "'   "
                End If

                command.CommandText &= "     And A.Treatment_Type_Id in ('3' , '4') "

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

                    command.CommandText &= " And A.DC<>'Y' And " & pvtMergeSQL
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

                    command.CommandText &= " And A.DC<>'Y' And " & pvtMergeSQL
                End If

            Else

                command.CommandText &= "       A.Order_Type_Id ='" & OrderTypeId & "'  And A.DC<>'Y' And " & pvtMergeSQL

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
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

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
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
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

    Public Function queryPUBOrderIsDC(ByVal inOrderCode As String) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            command.CommandText = "  Select * "
            command.CommandText &= " From OPH_Pharmacy_Base  "
            command.CommandText &= " Where Order_Code='" & inOrderCode & "' And DC='Y' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 查詢被DC的醫令
    ''' </summary>
    ''' <param name="inOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBOrderDC(ByVal inOrderCode As String) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            command.CommandText = "  Select * "
            command.CommandText &= " From Pub_Order  "
            command.CommandText &= " Where Order_Code='" & inOrderCode & "' And DC='Y' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "2009/10/06 Add By Jen 醫令資料查詢(含醫令，醫令費用資料)"

    ''' <summary>
    ''' 醫令資料查詢(含醫令)
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <param name="EffectDate"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function queryOrderData(ByVal OrderCode As String, ByVal EffectDate As Date) As DataTable

        Dim cmdStrOrder As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrOrder.AppendLine("select top 1 * ")
        cmdStrOrder.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrder.AppendLine("where Order_Code = @OrderCode ")
        'cmdStrOrder.AppendLine("and Effect_Date <= @EffectDate ")
        'cmdStrOrder.AppendLine("and Dc <> @DcY ")
        cmdStrOrder.AppendLine("Order by  Effect_Date ")

        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrder.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                        'sqlCmd.Parameters.AddWithValue("@EffectDate", EffectDate)
                        'sqlCmd.Parameters.AddWithValue("@DcY", "Y")

                    End With

                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dtOrder)
                    End Using

                End Using

            End Using

            Return dtOrder

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryOrderData2(ByVal OrderCode As String, ByVal EffectDate As Date) As DataTable

        Dim cmdStrOrder As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        'modify by 唐子晴 2013.11.25===================================================
        ''cmdStrOrder.AppendLine("select top 1 * ")
        ''cmdStrOrder.Append("from ").Append(tableName).AppendLine(" ")
        ''cmdStrOrder.AppendLine("where Order_Code = @OrderCode ")
        ''cmdStrOrder.AppendLine("and Effect_Date <= @EffectDate ")
        ' ''cmdStrOrder.AppendLine("and Dc <> @DcY ")
        ''cmdStrOrder.AppendLine("Order by Effect_Date desc ")
        cmdStrOrder.AppendLine("select top 1 * ")
        cmdStrOrder.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrder.AppendLine("where Order_Code = @OrderCode ")
        cmdStrOrder.AppendLine("Order by Effect_Date desc ")
        '==============================================================================
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrder.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                        sqlCmd.Parameters.AddWithValue("@EffectDate", EffectDate)
                        'sqlCmd.Parameters.AddWithValue("@DcY", "Y")

                    End With

                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dtOrder)
                    End Using

                End Using

            End Using

            Return dtOrder

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 醫令資料完整查詢(含醫令)
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function queryCompleteOrderData(ByVal OrderCode As String) As DataTable

        Dim cmdStrOrder As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrOrder.AppendLine("select * ")
        cmdStrOrder.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrder.AppendLine("where Order_Code = @OrderCode ")
        'cmdStrOrder.AppendLine("and Effect_Date <= @EffectDate ")
        'cmdStrOrder.AppendLine("and Dc <> @DcY ")
        cmdStrOrder.AppendLine("Order by Effect_Date desc ")

        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrder.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                        'sqlCmd.Parameters.AddWithValue("@EffectDate", EffectDate)
                        sqlCmd.Parameters.AddWithValue("@DcY", "Y")

                    End With

                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dtOrder)
                    End Using

                End Using

            End Using

            Return dtOrder

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "2009/12/08 Add by Jen 查尋相似醫令碼"

    ''' <summary>
    ''' 查詢符合開頭字串醫令
    ''' </summary>
    ''' <param name="LikeOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function queryLikeOrderData(ByVal LikeOrderCode As String) As DataTable
        Dim systemDate As Date = DateUtil.getSystemDate
        Dim cmdStrOrder As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrOrder.AppendLine("select Order_Code, Order_Name, Order_En_Name ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStrOrder.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStrOrder.Append("where Order_Code like '").Append(LikeOrderCode).AppendLine("%' ")
        cmdStrOrder.AppendLine("and Effect_Date <= @EffectDate ")
        cmdStrOrder.AppendLine("and Dc <> @DcY ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStrOrder.AppendLine("Order by Order_Code ")
        '----------------------------------------------------------------------------
        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrder.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@EffectDate", systemDate)
                        sqlCmd.Parameters.AddWithValue("@DcY", "Y")

                    End With

                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dtOrder)
                    End Using

                End Using

            End Using

            Return dtOrder

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "2009/12/14 Add By Jen 更新sheet_detail內關聯的欄位"

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="dt">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updateSheetDetailRelatedOrder(ByVal dt As DataTable, Optional ByRef conn As IDbConnection = Nothing) As Integer

        '{"Order_Code", "Effect_Date", "Modified_User", "Is_Indication", "Order_Note"}
        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = getConnection()
            End If
            If conn.State <> ConnectionState.Open Then conn.Open()

            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Order_Note=@Order_Note , Modified_User=@Modified_User " & _
            " where  Order_Code=@Order_Code and Effect_Date=@Effect_Date "

            For Each row As DataRow In dt.Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@Is_Indication", row.Item("Is_Indication"))
                    command.Parameters.AddWithValue("@Order_Note", row.Item("Order_Note"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "2009/12/14 Add By James 給OrderCode 查 Order_En_Name"

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="Order_Code">醫令碼</param>
    ''' <remarks></remarks>
    Public Function queryPubOrderForOrderEnName(ByVal Order_Code As String) As String

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  " & tableName1 & " where Order_Code=@Order_Code   "
            command.Parameters.AddWithValue("@Order_Code", Order_Code)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using

            If ds.Tables.Count > 0 Then

                Return ds.Tables(0).Rows(0).Item(0).ToString.Trim
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "20100210 醫令查詢 by yaya"
    ''' <summary>
    ''' 醫令項目查詢
    ''' </summary>
    ''' <param name="ds">條件集合</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>
    ''' Pub_Order:資料集合
    ''' </remarks>
    Public Function QueryOrderItems(ByVal ds As DataSet) As DataSet
        Try
            Dim querySql As StringBuilder = New StringBuilder()
            Dim conditionSql As StringBuilder = New StringBuilder()
            Dim Order_Code, Order_Name, Order_En_Name, Order_Type_Id, Account_Id, Quote_Date As String
            Order_Code = ""
            Order_Name = ""
            Order_En_Name = ""
            Order_Type_Id = ""
            Account_Id = ""
            Quote_Date = ""

            For Each row As DataRow In ds.Tables("Query").Rows

                Order_Code = StringUtil.nvl(row("Order_Code"))
                Order_Name = StringUtil.nvl(row("Order_Name"))
                Order_En_Name = StringUtil.nvl(row("Order_En_Name"))
                Order_Type_Id = StringUtil.nvl(row("Order_Type_Id"))
                Account_Id = StringUtil.nvl(row("Account_Id"))
                Quote_Date = IIf(StringUtil.nvl(row("Quote_Date")).Length > 0, StringUtil.nvl(row("Quote_Date")), Now.ToString("yyyy/MM/dd"))
            Next

            Using conn As System.Data.IDbConnection = getConnection()
                querySql.Append("SELECT A.Order_Code , A.Order_Name , B.Exam_Detail_Desc, C.Price AS Self_Price, ")
                querySql.Append("D.Price AS NHI_Price, E.Default_Body_Site_Code , E.Default_Specimen_Id ,ISNULL(F.Discount_Rate,1) AS Min_Discount_Rate ")
                querySql.Append(" FROM PUB_Order AS A LEFT OUTER JOIN OHM_Exam_Content AS B ON A.Order_Code = B.Order_Code LEFT OUTER JOIN ")
                querySql.Append(" PUB_Order_Price AS C ON A.Order_Code = C.Order_Code AND @Quote_Date BETWEEN C.Effect_Date AND  ")
                querySql.Append(" C.End_Date AND C.Main_Identity_Id = @Main_Identity_Id_Self AND C.Dc = @DC_N LEFT OUTER JOIN ")
                querySql.Append(" PUB_Order_Price AS D ON A.Order_Code = D.Order_Code AND @Quote_Date BETWEEN D.Effect_Date AND  ")
                querySql.Append(" D.End_Date AND D.Main_Identity_Id = @Main_Identity_Id_NHI AND D.Dc = @DC_N LEFT OUTER JOIN ")
                querySql.Append(" PUB_Order_Examination AS E ON A.Order_Code = E.Order_Code LEFT OUTER JOIN ")
                querySql.Append(" OHM_Bottom_Dis_Set AS F ON @Quote_Date BETWEEN F.Effect_Date AND F.End_Date AND  ")
                querySql.Append(" (A.Order_Code = F.Order_Code OR A.Account_Id = F.Account_Id OR A.Order_Type_Id = F.Order_Type_Id) ")
                querySql.Append(" WHERE (@Quote_Date BETWEEN A.Effect_Date AND A.End_Date) AND (A.Dc = @DC_N) ")
                Using _dataset As DataSet = New DataSet()
                    Using command As SqlCommand = New SqlCommand
                        With command
                            If (Order_Code.Length > 0) Then
                                If (conditionSql.ToString.Length > 0) Then conditionSql.Append(" and ")
                                conditionSql.Append(" A.Order_Code like ").Append("@Order_Code").Append("+'%'")
                                .Parameters.AddWithValue("@Order_Code", Order_Code)
                            End If
                            If (Order_Name.Length > 0) Then
                                If (conditionSql.ToString.Length > 0) Then conditionSql.Append(" and ")
                                conditionSql.Append(" A.Order_Name like ").Append("'%'+").Append("@Order_Name").Append("+'%'")
                                .Parameters.AddWithValue("@Order_Name", Order_Name)
                            End If
                            If (Order_En_Name.Length > 0) Then
                                If (conditionSql.ToString.Length > 0) Then conditionSql.Append(" and ")
                                conditionSql.Append(" A.Order_En_Name like ").Append("'%'+").Append("@Order_En_Name").Append("+'%'")
                                .Parameters.AddWithValue("@Order_En_Name", Order_En_Name)
                            End If
                            If (Order_Type_Id.Length > 0) Then
                                If (conditionSql.ToString.Length > 0) Then conditionSql.Append(" and ")
                                conditionSql.Append(" A.Order_Type_Id=@Order_Type_Id ")
                                .Parameters.AddWithValue("@Order_Type_Id", Order_Type_Id)
                            End If
                            If (Account_Id.Length > 0) Then
                                If (conditionSql.ToString.Length > 0) Then conditionSql.Append(" and ")
                                conditionSql.Append(" A.Account_Id=@Account_Id ")
                                .Parameters.AddWithValue("@Account_Id", Account_Id)
                            End If
                            If (conditionSql.ToString.Length > 0) Then
                                querySql.Append(" and ").Append(conditionSql.ToString)
                            End If
                            .Parameters.AddWithValue("@Main_Identity_Id_Self", MagicNumbers.Main_Identity_Id_Self)
                            .Parameters.AddWithValue("@Main_Identity_Id_NHI", MagicNumbers.Main_Identity_Id_NHI)
                            .Parameters.AddWithValue("@DC_N", MagicNumbers.CODE_NO_DC_NO)
                            .Parameters.AddWithValue("@Quote_Date", Quote_Date)
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                            .CommandText = querySql.ToString
                        End With
                        Using _dataAdapter As SqlDataAdapter = New SqlDataAdapter(command)
                            _dataAdapter.Fill(_dataset, "Pub_Order")
                        End Using
                    End Using
                    Return _dataset
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    ''' <summary>
    ''' 程式說明：查詢醫令上一筆(下一筆)資料
    ''' 開發人員：Jen
    ''' 開發日期：2010.03.01
    ''' </summary>
    ''' <param name="partialOrderCode">部分醫令碼</param>
    ''' <param name="orderTypeId">醫令分類碼</param>
    ''' <param name="isPre">找上一筆?</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Order
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2010/03/10, XXX
    ''' </修改註記>
    Public Function queryPreOrNextRecordOrder(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal isPre As Boolean) As DataTable

        If (partialOrderCode IsNot Nothing AndAlso partialOrderCode.Length > 0) AndAlso (orderTypeId IsNot Nothing AndAlso orderTypeId.Length > 0) Then
            '至少有Icd_Code, Disease_Type_Id
            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("SELECT top 1 Order_Code ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where ")
            '主條件
            cmdStr.AppendLine("Dc <> @DcY ")
            cmdStr.AppendLine("and Effect_Date <= @Today_Date ")
            cmdStr.AppendLine("and Order_Type_Id = @Order_Type_Id ")
            If isPre Then
                cmdStr.AppendLine("and Order_Code < @Order_Code ")
            Else
                cmdStr.AppendLine("and Order_Code > @Order_Code ")
            End If

            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            If isPre Then
                cmdStr.AppendLine("order by Order_Code desc ")
            Else
                cmdStr.AppendLine("order by Order_Code asc ")
            End If


            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@DcY", "Y")
                            sqlCmd.Parameters.AddWithValue("@Today_Date", Now)
                            sqlCmd.Parameters.AddWithValue("@Order_Type_Id", orderTypeId)
                            sqlCmd.Parameters.AddWithValue("@Order_Code", partialOrderCode)

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

    Public Function queryPreOrNextRecordOrder2(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal EffectDate As String, ByVal isPre As Boolean) As DataTable

        If (partialOrderCode IsNot Nothing AndAlso partialOrderCode.Length > 0) AndAlso (orderTypeId IsNot Nothing AndAlso orderTypeId.Length > 0) Then
            '至少有Icd_Code, Disease_Type_Id
            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("SELECT top 2 Order_Code,Effect_Date ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where 1=1 ")
            '主條件
            If isPre Then
                If EffectDate <> "" Then
                    cmdStr.AppendLine(" and Effect_Date <= @Effect_Date ")
                    cmdStr.AppendLine("and Order_Code <= @Order_Code ")
                Else
                    cmdStr.AppendLine("and Order_Code < @Order_Code ")
                End If
            Else
                If EffectDate <> "" Then
                    cmdStr.AppendLine(" and Effect_Date >= @Effect_Date ")
                    cmdStr.AppendLine("and Order_Code >= @Order_Code ")
                Else
                    cmdStr.AppendLine("and Order_Code > @Order_Code ")
                End If

            End If

            cmdStr.AppendLine("and Order_Type_Id = @Order_Type_Id ")


            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            If isPre Then
                cmdStr.AppendLine("order by Order_Code desc,Effect_Date desc ")
            Else
                cmdStr.AppendLine("order by Order_Code asc,Effect_Date asc ")
            End If


            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@Effect_Date", EffectDate)
                            sqlCmd.Parameters.AddWithValue("@Order_Type_Id", orderTypeId)
                            sqlCmd.Parameters.AddWithValue("@Order_Code", partialOrderCode)

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

    Public Function queryPreOrNextRecordOrder3(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal EffectDate As String, ByVal isPre As Boolean) As DataTable

        If (partialOrderCode IsNot Nothing AndAlso partialOrderCode.Length > 0) AndAlso (orderTypeId IsNot Nothing AndAlso orderTypeId.Length > 0) Then
            '至少有Icd_Code, Disease_Type_Id
            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("SELECT top 2 Order_Code,Effect_Date ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where 1=1 ")
            '主條件

            cmdStr.AppendLine("and Order_Code = @Order_Code ")
            cmdStr.AppendLine("and Order_Type_Id = @Order_Type_Id ")


            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("order by Order_Code desc,Effect_Date desc ")


            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@Effect_Date", EffectDate)
                            sqlCmd.Parameters.AddWithValue("@Order_Type_Id", orderTypeId)
                            sqlCmd.Parameters.AddWithValue("@Order_Code", partialOrderCode)

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


#Region "成大碼轉健保碼"


    Public Function queryInsuCodeByOrderCode(ByVal OrderCodeDS As DataSet, Optional ByVal BasicDate As String = "") As DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim OrderCodeList As String = ""

            For i As Integer = 0 To OrderCodeDS.Tables(0).Rows.Count - 1
                If i < OrderCodeDS.Tables(0).Rows.Count - 1 Then

                    OrderCodeList += "'" & OrderCodeDS.Tables(0).Rows(i).Item("Order_Code").ToString.Trim & "' , "
                Else
                    OrderCodeList += "'" & OrderCodeDS.Tables(0).Rows(i).Item("Order_Code").ToString.Trim & "' "

                End If


            Next

            If BasicDate = "" Then
                'command.CommandText = " Select A.Order_Code ,B.Insu_Code , A.Order_Name ,A.Order_En_Name From PUB_Order A ,PUB_Order_Price B " & _
                '                " Where  A.Order_Code =B.Order_Code And B.Main_Identity_Id = '2' And B.Insu_Code <> '' And  '" & Now().ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= B.End_Date    And B.Insu_Code<>'ZZZZZZ' And  " & _
                '                " A.Order_Code in (" & OrderCodeList & ") And A.Dc='N'"


                command.CommandText = " Select  PP.Order_Code,  "
                command.CommandText += " Case when DD.Insu_Code is null then PP.Insu_Code "  '--因為在 PUB_Insu_Code 中沒有 Order_Code為'ZZZZZZ' 的資料對應, 所以會為 Null
                command.CommandText += " else DD.Insu_Code "
                command.CommandText += " End as detail_Insu_Code "
                command.CommandText += " From    dbo.PUB_Order_Price PP "
                command.CommandText += " left outer join dbo.PUB_Insu_Code as DD on "
                command.CommandText += " ( PP.Order_Code = DD.Order_Code ) "
                command.CommandText += " where   PP.Order_Code in (" & OrderCodeList & ") and "
                command.CommandText += "'" & Now().ToString("yyyy/M/d") & "' >= PP.Effect_Date And "
                command.CommandText += "'" & Now().ToString("yyyy/M/d") & "' <= PP.End_Date And "
                command.CommandText += " PP.Main_Identity_Id ='2' "



            Else
                'command.CommandText = " Select A.Order_Code ,B.Insu_Code , A.Order_Name ,A.Order_En_Name From PUB_Order A ,PUB_Order_Price B " & _
                '                " Where  A.Order_Code =B.Order_Code And B.Main_Identity_Id = '2' And B.Insu_Code <> '' And  '" & BasicDate & "' >= B.Effect_Date And '" & BasicDate & "'<= B.End_Date    And B.Insu_Code<>'ZZZZZZ' And  " & _
                '                " A.Order_Code in (" & OrderCodeList & ") And A.Dc='N'"


                command.CommandText = " Select  PP.Order_Code,  "
                command.CommandText += " Case when DD.Insu_Code is null then PP.Insu_Code "  '--因為在 PUB_Insu_Code 中沒有 Order_Code為'ZZZZZZ' 的資料對應, 所以會為 Null
                command.CommandText += " else DD.Insu_Code "
                command.CommandText += " End as detail_Insu_Code "
                command.CommandText += " From    dbo.PUB_Order_Price PP "
                command.CommandText += " left outer join dbo.PUB_Insu_Code as DD on "
                command.CommandText += " ( PP.Order_Code = DD.Order_Code ) "
                command.CommandText += " where   PP.Order_Code in (" & OrderCodeList & ") and "
                command.CommandText += "'" & BasicDate & "' >= PP.Effect_Date And "
                command.CommandText += "'" & BasicDate & "' <= PP.End_Date And "
                command.CommandText += " PP.Main_Identity_Id ='2' "




            End If



            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using

            Return ds
        Catch ex As Exception
            Return Nothing

        End Try


    End Function
#End Region

#Region "2010-05-06 Add By Alan - 醫令維護作業"

    ''' <summary>
    '''更新結束日期與停用註記
    ''' </summary>
    ''' <remarks></remarks>
    Public Function updatePUBOrderEndDateAndDc(ByVal OrderCode As String, ByVal EffectDate As String, ByVal EndDate As String, ByVal Dc As String, _
                                               ByVal ModifyUser As String) As Integer

        Dim conn As IDbConnection = getConnection()

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName1 & " set " & _
            " End_Date=@End_Date , Dc=@Dc , Modified_User=@Modified_User, Modified_Time=@Modified_Time " & _
            " where  Effect_Date=@Effect_Date and Order_Code=@Order_Code "

            conn.Open()


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Order_Code", OrderCode)
                command.Parameters.AddWithValue("@Effect_Date", EffectDate)
                command.Parameters.AddWithValue("@End_Date", EndDate)
                command.Parameters.AddWithValue("@Dc", Dc)
                command.Parameters.AddWithValue("@Modified_User", ModifyUser)
                command.Parameters.AddWithValue("@Modified_Time", currentTime)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            '==================
            '加入backup
            Try
                Using conn_backup As SqlConnection = getConnection()
                    conn_backup.Open()
                    Using command As SqlCommand = conn_backup.CreateCommand()
                        sqlString = "Select * From " & tableName1 & _
                                   " where  Effect_Date=@Effect_Date and Order_Code=@Order_Code "

                        command.CommandText = sqlString

                        command.Parameters.AddWithValue("@Order_Code", OrderCode)
                        command.Parameters.AddWithValue("@Effect_Date", EffectDate)
                       
                        Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                            Using OrderDS As DataSet = New DataSet("OrderDS")
                                adapter.Fill(OrderDS, "OrderDS")

                                For Each row As DataRow In OrderDS.Tables(0).Rows
                                    updateBackup(row, conn_backup)
                                Next

                            End Using
                        End Using
                    End Using

                    conn_backup.Close()

                End Using
            Catch ex As Exception
                Syscom.Server.CMM.LOGDelegate.getInstance.dbDebugMsg("備份錯誤-" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "-" & ex.ToString)
            End Try

            '==================

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
    End Function

    ''' <summary>
    '''依DC為條件查詢醫令
    ''' </summary> 
    ''' <remarks></remarks>
    Public Function queryPUBOrderByDc(ByVal OrderCode As String, ByVal Dc As String) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            command.CommandText = "  Select *  From PUB_Order "
            command.CommandText &= " Where  Order_Code='" & OrderCode & "' And Dc='" & Dc & "' "
            command.CommandText &= " Order By Effect_Date Desc"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    '''刪除醫令資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function DeletePUBOrderByEffectDate(ByVal EffectDate As String, ByVal OrderCode As String) As Integer

        Dim conn As IDbConnection = getConnection()

        Try
            Dim currentTime = Now
            '================================
            '加入backup
            Try
                Using conn_backup As SqlConnection = getConnection()
                    conn_backup.Open()
                    Using command As SqlCommand = conn_backup.CreateCommand()

                        Dim sqlSelectString As String = " Select * From " & tableName1 & " " & _
                                              " Where  Effect_Date>=@Effect_Date and Order_Code=@Order_Code "

                        command.CommandText = sqlSelectString

                        command.Parameters.AddWithValue("@Order_Code", OrderCode)
                        command.Parameters.AddWithValue("@Effect_Date", EffectDate)

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                            Using OrderDS As DataSet = New DataSet("OrderDS")
                                adapter.Fill(OrderDS, "OrderDS")

                                For Each row As DataRow In OrderDS.Tables(0).Rows
                                    deleteBackup(row, conn_backup)
                                Next

                            End Using
                        End Using
                    End Using
                    conn_backup.Close()
                End Using
            Catch ex As Exception
                Syscom.Server.CMM.LOGDelegate.getInstance.dbDebugMsg("備份錯誤-" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "-" & ex.ToString)
            End Try

            '================================
            Dim count As Integer = 0
            Dim sqlString As String = "Delete From " & tableName1 & " " & _
                                      "Where  Effect_Date>=@Effect_Date and Order_Code=@Order_Code "

            conn.Open()

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Order_Code", OrderCode)
                command.Parameters.AddWithValue("@Effect_Date", EffectDate)
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
    End Function

#Region "     查詢醫令資料By Order_Code "

    ''' <summary>
    '''查詢醫令資料For Dc
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryPubOrderByOrderCode(ByRef pk_Order_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Effect_Date , Order_Code , Order_En_Name , Order_Name , Order_En_Short_Name ,  ")
            content.AppendLine(" Order_Short_Name , Order_Type_Id , Account_Id , Is_Cure , Cure_Type_Id ,  ")
            content.AppendLine(" Treatment_Type_Id , Charge_Unit , Nhi_Transrate , Nhi_Unit , Is_Order_Check ,  ")
            content.AppendLine(" Fix_Order_Id , Is_Exclude_Drug , Order_Note , Order_Memo , Is_Agree_Sheet ,  ")
            content.AppendLine(" Is_Nhi_Sheet , Is_Prior_Review , Is_IC_Card_Order , Is_Order_Price_Special , Dc_Reason ,  ")
            content.AppendLine(" Dc , End_Date , Create_User , Create_Time , Modified_User ,  ")
            content.AppendLine(" Modified_Time , Old_Order_Code , Material_Used_Cnt , Include_Order_Mark , Insu_Cover_Opd ,  ")
            content.AppendLine(" Insu_Cover_Emg , Insu_Cover_Ipd , Is_Icd_Check , Is_Emg_Nursing_Charge , Majorcare_Code ,  ")
            content.AppendLine(" Cost_Price , Is_Alternative                from " & tableName)
            content.AppendLine("   where  Order_Code=@Order_Code and DC='N' ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
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

#Region "     查詢醫令資料For Dc "

    ''' <summary>
    '''查詢醫令資料For Dc
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPKForDc(ByRef pk_Effect_Date As System.DateTime, ByRef pk_Order_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Effect_Date , Order_Code , Order_En_Name , Order_Name , Order_En_Short_Name ,  ")
            content.AppendLine(" Order_Short_Name , Order_Type_Id , Account_Id , Is_Cure , Cure_Type_Id ,  ")
            content.AppendLine(" Treatment_Type_Id , Charge_Unit , Nhi_Transrate , Nhi_Unit , Is_Order_Check ,  ")
            content.AppendLine(" Fix_Order_Id , Is_Exclude_Drug , Order_Note , Order_Memo , Is_Agree_Sheet ,  ")
            content.AppendLine(" Is_Nhi_Sheet , Is_Prior_Review , Is_IC_Card_Order , Is_Order_Price_Special , Dc_Reason ,  ")
            content.AppendLine(" Dc , End_Date , Create_User , Create_Time , Modified_User ,  ")
            content.AppendLine(" Modified_Time , Old_Order_Code , Material_Used_Cnt , Include_Order_Mark , Insu_Cover_Opd ,  ")
            content.AppendLine(" Insu_Cover_Emg , Insu_Cover_Ipd , Is_Icd_Check , Is_Emg_Nursing_Charge , Majorcare_Code ,  ")
            content.AppendLine(" Cost_Price , Is_Alternative                from " & tableName)
            content.AppendLine("   where Effect_Date=@Effect_Date and Order_Code=@Order_Code   and DC='Y'         ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
            command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
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

#Region "     刪除醫令資料 "
    ''' <summary>
    '''刪除醫令資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function DeletePUBOrderByEffectDateAndDc(ByVal pk_Effect_Date As String, ByVal pk_Order_Code As String, ByVal Dc As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Effect_Date=@Effect_Date and Order_Code=@Order_Code and DC='Y'  "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            deleteBackupForDC(pk_Effect_Date, pk_Order_Code, conn) '備份機制
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB914", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 備份刪除資料
    ''' </summary>       
    Protected Sub deleteBackupForDC(ByVal pk_Effect_Date As System.DateTime, ByVal pk_Order_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing)

        Dim bkDS As System.Data.DataSet = queryByPKForDc(pk_Effect_Date, pk_Order_Code, conn)
        If bkDS IsNot Nothing _
        AndAlso bkDS.Tables.Count > 0 _
        AndAlso bkDS.Tables(0) IsNot Nothing _
        AndAlso bkDS.Tables(0).Rows.Count > 0 _
        AndAlso bkDS.Tables(0).Rows(0) IsNot Nothing _
        Then
            deleteBackup(bkDS.Tables(0).Rows(0), conn)
        Else
            'Throw New Exception("No Data To Delete")
        End If
    End Sub

#End Region

    ''' <summary>
    ''' 查詢廠牌
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.OPH_Pharmacy_Base
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/10
    ''' </修改註記>
    Public Function queryOrderBrand(ByVal OrderCode As String) As DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select B.Code_Name " & _
                                  "From OPH_Pharmacy_Base A,OPH_Code B " & _
                                  "Where A.Order_Code ='" & OrderCode & "' And " & _
                                  "      B.Type_Id ='3' AND " & _
                                  "      B.Code_Id =A.Supplier_Id "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try


    End Function

#End Region

#Region "udpate Pub_order is_order_check=true"
    ''' <summary>
    '''新增
    ''' </summary>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function updatepub_order(ByVal sql As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = sql
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New Exception
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

    ''' <summary>
    '''刪除醫令所有記錄資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function DeletePUBOrderByOrderCode(ByVal OrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            '================================
            '加入backup
            Try
                Using conn_backup As SqlConnection = getConnection()
                    conn_backup.Open()
                    Using command As SqlCommand = conn_backup.CreateCommand()

                        Dim sqlSelectString As String = " Select * From " & tableName1 & " " & _
                                   "Where   Order_Code=@Order_Code "

                        command.CommandText = sqlSelectString

                        command.Parameters.AddWithValue("@Order_Code", OrderCode)


                        Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                            Using OrderDS As DataSet = New DataSet("OrderDS")
                                adapter.Fill(OrderDS, "OrderDS")

                                For Each row As DataRow In OrderDS.Tables(0).Rows
                                    deleteBackup(row, conn_backup)
                                Next

                            End Using
                        End Using
                    End Using
                    conn_backup.Close()
                End Using
            Catch ex As Exception
                Syscom.Server.CMM.LOGDelegate.getInstance.dbDebugMsg("備份錯誤-" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "-" & ex.ToString)
            End Try

            '================================

            Dim sqlString As String = "Delete From " & tableName1 & " " & _
                                      "Where  Order_Code=@Order_Code "

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Order_Code", OrderCode)

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

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

    'add by 唐子晴 2014.02.06 --------------------------------------------------------
    ''' <summary>
    '''刪除醫令所有記錄資料 Log
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deletePUBOrderLog(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal OrderMode As String, ByVal ExecutionUser As String) As Integer

        Dim conn As SqlConnection
        conn = CType(getPUBDBConnection(), SqlConnection)

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String

            sqlString = "Insert into PUB_Order_Log ("
            sqlString &= "Execution_Date, Order_Code, Order_Name, Order_Type_Id, Order_Mode, Execution_User "
            sqlString &= ") values ("
            sqlString &= "@Execution_Date, @Order_Code, @Order_Name, @Order_Type_Id, @Order_Mode, @Execution_User )"
            conn.Open()


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Execution_Date", currentTime)
                command.Parameters.AddWithValue("@Order_Code", OrderCode)
                command.Parameters.AddWithValue("@Order_Name", OrderName)
                command.Parameters.AddWithValue("@Order_Type_Id", OrderTypeId)
                command.Parameters.AddWithValue("@Order_Mode", OrderMode)
                command.Parameters.AddWithValue("@Execution_User", ExecutionUser)

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
    End Function
    '-----------------------------------------------------------------------------

#Region "2010/9/27 Add By Barry 查詢收費標準檔資料"

    ''' <summary>
    ''' 查詢收費標準檔資料
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <param name="EffectDate"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function queryOrderCodeData(ByVal OrderCode As String, ByVal EffectDate As Date) As DataSet
        Dim cmdStrOrder As New StringBuilder
        Dim orderCodeList() As String = New String() {}
        Dim ds As New System.Data.DataSet("SendPack")
        Dim EffectDate2 = EffectDate.AddDays(1)
        'Dim _command As New SqlCommand(cmdStrOrder.ToString
        Dim cmd As SqlCommand
        '先找出需要回傳的orderCode, 再用此orderCode去找出其他資料
        Dim queryDs As DataSet
        If OrderCode IsNot Nothing And OrderCode <> "" Then
            orderCodeList = New String() {OrderCode}
        ElseIf EffectDate <> Nothing Then
            cmdStrOrder.AppendLine("select distinct A.Order_Code")
            cmdStrOrder.AppendLine(" from PUB_Order A, PUB_Order_Price B")
            cmdStrOrder.AppendLine(" where A.Effect_Date=B.Effect_Date and A.Order_Code=B.Order_Code and")
            cmdStrOrder.AppendLine(" ((A.Modified_Time >=@EffectDate and A.Modified_Time <=@EffectDate2)")
            cmdStrOrder.AppendLine(" or")
            cmdStrOrder.AppendLine(" (B.Modified_Time >=@EffectDate and B.Modified_Time <=@EffectDate2))")
            cmd = New SqlCommand(cmdStrOrder.ToString)
            cmd.Parameters.AddWithValue("@EffectDate", EffectDate)
            cmd.Parameters.AddWithValue("@EffectDate2", EffectDate2)
            queryDs = query(cmd)
            If hasData(queryDs) Then '有資料就set到orderCodeList
                ReDim orderCodeList(queryDs.Tables(0).Rows.Count - 1)
                For i As Integer = 0 To orderCodeList.Length - 1
                    orderCodeList(i) = queryDs.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                Next
            End If
        End If

        'Dim orderIdx As Integer = 0
        'Dim priceIdx As Integer
        'Dim insuIdx As Integer
        Dim codeList As String = ""
        For i As Integer = 0 To orderCodeList.Count - 1
            If i = 0 Then
                codeList = "'" & orderCodeList(i) & "'"
            Else
                codeList += ", '" & orderCodeList(i) & "'"
            End If
        Next

        'For Each code As String In orderCodeList
        'For i As Integer = 0 To orderCodeList.Count - 1
        'orderIdx = orderIdx + 1
        'priceIdx = 1
        'insuIdx = 1

        If codeList.Length <> 0 Then
            '拼PUB_Order
            cmdStrOrder.Length = 0 '清除內容
            cmdStrOrder.AppendLine(" select Effect_Date, Order_Code, Order_En_Name, Order_Name, Order_En_Short_Name, Order_Short_Name, Order_Type_Id, Account_Id, Cure_Type_Id, Charge_Unit, Nhi_Transrate, Nhi_Unit, Order_Note, Order_Memo, Is_Prior_Review, Is_IC_Card_Order, Dc, End_Date, Create_User, Create_Time, Modified_User, Modified_Time, Insu_Cover_Opd, Insu_Cover_Emg, Insu_Cover_Ipd, Is_Inventory")
            cmdStrOrder.AppendLine(" from PUB_Order")
            cmdStrOrder.AppendLine(" where Dc = 'N' and Order_Code in (" + codeList + ")")
            cmd = New SqlCommand(cmdStrOrder.ToString)
            'cmd.Parameters.AddWithValue("@codeList", codeList)
            queryDs = query(cmd, "PUB_Order_Data")

            If hasData(queryDs) Then '有資料就set到ds
                '改格式
                'queryDs.Tables(0).Rows(0).Item("Charge_Unit") = queryDs.Tables(0).Rows(0).Item("Charge_Unit").ToString.Trim
                'queryDs.Tables(0).Rows(0).Item("Nhi_Unit") = queryDs.Tables(0).Rows(0).Item("Nhi_Unit").ToString.Trim
                'queryDs.Tables(0).Rows(0).Item("Effect_Date") = CDate(queryDs.Tables(0).Rows(0).Item("Effect_Date")).ToString("yyyy-MM-dd")
                'queryDs.Tables(0).Rows(0).Item("Create_Time") = CDate(queryDs.Tables(0).Rows(0).Item("Create_Time")).ToString("yyyy-MM-dd")
                'queryDs.Tables(0).Rows(0).Item("Modified_Time") = CDate(queryDs.Tables(0).Rows(0).Item("Modified_Time")).ToString("yyyy-MM-dd")

                'ds.Tables.Add(queryorderTable.Copy)

                Dim orderTable As DataTable = ds.Tables.Add("PUB_Order_Data")
                orderTable.Columns.Add("Effect_Date")
                orderTable.Columns.Add("Order_Code")
                orderTable.Columns.Add("Order_En_Name")
                orderTable.Columns.Add("Order_Name")
                orderTable.Columns.Add("Order_En_Short_Name")
                orderTable.Columns.Add("Order_Short_Name")
                orderTable.Columns.Add("Order_Type_Id")
                orderTable.Columns.Add("Account_Id")
                orderTable.Columns.Add("Cure_Type_Id")
                orderTable.Columns.Add("Charge_Unit")
                orderTable.Columns.Add("Nhi_Transrate")
                orderTable.Columns.Add("Nhi_Unit")
                orderTable.Columns.Add("Order_Note")
                orderTable.Columns.Add("Order_Memo")
                orderTable.Columns.Add("Is_Prior_Review")
                orderTable.Columns.Add("Is_IC_Card_Order")
                orderTable.Columns.Add("Dc")
                orderTable.Columns.Add("End_Date")
                orderTable.Columns.Add("Create_User")
                orderTable.Columns.Add("Create_Time")
                orderTable.Columns.Add("Modified_User")
                orderTable.Columns.Add("Modified_Time")
                orderTable.Columns.Add("Insu_Cover_Opd")
                orderTable.Columns.Add("Insu_Cover_Emg")
                orderTable.Columns.Add("Insu_Cover_Ipd")
                orderTable.Columns.Add("Is_Inventory")

                Dim orderRow As DataRow
                For i As Integer = 0 To queryDs.Tables(0).Rows.Count - 1
                    orderRow = orderTable.Rows.Add()
                    orderRow.Item("Effect_Date") = CDate(queryDs.Tables(0).Rows(i).Item("Effect_Date")).ToString("yyyy-MM-dd")
                    orderRow.Item("Order_Code") = queryDs.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                    orderRow.Item("Order_En_Name") = queryDs.Tables(0).Rows(i).Item("Order_En_Name").ToString.Trim
                    orderRow.Item("Order_Name") = queryDs.Tables(0).Rows(i).Item("Order_Name").ToString.Trim
                    orderRow.Item("Order_En_Short_Name") = queryDs.Tables(0).Rows(i).Item("Order_En_Short_Name").ToString.Trim
                    orderRow.Item("Order_Short_Name") = queryDs.Tables(0).Rows(i).Item("Order_Short_Name").ToString.Trim
                    orderRow.Item("Order_Type_Id") = queryDs.Tables(0).Rows(i).Item("Order_Type_Id").ToString.Trim
                    orderRow.Item("Account_Id") = queryDs.Tables(0).Rows(i).Item("Account_Id").ToString.Trim
                    orderRow.Item("Cure_Type_Id") = queryDs.Tables(0).Rows(i).Item("Cure_Type_Id").ToString.Trim
                    orderRow.Item("Charge_Unit") = queryDs.Tables(0).Rows(i).Item("Charge_Unit").ToString.Trim
                    orderRow.Item("Nhi_Transrate") = queryDs.Tables(0).Rows(i).Item("Nhi_Transrate").ToString.Trim
                    orderRow.Item("Nhi_Unit") = queryDs.Tables(0).Rows(i).Item("Nhi_Unit").ToString.Trim
                    orderRow.Item("Order_Note") = queryDs.Tables(0).Rows(i).Item("Order_Note").ToString.Trim
                    orderRow.Item("Order_Memo") = queryDs.Tables(0).Rows(i).Item("Order_Memo").ToString.Trim
                    orderRow.Item("Is_Prior_Review") = queryDs.Tables(0).Rows(i).Item("Is_Prior_Review").ToString.Trim
                    orderRow.Item("Is_IC_Card_Order") = queryDs.Tables(0).Rows(i).Item("Is_IC_Card_Order").ToString.Trim
                    orderRow.Item("Dc") = queryDs.Tables(0).Rows(i).Item("Dc").ToString.Trim
                    orderRow.Item("End_Date") = CDate(queryDs.Tables(0).Rows(i).Item("End_Date")).ToString("yyyy-MM-dd")
                    orderRow.Item("Create_User") = queryDs.Tables(0).Rows(i).Item("Create_User").ToString.Trim
                    orderRow.Item("Create_Time") = CDate(queryDs.Tables(0).Rows(i).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm")
                    orderRow.Item("Modified_User") = queryDs.Tables(0).Rows(i).Item("Modified_User").ToString.Trim
                    orderRow.Item("Modified_Time") = CDate(queryDs.Tables(0).Rows(i).Item("Modified_Time")).ToString("yyyy-MM-dd HH:mm")
                    orderRow.Item("Insu_Cover_Opd") = queryDs.Tables(0).Rows(i).Item("Insu_Cover_Opd").ToString.Trim
                    orderRow.Item("Insu_Cover_Emg") = queryDs.Tables(0).Rows(i).Item("Insu_Cover_Emg").ToString.Trim
                    orderRow.Item("Insu_Cover_Ipd") = queryDs.Tables(0).Rows(i).Item("Insu_Cover_Ipd").ToString.Trim
                    orderRow.Item("Is_Inventory") = queryDs.Tables(0).Rows(i).Item("Is_Inventory").ToString.Trim
                Next
            End If

            '拼PUB_Order_Price
            cmdStrOrder.Length = 0 '清除內容
            cmdStrOrder.AppendLine(" select Effect_Date, Order_Code, Main_Identity_Id, Price, Add_Price, Material_Ratio, Material_Account_Id, Insu_Code, Insu_Account_Id, Insu_Order_Type_Id, Insu_Group_Code, Insu_Apply_Price, Order_Ratio")
            cmdStrOrder.AppendLine(" from PUB_Order_Price")
            cmdStrOrder.AppendLine(" where Dc = 'N' and Order_Code in (" + codeList + ")")
            cmd = New SqlCommand(cmdStrOrder.ToString)
            'cmd.Parameters.AddWithValue("@codeList", codeList)
            queryDs = query(cmd, "PUB_Order_Price_Data")

            If hasData(queryDs) Then '有資料就set到ds
                'queryDs.Tables(0).Columns("Effect_Date").DataType = Type.GetType("System.String")
                '改格式
                'For Each row As DataRow In queryDs.Tables(0).Rows
                '    row.Item("Effect_Date") = CDate(row.Item("Effect_Date")).ToString("yyyy-MM-dd")
                'Next
                'ds.Tables.Add(queryDs.Tables(0).Copy)

                'ds.Tables.Add("PUB_Order_Price_Data")
                Dim priceTable As DataTable = ds.Tables.Add("PUB_Order_Price_Data")
                priceTable.Columns.Add("Effect_Date")
                priceTable.Columns.Add("Order_Code")
                priceTable.Columns.Add("Main_Identity_Id")
                priceTable.Columns.Add("Price")
                priceTable.Columns.Add("Add_Price")
                priceTable.Columns.Add("Material_Ratio")
                priceTable.Columns.Add("Material_Account_Id")
                priceTable.Columns.Add("Insu_Code")
                priceTable.Columns.Add("Insu_Account_Id")
                priceTable.Columns.Add("Insu_Order_Type_Id")
                priceTable.Columns.Add("Insu_Group_Code")
                priceTable.Columns.Add("Insu_Apply_Price")
                priceTable.Columns.Add("Order_Ratio")

                For i As Integer = 0 To queryDs.Tables(0).Rows.Count - 1
                    priceTable.Rows.Add()
                    priceTable.Rows(i).Item("Effect_Date") = CDate(queryDs.Tables(0).Rows(i).Item("Effect_Date")).ToString("yyyy-MM-dd")
                    priceTable.Rows(i).Item("Order_Code") = queryDs.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                    priceTable.Rows(i).Item("Main_Identity_Id") = queryDs.Tables(0).Rows(i).Item("Main_Identity_Id").ToString.Trim
                    priceTable.Rows(i).Item("Price") = queryDs.Tables(0).Rows(i).Item("Price").ToString.Trim
                    priceTable.Rows(i).Item("Add_Price") = queryDs.Tables(0).Rows(i).Item("Add_Price").ToString.Trim
                    priceTable.Rows(i).Item("Material_Ratio") = queryDs.Tables(0).Rows(i).Item("Material_Ratio").ToString.Trim
                    priceTable.Rows(i).Item("Material_Account_Id") = queryDs.Tables(0).Rows(i).Item("Material_Account_Id").ToString.Trim
                    priceTable.Rows(i).Item("Insu_Code") = queryDs.Tables(0).Rows(i).Item("Insu_Code").ToString.Trim
                    priceTable.Rows(i).Item("Insu_Account_Id") = queryDs.Tables(0).Rows(i).Item("Insu_Account_Id").ToString.Trim
                    priceTable.Rows(i).Item("Insu_Group_Code") = queryDs.Tables(0).Rows(i).Item("Insu_Group_Code").ToString.Trim
                    priceTable.Rows(i).Item("Insu_Apply_Price") = queryDs.Tables(0).Rows(i).Item("Insu_Apply_Price").ToString.Trim
                    priceTable.Rows(i).Item("Order_Ratio") = queryDs.Tables(0).Rows(i).Item("Order_Ratio").ToString.Trim
                Next

            End If

            '拼PUB_Insu_Code
            cmdStrOrder.Length = 0 '清除內容
            cmdStrOrder.AppendLine(" select A.Order_Code, B.Insu_Code")
            cmdStrOrder.AppendLine(" from PUB_Order_Price A, PUB_Insu_Code B")
            cmdStrOrder.AppendLine(" where A.Main_Identity_Id='2' and A.Dc='N' and B.Dc='N' and A.Order_Code in (" + codeList + ") and A.Order_Code=B.Order_Code")
            cmd = New SqlCommand(cmdStrOrder.ToString)
            'cmd.Parameters.AddWithValue("@codeList", codeList)
            queryDs = query(cmd, "PUB_Insu_Code_Data")
            If hasData(queryDs) Then '有資料就set到ds
                'ds.Tables.Add(queryDs.Tables(0).Copy)

                'ds.Tables.Add("PUB_Insu_Code_Data")
                Dim insuTable As DataTable = ds.Tables.Add("PUB_Insu_Code_Data")
                insuTable.Columns.Add("Order_Code")
                insuTable.Columns.Add("Insu_Code")
                For i As Integer = 0 To queryDs.Tables(0).Rows.Count - 1
                    insuTable.Rows.Add()
                    insuTable.Rows(i).Item("Order_Code") = queryDs.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                    insuTable.Rows(i).Item("Insu_Code") = queryDs.Tables(0).Rows(i).Item("Insu_Code").ToString.Trim
                Next

            End If

        End If
        'Next

        Return ds
    End Function

    Private Function query(ByRef cmd As SqlCommand) As DataSet
        Return query(cmd, tableName)
    End Function
    Private Function query(ByRef cmd As SqlCommand, ByVal tableName As String) As DataSet
        Dim ds As New DataSet
        Try
            Using _sqlConnection As SqlConnection = getConnection()
                cmd.Connection = _sqlConnection
                Dim _dataAdapter1 As SqlDataAdapter = New SqlDataAdapter(cmd)
                _dataAdapter1.Fill(ds, tableName)
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function hasData(ByRef ds As DataSet) As Boolean
        Return ds IsNot Nothing AndAlso ds.Tables IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0

    End Function


#End Region


#Region "2010/10/02"
    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function update_Is_Icd_Check(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Is_Icd_Check=@Is_Icd_Check " & _
            " where   Order_Code=@Order_Code            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Is_Icd_Check", row.Item("Is_Icd_Check"))
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
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region
#Region "2010/10/13 Add By Jeff 匯出醫療支付公用主檔"
    ''' <summary>
    '''匯出醫療支付公用主檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Function QueryPUBExportByOrderData(ByVal OrderCode As String, ByVal OrderType As String, ByVal OrderTime As String) As DataSet

        Try
            Dim ds As DataSet
            'modify by 唐子晴 2014.01.06-------------------------------------------------------------------------------------------            
            Dim sqlConn As SqlConnection
            Dim command As SqlCommand
            Dim sqlString As String = ""

            If OrderType = "G" Then
                Dim type As String() = OrderTime.Split(New String() {"|"}, StringSplitOptions.RemoveEmptyEntries)

                sqlConn = CType(getPUBDBConnection(), SqlConnection)
                command = sqlConn.CreateCommand()
                Select Case type(0)
                    Case "All"
                        'modify by 唐子晴 2014.01.07---------------------------------------------
                        ''sqlString = "SELECT D.成大料號,D.品名,F.Insu_Code as 保險碼,F.Insu_Group_Code as 健保編碼, " & _
                        ''            "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='902' and code_id=D.Manage_Id) as 給付註記, " & _
                        ''            "D.規格型號,D.單位,D.單價調整紀錄,D.最後採購單價,F.Insu_Apply_Price as 健保核定單價,F.Price as 健保價, " & _
                        ''            "E.Price as 自費價, F.Add_Price as 自付差額, D.核給使用次數,D.健保內含項註記,D.訂價原則,D.批價符號, " & _
                        ''            "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='41' and code_id=D.Account_Id) as 收據項目, " & _
                        ''            "D.事前審查, " & _
                        ''            "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='500' and code_id=D.Apply_Status_Id) as 申請狀況, " & _
                        ''            "D.虛擬健保碼, D.衛證號, D.庫房別, D.廠牌, D.廠商, D.醫令備註, D.生效日, D.設量者, D.最近進貨日, D.修改者, D.修改時間, D.使用原因, " & _
                        ''            "D.產品特性 ,D.注意事項,D.副作用,D.療效比較 " & _
                        ''            "FROM " & _
                        ''            "(select  A.Dc, A.Order_Code as 成大料號,A.Order_Name as 品名,A.Material_Used_Cnt as 核給使用次數, " & _
                        ''            "A.Include_Order_Mark as 健保內含項註記,A.Brand as 廠牌 , '' as 廠商,'' as 設量者,'' as 最近進貨日, " & _
                        ''            "A.Insu_Cover_Opd+A.Insu_Cover_Emg+A.Insu_Cover_Ipd as 批價符號, " & _
                        ''            "A.Is_Prior_Review as 事前審查, A.Modified_User as 修改者, " & _
                        ''            "CONVERT(varchar, A.Modified_Time,120) as 修改時間, A.Account_Id,A.Manage_Id , " & _
                        ''            "B.Spec as 規格型號 ,B.Purchase_Price_Unit as 單位,B.Purchase_Price as 最後採購單價, " & _
                        ''            "B.Stock_Unit as 庫房別 , A.Effect_Date,CONVERT(varchar(12), A.End_Date,111) as End_Date , " & _
                        ''            "B.Price_Adjustment as 單價調整紀錄, A.Order_Note as 醫令備註, " & _
                        ''            "CONVERT(varchar(12), A.Effect_Date,111) as 生效日 , " & _
                        ''            "C.Equipment_License_No as 衛證號, C.Use_Reason as 使用原因,C.Self_Insu_Code as 虛擬健保碼,C.Apply_Status_Id, " & _
                        ''            "C.Product_Features as 產品特性,C.Precautions as 注意事項,C.Side_Effect as 副作用,C.Efficacy_Comparison as 療效比較, " & _
                        ''            "訂價原則 = CASE A.Order_Flag  " & _
                        ''            "WHEN 'A' THEN 'A.科部上簽自訂' " & _
                        ''            "WHEN 'B' THEN 'B.科部建議價格' " & _
                        ''            "WHEN 'C' THEN 'C.衛生局加成' " & _
                        ''            "Else  A.Order_Flag " & _
                        ''            "End " & _
                        ''            "from PUB_Order as A join PUB_Mis_Purchase_Data as B  " & _
                        ''            "on A.Order_Code=B.Purchase_Code  " & _
                        ''            "join PUB_Material_Selfpay_Apply as C " & _
                        ''            "on A.Order_Code = C.Order_Code " & _
                        ''            "where A.Order_Type_Id='G' and A.Dc='N' " & _
                        ''            ") AS D LEFT JOIN PUB_Order_Price AS E  " & _
                        ''            "ON D.成大料號=E.Order_Code " & _
                        ''            "LEFT JOIN PUB_Order_Price AS F " & _
                        ''            "ON D.成大料號=F.Order_Code  " & _
                        ''            "where E.Main_Identity_Id='1' and E.Dc='N' " & _
                        ''            "AND F.Main_Identity_Id='2' AND F.Dc='N' " & _
                        ''            "order by D.成大料號 "
                        '--------------------------------------------------------------------------
                        sqlString = "select  A.Order_Code as 成大料號,A.Order_Name as 品名,'' as 保險碼,'' as 健保編碼, "
                        sqlString &= "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='902' and code_id=A.Manage_Id) as 給付註記, "
                        sqlString &= "B.Spec as 規格型號 ,B.Purchase_Price_Unit as 單位,B.Price_Adjustment as 單價調整紀錄,B.Purchase_Price as 最後採購單價, "
                        sqlString &= "'' as 健保核定單價, '' as 健保價,'' as 自費價, '' as 自付差額,A.Material_Used_Cnt as 核給使用次數, "
                        sqlString &= "A.Include_Order_Mark as 健保內含項註記, "
                        sqlString &= "訂價原則 = CASE A.Order_Flag  "
                        sqlString &= "WHEN 'A' THEN 'A.科部上簽自訂' "
                        sqlString &= "WHEN 'B' THEN 'B.科部建議價格' "
                        sqlString &= "WHEN 'C' THEN 'C.衛生局加成' "
                        sqlString &= "Else  A.Order_Flag "
                        sqlString &= "End , "
                        sqlString &= "A.Insu_Cover_Opd+A.Insu_Cover_Emg+A.Insu_Cover_Ipd as 批價符號, "
                        sqlString &= "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='41' and code_id=Account_Id) as 收據項目, "
                        sqlString &= "A.Is_Prior_Review as 事前審查,"
                        sqlString &= "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='500' and code_id=Apply_Status_Id) as 申請狀況, "
                        sqlString &= "C.Self_Insu_Code as 虛擬健保碼,C.Equipment_License_No as 衛證號,B.Stock_Unit as 庫房別 ,"
                        sqlString &= "A.Brand as 廠牌 , '' as 廠商,A.Order_Note as 醫令備註,CONVERT(varchar(12), A.Effect_Date,111) as 生效日 ,"
                        sqlString &= "'' as 設量者,'' as 最近進貨日,A.Modified_User as 修改者,CONVERT(varchar, A.Modified_Time,120) as 修改時間,"
                        sqlString &= "C.Use_Reason as 使用原因,"
                        sqlString &= "C.Product_Features as 產品特性,C.Precautions as 注意事項,C.Side_Effect as 副作用,C.Efficacy_Comparison as 療效比較 "
                        sqlString &= "from PUB_Order as A join PUB_Mis_Purchase_Data as B  "
                        sqlString &= "on A.Order_Code=B.Purchase_Code  "
                        sqlString &= "join PUB_Material_Selfpay_Apply as C "
                        sqlString &= "on A.Order_Code = C.Order_Code "
                        sqlString &= "where A.Order_Type_Id='G' and A.Dc='N' "



                    Case "Normal"
                        'modify by 唐子晴 2014.01.07---------------------------------------------
                        ''sqlString = "SELECT D.成大料號,D.品名,'' as 保險碼,F.Insu_Code as 新保險碼,F.Insu_Group_Code as 健保編碼, "
                        ''sqlString &= "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='902' and code_id=D.Manage_Id) as 給付註記, "
                        ''sqlString &= "D.規格型號,D.單位,D.單價調整紀錄,D.最後採購單價,F.Insu_Apply_Price as 健保核定單價,'' as 健保價,F.Price as 新健保價, "
                        ''sqlString &= "'' as 自費價, E.Price as 新自費價,F.Add_Price as 自付差額, D.核給使用次數,D.健保內含項註記,D.訂價原則,D.批價符號, "
                        ''sqlString &= "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='41' and code_id=D.Account_Id) as 收據項目, "
                        ''sqlString &= "D.事前審查, "
                        ''sqlString &= "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='500' and code_id=D.Apply_Status_Id) as 申請狀況, "
                        ''sqlString &= "D.虛擬健保碼, D.衛證號, D.庫房別, D.廠牌, D.廠商, D.醫令備註, D.生效日, D.設量者, D.最近進貨日, D.修改者, D.修改時間, D.使用原因, "
                        ''sqlString &= "D.產品特性 ,D.注意事項,D.副作用,D.療效比較 "
                        ''sqlString &= "FROM "
                        ''sqlString &= "(select  A.Dc, A.Order_Code as 成大料號,A.Order_Name as 品名,A.Material_Used_Cnt as 核給使用次數, "
                        ''sqlString &= "A.Include_Order_Mark as 健保內含項註記,A.Brand as 廠牌 , '' as 廠商,'' as 設量者,'' as 最近進貨日, "
                        ''sqlString &= "A.Insu_Cover_Opd+A.Insu_Cover_Emg+A.Insu_Cover_Ipd as 批價符號, "
                        ''sqlString &= "A.Is_Prior_Review as 事前審查, A.Modified_User as 修改者, "
                        ''sqlString &= "CONVERT(varchar, A.Modified_Time,120) as 修改時間, A.Account_Id,A.Manage_Id , "
                        ''sqlString &= "B.Spec as 規格型號 ,B.Purchase_Price_Unit as 單位,B.Purchase_Price as 最後採購單價, "
                        ''sqlString &= "B.Stock_Unit as 庫房別 , A.Effect_Date,CONVERT(varchar(12), A.End_Date,111) as End_Date , "
                        ''sqlString &= "B.Price_Adjustment as 單價調整紀錄, A.Order_Note as 醫令備註, "
                        ''sqlString &= "CONVERT(varchar(12), A.Effect_Date,111) as 生效日 , "
                        ''sqlString &= "C.Equipment_License_No as 衛證號, C.Use_Reason as 使用原因,C.Self_Insu_Code as 虛擬健保碼,C.Apply_Status_Id, "
                        ''sqlString &= "C.Product_Features as 產品特性,C.Precautions as 注意事項,C.Side_Effect as 副作用,C.Efficacy_Comparison as 療效比較, "
                        ''sqlString &= "訂價原則 = CASE A.Order_Flag  "
                        ''sqlString &= "WHEN 'A' THEN 'A.科部上簽自訂' "
                        ''sqlString &= "WHEN 'B' THEN 'B.科部建議價格' "
                        ''sqlString &= "WHEN 'C' THEN 'C.衛生局加成' "
                        ''sqlString &= "Else  A.Order_Flag "
                        ''sqlString &= "End "
                        ''sqlString &= "from PUB_Order as A join PUB_Mis_Purchase_Data as B  "
                        ''sqlString &= "on A.Order_Code=B.Purchase_Code  "
                        ''sqlString &= "join PUB_Material_Selfpay_Apply as C "
                        ''sqlString &= "on A.Order_Code = C.Order_Code "
                        ''sqlString &= "where A.Order_Type_Id='G' and A.Dc='N' "
                        ''If OrderCode <> "" Then
                        ''    sqlString &= "and A.Order_Code='" & OrderCode & "' "
                        ''End If

                        ''sqlString &= "and A.Modified_Time >='" & type(1) & " 00:00:00' And A.Modified_Time<='" & type(2) & " 23:59:59'"
                        ''sqlString &= ") AS D LEFT JOIN PUB_Order_Price AS E  "
                        ''sqlString &= "ON D.成大料號=E.Order_Code "
                        ''sqlString &= "LEFT JOIN PUB_Order_Price AS F "
                        ''sqlString &= "ON D.成大料號=F.Order_Code  "
                        ''sqlString &= "where E.Main_Identity_Id='1' and E.Dc='N' "
                        ''sqlString &= "AND F.Main_Identity_Id='2' AND F.Dc='N' "
                        ''sqlString &= "order by D.成大料號 "


                        sqlString = "select  A.Order_Code as 成大料號,A.Order_Name as 品名,'' as 保險碼,'' as 新保險碼, '' as 健保編碼, "
                        sqlString &= "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='902' and code_id=A.Manage_Id) as 給付註記, "
                        sqlString &= "B.Spec as 規格型號 ,B.Purchase_Price_Unit as 單位,B.Price_Adjustment as 單價調整紀錄,B.Purchase_Price as 最後採購單價, "
                        sqlString &= "'' as 健保核定單價, '' as 健保價,'' as 新健保價,'' as 自費價, '' as 新自費價,'' as 自付差額,A.Material_Used_Cnt as 核給使用次數, "
                        sqlString &= "A.Include_Order_Mark as 健保內含項註記, "
                        sqlString &= "訂價原則 = CASE A.Order_Flag  "
                        sqlString &= "WHEN 'A' THEN 'A.科部上簽自訂' "
                        sqlString &= "WHEN 'B' THEN 'B.科部建議價格' "
                        sqlString &= "WHEN 'C' THEN 'C.衛生局加成' "
                        sqlString &= "Else  A.Order_Flag "
                        sqlString &= "End , "
                        sqlString &= "A.Insu_Cover_Opd+A.Insu_Cover_Emg+A.Insu_Cover_Ipd as 批價符號, "
                        sqlString &= "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='41' and code_id=Account_Id) as 收據項目, "
                        sqlString &= "A.Is_Prior_Review as 事前審查,"
                        sqlString &= "(select RTRIM(code_id)+' - '+ code_name from PUB_Syscode where TYPE_ID='500' and code_id=Apply_Status_Id) as 申請狀況, "
                        sqlString &= "C.Self_Insu_Code as 虛擬健保碼,C.Equipment_License_No as 衛證號,B.Stock_Unit as 庫房別 ,"
                        sqlString &= "A.Brand as 廠牌 , '' as 廠商,A.Order_Note as 醫令備註,CONVERT(varchar(12), A.Effect_Date,111) as 生效日 ,"
                        sqlString &= "'' as 設量者,'' as 最近進貨日,A.Modified_User as 修改者,CONVERT(varchar, A.Modified_Time,120) as 修改時間,"
                        sqlString &= "C.Use_Reason as 使用原因,"
                        sqlString &= "C.Product_Features as 產品特性,C.Precautions as 注意事項,C.Side_Effect as 副作用,C.Efficacy_Comparison as 療效比較 "
                        sqlString &= "from PUB_Order as A join PUB_Mis_Purchase_Data as B  "
                        sqlString &= "on A.Order_Code=B.Purchase_Code  "
                        sqlString &= "join PUB_Material_Selfpay_Apply as C "
                        sqlString &= "on A.Order_Code = C.Order_Code "
                        sqlString &= "where A.Order_Type_Id='G' and A.Dc='N' "
                        If OrderCode <> "" Then
                            sqlString &= "and A.Order_Code='" & OrderCode & "' "
                        End If

                        sqlString &= "and A.Modified_Time >='" & type(1) & " 00:00:00' And A.Modified_Time<='" & type(2) & " 23:59:59'"
                End Select

                command.CommandText = sqlString
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet(tableName)
                    adapter.Fill(ds, tableName)
                End Using

                Dim priceDs As DataSet
                Select Case type(0)
                    Case "All"
                        For index As Integer = 0 To ds.Tables(0).Rows.Count - 1
                            sqlString = "select Price as 自費價 from PUB_Order_Price "
                            sqlString &= "where Order_Code='" & ds.Tables(0).Rows(index)("成大料號").ToString & "' "
                            sqlString &= "and Main_Identity_Id='1' and Dc='N';"

                            sqlString &= "select Insu_Code as 保險碼,Price as 健保價,Add_Price as 自付差額,Insu_Group_Code as 健保編碼, "
                            sqlString &= "Insu_Apply_Price as 健保核定單價 "
                            sqlString &= "from PUB_Order_Price "
                            sqlString &= "where Order_Code='" & ds.Tables(0).Rows(index)("成大料號").ToString & "' "
                            sqlString &= "and Main_Identity_Id='2' and Dc='N'"
                            command.CommandText = sqlString
                            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                                priceDs = New DataSet()
                                adapter.Fill(priceDs)

                                If priceDs.Tables(0).Rows.Count > 0 Then
                                    ds.Tables(0).Rows(index)("自費價") = priceDs.Tables(0).Rows(0)("自費價").ToString
                                Else
                                    ds.Tables(0).Rows(index)("自費價") = ""
                                End If
                                If priceDs.Tables(1).Rows.Count > 0 Then
                                    ds.Tables(0).Rows(index)("保險碼") = priceDs.Tables(1).Rows(0)("保險碼").ToString
                                    ds.Tables(0).Rows(index)("健保價") = priceDs.Tables(1).Rows(0)("健保價").ToString
                                    ds.Tables(0).Rows(index)("自付差額") = priceDs.Tables(1).Rows(0)("自付差額").ToString
                                    ds.Tables(0).Rows(index)("健保編碼") = priceDs.Tables(1).Rows(0)("健保編碼").ToString
                                    'modify by 唐子晴 2014.01.13-------------------------------------------------------------
                                    'ds.Tables(0).Rows(index)("健保核定單價") = priceDs.Tables(1).Rows(0)("健保編碼").ToString
                                    ds.Tables(0).Rows(index)("健保核定單價") = priceDs.Tables(1).Rows(0)("健保核定單價").ToString
                                    '----------------------------------------------------------------------------------------
                                Else
                                    ds.Tables(0).Rows(index)("保險碼") = ""
                                    ds.Tables(0).Rows(index)("健保價") = ""
                                    ds.Tables(0).Rows(index)("自付差額") = ""
                                    ds.Tables(0).Rows(index)("健保編碼") = ""
                                    ds.Tables(0).Rows(index)("健保核定單價") = ""
                                End If
                            End Using
                        Next
                    Case "Normal"

                        Dim tempDs As DataSet
                        For index As Integer = 0 To ds.Tables(0).Rows.Count - 1
                            sqlString = "select Price as 新自費價 from PUB_Order_Price "
                            sqlString &= "where Order_Code='" & ds.Tables(0).Rows(index)("成大料號").ToString & "' "
                            sqlString &= "and Main_Identity_Id='1' and Dc='N';"

                            sqlString &= "select Insu_Code as 新保險碼,Price as 新健保價,Add_Price as 自付差額,Insu_Group_Code as 健保編碼, "
                            sqlString &= "Insu_Apply_Price as 健保核定單價 "
                            sqlString &= "from PUB_Order_Price "
                            sqlString &= "where Order_Code='" & ds.Tables(0).Rows(index)("成大料號").ToString & "' "
                            sqlString &= "and Main_Identity_Id='2' and Dc='N'"
                            command.CommandText = sqlString
                            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                                priceDs = New DataSet()
                                adapter.Fill(priceDs)

                                If priceDs.Tables(0).Rows.Count > 0 Then
                                    ds.Tables(0).Rows(index)("新自費價") = priceDs.Tables(0).Rows(0)("新自費價").ToString
                                Else
                                    ds.Tables(0).Rows(index)("新自費價") = ""
                                End If
                                If priceDs.Tables(1).Rows.Count > 0 Then
                                    ds.Tables(0).Rows(index)("新保險碼") = priceDs.Tables(1).Rows(0)("新保險碼").ToString
                                    ds.Tables(0).Rows(index)("新健保價") = priceDs.Tables(1).Rows(0)("新健保價").ToString
                                    ds.Tables(0).Rows(index)("自付差額") = priceDs.Tables(1).Rows(0)("自付差額").ToString
                                    ds.Tables(0).Rows(index)("健保編碼") = priceDs.Tables(1).Rows(0)("健保編碼").ToString
                                    'modify by 唐子晴 2014.01.13 --------------------------------------------------------------
                                    'ds.Tables(0).Rows(index)("健保核定單價") = priceDs.Tables(1).Rows(0)("健保編碼").ToString
                                    ds.Tables(0).Rows(index)("健保核定單價") = priceDs.Tables(1).Rows(0)("健保核定單價").ToString
                                    '------------------------------------------------------------------------------------------
                                Else
                                    ds.Tables(0).Rows(index)("新保險碼") = ""
                                    ds.Tables(0).Rows(index)("新健保價") = ""
                                    ds.Tables(0).Rows(index)("自付差額") = ""
                                    ds.Tables(0).Rows(index)("健保編碼") = ""
                                    ds.Tables(0).Rows(index)("健保核定單價") = ""
                                End If
                            End Using

                            sqlString = "SELECT Insu_Code as 保險碼,Price as 健保價 FROM PUB_Order_Price "
                            sqlString &= "where Order_Code='" & ds.Tables(0).Rows(index)("成大料號").ToString & "' "
                            'modify by 唐子晴 2014.05.08 ---------------------------
                            'sqlString &= "and Effect_Date<SYSDATETIME() and Effect_Date>='" & ds.Tables(0).Rows(index)("生效日").ToString & "'"
                            'sqlString &= "and Main_Identity_Id='2' ORDER BY Effect_Date; "
                            sqlString &= "and Dc='Y' "
                            sqlString &= "and Main_Identity_Id='2' ORDER BY Effect_Date desc, Main_Identity_Id; "
                            '------------------------------------------------------

                            sqlString &= "SELECT Price as 自費價 FROM PUB_Order_Price "
                            sqlString &= "where Order_Code='" & ds.Tables(0).Rows(index)("成大料號").ToString & "' "
                            'modify by 唐子晴 2014.05.08--------------------
                            'sqlString &= "and Effect_Date<SYSDATETIME() and Effect_Date>='" & ds.Tables(0).Rows(index)("生效日").ToString & "'"
                            'sqlString &= "and Main_Identity_Id='1' ORDER BY Effect_Date; "
                            sqlString &= "and Dc='Y' "
                            sqlString &= "and Main_Identity_Id='1' ORDER BY Effect_Date desc, Main_Identity_Id; "
                            '--------------------------------------------

                            command.CommandText = sqlString
                            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                                tempDs = New DataSet()
                                adapter.Fill(tempDs)

                                If tempDs.Tables(0).Rows.Count > 0 Then
                                    ds.Tables(0).Rows(index)("保險碼") = tempDs.Tables(0).Rows(0)("保險碼").ToString
                                    ds.Tables(0).Rows(index)("健保價") = tempDs.Tables(0).Rows(0)("健保價").ToString
                                Else
                                    ds.Tables(0).Rows(index)("保險碼") = ""
                                    ds.Tables(0).Rows(index)("健保價") = ""
                                End If
                                If tempDs.Tables(1).Rows.Count > 0 Then
                                    ds.Tables(0).Rows(index)("自費價") = tempDs.Tables(1).Rows(0)("自費價").ToString
                                Else
                                    ds.Tables(0).Rows(index)("自費價") = ""
                                End If
                            End Using
                        Next
                End Select
                '--------------------------------------------------------------------------------------------------
            Else
                sqlConn = CType(getConnection(), SqlConnection)
                command = sqlConn.CreateCommand()
                'add by 唐子晴 2014.02.19 加入生效日---------------------------------------------------------------------------------------------------
                'modify by 唐子晴 2014.04.09 匯出公用主檔時 , 欄位"健保費用名稱" , 不符使用 , 修正取其健保支付標準檔之中文名稱, 做為健保費用名稱    
                'case when C.Insu_Name Is null then E.Insu_Name else C.Insu_Name end as 健保費用名稱
                sqlString = " Select A.Order_Type_Id as 醫令類別,A.Order_Code as 醫令碼,A.Order_En_Name as 醫令英文名稱,A.Order_Name as 醫令中文名稱," & _
                                              " case when B.Insu_Code='ZZZZZZ' then '' else B.Insu_Code end" & _
                                              " +case when C.Insu_Code Is null then '' else  C.Insu_Code end as 健保代碼," & _
                                              " C.Tqty as 數量 ," & _
                                              " E.Insu_Name as 健保費用名稱," & _
                                              " D.Price as 自費價,B.Price as 健保價,B.Add_Price as 自費差價," & _
                                              " case when B.Price Is null then '不給付' else '' end as 給付原則," & _
                                              " case when B.Is_Kid_Add='Y' then '兒加' else '' end as 兒加," & _
                                              " case when B.Is_Emg_Add='Y' then '急加' else '' end as 急加," & _
                                              " case when B.Is_Dental_Add='Y' then '牙轉加' else '' end as 牙轉加," & _
                                              " D.Insu_Cover_Opd as 門診可開立,D.Insu_Cover_Emg as 急診可開立,D.Insu_Cover_Ipd as 住診可開立,A.Account_Id as 院內費用項目代碼,B.Order_Ratio as 醫令比率,B.Material_Account_Id as 材料費費用項目代碼,B.Material_Ratio as 材料費比率, " & _
                                              " A.Is_Prior_Review as 事前審查,OP.Class_Code as 藥理分類,A.Charge_Unit as 計價單位,A.Nhi_Transrate as 計價轉申報單位,A.Nhi_Unit as 申報單位,A.Include_Order_Mark as 	內含項註 " & _
                                              " , case when B.Effect_date is null then convert(varchar,D.Effect_date,111) else convert(varchar,B.Effect_date,111) end as 生效日  " & _
                                              " from PUB_Order A"
                If nvl(OrderTime) <> "" AndAlso nvl(OrderTime) > Now Then
                    sqlString &= " left join PUB_Order_Price B "
                    sqlString &= " on  B.Effect_date >= '" & OrderTime & "' and A.Order_Code=B.Order_Code and B.Main_Identity_Id='2' "
                    sqlString &= " left join PUB_Order_Price D "
                    sqlString &= " on  D.Effect_date >= '" & OrderTime & "' and A.Order_Code=D.Order_Code and D.Main_Identity_Id='1' "
                Else
                    sqlString &= " left join PUB_Order_Price B"
                    sqlString &= " on  B.Dc='N' and A.Order_Code=B.Order_Code and B.Main_Identity_Id='2' "
                    sqlString &= " left join PUB_Order_Price D"
                    sqlString &= " on  D.Dc='N' and A.Order_Code=D.Order_Code and D.Main_Identity_Id='1' "
                End If
                sqlString &= " left join PUB_Insu_Code C " & _
                                                 " on B.Main_Identity_Id='2' and  B.Order_Code=C.Order_Code and C.Dc='N'" & _
                                                 " left outer join OPH_Pharmacy_Base OP on OP.Order_Code =A.Order_Code and OP.Dc='N' "

                sqlString &= " left join PUB_Nhi_Code E " & _
                             "on  B.Main_Identity_Id='2' and B.Insu_Code=E.Insu_Code and E.Dc='N'  "

                sqlString &= " where  A.Dc='N' and A.Order_Type_Id='" & OrderType & "'   "

                If OrderCode <> "" Then
                    sqlString &= " and A.Order_Code='" & OrderCode & "' "

                End If

                '2014/1/10 匯出需參考有效日 modified by CY.Wang.
                If nvl(OrderTime) <> "" AndAlso nvl(OrderTime) > Now Then
                    sqlString &= " and ( B.Effect_date >= '" & OrderTime & "'  or  D.Effect_date >= '" & OrderTime & "') "
                ElseIf nvl(OrderTime) <> "" Then
                    sqlString &= " and ( B.Effect_date >= '" & OrderTime & "'  or  D.Effect_date >= '" & OrderTime & "') "
                End If

                sqlString &= " order By A.Order_Code "

                command.CommandText = sqlString
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet(tableName)
                    adapter.Fill(ds, tableName)
                    'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
                End Using
            End If
            '----------------------------------------------------------------------------------------------------------------------
            'mark by 唐子晴 2014.01.06---------------------------------------------------------------------------------------------
            'Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            'Dim command As SqlCommand = sqlConn.CreateCommand()

            'sqlString = " Select A.Order_Type_Id as 醫令類別,A.Order_Code as 醫令碼,A.Order_En_Name as 醫令英文名稱,A.Order_Name as 醫令中文名稱," & _
            '                                  " case when B.Insu_Code='ZZZZZZ' then '' else B.Insu_Code end" & _
            '                                  " +case when C.Insu_Code Is null then '' else  C.Insu_Code end as 健保代碼," & _
            '                                  " C.Tqty as 數量 ," & _
            '                                  " case when C.Insu_Name Is null then E.Insu_En_Name else C.Insu_Name end as 健保費用名稱," & _
            '                                  " D.Price as 自費價,B.Price as 健保價,B.Add_Price as 自費差價," & _
            '                                  " case when B.Price Is null then '不給付' else '' end as 給付原則," & _
            '                                  " case when B.Is_Kid_Add='Y' then '兒加' else '' end as 兒加," & _
            '                                  " case when B.Is_Emg_Add='Y' then '急加' else '' end as 急加," & _
            '                                  " case when B.Is_Dental_Add='Y' then '牙轉加' else '' end as 牙轉加," & _
            '                                  " D.Insu_Cover_Opd as 門診可開立,D.Insu_Cover_Emg as 急診可開立,D.Insu_Cover_Ipd as 住診可開立,A.Account_Id as 院內費用項目代碼,B.Order_Ratio as 醫令比率,B.Material_Account_Id as 材料費費用項目代碼,B.Material_Ratio as 材料費比率, " & _
            '                                  " A.Is_Prior_Review as 事前審查,OP.Class_Code as 藥理分類,A.Charge_Unit as 計價單位,A.Nhi_Transrate as 計價轉申報單位,A.Nhi_Unit as 申報單位,A.Include_Order_Mark as 	內含項註 " & _
            '                           " from PUB_Order A"
            'If nvl(OrderTime) <> "" AndAlso nvl(OrderTime) > Now Then
            '    sqlString &= " left join PUB_Order_Price B "
            '    sqlString &= " on  B.Effect_date >= '" & OrderTime & "' and A.Order_Code=B.Order_Code and B.Main_Identity_Id='2' "
            '    sqlString &= " left join PUB_Order_Price D "
            '    sqlString &= " on  D.Effect_date >= '" & OrderTime & "' and A.Order_Code=D.Order_Code and D.Main_Identity_Id='1' "
            'Else
            '    sqlString &= " left join PUB_Order_Price B"
            '    sqlString &= " on  B.Dc='N' and A.Order_Code=B.Order_Code and B.Main_Identity_Id='2' "
            '    sqlString &= " left join PUB_Order_Price D"
            '    sqlString &= " on  D.Dc='N' and A.Order_Code=D.Order_Code and D.Main_Identity_Id='1' "
            'End If
            'sqlString &= " left join PUB_Insu_Code C " & _
            '                                 " on B.Main_Identity_Id='2' and  B.Order_Code=C.Order_Code and C.Dc='N'" & _
            '                                 " left outer join OPH_Pharmacy_Base OP on OP.Order_Code =A.Order_Code and OP.Dc='N' "

            'sqlString &= " left join PUB_Nhi_Code E " & _
            '             "on  B.Main_Identity_Id='2' and B.Insu_Code=E.Insu_Code and E.Dc='N'  "

            'sqlString &= " where  A.Dc='N' and A.Order_Type_Id='" & OrderType & "'   "

            'If OrderCode <> "" Then
            '    sqlString &= " and A.Order_Code='" & OrderCode & "' "

            'End If

            'If nvl(OrderTime) <> "" AndAlso nvl(OrderTime) > Now Then
            '    sqlString &= " and ( B.Effect_date >= '" & OrderTime & "'  or  D.Effect_date >= '" & OrderTime & "') "

            'End If

            'sqlString &= " order By A.Order_Code "

            'command.CommandText = sqlString
            'Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
            '    ds = New DataSet(tableName)
            '    adapter.Fill(ds, tableName)
            '    'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            'End Using
            '-------------------------------------------------------------------------------------------------------------------------

            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex

        End Try

    End Function

    ''' <summary>
    ''' 和表Pub_syscode關聯取得診別
    ''' </summary>
    ''' <remarks></remarks>
    Public Function QueryPUBExportByPubSyscodeByAll() As System.Data.DataSet

        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select  Code_Id, Code_Name   ")
        strSql.Append(" ").Append("from ")
        strSql.Append(" ").Append("PUB_Syscode")
        strSql.Append(" ").Append("Where Type_Id=31")
        strSql.Append(" ").Append("order by Type_Id")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getOpdDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
        Return ds
    End Function
    'add by 唐子晴 2013.12.18--------------------------------------------------------------------
    Public Function QueryPUBExportByModifyData(ByRef sqlString As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
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
    '--------------------------------------------------------------------------------------
#End Region

    ''' <summary>
    '''當PUB_Order 維護存檔完成，執行下列SQL 校正，取price 最小日期，update Pub_Order.Effect_Date
    ''' </summary>
    ''' <remarks></remarks>
    Public Function UpdatePUBOrderEffectDateByOrderCode(ByVal OrderCode As String) As Integer

        Dim conn As IDbConnection = getConnection()

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = " update pub_order set pub_order.Effect_Date=T2.Price_effect_date " & _
                                        " from pub_order T1 " & _
                                        " Inner Join " & _
                                        " (select Min(B.Order_Code) as Order_Code " & _
                                        "        ,MIN(A.effect_date) as Order_effect_date " & _
                                        "        ,MIN(B.effect_date) as Price_effect_date " & _
                                        "  from  pub_order A " & _
                                        "        left join pub_order_price B " & _
                                        "             on (A.Order_Code=B.order_code)  " & _
                                        "  where  A.Order_Code= @Order_Code " & _
                                        "  having MIN(A.effect_date)<>MIN(B.effect_date) " & _
                                        " ) T2 " & _
                                        " on (T1.Order_Code=T2.Order_Code and T1.Effect_Date=T2.Order_effect_date) ;"
             

            conn.Open()
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Order_Code", OrderCode)

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            '==================
            '加入backup
            Try
                Using conn_backup As SqlConnection = getConnection()
                    conn_backup.Open()
                    Using command As SqlCommand = conn_backup.CreateCommand()
                        sqlString = " Select *    " & _
                                                   " from pub_order T1 " & _
                                                   " Inner Join " & _
                                                   " (select Min(B.Order_Code) as Order_Code " & _
                                                   "        ,MIN(A.effect_date) as Order_effect_date " & _
                                                   "        ,MIN(B.effect_date) as Price_effect_date " & _
                                                   "  from  pub_order A " & _
                                                   "        left join pub_order_price B " & _
                                                   "             on (A.Order_Code=B.order_code)  " & _
                                                   "  where  A.Order_Code= @Order_Code " & _
                                                   "  having MIN(A.effect_date)<>MIN(B.effect_date) " & _
                                                   " ) T2 " & _
                                                   " on (T1.Order_Code=T2.Order_Code and T1.Effect_Date=T2.Order_effect_date) ;"

                        command.CommandText = sqlString
                        command.Parameters.AddWithValue("@Order_Code", OrderCode)
                        Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                            Using OrderDS As DataSet = New DataSet("OrderDS")
                                adapter.Fill(OrderDS, "OrderDS")

                                For Each row As DataRow In OrderDS.Tables(0).Rows
                                    updateBackup(row, conn_backup)
                                Next

                            End Using
                        End Using
                    End Using

                    conn_backup.Close()

                End Using
            Catch ex As Exception
                Syscom.Server.CMM.LOGDelegate.getInstance.dbDebugMsg("備份錯誤-" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "-" & ex.ToString)
            End Try
          
            '==================
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
    End Function

    Public Function queryDateByOrderCode(ByVal inOrderCode As String) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getPUBDBConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            command.CommandText = "  Select A.Order_Code,A.Effect_Date,A.End_Date " & _
                                  "  From PUB_Order A,PUB_Material_Selfpay_Apply B " & _
                                  "  Where A.Order_Code ='" & inOrderCode & "' And " & _
                                  "        B.Effect_Date = A.Effect_Date " & _
                                  "  Order By A.Effect_Date"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function updateEndDateByOrderCode(ByVal inOrderCode As String, ByVal inEffectDate As String, ByVal inEndDate As String) As Integer

        Dim conn As IDbConnection = getPUBDBConnection()

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = " Update PUB_Material_Selfpay_Apply " & _
                                      " Set End_Date ='" & inEndDate & "' " & _
                                      " Where Order_Code ='" & inOrderCode & "' and Effect_Date ='" & inEffectDate & "' "
            conn.Open()
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With

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
    End Function

#Region "查詢醫令項目基本檔    "

    ''' <summary>
    ''' 查詢醫令項目基本檔   
    ''' </summary>
    ''' <param name="strOrderCode">醫令項目碼</param>
    ''' <param name="dc">Y、N，空字串表示不判斷</param>
    ''' <param name="judgeDate" >yyyy/MM/dd，空字串表示不判斷，判斷日當天仍有效的Order</param>
    ''' <remarks>by Sean.Lin on 2015-07-27</remarks>
    Public Function queryByOrderCode(ByVal strOrderCode As String, ByVal dc As String, ByVal judgeDate As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If


            Dim Content As New StringBuilder
            Content.AppendLine("       SELECT ")
            Content.AppendLine("       Effect_Date")
            Content.AppendLine("      ,Order_Code")
            Content.AppendLine("      ,Order_En_Name")
            Content.AppendLine("      ,Order_Name")
            Content.AppendLine("      ,Order_En_Short_Name")
            Content.AppendLine("      ,Order_Short_Name")
            Content.AppendLine("      ,Order_Type_Id")
            Content.AppendLine("      ,Account_Id")
            Content.AppendLine("      ,Is_Cure")
            Content.AppendLine("      ,Cure_Type_Id")
            Content.AppendLine("      ,Treatment_Type_Id")
            Content.AppendLine("      ,Charge_Unit")
            Content.AppendLine("      ,Nhi_Transrate")
            Content.AppendLine("      ,Nhi_Unit")
            Content.AppendLine("      ,Is_Order_Check")
            Content.AppendLine("      ,Fix_Order_Id")
            Content.AppendLine("      ,Is_Exclude_Drug")
            Content.AppendLine("      ,Order_Note")
            Content.AppendLine("      ,Order_Memo")
            Content.AppendLine("      ,Is_Agree_Sheet")
            Content.AppendLine("      ,Is_Nhi_Sheet")
            Content.AppendLine("      ,Is_Prior_Review")
            Content.AppendLine("      ,Is_IC_Card_Order")
            Content.AppendLine("      ,Is_Order_Price_Special")
            Content.AppendLine("      ,Dc_Reason")
            Content.AppendLine("      ,Dc")
            Content.AppendLine("      ,End_Date")
            Content.AppendLine("      ,Create_User")
            Content.AppendLine("      ,Create_Time")
            Content.AppendLine("      ,Modified_User")
            Content.AppendLine("      ,Modified_Time")
            Content.AppendLine("      ,Old_Order_Code")
            Content.AppendLine("      ,Material_Used_Cnt")
            Content.AppendLine("      ,Include_Order_Mark")
            Content.AppendLine("      ,Insu_Cover_Opd")
            Content.AppendLine("      ,Insu_Cover_Emg")
            Content.AppendLine("      ,Insu_Cover_Ipd")
            Content.AppendLine("      ,Is_Icd_Check")
            Content.AppendLine("      ,Is_Emg_Nursing_Charge")
            Content.AppendLine("       FROM PUB_Order   WHERE Order_Code =  @Order_Code    ")
            If dc <> "" Then
                Content.AppendLine("    AND  Dc = @DC  ")
            End If

            If judgeDate <> "" Then
                Content.AppendLine("    AND  Effect_Date <=  @judgeDate and @judgeDate < End_Date ")

            End If

            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim command As SqlCommand = sqlConnection.CreateCommand()
                command.CommandText = Content.ToString
                command.Parameters.AddWithValue("@Order_Code", strOrderCode)

                '註記
                If dc <> "" Then
                    command.Parameters.AddWithValue("@DC", dc)
                End If

                '判斷有效日期
                If judgeDate <> "" Then
                    command.Parameters.AddWithValue("@judgeDate", judgeDate)
                End If


                Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

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
