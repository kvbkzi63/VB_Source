'/*
'*****************************************************************************
'*
'*    Page/Class Name:  身份二代基本檔維護
'*              Title:	PUBSubIdentityBO_E2
'*        Description:	身份二代基本檔維護
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
Imports Syscom.Server.CMM
Imports System.Text
Imports Syscom.Comm.EXP



Public Class PUBSubIdentityBO_E2
    Inherits PubSubIdentityBO
    Public Shared ReadOnly tableName1 As String = "PUB_Syscode"
    Public Shared ReadOnly tableName2 As String = "Pub_Medical_Type"

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBSubIdentityBO_E2
    Public Overloads Shared Function GetInstance() As PUBSubIdentityBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBSubIdentityBO_E2
        End If
        Return myInstance
    End Function

#End Region

    ''' <summary>
    ''' 查詢身份二代碼基本檔
    ''' </summary>
    ''' <param name=" strSubIdentityCode">身份二代碼</param>
    ''' <param name=" strMainIdentityId">隸屬主身份</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢條件完全匹配</remarks>
    Public Overloads Function queryPUBSubIdentityByCond(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("select A.* ,RTRIM(B.Code_Id) + ' - ' + RTRIM(B.Code_Name) as Main_Name From ")
        strSql.Append(tableName)
        strSql.Append(" A left join  ").Append(tableName1).Append(" B on (A.Main_Identity_Id = B.Code_Id and B.Type_Id = '18' and B.DC = 'N')")
        strSql.Append(" Where 1=1 ")
        If strSubIdentityCode.Trim <> "" Then
            strSql.Append(" AND A.Sub_Identity_Code = '").Append(strSubIdentityCode.Trim).Append("' ")
        End If
        If strMainIdentityId.Trim <> "" Then
            strSql.Append(" AND A.Main_Identity_Id = '").Append(strMainIdentityId.Trim).Append("' ")
        End If
        strSql.Append(" Order By Sub_Identity_Code,Main_Identity_Id")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function

#Region "20090818 PUBSubIdentityBO_E2 共用代碼檔維護 by Add Syscom Yunfei"
    ''' <summary>
    ''' 獲取PUB_Sub_Identity資料
    ''' </summary>
    ''' <param name="strColumnName">表字段對象</param>
    ''' <param name="strColumnValue">字段值對象</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSubIdentityByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select Sub_Identity_Code as code,Sub_Identity_Name as code_name,(REPLACE(CONVERT(nvarchar,Sub_Identity_Code),' ' ,'') + ' - ' + Sub_Identity_Name) as code_name_cb  from " & tableName & " where 1=1 ")
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

#Region "20090921 PUBSubIdentityBO_E2 身份二查詢 by Add  liuye"
    ''' <summary>
    ''' 獲取身份二資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSubIdentityandContract() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("select  DISTINCT  A.Sub_Identity_Code, A.Sub_Identity_Name from PUB_Sub_Identity A ")
        strSql.Append("left outer join PUB_Contract  B on (A.Sub_Identity_Code= B.Sub_Identity_Code and B.Dc='N')")
        strSql.Append(" Where 1=1 and A.Dc='N' ")
        strSql.Append("  order by A.Sub_Identity_Code  ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "20100208  身份二查詢for 優待身份折扣設定檔combox  by Add  tony"
    ''' <summary>
    ''' 獲取身份二資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSubIdentityForCombo() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" ").Append("    select  A.Sub_Identity_Code,                                              ")
        strSql.Append(" ").Append("    A .Sub_Identity_Name ,A.Main_Identity_Id                                                       ")
        strSql.Append(" ").Append("    from PUB_Sub_Identity  A                                                      ")
        strSql.Append(" ").Append("    Where 1=1                                                                 ")
        strSql.Append(" ").Append("    and A.Dc='N'                                                              ")
        strSql.Append(" ").Append("    order by A.Sub_Identity_Code                                              ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "20100426  身份二查詢for  門診健檢套餐報價combox  by Add  tony"
    ''' <summary>
    ''' 獲取身份二資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSubIdentityForCombo1(ByVal strContractCode As String) As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
        Dim command As SqlCommand = sqlConn.CreateCommand()

        Dim strSql As New StringBuilder
        strSql.Append(" ").Append("    select  A.Sub_Identity_Code,                                              ")
        strSql.Append(" ").Append("    I .Sub_Identity_Name ,I.Main_Identity_Id                                  ")
        strSql.Append(" ").Append("    from PUB_Contract  A                                                      ")
        strSql.Append(" ").Append("    left join PUB_Sub_Identity I  on I .Sub_Identity_Code=A.Sub_Identity_Code ")
        strSql.Append(" ").Append("    Where 1=1                                                                 ")
        strSql.Append(" ").Append("    and A.Contract_Code=@Contract_Code                                        ")
        strSql.Append(" ").Append("    and A.Dc='N'                                                              ")
        strSql.Append(" ").Append("    order by A.Sub_Identity_Code                                              ")
        command.CommandText = strSql.ToString
        command.Parameters.AddWithValue("@Contract_Code", strContractCode)
        Try
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "20120312  身份代碼查詢 for ComboBox  by Add Mark Zhang"
    ''' <summary>
    ''' 獲取身份代碼資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSubIdentityForComboBox2() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" ").Append("    select  A.Sub_Identity_Code,             ").Append(vbCrLf)
        strSql.Append(" ").Append("    A .Sub_Identity_Name ,A.Main_Identity_Id ").Append(vbCrLf)
        strSql.Append(" ").Append("    from PUB_Sub_Identity  A                 ").Append(vbCrLf)
        strSql.Append(" ").Append("    Where 1=1                                ").Append(vbCrLf)
        strSql.Append(" ").Append("    and A.Dc='N'                             ").Append(vbCrLf)
        strSql.Append(" ").Append("    order by A.Main_Identity_Id,A.Sub_Identity_Code  ").Append(vbCrLf)
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "20120604 PUBSubIdentityBO_E2 身份二查詢ForEmd by Add  ChenYang"
    ''' <summary>
    ''' 獲取身份二資料ForEmd
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSubIdentityandContractForEmd() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("select  DISTINCT  A.Sub_Identity_Code, A.Sub_Identity_Name from PUB_Sub_Identity A ")
        strSql.Append("left outer join PUB_Contract  B on (A.Sub_Identity_Code= B.Sub_Identity_Code and B.Dc='N')")
        strSql.Append(" Where 1=1 and A.Dc='N' and is_emg='Y'")
        strSql.Append("  order by A.Sub_Identity_Code  ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "2016-05-19 PUBSubIdentityBO_E2 身份二查詢 by Add Xiaozhi"
    ''' <summary>
    ''' 獲取身份二資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSubMedicalType() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append("Select Medical_Type_Id, Medical_Type_Name From PUB_Medical_Type")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName2)
                adapter.Fill(ds, tableName2)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName2)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

End Class

