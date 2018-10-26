'/*
'*****************************************************************************
'*
'*    Page/Class Name:  全國醫療卡維護
'*              Title:	PUBPatientHealthCardBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-14
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-14
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports System.Text
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP



Public Class PUBPatientHealthCardBO_E2
    Inherits PubPatientHealthCardBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPatientHealthCardBO_E2
    Public Overloads Shared Function GetInstance() As PUBPatientHealthCardBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPatientHealthCardBO_E2
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
#Region "20100419 全國醫療服務卡維護檔-查詢 add by Runxia"
    ''' <summary>
    ''' 查詢全國醫療服務卡資料
    ''' </summary>
    ''' <param name="strChartNo">病歷號</param>
    ''' <param name="dateEffectDate">生效日期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPubPatientHealthCardByCond_L(ByVal strChartNo As String, ByVal dateEffectDate As Date, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As StringBuilder = New StringBuilder()

            strSql.Append("SELECT A.*,B.Idno,B.Patient_Name  FROM  ")
            strSql.Append(" ").Append(tableName + " A")
            strSql.Append(" ").Append("LEFT JOIN PUB_Patient B ON A.Chart_No=B.Chart_No")
            strSql.Append(" ").Append("where 1=1 ")
            If strChartNo <> "" Then
                strSql.Append(" and A.Chart_No = ").Append(" @Chart_No ")
            End If
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                strSql.Append(" ").Append("and A.Effect_Date= @Effect_Date ")
            End If
            command.CommandText = strSql.ToString()
            command.Parameters.AddWithValue("@Chart_No", strChartNo)
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            'LOGDelegate.getInstance.getFileLogger(Me).Error(sqlex.ToString)
            Throw sqlex
        Catch ex As Exception
            ' LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region
#End Region

End Class

