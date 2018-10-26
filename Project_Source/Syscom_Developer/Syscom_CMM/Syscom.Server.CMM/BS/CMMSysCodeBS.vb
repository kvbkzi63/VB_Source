'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：基本代碼查詢
'=======
'======= 程式說明：1.基本代碼查詢
'=======
'======= 建立日期：2013-7-19
'=======
'======= 開發人員：Sean.Lin
'=============================================================================
'=============================================================================
'=============================================================================

Imports Syscom.Server.SQL
Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports Syscom.Comm.LOG
Imports System.Text

Public Class CMMSysCodeBS

#Region "     變數宣告 "

    '宣告Log
    Dim log As LOGDelegate = LOGDelegate.getInstance

#End Region

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "

#Region "     基本代碼查詢 - Base "

    ''' <summary>
    ''' 基本代碼查詢 - Base
    ''' 
    ''' CodeType:查詢代碼
    ''' 
    ''' SystemFlag:系統別 1:不限系統
    ''' 
    ''' 回傳 TableName 為 CodeType 的 DataTable
    ''' 
    ''' 包含 Code_ID,Code_Name,Code_EN_Name,Combine_Name,Combine_EN_Name 
    ''' 
    ''' </summary>
    ''' <param name="CodeType" >代碼代號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    Private Function SysCodeQueryBase(ByVal CodeType As Integer, ByVal SystemFlag As Integer, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataTable

        Dim connFlag As Boolean = conn Is Nothing

        Try

            Dim dt As DataTable

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT PS.Code_ID, " & vbCrLf)
            varname1.Append("       PS.Code_Name, " & vbCrLf)
            varname1.Append("       PS.Code_EN_Name, " & vbCrLf)
            varname1.Append("       Rtrim(PS.Code_ID) + '-' + Rtrim(PS.Code_Name) AS Combine_Name, " & vbCrLf)
            varname1.Append("       Rtrim(PS.Code_ID) + '-' + Rtrim(PS.Code_EN_Name) AS Combine_EN_Name " & vbCrLf)
            varname1.Append("FROM   Pub_SysCode As PS " & vbCrLf)
            varname1.Append("WHERE  1 = 1 " & vbCrLf)
            varname1.Append("       -- 取得符合的 Type_ID 資料 " & vbCrLf)
            varname1.Append("       AND PS.TYPE_ID = @TYPE_ID " & vbCrLf)

            '提供日後擴充用
            Select Case SystemFlag

                '不限系統
                Case 1


                Case 2

                    'EX
                    varname1.Append("       AND PS.is_Opd = 'Y' " & vbCrLf)

            End Select

            varname1.Append("       -- 尚未DC " & vbCrLf)
            varname1.Append("       AND PS.DC = 'N' " & vbCrLf)
            varname1.Append("ORDER  BY PS.Sort_Value ")


            command.CommandText = varname1.ToString

            command.Parameters.AddWithValue("@TYPE_ID", CodeType)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dt = New DataTable(CodeType)
                adapter.Fill(dt)
            End Using

            Return dt

        Catch sqlex As SqlException

            Throw New SQLDatabaseException(sqlex)

        Catch cmex As CommonException

            Throw cmex

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

#End Region

#Region "     基本代碼查詢 - 不限系統 "

    ''' <summary>
    ''' 基本代碼查詢 - 不限系統；CodeType:查詢代碼；回傳 TableName 為 CodeType 的 Dataset;包含 Code_ID,Code_Name,Code_EN_Name,Combine_Name,Combine_EN_Name 
    ''' 
    ''' </summary>
    ''' <param name="CodeType" >代碼代號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    Public Function SysCodeQuery(ByVal CodeType As Integer, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try

            Dim ds As New DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            '取得共用的 CodeType 對應的資料，(不限系統)
            ds.Tables.Add(SysCodeQueryBase(CodeType, 1, conn))

            Return ds

        Catch sqlex As SqlException

            Throw New SQLDatabaseException(sqlex)

        Catch cmex As CommonException

            Throw cmex

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

#End Region

#Region "     基本代碼查詢 - 不限系統 - 多筆 "

    ''' <summary>
    ''' 基本代碼查詢 - 不限系統 - 多筆 ；CodeType:查詢代碼的陣列；回傳 TableName 為 CodeType 的 Dataset;包含 Code_ID,Code_Name,Code_EN_Name,Combine_Name,Combine_EN_Name 
    ''' </summary>
    ''' <param name="CodeType" >代碼代號陣列</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    Public Function SysCodeQueryMuti(ByVal CodeType As Integer(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As New DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            '循環取得所有的代碼，加到每一個Table 中
            For i As Integer = 0 To CodeType.Length - 1

                '取得共用的 CodeType 對應的資料，(不限系統)
                ds.Tables.Add(SysCodeQueryBase(CodeType(i), 1, conn))

            Next

            Return ds


        Catch sqlex As SqlException

            Throw New SQLDatabaseException(sqlex)

        Catch cmex As CommonException

            Throw cmex

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

#End Region

#Region "     基本類別代碼查詢 - Base "

    ''' <summary>
    ''' 基本類別代碼查詢 - Base
    ''' 
    ''' TypeId:查詢類別代碼
    ''' 
    ''' 回傳 TableName 為 SystemName 的 DataTable
    ''' 
    ''' 包含 Type_Id ,Type_Name ,System_Name 
    ''' 
    ''' </summary>
    ''' <param name="TypeId" >類別代碼代號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Lewis on 2014-2-13</remarks>
    Private Function SysCodeTypeQueryBase(ByVal TypeId As String, ByVal SystemName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataTable

        Dim connFlag As Boolean = conn Is Nothing

        Try

            Dim dt As DataTable

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("select CONVERT(varchar(10), Type_Id) as Code,Type_Name,CONVERT(varchar(10), Type_Id) +'-'+Type_Name as Combine  " & vbCrLf)
            varname1.Append("FROM   PUB_Syscode_Type As PST " & vbCrLf)
            varname1.Append("WHERE  1 = 1 " & vbCrLf)
            If TypeId.ToString.Trim <> "" Then
                varname1.Append("       AND PST.TYPE_ID = @TYPE_ID " & vbCrLf)
            End If
            If SystemName.Trim <> "" Then
                varname1.Append("       AND PST.System_Name =@SYSTEM_NAME " & vbCrLf)
            End If
            varname1.Append("ORDER  BY PST.TYPE_ID ")

            command.CommandText = varname1.ToString

            command.Parameters.AddWithValue("@TYPE_ID", TypeId)
            command.Parameters.AddWithValue("@SYSTEM_NAME", SystemName)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dt = New DataTable(SystemName)
                adapter.Fill(dt)
            End Using

            Return dt

        Catch sqlex As SqlException

            Throw New SQLDatabaseException(sqlex)

        Catch cmex As CommonException

            Throw cmex

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

#End Region

#Region "     基本類別代碼查詢 "

    ''' <summary>
    ''' 基本代碼類別查詢 Pub_Syscode_Type
    ''' 
    ''' </summary>
    ''' <param name="TypeId" >類別代碼代號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Lewis on 2014-2-13</remarks>
    Public Function SysCodeTypeQuery(ByVal TypeId As String, ByVal SystemName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try

            Dim ds As New DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            '取得共用的 CodeType 對應的資料，(不限系統)
            ds.Tables.Add(SysCodeTypeQueryBase(TypeId, SystemName, conn))

            Return ds

        Catch sqlex As SqlException

            Throw New SQLDatabaseException(sqlex)

        Catch cmex As CommonException

            Throw cmex

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

#End Region

#Region " 院區代碼查詢 "

    ''' <summary>
    ''' 院區代碼查詢
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-09-16</remarks>
    Public Function querySectionCode(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

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
            varname1.Append("SELECT PS.SECTION_CODE, " & vbCrLf)
            varname1.Append("       PS.SECTION_NAME, " & vbCrLf)
            varname1.Append("       PS.SECTION_EN_Name, " & vbCrLf)
            varname1.Append("       Rtrim(PS.SECTION_CODE) + '-' + Rtrim(PS.SECTION_Name)    AS Combine_Name, " & vbCrLf)
            varname1.Append("       Rtrim(PS.SECTION_CODE) + '-' + Rtrim(PS.SECTION_EN_Name) AS Combine_EN_Name " & vbCrLf)
            varname1.Append("FROM   PUB_SECTION PS " & vbCrLf)
            varname1.Append("--尚未DC " & vbCrLf)
            varname1.Append("WHERE  PS.DC = 'N' " & vbCrLf)
            varname1.Append("       --仍然有效 " & vbCrLf)
            varname1.Append("       AND Getdate() BETWEEN PS.Effect_Date AND PS.End_date " & vbCrLf)
            varname1.Append("ORDER  BY PS.Sort_Value ")


            command.CommandText = varname1.ToString


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_SECTION")
                adapter.Fill(ds, "PUB_SECTION")
            End Using

            Return ds

        Catch sqlex As SqlException

            Throw New SQLDatabaseException(sqlex)

        Catch cmex As CommonException

            Throw cmex

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

#End Region

#Region " 部門代碼查詢 "

    ''' <summary>
    ''' 部門代碼查詢
    ''' </summary>
    ''' <param name="conn">資料庫連結</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-09-16</remarks>
    Public Function queryDeptTCodeBySectionCode(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

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
            varname1.Append("SELECT PD.Dept_Code, " & vbCrLf)
            varname1.Append("       PD.Dept_NAME, " & vbCrLf)
            varname1.Append("       PD.Dept_EN_Name, " & vbCrLf)
            varname1.Append("       Rtrim(PD.Dept_CODE) + '-' + Rtrim(PD.Dept_Name)    AS Combine_Name, " & vbCrLf)
            varname1.Append("       Rtrim(PD.Dept_CODE) + '-' + Rtrim(PD.Dept_EN_Name) AS Combine_EN_Name" & vbCrLf)
            varname1.Append("       --,PD.SECTION_CODE " & vbCrLf) '20140217/Lewis/暫時移除 Section_Code，當初此欄位為For北市聯合醫
            varname1.Append("FROM   PUB_Department PD " & vbCrLf)
            varname1.Append("WHERE  1 = 1 " & vbCrLf)
            varname1.Append("       --尚未DC " & vbCrLf)
            varname1.Append("       AND PD.DC = 'N' " & vbCrLf)
            varname1.Append("       --仍然有效 " & vbCrLf)
            varname1.Append("       AND Getdate() BETWEEN PD.Effect_Date AND PD.End_date " & vbCrLf)
            varname1.Append("ORDER  BY PD.Sort_Value ")


            command.CommandText = varname1.ToString


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Department")
                adapter.Fill(ds, "PUB_Department")
            End Using

            Return ds

        Catch sqlex As SqlException

            Throw New SQLDatabaseException(sqlex)

        Catch cmex As CommonException

            Throw cmex

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

#End Region

#Region " 護理站代碼查詢 "

    ''' <summary>
    ''' 護理站代碼查詢
    ''' </summary>
    ''' <param name="conn">資料庫連結</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2015-11-26</remarks>
    Public Function queryPubStation(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataTable

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim dt As DataTable

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim Content As New StringBuilder
            Content.AppendLine("SELECT PS.Station_No, ")
            Content.AppendLine("       PS.Station_Name,   ")
            Content.AppendLine("       Rtrim(PS.Station_No) + '-' + Rtrim(PS.Station_Name)    AS Combine_Name, ")
            Content.AppendLine("       Rtrim(PS.Station_No) + '-' + Rtrim(PS.Station_Name) AS Combine_EN_Name")
            Content.AppendLine(" FROM   PUB_Station PS ")
            Content.AppendLine("WHERE  1 = 1 ")
            Content.AppendLine("       --尚未DC ")
            Content.AppendLine("       AND PS.DC = 'N' ")
            Content.AppendLine("")


            command.CommandText = Content.ToString


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dt = New DataTable("PUB_Station")
                adapter.Fill(dt)
            End Using

            Return dt

        Catch sqlex As SqlException

            Throw New SQLDatabaseException(sqlex)

        Catch cmex As CommonException

            Throw cmex

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

#End Region

#Region " 查詢參數檔 "

    ''' <summary>
    ''' 查詢參數檔，回傳一個DT，Table Name 為 傳入的 configName
    ''' </summary>
    ''' <param name="configName" >參數名</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2016-05-18</remarks>
    Public Function QueryPubConfig(ByVal configName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataTable

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim dt As DataTable

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim Content As New StringBuilder
            Content.AppendLine("SELECT  Config_Name")
            Content.AppendLine("      ,Config_Description")
            Content.AppendLine("      ,Config_Value")
            Content.AppendLine("      ,Create_User")
            Content.AppendLine("      ,Create_Time")
            Content.AppendLine("      ,Modified_User")
            Content.AppendLine("      ,Modified_Time")
            Content.AppendLine("  FROM  PUB_Config")
            Content.AppendLine("  Where Config_Name = @Config_Name")
            Content.AppendLine("")

            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Config_Name", configName)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dt = New DataTable(configName)
                adapter.Fill(dt)
            End Using

            Return dt

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 查詢參數檔 - 多筆 "

    ''' <summary>
    ''' 查詢參數檔 - 多筆，回傳一個DS，Table Name 為 傳入的 configName
    ''' </summary>
    ''' <param name="configName" >參數名</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2016-05-18</remarks>
    Public Function QueryPubConfigMuti(ByVal configName As String(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As New DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each configNameSingle As String In configName
                ds.Tables.Add(QueryPubConfig(configNameSingle, conn))
            Next

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#End Region

#Region "     取得 共用代碼檔 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 共用代碼檔 在所屬資料庫的連線
    ''' </summary>
    ''' ''' <returns>資料庫連線</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    Public Function getConnection() As IDbConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

