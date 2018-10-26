Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text
Imports System.Transactions


Public Class PUBPatientSevereDiseaseBO_E1
    Inherits PubPatientSevereDiseaseBO



#Region "########## getInstance ##########"

    Private Shared instance As PUBPatientSevereDiseaseBO_E1

    Public Overloads Shared Function getInstance() As PUBPatientSevereDiseaseBO_E1
        If instance Is Nothing Then
            instance = New PUBPatientSevereDiseaseBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region


    Function queryPubPatientSevereDiseaseByKey(ByVal chartNo As String) As DataSet
        Try
            Using conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim Content As New StringBuilder

                Content.AppendLine(" 									SELECT A.Chart_No")
                Content.AppendLine("										  , Case When B.Icd_Code is not null then B.Icd_Code ")
                Content.AppendLine("										         When C.Icd_Code is not null then C.Icd_Code End Icd_Code")
                Content.AppendLine("										  , A.Effect_Date")
                Content.AppendLine("										  , A.Certificate_Sn")
                Content.AppendLine("										  , A.End_Date ")
                Content.AppendLine("                                          ,A.Create_User")
                Content.AppendLine("										  , A.Create_Time ")
                Content.AppendLine("                                          ,Case When B.Disease_En_Name is not null Then B.Disease_En_Name Else C.Disease_En_Name End as Disease_En_Name ")
                Content.AppendLine("                                          ,Case When B.Disease_Name is not null Then B.Disease_Name Else C.Disease_Name End as Disease_Name ")
                Content.AppendLine("                                     FROM PUB_Patient_Severe_Disease A WITH(NOLOCK) ")
                Content.AppendLine("                                Left JOIN PUB_Disease B WITH(NOLOCK) ON (A.Icd_Code = B.Icd_Code or A.Icd_Code = B.Icd_Code_Nodot)")
                Content.AppendLine("												  AND B.Disease_Type_Id = '1' ")
                Content.AppendLine("												  AND (((B.End_Date Is NOT NULL) ")
                Content.AppendLine("												  AND (B.End_Date >= A.Effect_Date)) OR (B.End_Date is null)) ")
                Content.AppendLine("												  AND B.DC = 'N' ")
                Content.AppendLine("                                Left JOIN PUB_Disease_ICD10 C WITH(NOLOCK) ON (A.Icd_Code = C.Icd_Code or A.Icd_Code = C.Icd_Code_Nodot)")
                Content.AppendLine("												  AND C.Disease_Type_Id = '1' ")
                Content.AppendLine("												  AND (((C.End_Date Is NOT NULL) ")
                Content.AppendLine("												  AND (C.End_Date >= A.Effect_Date)) OR (C.End_Date is null)) ")
                Content.AppendLine("												  AND C.DC = 'N' ")
                Content.AppendLine("                                                WHERE A.Chart_No=@Chart_No  ")
                Content.AppendLine(" 										          And @Now < A.End_Date ")
                Content.AppendLine("                                             ORDER BY End_Date ")
                'Content.AppendLine("									SELECT A.Chart_No, A.Icd_Code, A.Effect_Date, A.Certificate_Sn, A.End_Date")
                'Content.AppendLine("                                              , A.Create_User, A.Create_Time")
                'Content.AppendLine("											  ,Case When B.Disease_En_Name is not null Then B.Disease_En_Name Else C.Disease_En_Name End as Disease_En_Name")
                'Content.AppendLine("											  ,Case When B.Disease_Name is not null Then B.Disease_Name Else C.Disease_Name End as Disease_Name")
                'Content.AppendLine("                                           FROM PUB_Patient_Severe_Disease A WITH(NOLOCK)")
                'Content.AppendLine("                                          Left JOIN PUB_Disease B WITH(NOLOCK) ON A.Icd_Code = B.Icd_Code")
                'Content.AppendLine("                                                                                 AND B.Disease_Type_Id = '1'")
                'Content.AppendLine("                                                                                AND (((B.End_Date Is NOT NULL)")
                'Content.AppendLine("                                                                                 AND (B.End_Date >= A.Effect_Date)) OR (B.End_Date is null))")
                'Content.AppendLine("                                                                                AND B.DC = 'N'")
                'Content.AppendLine("                                          Left JOIN PUB_Disease_ICD10 C WITH(NOLOCK) ON A.Icd_Code = C.Icd_Code")
                'Content.AppendLine("                                                                                 AND C.Disease_Type_Id = '1'")
                'Content.AppendLine("                                                                                AND (((C.End_Date Is NOT NULL)")
                'Content.AppendLine("                                                                                 AND (C.End_Date >= A.Effect_Date)) OR (C.End_Date is null))")
                'Content.AppendLine("                                                                                AND C.DC = 'N'")
                'Content.AppendLine("                                           WHERE A.Chart_No=@Chart_No ")
                'Content.AppendLine("										     And @Now < A.End_Date")
                'Content.AppendLine("                                        ORDER BY End_Date")
                'Content.AppendLine("")

                Using command As SqlCommand = conn.CreateCommand
                    command.CommandText = Content.ToString

                    command.Parameters.AddWithValue("@Chart_No", chartNo)
                    command.Parameters.AddWithValue("@Now", Now().ToString("yyyy/M/d H:m:s"))

                    Using da As SqlDataAdapter = New SqlDataAdapter(command)
                        Using ds As DataSet = New DataSet("resultDB")
                            da.FillSchema(ds, SchemaType.Source, "resulttable")
                            da.Fill(ds.Tables("resulttable"))
                            Return ds
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As SqlClient.SqlException

            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 程式說明：取得重大傷病的Icd_Code、證明文號、起迄日
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.04
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <param name="OpdVisitDate">看診日期</param>
    ''' <param name="IcdCodeDT">診斷檔的前3個診斷的Icd_Code、證明文號、起迄日</param>
    ''' <returns>Icd_Code</returns>
    ''' <remarks>For OPC收退費用</remarks>
    Friend Function getIcdCodeForReceiptUI(ByVal ChartNo As String, ByVal OpdVisitDate As String, ByVal IcdCodeDT As DataTable) As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select")
        cmdStr.AppendLine("A.Icd_Code,")
        cmdStr.AppendLine("A.Certificate_Sn,")
        cmdStr.AppendLine("A.Effect_Date,")
        cmdStr.AppendLine("A.End_Date")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from PUB_Patient_Severe_Disease as A")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where 1=1")
        'cmdStr.AppendLine("and A.Chart_No = @Chart_No")
        Dim tempChartNo() As String = ChartNo.Split(New Char() {","})
        If tempChartNo.Length.Equals(1) Then
            ChartNo = "'" & ChartNo & "'"
        End If
        cmdStr.AppendLine("and A.Chart_No in (" & ChartNo & ")")

        cmdStr.AppendLine("and A.Effect_Date <= @Opd_Visit_Date and A.End_Date >= @Opd_Visit_Date")
        '如果IcdCodeDT無資料，則回傳空的資料表
        Dim icdCodeSql As String = ""
        If DataSetUtil.IsContainsData(IcdCodeDT) Then
            For Each row As DataRow In IcdCodeDT.Rows
                Dim tempStr As String = StringUtil.nvl(row(0))

                If tempStr.Length > 0 Then
                    If Not icdCodeSql.Equals("") Then
                        icdCodeSql += " or "
                    End If
                    icdCodeSql += "'" & tempStr & "' like ''+ltrim(rtrim(A.icd_code))+'%'"
                End If
            Next
            If icdCodeSql.Length > 0 Then
                icdCodeSql = "and (" + icdCodeSql + ")"
            Else
                icdCodeSql = "and 1<>1"
            End If
        Else
            icdCodeSql = "and 1<>1"
        End If
        cmdStr.AppendLine(icdCodeSql)
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        'sqlCmd.Parameters.AddWithValue("@Chart_No", ChartNo)
                        sqlCmd.Parameters.AddWithValue("@Opd_Visit_Date", OpdVisitDate)

                    End With

                    conn.Open()

                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        Using dt As DataTable = New DataTable("icdCodeDataDT")

                            da.Fill(dt)

                            Return dt
                        End Using
                    End Using

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' 程式說明：重新寫入IC卡重大傷病資料
    ''' 開發人員：Alan
    ''' 開發日期：2009.12.10   
    Public Function updatePubPatientSevereDiseaseByChartNo(ByVal UserID As String, ByVal ChartNo As String, ByVal iData As DataSet) As Integer

        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
        Dim SqlCmd As SqlCommand

        Try

            Dim cmdStr1 As String = ""

            '刪除IC卡重大傷病資料
            'cmdStr1 = "Delete From PUB_Patient_Severe_Disease " & _
            '          "Where Chart_No='" & ChartNo & "' And " & _
            '          "      ( Certificate_Sn='' OR Certificate_Sn is Null ) "
            conn.Open()
            'SqlCmd = New SqlCommand(cmdStr1, conn)
            'SqlCmd.ExecuteNonQuery()

            '重新寫入IC卡重大傷病資料
            Dim pvtICDCode As String
            Dim pvtEffectDate As String
            Dim pvtEndDate As String
            Dim pvtSysTime As String
            Dim pvtServereDiseaseData As DataSet

            pvtSysTime = Now().ToString("yyyy/M/d H:m:s")

            For i = 0 To iData.Tables(0).Rows.Count - 1

                pvtICDCode = iData.Tables(0).Rows(i).Item("ILLNESS_ID").ToString.Trim
                pvtEffectDate = iData.Tables(0).Rows(i).Item("EXPIRED_START_DATE").ToString.Trim
                pvtEndDate = iData.Tables(0).Rows(i).Item("EXPIRED_END_DATE").ToString.Trim

                If pvtICDCode.Length > 3 AndAlso Not pvtICDCode.Contains(".") Then
                    pvtICDCode = pvtICDCode.Trim.Substring(0, 3) & "." & pvtICDCode.Trim.Substring(3, pvtICDCode.Length - 3)
                End If


                If pvtICDCode <> "" Then
                    pvtEffectDate = CStr(CInt(pvtEffectDate.Substring(0, 3)) + 1911) & _
                                    "/" & pvtEffectDate.Substring(3, 2) & "/" & pvtEffectDate.Substring(5, 2)

                    pvtEndDate = CStr(CInt(pvtEndDate.Substring(0, 3)) + 1911) & _
                                    "/" & pvtEndDate.Substring(3, 2) & "/" & pvtEndDate.Substring(5, 2)

                    '先判斷是否存在=>不存在則新增，存在則更新End_Date

                    pvtServereDiseaseData = getSevereDiseaseData(ChartNo, pvtICDCode, pvtEffectDate)

                    If pvtServereDiseaseData IsNot Nothing AndAlso pvtServereDiseaseData.Tables(0) IsNot Nothing AndAlso _
                       pvtServereDiseaseData.Tables(0).Rows.Count > 0 Then
                        cmdStr1 = "Update PUB_Patient_Severe_Disease " & _
                                  "Set End_Date='" & pvtEndDate & "' " & _
                                  "Where Chart_No='" & ChartNo & "' And Icd_Code='" & pvtICDCode & "' And " & _
                                  "      Effect_Date='" & pvtEffectDate & "'"
                    Else
                        cmdStr1 = "Insert into PUB_Patient_Severe_Disease " & _
                                  "(Chart_No,Icd_Code,Effect_Date,Certificate_Sn,End_Date,Create_User,Create_Time,Is_From_IcCard) " & _
                                  "Values " & _
                                  "('" & ChartNo & "','" & pvtICDCode & "','" & _
                                  pvtEffectDate & "','','" & pvtEndDate & "','" & UserID & "','" & pvtSysTime & "','Y' )"
                    End If

                    SqlCmd = New SqlCommand(cmdStr1, conn)
                    SqlCmd.ExecuteNonQuery()

                End If
            Next


        Catch ex As SqlClient.SqlException

            Throw ex
            Return 0
        Finally
            conn.Close()
            conn.Dispose()
        End Try

        Return 1

    End Function

    Public Function getSevereDiseaseData(ByVal ChartNo As String, ByVal pvtICDCode As String, ByVal pvtEffectDate As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select * From PUB_Patient_Severe_Disease " & _
                                  "Where Chart_No='" & ChartNo & "' And Icd_Code='" & pvtICDCode & "' And " & _
                                  "      Effect_Date='" & pvtEffectDate & "'"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Patient_Severe_Disease")
                adapter.Fill(ds, "PUB_Patient_Severe_Disease")
                adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Patient_Severe_Disease")
            End Using

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢重大傷病資料 (For Web Service用)
    ''' </summary>
    ''' <param name="InputXml">欲查詢之條件 (XML)</param>
    ''' <returns>查詢之結果 (XML)</returns>
    ''' <author>Ken</author>
    ''' <date>2010-07-22</date>
    ''' <remarks></remarks>
    Public Function GetPubPatientServerDisease(ByVal InputXml As String) As String

        Dim _xmlReader As System.Xml.XmlReader = System.Xml.XmlReader.Create(New System.IO.StringReader(InputXml))
        Dim _xDoc = System.Xml.Linq.XDocument.Load(_xmlReader)
        Dim _records = From o In _xDoc.Root.Elements("PUB_Patient_Severe_Disease") _
                       Select New With {.Chart_No = o.Elements("Chart_No").Value}

        Dim ChartNo As String = _records.First.Chart_No

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(A.Icd_Code)       AS Icd_Code, " & vbCrLf)
        var1.Append("       RTRIM(A.Certificate_Sn) AS Certificate_Sn, " & vbCrLf)
        var1.Append("       A.Effect_Date, " & vbCrLf)
        var1.Append("       A.End_Date, " & vbCrLf)
        var1.Append("       RTRIM(A.Is_From_Iccard) AS Is_From_Iccard, " & vbCrLf)
        var1.Append("       RTRIM(A.Create_User)    AS Create_User, " & vbCrLf)
        var1.Append("       A.Create_Time " & vbCrLf)
        var1.Append("FROM   PUB_Patient_Severe_Disease AS A " & vbCrLf)
        var1.Append("WHERE  A.Chart_No = @Chart_No " & vbCrLf)
        var1.Append("       AND A.End_Date >= @Now " & vbCrLf)

        Dim _dsX As New DataSet
        Dim ds As New System.Data.DataSet("SendPack")

        Try
            Using _sqlConnection As SqlConnection = getConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Chart_No", ChartNo)
                _command.Parameters.AddWithValue("@Now", Now.Date)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_dsX, "PUB_Patient_Severe_Disease")

                ds.Tables.Add("Information")
                ds.Tables("Information").Columns.Add("SendDate")
                ds.Tables("Information").Columns.Add("SubSystem")
                ds.Tables("Information").Columns.Add("Function")
                ds.Tables("Information").Columns.Add("User")
                ds.Tables("Information").Rows.Add(New Object() {Now.ToString("yyyy-MM-dd HH:mm:ss"), "OMO", "GetPatientServerDisease", "外部程式呼叫"})

                ds.Tables.Add("ReturnResult")
                ds.Tables("ReturnResult").Columns.Add("Result")
                ds.Tables("ReturnResult").Columns.Add("Message")
                ds.Tables("ReturnResult").Rows.Add(New Object() {"0", "執行成功"})

                ds.Tables.Add(_dsX.Tables("PUB_Patient_Severe_Disease").Copy)
            End Using
        Catch ex As Exception

            ds.Tables.Add("Information")
            ds.Tables("Information").Columns.Add("SendDate")
            ds.Tables("Information").Columns.Add("SubSystem")
            ds.Tables("Information").Columns.Add("Function")
            ds.Tables("Information").Columns.Add("User")
            ds.Tables("Information").Rows.Add(New Object() {Now.ToString("yyyy-MM-dd HH:mm:ss"), "OMO", "GetPatientServerDisease", "外部程式呼叫"})
            ds.Tables.Add("ReturnResult")
            ds.Tables("ReturnResult").Columns.Add("Result")
            ds.Tables("ReturnResult").Columns.Add("Message")
            ds.Tables("ReturnResult").Rows.Add(New Object() {"-1", ex.Message})
        End Try

        Return ds.GetXml
    End Function

    ''' <summary>
    ''' 更新重大傷病資料 (For Web Service用)
    ''' </summary>
    ''' <param name="InputXml">欲更新之資料 (XML)</param>
    ''' <returns>更新之結果 (XML)</returns>
    ''' <author>Ken</author>
    ''' <date>2010-07-22</date>
    ''' <remarks></remarks>
    Public Function UpdatePubPatientServerDisease(ByVal InputXml As String) As String

        Dim _xmlReader As System.Xml.XmlReader = System.Xml.XmlReader.Create(New System.IO.StringReader(InputXml))

        Dim _xDoc = XDocument.Load(_xmlReader)

        Dim _now As Date = Now

        Dim _records = From o In _xDoc.Root.Elements("PUB_Patient_Severe_Disease") _
                       Select New With {.Chart_No = o.Elements("Chart_No").Value, _
                                        .Icd_Code = o.Element("Icd_Code").Value, _
                                        .Effect_Date = CDate(o.Element("Effect_Date").Value).Date, _
                                        .Certificate_Sn = o.Element("Certificate_Sn").Value, _
                                        .End_Date = o.Element("End_Date").Value.Trim, _
                                        .Is_From_Iccard = o.Element("Is_From_Iccard").Value}

        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Patient_Severe_Disease " & vbCrLf)
        var1.Append("SET    Certificate_Sn = @Certificate_Sn, " & vbCrLf)
        var1.Append("       End_Date = @End_Date, " & vbCrLf)
        var1.Append("       Is_From_Iccard = @Is_From_Iccard " & vbCrLf)
        var1.Append("WHERE  Chart_No = @Chart_No " & vbCrLf)
        var1.Append("       AND Icd_Code = @Icd_Code " & vbCrLf)
        var1.Append("       AND Effect_Date = @Effect_Date " & vbCrLf)

        '========================================================================
        Dim _cnt As Int32 = 0

        Using _trans As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

            Using _sqlConnection As SqlConnection = Me.getConnection

                _sqlConnection.Open()

                Try
                    For Each _record In _records

                        Dim _tmpCnt As Int32 = 0
                        Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                        _command.CommandType = CommandType.Text
                        _command.Parameters.AddWithValue("@Chart_No", _record.Chart_No)
                        _command.Parameters.AddWithValue("@Icd_Code", _record.Icd_Code)
                        _command.Parameters.AddWithValue("@Effect_Date", _record.Effect_Date)
                        _command.Parameters.AddWithValue("@Certificate_Sn", _record.Certificate_Sn)
                        If _record.End_Date = String.Empty Then
                            _command.Parameters.AddWithValue("@End_Date", DBNull.Value)
                        Else
                            _command.Parameters.AddWithValue("@End_Date", Date.Parse(_record.End_Date))
                        End If
                        _command.Parameters.AddWithValue("@Is_From_Iccard", _record.Is_From_Iccard)

                        _tmpCnt += _command.ExecuteNonQuery()

                        _cnt += _tmpCnt
                        If _tmpCnt = 0 Then
                            '若無可更新之資料，則新增
                            Dim _newDs As New DataSet
                            Dim _newDt As DataTable = PubPatientSevereDiseaseDataTableFactory.getDataTableWithSchema
                            Dim _newDr As DataRow = _newDt.NewRow
                            _newDr("Chart_No") = _record.Chart_No
                            _newDr("Icd_Code") = _record.Icd_Code
                            _newDr("Effect_Date") = _record.Effect_Date
                            _newDr("Certificate_Sn") = _record.Certificate_Sn
                            If _record.End_Date <> String.Empty Then
                                _newDr("End_Date") = Date.Parse(_record.End_Date)
                            End If
                            _newDr("Is_From_Iccard") = _record.Is_From_Iccard
                            _newDr("Create_User") = "WebService"
                            _newDr("Create_Time") = _now
                            _newDt.Rows.Add(_newDr)
                            _newDs.Tables.Add(_newDt)
                            _cnt += PUBPatientSevereDiseaseBO_E1.instance.insertBySetCreateTime(_newDs, _sqlConnection)
                        End If
                    Next

                    _trans.Complete()

                Catch ex As Exception

                    Dim ds As New System.Data.DataSet("SendPack")
                    ds.Tables.Add("Information")
                    ds.Tables("Information").Columns.Add("SendDate")
                    ds.Tables("Information").Columns.Add("SubSystem")
                    ds.Tables("Information").Columns.Add("Function")
                    ds.Tables("Information").Columns.Add("User")
                    ds.Tables("Information").Rows.Add(New Object() {Now.ToString("yyyy-MM-dd HH:mm:ss"), "OMO", "UpdatePatientServerDisease", "外部程式呼叫"})
                    ds.Tables.Add("ReturnResult")
                    ds.Tables("ReturnResult").Columns.Add("Result")
                    ds.Tables("ReturnResult").Columns.Add("Message")
                    ds.Tables("ReturnResult").Rows.Add(New Object() {"-1", ex.Message})
                    Return ds.GetXml
                End Try
            End Using
        End Using

        Dim _dsX As DataSet = New System.Data.DataSet("SendPack")
        _dsX.Tables.Add("Information")
        _dsX.Tables("Information").Columns.Add("SendDate")
        _dsX.Tables("Information").Columns.Add("SubSystem")
        _dsX.Tables("Information").Columns.Add("Function")
        _dsX.Tables("Information").Columns.Add("User")
        _dsX.Tables("Information").Rows.Add(New Object() {Now.ToString("yyyy-MM-dd HH:mm:ss"), "OMO", "UpdatePatientServerDisease", "外部程式呼叫"})
        _dsX.Tables.Add("ReturnResult")
        _dsX.Tables("ReturnResult").Columns.Add("Result")
        _dsX.Tables("ReturnResult").Columns.Add("Message")
        _dsX.Tables("ReturnResult").Rows.Add(New Object() {"0", String.Format("資料庫更新完成，筆數：{0} 筆", _cnt)})
        Return _dsX.GetXml
    End Function
End Class
