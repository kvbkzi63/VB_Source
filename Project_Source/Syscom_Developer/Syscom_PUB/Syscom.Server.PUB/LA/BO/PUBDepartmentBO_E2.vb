'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBDepartmentBO_E2.vb
'*              Title:	科室維護
'*        Description:	科室維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	ming
'*        Create Date:	2009/06/16
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

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

Public Class PUBDepartmentBO_E2
    Inherits PubDepartmentBO
    Private Shared myInstance As PUBDepartmentBO_E2
    Public Overloads Shared Function GetInstance() As PUBDepartmentBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBDepartmentBO_E2()
        End If
        Return myInstance
    End Function
    ''' <summary>
    ''' 查詢科室維護
    ''' </summary>
    ''' <param name="strDeptCode">科別代碼</param>
    ''' <param name="strDeptName">科別名稱</param>
    ''' <param name="strDeptEnName">科別英文</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>科別代碼完全匹配;科別名稱與科別英文左匹配</remarks>
    Public Overloads Function queryPUBDepartmentByCond(ByVal strDeptCode As String, ByVal strDeptName As String, ByVal strDeptEnName As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.AppendLine("select  Dept_Code,")
        strSql.AppendLine("     Short_Name,")
        strSql.AppendLine("      Dept_Name,")
        strSql.AppendLine("      Dept_En_Name,")
        strSql.AppendLine("      Is_Reg_Dept,")
        strSql.AppendLine("      Sort_Value,")
        strSql.AppendLine("      Emg_Dept_Name,")
        strSql.AppendLine("      Emg_Dept_En_Name,")
        strSql.AppendLine("      Is_Emg_Dept,")
        strSql.AppendLine("      Emg_Sort_Value,")
        strSql.AppendLine("      Ipd_Dept_Name,")
        strSql.AppendLine("      Ipd_Dept_En_Name,")
        strSql.AppendLine("      Is_Ipd_Dept,")
        strSql.AppendLine("      Ipd_Sort_Value,")
        strSql.AppendLine("      NHI_Opd_Dept_Code,")
        strSql.AppendLine("      NHI_Ipd_Dept_Code,")
        strSql.AppendLine("      Belong_Dept_Code,")
        strSql.AppendLine("      Upper_Dept_Code,")
        strSql.AppendLine("      Dept_Level_Id,")
        '承毅
        strSql.AppendLine("      Acc_Dept,")
        strSql.AppendLine("      Is_Nrs_Station,")
        strSql.AppendLine("      Dc,")
        strSql.AppendLine("      Create_User,")
        strSql.AppendLine("     Right('0000'+ltrim(dbo.AdToRocDate (Create_Time)),9) AS  'Create_Time'  ,")
        strSql.AppendLine("      Modified_User,")
        strSql.AppendLine("    Right('0000'+ltrim(dbo.AdToRocDate (Modified_Time)),9) AS  'Modified_Time'   ,")
        strSql.AppendLine("      Effect_Date,")
        strSql.AppendLine("      End_Date ")
        strSql.Append("  from " & tableName)
        strSql.Append(" Where 1=1 ")
        If strDeptCode.Trim <> "" Then
            strSql.Append(" AND Dept_Code = '").Append(strDeptCode).Append("' ")
        End If
        If strDeptName.Trim <> "" Then
            strSql.Append(" AND Dept_Name like '").Append(strDeptName).Append("%' ")
        End If
        If strDeptEnName.Trim <> "" Then
            strSql.Append(" AND Dept_En_Name like '").Append(strDeptEnName).Append("%' ")
        End If
        strSql.Append(" Order By Dept_Code")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function


    Public Function queryPUBDepartmentByDeptCodeSAndDeptCodeE(ByVal strDeptCodeS As String, ByVal strDeptCodeE As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("SELECT ")
        strSql.Append(" ").Append("A.Dept_Code,A.Dept_Name,B.Dept_Name AS BeLong_Dept_Code ")
        strSql.Append(" ").Append("FROM " + tableName + " A ")
        strSql.Append(" ").Append("LEFT JOIN PUB_Department B ")
        strSql.Append(" ").Append("ON A.BeLong_Dept_Code = B.Dept_Code ")
        strSql.Append(" ").Append("WHERE A.DC != 'Y' order by Dept_Code ")

        If strDeptCodeS.Trim <> "" Then
            strSql.Append("AND A.Dept_Code >= '" + strDeptCodeS.Trim + "' ")
        End If

        If strDeptCodeE.Trim <> "" Then
            strSql.Append("AND A.Dept_Code <= '" + strDeptCodeE.Trim + "' ")
        End If

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function

#Region "20090703 PUBDepartmentBO_E2 科室檔維護 by Add Syscom Yunfei"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentCA() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select  Dept_Code as code,Dept_Name as dept_name,(REPLACE(CONVERT(nvarchar,Dept_Code),' ' ,'') + ' - ' + Dept_Name) as dept_name_cb  from " & tableName)
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

    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentByIsRegDept() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select  Dept_Code as code,Dept_Name as dept_name,(REPLACE(CONVERT(nvarchar,Dept_Code),' ' ,'') + ' - ' + Dept_Name) as dept_name_cb  from " & tableName & " where Is_Reg_Dept= 'Y' ")
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

#Region "20090708 病歷量的審查設定基本檔維護中 科系資料來源 by Add Syscom Johsn"
    ''' <summary>
    ''' 取得科系資料來源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentCode() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select RTRIM(Dept_Code) as Dept_Code, RTRIM(Dept_Name) as Dept_Name, RTRIM(Dept_En_Name) as Dept_En_Name, RTRIM(Short_Name) as Short_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  DC='N' and RTRIM(Dept_Code) = RTRIM(Belong_Dept_Code) ")
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

#Region "20090724 查詢批價項目作業  就醫科別資料來源 by Add Johsn"
    ''' <summary>
    ''' 取得就醫科別資料來源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentCodeAndName() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select RTRIM(Dept_Code) as Dept_Code, RTRIM(Dept_Name) as Dept_Name, RTRIM(Dept_En_Name) as Dept_En_Name, RTRIM(Short_Name) as Short_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  DC='N' ")
            content.Append(" Order By Dept_Code")
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
#Region "20090826 牙醫師週班表維護作業 取得牙科治療 strDeptKind=7 add by Johsn"
    ''' <summary>
    ''' 取得科別資料來源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentByDeptType(ByVal strDeptType As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As StringBuilder = New StringBuilder()
            sqlString.Append(" Select RTRIM(Dept_Code) as Dept_Code, RTRIM(Dept_Name) as Dept_Name, RTRIM(Dept_En_Name) as Dept_En_Name, RTRIM(Short_Name) as Short_Name ")
            sqlString.Append(" From " & tableName)
            sqlString.Append(" Where  DC='N'   ")
            sqlString.Append(" And  Dept_Code Like '" + strDeptType + "%' ")
            sqlString.Append(" And len(Dept_Code) < 4 ")
            sqlString.Append(" Order By Dept_Code ")
            command.CommandText = sqlString.ToString
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

#Region "20090805 平均看診時間維護  科別資料來源 by Add Mark"
    ''' <summary>
    ''' 取得科別資料來源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentEffectCodeAndName() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select RTRIM(Dept_Code) as Dept_Code, RTRIM(Dept_Name) as Dept_Name, RTRIM(Dept_En_Name) as Dept_En_Name, RTRIM(Short_Name) as Short_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  DC='N' AND '")
            content.Append(Now.ToString("yyyy/MM/dd"))
            content.Append("' Between Effect_Date AND End_Date")
            content.Append(" Order By Dept_Code")
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
#Region "20090901 PUBDepartmentBO_E1 科室檔維護--查詢小科 by Add XaJian"
    ''' <summary>
    ''' 獲取Department資料 
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDeptCode() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select RTRIM(Dept_Code) as Dept_Code, RTRIM(Dept_Name) as Dept_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  DC='N' and RTRIM(Dept_Code) != RTRIM(Belong_Dept_Code) ")
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

#Region "20090910 門診診斷代號開立次數排行表--初始化科別 by Add XaJianming"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDeptCodeName() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()

            content.Append(" Select RTRIM(Dept_Code) as Dept_Code, RTRIM(Dept_Name) as Dept_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where RTRIM(Dept_Code) = RTRIM(Belong_Dept_Code) ")

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

    Private Overloads Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

#Region "20090914 emrDB PUBDepartmentBO_E2 科室檔維護 by Add Syscom Yunfei"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentCA2() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection2(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select RTRIM(Dept_Code) as code,RTRIM(Dept_Name) as dept_name,RTRIM(REPLACE(CONVERT(nvarchar,Dept_Code),' ' ,'') + ' - ' + Dept_Name) as dept_name_cb  from " & tableName)
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

    Private Overloads Function getConnection2() As IDbConnection
        Return SQLConnFactory.getInstance.getEmrDBSqlConn
    End Function
#End Region

#Region "20090923 疾病分類住院資料申請--初始化科別 by Add ChenYang"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDeptCodeNameCA3() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()

            content.Append(" Select RTRIM(Dept_Code) as Dept_Code, RTRIM(Dept_Name) as Dept_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  DC='N' ")

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
#Region "200901010 轉診轉出--建議轉診科別 by Add tor"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDeptHealthOpdDeptCodeName_L() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT DISTINCT Rtrim(Insu_Dept_Code)      AS Dept_Code, " & vbCrLf)
            sqlString.Append("                Rtrim(Insu_Dept_Code_Name) AS Dept_Name " & vbCrLf)
            sqlString.Append("FROM   PUB_Insu_Dept " & vbCrLf)
            sqlString.Append("WHERE  DC = 'N' ")

            command.CommandText = sqlString.ToString
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

#Region "20091012 查詢 查詢科別健保碼   by Add Tor"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDeptHealthByCode_L(ByVal code As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()

            content.Append(" SELECT D.Health_Opd_Dept_Code, D.Dept_Name FROM PUB_Department D  ")
            content.Append(" WHERE D.Dept_Code = '" & code.Trim & "' ")
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

#Region "20091225 查詢 轉介科別  add by Fan"
    Function queryPUBDeptCodeAndNameByCodeDC() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()

            content.Append(" select D.Dept_Code   ")
            content.Append(" ,D.Dept_Name ")
            content.Append(" from PUB_Department As D ")
            content.Append(" where D.Dept_Code = D.Belong_Dept_Code  ")
            content.Append(" and   D.DC ='N' ")
            content.Append(" and  SUBSTRING (D.Dept_Code ,1,1)='5' ")

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
#Region "20100205 查詢 轉介科別  add by tony"
    Function queryRefferalDept() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" select D.Dept_Code   ")
            content.Append(" ,D.Dept_Name ")
            content.Append(" from PUB_Department As D ")
            content.Append(" where D.Dept_Code <> D.Belong_Dept_Code  ")
            content.Append(" and   D.DC ='N' ")
            content.Append(" and  D.Is_Reg_Dept ='Y' ")
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
#Region "20100303 獲得所屬部門下的所有部門   by Add ming"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentByCode_L(ByVal code As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()

            content.Append(" SELECT Dept_Code,Dept_Name,Dept_En_Name FROM PUB_Department D  ")
            content.Append(" WHERE D.DC='N' AND D.Belong_Dept_Code = (SELECT Belong_Dept_Code FROM PUB_Department where Dept_Code='" + code.Trim + "')  ")
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

#Region "20100329 健檢套餐報價作業定價頁簽科別combobox by Add tony"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentForSellCombo_L() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()

            content.Append(" SELECT Dept_Code,Dept_Name FROM PUB_Department D  ")
            content.Append(" WHERE D.DC='N' AND D.Is_Reg_Dept ='Y'")
            content.Append(" and D.Dept_Code IN ('12','42')")
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

#Region "20100526  次專科基本檔所屬科別combobox資料  add by liuye"
    Function queryPUBDepartmentEffectByColumnValue(ByVal strColumnName As String(), ByVal strColumnValue As Object()) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlconn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim Command As SqlCommand = sqlconn.CreateCommand()
            Dim content As New StringBuilder
            content.Append(" SELECT Dept_Code,Dept_Name FROM PUB_Department WHERE CAST(GETDATE() AS DATE) BETWEEN Effect_Date AND End_Date ").Append(vbCrLf)
            If strColumnName.Count > 0 Then
                For i As Integer = 0 To strColumnName.Count - 1
                    If strColumnName(i).Trim <> "" Then
                        content.Append(" and ").Append(strColumnName(i) & "=@" & strColumnName(i)).Append(vbCrLf)
                    End If
                Next
            End If
            Command.CommandText = content.ToString()
            If strColumnName.Count > 0 Then
                For i As Integer = 0 To strColumnName.Count - 1
                    If strColumnName(i).Trim <> "" Then
                        Command.Parameters.AddWithValue("@" & strColumnName(i), strColumnValue(i))
                    End If
                Next
            End If
            Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
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

#Region "20100608  科室維護  add by tima_qin"
    ''' <summary>
    ''' 診別查詢
    ''' </summary>
    ''' <param name="strDeptCode">科別代碼</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function queryPubDeptSect(ByVal strDeptCode As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" Select B.* ")
        strSql.Append(" From PUB_Department A,PUB_Dept_Sect B")
        strSql.Append(" Where A.Dept_Code = B.Dept_Code  and B.Dc ='N'  ")
        If strDeptCode.Trim <> "" Then
            strSql.Append(" AND A.Dept_Code = '").Append(strDeptCode.Trim).Append("' ")
        End If
        strSql.Append("Order By B.Section_Id ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet("PUB_Dept_Sect")
                adapter.Fill(ds, "PUB_Dept_Sect")
                adapter.FillSchema(ds, Data.SchemaType.Mapped, "PUB_Dept_Sect")
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function
#End Region
#Region "20100622常用維護科別資料來源  add by coco"
    Function queryRefferalDeptOMO() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" select D.Dept_Code   ")
            content.Append(" ,D.Dept_Name ")
            content.Append(" from PUB_Department As D ")
            content.Append(" where 1=1  ")
            content.Append(" and   D.DC ='N' ")
            content.Append(" and  D.Is_Reg_Dept ='Y' ")
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

#Region "20110124 PUBDepartmentBO_E2 OHM家醫科健檢報告列印寄發ComboBox資料來源 Add by Mark Zhang"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentForCobomBox() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select  Dept_Code,Dept_Name,(REPLACE(CONVERT(nvarchar,Dept_Code),' ' ,'') + ' ' + Dept_Name) as code_name_cb  from " & tableName)
            'add mark zhang 2011/02/11 begin 所屬單位下拉選單資料過濾掉可掛號之科室
            content.Append(" where is_reg_dept= 'N'")
            'add mark zhang 2011/02/11 end
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

#Region "20110216 候床查詢 科別combox by Add johsn wu"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentForQueryWaitingBed() As DataSet
        Try
            Dim strCond As String = "'01', '02', '03', '04', '05', '07', '08','09', '0A', '10', '11', '12', '13', '14', '18', '21', '22', '23', '24', '25', " & _
                                    "'26', '27', '31', '32', '33', '34', '35', '37', '41', '42', '43', '51', '52', '61', '71', '80', '91', '92', '99'"

            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()

            content.Append(" SELECT RTRIM(Dept_Code) As Dept_Code , RTRIM(Dept_Name) As Dept_Name FROM PUB_Department D  ").Append(vbCrLf)
            content.Append(" WHERE D.DC='N'                                                   ").Append(vbCrLf)
            content.Append(" AND D.Dept_Code IN (" & strCond & ")                             ").Append(vbCrLf)
            command.CommandText = content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "20110907 急診掛號病人表  離院型態資料來源  Add by prince"
    ''' <summary>
    ''' 取得離院型態資料來源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentCodeAndName1() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select distinct RTRIM(Dept_Code) as Dept_Code, RTRIM(Dept_Name) as Dept_Name")
            content.Append(" From " & tableName)
            content.Append(" Where   DC='N' ")
            content.Append(" And Is_Emg_Dept ='Y'")
            content.Append(" Order By Dept_Code")
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

#Region "20120326   申復爭議作業  Add by Runxia"
    ''' <summary>
    ''' 申復爭議作業
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentCodeForIHD() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select distinct RTRIM(Dept_Code) as Dept_Code, RTRIM(Dept_Name) as Dept_Name")
            content.Append(" From " & tableName)
            content.Append(" Where  Is_Ipd_Dept ='Y'")
            content.Append(" Order By Dept_Code")
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
#Region "     科室/團隊查詢 "

    ''' <summary>
    ''' 科室/團隊查詢
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by liuye on 2012-4-2</remarks>
    Public Function queryPUBDepartmentCodeIsIpdDeptY(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT Dept_Code, " & vbCrLf)
            varname1.Append("       IPD_Dept_Name as Dept_Name " & vbCrLf)
            varname1.Append("FROM   PUB_Department " & vbCrLf)
            varname1.Append("WHERE  DC = 'N' " & vbCrLf)
            varname1.Append("       AND Is_Ipd_Dept = 'Y' ")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = varname1.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
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

#End Region

#Region "20120821 急診片語維護  Add by prince"
    ''' <summary>
    ''' 常用維護科別資料來源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBDepartmentEMO() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("SELECT Dept_Code, " & vbCrLf)
            content.Append("       Emg_Dept_Name " & vbCrLf)
            content.Append("FROM   PUB_Department " & vbCrLf)
            content.Append("WHERE  Is_Emg_Dept = 'Y' " & vbCrLf)
            content.Append("       AND DC = 'N' " & vbCrLf)
            content.Append("ORDER  BY Emg_Sort_Value ")
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
End Class


