'/*
'*****************************************************************************
'*
'*    Page/Class Name:  醫事機構維護
'*              Title:	PubHospital
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


Public Class PubHospitalBS

    Public Shared ReadOnly tableName As String = "PUB_Hospital"

#Region "########## getInstance ##########"

    Private Shared myInstance As PubHospitalBS

    Public Overloads Function getInstance() As PubHospitalBS
        If myInstance Is Nothing Then
            myInstance = New PubHospitalBS()
        End If
        Return myInstance
    End Function

    Public Sub New()
    End Sub

#End Region

#Region "     取得畫面初始化資料 "

    ''' <summary>
    ''' 取得畫面初始化資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan Tsai on 2014-11-10</remarks>
    Public Function initPubHospital() As DataSet
        Dim dsResult As New DataSet
        Dim dsLanguageTypeId, dsPostalCode, dsHospitalLevelId As New DataTable
        Dim PubBO As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance
        Dim PubBO2 As PubPostalCodeBO = PubPostalCodeBO.GetInstance

        Try

            '類別
            dsLanguageTypeId = PubBO.queryPUBSyscode("75", "PUB_SysCode1")

            '郵遞區號
            dsPostalCode = PubBO2.queryAll().Tables(0).Copy

            '醫療院所層級
            dsHospitalLevelId = PubBO.queryPUBSyscode("88", "PUB_SysCode3")

            dsResult.Tables.Add(dsLanguageTypeId.Copy)
            dsResult.Tables.Add(dsPostalCode.Copy)
            dsResult.Tables.Add(dsHospitalLevelId.Copy)

            Return dsResult

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

#End Region

#Region "     存檔 "

    ''' <summary>
    ''' 資料存檔
    ''' </summary>
    ''' <param name="inSaveDs">存檔DataSet</param>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Function savePubHospital(ByVal inSaveDs As DataSet) As DataSet

        Dim resultDs As New DataSet          '回傳DataSet
        Dim pvtIndex As Integer = 0          '處理記錄索引位置 
        Dim pvtErrorCount As Integer = 0     '註記錯誤筆數位置
        Dim pvtSystemTime As String          '系統時間

        Dim m_Pub_Hospital As PubHospitalBO_E1 = PubHospitalBO_E1.getInstance

        Dim scope As TransactionScope = Nothing

        Try

            pvtSystemTime = Now.ToString("yyyy/MM/dd HH:mm:ss")

            resultDs.Tables.Add("Save_Result")
            resultDs.Tables("Save_Result").Columns.Add("Language_Type_Id")
            resultDs.Tables("Save_Result").Columns.Add("Hospital_Code")
            resultDs.Tables("Save_Result").Columns.Add("Effect_Date")
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

                            m_Pub_Hospital.insertPubHospitalByRowData(inSaveDs.Tables(0).Rows(i).Item("Language_Type_Id").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Hospital_Code").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Effect_Date").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("End_Date").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Hospital_Name").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Hospital_Short_Name").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Telephone").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Fax").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Voice_Tel").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Postal_Code").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Address").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Principal_Name").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Principal_Email").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Hospital_Level_Id").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("URL").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Unified_Business_No").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Create_User").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Create_Time").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Modified_User").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Modified_Time").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("License_No").ToString.Trim,
                                                                        inSaveDs.Tables(0).Rows(i).Item("Receipt_Hospital_Name").ToString.Trim,
                                                                      conn)  'Add By Elly 2016/10/19   inSaveDs.Tables(0).Rows(i).Item("Receipt_Hospital_Name").ToString.Trim,

                            '新增成功，才寫入BK檔
                            insertBackup(inSaveDs.Tables(0).Rows(i)) '備份機制

                        Else

                            '修正Modified_Time時間為Server端時間
                            inSaveDs.Tables(0).Rows(i).Item("Modified_Time") = pvtSystemTime

                            m_Pub_Hospital.updatePubHospitalByRowData(inSaveDs.Tables(0).Rows(i).Item("Language_Type_Id").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Hospital_Code").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Effect_Date").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("End_Date").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Hospital_Name").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Hospital_Short_Name").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Telephone").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Fax").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Voice_Tel").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Postal_Code").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Address").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Principal_Name").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Principal_Email").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Hospital_Level_Id").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("URL").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Unified_Business_No").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Modified_User").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Modified_Time").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Org_Effect_Date").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("License_No").ToString.Trim,
                                                                      inSaveDs.Tables(0).Rows(i).Item("Receipt_Hospital_Name").ToString.Trim,
                                                                      conn) 'Add By Elly 2016/10/19   inSaveDs.Tables(0).Rows(i).Item("Receipt_Hospital_Name").ToString.Trim,
                            '修改成功，才寫入BK檔
                            updateBackup(inSaveDs.Tables(0).Rows(i)) '備份機制
                        End If

                    Catch sql_ex As SqlException
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Language_Type_Id") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Language_Type_Id")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Hospital_Code") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Hospital_Code")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Effect_Date") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Effect_Date")
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
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Language_Type_Id") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Language_Type_Id")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Hospital_Code") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Hospital_Code")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Effect_Date") = inSaveDs.Tables(0).Rows(pvtIndex).Item("Effect_Date")
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
    Public Function deletePubHospital(ByVal inDeleteDs As DataSet) As DataSet

        Dim resultDs As New DataSet          '回傳DataSet
        Dim pvtIndex As Integer = 0          '處理記錄索引位置 
        Dim pvtSysTime As DateTime = Now     '系統時間
        Dim pvtErrorCount As Integer = 0     '註記錯誤筆數位置
        Dim pvtSystemTime As String          '系統時間

        Dim m_Pub_Hospital As PubHospitalBO_E1 = PubHospitalBO_E1.getInstance

        resultDs.Tables.Add("Save_Result")
        resultDs.Tables("Save_Result").Columns.Add("Language_Type_Id")
        resultDs.Tables("Save_Result").Columns.Add("Hospital_Code")
        resultDs.Tables("Save_Result").Columns.Add("Effect_Date")
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
                        m_Pub_Hospital.deletePubHospitalByPK(inDeleteDs.Tables(0).Rows(i).Item("Language_Type_Id").ToString.Trim, _
                                                             inDeleteDs.Tables(0).Rows(i).Item("Hospital_Code").ToString.Trim, _
                                                             inDeleteDs.Tables(0).Rows(i).Item("Org_Effect_Date").ToString.Trim, _
                                                             conn)

                        '刪除成功，才寫入BK檔
                        deleteBackup(inDeleteDs.Tables(0).Rows(i)) '備份機制

                    Catch sqlex As SqlException
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Language_Type_Id") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Language_Type_Id")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Hospital_Code") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Hospital_Code")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Effect_Date") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Effect_Date")
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
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Language_Type_Id") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Language_Type_Id")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Hospital_Code") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Hospital_Code")
                        resultDs.Tables(0).Rows(pvtErrorCount).Item("Effect_Date") = inDeleteDs.Tables(0).Rows(pvtIndex).Item("Effect_Date")
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
            dt.Columns.Add("Language_Type_Id")
            dt.Columns("Language_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Code")
            dt.Columns("Hospital_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Hospital_Name")
            dt.Columns("Hospital_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Short_Name")
            dt.Columns("Hospital_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Telephone")
            dt.Columns("Telephone").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fax")
            dt.Columns("Fax").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Voice_Tel")
            dt.Columns("Voice_Tel").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Postal_Code")
            dt.Columns("Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Address")
            dt.Columns("Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Principal_Name")
            dt.Columns("Principal_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Principal_Email")
            dt.Columns("Principal_Email").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Level_Id")
            dt.Columns("Hospital_Level_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("URL")
            dt.Columns("URL").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Unified_Business_No")
            dt.Columns("Unified_Business_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("License_No")
            dt.Columns("License_No").DataType = System.Type.GetType("System.String")
            'Add By Elly 2016/10/19  --start
            dt.Columns.Add("Receipt_Hospital_Name")
            dt.Columns("Receipt_Hospital_Name").DataType = System.Type.GetType("System.String")
            '--end
            Dim pkColArray(4) As DataColumn
            pkColArray(2) = dt.Columns("Language_Type_Id")
            pkColArray(3) = dt.Columns("Hospital_Code")
            pkColArray(4) = dt.Columns("Effect_Date")
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
        bkRow("Language_Type_Id") = row.Item("Language_Type_Id")
        bkRow("Hospital_Code") = row.Item("Hospital_Code")
        bkRow("Effect_Date") = row.Item("Effect_Date")
        bkRow("End_Date") = row.Item("End_Date")
        bkRow("Hospital_Name") = row.Item("Hospital_Name")
        bkRow("Hospital_Short_Name") = row.Item("Hospital_Short_Name")
        bkRow("Telephone") = row.Item("Telephone")
        bkRow("Fax") = row.Item("Fax")
        bkRow("Voice_Tel") = row.Item("Voice_Tel")
        bkRow("Postal_Code") = row.Item("Postal_Code")
        bkRow("Address") = row.Item("Address")
        bkRow("Principal_Name") = row.Item("Principal_Name")
        bkRow("Principal_Email") = row.Item("Principal_Email")
        bkRow("Hospital_Level_Id") = row.Item("Hospital_Level_Id")
        bkRow("URL") = row.Item("URL")
        bkRow("Unified_Business_No") = row.Item("Unified_Business_No")
        bkRow("Create_User") = row.Item("Create_User")
        bkRow("Create_Time") = row.Item("Create_Time")
        bkRow("Modified_User") = row.Item("Modified_User")
        bkRow("Modified_Time") = row.Item("Modified_Time")
        bkRow("License_No") = row.Item("License_No")
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
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function getConnection() As IDbConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

