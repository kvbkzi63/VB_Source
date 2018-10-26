Imports System.Text
Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.EXP

Public Class PubSheetDetailBO_E1
    Inherits PubSheetDetailBO



#Region "########## getInstance ##########"

    Private Shared instance As PubSheetDetailBO_E1

    Public Overloads Shared Function getInstance() As PubSheetDetailBO_E1
        If instance Is Nothing Then
            instance = New PubSheetDetailBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 程式說明：取得所有表單明細資料
    ''' 開發人員：James
    ''' 開發日期：2010.03.01
    ''' </summary>
    ''' <returns>DataSet-表單明細資料</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.PUB_Sheet_Detail
    ''' </使用表單>
    ''' <修改註記>
    ''' 
    ''' </修改註記>
    Public Function queryPUBSheetDetailAll() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select Sheet_Code ,Order_Code  From PUB_Sheet_Detail Where Dc='N' "

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
    ''' 程式說明：取得表單明細資料
    ''' 開發人員：Alan
    ''' 開發日期：2009.09.02
    ''' </summary>
    ''' <returns>DataSet-表單明細資料</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.PUB_Sheet_Detail
    ''' </使用表單>
    ''' <修改註記>
    ''' 
    ''' </修改註記>
    Public Function queryPUBSheetDetailData(ByVal SheetCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select A.Order_Code,B.Order_En_Name,B.Order_Name,A.Is_Indication,A.Separate_Mark, " & _
                                  "       C.Specimen_Id,C.Vessel_Id,D.Default_Body_Site_Code,D.Default_Side_Id,D.Is_Labdiscount, " & _
                                  "       D.Is_Scheduled,D.Is_Same_Specimen_Add " & _
                                  "From  PUB_Sheet_Detail A Left Join PUB_Order_Mapping_Specimen C ON C.Order_Code=A.Order_Code And C.Is_Default='Y' " & _
                                  "                         Left Join PUB_Order_Examination D ON D.Order_Code=A.Order_Code " & _
                                  "                         , PUB_Order B " & _
                                  "Where  A.Sheet_Code='" & SheetCode & "' And " & _
                                  "       A.DC<>'Y'  And " & _
                                  "       B.Order_Code=A.Order_Code And " & _
                                  "       B.Effect_Date<='" & Now.ToShortDateString & "' And  " & _
                                  "       B.End_Date>='" & Now.ToShortDateString & "' And  B.DC<>'Y' " & _
                                  "Order by A.Sheet_Detail_Sort_Value "

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
    ''' 程式說明：取得表單明細資料
    ''' 開發人員：Alan
    ''' 開發日期：2009.09.02
    ''' </summary>
    ''' <returns>DataSet-表單明細資料</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.PUB_Sheet_Detail
    ''' </使用表單>
    ''' <修改註記>
    ''' 
    ''' </修改註記>
    Public Function queryPUBSheetDetailData2(ByVal SheetCode As String, ByVal GroupCode As String, ByVal Sheet_Type_Id As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            If Sheet_Type_Id = 1 Then

                command.CommandText = "Select A.Order_Code,D.Order_En_Name,D.Order_Name,B.Is_Indication,B.Separate_Mark, " & _
                                      "       C.Specimen_Id,C.Vessel_Id,'' as Default_Body_Site_Code,'' as Default_Side_Id  " & _
                                      "From   PUB_Sheet_Group A," & _
                                      "       PUB_Sheet_Detail B Left Join PUB_Order_Mapping_Specimen C ON C.Order_Code=B.Order_Code And C.Is_Default='Y' " & _
                                      "                         , PUB_Order D " & _
                                      "Where  A.Sheet_Group='" & GroupCode & "' And " & _
                                      "       A.Sheet_Code='" & SheetCode & "' And " & _
                                      "       B.Sheet_Code=A.Sheet_Code And B.Order_Code=A.Order_Code And " & _
                                      "       B.DC<>'Y'  And " & _
                                      "       C.Specimen_Id=A.Sheet_Group  And " & _
                                      "       D.Order_Code=A.Order_Code And " & _
                                      "       D.Effect_Date<='" & Now.ToShortDateString & "' And  " & _
                                      "       D.End_Date>='" & Now.ToShortDateString & "' And  D.DC<>'Y' " & _
                                      "Order by B.Sheet_Detail_Sort_Value "
            Else
                command.CommandText = "Select A.Order_Code,D.Order_En_Name,D.Order_Name,B.Is_Indication,B.Separate_Mark, " & _
                                      "      '' as Specimen_Id,''  as Vessel_Id,C.Default_Body_Site_Code,C.Default_Side_Id " & _
                                      "From   PUB_Sheet_Group A," & _
                                      "      PUB_Sheet_Detail B Left Join PUB_Order_Examination C ON C.Order_Code=B.Order_Code " & _
                                      "                         , PUB_Order D " & _
                                      "Where  A.Sheet_Group='" & GroupCode & "' And " & _
                                      "       A.Sheet_Code='" & SheetCode & "' And " & _
                                      "       B.Sheet_Code=A.Sheet_Code And B.Order_Code=A.Order_Code And " & _
                                      "       B.DC<>'Y'  And " & _
                                      "       C.Default_Main_Body_Site_Code=A.Sheet_Group  And " & _
                                      "       D.Order_Code=A.Order_Code And " & _
                                      "       D.Effect_Date<='" & Now.ToShortDateString & "' And  " & _
                                      "       D.End_Date>='" & Now.ToShortDateString & "' And  D.DC<>'Y' " & _
                                      "Order by B.Sheet_Detail_Sort_Value "
            End If

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
    ''' 程式說明：取得拆單註記
    ''' 開發人員：James
    ''' 開發日期：2009.10.13
    ''' </summary>
    ''' <returns>DataSet-表單明細資料</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.PUB_Sheet_Detail
    ''' </使用表單>
    ''' <修改註記>
    ''' 
    ''' </修改註記>
    Public Function queryPUBSheetDetailByCond(ByVal OrderCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select  Separate_Mark , Exclusive_Order_Code " & _
                                  "From  PUB_Sheet_Detail   " & _
                                  "Where  Order_Code='" & OrderCode & "' And  DC<>'Y' "

                                 
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
    ''' 程式說明：表單明細資訊
    ''' 開發人員：Jen
    ''' 開發日期：2009.12.07
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Sheet_Detail
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/12/07, XXX
    ''' </修改註記>
    Public Function querySheetDetailData(ByVal SheetCode As String) As DataTable

        Dim systemDate As Date = DateUtil.getSystemDate

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL  ( O.Is_Indication,)
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select S.*, O.Order_Name, O.Order_En_Name, O.Effect_Date, O.End_Date, O.Is_Order_Check, S.Is_Indication, O.Dc_Reason, O.Order_Note, ")
        cmdStr.AppendLine("E.Default_Main_Body_Site_Code, E.Default_Body_Site_Code, E.Default_Side_Id, E.Is_Scheduled, E.Is_Print_Order_Note, E.Is_Main_Body_Site, E.Is_Body_Site, E.Is_Side_Id, E.Opd_Report_Time, E.Emg_Report_Time, E.Ipd_Report_Time, E.Is_PACS, E.Is_With_Contrast, E.Nhi_Body_Site_Code, E.Is_No_Check_In, E.Is_No_Print ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append(tableName).AppendLine(" S ")
        cmdStr.AppendLine("left join PUB_Order O on O.Dc <> @DcY and O.Order_Code = S.Order_Code and @SystemDate >= O.Effect_Date and (End_Date = null or @SystemDate <= End_Date )")
        cmdStr.AppendLine("left join PUB_Order_Examination E on O.Order_Code = E.Order_Code ")
        '
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where S.Sheet_Code = @SheetCode ")
        cmdStr.AppendLine("and S.Dc <> @DcY ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("Order By Order_Code ")
        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@SystemDate", systemDate)
                        sqlCmd.Parameters.AddWithValue("@SheetCode", SheetCode)
                        sqlCmd.Parameters.AddWithValue("@DcY", "Y")

                    End With
                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：表單明細全資訊
    ''' 開發人員：Jen
    ''' 開發日期：2009.12.07
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Sheet_Detail
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/12/07, XXX
    ''' </修改註記>
    Public Function querySheetDetailBySheetCode(ByVal SheetCode As String) As DataTable

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select * ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append(tableName).AppendLine(" ")
        '
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where Sheet_Code = @SheetCode ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("Order By Order_Code ")
        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@SheetCode", SheetCode)

                    End With
                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 以SheetCode刪除資料
    ''' </summary>
    ''' <param name="sheetCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deleteSheetDetailBySheetCode(ByRef sheetCode As String, Optional ByRef conn As IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = getConnection()
            End If
            If conn.State <> ConnectionState.Open Then conn.Open()

            Dim count As Integer = 0
            Dim cmdStr As StringBuilder = New StringBuilder
            cmdStr.Append("delete from ").Append(tableName).AppendLine(" ")
            cmdStr.Append("where Sheet_Code = '").Append(sheetCode).AppendLine("'")

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = cmdStr.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With

                count = command.ExecuteNonQuery
            End Using
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


    Public Function queryPubSheetDetailByOrderCode(ByVal OrderCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim Content As New StringBuilder
            Content.AppendLine("Select * from PUB_Sheet_Detail ")
            Content.AppendLine("where 1=1")
            Content.AppendLine("and Order_Code = @Order_Code")
            command.Parameters.AddWithValue("@Order_Code", OrderCode)
            command.CommandText = Content.ToString

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
End Class