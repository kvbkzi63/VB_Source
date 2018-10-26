Imports System.Data.SqlClient
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP

Public Class PubSheetDisplayOrderBO_E1
    Inherits PubSheetDisplayOrderBO

#Region "########## getInstance ##########"

    Private Shared instance As PubSheetDisplayOrderBO_E1

    Public Overloads Shared Function getInstance() As PubSheetDisplayOrderBO_E1
        If instance Is Nothing Then
            instance = New PubSheetDisplayOrderBO_E1
        End If
        Return instance
    End Function

    Public Sub New()
    End Sub

#Region "查詢"""
    ''' <summary>
    ''' 表單開單顯示維護查詢
    ''' </summary>
    ''' <param name="Sheet_Sub_Display">表單顯示次分類</param>
    ''' <param name="Order_Code">醫令代碼</param>
    ''' <param name="Order_Display_Code">醫令顯示代碼</param>
    '''  <param name="Order_Display_Name">醫令顯示代碼名稱</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
#Region "查詢"
    Public Function QueryPubSheetDisplayOrderByCond(ByVal Sheet_Sub_Display As String, ByVal Order_Code As String, ByVal Order_Display_Code As String, ByVal Order_Display_Name As String) As System.Data.DataSet
        Dim ds As Data.DataSet


        Dim varname1 As New StringBuilder

        varname1.AppendLine("SELECT Rtrim(a.Sheet_Sub_Display) + '-'")
        varname1.AppendLine("       + Rtrim(e.Sheet_Sub_Display_Name) AS Sheet_sub_display_Name,")
        varname1.AppendLine("       a.Order_Display_Code,")
        varname1.AppendLine("       a.Order_Display_Name,")
        varname1.AppendLine("       a.Order_Code,")
        varname1.AppendLine("       isnull(Rtrim(a.Default_Main_Body_Site_Code) + '-' + Rtrim(b.Body_Site_Name ),'')        AS Default_Main_Body_Site_Code_Name,")
        varname1.AppendLine("       isnull(Rtrim(a.Default_Body_Site_Code) + '-' + Rtrim(c.Body_Site_Name),''   )      AS Default_Body_Site_Code_Name,")
        varname1.AppendLine("       isnull(Rtrim(a.Default_Side_Id) + '-'  + Rtrim(d.Code_Name ),'')             AS Default_Side_Id_Name,")
        varname1.AppendLine("	   a.Sheet_Sub_Display,")
        varname1.AppendLine("	   a.Default_Main_Body_Site_Code,")
        varname1.AppendLine("	   a.Default_Body_Site_Code,")
        varname1.AppendLine("	   a.Default_Side_Id,")
        varname1.AppendLine("	   a.Display_Sort_Value")
        varname1.AppendLine("FROM   PUB_Sheet_Display_Order a")
        varname1.AppendLine("       LEFT JOIN PUB_Body_Site b")
        varname1.AppendLine("              ON a.Default_Main_Body_Site_Code = b.Body_Site_Code")
        varname1.AppendLine("       LEFT JOIN PUB_Body_Site c")
        varname1.AppendLine("              ON a.Default_Body_Site_Code = c.Body_Site_Code")
        varname1.AppendLine("       LEFT JOIN pub_syscode d")
        varname1.AppendLine("              ON a.Default_Side_Id = d.Code_Id")
        varname1.AppendLine("                 AND d.Type_Id = 48")
        varname1.AppendLine("       INNER JOIN PUB_Sheet_Display e")
        varname1.AppendLine("       ON a.Sheet_Sub_Display = e.Sheet_Sub_Display")
        varname1.AppendLine("WHERE  1 = 1 ")
        varname1.AppendLine("")




        If Sheet_Sub_Display.Trim <> "" Then
            varname1.Append(" AND a.Sheet_Sub_Display = '").Append(Sheet_Sub_Display.Trim).Append("' ")
        End If

        If Order_Code.Trim <> "" Then
            varname1.Append(" AND a.Order_Code = '").Append(Order_Code.Trim).Append("' ")
        End If

        If Order_Display_Code.Trim <> "" Then
            varname1.Append(" AND a.Order_Display_Code = '").Append(Order_Display_Code.Trim).Append("' ")
        End If

        If Order_Display_Name.Trim <> "" Then
            varname1.Append(" AND a.Order_Display_Name = '").Append(Order_Display_Name.Trim).Append("' ")
        End If

        varname1.Append("Order By a.Sheet_Sub_Display ,a.Order_Code , a.Order_Display_Code,  a.Order_Display_Name")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(varname1.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Throw ex

        End Try

        Return ds

    End Function
#End Region
#Region "查詢全部"
    Public Function QuerySheetDisplayOrderAll() As System.Data.DataSet
        Dim ds As Data.DataSet

        Dim varname1 As New System.Text.StringBuilder
        varname1.Append(" SELECT            a.*," & vbCrLf)
        varname1.Append("         b.order_name," & vbCrLf)
        varname1.Append("      c.Sheet_Sub_Display_Name" & vbCrLf)
        varname1.Append("FROM   PUB_Sheet_Display_Order a " & vbCrLf)
        varname1.Append("INNER JOIN pub_order b" & vbCrLf)
        varname1.Append("ON a.Order_Code = b.Order_Code" & vbCrLf)
        varname1.Append("INNER JOIN PUB_Sheet_Display c" & vbCrLf)
        varname1.Append("ON a.Sheet_Sub_Display = c.Sheet_Sub_Display" & vbCrLf)
        varname1.Append("AND b.Dc ='N'")
        varname1.Append("WHERE 1=1")

        varname1.Append("Order By a.Sheet_Sub_Display , a.Order_Display_Code ,a.Order_Code,  a.Order_Display_Name")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(varname1.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Throw ex

        End Try

        Return ds
    End Function
#End Region
#End Region

#Region "Combobox資料查詢"

    Public Function QueryPubSheetDisplayOrderCombodata(ByVal MainBodySite As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Dim ds As New DataSet

        Try

            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            Dim dt5 As DataTable

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim varname1 As New StringBuilder
            varname1.AppendLine("SELECT DISTINCT Sheet_Sub_Display, Sheet_Sub_Display_Name ")
            varname1.AppendLine("FROM PUB_Sheet_Display  ")
            varname1.AppendLine(" ")
            varname1.AppendLine(" ")
            varname1.AppendLine(" Where 1=1  ")
            varname1.Append("ORDER  BY Sheet_Sub_Display ")

            command.CommandText = varname1.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dt1 = New DataTable("UclCbo_PUB_Sheet_Sub_Display")
                adapter.Fill(ds, "UclCbo_PUB_Sheet_Sub_Display")
            End Using

            Dim varnamel2 As New StringBuilder
            varnamel2.AppendLine("SELECT DISTINCT a.Order_Code,b.Order_Name,a.Default_Main_Body_Site_Code,a.Default_Body_Site_Code,a.Default_Side_Id ")
            varnamel2.AppendLine("FROM PUB_Order_Examination a ")
            varnamel2.AppendLine("INNER JOIN PUB_Order b ")
            varnamel2.AppendLine("ON a.Order_Code = b.Order_Code ")
            varnamel2.AppendLine(" Where 1=1  ")
            varnamel2.Append("ORDER  BY Order_Code ")

            command.CommandText = varnamel2.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)

                dt2 = New DataTable("UclCbo_Order_Code")
                adapter.Fill(ds, "UclCbo_Order_Code")
            End Using

            Dim varname3 As New StringBuilder
            varname3.AppendLine("Select DISTINCT  a.Main_Body_Site_Code, b.Body_Site_Name")
            varname3.AppendLine("from PUB_Body_Site a")
            varname3.AppendLine("INNER JOIN PUB_Body_Site b")
            varname3.AppendLine("ON a.Main_Body_Site_Code=b.Body_Site_Code")
            varname3.AppendLine("")
            varname3.AppendLine("WHERE 1=1")
            varname3.Append("ORDER  BY Main_Body_Site_Code ")

            command.CommandText = varname3.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dt3 = New DataTable("UclCbo_Main_Body_Site_Code")
                adapter.Fill(ds, "UclCbo_Main_Body_Site_Code")
            End Using

            Dim varname4 As New StringBuilder
            varname4.AppendLine("SELECT DISTINCT")
            varname4.AppendLine("       d.Body_Site_Code as BodySite,")
            varname4.AppendLine("       d.Body_Site_Name as BodySiteName,")
            varname4.AppendLine("       c.Main_Body_Site_Code as MainBodySite")
            varname4.AppendLine("FROM   (SELECT DISTINCT a.Main_Body_Site_Code,")
            varname4.AppendLine("                        b.Body_Site_Name")
            varname4.AppendLine("        FROM   PUB_Body_Site a")
            varname4.AppendLine("        INNER JOIN PUB_Body_Site b")
            varname4.AppendLine("        ON a.Body_Site_Code = b.Main_Body_Site_Code) c")
            varname4.AppendLine("LEFT JOIN PUB_Body_Site d")
            varname4.AppendLine("ON c.Main_Body_Site_Code = d.Main_Body_Site_Code ")
            varname4.AppendLine("WHERE 1=1")
            varname4.AppendLine("    AND d.Main_Body_Site_Code<>d.Body_Site_Code")

            If MainBodySite.Trim <> "" Then
                varname4.Append(" AND c.Main_Body_Site_Code = '").Append(MainBodySite.Trim).Append("' ")
            End If

            varname4.Append("ORDER  BY MainBodySite,BodySite ")



            command.CommandText = varname4.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dt4 = New DataTable("UclCbo_Body_Site_Code")
                adapter.Fill(ds, "UclCbo_Body_Site_Code")
            End Using

            Dim varname5 As New StringBuilder
            varname5.AppendLine("select Code_Id,Code_Name")
            varname5.AppendLine("from PUB_Syscode")
            varname5.AppendLine("WHERE Type_Id=48")
            varname5.AppendLine("AND Dc ='N'")
            varname5.AppendLine("Order by Sort_Value")
            varname5.AppendLine("")
            varname5.AppendLine("")


            command.CommandText = varname5.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dt5 = New DataTable("UclCbo_Sch_Code_Id")
                adapter.Fill(ds, "UclCbo_Sch_Code_Id")
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

#Region "          是否重複資料查詢"
    Public Function QuerySheetDisplayOrderCheckDS(ByVal strOrderCode As String, ByVal strMainBodySite As String, ByVal strBodySite As String, ByVal strSiteID As String) As System.Data.DataSet
        Dim ds As Data.DataSet

        Dim Content As New StringBuilder
        Content.AppendLine("declare @order_code as varchar(20)= '" & strOrderCode & "'")
        Content.AppendLine("declare @main_body_site as varchar(20)= '" & strMainBodySite & "'")
        Content.AppendLine("declare @body_site as varchar(20)= '" & strBodySite & "'")
        Content.AppendLine("declare @side_id as varchar(20)= '" & strSiteID & "'")
        Content.AppendLine("")
        Content.AppendLine("select rtrim(a.Sheet_Sub_Display) +'-'+  b.Sheet_Sub_Display_Name as sub_displsy_name,")
        Content.AppendLine(" rtrim(Order_Display_Code)+'-'+  Order_Display_Name  as order_display_name from PUB_Sheet_Display_Order a")
        Content.AppendLine("left join PUB_Sheet_Display b")
        Content.AppendLine("on a.sheet_sub_display = b.Sheet_Sub_Display ")
        Content.AppendLine("where a.Order_Code = @order_code")
        Content.AppendLine("and a.Default_Main_Body_Site_Code = @main_body_site")
        Content.AppendLine("and a.Default_Body_Site_Code = @body_site")
        Content.AppendLine("")
        Content.AppendLine("")
        Content.AppendLine("and a.Default_Side_Id = @side_id")
        Content.AppendLine("")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(Content.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, "CheckSheetDisplayOrderDS")
            End Using
        Catch ex As Exception
            Throw ex

        End Try

        Return ds
    End Function
#End Region
#End Region


End Class
