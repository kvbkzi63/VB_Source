'/*
'*****************************************************************************
'*
'*    Page/Class Name:  轉入健保醫令價格異動檔-衛材
'*              Title:	PUBNhiCodeImportMBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Chi,Wang
'*        Create Date:	2017-02-23
'*      Last Modifier:	Chi,Wang
'*   Last Modify Date:	2017-02-23
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Comm.Utility.DateUtil


Public Class PUBNhiCodeImportMBO_E1
    Inherits PubNhiCodeImportBO


#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBNhiCodeImportMBO_E1
    Public Overloads Shared Function GetInstance() As PUBNhiCodeImportMBO_E1
        If myInstance Is Nothing Then
            myInstance = New PUBNhiCodeImportMBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     修改 Method "

#End Region

    '******************************

#Region " 匯入健保醫令價格異動檔 "

    ''' <summary>
    ''' 匯入健保醫令價格異動檔
    ''' </summary>
    ''' <param name="ds" >匯入excel資料</param>
    ''' <param name="strUserId" >登入者</param>
    ''' <param name="strDownload_Sn" >匯入版本號</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function ImportCase(ByVal ds As DataSet, ByVal strDownload_Sn As String, ByVal strUserId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim count As Integer = 0
            '前端得到的excel DataSet
            For Each dt As DataTable In ds.Tables
                For Each row As DataRow In dt.Rows
                    '生效日期、事前審查生效日期、生效迄日 : 民國年轉西元年()
                    '日期格式 106/03/01 & 106/12/11
                    If Len(row.Item(5).ToString.Trim) = 9 Then
                        row.Item(5) = TransDateToWE(row.Item(5).ToString)
                    End If
                    '日期格式  1060301 & 106/3/1
                    If Len(row.Item(5).ToString.Trim) = 7 Then
                        '106/3/1
                        If row.Item(5).ToString.Trim.Substring(3, 1) = "/" And row.Item(5).ToString.Trim.Substring(5, 1) = "/" Then
                            row.Item(5) = row.Item(5).ToString.Trim.Substring(0, 4) & "0" & row.Item(5).ToString.Trim.Substring(4, 2) & "0" & row.Item(5).ToString.Trim.Substring(6, 1)
                        Else '1060301 
                            row.Item(5) = row.Item(5).ToString.Trim.Substring(0, 3) & "/" & row.Item(5).ToString.Trim.Substring(3, 2) & "/" & row.Item(5).ToString.Trim.Substring(5, 2)
                        End If
                        row.Item(5) = TransDateToWE(row.Item(5).ToString)
                    End If
                    '日期格式 106/3/12 106/12/1 
                    If Len(row.Item(5).ToString.Trim) = 8 Then
                        If row.Item(5).ToString.Trim.Substring(3, 1) = "/" And row.Item(5).ToString.Trim.Substring(5, 1) = "/" Then
                            row.Item(5) = row.Item(5).ToString.Trim.Substring(0, 4) & "0" & row.Item(5).ToString.Trim.Substring(4, 4)
                        ElseIf row.Item(5).ToString.Trim.Substring(3, 1) = "/" And row.Item(5).ToString.Trim.Substring(6, 1) = "/" Then
                            row.Item(5) = row.Item(5).ToString.Trim.Substring(0, 7) & "0" & row.Item(5).ToString.Trim.Substring(7, 1)
                        End If
                        row.Item(5) = TransDateToWE(row.Item(5).ToString)
                    End If

                Next
            Next

            ' (四)	匯入，皆先delete from PUB_Nhi_Code_Import where  Nhi_Download_Sn=下載版本號
            Dim sqlString As String = "delete from PUB_Nhi_Code_Import where Nhi_Download_Sn='" & strDownload_Sn & "'"

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                count = command.ExecuteNonQuery
            End Using

            '再Insert  into PUB_Nhi_Code_Import
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

                If CheckMethodUtil.CheckHasTable(ds) Then
                    insertlogdata(ds, strDownload_Sn, strUserId, conn)
                End If
                scope.Complete()

            End Using

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


#Region " 新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function insertlogdata(ByVal ds As DataSet, ByVal strDownload_Sn As String, ByVal strUserId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("INSERT INTO PUB_Nhi_Code_Import")
            Content.AppendLine("           (Nhi_Download_Sn,Nhi_Import_Sn,Item_No,Insu_Code ,Insu_Name,Brand,Content_Desc")
            Content.AppendLine("           ,Form_Desc,Spec_Desc,Orig_Price,New_Price,Effect_Date")
            Content.AppendLine("           ,Trans_User,Trans_Time,Create_User ,Create_Time ,Modified_User")
            Content.AppendLine("           ,Modified_Time)")
            Content.AppendLine(" VALUES (@strDownload_Sn,@Nhi_Import_Sn,@Item_No,@Insu_Code ,@Insu_Name,@Brand,@Content_Desc")
            Content.AppendLine("           ,@Form_Desc,@Spec_Desc,@Orig_Price,@New_Price,@Effect_Date")
            Content.AppendLine("           ,@Trans_User,@Trans_Time,@Create_User ,@Create_Time ,@Modified_User")
            Content.AppendLine("           ,@Modified_Time)")


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim CountItemNo As Integer = 1
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    Dim Insu_Name As String = row.Item(1).ToString.Trim
                    If Len(Insu_Name) > 200 Then
                        Insu_Name = row.Item(1).ToString.Trim.Substring(0, 200)
                    End If
                    Dim Brand As String = row.Item(10).ToString.Trim
                    If Len(Brand) > 200 Then
                        Brand = row.Item(10).ToString.Trim.Substring(0, 200)
                    End If
                    Dim Content_Desc As String = row.Item(2).ToString.Trim
                    If Len(Content_Desc) > 200 Then
                        Content_Desc = row.Item(2).ToString.Trim.Substring(0, 200)
                    End If
                    Dim Form_Desc As String = row.Item(8).ToString.Trim
                    If Len(Form_Desc) > 200 Then
                        Form_Desc = row.Item(8).ToString.Trim.Substring(0, 200)
                    End If
                    Dim Spec_Desc As String = row.Item(3).ToString.Trim
                    If Len(Spec_Desc) > 200 Then
                        Spec_Desc = row.Item(3).ToString.Trim.Substring(0, 200)
                    End If
                    command.Parameters.AddWithValue("@strDownload_Sn", strDownload_Sn)
                    command.Parameters.AddWithValue("@Nhi_Import_Sn", "")
                    command.Parameters.AddWithValue("@Item_No", CountItemNo)
                    command.Parameters.AddWithValue("@Insu_Code", row.Item(0).ToString.Trim)
                    command.Parameters.AddWithValue("@Insu_Name", Insu_Name)
                    command.Parameters.AddWithValue("@Brand", Brand)
                    command.Parameters.AddWithValue("@Content_Desc", Content_Desc)
                    command.Parameters.AddWithValue("@Form_Desc", Form_Desc)
                    command.Parameters.AddWithValue("@Spec_Desc", Spec_Desc)
                    command.Parameters.AddWithValue("@Orig_Price", 0)
                    command.Parameters.AddWithValue("@New_Price", row.Item(4).ToString.Trim)
                    command.Parameters.AddWithValue("@Effect_Date", CDate(row.Item(5).ToString.Trim))
                    command.Parameters.AddWithValue("@Trans_User", DBNull.Value)
                    command.Parameters.AddWithValue("@Trans_Time", DBNull.Value)
                    command.Parameters.AddWithValue("@Create_User", strUserId)
                    command.Parameters.AddWithValue("@Create_Time", Now)
                    command.Parameters.AddWithValue("@Modified_User", strUserId)
                    command.Parameters.AddWithValue("@Modified_Time", Now)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                    CountItemNo += 1
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

    '******************************

#Region "     查詢 Method "
#Region " query健保醫令價格異動檔 "

    ''' <summary>
    ''' query健保醫令價格異動檔
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function querydata(ByVal strNhi_Download_Sn As String, ByVal strInsu_Code As String, ByVal strEffect_Date As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            '四、	查詢，控制至少輸入一個條件，沒有輸入showmessage (至少輸入下載版本號或生效日或健保碼!)。
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            'Content.AppendLine("select A.*,B.*")
            Content.AppendLine("select  LTRIM(RTRIM(A.Nhi_Download_Sn)) as Nhi_Download_Sn , LTRIM(RTRIM(A.Nhi_Import_Sn)) as Nhi_Import_Sn ,A.Item_No,dbo.AdToRocDate(A.Effect_Date) as Effect_Date, LTRIM(RTRIM(A.Insu_Code)) as Insu_Code, LTRIM(RTRIM(A.Insu_Name)) as Insu_Name, A.Orig_Price, A.New_Price,LTRIM(RTRIM(B.Order_Code)) as Order_Code, A.Brand, A.Content_Desc,")
            Content.AppendLine("A.Modified_User,dbo.AdToRocDate( A.Modified_Time) as Modified_Time")
            Content.AppendLine("from  PUB_Nhi_Code_Import A")
            Content.AppendLine("Left Join PUB_Order_Price B")
            Content.AppendLine("on (A.Insu_Code=B.Insu_Code and B.Dc='N')")
            Content.AppendLine("where 1=1 and ISNULL(Order_Code,'')<>'' ")
            '下載版本號，有此查詢條件才加入
            If strNhi_Download_Sn <> "" Then
                Content.AppendLine("and A.Nhi_Download_Sn=@strNhi_Download_Sn ")
            End If
            '@健保碼，有此查詢條件才加入
            If strInsu_Code <> "" Then
                Content.AppendLine("and A.Insu_Code =@strInsu_Code")
            End If
            '@生效日，有此查詢條件才加入
            If strEffect_Date <> "" Then
                Content.AppendLine("and A.Effect_Date =@strEffect_Date")
            End If

            command.CommandText = Content.ToString

            '下載版本號，有此查詢條件才加入
            If strNhi_Download_Sn <> "" Then
                command.Parameters.AddWithValue("@strNhi_Download_Sn", strNhi_Download_Sn)
            End If
            '@健保碼，有此查詢條件才加入
            If strInsu_Code <> "" Then
                command.Parameters.AddWithValue("@strInsu_Code", strInsu_Code)
            End If
            '@生效日，有此查詢條件才加入
            If strEffect_Date <> "" Then
                command.Parameters.AddWithValue("@strEffect_Date", strEffect_Date)
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Nhi_Code_Import")
                adapter.Fill(ds, "PUB_Nhi_Code_Import")
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

#End Region

#End Region

    '******************************

#Region " 轉入醫令價格檔 "

    ''' <summary>
    ''' 轉入醫令價格檔
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <param name="ds" >匯入user選取資料 從查詢來</param>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function importorderprice(ByVal ds As DataSet, ByVal struser As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        '若沒有先查詢出東西 不可按匯入健保醫令價格異動檔
        '
        Dim connFlag As Boolean = conn Is Nothing
        '五、	轉入醫令價格檔，將GIRD 欄位’選’以勾選的紀錄，轉入醫令項目價格檔(PUB_Order_Price)
        '以勾選的在前端存成dataset傳回後端
        Try
            Dim count As Integer = 0


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            '(一)需包成同一個交易(transactions)。
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()
                '(二)已存在自費單價及健保單價，需更新健保單價。
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim streffectdate As String = TransDateToWE(ds.Tables(0).Rows(i).Item("Effect_Date").ToString.Trim)
                    Dim strprice As String = ds.Tables(0).Rows(i).Item("New_Price").ToString.Trim
                    Dim strOrderCode As String = ds.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                    Dim strDownload_Sn As String = ds.Tables(0).Rows(i).Item("Nhi_Download_Sn").ToString.Trim
                    Dim strImport_Sn As String = ds.Tables(0).Rows(i).Item("Nhi_Import_Sn").ToString.Trim
                    Dim strItem_Non As String = ds.Tables(0).Rows(i).Item("Item_No").ToString.Trim

                    'OrderCode=null 不做事
                    If strOrderCode <> "" Then
                        count = importexceldata(streffectdate, strprice, strOrderCode, strDownload_Sn, strImport_Sn, strItem_Non, struser)
                    Else
                        count = 1
                    End If
                Next
                scope.Complete()
            End Using

            Return count

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

#End Region


#Region " 主邏輯 "

    ''' <summary>
    ''' 主邏輯
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <param name="streffectdate" >EXCEL的生效日</param>
    ''' <param name="strprice" >EXCEL的新核定價</param>
    ''' <param name="strOrderCode" >目前處理的醫令</param>
    ''' <param name="struser" >異動者</param>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function importexceldata(ByVal streffectdate As String, ByVal strprice As String, ByVal strOrderCode As String, ByVal strDownload_Sn As String, ByVal strImport_Sn As String, ByVal strItem_Non As String, ByVal struser As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing
        '以勾選的在前端存成dataset傳回後端 
        '進入此每次為一筆資料
        Try
            Dim currentTime = Now
            Dim count As Integer = 0


            Dim dateflag As Boolean  '判斷EXCEL(勾選)的生效日大於或小於Now
            If CDate(streffectdate) > Now Then ' 若EXCEL的生效日>Now @DC=Y
                dateflag = True
            Else ' 若EXCEL的生效日<=Now @DC=N
                dateflag = False
            End If

            '***************健保***************************
            '1:自費 2:健保

            '1.查詢結果的院內碼，找出目前有效的紀錄
            Dim effectds As DataSet = queryEffectDate(strOrderCode, "2", conn)
            Dim top1 As DataSet = queryTop1(strOrderCode, "2", conn)
            '2.	刪除EXCEL的生效日之後的醫令項目價格檔
            count = deleteeffectdate(streffectdate, strOrderCode, "2", conn)
            '3.複製目前有效的紀錄(PUB_Order_Price)，更改下列欄位，新增一筆到醫令項目價格檔(PUB_Order_Price)。
            count = queryandinsertEffectDate(effectds, streffectdate, strprice, struser, strOrderCode, dateflag, "2", conn)
            '4.	更改目前有效的紀錄 -->更改新增的前一筆
            count = updateBefoerEffectDate(top1, streffectdate, struser, strOrderCode, dateflag, "2", conn)
            '5.Update  PUB_Nhi_Code_Import
            count = updateordercode(strDownload_Sn, strImport_Sn, strItem_Non, struser, conn)
            '***************健保***************************
            '***************自費***************************
            '1:自費 2:健保

            '1.查詢結果的院內碼，找出目前有效的紀錄
            Dim Owneffectds As DataSet = queryEffectDate(strOrderCode, "1", conn)
            Dim Owntop1 As DataSet = queryTop1(strOrderCode, "1", conn)
            '2.	刪除EXCEL的生效日之後的醫令項目價格檔
            count = deleteeffectdate(streffectdate, strOrderCode, "1", conn)
            '3.複製目前有效的紀錄(PUB_Order_Price)，更改下列欄位，新增一筆到醫令項目價格檔(PUB_Order_Price)。
            count = queryandinsertEffectDate(Owneffectds, streffectdate, strprice, struser, strOrderCode, dateflag, "1", conn)
            '4.	更改目前有效的紀錄 -->更改新增的前一筆
            count = updateBefoerEffectDate(Owntop1, streffectdate, struser, strOrderCode, dateflag, "1", conn)
            '5.Update  PUB_Nhi_Code_Import
            count = updateordercode(strDownload_Sn, strImport_Sn, strItem_Non, struser, conn)
            '***************自費***************************


            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 查詢結果的院內碼，找出目前有效的紀錄 "

    ''' <summary>
    ''' 查詢結果的院內碼，找出目前有效的紀錄
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function queryEffectDate(ByVal strOrderCode As String, ByVal flag As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim querycommand As SqlCommand = sqlConn.CreateCommand()
            '查詢結果的院內碼，找出目前有效的紀錄
            querycommand.CommandText = "select  *  from  PUB_Order_Price where dc='N' and Main_Identity_Id='" & flag & "' and  Order_Code='" & strOrderCode & "'"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(querycommand)
                ds = New DataSet("Effect_date")
                adapter.Fill(ds, "Effect_date")
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

#End Region


#Region " 查詢目前有效的紀錄top 2 "

    ''' <summary>
    ''' 查詢目前有效的紀錄top 2
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function queryTop1(ByVal strOrderCode As String, ByVal flag As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim querycommand As SqlCommand = sqlConn.CreateCommand()

            querycommand.CommandText = "select top 1  Effect_Date,Order_Code,Main_Identity_Id from  PUB_Order_Price where  Order_Code='" & strOrderCode & "' and dc='N' and Main_Identity_Id='" & flag & "' order by Effect_Date desc , Main_Identity_Id "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(querycommand)
                ds = New DataSet("Top_1_Effect_date")
                adapter.Fill(ds, "Top_1_Effect_date")
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

#End Region

#Region " 新增醫令項目 "

    ''' <summary>
    ''' 新增醫令項目
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <param name="streffectdate" >EXCEL的生效日</param>
    ''' <param name="strprice" >更新的價錢</param>
    ''' <param name="struser" >異動者</param>
    ''' <param name="strOrderCode" >目前處理的醫令</param>
    ''' <param name="dateflag" >判斷DC</param>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function queryandinsertEffectDate(ByVal ds As DataSet, ByVal streffectdate As String, ByVal strprice As String, ByVal struser As String, ByVal strOrderCode As String, ByVal dateflag As Boolean, ByVal flag As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim count As Integer

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            '複製目前有效的紀錄(PUB_Order_Price)，更改下列欄位，新增一筆到醫令項目價格檔(PUB_Order_Price)。
            If CheckMethodUtil.CheckHasValue(ds) Then
                Dim Content As New StringBuilder
                Content.AppendLine("INSERT INTO PUB_Order_Price")
                Content.AppendLine("           (Effect_Date,Order_Code,Main_Identity_Id,Price,Add_Price,Material_Ratio")
                Content.AppendLine("           ,Material_Account_Id,Order_Ratio,Is_Emg_Add,Is_Kid_Add,Is_Dental_Add,Is_Holiday_Add")
                Content.AppendLine("           ,Is_Dept_Add ,Insu_Code,Insu_Account_Id,Insu_Order_Type_Id,Opd_Add_Order_Code")
                Content.AppendLine("           ,Emg_Add_Order_Code,Ipd_Add_Order_Code  ,Emg_Nursing_Add_Order_Code,Ipd_Nursing_Add_Order_Code")
                Content.AppendLine("           ,Insu_Group_Code,Insu_Apply_Price,Dc,End_Date,Create_User,Create_Time")
                Content.AppendLine("           ,Modified_User,Modified_Time,Charge_Flag)")
                Content.AppendLine("     VALUES (@Effect_Date,@Order_Code,@Main_Identity_Id,@Price,@Add_Price,@Material_Ratio")
                Content.AppendLine("           ,@Material_Account_Id,@Order_Ratio,@Is_Emg_Add,@Is_Kid_Add,@Is_Dental_Add,@Is_Holiday_Add")
                Content.AppendLine("           ,@Is_Dept_Add ,@Insu_Code,@Insu_Account_Id,@Insu_Order_Type_Id,@Opd_Add_Order_Code")
                Content.AppendLine("           ,@Emg_Add_Order_Code,@Ipd_Add_Order_Code  ,@Emg_Nursing_Add_Order_Code,@Ipd_Nursing_Add_Order_Code")
                Content.AppendLine("           ,@Insu_Group_Code,@Insu_Apply_Price,@Dc,@End_Date,@Create_User,@Create_Time")
                Content.AppendLine("           ,@Modified_User,@Modified_Time,@Charge_Flag)")



                Using insertcommand As SqlCommand = New SqlCommand
                    With insertcommand
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With

                    insertcommand.Parameters.AddWithValue("@Order_Code", strOrderCode)

                    '健保
                    If flag = "2" Then
                        insertcommand.Parameters.AddWithValue("@Main_Identity_Id", "2")
                        insertcommand.Parameters.AddWithValue("@Effect_Date", CDate(streffectdate))
                        If dateflag = True Then
                            insertcommand.Parameters.AddWithValue("@Dc", "Y")
                        Else
                            insertcommand.Parameters.AddWithValue("@Dc", "N")
                        End If
                    Else '自費
                        insertcommand.Parameters.AddWithValue("@Main_Identity_Id", "1")
                        insertcommand.Parameters.AddWithValue("@Effect_Date", Now)
                        insertcommand.Parameters.AddWithValue("@Dc", "N")
                    End If

                    insertcommand.Parameters.AddWithValue("@Price", strprice)
                    insertcommand.Parameters.AddWithValue("@Add_Price", ds.Tables(0).Rows(0).Item("Add_Price").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Material_Ratio", ds.Tables(0).Rows(0).Item("Material_Ratio").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Material_Account_Id", ds.Tables(0).Rows(0).Item("Material_Account_Id").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Order_Ratio", ds.Tables(0).Rows(0).Item("Order_Ratio").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Is_Emg_Add", ds.Tables(0).Rows(0).Item("Is_Emg_Add").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Is_Kid_Add", ds.Tables(0).Rows(0).Item("Is_Kid_Add").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Is_Dental_Add", ds.Tables(0).Rows(0).Item("Is_Dental_Add").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Is_Holiday_Add", ds.Tables(0).Rows(0).Item("Is_Holiday_Add").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Is_Dept_Add", ds.Tables(0).Rows(0).Item("Is_Dept_Add").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Insu_Code", ds.Tables(0).Rows(0).Item("Insu_Code").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Insu_Account_Id", ds.Tables(0).Rows(0).Item("Insu_Account_Id").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Insu_Order_Type_Id", ds.Tables(0).Rows(0).Item("Insu_Order_Type_Id").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Opd_Add_Order_Code", ds.Tables(0).Rows(0).Item("Opd_Add_Order_Code").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Emg_Add_Order_Code", ds.Tables(0).Rows(0).Item("Emg_Add_Order_Code").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Ipd_Add_Order_Code", ds.Tables(0).Rows(0).Item("Ipd_Add_Order_Code").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Emg_Nursing_Add_Order_Code", ds.Tables(0).Rows(0).Item("Emg_Nursing_Add_Order_Code").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Ipd_Nursing_Add_Order_Code", ds.Tables(0).Rows(0).Item("Ipd_Nursing_Add_Order_Code").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Insu_Group_Code", ds.Tables(0).Rows(0).Item("Insu_Group_Code").ToString.Trim)
                    insertcommand.Parameters.AddWithValue("@Insu_Apply_Price", ds.Tables(0).Rows(0).Item("Insu_Apply_Price").ToString.Trim)
                   
                    insertcommand.Parameters.AddWithValue("@End_Date", CDate("2910/12/31"))
                    insertcommand.Parameters.AddWithValue("@Create_User", struser)
                    insertcommand.Parameters.AddWithValue("@Create_Time", Now)
                    insertcommand.Parameters.AddWithValue("@Modified_User", struser)
                    insertcommand.Parameters.AddWithValue("@Modified_Time", Now)
                    insertcommand.Parameters.AddWithValue("@Charge_Flag", ds.Tables(0).Rows(0).Item("Charge_Flag").ToString.Trim)
                    count = insertcommand.ExecuteNonQuery()
                End Using
            End If

            Return count

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

#End Region

#Region " 刪除EXCEL的生效日之後的醫令項目價格檔 "

    ''' <summary>
    ''' 刪除EXCEL的生效日之後的醫令項目價格檔
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <param name="streffectdate" >EXCEL的生效日</param>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function deleteeffectdate(ByVal streffectdate As String, ByVal strOrderCode As String, ByVal flag As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            '刪除DB中，EXCEL的生效日之後的醫令項目價格檔
            Dim sqlString As String = "delete from PUB_Order_Price where order_code ='" & strOrderCode & "' and Main_Identity_Id='" & flag & "' and effect_date>='" & CDate(streffectdate) & "'"

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
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
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 修改 PUB_Order_Price "

    ''' <summary>
    ''' 修改 PUB_Order_Price
    ''' </summary>
    ''' <param name="streffectdate" >EXCEL的生效日</param>
    ''' <param name="struser" >異動者</param>
    ''' <param name="strOrderCode" >目前處理的醫令</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function updateBefoerEffectDate(ByVal ds As DataSet, ByVal streffectdate As String, ByVal struser As String, ByVal strOrderCode As String, ByVal dateflag As Boolean, ByVal flag As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            'Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            '停止日(PUB_Order_Price.End_Date)=EXCEL的生效日-1
            '異動者(PUB_Order_Price.Modified_User) =Login user
            '異動時間(PUB_Order_Price. Modified _Time) =now。

            Dim sqlString As String = "update PUB_Order_Price set End_Date=@streffectdate,Dc=@dc ,Modified_User=@struser,Modified_Time=@Modified_Time where Effect_Date=@Effect_Date and Order_Code=@Order_Code and Main_Identity_Id=@Main_Identity_Id"


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With

                If flag = "2" Then '健保
                    command.Parameters.AddWithValue("@streffectdate", CDate(streffectdate).AddDays(-1))
                    If dateflag = False Then
                        command.Parameters.AddWithValue("@Dc", "Y")  '若EXCEL的生效日<Now 前面兩筆要改成 @DC=Y
                    Else
                        command.Parameters.AddWithValue("@Dc", "N")  '若EXCEL的生效日>Now 前面兩筆要改成 @DC=N
                    End If
                Else '自費
                    command.Parameters.AddWithValue("@streffectdate", Now.AddDays(-1))
                    command.Parameters.AddWithValue("@Dc", "Y") 'Now=Now 前面兩筆要改成 @DC=N
                End If
                command.Parameters.AddWithValue("@struser", struser)
                command.Parameters.AddWithValue("@Modified_Time", Now)
                command.Parameters.AddWithValue("@Effect_Date", ds.Tables("Top_1_Effect_date").Rows(0).Item("Effect_Date"))
                command.Parameters.AddWithValue("@Order_Code", ds.Tables("Top_1_Effect_date").Rows(0).Item("Order_Code").ToString.Trim)
                command.Parameters.AddWithValue("@Main_Identity_Id", ds.Tables("Top_1_Effect_date").Rows(0).Item("Main_Identity_Id").ToString.Trim)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 修改目前處理的醫令 "

    ''' <summary>
    '''  修改目前處理的醫令
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function updateordercode(ByVal strDownload_Sn As String, ByVal strImport_Sn As String, ByVal strItem_Non As String, ByVal struser As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            '*********
            Dim sqlString As String = "Update  PUB_Nhi_Code_Import  set Trans_User='" & struser & "', Trans_Time=@Trans_Time , Modified_User='" & struser & "' , Modified_Time=@Modified_Time" & _
                "  where Nhi_Download_Sn='" & strDownload_Sn & "' and Nhi_Import_Sn='" & strImport_Sn & "' and Item_No='" & strItem_Non & "'"

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Trans_Time", Now)
                command.Parameters.AddWithValue("@Modified_Time", Now)

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using
            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
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

