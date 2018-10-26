Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBDepartmentBO_E1
    Inherits PUBDepartmentBO

    
#Region "########## getInstance ##########"

    Private Shared instance As PUBDepartmentBO_E1

    Public Overloads Shared Function getInstance() As PUBDepartmentBO_E1
        If instance Is Nothing Then
            instance = New PUBDepartmentBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    '取得所有大分科
    Public Overloads Function queryPUBDepartmentAll_B(Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet
        Try
            Dim ds As DataSet
            If conn Is Nothing Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   Select Dept_Code,Dept_Name,Dept_En_Name,Short_Name," & _
                                  "          Health_Opd_Dept_Code,Health_Ipd_Dept_Code,Effect_Date,End_Date,Belong_Dept_Code " & _
                                    " From  " & tableName & " " & _
                                    " Where  Is_Reg_Dept='Y' And (  DC<>'Y' Or  DC Is null) And Belong_Dept_Code is not null And Dept_Code=Belong_Dept_Code " & _
                                    " Order By Sort_Value ,Dept_Code   "

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

    '取得所有細分科
    Public Overloads Function queryPUBDepartmentAll_D(Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet 'Implements IPUBDepartmentBO.queryPUBDepartmentAll_D

        Dim cmdStr As New StringBuilder
        If conn Is Nothing Then
            conn = getConnection()
        End If
        Try
            'SQL
            'cmdStr.AppendLine("select ")
            'cmdStr.AppendLine("rtrim(Dept_Code) as Dept_Code,")
            'cmdStr.AppendLine("rtrim(Dept_Name) as Dept_Name,")
            'cmdStr.AppendLine("rtrim(Dept_En_Name) as Dept_En_Name,")
            'cmdStr.AppendLine("Short_Name,")
            'cmdStr.AppendLine("NHI_Opd_Dept_Code,NHI_Ipd_Dept_Code,Effect_Date,End_Date,Belong_Dept_Code")
            'cmdStr.AppendLine("from " & tableName)
            'cmdStr.AppendLine("where 1=1")
            'cmdStr.AppendLine("and DC <> 'Y'")
            'cmdStr.AppendLine("and Is_Reg_Dept = 'Y'")
            'cmdStr.AppendLine("and Belong_Dept_Code is not Null")
            'cmdStr.AppendLine("Order By Sort_Value ,Dept_Code   ")

            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT DISTINCT Rtrim(A.Dept_Code)    AS Dept_Code, " & vbCrLf)
            varname1.Append("                Rtrim(A.Dept_Name)    AS Dept_Name, " & vbCrLf)
            varname1.Append("                Rtrim(A.Dept_En_Name) AS Dept_En_Name, " & vbCrLf)
            varname1.Append("                A.Short_Name, " & vbCrLf)
            varname1.Append("                A.NHI_Opd_Dept_Code, " & vbCrLf)
            varname1.Append("                A.NHI_Ipd_Dept_Code, " & vbCrLf)
            varname1.Append("                A.Effect_Date, " & vbCrLf)
            varname1.Append("                A.End_Date, " & vbCrLf)
            varname1.Append("                A.Belong_Dept_Code, " & vbCrLf)
            varname1.Append("                B.Dept_Code           AS Dept_Code2 " & vbCrLf)
            varname1.Append("FROM   PUB_Department A " & vbCrLf)
            varname1.Append("       LEFT JOIN PUB_Dept_Sect B " & vbCrLf)
            varname1.Append("              ON A.Dept_Code = B.Dept_Code " & vbCrLf)
            varname1.Append("                 AND B.Dc <> 'Y' " & vbCrLf)
            varname1.Append("WHERE  1 = 1 " & vbCrLf)
            varname1.Append("       AND A.DC <> 'Y' " & vbCrLf)
            varname1.Append("       AND A.Is_Reg_Dept = 'Y' " & vbCrLf)
            varname1.Append("       AND A.Belong_Dept_Code IS NOT NULL " & vbCrLf)
            varname1.Append("ORDER  BY Dept_Code, " & vbCrLf)
            varname1.Append("          Dept_Name, " & vbCrLf)
            varname1.Append("          Dept_En_Name, " & vbCrLf)
            varname1.Append("          A.Short_Name, " & vbCrLf)
            varname1.Append("          A.NHI_Opd_Dept_Code, " & vbCrLf)
            varname1.Append("          A.NHI_Ipd_Dept_Code, " & vbCrLf)
            varname1.Append("          A.Effect_Date, " & vbCrLf)
            varname1.Append("          End_Date, " & vbCrLf)
            varname1.Append("          A.Belong_Dept_Code, " & vbCrLf)
            varname1.Append("          Dept_Code2")

            Try

                Using Command As SqlCommand = conn.CreateCommand

                    Command.CommandText = varname1.ToString

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                        Using ds As DataSet = New DataSet
                            adapter.Fill(ds, "table0")
                            Return ds
                        End Using
                    End Using
                End Using

            Catch ex As Exception
                Throw ex
            End Try

            '執行SQL
            'Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select2", Nothing, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Overloads Function queryPUBDepartmentAll_D2(ByVal SourceType As String) As System.Data.DataSet

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
            
            cmdStr.AppendLine(", Short_Name, NHI_Opd_Dept_Code, NHI_Ipd_Dept_Code, Effect_Date, End_Date, Belong_Dept_Code" & _
                          " FROM " & tableName & " WITH(NOLOCK)" & _
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

            '執行SQL
            'Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select2", Nothing)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "2009/11/06, 取得科別的代碼與名稱 Add By Jen"

    ''' <summary>
    ''' 程式說明：取得科別Code, Name
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.06
    ''' </summary>
    ''' <returns>Dept_Code, Dept_Name</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.Jen-PUB_Department
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/06, XXX
    ''' </修改註記>
    Public Function queryDepartmentCodeAndName() As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select  Dept_Code, Dept_Name, Dept_En_Name ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where DC <> @DcY  and Is_Reg_Dept = 'Y' ")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("Order by Dept_Code ")
        '----------------------------------------------------------------------------
        Try
            Dim dt As DataTable = New DataTable(tableName)
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@DcY", "Y")

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
    End Function

#End Region


    '根據Key值取得細分科
    Public Overloads Function queryPUBDepartmentByKey(ByVal deptCode As String) As System.Data.DataSet
        Try
            Using sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Using command As SqlCommand = sqlConn.CreateCommand()

                    command.CommandText = "SELECT Dept_Code, Dept_Name, Dept_En_Name, Short_Name" & _
                                               ", Health_Opd_Dept_Code, Health_Ipd_Dept_Code, Effect_Date, End_Date, Belong_Dept_Code" & _
                                           " FROM " & tableName & " WITH(NOLOCK)" & _
                                          " WHERE Dept_Code = @deptCode" & _
                                            " AND Is_Reg_Dept = 'Y'" & _
                                            " AND DC = 'N'" & _
                                            " AND Belong_Dept_Code IS NOT NULL" & _
                                            " AND Belong_Dept_Code <>'' " & _
                                          " ORDER BY Dept_Code"

                    command.Parameters.AddWithValue("@deptCode", deptCode)

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        Using ds As DataSet = New DataSet(tableName)
                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            adapter.Fill(ds, tableName)

                            Return ds
                        End Using
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Private Function getConnection() As IDbConnection
    '    Return SQLConnFactory.getInstance.getPubDBSqlConn
    'End Function




#Region "20090608 科室維護檔, add by LingAn Ming"
    '查詢科室資料
    Public Overloads Function queryPUBDepartmentByCond(ByVal DeptCode As String, ByVal DeptName As String, ByVal DeptEnName As String) As System.Data.DataSet 'Implements IPUBDepartmentBO.queryPUBDepartmentByCond
        Dim ds As Data.DataSet
        Dim cmdQueryStr As String = ""

        cmdQueryStr = "   Select Dept_Code,Dept_Name,Dept_En_Name,Short_Name," & _
                                  "          Health_Opd_Dept_Code,Health_Ipd_Dept_Code,Effect_Date,End_Date,Belong_Dept_Code,DC " & _
                                    " From  " & tableName & " " & _
                                    " Where 1=1 "
        If DeptCode.Trim <> "" Then
            cmdQueryStr = cmdQueryStr + " AND Dept_Code = '" & DeptCode & "' "
        End If
        If DeptName.Trim <> "" Then
            cmdQueryStr = cmdQueryStr + " AND Dept_Name like '" & DeptName & "%' "
        End If
        If DeptEnName.Trim <> "" Then
            cmdQueryStr = cmdQueryStr + " AND Dept_En_Name like '" & DeptEnName & "%' "
        End If
        cmdQueryStr = cmdQueryStr + " Order By Dept_Code"
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdQueryStr, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception

            Throw ex
        End Try
        Return ds
    End Function
    '新增科室資料
    Public Overloads Function insertPUBDepartment(ByVal ds As DataSet) As Integer 'Implements IPUBDepartmentBO.insertPUBDepartment
        Dim count As Integer = 0
        Try
            Dim insertSql As String = "insert into " & tableName & " " & _
                                  " (Dept_Code,Dept_Name,Dept_En_Name,Short_Name,Health_Opd_Dept_Code,Health_Ipd_Dept_Code,Effect_Date,End_Date,Belong_Dept_Code,DC,Create_User,Create_Time,Modified_User,Modified_Time,Acc_Dept) " & _
                                  " values(@Dept_Code,@Dept_Name,@Dept_En_Name,@Short_Name, @Health_Opd_Dept_Code,@Health_Ipd_Dept_Code,@Effect_Date,@End_Date,@Belong_Dept_Code,@DC,@Create_User, @Create_Time,@Modified_User,@Modified_Time,@Acc_Dept) "


            Using conn As System.Data.IDbConnection = getConnection()
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = insertSql
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    For Each row As DataRow In ds.Tables(0).Rows
                        command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        command.Parameters.AddWithValue("@Dept_Name", row.Item("Dept_Name"))
                        command.Parameters.AddWithValue("@Dept_En_Name", row.Item("Dept_En_Name"))
                        command.Parameters.AddWithValue("@Short_Name", row.Item("Short_Name"))
                        command.Parameters.AddWithValue("@Health_Opd_Dept_Code", row.Item("Health_Opd_Dept_Code"))
                        command.Parameters.AddWithValue("@Health_Ipd_Dept_Code", row.Item("Health_Ipd_Dept_Code"))
                        command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        command.Parameters.AddWithValue("@Belong_Dept_Code", row.Item("Belong_Dept_Code"))
                        command.Parameters.AddWithValue("@DC", row.Item("DC"))
                        command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        command.Parameters.AddWithValue("@Create_Time", Now)
                        command.Parameters.AddWithValue("@Modified_User", row.Item("Create_User"))
                        command.Parameters.AddWithValue("@Modified_Time", Now)
                        '承毅
                        command.Parameters.AddWithValue("@Acc_Dept", row.Item("Acc_Dept"))
                    Next
                    conn.Open()
                    count = command.ExecuteNonQuery

                    '20090612 Modify By James :Start
                    If count = 1 Then
                        '資料有異動(insert,update,delete)成功後需呼叫備份機制Method
                        '傳入參數說明 -changeFlag(異動狀態-A:新增，U:修改，D:刪除)
                        '             -changeData:該ds須包含DB上該Table所有column
                        '備註:執行Delete, ds不可只有Key值欄位資料,須傳入所有欄位值
                        Return PUBDelegate.getInstance.insertPUBBackupTemp("A", ds)
                    End If
                    '20090612 Modify By James :End

                End Using
            End Using

            Return 0
            ' Return count
        Catch ex As Exception
            Return 0
            Throw ex
        End Try
    End Function
    '刪除科室資料
    Public Overloads Function deletePUBDepartment(ByVal DeptCode As String) As Integer 'Implements IPUBDepartmentBO.deletePUBDepartment
        Dim cmdDelStr As String = ""
        Dim flag As Integer
        cmdDelStr = "delete from " & tableName & " where Dept_Code='" & DeptCode & "'"
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim cmdAdd As New SqlCommand(cmdDelStr, sqlConnection)
                sqlConnection.Open()
                flag = cmdAdd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return flag
    End Function
    '修改科室資料
    Public Overloads Function updatePUBDepartment(ByVal ds As Data.DataSet) As Integer 'Implements IPUBDepartmentBO.updatePUBDepartment
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Dept_Name=@Dept_Name , Dept_En_Name=@Dept_En_Name ,Short_Name=@Short_Name ,Health_Opd_Dept_Code=@Health_Opd_Dept_Code, Health_Ipd_Dept_Code=@Health_Ipd_Dept_Code,Effect_Date=@Effect_Date,End_Date=@End_Date,Belong_Dept_Code=@Belong_Dept_Code,DC=@DC," & _
            " Modified_User=@Modified_User , Modified_Time=@Modified_Time , Acc_Dept=@Acc_Dept" & _
            " where  Dept_Code=@Dept_Code "
            Using conn As System.Data.IDbConnection = getConnection()
                conn.Open()
                For Each row As DataRow In ds.Tables(0).Rows
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = sqlString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With
                        command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        command.Parameters.AddWithValue("@Dept_Name", row.Item("Dept_Name"))
                        command.Parameters.AddWithValue("@Dept_En_Name", row.Item("Dept_En_Name"))
                        command.Parameters.AddWithValue("@Short_Name", row.Item("Short_Name"))
                        command.Parameters.AddWithValue("@Health_Opd_Dept_Code", row.Item("Health_Opd_Dept_Code"))
                        command.Parameters.AddWithValue("@Health_Ipd_Dept_Code", row.Item("Health_Ipd_Dept_Code"))
                        command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        command.Parameters.AddWithValue("@Belong_Dept_Code", row.Item("Belong_Dept_Code"))
                        command.Parameters.AddWithValue("@DC", row.Item("DC"))
                        command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        command.Parameters.AddWithValue("@Modified_Time", Now)
                        '承毅
                        command.Parameters.AddWithValue("@Acc_Dept", row.Item("Acc_Dept"))
                        Dim cnt As Integer = command.ExecuteNonQuery
                        count = count + cnt
                    End Using
                Next
            End Using
            Return count
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "20090707 added by Ken"
    ''' <summary>
    ''' 取得小分科 (k)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentBySmallDept() As DataSet
        Dim _ds As New DataSet

        Dim _date As Date = Date.Now

        Dim var1 As New System.Text.StringBuilder
        var1.AppendFormat("SELECT Rtrim(Dept_Code), " & vbCrLf)
        var1.AppendFormat("       Dept_Name " & vbCrLf)
        var1.AppendFormat("FROM   PUB_Department " & vbCrLf)
        var1.AppendFormat("WHERE  Is_Reg_Dept='Y'  " & vbCrLf)
        var1.AppendFormat("       AND (DC <> 'Y' " & vbCrLf)
        var1.AppendFormat("             OR DC IS NULL) " & vbCrLf)
        var1.AppendFormat("       AND Effect_Date <= '{0}' " & vbCrLf, _date.ToShortDateString)
        var1.AppendFormat("       AND (End_Date >= '{0}' " & vbCrLf, _date.ToShortDateString)
        var1.AppendFormat("             OR End_Date IS NULL) " & vbCrLf)

        Try
            Using _sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(var1.ToString, _sqlConnection)
                _dataAdapter.Fill(_ds, "PUB_Department")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    '依來源別(O,E,I)取得小分科
    Public Function queryPUBDepartmentBySourceType(ByVal inSourceType As String) As DataSet
        Dim _ds As New DataSet

        Dim _date As Date = Date.Now

        Dim var1 As New System.Text.StringBuilder
        var1.AppendFormat("SELECT Rtrim(Dept_Code), " & vbCrLf)
        Select Case inSourceType
            Case "O"
                var1.AppendFormat("       Dept_Name " & vbCrLf)
            Case "E"
                var1.AppendFormat("       Emg_Dept_Name " & vbCrLf)
            Case "I"
                var1.AppendFormat("       Ipd_Dept_Name " & vbCrLf)
        End Select

        var1.AppendFormat("FROM   PUB_Department " & vbCrLf)
        var1.AppendFormat("WHERE  Is_Reg_Dept='Y'  " & vbCrLf)
        var1.AppendFormat("       AND (DC <> 'Y' " & vbCrLf)
        var1.AppendFormat("             OR DC IS NULL) " & vbCrLf)
        var1.AppendFormat("       AND Effect_Date <= '{0}' " & vbCrLf, _date.ToShortDateString)
        var1.AppendFormat("       AND (End_Date >= '{0}' " & vbCrLf, _date.ToShortDateString)
        var1.AppendFormat("             OR End_Date IS NULL) " & vbCrLf)

        Select Case inSourceType
            Case "O"
                var1.AppendFormat(" Order By Sort_Value,Dept_Code")
            Case "E"
                var1.AppendFormat("  AND  Is_Emg_Dept ='Y' " & vbCrLf)
                var1.AppendFormat(" Order By Emg_Sort_Value,Dept_Code")
            Case "I"
                var1.AppendFormat("  AND  Is_Ipd_Dept ='Y' " & vbCrLf)
                var1.AppendFormat(" Order By Ipd_Sort_Value,Dept_Code")
        End Select

        Try
            Using _sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(var1.ToString, _sqlConnection)
                _dataAdapter.Fill(_ds, "PUB_Department")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 取得所有科室代碼與名稱(不分大小分科)(k)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentAllDept() As DataSet
        Dim _ds As New DataSet

        Dim _date As Date = Date.Now

        Dim var1 As New System.Text.StringBuilder
        var1.AppendFormat("SELECT Rtrim(Dept_Code) AS Dept_Code, " & vbCrLf)
        var1.AppendFormat("       Dept_Name " & vbCrLf)
        var1.AppendFormat("FROM   PUB_Department " & vbCrLf)
        var1.AppendFormat("WHERE  (DC <> 'Y' " & vbCrLf)
        var1.AppendFormat("           OR DC IS NULL) " & vbCrLf)
        var1.AppendFormat("       AND Effect_Date <= '{0}' " & vbCrLf, _date.ToShortDateString)
        var1.AppendFormat("       AND (End_Date >= '{0}' " & vbCrLf, _date.ToShortDateString)
        var1.AppendFormat("             OR End_Date IS NULL) " & vbCrLf)

        Try
            Using _sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(var1.ToString, _sqlConnection)
                _dataAdapter.Fill(_ds, "PUB_Department")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function
#End Region

#Region "2009/08/11, Add By 谷官, ComboBox的Data Source"

    ''' <summary>
    ''' 程式說明：取得就醫科別ComboBox的Data Source
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.11
    ''' </summary>
    ''' <returns>Dept_Code, Dept_Name</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.Nick-PUB_Department
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/07/22, XXX
    ''' </修改註記>
    Public Function getComboBoxValueTable(Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Dim cmdStr As New StringBuilder
        If conn Is Nothing Then
            conn = getConnection()
        End If
        Try
            'SQL
            cmdStr.AppendLine("select")
            cmdStr.AppendLine("rtrim(Dept_Code) as Dept_Code,")
            cmdStr.AppendLine("rtrim(Dept_Name) as Dept_Name,")
            cmdStr.AppendLine("rtrim(NHI_Opd_Dept_Code) as Health_Opd_Dept_Code,")
            cmdStr.AppendLine("rtrim(NHI_Ipd_Dept_Code) as Health_Ipd_Dept_Code")
            cmdStr.AppendLine("from PUB_Department")
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("and DC <> 'Y'")
            cmdStr.AppendLine("Order by Dept_Code")


            Try

                Using Command As SqlCommand = conn.CreateCommand

                    Command.CommandText = cmdStr.ToString

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                        Using ds As DataSet = New DataSet
                            adapter.Fill(ds, "PUB_Department")
                            Return ds.Tables(0)
                        End Using
                    End Using

                End Using
            Catch ex As Exception
                Throw ex
            End Try

            '執行SQL
            'Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select1", Nothing, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    ''' <summary>
    '''以Dept_Code查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByDeptCodeOnly(ByRef DeptCode As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = _
            " Select * " & _
            " From PUB_Department " & _
            " Where Dept_Code=@Dept_Code and DC=@DC "
            command.Parameters.AddWithValue("@Dept_Code", DeptCode)
            command.Parameters.AddWithValue("@DC", "N")
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
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：取得就醫科別ComboBox的Data Source
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.11
    ''' </summary>
    ''' <returns>Dept_Code, Dept_Name</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.Nick-PUB_Department
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/07/22, XXX
    ''' 2.2016/1/20,health_Opd_Dept_Code-->NHI_Opd_Dept_Code ,health_Ipd_Dept_Code-->NHI_Ipd_Dept_Code
    ''' </修改註記>
    Public Function getMMRChartLendCboDeptValue(Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Dim cmdStr As New StringBuilder

        Try
            'SQL
            cmdStr.AppendLine("select")
            cmdStr.AppendLine("rtrim(Dept_Code) as Dept_Code,")
            cmdStr.AppendLine("rtrim(Dept_Name) as Dept_Name,")
            cmdStr.AppendLine("rtrim(NHI_Opd_Dept_Code) as NHI_Opd_Dept_Code,")
            cmdStr.AppendLine("rtrim(NHI_Ipd_Dept_Code) as NHI_Ipd_Dept_Code")
            cmdStr.AppendLine("from PUB_Department")
            cmdStr.AppendLine("where 1=1 and LEN(Rtrim(Dept_Code)) = 4")
            cmdStr.AppendLine("and DC <> 'Y'")
            cmdStr.AppendLine("Order by Dept_Code")

            '執行SQL
            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select1", Nothing, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getDepSect(ByVal DeptCode As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try
            Dim ds As DataSet
            If conn Is Nothing Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select Section_Id,Section_Name " & _
                                  " From  PUB_Dept_Sect " & _
                                  " Where Dept_Code='" & DeptCode & "' And DC<>'Y' " & _
                                  " Order By Section_Id"

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
    ''' 取出所有急診科別
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getAllEmgDept() As DataTable
        Dim conn As SqlConnection = getConnection()

        Try
            Dim sqlStr As New StringBuilder
            Dim dt As New DataTable
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            sqlStr.AppendLine("select Dept_Code,Emg_Dept_Name from PUB_Department ")
            sqlStr.AppendLine("where Is_Emg_Dept='Y' order by Emg_Sort_Value")
            command.CommandText = sqlStr.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dt = New DataTable("PUB_Department")
                adapter.Fill(dt)
                adapter.FillSchema(dt, SchemaType.Mapped)
            End Using
            Return dt
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try
    End Function

    ''' <summary>
    '''以Belong_Dept_Code查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByBelongDeptCode(ByRef Belong_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  " & tableName & " where Belong_Dept_Code=@Belong_Dept_Code "
            command.Parameters.AddWithValue("@Belong_Dept_Code", Belong_Dept_Code)
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
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#Region " 大分科所屬細分科統計 "

    ''' <summary>
    ''' 大分科所屬細分科統計
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by ChenYu.Guo on 2015-07-15</remarks>
    Public Function queryPUBDepartmentCount(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT Belong_Dept_Code, " & vbCrLf)
            varname1.Append("       Count(Dept_Code)AS DeptCodeCount " & vbCrLf)
            varname1.Append("FROM   PUB_Department " & vbCrLf)
            varname1.Append("WHERE  1 = 1 " & vbCrLf)
            varname1.Append("       AND DC <> 'Y' " & vbCrLf)
            varname1.Append("       AND Is_Reg_Dept = 'Y' " & vbCrLf)
            varname1.Append("       AND Belong_Dept_Code IS NOT NULL " & vbCrLf)
            varname1.Append("       AND Belong_Dept_Code <> '' " & vbCrLf)
            varname1.Append("GROUP  BY Belong_Dept_Code ")

            command.CommandText = varname1.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SQLException
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

