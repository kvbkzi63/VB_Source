Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text


Public Class PUBPostalAreaBO_E1
    Inherits PubPostalAreaBO


    Private Shared instance As PUBPostalAreaBO_E1

    Public Overloads Shared Function getInstance() As PUBPostalAreaBO_E1
        instance = New PUBPostalAreaBO_E1
        Return instance
    End Function


    Enum QueryType As Integer
        GetAll = 0

    End Enum



    Public Function queryPubPostalAreaAll() As DataSet

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
                'da.FillSchema(ds, SchemaType.Source, "resulttable")
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

                'Dim varname1 As New System.Text.StringBuilder
                'varname1.Append("SELECT distinct PUB_Area_Code_N.Area_Code, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_N.Area_Name, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_N.County_Code, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.Postal_Code, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.Postal_Name, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.Town_Name, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.County_Name, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Gov_County_Code, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Gov_County_Name, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Dist_Code , " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Dist_Name " & vbCrLf)
                'varname1.Append("FROM   PUB_Postal_Area, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_N, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Gov_Area " & vbCrLf)
                'varname1.Append("WHERE  PUB_Postal_Area.Area_Code = PUB_Area_Code_N.Orig_Area_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Area.Postal_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Gov_Area.Postal_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Postal_Gov_Area.Dist_Code = PUB_Area_Code_Gov.Dist_Code " & vbCrLf)
                'varname1.Append("ORDER  BY PUB_Area_Code_N.Area_Code")

                Dim varname1 As New System.Text.StringBuilder
                'varname1.Append("SELECT distinct PUB_Area_Code_N.Area_Code, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_N.Area_Name, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_N.County_Code, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.Postal_Code, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.Postal_Name, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.Town_Name, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code.County_Name, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Gov_County_Code, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Gov_County_Name, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Dist_Code , " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov.Dist_Name " & vbCrLf)
                'varname1.Append("FROM   PUB_Postal_Area, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_N, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Code, " & vbCrLf)
                'varname1.Append("       PUB_Area_Code_Gov, " & vbCrLf)
                'varname1.Append("       PUB_Postal_Gov_Area " & vbCrLf)
                'varname1.Append("WHERE  PUB_Postal_Area.Area_Code = PUB_Area_Code_N.Orig_Area_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Area.Postal_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Gov_Area.Postal_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Postal_Gov_Area.Dist_Code = PUB_Area_Code_Gov.Dist_Code " & vbCrLf)
                'varname1.Append("       AND PUB_Area_Code_Gov.Gov_County_Code ='64' " & vbCrLf)
                'varname1.Append("	    " & vbCrLf)
                'varname1.Append("UNION ALL " & vbCrLf)
                'varname1.Append(" " & vbCrLf)
                varname1.Append("SELECT distinct PUB_Area_Code_N.Area_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.Area_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.County_Code, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Postal_Code, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Postal_Name, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.Town_Name, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code.County_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Gov_County_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Gov_County_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Dist_Code , " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov.Dist_Name, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N.Sort_Value " & vbCrLf)
                varname1.Append(" FROM   PUB_Postal_Area, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_N, " & vbCrLf)
                varname1.Append("       PUB_Postal_Code, " & vbCrLf)
                varname1.Append("       PUB_Area_Code_Gov, " & vbCrLf)
                varname1.Append("       PUB_Postal_Gov_Area " & vbCrLf)
                varname1.Append(" WHERE  PUB_Postal_Area.Area_Code = PUB_Area_Code_N.Orig_Area_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Area.Postal_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Code.Postal_Code = PUB_Postal_Gov_Area.Postal_Code " & vbCrLf)
                varname1.Append("       AND PUB_Postal_Gov_Area.Dist_Code = PUB_Area_Code_Gov.Dist_Code " & vbCrLf)
                 
                varname1.Append(" ORDER  BY PUB_Area_Code_N.Sort_Value, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_N.Area_Code, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_N.Area_Name, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_N.County_Code, " & vbCrLf)
                varname1.Append("          PUB_Postal_Code.Postal_Code, " & vbCrLf)
                varname1.Append("          PUB_Postal_Code.Postal_Name, " & vbCrLf)
                varname1.Append("          PUB_Postal_Code.Town_Name, " & vbCrLf)
                varname1.Append("          PUB_Postal_Code.County_Name, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_Gov.Gov_County_Code, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_Gov.Gov_County_Name, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_Gov.Dist_Code, " & vbCrLf)
                varname1.Append("          PUB_Area_Code_Gov.Dist_Name")


                Return varname1.ToString
        End Select


        Return ""
    End Function
End Class
