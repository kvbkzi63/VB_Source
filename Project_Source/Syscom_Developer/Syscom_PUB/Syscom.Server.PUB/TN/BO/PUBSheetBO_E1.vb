Imports System.Data.SqlClient

Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
'
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP

Public Class PUBSheetBO_E1
    Inherits PubSheetBO

    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

#Region "########## getInstance ##########"

    Private Shared instance As PUBSheetBO_E1

    Public Overloads Shared Function getInstance() As PUBSheetBO_E1
        If instance Is Nothing Then
            instance = New PUBSheetBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 程式說明：取得所有表單
    ''' 開發人員：James
    ''' 開發日期：2009.10.20
    ''' </summary>
    ''' <returns>DataSet表單</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.PUB_Sheet
    ''' </使用表單>
    ''' <修改註記>
    ''' 
    ''' </修改註記>
    Public Function queryPUBSheet(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection
            If connFlag Then
                sqlConn = CType(getConnection(), SqlConnection)
            Else
                sqlConn = conn
            End If
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select * " & _
                                  "From  PUB_Sheet A " & _
                                  "Where   A.DC<>'Y'   " & _
                                  "Order by A.Dept_Code "

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
    ''' 程式說明：取得科室
    ''' 開發人員：Alan
    ''' 開發日期：2009.09.02
    ''' </summary>
    ''' <returns>DataSet-科室</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.PUB_Sheet,PUB_Department
    ''' </使用表單>
    ''' <修改註記>
    ''' 
    ''' </修改註記>
    Public Function queryPUBSheetDeptData() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select distinct A.Dept_Code ,B.Dept_Name " & _
                                  "From  PUB_Sheet A,PUB_Department B " & _
                                  "Where  1=1 And " & _
                                  "       A.DC<>'Y'  And " & _
                                  "       B.Dept_Code=A.Dept_Code " & _
                                  "Order by A.Dept_Code "

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
    ''' 程式說明：取得所有科別與表單
    ''' 開發人員：Alan
    ''' 開發日期：2009.09.02
    ''' </summary>
    ''' <returns>DataSet表單</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.PUB_Sheet,PUB_Department
    ''' </使用表單>
    ''' <修改註記>
    ''' 
    ''' </修改註記>
    Public Function queryPUBSheetDeptSheetData() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select distinct A.Dept_Code ,B.Dept_Name,A.Sheet_Code,A.Sheet_Name,C.Specimen_Id,C.Vessel_Id " & _
                                  "From  PUB_Sheet A LEFT JOIN PUB_Sheet_Specimen C ON C.Sheet_Code=A.Sheet_Code ,PUB_Department B " & _
                                  "Where  1=1 And " & _
                                  "       A.DC<>'Y'  And " & _
                                  "       B.Dept_Code=A.Dept_Code  " & _
                                  "Order by A.Dept_Code,A.Sheet_Code,C.Specimen_Id,C.Vessel_Id "


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
    ''' 程式說明：依科別取得表單
    ''' 開發人員：Alan
    ''' 開發日期：2009.09.02
    ''' </summary>
    ''' <returns>DataSet表單</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.PUB_Sheet
    ''' </使用表單>
    ''' <修改註記>
    ''' 
    ''' </修改註記>
    Public Function queryPUBSheetSheetData(ByVal DeptCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtSqlStr As String

            If DeptCode <> "" Then
                pvtSqlStr = " And A.Dept_Code='" & DeptCode & "' "
            Else
                pvtSqlStr = ""
            End If

            command.CommandText = "Select A.Sheet_Code ,A.Sheet_Name,B.Specimen_Id,B.Vessel_Id " & _
                                  "From  PUB_Sheet A Left Join PUB_Sheet_Specimen B  ON B.Sheet_Code=A.Sheet_Code " & _
                                  "Where  1=1 And " & pvtSqlStr & " And " & _
                                  "       A.DC<>'Y'  " & _
                                  "Order by A.Sheet_Code,B.Specimen_Id,B.Vessel_Id "

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
    ''' 依科室代碼查詢表單代碼 (已trim掉空白)
    ''' </summary>
    ''' <param name="DeptCode">科室代碼</param>
    ''' <returns>查詢結果</returns>
    ''' <remarks>
    ''' Sheet_Type_Id = '2' (2010/6/1後不判斷)
    ''' For 排程用
    ''' </remarks>
    Public Function querySheetCodeByDeptCode(ByVal DeptCode As String) As DataSet
        'Dim var1 As New System.Text.StringBuilder
        'var1.Append("SELECT RTRIM(Sheet_Code) AS Sheet_Code, " & vbCrLf)
        'var1.Append("       Sheet_Name, " & vbCrLf)
        'var1.Append("       RTRIM(Dept_Code) AS Dept_Code " & vbCrLf)
        'var1.Append("FROM   PUB_Sheet " & vbCrLf)
        'var1.Append("WHERE  (Dc = 'N' " & vbCrLf)
        'var1.Append("         OR Dc IS NULL) " & vbCrLf)
        'If DeptCode IsNot Nothing Then
        '    var1.Append("       AND Dept_Code = @Dept_Code " & vbCrLf)
        'End If

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT DISTINCT RTRIM(A.Sheet_Code) AS Sheet_Code, " & vbCrLf)
        var1.Append("                A.Sheet_Name, " & vbCrLf)
        var1.Append("                RTRIM(A.Dept_Code)  AS Dept_Code " & vbCrLf)
        var1.Append("FROM   PUB_Sheet A " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Sheet_Detail B " & vbCrLf)
        var1.Append("         ON A.Sheet_Code = B.Sheet_Code " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Order_Examination C " & vbCrLf)
        var1.Append("         ON B.Order_Code = C.Order_Code " & vbCrLf)
        var1.Append("WHERE  ( A.Dc = 'N' " & vbCrLf)
        var1.Append("          OR A.Dc IS NULL ) " & vbCrLf)
        If DeptCode IsNot Nothing Then
            var1.Append("       AND A.Dept_Code = @Dept_Code " & vbCrLf)
        End If
        var1.Append("       AND ( B.Dc = 'N' " & vbCrLf)
        var1.Append("              OR B.Dc IS NULL ) " & vbCrLf)
        var1.Append("       AND C.Is_Scheduled = 'Y' " & vbCrLf)


        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Dept_Code", IIf(IsNothing(DeptCode), String.Empty, DeptCode))

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, tableName)
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 程式說明：表單代碼下拉選單與資訊
    ''' 開發人員：Jen
    ''' 開發日期：2009.12.07
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Sheet
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/12/07, XXX
    ''' </修改註記>
    Public Function querySheetData() As DataTable

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
        cmdStr.AppendLine("where Sheet_Type_Id = @Sheet_Type_Id ")
        cmdStr.AppendLine("and Dc <> @DcY ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("Order By Sheet_Code ")
        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@Sheet_Type_Id", "2")
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

    ''' <summary>
    ''' 以Sheet_Type_Id查詢符合之Sheet Code
    ''' </summary>
    ''' <returns></returns>
    ''' <author>Ken</author>
    ''' <date>2009-12-15</date>
    ''' <tables>
    ''' PUB_Sheet
    ''' </tables>
    ''' <remarks>For ComboBox用</remarks>
    Public Function QueryWithSheetTypeId1(ByVal SheetTypeId As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(Sheet_Code) AS Sheet_Code, " & vbCrLf)
        var1.Append("       Sheet_Name " & vbCrLf)
        var1.Append("FROM   PUB_Sheet " & vbCrLf)
        var1.Append("WHERE  Sheet_Type_Id = @Sheet_Type_Id " & vbCrLf)
        var1.Append("       AND Dc = 'N' " & vbCrLf)
        var1.Append("ORDER  BY Sheet_Code ")

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Sheet_Type_Id", SheetTypeId)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, tableName)
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 程式說明：取得Pub_Sheet的ComboBox Value For櫃台批價
    ''' 開發人員：谷官
    ''' 開發日期：2010.03.25
    ''' </summary>
    ''' <returns>Pub_Sheet的ComboBox Value For櫃台批價</returns>
    ''' <remarks></remarks>
    Public Function queryPubSheetComboValueForAddMedicalRecord(Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Dim cmdStr As New StringBuilder

        Try
            'SQL
            cmdStr.AppendLine("select")
            cmdStr.AppendLine("rtrim(A.Sheet_Code) as Sheet_Code,")
            cmdStr.AppendLine("rtrim(A.Sheet_Name) as Sheet_Name,")
            cmdStr.AppendLine("rtrim(A.Sheet_Type_Id) as Sheet_Type_Id")
            cmdStr.AppendLine("from PUB_Sheet as A")
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("and A.Dc <> 'Y'")

            '執行SQL
            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select1", New String() {"pubSheetDT"}, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "     以ＰＫ查詢資料 "

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PubSheetQueryByPK(ByVal pk_Sheet_Code As System.String, ByVal pk_Sheet_Name As System.String, ByVal pk_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Sheet_Code , Sheet_Name , Dept_Code , Is_Emergency_Sheet , Is_Indication ,  ")
            content.AppendLine(" Is_Print_Indication , Sheet_Collect_Note , Sheet_Note , Sheet_Type_Id , Lis_Sheet_Limit_Cnt ,  ")
            content.AppendLine(" Sheet_Sort_Value , Dc , Create_User , Create_Time , Modified_User ,  ")
            content.AppendLine(" Modified_Time , Is_Print , Lab_Group_Id , Report_Title , Sheet_Short_Name ,  ")
            content.AppendLine(" Finish_Sign_Hours , Finish_Rpt_Hours , In_Out_Id , Finish_Total_Hours                from " & tableName)
            content.AppendLine("   where Sheet_Code=@Sheet_Code and  Sheet_Name=@Sheet_Name and Dept_Code=@Dept_Code  and Sheet_Type_Id='1'    ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Sheet_Code", pk_Sheet_Code)
            command.Parameters.AddWithValue("@Sheet_Name", pk_Sheet_Name)
            command.Parameters.AddWithValue("@Dept_Code", pk_Dept_Code)
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

#Region "     以ＰＫ Like 的方式查詢資料 "

    ''' <summary>
    '''以ＰＫ Like 的方式查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PubSheetQueryByLikePK(ByVal pk_Sheet_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Sheet_Code , Sheet_Name , Dept_Code , Is_Emergency_Sheet , Is_Indication ,  ")
            content.AppendLine(" Is_Print_Indication , Sheet_Collect_Note , Sheet_Note , Sheet_Type_Id , Lis_Sheet_Limit_Cnt ,  ")
            content.AppendLine(" Sheet_Sort_Value , Dc , Create_User , Create_Time , Modified_User ,  ")
            content.AppendLine(" Modified_Time , Is_Print , Lab_Group_Id , Report_Title , Sheet_Short_Name ,  ")
            content.AppendLine(" Finish_Sign_Hours , Finish_Rpt_Hours , In_Out_Id , Finish_Total_Hours                from " & tableName)
            content.AppendLine("   where Sheet_Code like @Sheet_Code and Sheet_Type_Id='1' ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Sheet_Code", pk_Sheet_Code & "%")

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

    ''' <summary>
    ''' 查詢登入使用者可用的表單類別
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun 2016/10/04 </remarks>
    Public Function queryUserMappingPUBSheet(ByVal currentUser As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection
            If connFlag Then
                sqlConn = CType(getConnection(), SqlConnection)
            Else
                sqlConn = conn
            End If
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "SELECT * FROM  PUB_SHEET A " & _
                                  "JOIN SCH_USER_MAPPING_SHEETS B ON A.SHEET_CODE=B.SHEET_CODE " & _
                                  "WHERE   A.DC<>'Y' AND " & _
                                  "A.SHEET_TYPE_ID='2' AND " & _
                                  "B.EXEC_EMPLOYEE_CODE='" & currentUser & "' " & _
                                  "ORDER BY A.DEPT_CODE "

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
    ''' 查詢登入使用者可用的表單類別
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun 2016/10/04 </remarks>
    Public Function queryUserMappingApparatusCode(ByVal currentUser As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection
            If connFlag Then
                sqlConn = CType(getConnection(), SqlConnection)
            Else
                sqlConn = conn
            End If
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "SELECT C.APPARATUS_CODE,C.APPARATUS_NAME,C.SHEET_CODE FROM  PUB_SHEET A " & _
                                  "JOIN SCH_USER_MAPPING_SHEETS B ON A.SHEET_CODE=B.SHEET_CODE " & _
                                  "INNER JOIN SCH_APPARATUS C ON B.SHEET_CODE=C.SHEET_CODE " & _
                                  "WHERE   A.DC<>'Y' AND " & _
                                  "A.SHEET_TYPE_ID='2' AND " & _
                                  "B.EXEC_EMPLOYEE_CODE='" & currentUser & "' " & _
                                  "ORDER BY A.DEPT_CODE "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class