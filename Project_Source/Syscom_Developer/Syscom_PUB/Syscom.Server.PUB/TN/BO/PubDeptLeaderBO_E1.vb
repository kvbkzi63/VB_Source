'/*
'*****************************************************************************
'*
'*    Page/Class Name:  科室主管檔維護
'*              Title:	PubDeptLeaderBO_E1
'*        Description:	針對科室主管檔處理新增、修改、刪除、查詢、清除和退出相關功能
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	kudy.Sue
'*        Create Date:	2016-07-13
'*      Last Modifier:	kudy.Sue
'*   Last Modify Date:	2016-07-13
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports System.Data
Imports Syscom.Server.BO


Public Class PubDeptLeaderBO_E1
    Inherits PubDeptLeaderBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubDeptLeaderBO_E1
    Public Overloads Shared Function GetInstance() As PubDeptLeaderBO_E1
        If myInstance Is Nothing Then
            myInstance = New PubDeptLeaderBO_E1()
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "

    ''' <summary>
    ''' 查詢科室主管檔資料
    ''' </summary>
    ''' <param name="_Dept_Code">科室代碼</param>
    ''' <param name="_Leader_Employee_Code">主管員工代碼</param>
    ''' <param name="_Effect_Date">生效日期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPubDeptLeaderByCond(ByVal _Dept_Code As String, ByVal _Leader_Employee_Code As String, ByVal _Effect_Date As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        Dim Content As New StringBuilder
        Try
            Content.AppendLine("select Dept_Code,")
            Content.AppendLine("Leader_Employee_Code,")
            Content.AppendLine("[dbo].[AdToRocDate](Effect_Date) as Effect_Date_ROC,")
            Content.AppendLine("Effect_Date ,")
            Content.AppendLine("[dbo].[AdToRocDate](End_Date) as End_Date_ROC,")
            Content.AppendLine("End_Date , ")
            Content.AppendLine("Create_User,")
            Content.AppendLine("[dbo].[AdToRocTime](Create_Time) as Create_Time_ROC,")
            Content.AppendLine(" Create_Time ,")
            Content.AppendLine("Modified_User,")
            Content.AppendLine("[dbo].[AdToRocTime](Modified_Time) as Modified_Time_ROC,")
            Content.AppendLine(" Modified_Time")
            Content.AppendLine("from PUB_Dept_Leader")
            Content.AppendLine("where 1=1 ")
            If _Dept_Code.Trim <> "" Then
                Content.AppendLine(" and Dept_Code = @Dept_Code")
            End If
            If _Leader_Employee_Code.Trim <> "" Then
                Content.AppendLine(" and Leader_Employee_Code = @Leader_Employee_Code")
            End If
            If _Effect_Date.Trim <> "" Then
                Content.AppendLine(" and Effect_Date = @Effect_Date")
            End If
            Content.AppendLine("Order By Dept_Code")

            Dim sqlConn As SqlConnection = SQLConnFactory.getInstance.getPcsDBSqlConn
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            If _Dept_Code.Trim <> "" Then
                command.Parameters.AddWithValue("@Dept_Code", _Dept_Code)
            End If
            If _Leader_Employee_Code.Trim <> "" Then
                command.Parameters.AddWithValue("@Leader_Employee_Code", _Leader_Employee_Code)
            End If
            If _Effect_Date.Trim <> "" Then
                command.Parameters.AddWithValue("@Effect_Date", _Effect_Date)
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function

#End Region

End Class

