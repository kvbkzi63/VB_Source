Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
'
'
Imports System.Text
Imports System.IO
Imports Syscom.Client.UCL
Imports System
Imports Syscom.Comm.EXP

'============================
'程式說明：報表執行進度查詢
'修改日期：2010.11.02
'開發人員：Barry
'============================
Public Class PubPrintJobQueryUI
    Dim pub As IPubServiceManager = Nothing

    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance '宣告EventManager

    Dim QueryConditionColumn() As String = {"User", "Start_DateTime", "End_DateTime", "System", "Report_Name", "DownloadCheck"}
    Dim QueryConditionColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                                 DataSetUtil.TypeString, DataSetUtil.TypeString}

    ''' <summary>
    ''' 初始化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        Try
            pub = PubServiceManager.getInstance
            tcq_User.Text = currentUserID

            Dim reportType As String = ""
            '系統別
            Dim systemType As DataSet
            systemType = pub.queryPUBPrintJobReportType
            If DataSetUtil.IsContainsData(systemType) Then
                reportType = systemType.Tables(0).Rows(0).Item(0)
                cbo_System.DataSource = systemType.Tables(0)
                cbo_System.uclDisplayIndex = "0"
                cbo_System.uclValueIndex = "0"
            End If
            '報表名稱
            cbo_ReportName.DataSource = pub.queryPUBPrintJobReportByType("", tcq_User.Text).Tables(0) '預設查出所有種類的報表
            cbo_ReportName.uclDisplayIndex = "0"
            cbo_ReportName.uclValueIndex = "0"


            Me.KeyPreview = True '啟用才能觸發快速鍵功能
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try


    End Sub

    '----------------------------------------------------------------------------
    '畫面功能
    '----------------------------------------------------------------------------
    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clear()

        dtp_StartDate.Text = ""
        dtp_EndDate.Text = ""
        txt_StartTime.Text = ""
        txt_EndTime.Text = ""
        cbo_System.Text = ""
        cbo_ReportName.Text = ""
        dgv_data.ClearDS()
    End Sub

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub query()

        'Check()
        '至少要有OrderCode
        '"User", "Start_DateTime", "End_DateTime", "System", "Report_Name"

        Dim QueryConditionDT As DataTable = DataSetUtil.GenDataTable("condition", Nothing, QueryConditionColumn, QueryConditionColumnType)
        Dim conditionDr As DataRow = QueryConditionDT.NewRow

        conditionDr("User") = tcq_User.Text
        If IsDate(dtp_StartDate.GetUsDateStr) Then
            conditionDr("Start_DateTime") = dtp_StartDate.GetUsDateStr
            If txt_StartTime.Text.Trim <> ":" Then
                conditionDr("Start_DateTime") &= " " & txt_StartTime.Text
            End If
        End If

        If IsDate(dtp_EndDate.GetUsDateStr) Then
            conditionDr("End_DateTime") = dtp_EndDate.GetUsDateStr
            If txt_EndTime.Text.Trim <> ":" Then
                conditionDr("End_DateTime") &= " " & txt_EndTime.Text
            End If
        End If

        conditionDr("System") = cbo_System.Text
        conditionDr("Report_Name") = cbo_ReportName.Text
        conditionDr("DownloadCheck") = cb_notYetDownload.Checked


        QueryConditionDT.Rows.Add(conditionDr)

        Dim queryData As DataSet = pub.queryPUBPrintJobByCond(QueryConditionDT)

        'Dim dtGrid As DataTable = DataSetUtil.getInstance.createDataTable("", Nothing, New String() {"訊息", "fid", "jobID", "報表名稱", "處理時間", "結束時間", "狀態", "訊息按鈕", "下載報表", "下載次數"})
        Dim dtGrid As DataTable = DataSetUtil.GenDataTable("", New String() {"訊息", "fid", "jobID", "報表名稱", "處理時間", "結束時間", "狀態", "訊息按鈕", "下載報表", "下載次數"}, Nothing)

        Try
            If Not DataSetUtil.IsContainsData(queryData) Then
                '查無資料
                MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
            Else
                Dim drGrid As DataRow

                For Each e As DataRow In queryData.Tables(0).Rows
                    drGrid = dtGrid.NewRow
                    drGrid("訊息") = e("Process_Msg")
                    drGrid("fid") = e("FID")
                    drGrid("jobID") = e("Job_ID")
                    drGrid("報表名稱") = e("Report_Name")
                    drGrid("處理時間") = getDateFormat(e("Create_Time"))
                    drGrid("結束時間") = getDateFormat(e("Modified_Time"))
                    drGrid("狀態") = e("Status")
                    drGrid("下載次數") = e("Download_Cnt")
                    'drGrid("下載報表") = ""
                    dtGrid.Rows.Add(drGrid)
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Dim data As DataSet = New DataSet
        data.Tables.Add(dtGrid)
        Dim ht As New Hashtable
        Dim btn_cell As New ButtonCell

        btn_cell.Text = "點選"
        ht.Add(-1, data)
        ht.Add(7, btn_cell)
        ht.Add(8, btn_cell)

        'dgv_data.Initial(queryData)
        'dgv_data.Initial(data)
        dgv_data.Initial(ht)
        dgv_data.uclColumnWidth = "0,0,0,390,150,150,60,60,60,60"
        'dgv_data.uclHeaderText = ",,,報表名稱,,,,,處理時間,,,狀態,訊息,匯出報表"
        dgv_data.uclNonVisibleColIndex = "0,1,2"
        dgv_data.uclSortColIndex = "3,4" '"報表名稱", "處理時間"
        dgv_data.Visible = True


    End Sub
    Private Function getDateFormat(ByVal dateString As Object) As String
        If IsDBNull(dateString) Then
            Return ""
        Else
            Return CDate(dateString).ToString("yyyy/MM/dd HH:mm:ss")
        End If
    End Function


#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PubPrintJobQueryUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F12
                'confirm()
            Case Keys.F1
                query()
            Case Keys.F5
                clear()
        End Select
    End Sub

    Private Sub btn_query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click
        query()
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Clear.Click
        clear()
    End Sub

#End Region

    Private Sub PubPrintJobQueryUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        init()
    End Sub

    Private Sub dgv_data_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_data.CellClick
        Dim status As String = dgv_data.GetGridDS.Tables(0).Rows(e.RowIndex)("狀態")
        Dim MyReportName As String = dgv_data.GetGridDS.Tables(0).Rows(e.RowIndex)("報表名稱")

        If e.ColumnIndex = 7 Then '訊息按鈕
            Dim msg As String = StringUtil.nvl(dgv_data.GetGridDS.Tables(0).Rows(e.RowIndex)("訊息"))
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {IIf(msg = "", "沒有訊息", msg)}, "")
            'MessageBox.Show(dgv_data.GetGridDS.Tables(0).Rows(e.RowIndex)("訊息"))
        ElseIf e.ColumnIndex = 8 Then '匯出報表
            If status = "成功" Then
                Dim fid As String = StringUtil.nvl(dgv_data.GetGridDS.Tables(0).Rows(e.RowIndex)("fid"))
                If fid <> "" Then
                    Dim ftm = FtmServiceManager.getInstance
                    '(0) 檔案資料byte() , (1) client端的預設檔名
                    Dim rtn As Object() = ftm.downloadFile(fid, True) '設為true表示,會傳回上傳時所設定的舊檔名
                    If "健保門診處方箋".Equals(MyReportName) Then
                        Dim MyFileName As String = Path.GetFileName(rtn(1))
                        FileTransferTool.convertByteArrayToFile(rtn(0), MyFileName)

                        Dim MyContent As String = ReadFile(MyFileName)
                        Dim fileObj As FileInfo
                        fileObj = New IO.FileInfo(MyFileName)
                        fileObj.Delete()


                        WriteFile(MyContent, System.Text.Encoding.Unicode, MyFileName)

                        Dim fileObj_1 As FileInfo
                        fileObj_1 = New IO.FileInfo(MyFileName)
                        PrintTxtFile(fileObj, "")

                    Else
                        'Dim fileInfo As FileInfo = New FileInfo(rtn(1))
                        Dim sFileDialog As New SaveFileDialog
                        'sFileDialog.Filter = "EXCEL檔 (*.xls)|*.xls" ' 只能寫入EXCEL檔
                        sFileDialog.Filter = Path.GetExtension(rtn(1)) + "|*" + Path.GetExtension(rtn(1)) '設定存檔類型
                        sFileDialog.FilterIndex = 1
                        sFileDialog.RestoreDirectory = True
                        sFileDialog.OverwritePrompt = True '當檔案已經存在時是否要顯示警告訊息
                        'sFileDialog.FileName = FileIO.FileSystem.GetName(rtn(1))
                        sFileDialog.FileName = Path.GetFileName(rtn(1)) '預設的檔名
                        sFileDialog.DefaultExt = Path.GetExtension(rtn(1)) '預設的副檔名,當使用者沒設定副檔名時,與社會被加在檔名後面
                        'Threading.Thread.CurrentThread.SetApartmentState(Threading.ApartmentState.STA)
                        If sFileDialog.ShowDialog() = DialogResult.OK Then
                            Dim fileName As String = sFileDialog.FileName
                            ' fileName就是我們要儲存檔案的路徑(含檔案名稱)
                            ' 透過我們自已寫的SaveAsExcelFile寫檔method
                            ' 將檔案寫到fileName這個路徑下
                            Dim openUCLWaitingFormUI = New UCLWaitingFormUI
                            openUCLWaitingFormUI.Text = "資料匯出中..."
                            openUCLWaitingFormUI.Show()

                            '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
                            FileTransferTool.convertByteArrayToFile(rtn(0), fileName)

                            openUCLWaitingFormUI.Dispose()
                            MessageHandling.ShowInfoMsg("CMMCMMB114", New String() {sFileDialog.FileName})
                            '更新下載次數
                            pub.increaseDownloadCnt(dgv_data.GetGridDS.Tables(0).Rows(e.RowIndex)("jobID"))
                        End If
                    End If


                Else
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"FID為空白,無法下載!!"}, "")
                End If
            Else
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"此報表尚未執行成功無法下載!!"}, "")
            End If

        End If
    End Sub
    ''' <summary>
    ''' 當選擇的報表型態改變,報表的名稱也要跟著變
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbo_System_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_System.SelectedIndexChanged
        reloadReportName()
    End Sub
    ''' <summary>
    ''' 當Combo Box的文字欄位被修改時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tcq_User_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcq_User.TextChanged
        reloadReportName()
    End Sub
    Private Sub reloadReportName()
        cbo_ReportName.DataSource = Nothing
        cbo_ReportName.DataSource = pub.queryPUBPrintJobReportByType(cbo_System.Text, tcq_User.Text).Tables(0)
        cbo_ReportName.uclDisplayIndex = "0"
        cbo_ReportName.uclValueIndex = "0"
    End Sub

    <STAThread()> _
    Public Shared Sub main()
        Application.Run(New PubPrintJobQueryUI())
    End Sub


#Region "    其他功能"

    ''' <summary>
    ''' 列印檔案
    ''' </summary>
    ''' <param name="rpt">列印物件</param>
    ''' <param name="printType">列印方式</param>
    ''' <remarks>
    ''' -p:直接列印
    ''' default是預覽列印
    ''' </remarks>
    Protected Sub PrintTxtFile(ByRef rpt As Object, ByRef printType As String)
        'Dim process As System.Diagnostics.Process
        Try
            Using process = New Process
                Dim fullFileName As String = CType(rpt, FileInfo).FullName
                process.Start(My.Application.Info.DirectoryPath & "\TxtPrint\TxtPreview.exe", printType & " " & fullFileName)
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            'If (process IsNot Nothing) Then
            '    process.Close()
            '    process.Dispose()
            'End If
        End Try
    End Sub


    Private Function ReadFile(ByVal FileName As String) As String
        Try
            Dim RtnStr As New StringBuilder

            'Dim MyFileInfo As FileInfo = New FileInfo(FileName)
            'Dim fs As FileStream
            'fs = MyFileInfo.OpenRead
            'Dim b(1024) As Byte
            Dim S As Stream = File.OpenRead(FileName)
            Dim srANSI As StreamReader = New StreamReader(S, Encoding.Default)

            'Dim sr As StreamReader = File.OpenText(FileName)


            Do While srANSI.Peek >= 0

                RtnStr.AppendLine(srANSI.ReadLine)
            Loop
            srANSI.Close()

            Return RtnStr.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 寫入 Rtf File
    ''' </summary>
    ''' <param name="reportData">寫入檔案的資料</param>
    ''' <returns>FileInfo</returns>
    ''' <remarks></remarks>
    Private Function WriteFile(ByRef reportData As String, ByRef txtEncode As Encoding, ByVal FileName As String) As FileInfo
        Try
            'log.Debug("Write File Current Encode = " & txtEncode.WebName)
            Dim fileObj As FileInfo
            Dim defaultTxtDirectoryPath As String = My.Application.Info.DirectoryPath & "\txtReport\"
            Dim fullFileName As String = FileName 'New StringBuilder().Append(defaultTxtDirectoryPath).Append(reportId).Append("-").Append(getRandom).Append(Now.ToString("-yyyyMMdd-HHmmssfffff")).Append(fileExtension).ToString

            fileObj = New IO.FileInfo(fullFileName)

            '假如沒有資料夾，先建立資料夾
            If (Not fileObj.Directory.Exists) Then
                fileObj.Directory.Create()
            End If

            Dim objStream As System.IO.StreamWriter = New System.IO.StreamWriter(fileObj.OpenWrite, txtEncode)

            objStream.WriteLine(reportData)

            objStream.Flush()
            objStream.Close()
            objStream.Dispose()

            Return fileObj
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

End Class