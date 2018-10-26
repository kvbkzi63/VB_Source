Imports System.Data.SqlClient
Imports log4net
Imports System.Text
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP

Public Class PUBExcludeDrugSetBO_E1
    Inherits PubExcludeDrugSetBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBExcludeDrugSetBO_E1

    Public Overloads Shared Function getInstance() As PUBExcludeDrugSetBO_E1
        If instance Is Nothing Then
            instance = New PUBExcludeDrugSetBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 查詢醫令排除藥費資料
    ''' </summary>
    ''' <param name="OrderCode">醫令碼</param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function queryExclusiveDrugSetData(ByVal OrderCode As String) As DataTable

        Dim cmdStrExc As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("select * ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStrExc.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("where Order_Code = @OrderCode ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrExc.ToString
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

    Public Function queryExclusiveDrugSetData2(ByVal OrderCode As String) As DataTable

        Dim cmdStrExc As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("Select  Rtrim(A.Code_Name) As Code_Name ,B.Effect_Date ,B.End_Date ,Rtrim(B.Exclude_Drug_Memo) As Exclude_Drug_Memo,A.Code_Id ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("From PUB_SYSCODE A Left Outer Join PUB_Exclude_Drug_Set B ON ")
        cmdStrExc.AppendLine("B.Order_Code = @OrderCode And ")
        cmdStrExc.AppendLine("B.Exclude_Drug_Type_Id =A.Code_Id And ")
        cmdStrExc.AppendLine("B.Effect_Date <='" & Now.ToString("yyyy/MM/dd") & "' And ")
        cmdStrExc.AppendLine("B.End_Date >='" & Now.ToString("yyyy/MM/dd") & "' ")

        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("Where A.Type_Id ='38' And A.Dc <>'Y' ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrExc.ToString
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


    ''' <summary>
    ''' 刪除醫令排除藥費資料
    ''' </summary>
    ''' <param name="OrderCode">醫令碼</param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function deleteExclusiveDrugSetByOrderCode(ByVal OrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing
        Dim count As Integer = 0

        Try
            Dim cmdStrExc As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStrExc.AppendLine("delete ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStrExc.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStrExc.AppendLine("where Order_Code = @OrderCode ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            '----------------------------------------------------------------------------

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = cmdStrExc.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Order_Code", OrderCode)

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
       Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function


    ''' <summary>
    ''' 先刪除後新增醫令排除藥費資料
    ''' </summary>
    ''' <param name="OrderCode">醫令碼</param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function insertExclusiveDrugSetByOrderCode(ByVal OrderCode As String, ByVal insertData As DataSet) As Integer

        Dim cmdStrExc As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("delete ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStrExc.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("where Order_Code = @OrderCode ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim count As Integer = -1

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand

                    conn.Open()

                    With sqlCmd
                        .CommandText = cmdStrExc.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)

                        count = sqlCmd.ExecuteNonQuery
                    End With

                    '新增資料
                    insert(insertData)

                End Using

            End Using

            Return count

        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
