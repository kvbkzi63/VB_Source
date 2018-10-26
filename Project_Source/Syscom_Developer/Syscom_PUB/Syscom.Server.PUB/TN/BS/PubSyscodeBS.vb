'/*
'*****************************************************************************
'*
'*    Page/Class Name:  公用代碼維護
'*              Title:	PubSyscode
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Alan.Tsai
'*        Create Date:	2014-11-09
'*      Last Modifier:	Alan.Tsai
'*   Last Modify Date:	2014-11-09
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
Imports System.Text
Imports Syscom.Server.CMM

Public Class PubSyscodeBS

    Public Shared ReadOnly tableName As String = "PUB_Syscode"

#Region "########## getInstance ##########"

    Private Shared myInstance As PubSyscodeBS

    Public Overloads Function getInstance() As PubSyscodeBS
        If myInstance Is Nothing Then
            myInstance = New PubSyscodeBS()
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
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Function savePubSyscode(ByVal inSaveDs As DataSet) As DataSet

        Dim resultDs As New DataSet          '回傳DataSet
        Dim pvtIndex As Integer = 0          '處理記錄索引位置 
        Dim pvtErrorCount As Integer = 0     '註記錯誤筆數位置
        Dim pvtSystemTime As String          '系統時間

        Dim m_Pub_Syscode As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance

        Dim scope As TransactionScope = Nothing

        Try

            pvtSystemTime = Now.ToString("yyyy/MM/dd HH:mm:ss")

            resultDs.Tables.Add("Save_Result")
            resultDs.Tables("Save_Result").Columns.Add("Type_Id")
            resultDs.Tables("Save_Result").Columns.Add("Code_Id")
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

                            m_Pub_Syscode.insertPUBSyscodeByRowData(inSaveDs.Tables(0).Rows(i).Item("Type_Id").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Code_Id").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Code_En_Name").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Code_Name").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Is_Default").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Sort_Value").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Dc").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Create_User").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Create_Time").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Modified_User").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Modified_Time").ToString.Trim,
                                                                    conn)
                            '新增成功，才寫入BK檔
                            insertBackup(inSaveDs.Tables(0).Rows(i), conn) '備份機制

                        Else

                            '修正Modified_Time時間為Server端時間
                            inSaveDs.Tables(0).Rows(i).Item("Modified_Time") = pvtSystemTime

                            m_Pub_Syscode.updatePUBSyscodeByRowData(inSaveDs.Tables(0).Rows(i).Item("Type_Id").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Code_Id").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Code_En_Name").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Code_Name").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Is_Default").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Sort_Value").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Dc").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Modified_User").ToString.Trim,
                                                                    inSaveDs.Tables(0).Rows(i).Item("Modified_Time").ToString.Trim,
                                                                    conn)
                            '修改成功，才寫入BK檔
                            updateBackup(inSaveDs.Tables(0).Rows(i), conn) '備份機制

                        End If

                    Catch sql_ex As SqlException
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Type_Id") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Type_Id")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Code_Id") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Code_Id")
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
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Code_Id") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Code_Id")
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
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Function deletePubSyscode(ByVal inDeleteDs As DataSet) As DataSet

        Dim resultDs As New DataSet          '回傳DataSet
        Dim pvtIndex As Integer = 0          '處理記錄索引位置 
        Dim pvtSysTime As DateTime = Now     '系統時間
        Dim pvtErrorCount As Integer = 0     '註記錯誤筆數位置
        Dim pvtSystemTime As String          '系統時間

        Dim m_Pub_Syscode As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance

        resultDs.Tables.Add("Save_Result")
        resultDs.Tables("Save_Result").Columns.Add("Type_Id")
        resultDs.Tables("Save_Result").Columns.Add("Code_Id")
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

                        '先寫入BK檔，否則撈不到資料
                        deleteBackup(inDeleteDs.Tables(0).Rows(i), conn) '備份機制

                        m_Pub_Syscode.deletePubSyscodeByPK(inDeleteDs.Tables(0).Rows(i).Item("Type_Id").ToString.Trim,
                                                           inDeleteDs.Tables(0).Rows(i).Item("Code_Id").ToString.Trim,
                                                           conn)



                    Catch sqlex As SqlException
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Type_Id") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Type_Id")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Code_Id") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Code_Id")
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
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Code_Id") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Code_Id")
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
            dt.Columns.Add("Code_Id")
            dt.Columns("Code_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Code_En_Name")
            dt.Columns("Code_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Code_Name")
            dt.Columns("Code_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Default")
            dt.Columns("Is_Default").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sort_Value")
            dt.Columns("Sort_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(3) As DataColumn
            pkColArray(2) = dt.Columns("Type_Id")
            pkColArray(3) = dt.Columns("Code_Id")
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
    Protected Sub insertBackup(ByVal row As DataRow, ByRef conn As System.Data.IDbConnection)
        dataBackup("Insert", row, conn)
    End Sub


    ''' <summary>
    ''' 備份新增資料
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Protected Sub insertBackupTable(ByVal table As DataTable, ByRef conn As System.Data.IDbConnection)
        If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
            For Each row In table.Rows
                insertBackup(row, conn)
            Next
        End If
    End Sub


    ''' <summary>
    ''' 備份更新資料
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Protected Sub updateBackup(ByVal row As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing)
        dataBackup("Update", row, conn)
    End Sub


    ''' <summary>
    ''' 備份更新資料
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Protected Sub updateBackupTable(ByVal table As DataTable, ByRef conn As System.Data.IDbConnection)
        If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
            For Each row In table.Rows
                updateBackup(row, conn)
            Next
        End If
    End Sub


    ''' <summary>
    ''' 備份主程式
    ''' </summary>
    ''' <param name="action"></param>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Protected Sub dataBackup(ByRef action As String, ByRef row As DataRow, ByRef conn As System.Data.IDbConnection)
        Dim bkDS = New DataSet
        Dim bkTable = getDataTableBKWithSchema()
        Dim bkRow = bkTable.NewRow()
        bkRow("Action") = action
        bkRow("Backup_Time") = Now
        bkRow("Type_Id") = row.Item("Type_Id")
        bkRow("Code_Id") = row.Item("Code_Id")
        bkRow("Code_En_Name") = row.Item("Code_En_Name")
        bkRow("Code_Name") = row.Item("Code_Name")
        bkRow("Is_Default") = row.Item("Is_Default")
        bkRow("Sort_Value") = row.Item("Sort_Value")
        bkRow("Dc") = row.Item("Dc")
        bkRow("Create_User") = row.Item("Create_User")
        bkRow("Create_Time") = row.Item("Create_Time")
        bkRow("Modified_User") = row.Item("Modified_User")
        bkRow("Modified_Time") = row.Item("Modified_Time")
        bkTable.Rows.Add(bkRow)
        bkDS.Tables.Add(bkTable)
        If bkDS.Tables(0).Rows.Count > 0 Then
            Try
                Dim Content As New StringBuilder
                Content.AppendLine("	 Insert Into " & tableName & "_BK (Action,Backup_Time")
                Content.AppendLine("      , Type_Id")
                Content.AppendLine("      , Code_Id")
                Content.AppendLine("      , Code_En_Name")
                Content.AppendLine("      , Code_Name")
                Content.AppendLine("      , Is_Default")
                Content.AppendLine("      , Sort_Value")
                Content.AppendLine("      , Dc")
                Content.AppendLine("      , Create_User")
                Content.AppendLine("      , Create_Time")
                Content.AppendLine("      , Modified_User")
                Content.AppendLine("      , Modified_Time")
                Content.AppendLine("      )")
                Content.AppendLine("Select '" & action & "','" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "' ,* From " & tableName & " Where 1=1 ")
                Content.AppendLine("   And Type_Id=@Type_Id")
                Content.AppendLine("   And Code_Id=@Code_Id")
                Using Command As SqlCommand = conn.CreateCommand
                    Command.CommandText = Content.ToString
                    Command.Parameters.AddWithValue("@Type_Id", bkRow("Type_Id"))
                    Command.Parameters.AddWithValue("@Code_Id", bkRow("Code_Id"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                End Using
            Catch ex As Exception
                Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(bkDS.GetXml, ex)
            End Try
        End If
    End Sub


    ''' <summary>
    ''' 備份刪除資料
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks>BO刪除動作要在這個方法之後，不然刪掉就沒資料了可以備份了；有 PKey 而不想太麻煩，用另一個方法，傳入PKey</remarks>
    Protected Sub deleteBackup(ByVal row As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing)
        'MOdify on 20160609 By Lits
        Dim user As ServerUserProfile = ServerAppContext.userProfile
        row("Modified_User") = user.userId
        row("Modified_Time") = Now
        dataBackup("Delete", row, conn)
    End Sub


    ''' <summary>
    ''' 備份刪除資料
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Protected Sub deleteBackupTable(ByVal table As DataTable, Optional ByRef conn As System.Data.IDbConnection = Nothing)
        If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
            For Each row In table.Rows
                deleteBackup(row, conn)
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

