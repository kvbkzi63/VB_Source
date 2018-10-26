'/*
'*****************************************************************************
'*
'*    Page/Class Name:  特殊屬性輸入元件
'*              Title:	PUBLabIndication04BO
'*        Description:	特殊屬性輸入元件
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Margaret.Tsai
'*        Create Date:	2016-07-18
'*      Last Modifier:	Margaret.Tsai
'*   Last Modify Date:	2016-07-18
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL


Public Class PUBLabIndication04BO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBLabIndication04BO
    Public Shared Function GetInstance() As PUBLabIndication04BO
        If myInstance Is Nothing Then
            myInstance = New PUBLabIndication04BO
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method-特殊屬性輸入元件 "
#Region " 特殊屬性輸入元件 "

    ''' <summary>
    ''' 特殊屬性輸入元件
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Margaret.Tsai on 2016-07-18</remarks>
    Public Function QureyPUBLabIndication04(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim Content As New StringBuilder
            Content.AppendLine("--1欄資料均分成3欄")
            Content.AppendLine("select ROW_NUMBER() OVER(ORDER BY a1.ord) AS PKey")
            Content.AppendLine("	, 'N' as check1, a1.Code_En_Name1")
            Content.AppendLine("	, 'N' as check2, a2.Code_En_Name2")
            Content.AppendLine("	, 'N' as check3, a3.Code_En_Name3")
            Content.AppendLine("from(")
            Content.AppendLine("	(select 'y' as ord, row, Code_En_Name as Code_En_Name1")
            Content.AppendLine("	from (")
            Content.AppendLine("			select row % 3 as x3,  row, Code_En_Name")
            Content.AppendLine("			from (")
            Content.AppendLine("				Select ROW_NUMBER() OVER(ORDER BY Code_En_Name) AS Row,  Code_En_Name ")
            Content.AppendLine("				From PUB_SYSCode")
            Content.AppendLine("				Where Type_Id  ='20004' and DC<>'Y'")
            Content.AppendLine("			)s")
            Content.AppendLine("	)x where x3=1 ) a1 ")
            Content.AppendLine("")
            Content.AppendLine("	left outer join (")
            Content.AppendLine("	select 'y' as ord, row, Code_En_Name as Code_En_Name2")
            Content.AppendLine("	from (")
            Content.AppendLine("			select row % 3 as x3,  row, Code_En_Name")
            Content.AppendLine("			from (")
            Content.AppendLine("				Select ROW_NUMBER() OVER(ORDER BY Code_En_Name) AS Row,  Code_En_Name ")
            Content.AppendLine("				From PUB_SYSCode")
            Content.AppendLine("				Where Type_Id  ='20004' and DC<>'Y'")
            Content.AppendLine("			)s")
            Content.AppendLine("	)x where x3=2 ) a2 on a1.ord=a2.ord and a2.row-a1.row=1")
            Content.AppendLine("")
            Content.AppendLine("	left outer join (")
            Content.AppendLine("	select 'y' as ord,row, Code_En_Name as  Code_En_Name3")
            Content.AppendLine("	from (")
            Content.AppendLine("			select row % 3 as x3,  row, Code_En_Name")
            Content.AppendLine("			from (")
            Content.AppendLine("				Select ROW_NUMBER() OVER(ORDER BY Code_En_Name) AS Row,  Code_En_Name ")
            Content.AppendLine("				From PUB_SYSCode")
            Content.AppendLine("				Where Type_Id  ='20004' and DC<>'Y'")
            Content.AppendLine("			)s")
            Content.AppendLine("	)x where x3=0 )a3 on a1.ord=a3.ord and a3.row-a1.row=2")
            Content.AppendLine(")")
            Content.AppendLine("")

            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getPcsDBSqlConn()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUBLabIndication04Ou")
                adapter.Fill(ds, "PUBLabIndication04Ou")
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢特殊屬性輸入元件"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    Public Function QureyPUBLabIndication10(ByVal inIDNO As String, ByVal inOrderDate As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim varname1 As New System.Text.StringBuilder
            '取得耀瑄大腸鏡報告資料
            'List=>檢體編號
            'LOC=>位置
            'LOC1=>位置不明(與肛門口距離)
            varname1.Append("SELECT List,LOC,LOC1 " & vbCrLf)
            varname1.Append("FROM OHM_ColonQC_Detail " & vbCrLf)
            varname1.Append("Where Idno='" & inIDNO & "' and Exam_Date='" & inOrderDate & "'; " & vbCrLf)

            '取得[檢體編號]下拉選項值
            varname1.Append("SELECT LAB_Code_Id,LAB_Code_En_Name " & vbCrLf)
            varname1.Append("FROM LAB_Code " & vbCrLf)
            varname1.Append("Where LAB_Type_Id='AP19'; " & vbCrLf)

            '取得[位置]下拉選項值
            varname1.Append("SELECT LAB_Code_Id,LAB_Code_Name " & vbCrLf)
            varname1.Append("FROM LAB_Code " & vbCrLf)
            varname1.Append("Where LAB_Type_Id='AP20'")

            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getPcsDBSqlConn()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = varname1.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUBLabIndication10Ou")
                adapter.Fill(ds, "PUBLabIndication10Ou")
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢特殊屬性輸入元件"})
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




End Class



