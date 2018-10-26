Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports System.Messaging

Public Class PUBBackupTempBO_E1

    Dim log As LOGDelegate = LOGDelegate.getInstance
    Dim myQ As New MessageQueue
    Dim QueueName As String = "PubBkTempQ"

    Public Function insertPUBBackupTemp(ByVal changeFlag As String, ByVal changeData As DataSet) As Integer
        Try
            If CheckQueue() Then
                If CheckColumnCount(changeData) Then
                    myQ.Send(ProduceSqlInsStr(changeFlag, changeData), Now.ToString())
                    Return 1
                End If
            End If

            'MessageQ 先不啟動
            Return 1
            ' Return 0
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Private Function ProduceSqlInsStr(ByVal changeFlag As String, ByVal changeData As DataSet) As String
        Dim SqlStr As String = ""
        Dim ChangeUserId As String = ""
        Dim ChangeTime As String = ""

        Try
            SqlStr = " Insert into " & changeData.Tables(0).TableName & "_BK " & "(Change_Flag,  "
            For i As Integer = 0 To changeData.Tables(0).Columns.Count - 1

                If changeData.Tables(0).Columns(i).ColumnName <> "Create_User" AndAlso _
                    changeData.Tables(0).Columns(i).ColumnName <> "Create_Time" AndAlso _
                    changeData.Tables(0).Columns(i).ColumnName <> "Modified_User" AndAlso _
                    changeData.Tables(0).Columns(i).ColumnName <> "Modified_Time" Then

                    SqlStr += changeData.Tables(0).Columns(i).ColumnName & ","

                End If
            Next

            SqlStr += "Change_User , Change_Time) Values ('" & changeFlag & "','"

            For i As Integer = 0 To changeData.Tables(0).Columns.Count - 1
                If changeData.Tables(0).Columns(i).ColumnName <> "Create_User" AndAlso _
                    changeData.Tables(0).Columns(i).ColumnName <> "Create_Time" AndAlso _
                    changeData.Tables(0).Columns(i).ColumnName <> "Modified_User" AndAlso _
                    changeData.Tables(0).Columns(i).ColumnName <> "Modified_Time" Then

                    SqlStr += changeData.Tables(0).Rows(0).Item(i).ToString.Replace("'", """") & "','"


                End If
            Next

            If changeFlag = "A" Then
                ChangeUserId = IIf(changeData.Tables(0).Rows(0).Item("Create_User") IsNot DBNull.Value, changeData.Tables(0).Rows(0).Item("Create_User"), "")
                ChangeTime = IIf(changeData.Tables(0).Rows(0).Item("Create_Time") IsNot DBNull.Value, changeData.Tables(0).Rows(0).Item("Create_Time"), Now.ToString())

            Else
                ChangeUserId = IIf(changeData.Tables(0).Rows(0).Item("Modified_User") IsNot DBNull.Value, changeData.Tables(0).Rows(0).Item("Modified_User"), "")
                ChangeTime = IIf(changeData.Tables(0).Rows(0).Item("Modified_Time") IsNot DBNull.Value, changeData.Tables(0).Rows(0).Item("Modified_Time"), Now.ToString())

            End If


            If ChangeTime.Contains("上午") Then
                ChangeTime.Replace("上午", " ")
                ChangeTime += " AM"
            Else
                ChangeTime.Replace("下午", " ")
                ChangeTime += " PM"
            End If


            SqlStr += ChangeUserId & "','" & ChangeTime & "')"
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

        Return SqlStr
    End Function

    Private Function CheckColumnCount(ByVal changeData As DataSet) As Boolean

        Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
        Try
            Dim dsDB As DataSet

            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select * from " & changeData.Tables(0).TableName & " where 1=2"
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dsDB = New DataSet(changeData.Tables(0).TableName)
                adapter.Fill(dsDB, changeData.Tables(0).TableName)
                adapter.FillSchema(dsDB, SchemaType.Mapped, changeData.Tables(0).TableName)
            End Using

            If dsDB IsNot Nothing Then
                If dsDB.Tables(0).Columns.Count = changeData.Tables(0).Columns.Count Then
                    Return True
                End If
            End If

            Return False
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Private Function CheckQueue() As Boolean
        Try
            'Private Queue
            Dim QPath_Private As String = ".\Private$\" & QueueName

            'Public Queue
            'Dim QPath_Public As String = ".\" & QueueName

            If Not MessageQueue.Exists(QPath_Private) Then

                ' Create the queue if it does not exist.
                myQ = MessageQueue.Create(QPath_Private)

            End If


            myQ.Path = QPath_Private

            If myQ IsNot Nothing Then
                Return True
            Else
                Return False

            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

End Class
