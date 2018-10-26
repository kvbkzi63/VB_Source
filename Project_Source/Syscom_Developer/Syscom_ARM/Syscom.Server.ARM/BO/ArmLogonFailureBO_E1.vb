Imports Syscom.Server.BO
Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Comm.EXP

Public Class ArmLogonFailureBO_E1
    Inherits ArmLogonFailureBO

#Region "Singleton Design Pattern - Fully Thread Safety"

    ' ''' <summary>
    ' ''' 阻止外部直接進行新建立的宣告
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub New()
    'End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Shadows ReadOnly Property getInstance() As ArmLogonFailureBO_E1
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

        Public Shared ReadOnly instance As New ArmLogonFailureBO_E1()
    End Class

#End Region

#Region "    以ＰＫ查詢資料 "

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByEmployeeCode(ByRef pk_Employee_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT TOP 1 Employee_Code, " & vbCrLf)
            sqlString.Append("             Max(Login_Try_Date) AS Login_Try_Date, " & vbCrLf)
            sqlString.Append("             Login_Try_Times, " & vbCrLf)
            sqlString.Append("             Machine_Name, " & vbCrLf)
            sqlString.Append("             IP_Address " & vbCrLf)
            sqlString.Append("FROM   ARM_Logon_failure " & vbCrLf)
            sqlString.Append("WHERE  Employee_Code = @Employee_Code " & vbCrLf)
            sqlString.Append("GROUP  BY Employee_Code, " & vbCrLf)
            sqlString.Append("          Login_Try_Times, " & vbCrLf)
            sqlString.Append("          Machine_Name, " & vbCrLf)
            sqlString.Append("          IP_Address " & vbCrLf)
            sqlString.Append("ORDER  BY Login_Try_Date DESC ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Employee_Code", pk_Employee_Code)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function


#End Region

#Region "    登入失敗超過3次UI "

#Region "    登入失敗超過3次查詢 "

    Public Function ArmLogonFailureQueryLoginFailure(ByVal str_StartDay As String, ByVal str_EndDay As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim content As New System.Text.StringBuilder
            content.Append(" select " & vbCrLf)
            content.Append(" Rtrim(ALF.Employee_Code),Rtrim(PUB_Employee.Employee_Name),dbo.AdToRocTime(ALF.Login_Try_Date), " & vbCrLf)
            content.Append(" Rtrim(ALF.Login_Try_Times),Rtrim(ALF.Machine_Name), " & vbCrLf)
            content.Append(" Rtrim(ALF.IP_Address) " & vbCrLf)
            content.Append("from ARM_Logon_Failure as ALF " & vbCrLf)
            content.Append("left join  PUB_Employee on  PUB_Employee.Employee_Code = ALF.Employee_Code " & vbCrLf)
            content.Append("where 1=1 " & vbCrLf)
            content.Append("and ALF.Login_Try_Times>=3 " & vbCrLf)

            If str_StartDay <> "" AndAlso str_EndDay <> "" Then

                content.Append("and ALF.Login_Try_Date between '" & str_StartDay & "' and '" & str_EndDay & "'")

            End If

            command.CommandText = content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#End Region
   
End Class
