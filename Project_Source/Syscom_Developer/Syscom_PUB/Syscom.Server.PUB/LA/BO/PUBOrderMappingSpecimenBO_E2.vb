'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBOrderMappingSpecimenBO.vb
'*              Title:	PUBOrderMappingSpecimenBO
'*        Description:	PUBOrderMappingSpecimenBO
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	windfog
'*        Create Date:	2009/08/21
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
Public Class PUBOrderMappingSpecimenBO_E2
    'Inherits OmoFavorBO
    Const tableName = "PUB_Order_Mapping_Specimen"
    Private Shared myInstance As PUBOrderMappingSpecimenBO_E2
    Public Overloads Shared Function GetInstance() As PUBOrderMappingSpecimenBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBOrderMappingSpecimenBO_E2()
        End If
        Return myInstance
    End Function


#Region "20090821 查詢醫令代碼對應檢體檔 add by windfog"
    ''' <summary>
    '''  查詢醫令代碼對應檢體檔
    ''' </summary>
    ''' <param name="strOrder_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBOrderMappingSpecimenByOrderCode(ByVal strOrder_Code As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" ").Append("	select A.Order_Code                                                                                                    ")
        strSql.Append(" ").Append("		,A.Specimen_Id                                                                                                     ")
        strSql.Append(" ").Append("		, PUB_SYSCODE.Code_Name                                                                                            ")
        strSql.Append(" ").Append("		, PUB_SYSCODE.Code_En_Name                                                                                         ")
        strSql.Append(" ").Append("		,A.Is_Default                                                                                                      ")
        strSql.Append(" ").Append("	from PUB_Order_Mapping_Specimen  A                                                                                     ")
        strSql.Append(" ").Append("		left outer join (select * from PUB_SYSCODE where PUB_SYSCODE.Type_Id= '46' and PUB_SYSCODE.Dc <>'Y') as PUB_SYSCODE")
        strSql.Append(" ").Append("			on A.Specimen_Id = PUB_SYSCODE.Code_Id                                                                         ")
        If strOrder_Code.Trim <> "" Then
            strSql.Append(" ").Append("	where A.Order_Code = '" + strOrder_Code + "'         ")
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
    '''取得資料庫連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Protected Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
#End Region

#Region "20100601 查詢套餐內容Grid.檢體ComboBox下拉選單資料 add by tima_qin"
    ''' <summary>
    '''  查詢套餐內容Grid.檢體ComboBox下拉選單資料
    ''' </summary>
    ''' <param name="strOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBSpecimenIdCombobox(ByVal strOrderCode As String, ByVal strFlag As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder
        If strFlag = "" Then
            If queryPUBSpecimenIdCombobox_Flag(strOrderCode).Tables(0).Rows(0).Item(0) > 0 Then
                strSql.Append(" ").Append("	select A.Specimen_Id,B.Code_Name        ")
                strSql.Append(" ").Append("	from PUB_Order_Mapping_Specimen A, PUB_Syscode B         ")
                strSql.Append(" ").Append("	where  A.Is_Default ='Y'         ")
                strSql.Append(" ").Append("	and B.Type_Id=46         ")
                strSql.Append(" ").Append("	and B.Code_Id=A.Specimen_Id        ")
                strSql.Append(" ").Append("	and A.Order_Code='" & strOrderCode & "'")
                strSql.Append(" ").Append("	order by A.Specimen_Sort_Value        ")
            Else
                strSql.Append(" ").Append("	select A.Specimen_Id,B.Code_Name        ")
                strSql.Append(" ").Append("	from PUB_Order_Mapping_Specimen A, PUB_Syscode B         ")
                strSql.Append(" ").Append("	where  A.Is_Default ='N'         ")
                strSql.Append(" ").Append("	and B.Type_Id=46         ")
                strSql.Append(" ").Append("	and B.Code_Id=A.Specimen_Id        ")
                strSql.Append(" ").Append("	and A.Order_Code='" & strOrderCode & "'")
                strSql.Append(" ").Append("	order by A.Specimen_Sort_Value        ")
            End If
        Else
            strSql.Append(" ").Append("	select A.Specimen_Id,B.Code_Name        ")
            strSql.Append(" ").Append("	from PUB_Order_Mapping_Specimen A, PUB_Syscode B         ")
            strSql.Append(" ").Append("	where  B.Type_Id=46         ")
            strSql.Append(" ").Append("	and B.Code_Id=A.Specimen_Id        ")
            strSql.Append(" ").Append("	and A.Order_Code='" & strOrderCode & "'")
            strSql.Append(" ").Append("	order by A.Specimen_Sort_Value        ")
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

    Public Overloads Function queryPUBSpecimenIdCombobox_Flag(ByVal strOrderCode As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("	select count(1)        ")
        strSql.Append(" ").Append("	from PUB_Order_Mapping_Specimen         ")
        strSql.Append(" ").Append("	where  Is_Default='Y'        ")
        strSql.Append(" ").Append("	and Order_Code='" & strOrderCode & "'")

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

#Region "20101216 查詢醫令代碼對應檢體檔 add by mark zhang"
    ''' <summary>
    '''  查詢醫令代碼對應檢體檔
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBOrderMappingSpecimenForAll() As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" ").Append("	select A.Order_Code                                                                                                    ")
        strSql.Append(" ").Append("		,A.Specimen_Id                                                                                                     ")
        strSql.Append(" ").Append("		, PUB_SYSCODE.Code_Name                                                                                            ")
        strSql.Append(" ").Append("		, PUB_SYSCODE.Code_En_Name                                                                                         ")
        strSql.Append(" ").Append("		,A.Is_Default                                                                                                      ")
        strSql.Append(" ").Append("		,A.Specimen_Sort_Value                                                                                             ")
        strSql.Append(" ").Append("	from PUB_Order_Mapping_Specimen  A                                                                                     ")
        strSql.Append(" ").Append("		left outer join (select * from PUB_SYSCODE where PUB_SYSCODE.Type_Id= '46' and PUB_SYSCODE.Dc <>'Y') as PUB_SYSCODE")
        strSql.Append(" ").Append("			on A.Specimen_Id = PUB_SYSCODE.Code_Id                                                                         ")
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

