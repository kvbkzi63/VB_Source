Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.SQL
Imports System.Reflection

Public Class PUBSysCodeBO_E2
    Dim tableName As String = "PUB_SYSCODE"
    Private Shared myInstance As PUBSysCodeBO_E2

    Public Overloads Shared Function getInstance() As PUBSysCodeBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBSysCodeBO_E2()
        End If
        Return myInstance
    End Function
    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

#Region "20090703 PUBSysCodeBO 共用代碼檔維護 by Add Yunfei"
    ''' <summary>
    ''' 獲取hisDB PUB_SYSCODE資料
    ''' </summary>
    ''' <param name="strColumnName">表字段對象</param>
    ''' <param name="strColumnValue">字段值對象</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select RTRIM(Code_Id) as code,RTRIM(Code_Name) as code_name,RTRIM((REPLACE(CONVERT(nvarchar,Code_Id),' ' ,'') + ' - ' + code_name)) as code_name_cb,sort_value  from " & tableName & " where 1=1 ")
            For i = 0 To strColumnName.Length - 1
                content.Append("and ").Append(strColumnName(i)).Append("=@").Append(strColumnName(i)).AppendLine(" ")
            Next
            content.Append(" order by Sort_Value") 'add by mark zhang 2011/01/06
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

#Region "20090720 PUBSysCodeBO 共用代碼檔維護 by Add Jianhui"
    ''' <summary>
    ''' 獲取OPH_Code資料
    ''' </summary>
    ''' <param name="strColumnName">表字段對象</param>
    ''' <param name="strOperator">運算符</param>
    ''' <param name="strColumnValue">字段值對象</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByCode(ByRef strColumnName As String(), ByRef strOperator As String(), ByRef strColumnValue As Object()) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select Code_Id as code,Code_Name as code_name,(REPLACE(CONVERT(nvarchar,Code_Id),' ' ,'') + ' - ' + code_name) as code_name_cb  from " & tableName & " where 1=1 ")
            For i = 0 To strColumnName.Length - 1
                content.Append("and ").Append(strColumnName(i)).Append(strOperator(i) + "@").Append(strColumnName(i)).AppendLine(" ")
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
#Region "2010/01/21 PUBSysCodeBO 共用代碼檔維護 by Add pearl"
    ''' <summary>
    ''' 查詢共用代碼檔資料(獲取"特殊註記"資料)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByCode2() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select Code_Id as code,Code_Name as code_name,(REPLACE(CONVERT(nvarchar,Code_Id),' ' ,'') + ' - ' + code_name) as code_name_cb  from " & tableName & " where 1=1 ")
            content.Append(" and Type_Id='30'and Code_Id>='A'and left(Code_Id,1)<>'Y' ")
            command.CommandText = content.ToString
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

#Region "20090818 PUBSysCodeBO 共用代碼檔維護 by Add Syscom Mark"
    ''' <summary>
    ''' 查詢共用代碼檔資料
    ''' </summary>
    ''' <param name="iTypeId">代碼類型</param>
    ''' <param name="strCodeId">代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByCond(ByVal iTypeId As Integer, ByVal strCodeId As String) As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select * From ")
        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append(" Where 1=1 ")
        If iTypeId > 0 Then
            strSql.Append(" AND Type_Id = ").Append(iTypeId).Append(" ")
        End If
        If strCodeId.Trim <> "" Then
            strSql.Append(" AND Code_Id = '").Append(strCodeId.Trim).Append("' ")
        End If
        strSql.Append(" Order By Sort_Value,Code_Id")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region
#Region "20090818 PUBSysCodeBO_E2 查詢醫令類別 Add by liuye"
    ''' <summary>
    ''' 查詢醫令類別
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByTCD() As DataSet
        Dim ds As DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("select * From ")

        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append("where Type_Id='31' and Dc='N' and (Code_Id ='E' or Code_Id ='H')")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region

#Region "20090914 emrDB PUBSysCodeBO 共用代碼檔維護 by Add Yunfei"
    ''' <summary>
    ''' 獲取emrDB PUB_SYSCODE資料
    ''' </summary>
    ''' <param name="strColumnName">表字段對象</param>
    ''' <param name="strColumnValue">字段值對象</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByCV2(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection2(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select RTRIM(Code_Id) as code,RTRIM(Code_Name) as code_name,RTRIM((REPLACE(CONVERT(nvarchar,Code_Id),' ' ,'') + ' - ' + code_name)) as code_name_cb  from " & tableName & " where 1=1  ")
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

    Private Function getConnection2() As IDbConnection
        Return SQLConnFactory.getInstance.getEmrDBSqlConn
    End Function
#End Region

#Region "20090917 PUBSysCodeBO_E2 查詢腸胃道疾病名稱 Add by liuye"
    ''' <summary>
    ''' 查詢腸胃道疾病名稱
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByTypeId() As DataSet
        Dim ds As DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("select Type_Id, Code_Id,Code_Name From ")

        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append("where Type_Id in (626,628,631,632,666,629) and Dc='N' ")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region

#Region "20090923 PUBSysCodeBO 共用代碼檔維護 by Add Yunfei"
    ''' <summary>
    ''' 獲取 PUB_SYSCODE資料
    ''' </summary>
    ''' <param name="strColumnName">表字段對象</param>
    ''' <param name="strColumnValue">字段值對象</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeNot0(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select RTRIM(Code_Id) as code,RTRIM(Code_Name) as code_name,RTRIM((REPLACE(CONVERT(nvarchar,Code_Id),' ' ,'') + ' - ' + code_name)) as code_name_cb  from " & tableName & " where 1=1 and Code_Id != '0'  ")
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


#Region "20160507  檢驗組別,IO類別(PUBSysCodeBO_E2) Add by Remote"
    ''' <summary>
    ''' 獲取 PUB_SYSCODE資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function querySpicemenType() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strsql As New StringBuilder

            ' 檢驗組別
            strsql.Append("SELECT code_id, " & vbCrLf)
            strsql.Append("       code_name " & vbCrLf)
            strsql.Append("FROM   PUB_Syscode " & vbCrLf)
            strsql.Append("WHERE  DC <> 'y' " & vbCrLf)
            strsql.Append("       AND Type_Id = '20001'")
            ' IO類別
            strsql.Append(" " & vbCrLf)
            strsql.Append("SELECT code_id, " & vbCrLf)
            strsql.Append("       code_name " & vbCrLf)
            strsql.Append("FROM   PUB_Syscode " & vbCrLf)
            strsql.Append("WHERE  DC <> 'y' " & vbCrLf)
            strsql.Append("       AND Type_Id = '20002' ")

            command.CommandText = strsql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20160601  資料來源Type_Id = '128'(PUBSysCodeBO_E2) Add by Remote"
    ''' <summary>
    ''' 資料來源（門診，急診，住院）
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeSourceId() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strsql As New StringBuilder

            ' 資料來源
            strsql.Append("SELECT code_id, " & vbCrLf)
            strsql.Append("       Code_Name " & vbCrLf)
            strsql.Append("FROM   PUB_SysCode " & vbCrLf)
            strsql.Append("WHERE  type_id = '128' ")


            command.CommandText = strsql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20091014 牙科X光醫令照射列印作業 by add zhangwei"
    ''' <summary>
    ''' 查詢醫令類別
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByX1_L(ByVal iTypeId As Integer, ByVal strCodeId1 As String, ByVal strCodeId2 As String) As DataSet
        Dim ds As DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("select * From ")

        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append("where")
        strSql.Append(" ").Append("Type_Id = " + iTypeId + " and Code_Id >='" + strCodeId1 + "' and Code_Id <='" + strCodeId2 + "'")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
    ''' <summary>
    ''' 查詢醫令類別
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByX2_L(ByVal iTypeId As Integer, ByVal strCodeId As String) As DataSet
        Dim ds As DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("select * From ")

        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append("where Type_Id = " + iTypeId + " and  Code_Id > '" + strCodeId + "'")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region

#Region "200901030 PUBSysCodeBO_E2 查詢外國國籍名稱 Add by tony"
    ''' <summary>
    ''' 查詢外國國籍名稱
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeNameByTypeId() As DataSet
        Dim ds As DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("select Code_Id,Code_Name From ")

        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append("where Type_Id='22'  and Dc='N' and Code_Id >= '60' ")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region
#Region "2010/01/14 DEP 復健治療師維護作業 取得治療類別 add by zhangwei"
    Function queryPUBSysCodeByTreatmentTypeId(ByVal strTypeId As String, ByVal strCodeId As String)
        Dim ds As DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("select RTRIM(Code_Id) as code,RTRIM(Code_Name) as code_name,RTRIM((REPLACE(CONVERT(nvarchar,Code_Id),' ' ,'') + ' - ' + code_name)) as code_name_cb From ")

        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append("where")
        strSql.Append(" ").Append("Type_Id = '" + strTypeId + "' and Code_Id like '" + strCodeId + "' and Dc ='N'")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function

#End Region

#Region "20100128 疾病分類住院資料查詢 add by Johsn"

    ''' <summary>
    ''' 查詢共用代碼檔資料
    ''' </summary>
    ''' <param name="iTypeId">代碼類型</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByTypeId(ByVal iTypeId As Integer, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder
        Dim connFlag As Boolean = conn Is Nothing

        strSql.Append(" ").Append("select RTRIM(Code_Id) as code,RTRIM(Code_Name) as code_name From ")
        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append(" Where 1=1 ")
        If iTypeId > 0 Then
            strSql.Append(" AND Type_Id = ").Append(iTypeId).Append(" ")
        End If

        strSql.Append(" Order By Sort_Value,Code_Id")

        Try
            If connFlag Then
                conn = getConnection()
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, CType(conn, SqlConnection))
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
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
        Return ds
    End Function
    ''' <summary>
    ''' 取得性別 年齡 來源 轉歸別 診斷類型 主次
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByIcdCodingQuery() As DataSet

        Dim dsDB As New DataSet
        dsDB.Tables.Add("SexId")
        dsDB.Tables.Add("AgeTypeId")
        dsDB.Tables.Add("InpatientSourceId")
        dsDB.Tables.Add("OutTypeId")
        dsDB.Tables.Add("DiagnosisTypeId")
        dsDB.Tables.Add("MainDiagnosisTypeId")

        Try
            Using sqlConn As SqlClient.SqlConnection = getConnection()
                sqlConn.Open()
                dsDB.Tables("SexId").Merge(queryPUBSysCodeByTypeId(21, sqlConn).Tables(0))
                dsDB.Tables("AgeTypeId").Merge(queryPUBSysCodeByTypeId(19, sqlConn).Tables(0))
                dsDB.Tables("InpatientSourceId").Merge(queryPUBSysCodeByTypeId(1007, sqlConn).Tables(0))
                dsDB.Tables("OutTypeId").Merge(queryPUBSysCodeByTypeId(1005, sqlConn).Tables(0))
                dsDB.Tables("DiagnosisTypeId").Merge(queryPUBSysCodeByTypeId(33, sqlConn).Tables(0))
                dsDB.Tables("MainDiagnosisTypeId").Merge(queryPUBSysCodeByTypeId(57, sqlConn).Tables(0))
                sqlConn.Close()
            End Using
            Return dsDB
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

#End Region

#Region "20100527 費用項目對應檔維護 add by Merry"
    '依傳入TypeID取得代碼檔資料
    Public Overloads Function queryPUBSysCodeAll(ByVal TypeID As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   Select RTRIM(Code_Id) as Code_Id,RTRIM(Code_Name) as Code_Name ,RTRIM(Code_En_Name) as Code_En_Name ,Is_Default  " & _
                                    " From " & tableName & " " & _
                                    " Where Type_Id='" & TypeID & "' And DC='N' " & _
                                    " Order By Sort_Value,Code_Id"

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
#Region "20100621 PUBSysCodeBO 共用代碼檔維護小兒預防註射疫苗領取登錄 by Add Syscom coco"
    ''' <summary>
    ''' 查詢共用代碼檔資料
    ''' </summary>
    ''' <param name="iTypeId">代碼類型</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByCond01(ByVal iTypeId As String) As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select  distinct Code_Id,Code_Name From ")
        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append(" Where type_id = '").Append(iTypeId).Append("' and Dc = 'N' ")
        strSql.Append(" Order By Code_Name")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region

#Region "20100913 PUBSysCodeBO 復健治療實際執行治療日數明細表 by Add Syscom pearl"
    ''' <summary>
    ''' 查詢共用代碼檔資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByCond36() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("  select Code_Id,Code_Name from PUB_Syscode ")
        strSql.Append(" ").Append("where Type_Id = '36' and Code_Id like '1-%' and DC ='N' ")
        strSql.Append(" Order By Code_Id")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region

#Region "20101116 PUBSysCodeBO_E2  Add by pearl"

    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByTypeId2(ByVal TypeId As String()) As DataSet
        Dim ds As DataSet = New DataSet
        Dim strSql As New StringBuilder
        strSql.Append("select Type_Id,Type_Name  From PUB_Syscode_Type ")
        strSql.Append(" ").Append("where Type_Id in (")
        If TypeId.Length > 0 Then
            For i As Integer = 0 To TypeId.Length - 1
                strSql.Append(" ").Append(TypeId(i))
                If i < TypeId.Length - 1 Then
                    strSql.Append(" ").Append(",")
                End If
            Next
        End If
        strSql.Append(" ").Append(")")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region

#Region "20110304 病患殘障記錄檔  Add by Runxia"

    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeByTypeIdForDisability(ByVal strTypeId As String) As DataSet
        Dim ds As DataSet = New DataSet
        Dim strSql As New StringBuilder
        strSql.Append("select distinct Code_Id,Code_Name  From PUB_Syscode ")
        strSql.Append(" ").Append("where Type_Id ='" & strTypeId & "'")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region

#Region "20110811 急診掛號病人表  離院型態資料來源  Add by prince"
    ''' <summary>
    ''' 取得離院型態資料來源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeCodeAndName() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select distinct RTRIM(Code_Id) as Code_Id, RTRIM(Code_Name) as Code_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  Type_Id='5005' ")
            content.Append(" Order By Code_Id")
            command.CommandText = content.ToString
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

#Region "     2016/06/29 傷口分類(PUBSysCodeBO_E2) by Remote "
    ''' <summary>
    ''' 傷口分類
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PUBSyscodeWoundType() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select distinct RTRIM(Code_Id) as Code_Id, RTRIM(Code_Name) as Code_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  Type_Id='8702' ")
            content.Append(" Order By Code_Id")
            command.CommandText = content.ToString
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

#Region "     2016/06/29 側位(PUBSysCodeBO_E2) by Remote "
    ''' <summary>
    ''' 側位
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PUBSyscodeBodySide() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select distinct RTRIM(Code_Id) as Code_Id, RTRIM(Code_Name) as Code_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  Type_Id='48' ")
            content.Append(" Order By Code_Id")
            command.CommandText = content.ToString
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

#Region "     2016/07/05 急作手術分級(PUBSysCodeBO_E2) by Remote "
    ''' <summary>
    ''' 急作手術分級
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PUBSyscodeUrgentClass() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select distinct RTRIM(Code_Id) as Code_Id, RTRIM(Code_Name) as Code_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  Type_Id='8701' ")
            content.Append(" Order By Code_Id")


            content.Append(" Select distinct RTRIM(Code_Id) as Code_Id, RTRIM(Code_Name) as Code_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  Type_Id='612'and Dc='N' ")
            content.Append(" Order By Code_Id")


            content.Append(" SELECT Oproom_No, " & vbCrLf)
            content.Append("       Oproom_Name " & vbCrLf)
            content.Append(" FROM   SUR_Oproom_Maintain_File ")
            content.Append(" Order By Oproom_No")

            content.Append(" SELECT Order_Code, " & vbCrLf)
            content.Append("       Favor_Name AS Order_Name " & vbCrLf)
            content.Append(" FROM   OMO_Favor " & vbCrLf)
            content.Append(" WHERE  Favor_Id = '2' " & vbCrLf)
            content.Append("       AND Favor_Type_Id = 'E' " & vbCrLf)
            content.Append("       AND Favor_Category = '抗生素' " & vbCrLf)
            content.Append("       AND Doctor_Dept_Code = '31306' " & vbCrLf)
            content.Append("       AND dc = 'N'")

            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                ' adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
