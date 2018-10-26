Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory

Public Class Sample
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If OpenFileDialog1.FileName <> "" Then
                TextBox2.Text = OpenFileDialog1.FileName
                PictureBox1.Image = ImageTool.getThumbnailImage(TextBox2.Text)
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MsgBox("請選擇檔案")
        Else
            TextBox6.Text = ("開始 ") & Now
            Dim dataSet As DataSet = New DataSet
            Dim dataTable As DataTable = FileTransferDataFormat.getDataTableWithSchema
            Dim dataRow As DataRow = dataTable.NewRow()
            '使用自己的資料來源取代 New Object 

            dataRow("File_Name") = TextBox2.Text '檔案路徑
            dataRow("Order_Seq") = 1 '顯示順序
            dataRow("Image_Thumb") = IIf(ImageTool.IsImage(TextBox2.Text), ImageTool.convertImageToByteArray(ImageTool.getThumbnailImage(TextBox2.Text), ImageTool.getFormatByFileName(TextBox2.Text)), Nothing) '縮圖
            dataRow("File_Note") = "testing" '檔案註解
            dataRow("Create_User") = "roger" '上傳人員
            dataRow("Create_Time") = Now '上傳時間
            dataRow("Modified_User") = "roger" '修改人員
            dataRow("Modified_Time") = Now '修改時間

            dataRow("FileByteArray") = FileTransferTool.convertFileToByteArray(TextBox2.Text) '將檔案轉成 byte array
            dataRow("FileType") = FileTransferTool.FileType_G '檔案型態 --> T / G /R /O /E / I
            dataRow("FileSub") = "PUB12345" ' 檔案系統八碼，如果是 EMR 系統，這裡填入八碼病歷號 
            dataRow("FileTime") = Now '指定檔案時間

            dataTable.Rows.Add(dataRow)
            dataSet.Tables.Add(dataTable)

            Dim client = FtmServiceManager.getInstance
            Dim s() = client.uploadNewFile(dataSet)
            TextBox1.Text = s(0)
            TextBox6.Text = ("結束 ") & Now
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox3.Text = TextBox1.Text
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox6.Text = ("開始 ") & Now
        Dim data As DataSet = New DataSet
        Dim dataTable As DataTable = FileTransferDataFormat.getDataTableWithSchema
        For i As Int16 = 1 To TextBox5.Text


            Dim dataRow As DataRow = dataTable.NewRow()
            '使用自己的資料來源取代 New Object 

            dataRow("File_Name") = TextBox2.Text '檔案路徑
            dataRow("Order_Seq") = 1 '顯示順序
            dataRow("Image_Thumb") = IIf(ImageTool.IsImage(TextBox2.Text), ImageTool.convertImageToByteArray(ImageTool.getThumbnailImage(TextBox2.Text), ImageTool.getFormatByFileName(TextBox2.Text)), Nothing) '縮圖
            dataRow("File_Note") = "testing" '檔案註解
            dataRow("Create_User") = "roger" '上傳人員
            dataRow("Create_Time") = Now '上傳時間
            dataRow("Modified_User") = "roger" '修改人員
            dataRow("Modified_Time") = Now '修改時間

            dataRow("FileByteArray") = FileTransferTool.convertFileToByteArray(TextBox2.Text) '將檔案轉成 byte array
            dataRow("FileType") = FileTransferTool.FileType_G '檔案型態 --> T / G /R /O /E / I
            dataRow("FileSub") = "PUB12345" ' 檔案系統八碼，如果是 EMR 系統，這裡填入八碼病歷號 
            dataRow("FileTime") = Now '指定檔案時間

            dataTable.Rows.Add(dataRow)

        Next
        data.Tables.Add(dataTable)
        Dim client = FtmServiceManager.getInstance
        Dim s() = client.uploadNewFile(data)
        TextBox6.Text = ("結束 ") & Now
        Dim q = ""
        For i As Int16 = 1 To TextBox5.Text
            q = q & ("#" & i & " FID:" & s(i - 1)) & vbCrLf
        Next
        MsgBox(q)
        'TextBox1.Text = s(0)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        strs = New List(Of String)
        For i As Int16 = 1 To TextBox5.Text
            Dim tt As New System.Threading.Thread(AddressOf MultiThread)
            tt.Start()
        Next
    End Sub
    Private strs As New List(Of String)
    Private Sub MultiThread()

        Dim data As DataSet = New DataSet
        Dim dataTable As DataTable = FileTransferDataFormat.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 

        dataRow("File_Name") = TextBox2.Text '檔案路徑
        dataRow("Order_Seq") = 1 '顯示順序
        dataRow("Image_Thumb") = IIf(ImageTool.IsImage(TextBox2.Text), ImageTool.convertImageToByteArray(ImageTool.getThumbnailImage(TextBox2.Text), ImageTool.getFormatByFileName(TextBox2.Text)), Nothing) '縮圖
        dataRow("File_Note") = "testing" '檔案註解
        dataRow("Create_User") = "roger" '上傳人員
        dataRow("Create_Time") = Now '上傳時間
        dataRow("Modified_User") = "roger" '修改人員
        dataRow("Modified_Time") = Now '修改時間

        dataRow("FileByteArray") = FileTransferTool.convertFileToByteArray(TextBox2.Text) '將檔案轉成 byte array
        dataRow("FileType") = FileTransferTool.FileType_G '檔案型態 --> T / G /R /O /E / I
        dataRow("FileSub") = "PUB12345" ' 檔案系統八碼，如果是 EMR 系統，這裡填入八碼病歷號 
        dataRow("FileTime") = Now '指定檔案時間

        dataTable.Rows.Add(dataRow)
        data.Tables.Add(dataTable)
        Dim client = FtmServiceManager.getInstance
        Dim s() = client.uploadNewFile(data)

        strs.Add(s(0))
        Dim strplay = "Current Job Done : " & s(0) & vbCrLf & "Total List :" & vbCrLf
        For Each item As String In strs
            strplay += (item & vbCrLf)
        Next
        MsgBox(strplay)
        'TextBox6.Text = ("結束") & Now
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox6.Text = ("開始") & Now
        Dim client = FtmServiceManager.getInstance
        Dim imgBytes = client.getImageThumb(TextBox3.Text)
        TextBox6.Text = ("結束") & Now
        PictureBox2.Image = ImageTool.convertByteArrayToImage(imgBytes)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox6.Text = ("開始") & Now
        Dim client = FtmServiceManager.getInstance
        Dim rtn As Object() = client.downloadFile(TextBox3.Text)
        '(0) 檔案資料byte() , (1) client端的預設檔名
        '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
        FileTransferTool.convertByteArrayToFile(rtn(0), rtn(1))
        TextBox6.Text = ("結束") & Now
        '這一段是直接把文件/圖檔打開,看個人需要是否要如此做
        System.Diagnostics.Process.Start("""" & rtn(1) & """")
    End Sub

    Private Sub Sample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class