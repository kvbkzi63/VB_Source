'/*
'*****************************************************************************
'*
'*    Page/Class Name:  合約共用檔
'*              Title:	PUBContractBO_E2
'*        Description:	合約共用檔
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2015-08-31
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2015-08-31
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports System.Text



Public Class PUBContractBO_E2
    Inherits PubContractBO
    Dim tableName1 As String = "PUB_Contract"
    Public Shared ReadOnly tableName2 As String = "PUB_Syscode"
    Public Shared ReadOnly tableName3 As String = "PUB_Sub_Identity"
#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBContractBO_E2
    Public Overloads Shared Function GetInstance() As PUBContractBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBContractBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "20090721 PUBContractBO_E2 合約共用檔維護 by Add Yunfei"
    ''' <summary>
    ''' 獲取PUB_Contract資料
    ''' </summary>
    ''' <param name="strColumnName">表字段對象</param>
    ''' <param name="strColumnValue">字段值對象</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBContractByColumnValue(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select Contract_Code as contract_Code,Contract_Name as contract_Name,(REPLACE(CONVERT(nvarchar,Contract_Code),' ' ,'') + ' - ' + Contract_Name) as code_name_cb  from " & tableName & " where 1=1 ")
            For i = 0 To strColumnName.Length - 1
                If strColumnName(i) = "Sub_Identity_Code" Then
                    content.Append("and (").Append(strColumnName(i)).Append("=@").Append(strColumnName(i)).AppendLine(" or Sub_Identity_Code ='') ")
                Else
                    content.Append("and ").Append(strColumnName(i)).Append("=@").Append(strColumnName(i)).AppendLine(" ")
                End If
            Next
            command.CommandText = content.ToString
            For i = 0 To strColumnName.Length - 1
                command.Parameters.AddWithValue("@" & strColumnName(i), strColumnValue(i))
            Next
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 獲取PUB_Contract資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBContractBySubIdentityCode57or40() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" ").Append("select distinct  Contract_Code as contract_Code,Contract_Name as contract_Name,")
            content.Append(" ").Append("(REPLACE(CONVERT(nvarchar,Contract_Code),' ' ,'') + ' - ' + Contract_Name) as code_name_cb ")
            content.Append(" ").Append("from " & tableName & " where 1=1 ")
            content.Append(" ").Append("and (Sub_Identity_Code = '57' or Sub_Identity_Code ='40') and DC = 'N' ")
            'add by Runxia 20110714 
            content.Append(" ").Append("and Contract_Code not in ('UE','UF','UG','D001') ")
            'For i = 0 To strColumnName.Length - 1
            '    If strColumnName(i) = "Sub_Identity_Code" Then
            '        content.Append("and (").Append(strColumnName(i)).Append("=@").Append(strColumnName(i)).AppendLine(" or Sub_Identity_Code ='') ")
            '    Else
            '        content.Append("and ").Append(strColumnName(i)).Append("=@").Append(strColumnName(i)).AppendLine(" ")
            '    End If
            'Next
            command.CommandText = content.ToString
            'For i = 0 To strColumnName.Length - 1
            '    command.Parameters.AddWithValue("@" & strColumnName(i), strColumnValue(i))
            'Next
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "20090917 PUBContractBO_E2 合約共用檔維護 by Add Pearl"
    ''' <summary>
    ''' 根據身份二代碼獲取機關合約代碼和名稱
    ''' </summary>
    ''' <param name="strSubIdentitycode">身份二代碼</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBContractBySubIdentitycode(ByVal strSubIdentitycode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select Contract_Code as contract_Code,Contract_Name as contract_Name,(REPLACE(CONVERT(nvarchar,Contract_Code),' ' ,'') + ' - ' + Contract_Name) as code_name_cb  from " & tableName & " where 1=1 and Dc ='N' ")
            If Not strSubIdentitycode.Equals("") Then
                content.Append("and ").Append("Sub_Identity_code =@Sub_Identity_code ")
            End If
            content.Append("order by contract_Code")
            command.CommandText = content.ToString
            If Not strSubIdentitycode.Equals("") Then
                command.Parameters.AddWithValue("@Sub_Identity_code", strSubIdentitycode)
            End If
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "20090721 PUBContractBO_E2 合約機構基本檔維護 Add by Merry_Jing"

    ''' <summary>
    ''' 查詢合約機構基本檔
    ''' </summary>
    ''' <param name=" strContractCode">合約機關代碼</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢條件完全匹配</remarks>
    Public Overloads Function queryPUBContractByCond(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("select A.* ,RTRIM(B.Code_Id) + ' - ' + RTRIM(B.Code_Name) as Upper_Name, RTRIM(C.Code_Id) + ' - ' + RTRIM(C.Code_Name) as Check_Quota_Name, RTRIM(D.Sub_Identity_Code) + ' - ' + RTRIM(D.Sub_Identity_Name) as Sub_Identity_Name From ")
        strSql.Append(tableName)
        strSql.Append(" A left join  ").Append(tableName2).Append(" B on (A.Upper_Amt_Type_Id = B.Code_Id and B.Type_Id = '51' and B.DC = 'N')")
        strSql.Append(" left join  ").Append(tableName2).Append(" C on (A.Check_Quota_Id = C.Code_Id and C.Type_Id = '52' and C.DC = 'N')")
        strSql.Append(" left join  ").Append(tableName3).Append(" D on (A.Sub_Identity_Code = D.Sub_Identity_Code and D.DC = 'N')")
        strSql.Append(" Where 1=1 ")
        If strContractCode.Trim <> "" Then
            strSql.Append(" AND A.Contract_Code = '").Append(strContractCode.Trim).Append("' ")
        End If
        If strSubIdentityCode.Trim <> "" Then
            strSql.Append(" AND A.Sub_Identity_Code = '").Append(strSubIdentityCode.Trim).Append("' ")
        End If
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
        Return ds
    End Function
#End Region
#Region "20090721 PUBContractBO_E2 病患合約機構記帳累積檔 Add by tony"


    Public Function queryPUBContractByCheckQuotaIdAndDc(ByVal strCheckQuotaId As String, ByRef strDc As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select A.* from ")
        strSql.Append(" ").Append(tableName1)
        strSql.Append(" ").Append(" A ")
        strSql.Append(" ").Append(" Where 1=1 ")
        strSql.Append(" ").Append(" AND A.Check_Quota_Id = '").Append(strCheckQuotaId.Trim).Append("' ")
        strSql.Append(" ").Append(" AND A.Dc = '").Append(strDc.Trim).Append("' ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region
#Region "20090831 PUBContractBO_E2 役男複檢批價明細 Add by tony"

    '查詢縣市別(合約機關代碼)
    Public Function queryPUBContractCodeBySubIdentityCodeAndDc() As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select C.Contract_Code , C.Contract_Name from ")
        strSql.Append(" ").Append(tableName1)
        strSql.Append(" ").Append(" C ")
        strSql.Append(" ").Append(" Where 1=1 ")
        strSql.Append(" ").Append(" AND C.Sub_Identity_Code = '80' AND C.Dc = 'N'")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region

#Region "20090922 PUBContractBO_E2 合約機構查詢  Add by liuye"
    ''' <summary>
    ''' 獲取合約機構資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBContractsId() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("SELECT  DISTINCT Sub_Identity_Code, Contract_Code, Contract_Name  FROM  PUB_Contract  ")
        strSql.Append(" Where 1=1 and Dc='N' ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region
#Region "20100331 門診健檢套餐報價作業  Add by tony"
    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePubContractMemo(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & " Memo=@Memo,Modified_User=@Modified_User , Modified_Time=@Modified_Time " & " where  Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code            "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim bkDS = New DataSet
            'Mark by Will,Lin
            'Dim bkTable = getDataTableBKWithSchema()
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Contract_Code", row.Item("Contract_Code"))
                    command.Parameters.AddWithValue("@Sub_Identity_Code", row.Item("Sub_Identity_Code"))
                    command.Parameters.AddWithValue("@Memo", row.Item("Memo"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
                Dim bkDS1 As System.Data.DataSet = queryByPK(row.Item("Contract_Code"), row.Item("Sub_Identity_Code"), conn)
                If bkDS1 IsNot Nothing _
                AndAlso bkDS1.Tables.Count > 0 _
                AndAlso bkDS1.Tables(0) IsNot Nothing _
                AndAlso bkDS1.Tables(0).Rows.Count > 0 _
                AndAlso bkDS1.Tables(0).Rows(0) IsNot Nothing _
                Then
                    'Mark by Will,Lin
                    'updateBackupTable(bkDS1.Tables(0).Copy)
                End If
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
    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePubContract(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & " Is_Use_Set=@Is_Use_Set,Modified_User=@Modified_User , Modified_Time=@Modified_Time " & " where  Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code            "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim bkDS = New DataSet
            'Mark by Will,Lin
            'Dim bkTable = getDataTableBKWithSchema()
            For Each row As DataRow In ds.Tables(0).Rows

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Contract_Code", row.Item("Contract_Code"))
                    command.Parameters.AddWithValue("@Sub_Identity_Code", row.Item("Sub_Identity_Code"))
                    command.Parameters.AddWithValue("@Is_Use_Set", row.Item("Is_Use_Set"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
                Dim bkDS1 As System.Data.DataSet = queryByPK(row.Item("Contract_Code"), row.Item("Sub_Identity_Code"), conn)
                If bkDS1 IsNot Nothing _
                AndAlso bkDS1.Tables.Count > 0 _
                AndAlso bkDS1.Tables(0) IsNot Nothing _
                AndAlso bkDS1.Tables(0).Rows.Count > 0 _
                AndAlso bkDS1.Tables(0).Rows(0) IsNot Nothing _
                Then
                    'Mark by Will,Lin
                    'updateBackupTable(bkDS1.Tables(0).Copy)
                End If
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
#Region "20100331 PUBContractBO_E2 合約機構combo  Add by tony"
    ''' <summary>
    ''' 門診健檢套餐報價作業 合約機構combo
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBContractForCombo() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" ").Append("select Contract_Code,Contract_Name ")
        strSql.Append(" ").Append("from PUB_Contract                  ")
        strSql.Append(" ").Append("where Dc='N'                       ")
        strSql.Append(" ").Append("group by Contract_Code,Contract_Name")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
        Return ds
    End Function
#End Region

#Region "20100713  門診健檢套餐報價作業-產生報價單 Add by Tima_Qin"
    Public Function queryPUBContractForExcel(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As New StringBuilder

            strSql.Append(" ").Append("select *  From ")
            strSql.Append(" ").Append(tableName)
            strSql.Append(" ").Append(" Where 1=1 ")
            If strContractCode.Trim <> "" Then
                strSql.Append(" ").Append(" AND Contract_Code =  @Contract_Code ")
            End If
            If strSubIdentityCode.Trim <> "" Then
                strSql.Append(" ").Append(" AND Sub_Identity_Code = @Sub_Identity_Code ")
            End If

            command.CommandText = strSql.ToString()
            command.Parameters.AddWithValue("@Contract_Code", strContractCode)
            command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(sqlex.ToString)
            Throw sqlex
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "更新資料庫內容"
    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePUBContratByCond(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Is_Use_Set=@Is_Use_Set  " & _
           " where  Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code            "
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
                    command.Parameters.AddWithValue("@Contract_Code", row.Item("Contract_Code"))
                    command.Parameters.AddWithValue("@Sub_Identity_Code", row.Item("Sub_Identity_Code"))
                    command.Parameters.AddWithValue("@Is_Use_Set", row.Item("Is_Use_Set"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
                'Mark by Will,Lin
                'updateBackup(row) '備份機制
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


#Region "20101224 PUBContractBO_E2 合約共用檔維護 by mark zhang"
    ''' <summary>
    ''' 獲取PUB_Contract資料
    ''' </summary>
    ''' <param name="strColumnName">表字段對象</param>
    ''' <param name="strColumnValue">字段值對象</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBContractByColumnValue2(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select Contract_Code as contract_Code,Contract_Name as contract_Name,(REPLACE(CONVERT(nvarchar,Contract_Code),' ' ,'') + ' - ' + Contract_Name) as code_name_cb  from " & tableName & " where 1=1 ")
            For i = 0 To strColumnName.Length - 1
                content.Append("and ").Append(strColumnName(i)).Append("=@").Append(strColumnName(i)).AppendLine(" ")
            Next
            command.CommandText = content.ToString
            For i = 0 To strColumnName.Length - 1
                command.Parameters.AddWithValue("@" & strColumnName(i), strColumnValue(i))
            Next
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


#Region "20110124 PUBContractBO_E2 OHM家醫科健檢報告列印寄發ComboBox資料來源 by mark zhang"
    ''' <summary>
    ''' 獲取PUB_Contract資料 
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>
    ''' 2012/05/09 Add 參考停用註記 By 木良
    ''' </remarks>
    Function QueryPUBContractForComboBox() As DataSet
        Try
            Dim Ds As DataSet
            Dim SqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim Command As SqlCommand = SqlConn.CreateCommand()
            Dim Content As StringBuilder = New StringBuilder()
            Content.Append(" ").Append("SELECT  Contract_Code,                                                                              ")
            Content.Append(" ").Append("        Contract_Name,                                                                              ")
            Content.Append(" ").Append("        (REPLACE(CONVERT(NVARCHAR, Contract_Code), ' ' , '') + ' ' + Contract_Name) AS Code_Name_Cb ")
            Content.Append(" ").Append("FROM " & tableName & "                                                                              ")
            Content.Append(" ").Append("WHERE Contract_Code <> '**' AND Contract_Code <> '00' AND Dc = 'N'                                  ")
            Content.Append(" ").Append("GROUP BY Contract_Code, Contract_Name                                                               ")
            Command.CommandText = Content.ToString
            Using Adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                Ds = New DataSet(tableName)
                Adapter.Fill(Ds, tableName)
                Adapter.FillSchema(Ds, SchemaType.Mapped, tableName)
            End Using
            Return Ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "20110608 PUBContractBO_E2 合約機構查詢（Sub_Identity_Code=91、82、01）  Add by liuye"
    ''' <summary>
    ''' 獲取合約機構資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBContractsSubIdentityCodeIN(ByVal strSubIdentityCode As String) As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("SELECT  DISTINCT  Contract_Code, Contract_Name  FROM  PUB_Contract  ").Append(vbCrLf)
        strSql.Append(" Where 1=1 and Dc='N' ").Append(vbCrLf)
        strSql.Append("  and Sub_Identity_Code in (" & strSubIdentityCode & ") ").Append(vbCrLf)

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region

#Region "PRSPEC-262-09-460(記帳患者醫令清單) by Elly 2017/01/11"

    Function queryPUBContractsForBILRPT09460() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("SELECT  DISTINCT  Contract_Code, Contract_Name  ").Append(vbCrLf)
        strSql.Append(", (REPLACE(CONVERT(NVARCHAR, Contract_Code), ' ' , '') + ' ' + Contract_Name) AS Code_Name_Cb ").Append(vbCrLf)
        strSql.Append(" FROM  PUB_Contract  ").Append(vbCrLf)
        strSql.Append(" Where 1=1 and Dc='N' ").Append(vbCrLf)
        strSql.Append(" and Sub_Identity_Code not in ('64', '66')").Append(vbCrLf)

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function

#End Region
End Class

