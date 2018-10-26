Imports System.Data
Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression
Imports System.IO.Compression.ZipFile
Imports System.Net
Imports System.Net.Mail
Imports System.ServiceModel
Imports System.Text
Imports System.Windows.Forms
Imports JOBClientServiceFactory
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports Syscom.Client.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Client.Servicefactory

Public Class JobPGSubmitUI
    Inherits Syscom.Client.UCL.BaseFormUI

#Region "     變數宣告"
    Dim WithEvents eventMgr As EventManager

    Dim FolderPath As String = ""
    Dim Sender As String = "Will_Lin@syscom.com.tw"
    Dim MainReceiver As String = ""
    Dim CCUser As String = ""
    Dim FTPFolder As Data.DataTable = Nothing
    Dim JOBCode As String = ""
    Dim IsSubmit As Boolean = False

    Private m_FileName As String = ""

    Public Property FileName As String
        Get
            Return m_FileName
        End Get
        Set(value As String)
            m_FileName = value
        End Set
    End Property
#End Region

#Region "     初始化"

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Job As IJOBServiceManager

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-04-19</remarks>
    Private Sub LoadServiceManager()

        Try

            Job = JOBServiceManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try


    End Sub

#End Region

#Region "     載入事件管理員(EventManager) "

    ''' <summary>
    ''' 載入EventManager的Instance
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-4-19</remarks>
    Private Sub LoadEventManager()

        Try

            eventMgr = EventManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB992", ex)
        End Try

    End Sub

#End Region

#Region "     關閉事件管理員(EventManager) "

    ''' <summary>
    ''' 關閉事件管理員(EventManager)
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-04-19</remarks>
    Private Sub UIDisposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        Try

            eventMgr = Nothing

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB993", ex)
        End Try

    End Sub

#End Region


#End Region

#Region "     事件處理"

#Region "覆寫事件"

    Public Overloads Function ShowDialog() As Boolean

        MyBase.ShowDialog()

        Try
            Return IsSubmit
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "dgv事件"

    Public Sub New()

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。
        ResetFolderCombobox()

        LoadServiceManager()
    End Sub


    Public Sub New(ByVal dr As DataRow)

        ' 設計工具需要此呼叫。
        InitializeComponent()

        JOBCode = dr("JOB_Code")
        txt_System.Text = dr("System_Code")
        txt_PGName.Text = AppContext.userProfile.userName
        dtp_AssignDate.SetValue(dr("Assign_Date"))
        Dim cboDS As DataSet = PubServiceManager.getInstance.queryPUBSysCode("9999")
        txt_Ver.Text = Syscom.Comm.Utility.StringUtil.appendCharToLeft(dr("Seq_No"), Convert.ToChar("0"), 2)
        cbo_Classify.DataSource = cboDS.Tables(0).Copy
        cbo_Classify.uclDisplayIndex = "1"
        cbo_Classify.uclValueIndex = "0"
        cbo_Classify.SelectedValue = dr("Issue_Classify")

        txt_Function.Text = dr("Function_Name")
        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。
        ResetFolderCombobox()

        LoadServiceManager()
    End Sub





    Private Sub dgv_Excel_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Excel.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Try
            If e.ColumnIndex = 0 Then
                dgv_Excel.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Not dgv_Excel.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_Path_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Try
            If e.ColumnIndex = 0 Then
                dgv_Path.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Not dgv_Path.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_FTPAddress_TextChanged(sender As Object, e As EventArgs) Handles txt_FTPAddress.TextChanged

        Try
            If txt_FTPAddress.Text.Length > 0 AndAlso txt_FTPLoginUser.Text.Length > 0 AndAlso txt_FTPLoginPassWord.Text.Length > 0 Then
                ResetFolderCombobox()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "按鈕事件"

    Private Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        Try
            Lock(Me)

            IsSubmit = False
            If txt_Folder.Text = "" Then Exit Sub

            If cbk_UploadFTP.Checked Then
                If dgv_Path.Rows.Count = 0 Then Exit Sub
                If dgv_Excel.Rows.Count = 0 Then Exit Sub
            End If
            If cbk_UploadFTP.Checked Then

                FolderPath = txt_Folder.Text & "\" & Now.ToString("yyyyMMdd") & txt_Ver.Text & "(" & txt_System.Text & ")" & "-正式機上版申請(" & txt_PGName.Text & ")"

                For i As Int32 = 0 To dgv_Path.Rows.Count - 1
                    Dim FileName As String = dgv_Path.Rows(i).Cells("FilePath").Value.ToString.Split("\")(dgv_Path.Rows(i).Cells("FilePath").Value.ToString.Split("\").Length - 1)
                    Dim path As String = FolderPath
                    Dim pathArr As String() = dgv_Path.Rows(i).Cells("FilePath").Value.ToString.Split("\")

                    Dim startIndex As Int32 = 0
                    For x As Int32 = 0 To pathArr.Length - 1
                        If pathArr(x).Contains("Developer") Then
                            startIndex = x + 1
                            Exit For
                        End If
                    Next
                    For y As Int32 = startIndex To pathArr.Length - 2
                        path = path & "\" & pathArr(y)
                    Next

                    Dim dir As New DirectoryInfo(path)
                    If dir.Exists = False Then
                        dir.Create()
                    End If
                    System.IO.File.Copy(dgv_Path.Rows(i).Cells("FilePath").Value.ToString, path & "\" & pathArr(pathArr.Length - 1), True)
                Next
                CreateExcelFile()
                UploadToFTP()
            End If

            MessageBox.Show("上傳成功")
            ClearAll()
            IsSubmit = True
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"PG工作清單"})
        Finally
            UnLock(Me)
            Me.Close()
        End Try

    End Sub

    Private Sub btn_Folder_Click(sender As Object, e As EventArgs) Handles btn_Folder.Click

        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            txt_Folder.Text = FolderBrowserDialog1.SelectedPath
        End If


    End Sub

    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click

        Delete_dgv_Excel()
        Delete_dgv_Path()

    End Sub

    Private Sub Delete_dgv_Excel()
        If dgv_Excel.Rows.Count <= 0 Then Exit Sub
        Dim selectRow As New Collections.Generic.List(Of DataGridViewRow)


        For i As Int32 = 0 To dgv_Excel.Rows.Count - 1
            If dgv_Excel.Rows(i).Cells(0).Value Then
                selectRow.Add(dgv_Excel.Rows(i))
            End If
        Next

        For Each dr As DataGridViewRow In selectRow
            dgv_Excel.Rows.Remove(dr)
        Next

        btn_Upload.Enabled = EnableUpload()
    End Sub

    Private Sub Delete_dgv_Path()
        If dgv_Path.Rows.Count <= 0 Then Exit Sub
        Dim selectRow As New Collections.Generic.List(Of DataGridViewRow)


        For i As Int32 = 0 To dgv_Path.Rows.Count - 1
            If dgv_Path.Rows(i).Cells(0).Value Then
                selectRow.Add(dgv_Path.Rows(i))
            End If
        Next

        For Each dr As DataGridViewRow In selectRow
            dgv_Path.Rows.Remove(dr)
        Next

        btn_Upload.Enabled = EnableUpload()
    End Sub

    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        Me.SelectFile.Filter = "All files (*.*)|*.*"
        If Me.SelectFile.ShowDialog() = DialogResult.OK Then
            Dim filePaths As String() = SelectFile.FileNames
            For Each s As String In filePaths
                If CheckPathIsExist(s, dgv_Path) Then
                    dgv_Path.Rows.Add(False, s)
                End If
            Next
            btn_Upload.Enabled = EnableUpload()
        End If
    End Sub

    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        Try

            If CheckInput() Then
                Exit Sub
            Else
                dgv_Excel.Rows.Add(False, txt_System.Text, dtp_AssignDate.GetUsDateStr, txt_Function.Text, cbo_Classify.Text, txt_Level.Text, rtb_desc.Text)
            End If

            btn_Upload.Enabled = EnableUpload()

        Catch ex As Exception


        End Try
    End Sub

    Private Sub btn_DeleteIssue_Click(sender As Object, e As EventArgs)
        If dgv_Excel.Rows.Count <= 0 Then Exit Sub
        Dim selectRow As New Collections.Generic.List(Of DataGridViewRow)
        For i As Int32 = 0 To dgv_Excel.Rows.Count - 1
            If dgv_Excel.Rows(i).Cells(0).Value Then
                selectRow.Add(dgv_Excel.Rows(i))
            End If
        Next

        For Each dr As DataGridViewRow In selectRow
            dgv_Excel.Rows.Remove(dr)
        Next

        btn_Upload.Enabled = EnableUpload()

    End Sub

    Public Sub SetFilePath(ByVal drList As System.Data.DataRow())
        Try
            If drList.Length = 0 Then Exit Sub
            For Each dr As DataRow In drList
                If CheckPathIsExist(dr("Layer_Code_Id").ToString.Trim, dgv_Path) Then
                    dgv_Path.Rows.Add(False, dr("Layer_Code_Id").ToString.Trim)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

#End Region

#Region "     內部函數"

#Region "產生EXCEL"


    Dim objApp As Excel.Application
    Dim objWB As Workbook
    Dim objWS As Worksheet


    Private Sub CreateExcelFile()
        Try
            Dim headList As String(,) = {{"系統別", "16", "20"},
                                    {"提出日", "16", "20"}, {"歸屬功能", "16", "20"}, {"問題類別", "16", "20"}, {"優先等級", "16", "20"}, {"問題描述", "16", "100"}, {"測試圖片", "16", "100"}
                                    }
            ' Connect to excel
            objApp = New Excel.Application
            ' Create a new workbook
            objWB = objApp.Workbooks.Add()
            ' Create a new worksheet
            objWS = objWB.ActiveSheet()
            objWS.Name = "版更說明"
            Dim rowindex As Int32 = 1

            Dim strTemplatePath As String = FolderPath & "\" & Now.ToString("yyyyMMdd") & txt_Ver.Text & "(" & txt_System.Text & ")" & "-正式機上版申請(" & txt_PGName.Text & ").xlsx"
            objWB.SaveAs(strTemplatePath)
            ''印出標題
            For i As Int32 = 0 To headList.GetUpperBound(0)
                objWS.Cells(rowindex, i + 1) = headList(i, 0)
                objWS.Cells(rowindex, i + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                objWS.Cells(rowindex, i + 1).ColumnWidth = headList(i, 2)

                objWS.Cells(rowindex, i + 1).Font.Size = CInt(headList(i, 1))
                objWS.Cells(rowindex, i + 1).Font.Name = "標楷體"
            Next

            rowindex += 1

            For x As Int32 = 0 To dgv_Excel.Rows.Count - 1
                For z As Int32 = 0 To headList.GetUpperBound(0) - 1

                    objWS.Cells(rowindex, z + 1) = dgv_Excel.Rows(x).Cells(headList(z, 0)).Value
                    If headList(z, 0).Equals("問題描述") Then
                        objWS.Cells(rowindex, z + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    Else
                        objWS.Cells(rowindex, z + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    End If
                    objWS.Cells(rowindex, z + 1).Font.Name = "標楷體"
                Next
                rowindex += 1
            Next

            rowindex = 1
            Dim obj As Object = System.Reflection.Missing.Value

            For x As Int32 = 0 To dgv_SelectPic.Rows.Count - 1
                Dim m_objRange As Microsoft.Office.Interop.Excel.Range = objWS.Range(Chr(71) & ((x + 2) + (x * 12)).ToString)
                m_objRange.Select()
                Dim opicture As Object
                opicture = objWB.ActiveSheet.Shapes.AddPicture(dgv_SelectPic.Rows(x).Cells("PicPath").Value.ToString, True, True, 1250, 30 + 200 * x, 300, 200)
                rowindex += 1
            Next


            rowindex = 1
            '程式路徑
            Dim headList2 As String(,) = {{"系統代碼", "16", "20"},
                                          {"路徑", "16", "150"},
                                          {"名稱", "16", "20"},
                                          {"變更集編號", "16", "20"},
                                          {"狀態", "16", "20"},
                                          {"備註", "16", "100"}}

            objWS = objWB.Worksheets(2)
            objWS.Name = "程式"

            ''印出標題
            For i As Int32 = 0 To headList2.GetUpperBound(0)
                objWS.Cells(rowindex, i + 1) = headList2(i, 0)
                objWS.Cells(rowindex, i + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                objWS.Cells(rowindex, i + 1).ColumnWidth = headList2(i, 2)

                objWS.Cells(rowindex, i + 1).Font.Size = CInt(headList2(i, 1))
                objWS.Cells(rowindex, i + 1).Font.Name = "標楷體"
            Next
            rowindex += 1

            '寫入路徑
            For x As Int32 = 0 To dgv_Path.Rows.Count - 1
                objWS.Cells(rowindex, 1) = txt_System.Text
                objWS.Cells(rowindex, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                objWS.Cells(rowindex, 1).Font.Name = "標楷體"

                objWS.Cells(rowindex, 2) = dgv_Path.Rows(x).Cells("FilePath").Value.ToString.Replace("C:\", "").Replace("D:\", "")
                objWS.Cells(rowindex, 2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                objWS.Cells(rowindex, 2).Font.Name = "標楷體"


                objWS.Cells(rowindex, 3) = dgv_Path.Rows(x).Cells("FilePath").Value.ToString.Replace("C:\", "").Replace("D:\", "").Split("\")(dgv_Path.Rows(x).Cells("FilePath").Value.ToString.Replace("C:\", "").Replace("D:\", "").Split("\").Length - 1)
                objWS.Cells(rowindex, 3).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                objWS.Cells(rowindex, 3).Font.Name = "標楷體"
                rowindex += 1
            Next

            'DB
            Dim headList3 As String(,) = {{"Table Name", "16", "20"},
                                          {"欄位", "16", "20"},
                                          {"型態", "16", "20"},
                                          {"狀態", "16", "20"}}

            objWS = objWB.Worksheets(3)
            objWS.Name = "DB"

            ''印出標題
            For i As Int32 = 0 To headList3.GetUpperBound(0)
                objWS.Cells(rowindex, i + 1) = headList3(i, 0)
                objWS.Cells(rowindex, i + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                objWS.Cells(rowindex, i + 1).ColumnWidth = headList3(i, 2)

                objWS.Cells(rowindex, i + 1).Font.Size = CInt(headList3(i, 1))
                objWS.Cells(rowindex, i + 1).Font.Name = "標楷體"
            Next
            rowindex += 1

        Catch ex As Exception

        Finally
            objApp.ActiveWorkbook.Save()
            objApp.Quit()
            '回收Excel
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objApp)
            If objApp IsNot Nothing Then objApp = Nothing
            If objWB IsNot Nothing Then objWB = Nothing
            If objWS IsNot Nothing Then objWS = Nothing
            GC.Collect()
        End Try


    End Sub

#End Region
#Region "文件壓縮"

    Public Function CompressFile(directorySelected As DirectoryInfo) As String
        Dim fileFullName As String = directorySelected.FullName & ".zip"
        '如果檔案存在，就問是否要刪除
        Dim zipInfo As New DirectoryInfo(fileFullName)
        If zipInfo.Exists = False Then
            ZipFile.CreateFromDirectory(directorySelected.FullName, fileFullName)
            directorySelected.Delete(True)
        Else
            Dim result As Integer = MessageBox.Show("檔案已存在是否覆蓋?", "警告", MessageBoxButtons.OKCancel)
            If result = DialogResult.OK Then
                zipInfo.Delete()
            Else
                Return ""
            End If
        End If
        FileName = directorySelected.Name.ToString
        Return fileFullName
    End Function

#End Region
#Region "上傳FTP"
    Private Function UploadToFTP() As Int32

        Try
            'Dim sourceStream As StreamReader = New StreamReader(CompressFile(New DirectoryInfo(FolderPath)))
            Dim filePath As String = CompressFile(New DirectoryInfo(FolderPath))
            Dim Upload As String = txt_FTPAddress.Text & cbo_FTPFolder.SelectedValue & "/" & Now.ToString("yyyyMMdd") & txt_Ver.Text & "(" & txt_System.Text & ")" & "-正式機上版申請(" & txt_PGName.Text & ").zip"

            Dim wc As New WebClient With {
                .Credentials = New NetworkCredential(txt_FTPLoginUser.Text, txt_FTPLoginPassWord.Text)
            }
            wc.UploadFile(Upload, filePath)
        Catch ex As Exception
            Return 1
        End Try
        Return 0

    End Function

    ''' <summary>
    ''' 更換FTP位置
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ResetFolderCombobox()


        Dim theUri As New Uri(txt_FTPAddress.Text)

        Try
            '定義FtpWebRequest類別
            Dim myRequest As FtpWebRequest

            '建立FtpWebRequest
            myRequest = CType(FtpWebRequest.Create(theUri), FtpWebRequest)

            '認證
            myRequest.Credentials = New NetworkCredential(txt_FTPLoginUser.Text, txt_FTPLoginPassWord.Text)

            '服務要求
            myRequest.Method = WebRequestMethods.Ftp.ListDirectory

            '定義FtpWebResponse類別
            Dim myFtpResponse As FtpWebResponse

            '建立FtpWebResponse
            myFtpResponse = CType(myRequest.GetResponse, FtpWebResponse)

            '建立目錄及檔案資料流
            Dim DataStream As Stream = myFtpResponse.GetResponseStream

            '建立目錄資料流
            Dim DownLoadDir As New StreamReader(DataStream, Encoding.UTF8)

            '讀取資料流
            Dim FTPFolders = DownLoadDir.ReadToEnd.Replace(vbLf, "").Split(vbCrLf)

            If FTPFolder Is Nothing Then
                FTPFolder = New Data.DataTable
                FTPFolder.Columns.Add("FolderName")
            Else
                FTPFolder.Clear()
            End If

            For Each s As String In FTPFolders
                If Not s.Contains(".") Then
                    FTPFolder.Rows.Add(s)
                End If
            Next

            cbo_FTPFolder.DataSource = FTPFolder.Copy
            cbo_FTPFolder.DisplayMember = "FolderName"
            cbo_FTPFolder.ValueMember = "FolderName"

            DataStream.Close()
            myFtpResponse.Close()

        Catch ex As Exception
            If theUri.Scheme <> Uri.UriSchemeFtp Then
                MsgBox(ex.ToString + vbNewLine + "請輸入正確的'ftp://xxx' 格式")
                Exit Sub
            Else
                MsgBox(ex.ToString + vbNewLine + "請確認帳號密碼正確")
            End If
        End Try
    End Sub


#End Region
#Region "發送提交通知"

    Private Function SendMailAfterUpload() As Int32

        Try
            Dim mailTitle As String = Now.ToString("yyyyMMdd") & txt_Ver.Text & "(" & txt_System.Text & ")" & "-正式機上版申請(" & txt_PGName.Text & ")"
            Dim message As New StringBuilder

            message.AppendLine("PG 程式提交通知(請勿直接回覆)")
            message.Append("所屬系統: ").Append(txt_System.Text).AppendLine()
            message.Append("提交者: ").Append(txt_PGName.Text).AppendLine()
            message.Append("需求提出日: ").Append(dtp_AssignDate.GetUsDateStr).AppendLine()
            message.Append("程式提交日: ").Append(Now.ToString("yyyy/MM/dd")).AppendLine()
            message.Append("歸屬功能: ").Append(txt_Function.Text).AppendLine()
            message.Append("問題類別: ").Append(cbo_Classify.Text).AppendLine()
            message.Append("提交版次: ").Append(txt_Ver.Text).AppendLine()
            message.Append("問題描述: ").Append(rtb_desc.Text).AppendLine()
            message.Append("提交程式:").AppendLine()
            For i As Int32 = 0 To dgv_Path.Rows.Count - 1
                message.Append(dgv_Path.Rows(i).Cells("FilePath").Value.ToString.Split("\")(dgv_Path.Rows(i).Cells("FilePath").Value.ToString.Split("\").Length - 1)).AppendLine()
            Next



            SendMail.getInstance.SendMail(MainReceiver, CCUser, mailTitle, message.ToString, FolderPath & ".zip")
        Catch ex As Exception
            Return 1
        End Try
        Return 0
    End Function

#End Region
#Region "檢核"

    Private Function CheckPathIsExist(ByVal path As String, ByVal dgv As DataGridView) As Boolean

        'If dgv_Path.Rows.Count <= 0 Then Return False

        CheckPathIsExist = True
        For i As Int32 = 0 To dgv.Rows.Count - 1
            Select Case dgv.Name
                Case "dgv_Path"
                    If dgv.Rows(i).Cells("FilePath").Value.ToString.Equals(path) Then
                        Return False
                    End If
                Case "dgv_SelectPic"
                    If dgv.Rows(i).Cells("PicPath").Value.ToString.Equals(path) Then
                        Return False
                    End If
            End Select

        Next
        Return CheckPathIsExist

    End Function

    Private Function CheckInput() As Boolean


        CheckInput = False


        If txt_System.Text = "" Then
            Return True
        End If
        If txt_PGName.Text = "" Then
            Return True
        End If
        If txt_Function.Text = "" Then
            Return True
        End If
        If cbo_Classify.Text = "" Then
            Return True
        End If
        If rtb_desc.Text = "" Then
            Return True
        End If


        Return CheckInput

    End Function

    Private Function EnableUpload() As Boolean
        Return dgv_Excel.Rows.Count > 0 AndAlso dgv_Path.Rows.Count > 0
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        ClearAll()

    End Sub

    Private Sub ClearAll()

        dgv_Excel.Rows.Clear()
        dgv_Path.Rows.Clear()

    End Sub

    Private Sub btn_SelectPic_Click(sender As Object, e As EventArgs) Handles btn_SelectPic.Click

        Me.SelectFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF;*.PNG;"

        If Me.SelectFile.ShowDialog() = DialogResult.OK Then
            Dim filePaths As String() = SelectFile.FileNames
            For Each s As String In filePaths
                If CheckPathIsExist(s, dgv_SelectPic) Then
                    dgv_SelectPic.Rows.Add(False, s)
                End If
            Next
        End If
    End Sub

#End Region

#End Region

End Class