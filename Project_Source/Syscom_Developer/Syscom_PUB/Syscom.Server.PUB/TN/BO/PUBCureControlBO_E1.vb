Imports System.Data.SqlClient
Imports log4net
Imports System.Text
Imports Syscom.Server.BO

Public Class PUBCureControlBO_E1
    Inherits PubCureControlBO

    Dim tableName1 As String = "PUB_Cure_Control"
  
#Region "########## getInstance ##########"

    Private Shared instance As PUBCureControlBO_E1

    Public Overloads Shared Function getInstance() As PUBCureControlBO_E1
        If instance Is Nothing Then
            instance = New PUBCureControlBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub



    ''' <summary>
    ''' 程式說明：取得療程控制檔資料
    ''' 開發人員：James
    ''' 開發日期：2009.10.30
    ''' </summary>
    ''' <param name=" CureTypeId">療程類型</param>
    ''' <remarks></remarks> 
    ''' <修改註記>
    ''' 
    ''' </修改註記>
    Public Function queryPUBCureControlByCond(ByVal CureTypeId As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select * " & _
                                  "From  PUB_Cure_Control   " & _
                                  "Where   Cure_Type_Id='" & CureTypeId & "' "


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

    ''' <summary>
    ''' 使用Cure_Type_Id查詢
    ''' </summary>
    ''' <param name="CureTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryByCureTypeId(ByVal CureTypeId As String) As DataSet
        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(A.Cure_Type_Id)    AS Cure_Type_Id, " & vbCrLf)
        var1.Append("       RTRIM(A.Time_Control_Id) AS Time_Control_Id, " & vbCrLf)
        var1.Append("       A.Control_Value, " & vbCrLf)
        var1.Append("       A.Max_Cnt, " & vbCrLf)
        var1.Append("       RTRIM(A.Is_Reg_Fee)      AS Is_Reg_Fee, " & vbCrLf)
        var1.Append("       RTRIM(A.Is_Fee_Check)    AS Is_Fee_Check " & vbCrLf)
        var1.Append("FROM   PUB_Cure_Control A " & vbCrLf)
        var1.Append("WHERE  A.Cure_Type_Id = CASE " & vbCrLf)
        var1.Append("                          WHEN @Cure_Type_Id = '' THEN A.Cure_Type_Id " & vbCrLf)
        var1.Append("                          ELSE @Cure_Type_Id " & vbCrLf)
        var1.Append("                        END " & vbCrLf)

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()

                Dim _command As New SqlCommand(var1.ToString, _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Cure_Type_Id", CureTypeId)
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function
End Class
