
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

Public Class PUBDoctorBO_E2
    Dim tableName As String = "PUB_Doctor"
    Private Shared myInstance As PUBDoctorBO_E2

    Public Overloads Shared Function getInstance() As PUBDoctorBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBDoctorBO_E2()
        End If
        Return myInstance
    End Function
    '依傳入醫師代碼取得有效醫師相關資料 註:醫師是否有效以Announce_Effect_Date與Announce_End_Date判斷
    Public Overloads Function queryPUBDoctor(ByVal DoctorCode As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   Select Employee_Code,Doctor_Code,Level_Id,Dept_Code,Announce_Effect_Date,Announce_End_Dat," & _
                                 "           License_No,License_Effect_Date,License_End_Date " & _
                                    " From  " & tableName & " " & _
                                    " Where Announce_Effect_Date<= " & Now & " And Announce_End_Date >= " & Now & "" & _
                                    " Order By Doctor_Code"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 員工編號查詢醫師信息
    ''' </summary>
    ''' <param name="EmployeeCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBDoctorByEmployeeCode(ByVal EmployeeCode As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   Select A.Employee_Code,A.Doctor_Code,A.Dept_Code, B.Dept_Name,C.Employee_Name" & _
                                    " From  " & tableName & " A left join PUB_Department B on (A.Dept_Code=B.Dept_Code) " & _
                                    " left join PUB_Employee C on (A.Employee_Code=C.Employee_Code) " & _
                                    " Where A.Employee_Code = '" & EmployeeCode & "' " & _
                                    " Order By A.Employee_Code"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 所屬單位查詢醫師信息
    ''' </summary>
    ''' <param name="DeptCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBDoctorByDeptCode(ByVal DeptCode As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   Select A.Employee_Code,A.Doctor_Code,A.Dept_Code, B.Dept_Name,C.Employee_Name" & _
                                    " From  " & tableName & " A left join PUB_Department B on (A.Dept_Code=B.Dept_Code) " & _
                                    " left join PUB_Employee C on (A.Employee_Code=C.Employee_Code) " & _
                                    " Where A.Dept_Code = '" & DeptCode & "' AND A.Announce_Effect_Date<= GETDATE() And A.Announce_End_Date >= GETDATE()" & _
                                    " Order By A.Employee_Code"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢醫師信息
    ''' </summary>
    ''' <param name="DoctorCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBDoctorByDoctorCode(ByVal DoctorCode As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "  select PUB_Doctor.Doctor_Code,PUB_Employee.Employee_Name, " & _
                                  "  PUB_Employee.Employee_Code,PUB_Employee.Idno from PUB_Doctor " & _
                                  " left join PUB_Employee on (PUB_Employee.Employee_Code = PUB_Doctor.Employee_Code) " & _
                                  " where PUB_Doctor.Doctor_Code = '" & DoctorCode & "' " & _
                                  " and PUB_Doctor.Announce_Effect_Date <= GETDATE()  " & _
                                  " and PUB_Doctor.Announce_End_Date >=GETDATE()  "


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''查詢全部
    ''' </summary>
    ''' <returns>查詢資料全部資料內容</returns>
    ''' <remarks></remarks>
    Public Function queryPUBDoctorByDoctorCode2(ByVal DoctorCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
            End If

            Dim content As New StringBuilder()

            content.Append(" select  PD.Doctor_Code,PD.Employee_Code ,PE.Employee_Name,PE.Idno from PUB_Doctor PD ").Append(vbCrLf)
            content.Append(" left join PUB_Employee PE on (PE.Employee_Code = PD.Employee_Code)  ").Append(vbCrLf)
            content.Append("   ").Append(vbCrLf)
            content.Append(" where PD.Doctor_Code = @Doctor_Code  ").Append(vbCrLf)
            content.Append(" and PD.Announce_Effect_Date <= @Date  ").Append(vbCrLf)
            content.Append(" and PD.Announce_End_Date >=@Date  ").Append(vbCrLf)
            content.Append("   ").Append(vbCrLf)

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = content.ToString

            command.Parameters.AddWithValue("@Doctor_Code", DoctorCode)
            command.Parameters.AddWithValue("@Date", Now.ToString("yyyy/MM/dd"))

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

#Region "20110106 營養諮詢作業使用 add by yunfei"
    ''' <summary>
    ''' 查詢所屬科室之醫師信息
    ''' </summary>
    ''' <param name="DeptCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBDoctorByDeptCode2(ByVal DeptCode As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   Select A.Doctor_Code,A.Employee_Code,B.Employee_Name" & _
                                    " From  " & tableName & _
                                    " A inner join PUB_Employee B on A.Employee_Code =B.Employee_Code " & _
                                    " Where SUBSTRING (A.Dept_Code,1,2) = '" & DeptCode & "' AND A.Announce_Effect_Date<= GETDATE() And A.Announce_End_Date >= GETDATE()" & _
                                    " Order By A.Doctor_Code"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


#Region "20160620 取得護理站 add by remote"
    ''' <summary>
    ''' 取得護理站
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryStationNo() As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   SELECT Station_No, Station_Name FROM   PUB_Station WHERE  Dc = 'N' " & _
                                    " order by Station_No"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

End Class


