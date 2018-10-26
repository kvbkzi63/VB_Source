Imports System.Data.SqlClient
Imports System.IO
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports System.String
Imports Syscom.Comm.Utility.StringUtil
Imports System.Text
Imports System.Transactions
Imports Syscom.Server.SQL
Imports Syscom.Server.PUB
Imports Syscom.Comm.Utility

Public Class UCLPostalAreaBS
    Dim conn As SqlConnection = SQLConnFactory.getInstance.getOpdDBSqlConn


    Enum QueryType As Integer
        GetAll = 0

    End Enum

#Region "20090414 共用元件-地址(戶籍地,郵遞區號)查詢  by James"

    Public Function queryUclPostalAreaAll() As DataSet
        Dim oper As PUBDelegate = PUBDelegate.getInstance()
        Return oper.queryPubPostalAreaAll()
    End Function


    Public Function queryUclPostalAreaAllNew() As DataSet
        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn

        Dim SqlCmd As SqlCommand
        Dim cmdStr As String = ""
        Dim myReader As SqlDataReader = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds As DataSet

        cmdStr = getQueryStr(QueryType.GetAll)
        ' cmdStr = "Select Area_Code, Area_Name From nckuhDB.dbo.CMN_Area_Code Order BY Area_Code "

        ds = New DataSet()
        Try
            If cmdStr <> "" Then
                conn.Open()
                SqlCmd = New SqlCommand(cmdStr, conn)
                da = New SqlDataAdapter(New SqlCommand(cmdStr, conn))

                da.Fill(ds, "data")
            End If
        Catch ex As SqlClient.SqlException
            Throw ex
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return ds



    End Function

    Public Function queryUclPUBAreaCodeGovVilCodeName(ByVal code1 As String, ByVal code2 As String, ByVal type As String) As DataSet
        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn

        Dim SqlCmd As SqlCommand
        Dim cmdStr As String = ""
        Dim myReader As SqlDataReader = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds As DataSet


        Dim varname1 As New System.Text.StringBuilder
        varname1.Append("SELECT   PUB_Area_Code_N.Area_Code, " & vbCrLf)
        varname1.Append("       PUB_Area_Code_N.Area_Name, " & vbCrLf)
        varname1.Append("       PUB_Area_Code_N.County_Code, " & vbCrLf)
        varname1.Append("       PUB_Postal_Code.Postal_Code, " & vbCrLf)
        varname1.Append("       PUB_Postal_Code.Postal_Name, " & vbCrLf)
        varname1.Append("       PUB_Postal_Code.Town_Name, " & vbCrLf)
        varname1.Append("       PUB_Postal_Code.County_Name, " & vbCrLf)
        varname1.Append("       PUB_Area_Code_Gov.Gov_County_Code, " & vbCrLf)
        varname1.Append("       PUB_Area_Code_Gov.Gov_County_Name, " & vbCrLf)
        varname1.Append("       PUB_Area_Code_Gov.Dist_Code , " & vbCrLf)
        varname1.Append("       PUB_Area_Code_Gov.Dist_Name , " & vbCrLf)
        varname1.Append("	   PUB_Area_Code_Gov.Vil_Code , " & vbCrLf)
        varname1.Append("	   PUB_Area_Code_Gov.Vil_Name " & vbCrLf)
        varname1.Append("FROM   PUB_Postal_Area, " & vbCrLf)
        varname1.Append("       PUB_Area_Code_N, " & vbCrLf)
        varname1.Append("       PUB_Postal_Code, " & vbCrLf)
        varname1.Append("       PUB_Area_Code_Gov, " & vbCrLf)
        varname1.Append("       PUB_Postal_Gov_Area " & vbCrLf)
        varname1.Append("WHERE  PUB_Postal_Area.Area_Code = PUB_Area_Code_N.Orig_Area_Code " & vbCrLf)
        varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Area.Postal_Code " & vbCrLf)
        varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Gov_Area.Postal_Code " & vbCrLf)
        varname1.Append("       AND PUB_Postal_Gov_Area.Dist_Code = PUB_Area_Code_Gov.Dist_Code " & vbCrLf)

        '1 Dist 2 Postal 3 Area
        If type = "1" Then
            varname1.Append("       AND PUB_Area_Code_Gov.Gov_County_Code='" & code1.Trim & "' And PUB_Postal_Gov_Area.Dist_Code = '" & code2.Trim & "' " & vbCrLf)

        ElseIf type = "2" Then
            varname1.Append("       AND PUB_Postal_Code.Postal_Code='" & code1.Trim & "' " & vbCrLf)

        ElseIf type = "3" Then
            varname1.Append("       AND PUB_Area_Code_N.Area_Code='" & code1.Trim & "' " & vbCrLf)

        End If

        varname1.Append("ORDER  BY PUB_Area_Code_N.Sort_Value , PUB_Area_Code_N.Area_Code")


        cmdStr = varname1.ToString

        ds = New DataSet()
        Try
            If cmdStr <> "" Then
                conn.Open()
                SqlCmd = New SqlCommand(cmdStr, conn)
                da = New SqlDataAdapter(New SqlCommand(cmdStr, conn))

                da.Fill(ds, "data")
            End If
        Catch ex As SqlClient.SqlException
            Throw ex
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return ds



    End Function


    Public Function getQueryStr(ByVal queryType As Integer) As String
        Select Case queryType
            Case 0
                Dim varname1 As New System.Text.StringBuilder
                varname1.Append("SELECT   PUB_Area_Code_N.Area_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.Area_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.County_Code, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Postal_Code, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Postal_Name, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Town_Name, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.County_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Gov_County_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Gov_County_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Dist_Code , " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Dist_Name , " & vbCrLf)
                varname1.Append("	   PUB_Area_Code_Gov.Vil_Code , " & vbCrLf)
                varname1.Append("	   PUB_Area_Code_Gov.Vil_Name " & vbCrLf)
                varname1.Append("FROM   PUB_Postal_Area, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov, " & vbCrLf)
                varname1.Append("       PUB_Postal_Gov_Area " & vbCrLf)
                varname1.Append("WHERE  PUB_Postal_Area.Area_Code = PUB_Area_Code_N.Orig_Area_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Area.Postal_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Gov_Area.Postal_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Gov_Area.Dist_Code = PUB_Area_Code_Gov.Dist_Code " & vbCrLf)
                varname1.Append("ORDER  BY  PUB_Area_Code_N.Sort_Value , PUB_Area_Code_N.Area_Code")

                Return varname1.ToString

        End Select


        Return ""
    End Function

#End Region
End Class
