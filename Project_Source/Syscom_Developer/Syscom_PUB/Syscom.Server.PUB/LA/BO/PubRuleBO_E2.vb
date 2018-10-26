'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PubRuleBO_E2.vb
'*              Title:	PubRuleBO_E2
'*        Description:	PubRuleBO_E2
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	liuye
'*        Create Date:	2011/10/31
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
Public Class PubRuleBO_E2
    Inherits PubRuleBO
    Private Shared instance As PubRuleBO_E2

    Public Overloads Shared Function getInstance() As PubRuleBO_E2
        If instance Is Nothing Then
            instance = New PubRuleBO_E2
        End If
        Return instance
    End Function
    ''' <summary>
    '''  查詢
    ''' </summary>
    ''' <param name="ParentRuleCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBRuleAndDeatilbyParentCode(ByVal ParentRuleCode As System.String, ByVal strlevel As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " select * ,level='" & strlevel & "' into #tempRule from PUB_Rule where Parent_Rule_Code in (" & ParentRuleCode & ") " & vbCrLf & _
                                  " select * from  #tempRule " & vbCrLf & _
                                  " select A.* from PUB_Rule_Detail A " & vbCrLf & _
                                  " inner join #tempRule B on A.Rule_Code=B.Rule_Code " & vbCrLf & _
                                  " delete #tempRule"

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
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Public Function queryPUBRuleCodebyParentCode(ByVal ParentRuleCode As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " select Rule_Code  from PUB_Rule where Parent_Rule_Code in (" & ParentRuleCode & ") " & vbCrLf

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
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Function getRulebyParentRuleCode(ByVal parentCodes() As String, Optional ByVal strlevel As String = "") As DataSet
        Try
            Dim ds As New DataSet

            If parentCodes.Length > 0 Then
                Dim strParentCode As String = ""
                For i As Integer = 0 To parentCodes.Length - 1
                    strParentCode &= "'" & parentCodes(i).Trim & "',"
                Next
                If strParentCode <> "" Then
                    strParentCode = strParentCode.Substring(0, strParentCode.Length - 1)
                    If strlevel <> "" Then
                        getdatabycode(strParentCode, strlevel, ds)
                    Else
                        'for delete
                        getCodebyParent(strParentCode, ds)
                    End If
                End If

            End If
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub getCodebyParent(ByVal parentCodes As String, ByRef ds As DataSet)
        Try
            Dim dsQuery As New DataSet
            If parentCodes <> "" Then
                dsQuery = queryPUBRuleCodebyParentCode(parentCodes)
                If dsQuery.Tables.Count > 0 Then
                    If ds.Tables.Count = 0 Then
                        ds.Tables.Add(dsQuery.Tables(0).Clone)
                    End If

                    '如果沒有下層資料即退出
                    If dsQuery.Tables(0).Rows.Count > 0 Then
                        'Rule
                        ds.Tables(0).Merge(dsQuery.Tables(0).Copy)
                        parentCodes = ""
                        For i As Integer = 0 To dsQuery.Tables(0).Rows.Count - 1
                            parentCodes &= "'" & dsQuery.Tables(0).Rows(i)("Rule_Code").ToString.Trim & "',"
                        Next
                        If parentCodes <> "" Then
                            parentCodes = parentCodes.Substring(0, parentCodes.Length - 1)
                            '查詢它的下一層
                            getCodebyParent(parentCodes, ds)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub getdatabycode(ByVal parentCodes As String, ByRef strlevel As String, ByRef ds As DataSet)
        Try
            Dim dsQuery As New DataSet
            If parentCodes <> "" Then
                dsQuery = queryPUBRuleAndDeatilbyParentCode(parentCodes, strlevel)
                If dsQuery.Tables.Count > 0 Then
                    If ds.Tables.Count = 0 Then
                        ds.Tables.Add(dsQuery.Tables(0).Clone)
                        ds.Tables.Add(dsQuery.Tables(1).Clone)
                    End If

                    If dsQuery.Tables(1).Rows.Count > 0 Then
                        'Detial
                        ds.Tables(1).Merge(dsQuery.Tables(1).Copy)
                    End If
                    '如果沒有下層資料即退出
                    If dsQuery.Tables(0).Rows.Count > 0 Then
                        'Rule
                        ds.Tables(0).Merge(dsQuery.Tables(0).Copy)
                        parentCodes = ""
                        For i As Integer = 0 To dsQuery.Tables(0).Rows.Count - 1
                            parentCodes &= "'" & dsQuery.Tables(0).Rows(i)("Rule_Code").ToString.Trim & "',"
                        Next
                        If parentCodes <> "" Then
                            parentCodes = parentCodes.Substring(0, parentCodes.Length - 1)
                            '查詢它的下一層
                            strlevel = CInt(strlevel) + 1
                            getdatabycode(parentCodes, strlevel, ds)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 重新寫Rule的查詢，新加入level欄
    ''' </summary>
    ''' <param name="RuleCodes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRuleDataByRuleCodesL(ByVal RuleCodes() As String, ByVal strlevel As String) As DataTable

        If RuleCodes IsNot Nothing AndAlso RuleCodes.Length > 0 Then
            Dim ruleStr As New StringBuilder
            For i As Integer = 0 To (RuleCodes.Length - 1)
                ruleStr.Append("'").Append(RuleCodes(i)).Append("',")
            Next
            If ruleStr.Length > 0 Then
                ruleStr.Remove(ruleStr.Length - 1, 1)
            End If

            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select * ,level='" & strlevel & "'  ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("where Rule_Code in (").Append(ruleStr).Append(") ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Expression_Str  ")
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                        End With
                        conn.Open()
                        Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            da.Fill(dt)
                        End Using
                    End Using
                End Using

                Return dt

            Catch ex As Exception
                Throw ex
            End Try

        Else
            Return Nothing
        End If

    End Function
End Class
