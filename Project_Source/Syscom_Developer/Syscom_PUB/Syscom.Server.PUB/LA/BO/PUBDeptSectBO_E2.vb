'/*
'*****************************************************************************
'*
'*    Page/Class Name:  科診名稱維護
'*              Title:	PUBDeptSectBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-15
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-15
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports System.Text
Imports Syscom.Comm.EXP



Public Class PUBDeptSectBO_E2
    Inherits PubDeptSectBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBDeptSectBO_E2
    Public Overloads Shared Function GetInstance() As PUBDeptSectBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBDeptSectBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 科診名稱維護查詢
    ''' </summary>
    ''' <param name="strDeptCode">科別代碼</param>
    ''' <param name="strSectId">診別代碼</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPubDeptSectByCond(ByVal strDeptCode As String, ByVal strSectId As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" Select * ")
        strSql.Append(" From ").Append(tableName)
        strSql.Append(" Where 1=1  ")
        If strDeptCode.Trim <> "" Then
            strSql.Append(" AND Dept_Code = '").Append(strDeptCode.Trim).Append("' ")
        End If
        If strSectId.Trim <> "" Then
            strSql.Append(" AND Section_Id = '").Append(strSectId.Trim).Append("' ")
        End If
        strSql.Append("Order By Dept_Code ")
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

    ''' <summary>
    ''' 科診屬性代碼查詢
    ''' </summary>
    ''' <param name="typeId" >類別代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function queryCboData(ByVal typeId As Integer, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            'Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            'Dim command As SqlCommand = sqlConn.CreateCommand()
            'command.CommandText = _
            '"select   Code_Id, Code_Name  from  PUB_Syscode" & _
            '" where Type_Id = @Type_Id" & _
            '"                   "

            'command.Parameters.AddWithValue("@Type_Id", typeId)

            'Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
            '    ds = New DataSet(tableName)
            '    adapter.Fill(ds, tableName)
            'End Using


            '取得syscode
            ds = Syscom.Server.CMM.CMMDelegate.getInstance.CMMSysCodeBSSysCodeQueryMuti(New Integer() {"97"}, conn)

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

End Class

