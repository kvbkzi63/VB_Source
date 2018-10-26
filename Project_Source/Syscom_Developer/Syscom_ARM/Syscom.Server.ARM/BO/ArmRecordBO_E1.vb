Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports System.Data.SqlClient

Public Class ArmRecordBO_E1
    Inherits ArmRecordBO

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Shadows ReadOnly Property getInstance() As ArmRecordBO_E1
        Get
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New ArmRecordBO_E1()
    End Class

#End Region

#Region " 查詢全部"

    ''' <summary>
    '''查詢全部
    ''' </summary>
    ''' <returns>查詢資料全部資料內容</returns>
    ''' <remarks></remarks>
    Public Function queryArmRecord(ByVal employeeCode As String, ByVal functionNo As String, ByVal startDate As String, ByVal endDate As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT ASS.Sub_System_No, " & vbCrLf)
            sqlString.Append("       ASS.Sub_System_Name, " & vbCrLf)
            sqlString.Append("       AFS.Fun_Function_No, " & vbCrLf)
            sqlString.Append("       AFS.Fun_Function_Name, " & vbCrLf)
            sqlString.Append("       Count(*) AS Click_Times " & vbCrLf)
            sqlString.Append("FROM   ARM_Record AS AR " & vbCrLf)
            sqlString.Append("       INNER JOIN PUB_Employee AS PE " & vbCrLf)
            sqlString.Append("         ON AR.Rec_User = PE.Employee_Code " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Sub_System AS ASS " & vbCrLf)
            sqlString.Append("         ON AR.Sub_System_No = ASS.Sub_System_No " & vbCrLf)
            sqlString.Append("       INNER JOIN arm_fun_System AS AFS " & vbCrLf)
            sqlString.Append("         ON AR.Fun_Function_No = AFS.Fun_Function_No " & vbCrLf)
            sqlString.Append("WHERE  1 = 1 " & vbCrLf)

            If employeeCode <> "" Then
                sqlString.Append("       AND AR.Rec_User = @Rec_User " & vbCrLf)
            End If

            If startDate <> "" Or endDate <> "" Then
                sqlString.Append("       AND AR.Rec_DateTime BETWEEN @Start_Time AND @End_Time " & vbCrLf)
            End If

            If functionNo <> "" Then
                sqlString.Append("       AND AR.Fun_Function_No = @Fun_Function_No " & vbCrLf)
            End If

            sqlString.Append("GROUP  BY ASS.Sub_System_No, " & vbCrLf)
            sqlString.Append("          ASS.Sub_System_Name, " & vbCrLf)
            sqlString.Append("          AFS.Fun_Function_No, " & vbCrLf)
            sqlString.Append("          AFS.Fun_Function_Name ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Rec_User", employeeCode)
            command.Parameters.AddWithValue("@Start_Time", startDate)
            command.Parameters.AddWithValue("@End_Time", endDate & " 23:59:59")
            command.Parameters.AddWithValue("@Fun_Function_No", functionNo)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
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

#End Region

#Region " 新增資料 "

    ''' <summary>
    ''' 新增資料
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2015-09-03</remarks>
    Public Function insertData(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
             
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            '取得Server端的時間
            For Each row As DataRow In ds.Tables(0).Rows
                row.Item("Rec_DateTime") = Now.ToString(Syscom.Comm.Utility.DateUtil.DateTimeFullTypeSlash)
            Next

            Return insert(ds, conn)

        Catch sqlex As SQLException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
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
