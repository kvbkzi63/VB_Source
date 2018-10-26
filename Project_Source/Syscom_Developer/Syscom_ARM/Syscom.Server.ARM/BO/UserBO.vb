Imports System.DirectoryServices
Imports Syscom.Server.CMM
Imports Syscom.Server.SQL
Imports System.Data.SqlClient
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.Utility.StringUtil

Public Class UserBO

#Region "使用者相關資料  User For AD "

    Dim errMsg1 As String = "輸入空的資料集"

    '''' <summary>
    '''' 新增使用者
    '''' </summary>
    '''' <param name="ds"></param>
    '''' <remarks></remarks>
    'Public Sub AddUser(ByVal ds As DataSet)
    '    'DataSet的欄位(userid, username, birthday, valid, mail, Dept_Name, Dept_Code)
    '    Try
    '        '存取roleTable的方式需要改善
    '        If ds.Tables.Count = 0 Then
    '            Throw New Exception(errMsg1)
    '        End If
    '        Dim dt As DataTable = ds.Tables("User")
    '        If dt Is Nothing Then
    '            Throw New Exception(errMsg1)
    '        End If

    '        '加入新使用者
    '        For Each row As DataRow In dt.Rows
    '            Using DE As DirectoryEntry = ADEntry.getADEntry(ADEntry.ADEntrys.USER)
    '                Dim DE_NewEntry As DirectoryEntry = DE.Children.Add("CN=" & row.Item("userid").ToString, ADEntry.USER)
    '                DE_NewEntry.Properties(ADEntry.ARM_KEY).Value = "" & row.Item("userid").ToString
    '                DE_NewEntry.Properties(ADEntry.ARM_PKEY).Value = "" & row.Item("userid").ToString
    '                ADEntry.SetProperty(DE_NewEntry, ADEntry.ARM_USER_LOGINNAME, row.Item("userid").ToString)

    '                DE_NewEntry.Properties(ADEntry.ARM_TYPE).Value = ADEntry.ARM_TYPE_USER
    '                DE_NewEntry.Properties(ADEntry.ARM_USER_NAME).Value = row.Item("username").ToString
    '                DE_NewEntry.Properties(ADEntry.ARM_USER_BIRTHDAY).Value = row.Item("birthday").ToString
    '                DE_NewEntry.Properties(ADEntry.ARM_USER_ISVALID).Value = row.Item("isvalid").ToString
    '                DE_NewEntry.Properties(ADEntry.ARM_USER_MAIL).Value = row.Item("mail").ToString
    '                DE_NewEntry.Properties(ADEntry.ARM_USER_Dept_Name).Value = row.Item("Dept_Name").ToString
    '                DE_NewEntry.Properties(ADEntry.ARM_USER_Dept_Code).Value = row.Item("Dept_Code").ToString
    '                DE_NewEntry.Properties(ADEntry.ARM_USER_CREATOR).Value = row.Item("creator_no").ToString
    '                DE_NewEntry.Properties(ADEntry.ARM_USER_MODIFIER).Value = row.Item("operator_no").ToString
    '                DE_NewEntry.CommitChanges()

    '                '新增使用者後設定一些基本屬性
    '                '參考 http://msdn.microsoft.com/en-us/library/ms817825.aspx
    '                DE_NewEntry.Properties(ADEntry.ARM_USER_ACCOUNTCONTROL).Value = 512
    '                '預設密碼若使用者自行維護應該也用不到了
    '                DE_NewEntry.Invoke("SetPassword", "pa$$w0rd")
    '                DE_NewEntry.CommitChanges()
    '                DE_NewEntry.Close()
    '            End Using
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    '''' <summary>
    '''' 修改使用者
    '''' </summary>
    '''' <param name="ds"></param>
    '''' <remarks></remarks>
    'Public Sub ModifyUser(ByVal ds As DataSet)
    '    Try
    '        Using DE As DirectoryEntry = ADEntry.getADEntry(ADEntry.ADEntrys.USER)
    '            ' 修改使用者
    '            Dim dt As DataTable = ds.Tables("User")
    '            If dt Is Nothing Then
    '                Throw New Exception(errMsg1)
    '            End If
    '            For Each row As DataRow In dt.Rows
    '                Using DE_NewRoleEntry As DirectoryEntry = getUser(DE, row.Item("userid").ToString)
    '                    If Not DE_NewRoleEntry Is Nothing Then
    '                        DE_NewRoleEntry.Properties(ADEntry.ARM_USER_NAME).Value = row.Item("username").ToString
    '                        DE_NewRoleEntry.Properties(ADEntry.ARM_USER_BIRTHDAY).Value = row.Item("birthday").ToString
    '                        DE_NewRoleEntry.Properties(ADEntry.ARM_USER_ISVALID).Value = row.Item("isvalid").ToString
    '                        DE_NewRoleEntry.Properties(ADEntry.ARM_USER_MAIL).Value = row.Item("mail").ToString
    '                        DE_NewRoleEntry.Properties(ADEntry.ARM_USER_Dept_Name).Value = row.Item("Dept_Name").ToString
    '                        DE_NewRoleEntry.Properties(ADEntry.ARM_USER_Dept_Code).Value = row.Item("Dept_Code").ToString
    '                        DE_NewRoleEntry.Properties(ADEntry.ARM_USER_MODIFIER).Value = row.Item("operator_no").ToString
    '                        DE_NewRoleEntry.CommitChanges()
    '                    End If
    '                End Using
    '            Next
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    '''' <summary>
    '''' 刪除使用者
    '''' </summary>
    '''' <param name="ds"></param>
    '''' <remarks></remarks>
    'Public Sub DeleteUser(ByVal ds As DataSet)
    '    Try
    '        '存取roleTable的方式需要改善
    '        Dim dt As DataTable = ds.Tables("User")
    '        If dt Is Nothing Then
    '            Throw New Exception(errMsg1)
    '        End If
    '        Using DE As DirectoryEntry = ADEntry.getADEntry(ADEntry.ADEntrys.USER)
    '            ' 搜尋使用者
    '            For Each row As DataRow In dt.Rows
    '                Using DE_NewRoleEntry As DirectoryEntry = getUser(DE, row.Item("userid").ToString) ' DE.Children.Find("CN=" & aRow.Item(2).ToString, "user")
    '                    If Not DE_NewRoleEntry Is Nothing Then
    '                        DE.Children.Remove(DE_NewRoleEntry)
    '                    End If
    '                End Using
    '            Next
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    '''' <summary>
    '''' 查詢使用者
    '''' </summary>
    '''' <param name="ds"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function QueryUser(ByVal ds As DataSet) As DataSet
    '    Try
    '        Dim DE As DirectoryEntry '
    '        '查詢使用者
    '        Dim DS_ADSearcher As DirectorySearcher
    '        If ds Is Nothing Or ds.Tables Is Nothing Then
    '            DE = ADEntry.getADEntry(ADEntry.ADEntrys.USER)
    '            DS_ADSearcher = New DirectorySearcher(DE)
    '            DS_ADSearcher.Filter = "(" & ADEntry.ARM_TYPE & "=" & ADEntry.ARM_TYPE_USER & ")"
    '        Else
    '            Dim cond As Boolean = False
    '            Dim row As DataRow = ds.Tables("User").Rows(0)
    '            DE = ADEntry.getADEntry(ADEntry.ADEntrys.USER)
    '            DS_ADSearcher = New DirectorySearcher(DE)
    '            Dim userId As String = row.Item("userid").ToString.Trim
    '            Dim filter As System.Text.StringBuilder = New System.Text.StringBuilder("(&(objectCategory=person)(objectClass=user)")
    '            If userId <> "" Then
    '                filter.Append("(" & ADEntry.ARM_PKEY & "=" & userId & ")")
    '                cond = True
    '            End If
    '            Dim userName As String = row.Item("username").ToString.Trim
    '            If userName <> "" Then
    '                filter.Append("(" & ADEntry.ARM_USER_NAME & "=*" & userName & "*)")
    '                cond = True
    '            End If
    '            Dim isValid As String = row.Item("isvalid").ToString.Trim
    '            If isValid <> "" Then
    '                filter.Append("(" & ADEntry.ARM_USER_ISVALID & "=" & isValid & ")")
    '                cond = True
    '            End If
    '            Dim BirStr As String = row.Item("birthday").ToString.Trim
    '            If BirStr <> "" Then
    '                filter.Append("(" & ADEntry.ARM_USER_BIRTHDAY & "=" & BirStr & ")")
    '                cond = True
    '            End If
    '            Dim deptName As String = row.Item("Dept_Name").ToString.Trim
    '            If deptName <> "" Then
    '                filter.Append("(" & ADEntry.ARM_USER_Dept_Name & "=" & deptName & ")")
    '                cond = True
    '            End If
    '            Dim deptNum As String = row.Item("Dept_Code").ToString.Trim
    '            If deptNum <> "" Then
    '                filter.Append("(" & ADEntry.ARM_USER_Dept_Code & "=" & deptNum & ")")
    '                cond = True
    '            End If
    '            Dim Mail As String = row.Item("mail").ToString.Trim
    '            If Mail <> "" Then
    '                filter.Append("(" & ADEntry.ARM_USER_MAIL & "=" & Mail & ")")
    '                cond = True
    '            End If
    '            filter.Append(")")
    '            DS_ADSearcher.Filter = filter.ToString
    '        End If
    '        DS_ADSearcher.PropertiesToLoad.AddRange(ADEntry.ARM_USER_COLUMNS)
    '        Dim results As SearchResultCollection = DS_ADSearcher.FindAll
    '        If results Is Nothing Or results.Count = 0 Then
    '            Return New DataSet
    '        End If
    '        Return ResultToDataSet(results)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    '''' <summary>
    '''' 修改使用者密碼
    '''' </summary>
    '''' <param name="ds"></param>
    '''' <remarks></remarks>
    'Public Sub ChangePassword(ByVal ds As DataSet)
    '    Try
    '        Dim DE As DirectoryEntry = ADEntry.getADEntry(ADEntry.ADEntrys.USER)
    '        ' 修改密碼
    '        Dim DS_ADSearcher As DirectorySearcher = New DirectorySearcher(DE)
    '        If ds Is Nothing Or ds.Tables Is Nothing Then
    '            Throw New Exception("無需要更新的資料")
    '        End If
    '        Dim row As DataRow = ds.Tables(0).Rows(0)
    '        Dim userId As String = row.Item(0).ToString
    '        DS_ADSearcher.Filter = "(" & ADEntry.ARM_PKEY & "=" & userId & ")"
    '        DS_ADSearcher.PropertiesToLoad.Add(ADEntry.ARM_PKEY)
    '        Dim userResult As SearchResult = DS_ADSearcher.FindOne
    '        If userResult Is Nothing Then
    '            Throw New Exception("無該使用者")
    '        End If

    '        Dim userEntry As DirectoryEntry = userResult.GetDirectoryEntry
    '        Dim valueObject() As Object = {ds.Tables(0).Rows(0).Item(1).ToString, ds.Tables(0).Rows(0).Item(2).ToString}
    '        userEntry.Invoke("ChangePassword", valueObject)
    '        userEntry.CommitChanges()
    '        userEntry.Close()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    ''' <summary>
    ''' 直接取得傳入路徑下所有路徑所查詢到的使用者
    ''' </summary>
    ''' <param name="DE"></param>
    ''' <param name="userid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getUser(ByVal DE As DirectoryEntry, ByVal userid As String) As DirectoryEntry
        Dim DS_ADSearcher As DirectorySearcher = New DirectorySearcher(DE)
        DS_ADSearcher.Filter = "(" & ADEntry.ARM_TYPE & "=" & ADEntry.ARM_TYPE_USER & ")"
        DS_ADSearcher.Filter = "(&" & DS_ADSearcher.Filter & "(" & ADEntry.ARM_PKEY & "=" & userid & "))"
        DS_ADSearcher.PropertiesToLoad.AddRange(ADEntry.ARM_USER_COLUMNS)
        Return DS_ADSearcher.FindOne.GetDirectoryEntry
    End Function

    ''' <summary>
    ''' 將搜尋結果的SearchResultCollection塞入DataSet中
    ''' </summary>
    ''' <param name="results"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ResultToDataSet(ByVal results As SearchResultCollection) As DataSet
        If results Is Nothing Or results.Count = 0 Then
            Return Nothing
        End If
        Dim roleDs As DataSet = New DataSet
        Dim roleTable As DataTable = New DataTable
        roleTable.TableName = "User"
        '由於以下需要和ui端的DataPropertyName配合 要想個辦法或者專門存放這些字串
        roleTable.Columns.Add(New DataColumn("userid"))
        roleTable.Columns.Add(New DataColumn("username"))
        roleTable.Columns.Add(New DataColumn("birthday"))
        roleTable.Columns.Add(New DataColumn("isvalid"))
        roleTable.Columns.Add(New DataColumn("mail"))
        roleTable.Columns.Add(New DataColumn("Dept_Name"))
        roleTable.Columns.Add(New DataColumn("Dept_Code"))
        roleTable.Columns.Add(New DataColumn("creator_no"))
        roleTable.Columns.Add(New DataColumn("create_datetime"))
        roleTable.Columns.Add(New DataColumn("operator_no"))
        roleTable.Columns.Add(New DataColumn("update_datetime"))

        For Each result As SearchResult In results
            Dim dentry As DirectoryEntry = result.GetDirectoryEntry
            Dim valueArray() As Object = {dentry.Properties(ADEntry.ARM_PKEY).Value, _
            dentry.Properties(ADEntry.ARM_USER_NAME).Value, _
            dentry.Properties(ADEntry.ARM_USER_BIRTHDAY).Value, _
            dentry.Properties(ADEntry.ARM_USER_ISVALID).Value, _
            dentry.Properties(ADEntry.ARM_USER_MAIL).Value, _
            dentry.Properties(ADEntry.ARM_USER_DEPARTMENTNUMBER).Value, _
            dentry.Properties(ADEntry.ARM_USER_DEPARTMENT).Value, _
            dentry.Properties(ADEntry.ARM_USER_CREATOR).Value, _
            dentry.Properties(ADEntry.ARM_USER_CREATETIME).Value, _
            dentry.Properties(ADEntry.ARM_USER_MODIFIER).Value, _
            dentry.Properties(ADEntry.ARM_USER_MODIFYTIME).Value}
            roleTable.Rows.Add(valueArray)
            dentry.Close()
        Next
        roleDs.Tables.Add(roleTable)
        Dim dt As DataTable
        Dim dv As DataView = New DataView(roleDs.Tables("User"))
        dv.Sort = "userid"
        dt = dv.ToTable("User")
        roleDs.Tables("User").Clear()
        roleDs.Merge(dt)
        Return roleDs
    End Function
#End Region

#Region "使用者相關資料  User For Database "

#Region "     查詢使用者 "

    ''' <summary>
    ''' 查詢使用者
    ''' </summary>
    ''' <param name="inputds" ></param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-7-18</remarks>
    Public Function QueryUser(ByVal inputds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim tableName As String = "User"
            Dim userId As String = ""
            Dim userName As String = ""
            Dim deptCode As String = ""
            Dim isValid As String = ""
            Dim JobTitle As String = ""

            If inputds.Tables.Count > 0 Then
                userId = inputds.Tables(tableName).Rows(0).Item("userid").ToString.Trim
                userName = inputds.Tables(tableName).Rows(0).Item("username").ToString.Trim
                isValid = inputds.Tables(tableName).Rows(0).Item("isvalid").ToString.Trim
                deptCode = inputds.Tables(tableName).Rows(0).Item("Dept_Code").ToString.Trim
                jobTitle = inputds.Tables(tableName).Rows(0).Item("Professal_Kind_Id").ToString.Trim
            End If

            '20140217/Lewis/暫時將Method--QueryUser的 birthday,isvalid,Dept_Name,Section_Code,Section_Name 給 ""

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT DISTINCT ( B.Employee_Code )                                           AS userid, " & vbCrLf)
            sqlString.Append("       Rtrim(B.Employee_Name)                                          AS username, " & vbCrLf)
            sqlString.Append("       B.Employee_En_Name                                              AS Employee_En_Name, " & vbCrLf)
            sqlString.Append("       B.Idno                                                          AS idno, " & vbCrLf)
            sqlString.Append("       ''                                                              AS birthday, " & vbCrLf)
            sqlString.Append("       CASE " & vbCrLf)
            sqlString.Append("         WHEN Getdate() BETWEEN B.Assume_Effect_Date AND B.Assume_End_Date THEN 'Y' " & vbCrLf)
            sqlString.Append("         ELSE 'N' " & vbCrLf)
            sqlString.Append("       END                                                             AS isvalid, " & vbCrLf)
            sqlString.Append("       CASE " & vbCrLf)
            sqlString.Append("         WHEN Getdate() BETWEEN B.Assume_Effect_Date AND B.Assume_End_Date THEN '是' " & vbCrLf)
            sqlString.Append("         ELSE '否' " & vbCrLf)
            sqlString.Append("       END                                                             AS isvalidName, " & vbCrLf)
            sqlString.Append("       Isnull(B.Email, '')                                             AS mail, " & vbCrLf)
            sqlString.Append("       B.Tel_Mobile                                                    AS Tel_Mobile, " & vbCrLf)
            sqlString.Append("       B.Professal_Kind_Id                                             AS Professal_Kind_Id, " & vbCrLf)
            sqlString.Append("       Rtrim(D.Code_Name)                                              AS Professal_Kind_Name, " & vbCrLf)
            sqlString.Append("       Isnull(B.Dept_Code, '')                                         AS Dept_Code, " & vbCrLf)
            sqlString.Append("       C.Dept_Name                                                     AS Dept_Name, " & vbCrLf)
            sqlString.Append("       ''                                                              AS Section_Code, " & vbCrLf)
            sqlString.Append("       ''                                                              AS Section_Name, " & vbCrLf)
            sqlString.Append("       dbo.AdtoRocDate(B.Assume_Effect_Date)                           AS Assume_Effect_Date, " & vbCrLf)
            sqlString.Append("       dbo.AdtoRocDate(B.Assume_End_Date)                              AS Assume_End_Date, " & vbCrLf)
            sqlString.Append("       B.Create_User                                                   AS creator_no, " & vbCrLf)
            sqlString.Append("       dbo.AdtoRocTime(Isnull(B.Create_Time, '1900-01-01 00:00:00'))   AS create_datetime, " & vbCrLf)
            sqlString.Append("                E.Update_User                                                 AS operator_no, " & vbCrLf)
            sqlString.Append("                dbo.Adtoroctime(Isnull(E.Update_Time, '1900-01-01 00:00:00')) AS update_datetime " & vbCrLf)
            '台南增加職級欄位
            If Syscom.Comm.BASE.HospConfigUtil.HospConfig = Comm.BASE.HospConfigUtil.hospConfigList.Tw_Tnhosp Then
                sqlString.Append("   ,B.Nrs_Level_Id " & vbCrLf)
            End If
            sqlString.Append("FROM   PUB_Employee AS B " & vbCrLf)
            'sqlString.Append("       INNER JOIN ARM_Password AS A " & vbCrLf)
            'sqlString.Append("         ON A.Employee_Code = B.Employee_Code " & vbCrLf)
            sqlString.Append("       LEFT JOIN PUB_Department AS C " & vbCrLf)
            sqlString.Append("         ON B.Dept_Code = C.Dept_Code " & vbCrLf)
            sqlString.Append("       LEFT JOIN PUB_Syscode AS D " & vbCrLf)
            sqlString.Append("         ON D.Type_Id = '1101' " & vbCrLf)
            sqlString.Append("            AND B.Professal_Kind_Id = D.Code_Id " & vbCrLf)
            sqlString.Append("       LEFT JOIN ARM_Roles AS E " & vbCrLf)
            sqlString.Append("              ON B.Employee_Code = E.Employee_Code " & vbCrLf)
            sqlString.Append("WHERE  1 = 1 " & vbCrLf)

            If userId <> "" Then
                sqlString.Append("       AND  B.Employee_Code = @Employee_Code " & vbCrLf)
            End If

            If userName <> "" Then
                sqlString.Append("       AND  B.Employee_Name LIKE @Employee_Name " & vbCrLf)
            End If

            If deptCode <> "" Then
                sqlString.Append("       AND  B.Dept_Code = @Dept_Code " & vbCrLf)
            End If

            If JobTitle <> "" Then
                sqlString.Append("       AND  B.Professal_Kind_Id = @Professal_Kind_Id " & vbCrLf)
            End If

            If isValid <> "" Then
                If isValid = "Y" Then
                    sqlString.Append("       AND  Getdate() BETWEEN B.Assume_Effect_Date AND B.Assume_End_Date " & vbCrLf)
                ElseIf isValid = "N" Then
                    sqlString.Append("       AND NOT  Getdate() BETWEEN B.Assume_Effect_Date AND B.Assume_End_Date " & vbCrLf)
                End If
            End If

            sqlString.Append("ORDER  BY B.Employee_Code ")
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Employee_Code", userId)
            command.Parameters.AddWithValue("@Employee_Name", "%" & userName & "%")
            command.Parameters.AddWithValue("@Dept_Code", deptCode)
            command.Parameters.AddWithValue("@Professal_Kind_Id", JobTitle)
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
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "     新增使用者 "

    ''' <summary>
    ''' 新增使用者
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-8-28</remarks>
    Public Function AddUser(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("INSERT INTO ARM_Password " & vbCrLf)
            sqlString.Append("            (Employee_Code, " & vbCrLf)
            sqlString.Append("             [Password]) " & vbCrLf)
            sqlString.Append("VALUES      ( @Employee_Code, " & vbCrLf)
            sqlString.Append("              @Password) " & vbCrLf)
            sqlString.Append("; " & vbCrLf)
            sqlString.Append("INSERT INTO PUB_Employee " & vbCrLf)
            sqlString.Append("            (Employee_Code, " & vbCrLf)
            sqlString.Append("             Employee_Name, " & vbCrLf)
            sqlString.Append("             Employee_En_Name, " & vbCrLf)
            sqlString.Append("             Idno, " & vbCrLf)
            sqlString.Append("             Dept_Code, " & vbCrLf)
            sqlString.Append("             Email, " & vbCrLf)
            sqlString.Append("             Assume_Effect_Date, " & vbCrLf)
            sqlString.Append("             Assume_End_Date, " & vbCrLf)
            If Syscom.Comm.BASE.HospConfigUtil.HospConfig = Comm.BASE.HospConfigUtil.hospConfigList.Tw_Tnhosp Then
                '台南增加職級欄位
                sqlString.Append("             Nrs_Level_Id, " & vbCrLf)
            End If
            sqlString.Append("             Create_User, " & vbCrLf)
            sqlString.Append("             Create_Time, " & vbCrLf)
            sqlString.Append("             Modified_User, " & vbCrLf)
            sqlString.Append("             Modified_Time) " & vbCrLf)
            sqlString.Append("VALUES      ( @Employee_Code, " & vbCrLf)
            sqlString.Append("              @Employee_Name, " & vbCrLf)
            sqlString.Append("              @Employee_En_Name, " & vbCrLf)
            sqlString.Append("              @Idno, " & vbCrLf)
            sqlString.Append("              @Dept_Code, " & vbCrLf)
            sqlString.Append("              @Email, " & vbCrLf)
            sqlString.Append("              @Assume_Effect_Date, " & vbCrLf)
            sqlString.Append("              @Assume_End_Date, " & vbCrLf)
            If Syscom.Comm.BASE.HospConfigUtil.HospConfig = Comm.BASE.HospConfigUtil.hospConfigList.Tw_Tnhosp Then
                '台南增加職級欄位
                sqlString.Append("             @Nrs_Level_Id, " & vbCrLf)
            End If
            sqlString.Append("              @Create_User, " & vbCrLf)
            sqlString.Append("              @Create_Time, " & vbCrLf)
            sqlString.Append("              @Modified_User, " & vbCrLf)
            sqlString.Append("              @Modified_Time) ")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Employee_Code", row.Item("userid"))
                    command.Parameters.AddWithValue("@Employee_Name", row.Item("username"))
                    command.Parameters.AddWithValue("@Employee_En_Name", row.Item("Employee_En_Name"))
                    command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                    command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                    command.Parameters.AddWithValue("@Email", row.Item("mail"))
                    command.Parameters.AddWithValue("@Assume_Effect_Date", Now.ToString("yyyy-MM-dd"))
                    command.Parameters.AddWithValue("@Assume_End_Date", "2099-12-31")
                    If Syscom.Comm.BASE.HospConfigUtil.HospConfig = Comm.BASE.HospConfigUtil.hospConfigList.Tw_Tnhosp Then
                        '台南增加職級欄位
                        command.Parameters.AddWithValue("@Nrs_Level_Id", row.Item("Nrs_Level_Id"))
                    End If
                    command.Parameters.AddWithValue("@Create_User", row.Item("creator_no"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    command.Parameters.AddWithValue("@Modified_User", row.Item("operator_no"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    command.Parameters.AddWithValue("@Password", "0F8A67072F8A4C9D")
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
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "     修改使用者 "

    ''' <summary>
    ''' 修改使用者
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-8-28</remarks>
    Public Function ModifyUser(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = _
            "update PUB_Employee set " & _
            "Employee_Name = @Employee_Name ,Employee_En_Name = @Employee_En_Name ,Idno = @Idno,  " & _
            "Dept_Code =@Dept_Code ,Email = @Email , " & _
            "Create_User =@Create_User," & _
            "Create_Time =@Create_Time,Modified_User = @Modified_User ,Modified_Time =@Modified_Time  "
            If Syscom.Comm.BASE.HospConfigUtil.HospConfig = Comm.BASE.HospConfigUtil.hospConfigList.Tw_Tnhosp Then
                '台南增加職級欄位
                sqlString &= ",Nrs_Level_Id =@Nrs_Level_Id          "
            End If
            sqlString &= "where     Employee_Code = @Employee_Code          "

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
                    command.Parameters.AddWithValue("@Employee_Code", row.Item("userid"))
                    command.Parameters.AddWithValue("@Employee_Name", row.Item("username"))
                    command.Parameters.AddWithValue("@Employee_En_Name", row.Item("Employee_En_Name"))
                    command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                    command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                    command.Parameters.AddWithValue("@Email", row.Item("mail"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("creator_no"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    command.Parameters.AddWithValue("@Modified_User", row.Item("operator_no"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    If Syscom.Comm.BASE.HospConfigUtil.HospConfig = Comm.BASE.HospConfigUtil.hospConfigList.Tw_Tnhosp Then
                        '台南增加職級欄位
                        command.Parameters.AddWithValue("@Nrs_Level_Id", row.Item("Nrs_Level_Id"))
                    End If

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
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "     刪除使用者 "

    ''' <summary>
    ''' 刪除使用者
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-8-28</remarks>
    Public Function DeleteUser(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            Dim userId As String = ""

            If ds.Tables.Count > 0 Then
                userId = ds.Tables("User").Rows(0).Item("userid").ToString
            End If

            If userId <> "" Then

                Dim sqlString As New System.Text.StringBuilder
                sqlString.Append("DELETE FROM ARM_Password " & vbCrLf)
                sqlString.Append("WHERE  Employee_Code = @Employee_Code ")
                sqlString.Append("; ")
                sqlString.Append("DELETE FROM PUB_Employee " & vbCrLf)
                sqlString.Append("WHERE  Employee_Code = @Employee_Code ")

                If connFlag Then
                    conn = getConnection()
                    conn.Open()
                End If

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Employee_Code", userId)

                    count = command.ExecuteNonQuery
                End Using
            Else
                count = 0
            End If

            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "     修改使用者密碼 "

    ''' <summary>
    ''' 修改使用者密碼
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Function ChangePassword(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            If CheckHasValue(ds, "User") Then

                Dim Employee_Code As String = ds.Tables(0).Rows(0).Item("userid")
                Dim Orgpass As String = ds.Tables(0).Rows(0).Item("orgpass")
                Dim Newpass As String = ds.Tables(0).Rows(0).Item("newpass")

                Dim sqlString As String = _
                "update Arm_Password set " & _
                "   Password =@NewPassword     " & _
                "where Employee_Code = @Employee_Code and Password =@OldPassword   "

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
                        command.Parameters.AddWithValue("@NewPassword", nvl(Newpass))
                        command.Parameters.AddWithValue("@Employee_Code", nvl(Employee_Code))
                        command.Parameters.AddWithValue("@OldPassword", nvl(Orgpass))

                        Dim cnt As Integer = command.ExecuteNonQuery
                        count = count + cnt
                    End Using
                Next
            End If
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
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

#End Region

#Region "     重設使用者密碼 "

    ''' <summary>
    ''' 修改使用者密碼
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Function ResetPassword(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0



            Dim Employee_Code As String = ds.Tables(0).Rows(0).Item("userid")
            Dim Newpass As String = ds.Tables(0).Rows(0).Item("newpass")

            Dim sqlString As String = _
            "update Arm_Password set " & _
            "   Password =@NewPassword     " & _
            "where Employee_Code = @Employee_Code    "

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
                    command.Parameters.AddWithValue("@NewPassword", nvl(Newpass))
                    command.Parameters.AddWithValue("@Employee_Code", nvl(Employee_Code))

                    Dim cnt As Integer = command.ExecuteNonQuery
                    If cnt = 0 Then
                        cnt = InsertPassword(row, conn)
                    End If

                    count = count + cnt
                End Using
            Next

            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
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

    ''' <summary>
    ''' 新增使用者密碼
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertPassword(ByVal dr As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0



            Dim Employee_Code As String = dr.Item("userid")
            Dim Newpass As String = dr.Item("newpass")

            Dim sqlString As String = _
                "INSERT INTO Arm_Password (Employee_Code, Password, Modified_Date) " & _
                "VALUES (@Employee_Code, @Password,@Modified_Date)"
          

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
                command.Parameters.AddWithValue("@Password", nvl(Newpass))
                command.Parameters.AddWithValue("@Employee_Code", nvl(Employee_Code))
                command.Parameters.AddWithValue("@Modified_Date", CDate(currentTime))

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
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
#End Region

#Region "     查詢使用者 "

    ''' <summary>
    ''' 查詢使用者
    ''' </summary>
    ''' <param name="employeeCode" ></param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function QueryUserPassword(ByVal employeeCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT * " & vbCrLf)
            sqlString.Append("FROM   ARM_Password " & vbCrLf)
            sqlString.Append("WHERE  Employee_Code = @Employee_Code " & vbCrLf)

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Employee_Code", employeeCode)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("ARM_Password")
                adapter.Fill(ds, "ARM_Password")
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

    ''' <summary>
    ''' 取得SQL連線
    ''' </summary> 
    ''' <remarks>by Sean.Lin on 2013-7-18</remarks>
    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

#End Region

End Class
