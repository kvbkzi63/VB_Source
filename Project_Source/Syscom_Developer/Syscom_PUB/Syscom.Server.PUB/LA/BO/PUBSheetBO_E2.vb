'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBSheetBO_E2.vb
'*              Title:	表單維護
'*        Description:	表單維護-查詢，增加，修改，刪除，清除，另存新檔，明細維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Yunfei
'*        Create Date:	2009/07/24
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports System.Text
Imports Syscom.Server.BO
Imports Syscom.Server.CMM

Public Class PUBSheetBO_E2
    Inherits PubSheetBO
    Dim tableName1 As String = "PUB_SYSCODE"
    Private Shared myInstance As PUBSheetBO_E2

    Public Overloads Shared Function getInstance() As PUBSheetBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBSheetBO_E2()
        End If
        Return myInstance
    End Function
    ''' <summary>
    ''' 查詢表單資料
    ''' </summary>
    ''' <param name="strSheetCode">表單代碼</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBSheetByCond(ByVal strSheetCode As String) As DataSet
        Dim strSql As New StringBuilder
        Dim ds As Data.DataSet
        strSql.Append("Select A.*,B.Code_Name as Send_System_Name, ")
        strSql.Append("C.Code_Name as Separate_Rule_Name,")
        strSql.Append("D.Code_Name as Sheet_Type_Name,")
        strSql.Append("E.Code_Name as Print_Form_Name from ")
        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append("A")
        strSql.Append(" left join ").Append(tableName1).Append(" ").Append(" B on (A.Send_System_Id = B.Code_Id and B.Type_Id =53 and B.Dc='N')")
        strSql.Append(" left join ").Append(tableName1).Append(" ").Append(" C on (A.Separate_Rule_Id = C.Code_Id and C.Type_Id =54 and C.Dc='N')")
        strSql.Append(" left join ").Append(tableName1).Append(" ").Append(" D on (A.Sheet_Type_Id = D.Code_Id and D.Type_Id =55 and D.Dc='N')")
        strSql.Append(" left join ").Append(tableName1).Append(" ").Append(" E on (A.Print_Form_Id = E.Code_Id and E.Type_Id =56 and E.Dc='N')")

        strSql.Append(" Where  1=1 ")
        If strSheetCode.Trim <> "" Then
            strSql.Append(" AND A.Sheet_Code = '").Append(strSheetCode).Append("' ")
        End If
        strSql.Append(" order by A.Sheet_Code ")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

#Region "20090703 PUBSheetBO 共用代碼檔維護 by Add jianhui"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strLoginID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBSheetByCV(ByVal strLoginID As String) As DataSet
        Dim strSql As New StringBuilder
        Dim ds As Data.DataSet
        strSql.Append("select Sheet_Code , Sheet_Name  ")
        strSql.Append("from PUB_Sheet  B")
        strSql.Append("  where  B.Dept_Code in ")
        strSql.Append("	(")
        strSql.Append("		select Dept_Code   ")
        strSql.Append(" 		from PUB_Employee  ")
        strSql.Append(" Where  1=1 ")
        If strLoginID.Trim <> "" Then
            strSql.Append(" AND Employee_Code = '").Append(strLoginID).Append("'	) ")
        End If
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' 通过 登陆者的 部门ID  取code name
    ''' </summary>
    ''' <param name="strDeptId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBSheetByCode_L(ByVal strDeptId As String) As DataSet
        Dim strSql As New StringBuilder
        Dim ds As Data.DataSet
        'modified by mark 2010-06-03 begin
        'strSql.Append("select Sheet_Code, Sheet_Name  ")
        'strSql.Append(" from PUB_Sheet PS")
        'strSql.Append("  where 1=1 ")

        'If strDeptId.Trim <> "" Then
        '    Dim str As String = Mid(strDeptId, 1, 2)

        '    If str = "A5" Then
        '        strSql.Append(" and Sheet_Type_Id = '2' ")
        '    Else
        '        strSql.Append(" AND Dept_Code = '").Append(strDeptId).Append("'	 ")
        '    End If

        'Else
        '    strSql.Append(" AND Dept_Code = '").Append(strDeptId).Append("'	")
        'End If
        strSql.Append(" ").Append("Select distinct PS.Sheet_Code, PS.Sheet_Name  ")
        strSql.Append(" ").Append("From PUB_Sheet PS")
        strSql.Append(" ").Append(" join PUB_Sheet_Detail PSD ON PS.Sheet_Code = PSD.Sheet_Code")
        'modified by mark zhang 2011/03/08 begin
        'strSql.Append(" ").Append(" join PUB_Order_Examination POE ON (PSD.Order_Code = POE.Order_Code AND POE.Is_Scheduled = 'Y')")
        strSql.Append(" ").Append(" join PUB_Order_Examination POE ON (PSD.Order_Code = POE.Order_Code )")
        'modified by mark zhang 2011/03/08 end
        strSql.Append(" ").Append("where 1=1 ")
        strSql.Append(" ").Append(" AND ISNULL(PS.Dc, 'N') != 'Y' ")
        strSql.Append(" ").Append(" AND ISNULL(PSD.Dc, 'N') != 'Y' ")

        'If HospUtil.isGeneral = True Then      '2014-03-24 by Wendy Yang : 斗六皆不卡科部權限
        '    If strDeptId.Trim.Equals("") Then
        '        strSql.Append(" AND 1<>1")
        '    ElseIf Not strDeptId.Trim.StartsWith("A5") Then
        '        strSql.Append(" AND PS.Dept_Code = '").Append(strDeptId).Append("'")
        '    End If
        'End If
        strSql.Append(" ").Append(" order by PS.Sheet_Code ")
        'modified by mark 2010-06-03 end
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "20091207 PUBSheetBO 特殊屬性主檔維護 查詢表單資料for ComboBox by Add Mark Zhang"
    ''' <summary>
    ''' 查詢表單資料for ComboBox
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBSheetAllForComboBox() As DataSet
        Dim strSql As New StringBuilder
        Dim ds As Data.DataSet
        strSql.Append(" Select RTRIM(Sheet_Code) AS Sheet_Code,RTRIM(Sheet_Name) AS Sheet_Name")
        strSql.Append(" From ").Append(tableName)
        strSql.Append(" Where DC = 'N' ")
        strSql.Append(" Order by Sheet_Code ")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function
#End Region
#Region "20091209 PUBSheetBO 查詢表單資料for 可選擇表單grid by Add tony"
    ''' <summary>
    ''' 查詢表單資料for 可選擇表單grid
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBSheetSlecet(ByVal strBloodSpecimen As String) As DataSet
        Dim strSql As New StringBuilder
        Dim ds As Data.DataSet
        strSql.Append(" ").Append(" select * ")
        strSql.Append(" ").Append(" From ")
        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append(" A ")
        strSql.Append(" ").Append(" Where A.DC = 'N'")
        strSql.Append(" ").Append(" and A.Sheet_Type_Id =1")
        If strBloodSpecimen.Trim = "Y" Then
            strSql.Append(" ").Append(" and A.Sheet_Code NOT IN (SELECT Sheet_Code FROM PUB_Sheet_Merge as B where B .Blood_Specimen =(select Config_Value from PUB_Config where Config_Name = 'PUB_Blood_Specimen') )")
        End If
        If strBloodSpecimen.Trim = "N" Then
            strSql.Append(" ").Append(" and A.Sheet_Code NOT IN (SELECT Sheet_Code FROM PUB_Sheet_Merge as B where B .Blood_Specimen ='')")
        End If
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function
#End Region
#Region "20091209 PUBSheetBO 查詢表單資料for 彙總表單grid by Add tony"
    ''' <summary>
    ''' 查詢表單資料for 彙總表單grid
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBSheetMerge(ByVal strPubSheetCode As String, ByVal strBloodSpecimen As String) As DataSet
        Dim strSql As New StringBuilder
        Dim ds As Data.DataSet
        strSql.Append(" ").Append(" select DISTINCT A.Sheet_Code  ,A .Merge_Mark ")
        strSql.Append(" ").Append(" into #Temp01 ")
        strSql.Append(" ").Append(" from ")
        strSql.Append(" ").Append(" (select * from PUB_Sheet_Merge as B")
        strSql.Append(" ").Append("where 1=1")
        If strBloodSpecimen.Trim = "Y" Then
            strSql.Append(" ").Append("and B .Blood_Specimen =(select Config_Value from PUB_Config where Config_Name = 'PUB_Blood_Specimen')")
        End If
        If strBloodSpecimen.Trim = "N" Then
            strSql.Append(" ").Append("and B .Blood_Specimen is null ")
        End If
        strSql.Append(" ").Append(") A;")
        strSql.Append(" ").Append("SELECT D.* ,")
        strSql.Append(" ").Append("E.Sheet_Name as Sheet_Name")
        strSql.Append(" ").Append("FROM  #Temp01 D")
        strSql.Append(" ").Append("LEFT JOIN PUB_Sheet AS E ON E.Sheet_Code =D.Sheet_Code")
        strSql.Append(" ").Append("WHERE(1 = 1)")
        strSql.Append(" ").Append(" AND D.Sheet_Code NOT IN (SELECT B .Sheet_Code   FROM PUB_Sheet_Detail AS B WHERE Sheet_Code ='" & strPubSheetCode & "')")
        strSql.Append(" ").Append("and Merge_Mark in (SELECT DISTINCT  C.Merge_Mark    FROM PUB_Sheet_Merge  AS C WHERE Sheet_Code ='" & strPubSheetCode & "')")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function
#End Region
#Region "20100809 PUBSheetBO 查詢表單資料for 排程清單--表單類別 by Add tor"
    ''' <summary>
    ''' 查詢表單資料for 彙總表單grid
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function querySheetCode(ByVal strPubSheetCode As String) As DataSet
        Dim strSql As New StringBuilder
        Dim ds As Data.DataSet
        strSql.Append(" ").Append(" select distinct A.Sheet_Code,A.Sheet_Name from PUB_Sheet  A ")
        strSql.Append(" ").Append(" inner join PUB_Sheet_Detail B on A.Sheet_Code =B.Sheet_Code ")
        strSql.Append(" ").Append(" inner join PUB_Order_Examination C on C.Order_Code =B.Order_Code  and  C.Is_Scheduled = 'Y' ")
        strSql.Append(" ").Append("where 1=1 ")
        If Not String.IsNullOrEmpty(strPubSheetCode) Then
            If strPubSheetCode.Length > 1 Then
                If Not (strPubSheetCode.Substring(0, 2).Equals("A5") Or strPubSheetCode.Substring(0, 2).Equals("M0") Or strPubSheetCode.Substring(0, 2).Equals("M5")) Then
                    strSql.Append(" ").Append("and  A.Dept_Code ='").Append(strPubSheetCode).Append("'")
                End If
            Else
                strSql.Append(" ").Append("and  A.Dept_Code ='").Append(strPubSheetCode).Append("'")
            End If
        End If
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "20160813 PUBSheetBO 檢驗單資料for ComboBox by Add Remote"
    ''' <summary>
    ''' 查詢表單資料for ComboBox
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBSheetCode() As DataSet
        Dim strSql As New StringBuilder
        Dim ds As Data.DataSet
        strSql.Append(" Select RTRIM(Sheet_Code) AS Sheet_Code,RTRIM(Sheet_Name) AS Sheet_Name")
        strSql.Append(" From  PUB_Sheet")
        strSql.Append(" Where Lab_Group_Id ='B' and DC<>'Y' ")
        strSql.Append(" Order by Sheet_Code ")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function
#End Region


End Class
