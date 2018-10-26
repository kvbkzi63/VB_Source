'/*
'*****************************************************************************
'*
'*    Page/Class Name:  公用類別代碼維護
'*              Title:	PubSyscodeType
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Alan.Tsai
'*        Create Date:	2014-11-08
'*      Last Modifier:	Alan.Tsai
'*   Last Modify Date:	2014-11-08
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL

Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.TableFactory


Public Class PubSyscodeTypeBS

    Public Shared ReadOnly tableName As String = "PUB_Syscode_Type"

#Region "########## getInstance ##########"

    Private Shared myInstance As PubSyscodeTypeBS

    Public Overloads Function getInstance() As PubSyscodeTypeBS
        If myInstance Is Nothing Then
            myInstance = New PubSyscodeTypeBS()
        End If
        Return myInstance
    End Function

    Public Sub New()
    End Sub

#End Region

#Region "     存檔 "

    ''' <summary>
    ''' 資料存檔
    ''' </summary>
    ''' <param name="inSaveDs">存檔DataSet</param>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan Tsai on 2014-11-08</remarks>
    Public Function savePubSyscodeType(ByVal inSaveDs As DataSet) As DataSet

        Dim resultDs As New DataSet          '回傳DataSet
        Dim pvtIndex As Integer = 0          '處理記錄索引位置 
        Dim pvtErrorCount As Integer = 0     '註記錯誤筆數位置
        Dim pvtSystemTime As String          '系統時間

        Dim m_Pub_Syscode_Type As PubSyscodeTypeBO_E1 = PubSyscodeTypeBO_E1.getInstance

        Dim scope As TransactionScope = Nothing

        Try

            pvtSystemTime = Now.ToString("yyyy/MM/dd HH:mm:ss")

            resultDs.Tables.Add("Save_Result")
            resultDs.Tables("Save_Result").Columns.Add("Type_Id")
            resultDs.Tables("Save_Result").Columns.Add("ErrMsg")
            resultDs.Tables("Save_Result").Columns.Add("Check_Index")

            resultDs.Tables.Add("Maintain_Time")
            resultDs.Tables("Maintain_Time").Columns.Add("Server_Time")

            resultDs.Tables("Maintain_Time").Rows.Add()
            resultDs.Tables("Maintain_Time").NewRow()
            resultDs.Tables("Maintain_Time").Rows(pvtErrorCount).Item("Server_Time") = pvtSystemTime

            scope = SQLConnFactory.getInstance.getRequiredTransactionScope()

            Using conn As System.Data.IDbConnection = CType(getConnection(), SqlConnection)

                conn.Open()

                '-------------------------------------------------------------
                '1.若[狀態]欄位值="I"則為新增，欄位值="U"則為修改
                '-------------------------------------------------------------
                For i = 0 To inSaveDs.Tables(0).Rows.Count - 1

                    Try

                        pvtIndex = i

                        If inSaveDs.Tables(0).Rows(i).Item("Status").ToString.Trim = "I" Then

                            '修正Crate_Time與Modified_Time時間為Server端時間
                            inSaveDs.Tables(0).Rows(i).Item("Create_Time") = pvtSystemTime
                            inSaveDs.Tables(0).Rows(i).Item("Modified_Time") = pvtSystemTime

                            m_Pub_Syscode_Type.insertPUBSyscodeTypeByRowData(inSaveDs.Tables(0).Rows(i).Item("Type_Id").ToString.Trim,
                                                                             inSaveDs.Tables(0).Rows(i).Item("Type_Name").ToString.Trim,
                                                                             inSaveDs.Tables(0).Rows(i).Item("Create_User").ToString.Trim,
                                                                             inSaveDs.Tables(0).Rows(i).Item("Create_Time").ToString.Trim,
                                                                             inSaveDs.Tables(0).Rows(i).Item("Modified_User").ToString.Trim,
                                                                             inSaveDs.Tables(0).Rows(i).Item("Modified_Time").ToString.Trim,
                                                                             conn)

                            '新增成功，才寫入BK檔
                            insertBackup(inSaveDs.Tables(0).Rows(i)) '備份機制

                        Else

                            '修正Modified_Time時間為Server端時間
                            inSaveDs.Tables(0).Rows(i).Item("Modified_Time") = pvtSystemTime

                            m_Pub_Syscode_Type.updatePUBSyscodeTypeByRowData(inSaveDs.Tables(0).Rows(i).Item("Type_Id").ToString.Trim,
                                                                             inSaveDs.Tables(0).Rows(i).Item("Type_Name").ToString.Trim,
                                                                             inSaveDs.Tables(0).Rows(i).Item("Modified_User").ToString.Trim,
                                                                             inSaveDs.Tables(0).Rows(i).Item("Modified_Time").ToString.Trim,
                                                                             conn)

                            '修改成功，才寫入BK檔
                            updateBackup(inSaveDs.Tables(0).Rows(i)) '備份機制

                        End If

                    Catch sql_ex As SqlException
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Type_Id") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Type_Id")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("ErrMsg") = sql_ex.Message
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Check_Index") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Check_Index")
                        pvtErrorCount += 1
                        '-------------------------------------------------------------

                    Catch ex As Exception
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Type_Id") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Type_Id")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("ErrMsg") = ex.Message
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Check_Index") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Check_Index")
                        pvtErrorCount += 1
                        '-------------------------------------------------------------
                    End Try

                Next
                '-------------------------------------------------------------

                '-------------------------------------------------------------
                '2.完成交易處理
                '-------------------------------------------------------------
                If pvtErrorCount = 0 Then
                    scope.Complete()
                End If
                '-------------------------------------------------------------

            End Using


        Catch cmex As CommonException
            Throw cmex

        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        Finally
            Try
                If scope IsNot Nothing Then scope.Dispose()
            Catch ex As Exception
                Throw ex
            End Try
        End Try

        Return resultDs

    End Function

#End Region

#Region "     刪除 "

    ''' <summary>
    ''' 資料刪除
    ''' </summary>
    ''' <param name="inDeleteDs">新增DataSet</param> 
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan Tsai on 2014-11-08</remarks>
    Public Function deletePubSyscodeType(ByVal inDeleteDs As DataSet) As DataSet

        Dim resultDs As New DataSet          '回傳DataSet
        Dim pvtIndex As Integer = 0          '處理記錄索引位置 
        Dim pvtSysTime As DateTime = Now     '系統時間
        Dim pvtErrorCount As Integer = 0     '註記錯誤筆數位置
        Dim pvtSystemTime As String          '系統時間

        Dim m_Pub_Syscode_Type As PubSyscodeTypeBO_E1 = PubSyscodeTypeBO_E1.getInstance

        resultDs.Tables.Add("Save_Result")
        resultDs.Tables("Save_Result").Columns.Add("Type_Id")
        resultDs.Tables("Save_Result").Columns.Add("ErrMsg")
        resultDs.Tables("Save_Result").Columns.Add("Check_Index")

        Dim scope As TransactionScope = Nothing

        Try

            pvtSystemTime = Now.ToString("yyyy/MM/dd HH:mm:ss")

            scope = SQLConnFactory.getInstance.getRequiredTransactionScope()

            Using conn As System.Data.IDbConnection = CType(getConnection(), SqlConnection)

                conn.Open()

                '-------------------------------------------------------------
                '1.逐筆刪除
                '-------------------------------------------------------------
                For i = 0 To inDeleteDs.Tables(0).Rows.Count - 1

                    Try
                        pvtIndex = i

                        '修正Modified_Time時間為Server端時間
                        inDeleteDs.Tables(0).Rows(i).Item("Modified_Time") = pvtSystemTime

                        m_Pub_Syscode_Type.deletePubSyscodeTypeByPK(inDeleteDs.Tables(0).Rows(i).Item("Type_Id").ToString.Trim, conn)

                        '刪除成功，才寫入BK檔
                        deleteBackup(inDeleteDs.Tables(0).Rows(i)) '備份機制

                    Catch sqlex As SqlException
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Type_Id") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Type_Id")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("ErrMsg") = sqlex.Message
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Check_Index") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Check_Index")
                        pvtErrorCount += 1
                        '-------------------------------------------------------------
                    Catch ex As Exception
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Type_Id") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Type_Id")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("ErrMsg") = ex.Message
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Check_Index") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Check_Index")
                        pvtErrorCount += 1
                        '-------------------------------------------------------------
                    End Try

                Next

                '-------------------------------------------------------------
                '2.交易處理
                '-------------------------------------------------------------
                If pvtErrorCount = 0 Then
                    scope.Complete()
                End If
                '-------------------------------------------------------------

            End Using

        Catch cmex As CommonException
            Throw cmex

        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        Finally
            Try
                If scope IsNot Nothing Then scope.Dispose()
            Catch ex As Exception
                Throw ex
            End Try
        End Try

        Return resultDs

    End Function

#End Region

#Region " 備份"

    ''' <summary>
    '''取得資料庫備份表格的 DataTable 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableBKWithSchema() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName & "_BK")
            dt.Columns.Add("Action")
            dt.Columns("Action").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Backup_Time")
            dt.Columns("Backup_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Type_Id")
            dt.Columns("Type_Id").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Type_Name")
            dt.Columns("Type_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(2) As DataColumn
            pkColArray(2) = dt.Columns("Type_Id")
            pkColArray(0) = dt.Columns("Action")
            pkColArray(1) = dt.Columns("Backup_Time")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 備份新增資料
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Protected Sub insertBackup(ByVal row As DataRow)
        dataBackup("Insert", row)
    End Sub


    ''' <summary>
    ''' 備份新增資料
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Protected Sub insertBackupTable(ByVal table As DataTable)
        If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
            For Each row In table.Rows
                insertBackup(row)
            Next
        End If
    End Sub


    ''' <summary>
    ''' 備份更新資料
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Protected Sub updateBackup(ByVal row As DataRow)
        dataBackup("Update", row)
    End Sub


    ''' <summary>
    ''' 備份更新資料
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Protected Sub updateBackupTable(ByVal table As DataTable)
        If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
            For Each row In table.Rows
                updateBackup(row)
            Next
        End If
    End Sub


    ''' <summary>
    ''' 備份主程式
    ''' </summary>
    ''' <param name="action"></param>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Protected Sub dataBackup(ByRef action As String, ByRef row As DataRow)
        Dim bkDS = New DataSet
        Dim bkTable = getDataTableBKWithSchema()
        Dim bkRow = bkTable.NewRow()
        bkRow("Action") = action
        bkRow("Backup_Time") = Now
        bkRow("Type_Id") = row.Item("Type_Id")
        bkRow("Type_Name") = row.Item("Type_Name")
        bkRow("Create_User") = row.Item("Create_User")
        bkRow("Create_Time") = row.Item("Create_Time")
        bkRow("Modified_User") = row.Item("Modified_User")
        bkRow("Modified_Time") = row.Item("Modified_Time")
        bkTable.Rows.Add(bkRow)
        bkDS.Tables.Add(bkTable)
        MessageQueueUtil.getInstance.sendBackupTableMessage(bkDS)
    End Sub


    ''' <summary>
    ''' 備份刪除資料
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks>BO刪除動作要在這個方法之後，不然刪掉就沒資料了可以備份了；有 PKey 而不想太麻煩，用另一個方法，傳入PKey</remarks>
    Protected Sub deleteBackup(ByVal row As DataRow)
        Dim user As New UserProfile
        If row("Modified_User") IsNot Nothing Then
            row("Modified_User") = user.userId
        End If
        If row("Modified_Time") IsNot Nothing Then
            row("Modified_Time") = Now
        End If
        dataBackup("Delete", row)
    End Sub


    ''' <summary>
    ''' 備份刪除資料
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Protected Sub deleteBackupTable(ByVal table As DataTable)
        If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
            For Each row In table.Rows
                deleteBackup(row)
            Next
        End If
    End Sub

#End Region

#Region "     取得 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function getConnection() As IDbConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

