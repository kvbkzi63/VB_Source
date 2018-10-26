Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBPatientDisabilityBO_E1
    Inherits PubPatientDisabilityBO

    Private Shared instance As PUBPatientDisabilityBO_E1

    Public Overloads Shared Function getInstance() As PUBPatientDisabilityBO_E1
        instance = New PUBPatientDisabilityBO_E1
        Return instance
    End Function

    Public Function queryPubPatientDisabilityByKey(ByVal chartNo As String) As DataSet

        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn

        Dim SqlCmd As SqlCommand
        Dim cmdStr As String = ""
        Dim myReader As SqlDataReader = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds As DataSet


        cmdStr = " Select * " & _
                 " From  PUB_Patient_Disability A, PUB_SYSCODE B , PUB_SYSCODE C " & _
                 " Where A.Chart_No ='" & chartNo & "'  And A.Disability_Type_Id=B.Code_Id And B.Type_Id='212' And A.Disability_Type_Id=C.Code_Id And C.Type_Id='214'  And  A.Effect_Date <= Getdate()  And A.End_Date >= Getdate()  And ( B.DC<>'Y' Or B.DC Is null) And ( C.DC<>'Y' Or C.DC Is null) ORDER BY  A.End_Date  , B.Code_Id,C.Code_Id "

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
            Throw ex
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return ds



    End Function

    ''' <summary>
    ''' 程式說明：取得殘障記錄的迄日
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.04
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <param name="OpdVisitDate">看診日期</param>
    ''' <returns>殘障記錄的迄日</returns>
    ''' <remarks>For OPC收退費用</remarks>
    Friend Function getEndDateForReceiptUI(ByVal ChartNo As String, ByVal OpdVisitDate As String) As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select")
        cmdStr.AppendLine("A.End_Date")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from PUB_Patient_Disability as A")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where 1=1")
        cmdStr.AppendLine("and A.Chart_No = @Chart_No")
        cmdStr.AppendLine("and A.Effect_Date <= @Opd_Visit_Date and A.End_Date >= @Opd_Visit_Date")
        '20131113 by ccr 若有多筆以鑑定最新一筆顯示
        cmdStr.AppendLine("ORDER  BY a.end_date DESC, a.effect_date DESC ")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@Chart_No", ChartNo)
                        sqlCmd.Parameters.AddWithValue("@Opd_Visit_Date", OpdVisitDate)

                    End With

                    conn.Open()

                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        Using dt As DataTable = New DataTable("disabilityDataDT")

                            da.Fill(dt)

                            Return dt
                        End Using
                    End Using

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：取得殘障序號的最大值 by Chart_No
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.06
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <returns>殘障記錄的迄日</returns>
    ''' <remarks>For OPC收退費用</remarks>
    Friend Function getMaxPatientDisabilityNoForReceiptUI(ByVal ChartNo As String) As Integer
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select")
        cmdStr.AppendLine("MAX(Patient_Disability_No) as Max_Patient_Disability_No")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from PUB_Patient_Disability as A")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where 1=1")
        cmdStr.AppendLine("and A.Chart_No = @Chart_No")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@Chart_No", ChartNo)

                    End With

                    conn.Open()

                    Return sqlCmd.ExecuteScalar()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：取得是否有有效的殘障紀錄以及最大序號 by Chart_No
    ''' 開發人員：Will
    ''' 開發日期：20151014
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <returns>回傳0，則無相關紀錄，回傳1則有</returns>
    ''' <remarks>For OPC收退費用</remarks>
    Friend Function getPatientDisabilityRecordForReceiptUI(ByVal ChartNo As String) As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("SELECT COUNT(Chart_No) AS RecordCount ,")
        cmdStr.AppendLine("       CASE WHEN (SELECT MAX(A.Patient_Disability_No) FROM PUB_Patient_Disability A WHERE A.Chart_No =@Chart_No)  IS NULL THEN 0 ")
        cmdStr.AppendLine("       ELSE (SELECT MAX(A.Patient_Disability_No) FROM PUB_Patient_Disability A WHERE A.Chart_No =@Chart_No)  END AS MAXDisability_No")

        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("FROM Pub_Patient_Disability PPD")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("WHERE PPD.Chart_No = @Chart_No")
        cmdStr.AppendLine("  AND @Now BETWEEN PPD.Effect_Date AND PPD.End_Date")

        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@Chart_No", ChartNo)
                        sqlCmd.Parameters.AddWithValue("@Now", Now.Date)
                        Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            Using dt As DataTable = New DataTable("RecodeDT")

                                da.Fill(dt)

                                Return dt
                            End Using
                        End Using
                    End With

                    conn.Open()

                    Return sqlCmd.ExecuteScalar()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
