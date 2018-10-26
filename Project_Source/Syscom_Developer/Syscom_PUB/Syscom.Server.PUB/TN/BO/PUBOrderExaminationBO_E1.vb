Imports System.Text
Imports System.Data.SqlClient
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP

Public Class PUBOrderExaminationBO_E1
    Inherits PubOrderExaminationBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBOrderExaminationBO_E1
    Public Overloads Shared Function getInstance() As PUBOrderExaminationBO_E1
        If instance Is Nothing Then
            instance = New PUBOrderExaminationBO_E1
        End If
        Return instance
    End Function
#End Region


#Region "2009/10/20 Add By Jen 檢驗資料"

    ''' <summary>
    ''' 檢驗檢查資料
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order, PUB_Order_Price</remarks>
    Public Function queryActiveOrderCode(ByVal OrderCode As String) As DataTable

        Dim cmdStrOrder As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrOrder.AppendLine("select * ")
        cmdStrOrder.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrder.AppendLine("where Order_Code = @OrderCode ")

        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrder.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)

                    End With

                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dtOrder)
                    End Using

                End Using

            End Using

            Return dtOrder

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "2009/12/14 Add By Jen 更新sheet_detail內關聯的欄位"

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="dt">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updateSheetDetailRelatedOrderExamination(ByVal dt As DataTable, Optional ByRef conn As IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = getConnection()
            End If
            If conn.State <> ConnectionState.Open Then conn.Open()

            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Default_Main_Body_Site_Code=@Default_Main_Body_Site_Code ,Default_Body_Site_Code=@Default_Body_Site_Code , Default_Side_Id=@Default_Side_Id , Is_Scheduled=@Is_Scheduled , Is_Print_Order_Note=@Is_Print_Order_Note, " & _
            " Opd_Report_Time = @Opd_Report_Time, Emg_Report_Time = @Emg_Report_Time, Ipd_Report_Time = @Ipd_Report_Time, " & _
            " Is_Main_Body_Site = @Is_Main_Body_Site, Is_Body_Site = @Is_Body_Site, Is_Side_Id = @Is_Side_Id, Is_PACS = @Is_PACS, Is_With_Contrast = @Is_With_Contrast, Nhi_Body_Site_Code = @Nhi_Body_Site_Code, Is_No_Check_In = @Is_No_Check_In " & _
            " where Order_Code=@Order_Code "

            For Each row As DataRow In dt.Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Default_Main_Body_Site_Code", row.Item("Default_Main_Body_Site_Code"))
                    command.Parameters.AddWithValue("@Default_Body_Site_Code", row.Item("Default_Body_Site_Code"))
                    command.Parameters.AddWithValue("@Default_Side_Id", row.Item("Default_Side_Id"))
                    command.Parameters.AddWithValue("@Is_Scheduled", row.Item("Is_Scheduled"))
                    command.Parameters.AddWithValue("@Is_Print_Order_Note", row.Item("Is_Print_Order_Note"))

                    command.Parameters.AddWithValue("@Opd_Report_Time", row.Item("Opd_Report_Time"))
                    command.Parameters.AddWithValue("@Emg_Report_Time", row.Item("Emg_Report_Time"))
                    command.Parameters.AddWithValue("@Ipd_Report_Time", row.Item("Ipd_Report_Time"))

                    command.Parameters.AddWithValue("@Is_Main_Body_Site", row.Item("Is_Main_Body_Site"))
                    command.Parameters.AddWithValue("@Is_Body_Site", row.Item("Is_Body_Site"))
                    command.Parameters.AddWithValue("@Is_Side_Id", row.Item("Is_Side_Id"))
                    command.Parameters.AddWithValue("@Is_PACS", row.Item("Is_PACS"))
                    command.Parameters.AddWithValue("@Is_With_Contrast", row.Item("Is_With_Contrast"))
                    command.Parameters.AddWithValue("@Nhi_Body_Site_Code", row.Item("Nhi_Body_Site_Code"))
                    command.Parameters.AddWithValue("@Is_No_Check_In", row.Item("Is_No_Check_In"))

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

    ''' <summary>
    ''' 取得 PUB_Order_Examination 中 Is_Scheduled='Y' And Is_No_Check_In='Y' 的成大碼
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryIsScheduleIsYAndIsNoCheckInIsYOrderCode() As String()

        Dim returnLinkedList As New LinkedList(Of String)

        Try

            Using conn As SqlConnection = getConnection()

                conn.Open()

                Using command As SqlCommand = conn.CreateCommand

                    command.CommandText = "SELECT DISTINCT Order_Code" & _
                                           " FROM PUB_Order_Examination" & _
                                          " WHERE Is_Scheduled='Y'" & _
                                            " AND Is_No_Check_In='Y'"

                    Using reader As SqlDataReader = command.ExecuteReader

                        While reader.Read
                            returnLinkedList.AddLast(StringUtil.nvl(reader.Item("Order_Code")).Trim)
                        End While

                        reader.Close()
                    End Using

                End Using

                conn.Close()

            End Using

            Return returnLinkedList.ToArray

        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        End Try

    End Function

    '#Region "2009/10/20 Add By Jen 檢驗資料"

    '    ''' <summary>
    '    ''' 檢查表單資料
    '    ''' </summary>
    '    ''' <param name="sheetCode"></param>
    '    ''' <returns></returns>
    '    ''' <remarks>PUB_Order, PUB_Order_Price</remarks>
    '    Public Function queryLikeSheetCode(ByVal sheetCode As String) As DataTable

    '        Dim cmdStrOrder As New StringBuilder
    '        '----------------------------------------------------------------------------
    '        'Select SQL
    '        '----------------------------------------------------------------------------
    '        cmdStrOrder.AppendLine("select * ")
    '        cmdStrOrder.Append("from ").Append(tableName).AppendLine(" ")
    '        cmdStrOrder.Append("where Order_Code like '").Append(sheetCode).Append("%' ")

    '        '----------------------------------------------------------------------------
    '        'From&Join SQL
    '        '----------------------------------------------------------------------------
    '        '----------------------------------------------------------------------------
    '        'Where SQL
    '        '----------------------------------------------------------------------------
    '        '----------------------------------------------------------------------------
    '        'Order By SQL
    '        '----------------------------------------------------------------------------
    '        '----------------------------------------------------------------------------
    '        Try
    '            Dim dtOrder As DataTable = New DataTable(tableName)

    '            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
    '                Using sqlCmd As SqlCommand = New SqlCommand
    '                    With sqlCmd
    '                        .CommandText = cmdStrOrder.ToString
    '                        .CommandType = CommandType.Text
    '                        .Connection = conn

    '                    End With

    '                    conn.Open()
    '                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
    '                        da.Fill(dtOrder)
    '                    End Using

    '                End Using

    '            End Using

    '            Return dtOrder

    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

End Class

