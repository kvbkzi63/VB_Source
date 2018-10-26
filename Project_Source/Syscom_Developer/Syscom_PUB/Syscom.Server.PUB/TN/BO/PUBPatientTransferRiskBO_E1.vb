'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患運送等級修改作業
'*              Title:	PUBPatientTransferRisk
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-03-21
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-03-21
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.BO

Public Class PUBPatientTransferRiskBO_E1
    Inherits PubPatientTransferRiskBO
#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPatientTransferRiskBO_E1
    Public Overloads Shared Function GetInstance() As PUBPatientTransferRiskBO_E1
        If myInstance Is Nothing Then
            myInstance = New PUBPatientTransferRiskBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "

    ''' <summary>
    ''' 病患運送等級修改作業
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-03-21
    '''          修正寫入只判斷病歷號，流水號以病歷號最大值加1 By 2017/03/27
    ''' </remarks>
    Public Function InsertIntoPUBPatientTransferRisk(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            Dim Content As New StringBuilder
            Content.AppendLine("Insert Into PUB_Patient_Transfer_Risk")
            Content.AppendLine("(Chart_No,")
            Content.AppendLine("Patient_Transfer_Risk_No,")
            Content.AppendLine("Medical_Sn,")
            Content.AppendLine("Transfer_Risk_Id,")
            Content.AppendLine("Src_System,")
            Content.AppendLine("Create_User,")
            Content.AppendLine("Create_Time,")
            Content.AppendLine("Modified_User,")
            Content.AppendLine("Modified_Time)")
            Content.AppendLine("values(@Chart_No,")
            Content.AppendLine("(Select  Top 1 isnull(Max(Patient_Transfer_Risk_No) +1,0)")
            Content.AppendLine("  from PUB_Patient_Transfer_Risk")
            Content.AppendLine("where Chart_No=@Chart_No ),")
            Content.AppendLine("@Medical_Sn,")
            Content.AppendLine("@Transfer_Risk_Id,")
            Content.AppendLine("@Src_System,")
            Content.AppendLine("@Create_User,")
            Content.AppendLine("@Create_Time,")
            Content.AppendLine("@Modified_User,")
            Content.AppendLine("@Modified_Time")
            Content.AppendLine(")")
            Content.AppendLine("")



            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Medical_Sn", row.Item("Medical_Sn"))
                    command.Parameters.AddWithValue("@Transfer_Risk_Id", row.Item("Transfer_Risk_Id"))
                    command.Parameters.AddWithValue("@Src_System", row.Item("Src_System"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime.ToString("yyyy/MM/dd HH:mm:ss"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime.ToString("yyyy/MM/dd HH:mm:ss"))
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

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "
    Public Function QueryDataByKey(ByVal strChartNo As String, ByVal strOutpatientSn As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("Select  Top 1 * ")
            Content.AppendLine("  from PUB_Patient_Transfer_Risk")
            Content.AppendLine("where Chart_No=@strChartNo and Medical_Sn=@Medical_Sn")
            Content.AppendLine("order by Create_Time desc;")
            Content.AppendLine("")
            Content.AppendLine("")



            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@strChartNo", strChartNo)
            command.Parameters.AddWithValue("@Medical_Sn", strOutpatientSn)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    ''' <summary>
    ''' 取得病患傳輸風險層級
    ''' </summary>
    ''' <param name="strChartNo"></param>
    ''' <param name="strOutpatientSn"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function GetPatientRiskLevel(ByVal strChartNo As String, ByVal strOutpatientSn As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String



        Dim connFlag As Boolean = conn Is Nothing
        Try


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim ds As DataSet = QueryDataByKey(strChartNo, strOutpatientSn, conn)

            Dim strTempSelectCase As String = ""
            If strOutpatientSn <> "" Then
                strTempSelectCase = strOutpatientSn.Substring(0, 1)
            Else
                strOutpatientSn = ""
            End If

            '先找PUB_Patient_Transfer_Risk 如果沒有，依據不同來源給予不同的預設值
            If CheckMethodUtil.CheckHasValue(ds) Then
                Return ds.Tables(0).Rows(0).Item("Transfer_Risk_Id").ToString.Trim
            Else
                Select Case strTempSelectCase
                    Case "E"
                        'A.若就醫序號的第一碼為”E”時, 檢傷I，預設為紅燈=3，檢傷II，預設為黃燈=2，檢傷lll，IV及V，預設為綠燈=1 ，否則則為綠燈
                        Dim patientSaveTriageDs As DataSet = QueryPatientSaveTriageData(strChartNo, strOutpatientSn, conn)
                        If CheckMethodUtil.CheckHasValue(patientSaveTriageDs) Then
                            If patientSaveTriageDs.Tables(0).Rows(0).Item("HumanRank").ToString.Trim.Equals("0") Then
                                If patientSaveTriageDs.Tables(0).Rows(0).Item("PcRank5").ToString.Trim.Equals("1") Then
                                    Return "3"
                                ElseIf patientSaveTriageDs.Tables(0).Rows(0).Item("PcRank5").ToString.Trim.Equals("2") Then
                                    Return "2"
                                Else
                                    Return "1"
                                End If
                            Else
                                If patientSaveTriageDs.Tables(0).Rows(0).Item("HumanRank").ToString.Trim.Equals("1") Then
                                    Return "3"
                                ElseIf patientSaveTriageDs.Tables(0).Rows(0).Item("HumanRank").ToString.Trim.Equals("2") Then
                                    Return "2"
                                Else
                                    Return "1"
                                End If
                            End If
                        Else
                            Return "2"
                        End If

                    Case "I"
                        '如果為ICU 則為紅燈 否則綠燈
                        If QueryICUBedRecord(strOutpatientSn, conn) > 0 Then
                            Return "3"
                        Else
                            Return "1"
                        End If
                    Case "O"
                        '門診預設綠燈
                        Return "1"
                    Case Else
                        Return ""
                End Select
            End If

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得病患傳輸風險層級"})
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return ""
    End Function

    ''' <summary>
    ''' 查詢病患檢傷資料
    ''' </summary>
    ''' <param name="strChartNo"></param>
    ''' <param name="strOutpatientSn"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Private Function QueryPatientSaveTriageData(ByVal strChartNo As String, ByVal strOutpatientSn As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT Top 1 PcRank5 ,HumanRank,Outpatient_sn")
            Content.AppendLine("  FROM  SaveTriageData ")
            Content.AppendLine("  Where BinLiNo=@BinLiNo and Outpatient_sn=@strOutpatientSn")
            Content.AppendLine("Order by SaveDataFullDateTime desc ")
            Content.AppendLine("")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@BinLiNo", strChartNo)
            command.Parameters.AddWithValue("@strOutpatientSn", strOutpatientSn)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢病患檢傷資料"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    ''' <summary>
    ''' 查詢病患病床等級是否為ICU
    ''' </summary>
    ''' <param name="strOutpatientSn"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Private Function QueryICUBedRecord(ByVal strOutpatientSn As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet
            Dim Content As New StringBuilder
            Content.AppendLine("Select  count(*) from inp_check_in_out A")
            Content.AppendLine("Inner join inp_bed B on A.bed_no = b.bed_no ")
            Content.AppendLine("Where A.Case_no = @strOutpatientSn and B.Attri_Id = '02'")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@strOutpatientSn", strOutpatientSn)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            If CheckMethodUtil.CheckHasValue(ds) Then
                Return ds.Tables(0).Rows(0).Item(0).ToString.Trim
            Else
                Return 0
            End If
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢病患病床等級是否為ICU"})
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

