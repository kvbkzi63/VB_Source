Imports System.Data.SqlClient
Imports log4net
Imports System.Text
Imports Syscom.Server.BO

Public Class PUBIndicationBO_E1
    Inherits PubIndicationBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBIndicationBO_E1

    Public Overloads Shared Function getInstance() As PUBIndicationBO_E1
        If instance Is Nothing Then
            instance = New PUBIndicationBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    Public Function queryPUBIndicationByCond(ByVal OrderCode As String) As DataSet

        Try
            Dim SheetCode As String = ""
            Dim OriOrderCode As String = ""
            Dim GroupIndication As String = ""
            Dim IsSpecimenDesc As String = ""

            Dim ds_SpecimenDesc As DataSet
            Dim ds_Order As DataSet
            Dim ds_Sheet As DataSet
            Dim ds_Group As DataSet

            Dim SheetCodeDS As DataSet

            Dim TempDS As DataSet

            Dim returnDS As New DataSet

            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


 
            returnDS.Tables.Add()
            returnDS.Tables(0).TableName = "Initial"


            returnDS.Tables(0).Columns.Add("Sheet_Name")
            returnDS.Tables(0).Columns.Add("Order_En_Name")
            returnDS.Tables(0).Rows.Add()



            If OrderCode.Trim.Contains("@") Then

                If Split(OrderCode, "@").Count = 3 Then

                    OriOrderCode = Split(OrderCode, "@")(0).Trim
                    GroupIndication = Split(OrderCode, "@")(1).Trim
                    IsSpecimenDesc = Split(OrderCode, "@")(2).Trim

                Else
                    OriOrderCode = OrderCode.Trim.Replace("@", "")
                End If

            Else

                OriOrderCode = OrderCode
            End If


            '取得SheetCode
            command.CommandText = " Select Sheet_Code " & _
                              " From PUB_Sheet_Detail " & _
                              " Where Order_Code= '" & OriOrderCode & "' And Dc<>'Y' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                SheetCodeDS = New DataSet(tableName)
                adapter.Fill(SheetCodeDS, tableName)
                adapter.FillSchema(SheetCodeDS, SchemaType.Mapped, tableName)
            End Using

            If SheetCodeDS IsNot Nothing AndAlso SheetCodeDS.Tables(0).Rows.Count > 0 Then

                SheetCode = SheetCodeDS.Tables(0).Rows(0).Item(0).ToString.Trim

            End If



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            command.CommandText = " Select Sheet_Name " & _
                               " From PUB_Sheet " & _
                               " Where Sheet_Code= '" & SheetCode & "' And Dc<>'Y' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                TempDS = New DataSet(tableName)
                adapter.Fill(TempDS, tableName)
                adapter.FillSchema(TempDS, SchemaType.Mapped, tableName)
            End Using

            If TempDS IsNot Nothing AndAlso TempDS.Tables(0).Rows.Count > 0 Then
                returnDS.Tables(0).Rows(0).Item("Sheet_Name") = TempDS.Tables(0).Rows(0).Item(0).ToString.Trim
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            command.CommandText = " Select Order_En_Name " & _
                               " From PUB_Order " & _
                               " Where Order_Code= '" & OriOrderCode & "'  And Dc<>'Y'  "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                TempDS = New DataSet(tableName)
                adapter.Fill(TempDS, tableName)
                adapter.FillSchema(TempDS, SchemaType.Mapped, tableName)
            End Using


            If TempDS IsNot Nothing AndAlso TempDS.Tables(0).Rows.Count > 0 Then
                returnDS.Tables(0).Rows(0).Item("Order_En_Name") = TempDS.Tables(0).Rows(0).Item(0).ToString.Trim
            End If





            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            If Not OrderCode.Trim.Contains("@") Then


                '檢體說明
                command.CommandText = " Select * " & _
                               " From PUB_Indication " & _
                               " Where Order_Code= '" & OriOrderCode & "' And Is_Specimen_Desc='Y'  And Dc<>'Y' Order By  Indication_Order_Value, Indication_No "

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds_SpecimenDesc = New DataSet(tableName)
                    adapter.Fill(ds_SpecimenDesc, tableName)
                    adapter.FillSchema(ds_SpecimenDesc, SchemaType.Mapped, tableName)
                End Using



                '非檢體說明
                command.CommandText = " Select * " & _
                                 " From PUB_Indication " & _
                                 " Where Order_Code= '" & OriOrderCode & "' And Is_Specimen_Desc='N'  And Dc<>'Y' Order By Indication_Order_Value, Indication_No "

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds_Order = New DataSet(tableName)
                    adapter.Fill(ds_Order, tableName)
                    adapter.FillSchema(ds_Order, SchemaType.Mapped, tableName)
                End Using


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If SheetCode <> "" Then
                    command.CommandText = " Select * " & _
                                   " From PUB_Indication " & _
                                   " Where Sheet_Code= '" & SheetCode & "' And Dc<>'Y' Order By Indication_Order_Value, Indication_No "

                Else
                    command.CommandText = " Select * " & _
                                   " From PUB_Indication " & _
                                   " Where 1=2 "

                End If

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds_Sheet = New DataSet(tableName)
                    adapter.Fill(ds_Sheet, tableName)
                    adapter.FillSchema(ds_Sheet, SchemaType.Mapped, tableName)
                End Using



                If ds_SpecimenDesc IsNot Nothing Then
                    ds_SpecimenDesc.Tables(0).TableName = "ds_SpecimenDesc"
                End If

                If ds_Order IsNot Nothing Then
                    ds_Order.Tables(0).TableName = "ds_Order"
                End If

                If ds_Sheet IsNot Nothing Then
                    ds_Sheet.Tables(0).TableName = "ds_Sheet"
                End If

                returnDS.Merge(ds_SpecimenDesc)
                returnDS.Merge(ds_Order)
                returnDS.Merge(ds_Sheet)


            Else

                '傳入的OrderCode 具 @   表示他是Group_Indication

                If IsSpecimenDesc = "Y" Then
                    command.CommandText = " Select * " & _
                              " From PUB_Indication " & _
                              " Where Group_Indication= '" & GroupIndication & "' And Is_Specimen_Desc='Y'  And Dc<>'Y' Order By Indication_Order_Value, Indication_No "


                Else

                    command.CommandText = " Select * " & _
                              " From PUB_Indication " & _
                              " Where Group_Indication= '" & GroupIndication & "' And Is_Specimen_Desc='N'  And Dc<>'Y' Order By Indication_Order_Value, Indication_No "


                End If

              
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds_Group = New DataSet(tableName)
                    adapter.Fill(ds_Group, tableName)
                    adapter.FillSchema(ds_Group, SchemaType.Mapped, tableName)
                End Using

                If ds_Group IsNot Nothing Then
                    ds_Group.Tables(0).TableName = "ds_Group"
                End If

                returnDS.Merge(ds_Group)


            End If
           
            Return returnDS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：查詢某表單indication資料
    ''' 開發人員：Jen
    ''' 開發日期：2010.01.21
    ''' </summary>
    ''' <param name="SheetCode">表單碼</param>
    ''' <param name="SheetOrderCode">表單明細醫令</param>
    ''' <returns>DataSet</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Indication
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2010/01/20, XXX
    ''' </修改註記>
    Public Function querySheetIndicationData(ByVal SheetCode As String, ByVal SheetOrderCode() As String) As DataTable

        If SheetCode IsNot Nothing AndAlso SheetCode.Length > 0 Then

            Dim orderCodeStr As New StringBuilder
            If SheetOrderCode IsNot Nothing AndAlso SheetOrderCode.Length > 0 Then
                For i As Integer = 0 To (SheetOrderCode.Length - 1)
                    orderCodeStr.Append("'").Append(SheetOrderCode(i)).Append("'")
                    If i <> (SheetOrderCode.Length - 1) Then
                        orderCodeStr.Append(",")
                    End If
                Next
            End If


            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select Indication_No, Sheet_Code, Order_Code ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("from " & tableName & " ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where (Sheet_Code = @Sheet_Code and Order_Code = '') ")

            If orderCodeStr.Length > 0 Then
                cmdStr.AppendLine("or (Sheet_Code = '' and Order_Code in (").Append(orderCodeStr.ToString).Append(")) ")
            End If

            '----------------------------------------------------------------------------
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------

            '----------------------------------------------------------------------------
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@Sheet_Code", SheetCode)


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
        Else
            Return Nothing
        End If

    End Function

End Class
