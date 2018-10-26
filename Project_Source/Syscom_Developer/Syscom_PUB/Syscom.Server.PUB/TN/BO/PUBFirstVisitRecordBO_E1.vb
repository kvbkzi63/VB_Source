Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text



Public Class PUBFirstVisitRecordBO_E1
    Inherits PubFirstVisitRecordBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBFirstVisitRecordBO_E1
    Public Overloads Shared Function getInstance() As PUBFirstVisitRecordBO_E1
        If instance Is Nothing Then
            instance = New PUBFirstVisitRecordBO_E1
        End If
        Return instance
    End Function
    Private Sub New()
    End Sub
#End Region


    'Dim tableName1 As String = "PUB_First_Visit_Record"
    'Private Shared instance As PUBFirstVisitRecordBO_E1

    'Public Shared Function getInstance() As PUBFirstVisitRecordBO_E1
    '    instance = New PUBFirstVisitRecordBO_E1
    '    Return instance
    'End Function

    'Private Function getConnection() As IDbConnection
    '    Return SQLConnFactory.getInstance.getPubDBSqlConn
    'End Function


    Public Overloads Function CheckWriteFirstVisitRecord(ByVal chartNo As String, ByVal depCode As String) As DataSet

        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
        Dim SqlCmd As SqlCommand
        Dim cmdStr As String = ""
        Dim myReader As SqlDataReader = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds As DataSet

        cmdStr = " SELECT Top 1 Is_First_Chart FROM PUB_First_Visit_Record WHERE Chart_No='" & chartNo & "' And   Dept_Code='" & depCode & "'  "
        ' cmdStr = "Select Area_Code, Area_Name From nckuhDB.dbo.CMN_Area_Code Order BY Area_Code "

        ds = New DataSet("resultDB")
        Try
            If cmdStr <> "" Then
                conn.Open()
                SqlCmd = New SqlCommand(cmdStr, conn)
                da = New SqlDataAdapter(New SqlCommand(cmdStr, conn))
                da.FillSchema(ds, SchemaType.Source, "resulttable")
                da.Fill(ds.Tables("resulttable"))
            End If
        Catch ex As SqlClient.SqlException
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.StackTrace, ex)
            Throw ex
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return ds


    End Function


    Public Overloads Function queryPUBFirstVisitRecord(ByVal ds As DataSet) As DataSet 'Implements IPUBFirstVisitRecordBO.queryPUBFirstVisitRecord

        Try

            Dim ChartNo As String = ds.Tables(0).Rows(0).Item("ChartNo")
            Dim BelongDep As String = ds.Tables(0).Rows(0).Item("BelongDep")
            Dim DepCode As String = ds.Tables(0).Rows(0).Item("DepCode")

            Dim ds2 As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            If ChartNo <> "" AndAlso BelongDep IsNot Nothing Then

                command.CommandText = " Select *  " & _
                                      " From  " & tableName & " " & _
                                      " Where  Chart_No='" & ChartNo & "' And Belong_Dept_Code='" & BelongDep & "' " & _
                                      " Order By Chart_No"

            ElseIf ChartNo <> "" AndAlso BelongDep Is Nothing Then

                command.CommandText = " Select *  " & _
                                     " From  " & tableName & " " & _
                                     " Where  Chart_No='" & ChartNo & "' And Belong_Dept_Code Is nothing " & _
                                     " Order By Chart_No"

            End If


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds2 = New DataSet(tableName)
                adapter.Fill(ds2, tableName)
                adapter.FillSchema(ds2, SchemaType.Mapped, tableName)
            End Using
            Return ds2

        Catch ex As Exception
            Throw ex
        End Try


    End Function



End Class
