Imports System.Data.SqlClient
Imports System.Transactions
Imports log4net
Imports System.Text
Imports Syscom.Comm.Utility
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP

Public Class PUBRisFormMaintainBS
    Implements IDisposable

    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#Region "########## getInstance() ##########"

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As PUBRisFormMaintainBS
        Try

            Return New PUBRisFormMaintainBS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    ''' <summary>
    ''' 表單代碼下拉選單與資訊
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function initSheetData() As DataSet
        Dim returnDS As New DataSet
        Dim sheetinstance As PUBSheetBO_E1 = PUBSheetBO_E1.getInstance
        Dim bodysiteinstance As PUBBodySiteBO_E1 = PUBBodySiteBO_E1.getInstance
        Dim syscodeinstance As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance
        Dim deptinstance As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance

        Try
            Dim sheetDT As DataTable = sheetinstance.querySheetData()
            If DataSetUtil.IsContainsData(sheetDT) Then
                returnDS.Tables.Add(sheetDT)
            End If

            Dim bsiteDT As DataTable = bodysiteinstance.queryBodySideData()
            If DataSetUtil.IsContainsData(bsiteDT) Then
                returnDS.Tables.Add(bsiteDT)
            End If

            Dim typeIds() As Integer = {48}
            Dim sideDT As DataTable = syscodeinstance.querySyscodeByTypeIds(typeIds)
            If DataSetUtil.IsContainsData(sideDT) Then
                returnDS.Tables.Add(sideDT)
            End If

            Dim deptDT As New DataTable
            Dim NEWdeptDT As New DataTable
            deptDT = deptinstance.getComboBoxValueTable()
            NEWdeptDT = deptDT.Copy
            If DataSetUtil.IsContainsData(deptDT) Then
                returnDS.Tables.Add(NEWdeptDT.Copy)
            End If

            '系統日期
            Dim SystemDateColumn() As String = {"System_Date"}
            Dim SystemDateColumnType() As Integer = {DataSetUtil.TypeDate}
            Dim SystemDateDT As DataTable = DataSetUtil.createDataTable("systemdate", Nothing, SystemDateColumn, SystemDateColumnType)
            Dim dateDR As DataRow = SystemDateDT.NewRow
            dateDR(SystemDateColumn(0)) = DateUtil.getSystemDate

            SystemDateDT.Rows.Add(dateDR)
            returnDS.Tables.Add(SystemDateDT)

            Return returnDS
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 表單明細資訊
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function querySheetDetailData(ByVal SheetCode As String) As DataTable
        Dim instance As PubSheetDetailBO_E1 = PubSheetDetailBO_E1.getInstance
        Try
            Return instance.querySheetDetailData(SheetCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 確認資料
    ''' </summary>
    ''' <param name="sheetDS"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function confirmSheetData(ByVal sheetDS As DataSet) As Boolean
        'transaction
        '  query data
        '  delete sheet, sheetdetail
        '  
        '  insert all
        Dim systemDate As Date = DateUtil.getSystemDate


        'process data tobe ok
        If DataSetUtil.IsContainsData(sheetDS) Then
            Dim sheetBO As PUBSheetBO_E1 = PUBSheetBO_E1.getInstance
            Dim sheetDetailBO As PubSheetDetailBO_E1 = PubSheetDetailBO_E1.getInstance
            Dim sheetGroupBO As PUBSheetGroupBO_E1 = PUBSheetGroupBO_E1.getInstance

            Dim indicationBO As PUBIndicationBO_E1 = PUBIndicationBO_E1.getInstance

            Dim orderBO As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance
            Dim orderExamBO As PUBOrderExaminationBO_E1 = PUBOrderExaminationBO_E1.getInstance

            If sheetDS.Tables.Contains(PubSheetDataTableFactory.tableName) Then
                Dim sheetDT As DataTable = sheetDS.Tables(PubSheetDataTableFactory.tableName)
                If DataSetUtil.IsContainsData(sheetDT) AndAlso (sheetDT.Rows.Count = 1) Then
                    Dim processStatus As Boolean = True
                    Try
                        Dim sheetCode As String = CType(sheetDT.Rows(0).Item("Sheet_Code"), String).Trim
                        Dim orderList As New ArrayList
                        Dim pkeySheet As DataSet = sheetBO.queryByPK(sheetCode)
                        If DataSetUtil.IsContainsData(pkeySheet) Then
                            'update mod user,time
                            sheetDT.Rows(0).Item("Modified_User") = sheetDT.Rows(0).Item("Create_User")
                            sheetDT.Rows(0).Item("Modified_Time") = systemDate

                            If Not IsDBNull(pkeySheet.Tables(0).Rows(0).Item("Create_User")) Then
                                sheetDT.Rows(0).Item("Create_User") = pkeySheet.Tables(0).Rows(0).Item("Create_User")
                            End If

                            If Not IsDBNull(pkeySheet.Tables(0).Rows(0).Item("Create_Time")) Then
                                sheetDT.Rows(0).Item("Create_Time") = pkeySheet.Tables(0).Rows(0).Item("Create_Time")
                            End If
                        Else
                            'insert
                            sheetDT.Rows(0).Item("Create_Time") = systemDate
                        End If

                        Dim sheetDetail As DataTable = sheetDetailBO.querySheetDetailBySheetCode(sheetCode)

                        Dim sheetDetailDT As DataTable = PubSheetDetailDataTableFactory.getDataTableWithSchema
                        If sheetDS.Tables.Contains(PubSheetDetailDataTableFactory.tableName) AndAlso sheetDS.Tables(PubSheetDetailDataTableFactory.tableName).Rows.Count > 0 Then
                            sheetDetailDT = sheetDS.Tables(PubSheetDetailDataTableFactory.tableName)
                        Else

                        End If

                        Dim sheetGroupDT As DataTable = PubSheetGroupDataTableFactory.getDataTableWithSchema
                        If sheetDS.Tables.Contains(PubSheetGroupDataTableFactory.tableName) AndAlso sheetDS.Tables(PubSheetGroupDataTableFactory.tableName).Rows.Count > 0 Then
                            sheetGroupDT = sheetDS.Tables(PubSheetGroupDataTableFactory.tableName)
                        Else

                        End If

                        If DataSetUtil.IsContainsData(sheetDetail) Then
                            'db has data, combine
                            Dim dbDetailHash As New Hashtable

                            For Each dr As DataRow In sheetDetail.Rows
                                If Not IsDBNull(dr.Item("Order_Code")) Then
                                    Dim existKey As String = CType(dr.Item("Order_Code"), String).Trim
                                    If Not dbDetailHash.ContainsKey(existKey) Then
                                        dbDetailHash.Add(existKey, dr)
                                        orderList.Add(existKey)
                                    End If
                                End If
                            Next

                            For Each dr As DataRow In sheetDetailDT.Rows
                                If Not IsDBNull(dr.Item("Order_Code")) Then
                                    Dim orderCode As String = CType(dr.Item("Order_Code"), String).Trim
                                    If dbDetailHash.ContainsKey(orderCode) Then

                                        Dim dbdr As DataRow = CType(dbDetailHash.Item(orderCode), DataRow)

                                        dr.Item("Modified_User") = dr.Item("Create_User")
                                        dr.Item("Modified_Time") = systemDate

                                        If Not IsDBNull(dbdr.Item("Create_User")) Then
                                            dr.Item("Create_User") = dbdr.Item("Create_User")
                                        End If

                                        If Not IsDBNull(dbdr.Item("Create_Time")) Then
                                            dr.Item("Create_Time") = dbdr.Item("Create_Time")
                                        End If

                                        dbDetailHash.Remove(orderCode)

                                    Else
                                        dr.Item("Create_Time") = systemDate
                                    End If

                                End If
                            Next


                            If dbDetailHash.Count > 0 Then

                                Dim dbenu As IDictionaryEnumerator = dbDetailHash.GetEnumerator
                                While dbenu.MoveNext
                                    Dim dcdr As DataRow = CType(dbenu.Value, DataRow)
                                    dcdr.Item("Dc") = "Y"

                                    sheetDetailDT.Rows.Add(dcdr.ItemArray)
                                End While

                                'sheetDetailDT
                            Else
                                'no...
                            End If

                        Else
                            'db no data, add insert
                            For i As Integer = 0 To (sheetDetailDT.Rows.Count - 1)
                                sheetDetailDT.Rows(i).Item("Create_Time") = systemDate
                            Next
                        End If

                        '---------------------------------------------------------------
                        '更新indication欄位資訊
                        If orderList.Count > 0 Then
                            Dim sheetOrder(orderList.Count - 1) As String
                            For i As Integer = 0 To (orderList.Count - 1)
                                sheetOrder(i) = CType(orderList.Item(i), String).Trim
                            Next

                            Dim indicationDT As DataTable = indicationBO.querySheetIndicationData(sheetCode, sheetOrder)
                            If DataSetUtil.IsContainsData(indicationDT) Then
                                Dim queryDr() As DataRow
                                queryDr = indicationDT.Select(" Sheet_Code = '" & sheetCode & "' and Order_Code = '' ")
                                If queryDr IsNot Nothing AndAlso queryDr.Length > 0 Then
                                    sheetDT.Rows(0).Item("Is_Indication") = "Y"
                                End If

                                For i As Integer = 0 To (sheetDetail.Rows.Count - 1)
                                    Dim orderCode As String = ""
                                    If Not IsDBNull(sheetDetail.Rows(i).Item("Order_Code")) Then
                                        orderCode = CType(sheetDetail.Rows(i).Item("Order_Code"), String).Trim
                                        queryDr = indicationDT.Select(" Sheet_Code = '' and Order_Code = '" & orderCode & "' ")
                                        If queryDr IsNot Nothing AndAlso queryDr.Length > 0 Then
                                            sheetDetail.Rows(i).Item("Is_Indication") = "Y"
                                        End If

                                    End If
                                Next

                            End If
                        Else
                            Dim indicationDT As DataTable = indicationBO.querySheetIndicationData(sheetCode, Nothing)
                            If DataSetUtil.IsContainsData(indicationDT) Then
                                Dim queryDr() As DataRow
                                queryDr = indicationDT.Select(" Sheet_Code = '" & sheetCode & "' and Order_Code = '' ")
                                If queryDr IsNot Nothing AndAlso queryDr.Length > 0 Then
                                    sheetDT.Rows(0).Item("Is_Indication") = "Y"
                                End If
                            End If
                        End If

                        '----------------------------------------------------------

                        Dim ordermodDT As DataTable = Nothing
                        Dim orderexammodDT As DataTable = Nothing
                        If sheetDS.Tables.Contains("order") Then
                            ordermodDT = sheetDS.Tables("order").Copy
                        End If

                        If sheetDS.Tables.Contains("orderexam") Then
                            orderexammodDT = sheetDS.Tables("orderexam").Copy
                        End If

                        '--------------------------------------------------------------
                        'sheetDT
                        'sheetDetailDT
                        '開始交易
                        Dim nextFlag As Boolean = True

                        Using Scope As TransactionScope = Syscom.Server.SQL.SQLConnFactory.getInstance.getRequiredTransactionScope ' TransactionScopeFactory.getInstance.GetRequiredTransactionScope()
                            Dim conn As IDbConnection = PubSheetBO.GetInstance.getConnection()

                            Try
                                If conn.State <> ConnectionState.Open Then conn.Open()

                                Try
                                    sheetBO.delete(sheetCode, conn)
                                    sheetDetailBO.deleteSheetDetailBySheetCode(sheetCode, conn)
                                    sheetGroupBO.deleteBySheetCode(sheetCode, conn)
                                Catch ex As Exception
                                    nextFlag = False
                                End Try


                                'For Each _drSheet As DataRow In sheetDT.Rows
                                '    _drSheet("Insu_Cover_Opd") = "Y"
                                '    _drSheet("Insu_Cover_Emg") = "Y"
                                '    _drSheet("Insu_Cover_Ipd") = "Y"
                                'Next


                                Dim insertSheetDS As New DataSet
                                insertSheetDS.Tables.Add(sheetDT.Copy)

                                Dim insertSheetDtlDS As New DataSet
                                insertSheetDtlDS.Tables.Add(sheetDetailDT.Copy)


                                If nextFlag Then
                                    Try
                                        sheetBO.insertBySetCreateTime(insertSheetDS, conn)
                                        'insert(insertSheetDS)
                                    Catch ex As Exception
                                        nextFlag = False
                                    End Try
                                End If

                                If nextFlag Then
                                    Try
                                        sheetDetailBO.insertBySetCreateTime(insertSheetDtlDS, conn)
                                    Catch ex As Exception
                                        nextFlag = False
                                    End Try
                                End If


                                'PubSheetGroupDataTableFactory.tableName
                                Dim insertSheetGroupDS As New DataSet
                                insertSheetGroupDS.Tables.Add(sheetGroupDT.Copy)
                                If nextFlag Then

                                    If DataSetUtil.IsContainsData(sheetGroupDT) Then
                                        Try
                                            sheetGroupBO.insert(insertSheetGroupDS, conn)
                                        Catch ex As Exception
                                            nextFlag = False
                                        End Try
                                    End If

                                End If

                                'TODO981214
                                'update order_exam, ....

                                If nextFlag Then

                                    If DataSetUtil.IsContainsData(ordermodDT) Then
                                        Try
                                            orderBO.updateSheetDetailRelatedOrder(ordermodDT, conn)
                                        Catch ex As Exception
                                            nextFlag = False
                                        End Try
                                    End If

                                End If

                                If nextFlag Then

                                    If DataSetUtil.IsContainsData(orderexammodDT) Then
                                        Try
                                            orderExamBO.updateSheetDetailRelatedOrderExamination(orderexammodDT, conn)
                                        Catch ex As Exception
                                            nextFlag = False
                                        End Try
                                    End If

                                End If

                                If nextFlag Then
                                    'process complete
                                    Scope.Complete()
                                Else
                                    Scope.Dispose()
                                End If

                            Catch sqlex As SqlException
                                Throw New SQLDatabaseException(sqlex)
                            Catch cmex As CommonException
                                Throw cmex
                            Catch ex As Exception
                                Throw New CommonException("CMMCMMB302", ex, New String() {"sheetDetailDT 寫入"})
                            Finally
                                If conn IsNot Nothing Then
                                    conn.Close()
                                    conn.Dispose()
                                    conn = Nothing
                                End If
                            End Try

                        End Using

                        Return nextFlag

                        '------

                        'transaction
                        'all remove, add insert
                        'end transaction

                    Catch ex As Exception
                        'sheet error
                        processStatus = False

                        Return processStatus
                    End Try


                Else
                    '資料錯誤
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If


    End Function

#Region "2009/12/08 Add by Jen 查尋相似醫令碼"

    ''' <summary>
    ''' 查詢符合開頭字串醫令
    ''' </summary>
    ''' <param name="LikeOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function queryLikeOrderData(ByVal LikeOrderCode As String) As DataTable
        Dim instance As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance
        Try
            Return instance.queryLikeOrderData(LikeOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "2010-11-12 Added by Ken"

    ''' <summary>
    ''' Get SQL connection.
    ''' </summary>
    ''' <author>Ken</author>
    ''' <date>2010-11-12</date>
    ''' <remarks></remarks>
    Private Function GetSqlConnection() As SqlConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    ''' <summary>
    ''' 取得可用之表單
    ''' </summary>
    ''' <param name="User">登入者Id</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAvalibleSheet(ByVal User As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(Y.Sheet_Code) AS Sheet_Code, " & vbCrLf)
        var1.Append("       Y.Sheet_Name, " & vbCrLf)
        var1.Append("       RTRIM(Y.Dept_Code) AS Dept_Code, " & vbCrLf)
        var1.Append("       RTRIM(Y.Is_Emergency_Sheet) AS Is_Emergency_Sheet, " & vbCrLf)
        var1.Append("       RTRIM(Y.Is_Indication) AS Is_Indication, " & vbCrLf)
        var1.Append("       RTRIM(Y.Is_Print_Indication) AS Is_Print_Indication, " & vbCrLf)
        var1.Append("       Y.Sheet_Note " & vbCrLf)
        var1.Append("FROM   PUB_Sheet Y " & vbCrLf)
        var1.Append("       LEFT JOIN PUB_Department Z " & vbCrLf)
        var1.Append("         ON Z.Dept_Code = Y.Dept_Code " & vbCrLf)
        var1.Append("            AND Z.DC = 'N' " & vbCrLf)
        var1.Append("            AND Y.Dc = 'N' " & vbCrLf)
        var1.Append("            AND Y.Sheet_Type_Id = '2' " & vbCrLf)
        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Employee_Code", User)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "PUB_Sheet")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "PUB_Sheet")

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 新增一筆檢查Order
    ''' </summary>
    ''' <param name="InputData">欲新增之資料</param>
    ''' <param name="User">操作者</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertIntoPubSheetDetailAndPubOrderExamination(ByVal InputData As DataSet, ByVal User As String) As Int32

        Dim _count As Int32 = 0
        Using trans As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
            Using conn As IDbConnection = GetSqlConnection()
                conn.Open()

                _count += Me.InsertIntoPubSheetDetail(InputData, User, conn)

                'Marked on 2011-02-14
                'Me.UpdateTreatmentTypeIdOfPubOrder(InputData, User, conn)
                'Me.InsertIntoPubOrderExamination(InputData, User, conn)

                trans.Complete()
                conn.Close()
            End Using
        End Using

        Return _count
    End Function

    ''' <summary>
    ''' 更新PUB_Order中的Treatment_Type_Id
    ''' </summary>
    ''' <param name="InputData">輸入資料</param>
    ''' <param name="User">員工號</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    Private Function UpdateTreatmentTypeIdOfPubOrder(ByVal InputData As DataSet, ByVal User As String, ByRef conn As IDbConnection) As Int32

        Dim _dtInputData As DataTable = InputData.Tables(0)

        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Order " & vbCrLf)
        var1.Append("SET    Treatment_Type_Id = @Treatment_Type_Id, " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Order_Code = @Order_Code " & vbCrLf)
        var1.Append("       AND Dc = 'N' " & vbCrLf)

        Dim _cnt As Int32 = 0
        Try
            Dim _sqlConnection As SqlConnection = conn
            If _sqlConnection.State <> ConnectionState.Open Then _sqlConnection.Open()

            For Each _drInputData As DataRow In _dtInputData.Rows

                Dim _orderCode As String = _drInputData("Order_Code").ToString.TrimEnd

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Order_Code", _orderCode)
                _command.Parameters.AddWithValue("@Treatment_Type_Id", "4")
                _command.Parameters.AddWithValue("@User", User)
                _command.Parameters.AddWithValue("@Now", Now)

                _cnt += _command.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt

    End Function

    ''' <summary>
    ''' 新增一筆Order至Pub_Sheet_Detail
    ''' </summary>
    ''' <param name="InputData">欲新增之資料</param>
    ''' <param name="User">操作者</param>
    ''' <param name="conn">SQL Connection</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InsertIntoPubSheetDetail(ByVal InputData As DataSet, ByVal User As String, ByRef conn As IDbConnection) As Int32
        'Sheet_Detail_Sort_Value要取最大號+1

        Dim _dtInputData As DataTable = InputData.Tables(0)

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT ISNULL(MAX(Sheet_Detail_Sort_Value), 0) + 1 AS Sheet_Detail_Sort_Value " & vbCrLf)
        var1.Append("FROM   PUB_Sheet_Detail " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)

        Dim _cnt As Int32 = 0

        Try
            Dim _sqlConnection As SqlConnection = conn
            If _sqlConnection.State <> ConnectionState.Open Then _sqlConnection.Open()

            For Each _drInputData As DataRow In _dtInputData.Rows

                '取出Sheet_Code
                Dim _sheetCode As String = _drInputData("Sheet_Code").ToString

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Sheet_Code", _sheetCode)

                Dim _ds As New DataSet
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "PUB_Sheet_Detail")

                '取出新的Sheet_Detail_Sort_Value
                Dim _newSheetDetailSortValue As Int32 = _ds.Tables("PUB_Sheet_Detail").Rows(0)("Sheet_Detail_Sort_Value")

                Dim _newDs As New DataSet
                Dim _newDt As DataTable = PubSheetDetailDataTableFactory.getDataTableWithSchema
                '填入新的Sheet_Detail_Sort_Value
                _drInputData("Sheet_Detail_Sort_Value") = _newSheetDetailSortValue
                _newDt.ImportRow(_drInputData)
                _newDs.Tables.Add(_newDt)

                '寫入Table
                _cnt += PubSheetDetailBO.GetInstance.insert(_newDs, _sqlConnection)
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    ''' <summary>
    ''' 新增一筆Order至Pub_Order_Examination
    ''' </summary>
    ''' <param name="InputData">欲新增之資料</param>
    ''' <param name="User">操作者</param>
    ''' <param name="conn">SQL Connection</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InsertIntoPubOrderExamination(ByVal InputData As DataSet, ByVal User As String, ByRef conn As IDbConnection) As Int32

        If conn.State <> ConnectionState.Open Then conn.Open()

        Dim _inputDt As DataTable = InputData.Tables(0)

        Dim _dt As DataTable = PubOrderExaminationDataTableFactory.getDataTableWithSchema
        Try
            For Each _inputDr As DataRow In _inputDt.Rows


                If Me.CheckIfExistInPubOrderExamination(_inputDr("Order_Code"), conn) Then
                    Continue For
                End If

                Dim _dr As DataRow = _dt.NewRow
                _dr("Order_Code") = _inputDr("Order_Code")
                _dr("Default_Main_Body_Site_Code") = String.Empty
                _dr("Default_Body_Site_Code") = String.Empty
                _dr("Default_Side_Id") = String.Empty
                _dr("Is_Main_Body_Site") = "N"
                _dr("Is_Body_Site") = "N"
                _dr("Is_Side_Id") = "N"
                _dr("Is_Labdiscount") = "N"
                _dr("Is_Scheduled") = "N"
                _dr("Is_Same_Specimen_Add") = "N"
                _dr("Is_Print_Order_Note") = "N"
                _dr("Default_Specimen_Id") = String.Empty
                _dr("Default_Vessel_Id") = String.Empty
                _dr("Is_PACS") = "N"
                _dr("Is_With_Contrast") = "N"
                _dr("Is_Scheduled_Ipd") = "N"
                _dr("Deliver_System") = String.Empty
                _dr("Nhi_Body_Site_Code") = String.Empty
                _dr("Is_No_Check_In") = "N"
                _dr("Is_No_Separate") = "N"
                _dr("Is_Loan_Chart") = "N"

                _dt.Rows.Add(_dr)
            Next

            Dim _count As Int32 = 0
 
            If _dt.Rows.Count > 0 Then
                Dim _boPubOrderExamination As PUBOrderExaminationBO_E1 = PUBOrderExaminationBO_E1.getInstance
                Dim _ds As New DataSet
                _ds.Tables.Add(_dt)
                _count = _boPubOrderExamination.insert(_ds, conn)
            End If
            Return _count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增一筆Order至Pub_Order_Examination"})
        End Try
     End Function

    ''' <summary>
    ''' 判斷此Order_Code是否已存在Pub_Order_Examination中
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <param name="conn">SQL Connection</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckIfExistInPubOrderExamination(ByVal OrderCode As String, ByRef conn As IDbConnection) As Boolean

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT COUNT(*) AS Cnt " & vbCrLf)
        var1.Append("FROM   PUB_Order_Examination " & vbCrLf)
        var1.Append("WHERE  Order_Code = @Order_Code " & vbCrLf)

        Dim _ds As New DataSet

        Try
            Dim _sqlConnection As SqlConnection = conn

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Order_Code", OrderCode)

            Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
            _dataAdapter.Fill(_ds, "PUB_Order_Examination")
            '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "PUB_Order_Examination")
        Catch ex As Exception
            Throw ex
        End Try

        Dim _dt As DataTable = _ds.Tables(0)

        If _dt.Rows(0)("Cnt") = 0 Then
            Return False
        Else
            Return True
        End If

    End Function


    Public Function DeleteFromPubSheetDetailAndPubOrderExamination(ByVal InputData As DataSet, ByVal User As String) As Int32

    End Function
#End Region
End Class
