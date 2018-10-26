Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBZoneRoomBO_E1
    Inherits PubZoneRoomBO
    Dim tableName1 As String = "PUB_Zone_Room"
    Private Shared instance As PUBZoneRoomBO_E1

    Public Overloads Shared Function getInstance() As PUBZoneRoomBO_E1
        instance = New PUBZoneRoomBO_E1
        Return instance
    End Function

    '取得診間相關資料 
    Public Overloads Function queryPUBZoneRoom() As System.Data.DataSet 'Implements IPUBZoneRoomBO.queryPUBZoneRoom
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "   Select Zone_Id,Room_Code,Room_Name,Room_En_Name,Tel_Ext_No " & _
                                  "   From  " & tableName1 & " " & _
                                    " Order By Zone_Id"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '取得看診區相關資料 
    Public Function queryPUBZoneRoomGetZoneId() As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "   Select distinct Zone_Id,Zone_Id AS Zone_Name " & _
                                  "   From  " & tableName1 & " " & _
                                  "   Order By Zone_Id"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '取得診間號相關資料 
    Public Function queryPUBZoneRoomByZoneId(ByVal pvtZoneId As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "   Select distinct Room_Code,Room_Name,Room_En_Name,Tel_Ext_No " & _
                                  "   From  " & tableName1 & " " & _
                                  "   Where Zone_Id='" & pvtZoneId & "' " & _
                                  "   Order By Room_Code"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "     queryPUBZoneRoomForMissMeal "

    ''' <summary>
    ''' queryPUBZoneRoomForMissMeal
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-19</remarks>
    Public Function queryPUBZoneRoomForMissMeal(ByVal Room_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT Room_Code, " & vbCrLf)
            varname1.Append("       Room_Name " & vbCrLf)
            varname1.Append("FROM   PUB_Zone_Room ")
            varname1.Append("WHERE  Room_Code = @Room_Code ")

            command.CommandText = varname1.ToString

            command.Parameters.AddWithValue("@Room_Code", Room_Code)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Zone_Room")
                adapter.Fill(ds, "PUB_Zone_Room")
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    '取得急診診間號相關資料 
    Public Function queryPUBZoneRoomByType(ByVal inSourceType As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "   Select Room_Code,Room_Name,Room_En_Name,Tel_Ext_No " & _
                                  "   From  " & tableName1 & " "

            If inSourceType = "O" Then
                command.CommandText &= "   Where Substring(Room_Code,3,2)<>'99' "

            ElseIf inSourceType = "E" Then
                command.CommandText &= "   Where Substring(Room_Code,3,2)='99' "

            End If

            command.CommandText &= "   Order By Room_Code"


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "PUBZoneRoomBO_E1  區診間維護檔"
    ''' <summary>
    ''' 查詢全國醫療服務卡資料
    ''' </summary>
    ''' <param name="strZoneId">診區代碼</param>
    ''' <param name="strRoomCode">診間號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBZoneRoomByCond(ByVal strZoneId As String, ByVal strRoomCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("SELECT  B.Code_Name, A.*  FROM  PUB_Zone_Room A left join pub_syscode B on  A.zone_id = B.code_id and B.Type_id = '12'and B.dc='N' where 1=1")
            If strZoneId <> "" Then
                sql.Append(" and Zone_Id = ").Append(" @Zone_Id ")
            End If
            If strRoomCode <> "" Then
                sql.Append(" AND Room_Code = ").Append(" @Room_Code ")

            End If
            command.CommandText = sql.ToString()
            command.Parameters.AddWithValue("@Zone_Id", strZoneId)
            command.Parameters.AddWithValue("@Room_Code", strRoomCode)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            'LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region
    
End Class


