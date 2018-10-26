Imports System.Data.SqlClient
Imports Syscom.Server.SQL
'
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
'
Imports System.Text
Imports Syscom.Comm.EXP
Public Class PUBOrderStandingBO_E1

    ''' <summary>
    ''' Get instance
    ''' </summary>
    ''' <value></value>
    ''' <returns>instance of this class</returns>
    ''' <remarks>added by Ken 2009-07-16</remarks>
    Public Shared ReadOnly Property Instance() As PUBOrderStandingBO_E1
        Get
            Return New PUBOrderStandingBO_E1
        End Get
    End Property

    ''' <summary>
    ''' Get SQL connection.
    ''' </summary>
    ''' <returns>sql connection</returns>
    ''' <remarks>added by Ken 2009-07-16</remarks>
    Private Function GetSqlConnection() As SqlConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    ''' <summary>
    ''' Get the day of the week.
    ''' 7: Sunday
    ''' 1: Monday
    ''' 2: Tuesday
    ''' 3: Wedesday
    ''' 4: Thursday
    ''' 5: Friday
    ''' 6: Saturday
    ''' </summary>
    ''' <returns>the day of the week</returns>
    ''' <remarks>added by Ken 2009-07-16</remarks>
    Private Function DayOfWeek() As Int32

        Return IIf(DateTime.Now.DayOfWeek = System.DayOfWeek.Sunday, 7, DateTime.Now.DayOfWeek)
    End Function

    ''' <summary>
    ''' Get consumption
    ''' </summary>
    ''' <param name="orderCode">醫令代碼</param>
    ''' <param name="DeptCode">就診科別</param>
    ''' <returns></returns>
    ''' <remarks>added by Ken 2009-07-16</remarks>
    Public Function queryPUBOrderStandingConsumptionDept(ByVal orderCode As String, ByVal DeptCode As String) As DataSet

        Dim _ds As New DataSet

        Dim _now As Date = Now

        Dim _dayOfWeek As Int32 = Me.DayOfWeek()

        Dim var1 As New System.Text.StringBuilder
        var1.AppendFormat("SELECT Rtrim(PUB_Order_Standing.Consumption_Unit) AS Consumption_Dept, " & vbCrLf)
        var1.AppendFormat("       'Y'                                        AS Is_Standing " & vbCrLf)
        var1.AppendFormat("FROM   PUB_Order_Standing " & vbCrLf)
        var1.AppendFormat("WHERE  Order_Code = '{0}' " & vbCrLf, orderCode.Replace("'", "''"))
        var1.AppendFormat("       AND (Service_Start_Time <= '{0}' " & vbCrLf, _now.ToString("HH:mm"))
        var1.AppendFormat("            AND Service_End_Time >= '{0}') " & vbCrLf, _now.ToString("HH:mm"))
        var1.AppendFormat("       AND Week = CASE  " & vbCrLf)
        var1.AppendFormat("                    WHEN (SELECT Count(PUB_Order_Standing.Consumption_Unit) " & vbCrLf)
        var1.AppendFormat("                          FROM   PUB_Order_Standing " & vbCrLf)
        var1.AppendFormat("                          WHERE  Order_Code = '{0}' " & vbCrLf, orderCode.Replace("'", "''"))
        var1.AppendFormat("                                 AND Dept_Code = '{0}' " & vbCrLf, DeptCode.Replace("'", "''"))
        var1.AppendFormat("                                 AND (Service_Start_Time <= '{0}' " & vbCrLf, _now.ToString("HH:mm"))
        var1.AppendFormat("                                      AND Service_End_Time > '{0}') " & vbCrLf, _now.ToString("HH:mm"))
        var1.AppendFormat("                                 AND Week = {0}) = 0 " & vbCrLf, _dayOfWeek)
        var1.AppendFormat("                    THEN 0 " & vbCrLf)
        var1.AppendFormat("                    ELSE {0} " & vbCrLf, _dayOfWeek)
        var1.AppendFormat("                  END " & vbCrLf)
        '============= Added by Ken on 2009-11-16 ===================
        var1.AppendFormat("       AND Dept_Code = '{0}' " & vbCrLf, DeptCode.Replace("'", "''"))
        '============================================================

        '============= Added by Ken on 2011-05-18 ===================
        var1.AppendFormat("       AND Dc = 'N' " & vbCrLf)
        '============================================================

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(var1.ToString, _sqlConnection)
                _dataAdapter.Fill(_ds, "PUB_Order_Standing")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

End Class
