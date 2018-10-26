Imports System.Data.SqlClient
Imports Syscom.Server.SQL
'
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
'
Imports System.Text
Imports Syscom.Comm.EXP

Public Class PUBOrderPriceBO_E1
    Inherits PubOrderPriceBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBOrderPriceBO_E1
    Public Overloads Shared Function getInstance() As PUBOrderPriceBO_E1
        If instance Is Nothing Then
            instance = New PUBOrderPriceBO_E1
        End If
        Return instance
    End Function
#End Region

#Region "For OPCAPI用 2009/07/09/ Add By Nick"

    ''' <summary>
    ''' 規則3：
    ''' 再把規則2的Order_Code值代入如下
    ''' Insu_Account_Id值為OP.Insu_Account_Id
    ''' Price值為OP.Price
    ''' Add_Price值為OP. Add_Price
    ''' Material_Account_Id值為OP. Material_Account_Id
    ''' Material_Ratio值為OP. Material_Ratio
    ''' SELECT OP.Insu_Account_Id, OP.Price, OP.Add_Price, 
    ''' OP.Material_Account_Id, OP.Material_Ratio 
    ''' FROM PUB_Order_Price OP 
    ''' WHERE OP.Dc=N
    ''' AND OP.Order_Code = Order_Code 
    ''' AND OP.Main_Identity_Id = 保險別(身份1)
    ''' AND OP.Effect_Date ＜＝ 掛號日期、就醫日
    ''' AND OP.End_Date ＞ 掛號日期、就醫日
    ''' </summary>
    ''' <param name="keyValue">
    ''' Key = Order_Code
    ''' Key = Main_Identity_Id：保險別(身份1)
    ''' Key = DATE：REG_DATE(掛號日)、OPD_VISIT_DATE(就醫日)
    ''' </param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getPubOrderPriceDataForOPCAPI(ByVal keyValue As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Dim cmdStr As New StringBuilder

        ' SQL
        cmdStr.Append("select")
        cmdStr.Append(vbCrLf + "rtrim(A.Insu_Account_Id) as Insu_Account_Id,")
        cmdStr.Append(vbCrLf + "A.Price,")
        cmdStr.Append(vbCrLf + "A.Add_Price,")
        cmdStr.Append(vbCrLf + "rtrim(A.Material_Account_Id) as Material_Account_Id,")
        cmdStr.Append(vbCrLf + "A.Material_Ratio,")
        cmdStr.Append(vbCrLf + "rtrim(B.Account_Id) as Account_Id")
        cmdStr.Append(vbCrLf + "from " + tableName + " as A")
        cmdStr.Append(vbCrLf + "left join PUB_Order as B on B.Order_Code = A.Order_Code and B.Effect_Date<=@DATE and B.End_Date>=@DATE")
        cmdStr.Append(vbCrLf + "where 1=1")
        'cmdStr.Append(vbCrLf + "and A.Dc=@Dc")
        cmdStr.Append(vbCrLf + "and A.Order_Code=@Order_Code")
        cmdStr.Append(vbCrLf + "and A.Main_Identity_Id=@Main_Identity_Id")
        cmdStr.Append(vbCrLf + "and A.Effect_Date<=@DATE")
        cmdStr.Append(vbCrLf + "and A.End_Date>=@DATE")

        Try
            '執行SQL
            Dim columnNames As String() = {"Order_Code", "Main_Identity_Id", "DATE"}
            Dim columnTypes As Integer() = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

            Using paramDT As DataTable = DataSetUtil.GenDataTable("paramDT", Nothing, columnNames, columnTypes)
                With keyValue.Tables(0).Rows(0)
                    paramDT.Rows.Add(New Object() {.Item("Order_Code").ToString.Trim, _
                                                   .Item("Main_Identity_Id").ToString.Trim, _
                                                   .Item("DATE").ToString.Trim})
                End With

                Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, paramDT, "select1", Nothing, conn)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "     2016/9/13 取得最小生效日期和最大到期日, By Kaiwen , PubOrderBS "
    Public Function queryEffectdayAndEndday(ByRef pk_Order_Code As System.String, ByRef pk_Main_Identity_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select  top 1  ")
            content.AppendLine(" Effect_Date , Order_Code , Main_Identity_Id , Price , Add_Price ,  ")
            content.AppendLine(" Material_Ratio , Material_Account_Id , Order_Ratio , Is_Emg_Add , Is_Kid_Add ,  ")
            content.AppendLine(" Is_Dental_Add , Is_Holiday_Add , Is_Dept_Add , Insu_Code , Insu_Account_Id ,  ")
            content.AppendLine(" Insu_Order_Type_Id , Opd_Add_Order_Code , Emg_Add_Order_Code , Ipd_Add_Order_Code , Emg_Nursing_Add_Order_Code ,  ")
            content.AppendLine(" Ipd_Nursing_Add_Order_Code , Insu_Group_Code , Insu_Apply_Price , Dc , End_Date ,  ")
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time , Charge_Flag ")
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where Order_Code like '" & pk_Order_Code & "%' and Main_Identity_Id like '" & pk_Main_Identity_Id & "%' ")
            content.AppendLine("Order by Effect_Date   ")

            command.CommandText = content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName & "Effect_Day")
                adapter.Fill(ds, tableName)
            End Using

            content.AppendLine("select top 1 * ")
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where Order_Code like '" & pk_Order_Code & "%' and Main_Identity_Id like '" & pk_Main_Identity_Id & "%' ")
            content.AppendLine("Order by End_Date  desc  ")

            command.CommandText = content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName & "Effect_Day")
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

    ''' <summary>
    ''' 由醫令查價錢
    ''' </summary>
    ''' <param name="orderNo">醫令碼</param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function queryPriceByOrders(ByVal orderNo() As String) As DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim orders As String = ""

            If orderNo IsNot Nothing And orderNo.Length > 0 Then
                For i As Integer = 0 To (orderNo.Length - 1)
                    If i = (orderNo.Length - 1) Then
                        orders = orders & "'" & orderNo(i) & "'"
                    Else
                        orders = orders & "'" & orderNo(i) & "',"
                    End If
                Next
            End If

            ds = New DataSet(tableName)

            If orders.Length > 0 Then
                command.CommandText = "select * from  " & tableName & " where Order_Code in (" & orders & ") And DC = 'N' and Main_Identity_Id = '1' " _
                & " and Effect_Date <= '" & DateUtil.SystemDate("yyyyMMdd") & "'"
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)

                    adapter.Fill(ds, tableName)
                    adapter.FillSchema(ds, SchemaType.Mapped, tableName)
                End Using
            End If

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 查詢醫令代碼是否存在。
    ''' </summary>
    ''' <param name="mainIdentityId">主身分代碼</param>
    ''' <param name="orderCode">醫令代碼</param>
    ''' <returns>查詢結果</returns>
    ''' <author>Ken</author>
    ''' <tables>
    ''' Pub_order_price
    ''' </tables>
    ''' <remarks></remarks>
    Public Function queryPUBOrderPriceByKey(ByVal mainIdentityId As String, ByVal orderCode As String) As DataSet

        Dim _now As Date = Date.Now

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT Price, " & vbCrLf)
        var1.Append("       Add_price, " & vbCrLf)
        var1.Append("       Material_ratio, " & vbCrLf)
        var1.Append("       Material_account_id, " & vbCrLf)
        var1.Append("       Is_emg_add, " & vbCrLf)
        var1.Append("       Is_kid_add, " & vbCrLf)
        var1.Append("       Is_dental_add, " & vbCrLf)
        var1.Append("       Is_holiday_add, " & vbCrLf)
        var1.Append("       Insu_code, " & vbCrLf)
        var1.Append("       Insu_cover_opd, " & vbCrLf)
        var1.Append("       Insu_cover_emg, " & vbCrLf)
        var1.Append("       Insu_cover_ipd, " & vbCrLf)
        var1.Append("       Insu_account_id, " & vbCrLf)
        var1.Append("       Insu_order_type_id, " & vbCrLf)
        var1.Append("       Opd_add_order_code, " & vbCrLf)
        var1.Append("       Emg_add_order_code, " & vbCrLf)
        var1.Append("       Ipd_add_order_code, " & vbCrLf)
        var1.Append("       Emg_nursing_add_order_code, " & vbCrLf)
        var1.Append("       Ipd_nursing_add_order_code " & vbCrLf)
        var1.Append("FROM   Pub_order_price " & vbCrLf)
        var1.AppendFormat("WHERE  Order_code = '{0}' " & vbCrLf, orderCode.Replace("'", "''"))
        var1.AppendFormat("       AND Main_identity_id = '{0}' " & vbCrLf, mainIdentityId.Replace("'", "''"))
        var1.AppendFormat("       AND Effect_date <= '{0}' " & vbCrLf, _now.ToShortDateString)
        var1.AppendFormat("       AND (End_date >= '{0}' " & vbCrLf, _now.ToShortDateString)
        var1.AppendFormat("             OR End_date IS NULL) " & vbCrLf)
        var1.AppendFormat("       AND Dc <> 'Y' " & vbCrLf)


        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(var1.ToString, _sqlConnection)
                _dataAdapter.Fill(_ds, "PUB_Sub_Identity")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 取得門診群組醫令代碼
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <param name="MainIdentityId"></param>
    ''' <param name="OrderTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBOrderPriceByCond(ByVal OrderCode As String, ByVal MainIdentityId As String, ByVal OrderTime As String) As DataSet


        '2 取得門診群組醫令代碼
        '    讀取醫令項目價格檔(PUB_Order_Price)之門診群組醫令代碼(Opd_Add_Order_Code) ，
        '    條件為醫令開立日期>=Effect_Date and 醫令開立日期<=End_Date and Order_Code =開立醫令代碼 and　 
        '    PUB_Sub_Identity_Set. Main_Identity_Id = Main_Identity_Id and Dc =’N’ 
        Try
            Dim returnDS As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select Opd_Add_Order_Code" & _
                                  " From " & tableName & " " & _
                                  " Where Effect_Date <='" & OrderTime & "' And '" & OrderTime & "'<=End_Date And Main_Identity_Id='" & MainIdentityId & "' And Account_Id='++' And Order_Code='" & OrderCode & "'  And DC = 'N' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                returnDS = New DataSet(tableName)
                adapter.Fill(returnDS, tableName)
                adapter.FillSchema(returnDS, SchemaType.Mapped, tableName)
            End Using
            Return returnDS
        Catch ex As Exception
            Throw ex
        End Try


    End Function


    ''' <summary>
    ''' 醫令資料查詢(醫令價格)
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order, PUB_Order_Price</remarks>
    Public Function queryOrderPriceData(ByVal OrderCode As String) As DataTable

        Dim cmdStrOrderPrice As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------

        'Order_Price
        cmdStrOrderPrice.AppendLine("select * ")
        cmdStrOrderPrice.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrderPrice.Append("where Order_Code = @OrderCode ")
        cmdStrOrderPrice.AppendLine("and Dc <> @DcY ")
        cmdStrOrderPrice.AppendLine("Order by Main_Identity_Id asc, Effect_Date desc ")
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
            Dim dtOrderPrice As DataTable = New DataTable(PubOrderPriceDataTableFactory.tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()

                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrderPrice.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                        sqlCmd.Parameters.AddWithValue("@DcY", "Y")

                        Using daOP As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            daOP.Fill(dtOrderPrice)
                        End Using

                    End With
                End Using

            End Using

            'Return ds
            Return dtOrderPrice

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 醫令歷史資料查詢(醫令價格)
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order, PUB_Order_Price</remarks>
    Public Function queryOrderPriceHistoryData(ByVal OrderCode As String) As DataTable

        Dim cmdStrOrderPrice As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------

        'Order_Price
        cmdStrOrderPrice.AppendLine("select * ")
        cmdStrOrderPrice.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrderPrice.Append("where Order_Code = @OrderCode ")
        'cmdStrOrderPrice.AppendLine("and Dc = @DcY ")
        cmdStrOrderPrice.AppendLine("Order by Effect_Date desc,Main_Identity_Id asc  ")
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
            Dim dtOrderPrice As DataTable = New DataTable(PubOrderPriceDataTableFactory.tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()

                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrderPrice.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                        'sqlCmd.Parameters.AddWithValue("@DcY", "Y")

                        Using daOP As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            daOP.Fill(dtOrderPrice)
                        End Using

                    End With
                End Using

            End Using

            'Return ds
            Return dtOrderPrice

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 醫令資料查詢(醫令價格)
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order, PUB_Order_Price</remarks>
    Public Function queryOrderPriceDataByOrder(ByVal OrderCode As String) As DataTable

        Dim cmdStrOrderPrice As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------

        'Order_Price
        cmdStrOrderPrice.AppendLine("select * ")
        cmdStrOrderPrice.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrderPrice.Append("where Order_Code = @OrderCode ")
        cmdStrOrderPrice.AppendLine("and Dc <> @DcY and Effect_Date <= @NowDate and End_Date >= @NowDate and Main_Identity_Id = @Main_Identity_Id ")
        cmdStrOrderPrice.AppendLine("Order by Main_Identity_Id asc, Effect_Date desc ")
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
            Dim dtOrderPrice As DataTable = New DataTable(PubOrderPriceDataTableFactory.tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()

                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrderPrice.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                        sqlCmd.Parameters.AddWithValue("@DcY", "Y")
                        sqlCmd.Parameters.AddWithValue("@NowDate", Now.ToString("yyyy-MM-dd"))
                        sqlCmd.Parameters.AddWithValue("@Main_Identity_Id", "2")

                        Using daOP As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            daOP.Fill(dtOrderPrice)
                        End Using

                    End With
                End Using

            End Using

            'Return ds
            Return dtOrderPrice

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' order price資料查詢
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order_Price</remarks>
    Public Function queryOrderPriceByOrderCode(ByVal OrderCode As String) As DataTable

        Dim cmdStrOrderPrice As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------

        'Order_Price
        cmdStrOrderPrice.AppendLine("select * ")
        cmdStrOrderPrice.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrderPrice.Append("where Order_Code = @OrderCode ")
        cmdStrOrderPrice.AppendLine("Order By Main_Identity_Id ")
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
            Dim dtOrderPrice As DataTable = New DataTable(PubOrderPriceDataTableFactory.tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()

                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrderPrice.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)

                        Using daOP As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            daOP.Fill(dtOrderPrice)
                        End Using

                    End With
                End Using

            End Using

            'Return ds
            Return dtOrderPrice

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'select  POP.Insu_Code, POP.Order_Code 
    'from PUB_Order_Price POP 
    '	 left outer join PUB_Insu_Code as PIC on
    '		( POP.Order_Code = PIC.Order_Code ) 
    '		where  
    '		  POP.Effect_Date <= '2010/02/10' and POP.End_Date >= '2010/02/10'
    '		  and POP.Main_Identity_Id ='2' 
    '		  and POP.Order_Code = 'D002363' 
    '		  --and POP.Insu_Code = 'P1404B'
    '		  order by POP.Order_Code 

    '成大馬轉健保碼

    ''' <summary>
    ''' 成大轉健保
    ''' </summary>
    ''' <param name="orderCodes"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order_Price</remarks>
    Public Function transOrderToInsuCode(ByVal orderCodes() As String) As DataTable

        Dim systemDate As Date = DateUtil.getSystemDate

        If orderCodes IsNot Nothing AndAlso orderCodes.Length > 0 Then
            Dim orderStr As New StringBuilder
            For i As Integer = 0 To (orderCodes.Length - 1)
                orderStr.Append("'").Append(orderCodes(i)).Append("',")
            Next
            If orderStr.Length > 0 Then
                orderStr.Remove(orderStr.Length - 1, 1)
            End If

            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select  POP.Insu_Code, POP.Order_Code  ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("from PUB_Order_Price POP  ")
            cmdStr.AppendLine("left outer join PUB_Insu_Code as PIC on ( POP.Order_Code = PIC.Order_Code ) ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("where POP.Effect_Date <= '").Append(systemDate.ToString("yyyy/MM/dd")).Append("' and POP.End_Date >= '").Append(systemDate.ToString("yyyy/MM/dd")).AppendLine("' ")
            cmdStr.AppendLine("and POP.Main_Identity_Id ='2'  ")
            cmdStr.Append("and POP.Order_Code in (").Append(orderStr.ToString).AppendLine(") ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            '----------------------------------------------------------------------------
            Try
                Dim dt As DataTable = New DataTable(PubOrderPriceDataTableFactory.tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()

                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            'sqlCmd.Parameters.AddWithValue("@Insu_Code", insuCode)

                            Using daOP As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                                daOP.Fill(dt)
                            End Using

                        End With
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
    ''' 健保碼轉成大
    ''' </summary>
    ''' <param name="insuCodes"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order_Price</remarks>
    Public Function transInsuToOrderCode(ByVal insuCodes() As String) As DataTable

        Dim systemDate As Date = DateUtil.getSystemDate

        If insuCodes IsNot Nothing AndAlso insuCodes.Length > 0 Then
            Dim insuStr As New StringBuilder
            For i As Integer = 0 To (insuCodes.Length - 1)
                insuStr.Append("'").Append(insuCodes(i)).Append("',")
            Next
            If insuStr.Length > 0 Then
                insuStr.Remove(insuStr.Length - 1, 1)
            End If

            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select  POP.Insu_Code, POP.Order_Code  ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("from PUB_Order_Price POP  ")
            cmdStr.AppendLine("left outer join PUB_Insu_Code as PIC on ( POP.Order_Code = PIC.Order_Code ) ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("where POP.Effect_Date <= '").Append(systemDate.ToString("yyyy/MM/dd")).Append("' and POP.End_Date >= '").Append(systemDate.ToString("yyyy/MM/dd")).AppendLine("' ")
            cmdStr.AppendLine("and POP.Main_Identity_Id ='2'  ")
            cmdStr.Append("and POP.Insu_Code in (").Append(insuStr.ToString).AppendLine(") ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            '----------------------------------------------------------------------------
            Try
                Dim dt As DataTable = New DataTable(PubOrderPriceDataTableFactory.tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()

                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            'sqlCmd.Parameters.AddWithValue("@Insu_Code", insuCode)

                            Using daOP As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                                daOP.Fill(dt)
                            End Using

                        End With
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

    Public Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As DataSet

        Dim sqlStr As String
        Dim returnDS As New DataSet
        Dim tableName1 = "OrderPrice"

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
                    _dataAdapter.Fill(returnDS, tableName1)
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

    Public Function queryOrderPriceData(ByVal EffectDate As String, ByVal EffectDateSymbol As String, ByVal OrderCode As String, ByVal MainIdentityId As String, ByVal Dc As String) As DataTable

        Dim cmdStrOrder As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrOrder.AppendLine("select * ")
        cmdStrOrder.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrder.AppendLine("where 1=1 ")

        If EffectDate <> "" Then
            cmdStrOrder.AppendLine("And Effect_Date " & EffectDateSymbol & " @EffectDate ")
        End If

        If OrderCode <> "" Then
            cmdStrOrder.AppendLine("And Order_Code = @OrderCode ")
        End If

        If MainIdentityId <> "" Then
            cmdStrOrder.AppendLine("And Main_Identity_Id = @MainIdentityId ")
        End If

        If Dc <> "" Then
            cmdStrOrder.AppendLine("And Dc = @Dc ")
        End If

        cmdStrOrder.AppendLine("Order By Effect_Date Desc,Order_Code,Main_Identity_Id ")


        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrder.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                        sqlCmd.Parameters.AddWithValue("@EffectDate", EffectDate)
                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                        sqlCmd.Parameters.AddWithValue("@MainIdentityId", MainIdentityId)
                        sqlCmd.Parameters.AddWithValue("@Dc", Dc)

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

    Public Function DeletePUBOrderPriceByEffectDateAndDc(ByVal EffectDate As String, ByVal OrderCode As String, ByVal MainIdentityId As String) As Integer

        Dim conn As IDbConnection = getConnection()

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "Delete From " & tableName & " " & _
                                      "Where  Effect_Date>=@Effect_Date and Order_Code=@Order_Code and Main_Identity_Id=@Main_Identity_Id "

            conn.Open()


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Effect_Date", EffectDate)
                command.Parameters.AddWithValue("@Order_Code", OrderCode)
                command.Parameters.AddWithValue("@Main_Identity_Id", MainIdentityId)

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

    Public Function updatePUBOrderPriceEndDateAndDc(ByVal EffectDate As String, ByVal OrderCode As String, ByVal MainIdentityId As String, _
                                                    ByVal EndDate As String, ByVal Dc As String, ByVal ModifyUser As String) As Integer

        Dim conn As IDbConnection = getConnection()

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " End_Date=@End_Date , Dc=@Dc , Modified_User=@Modified_User, Modified_Time=@Modified_Time " & _
            " where  Effect_Date=@Effect_Date and Order_Code=@Order_Code And Main_Identity_Id=@Main_Identity_Id "

            conn.Open()


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Effect_Date", EffectDate)
                command.Parameters.AddWithValue("@Order_Code", OrderCode)
                command.Parameters.AddWithValue("@Main_Identity_Id", MainIdentityId)
                command.Parameters.AddWithValue("@End_Date", EndDate)
                command.Parameters.AddWithValue("@Dc", Dc)
                command.Parameters.AddWithValue("@Modified_User", ModifyUser)
                command.Parameters.AddWithValue("@Modified_Time", currentTime)
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

    'Public Function DeletePUBOrderPriceByEffectDateAndDc(ByVal EffectDate As String, ByVal OrderCode As String, ByVal MainIdentityId As String, ByVal Dc As String) As Integer

    '    Dim conn As IDbConnection = getConnection()

    '    Try
    '        Dim currentTime = Now
    '        Dim count As Integer = 0
    '        Dim sqlString As String = "Delete From " & tableName & " " & _
    '                                  "Where  Effect_Date>@Effect_Date and Order_Code=@Order_Code and " & _
    '                                  "       Main_Identity_Id=@MainIdentityId "


    '        If Dc <> "" Then
    '            sqlString &= " And DC='" & Dc & "' "
    '        End If

    '        conn.Open()


    '        Using command As SqlCommand = New SqlCommand
    '            With command
    '                .CommandText = sqlString
    '                .CommandType = CommandType.Text
    '                .Connection = CType(conn, SqlConnection)
    '            End With
    '            command.Parameters.AddWithValue("@Order_Code", OrderCode)
    '            command.Parameters.AddWithValue("@Effect_Date", EffectDate)
    '            command.Parameters.AddWithValue("@Main_Identity_Id", MainIdentityId)
    '            Dim cnt As Integer = command.ExecuteNonQuery
    '            count = count + cnt
    '        End Using

    '        Return count
    '    Catch sqlex As SqlException
    '        Throw sqlex
    '    Catch ex As Exception
    '        Throw New CommonException("CMMCMMD003", ex)
    '    Finally
    '        conn.Close()
    '        conn.Dispose()
    '        conn = Nothing
    '    End Try
    'End Function

    ''' <summary>
    '''刪除醫令所有記錄資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function DeletePUBOrderPriceByOrderCode(ByVal OrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "Delete From PUB_Order_Price " & _
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

End Class
