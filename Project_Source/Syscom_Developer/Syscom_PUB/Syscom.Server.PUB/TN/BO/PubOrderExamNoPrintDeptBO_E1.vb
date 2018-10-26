'/*
'*****************************************************************************
'*
'*    Page/Class Name:  檢查醫令不須列印部門維護作業
'*              Title:	PubOrderExamNoPrintDeptBO_E1
'*        Description:	刪除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Michelle
'*        Create Date:	2017-04-13
'*      Last Modifier:	Michelle
'*   Last Modify Date:	2017-04-13
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.BO


Public Class PubOrderExamNoPrintDeptBO_E1
    Inherits PubOrderExamNoprintDeptBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubOrderExamNoPrintDeptBO_E1
    Public Overloads Shared Function GetInstance() As PubOrderExamNoPrintDeptBO_E1
        If myInstance Is Nothing Then
            myInstance = New PubOrderExamNoPrintDeptBO_E1
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

    ''' <summary>
    '''以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PUBOrderExamNoPrintDeptdelete(ByRef pk_Order_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try

            '================================
            '加入backup
            Try
                Using conn_backup As SqlConnection = getConnection()
                    conn_backup.Open()
                    Using command As SqlCommand = conn_backup.CreateCommand()
                        Dim sqlSelectString As String = " Select * From " & tableName & " Where Order_Code=@Order_Code "
                        command.CommandText = sqlSelectString
                        command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                            Using NoPrintDeptDS As DataSet = New DataSet("NoPrintDeptDS")
                                adapter.Fill(NoPrintDeptDS, "NoPrintDeptDS")

                                For Each row As DataRow In NoPrintDeptDS.Tables(0).Rows
                                    deleteBackup(row, conn_backup)
                                Next

                            End Using
                        End Using
                    End Using
                    conn_backup.Close()
                End Using
            Catch ex As Exception
                Syscom.Server.CMM.LOGDelegate.getInstance.dbDebugMsg("備份錯誤-" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "-" & ex.ToString)
            End Try

            '================================

            Dim count As Integer = 0

            Dim sqlString As String = "delete from " & tableName & " where Order_Code=@Order_Code"

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
                command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB914", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "     查詢 Method "

#End Region

End Class

