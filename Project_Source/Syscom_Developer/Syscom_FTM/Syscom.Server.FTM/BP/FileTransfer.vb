Imports System.IO
Imports System.Text
Imports System.Configuration
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SNC

Public Class FileTransfer

    Private Shared ReadOnly apTempLocalDir As String = ConfigurationManager.AppSettings.Item("TempFile")
    Private Shared ReadOnly transferFlag As String = ConfigurationManager.AppSettings.Item("isDeviceFlag") '0=網路芳鄰,1=FtpServer


    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

#Region "    上傳檔案"

    ''' <summary>
    ''' 上傳包藥機檔案
    ''' </summary>
    ''' <param name="data">上傳包藥機檔案</param>
    ''' <param name="fileVersionData">檔案版本資訊</param>
    ''' <returns>FID</returns>
    ''' <remarks></remarks>
    Public Shared Function uploadDrugPackFile(ByRef path As String, ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing) As String()
        Try
            Return uploadNewFile(data, fileVersionData)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 上傳檔案
    ''' </summary>
    ''' <param name="data">上傳檔案資料</param>
    ''' <param name="fileVersionData">檔案版本資訊</param>
    ''' <returns>FID</returns>
    ''' <remarks></remarks>
    Public Shared Function uploadNewFile(ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing, Optional ByRef specialPath As String = "", Optional ByRef useOldFileName As Boolean = False, Optional ByVal overWriteExists As Boolean = False, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String()
        Try
            Dim fidString As String() = Nothing
            Dim currentTime = Now
            If (Not data Is Nothing) AndAlso (Not data.Tables(FileTransferDataFormat.tableName) Is Nothing) AndAlso data.Tables(FileTransferDataFormat.tableName).Rows.Count > 0 Then
                fidString = New String(data.Tables(FileTransferDataFormat.tableName).Rows.Count - 1) {}
                Dim dirName As String() = New String(data.Tables(FileTransferDataFormat.tableName).Rows.Count - 1) {}
                Dim fis As FileInfo() = New FileInfo(data.Tables(FileTransferDataFormat.tableName).Rows.Count - 1) {}

                Dim dataTable As DataTable = FileTransferDataFormat.getDataTableWithSchema
                Dim dtPubFileMap As DataTable = PubFileMapDataTableFactory.getDataTableWithSchema
                Dim dsPubFileMap As DataSet = New DataSet(PubFileMapDataTableFactory.tableName)

                For index As Integer = 0 To data.Tables(FileTransferDataFormat.tableName).Rows.Count - 1
                    Dim currentRow = data.Tables(FileTransferDataFormat.tableName).Rows(index)
                    Dim oldFileName = IIf(StringUtil.nvl(currentRow("File_Name")) = "", "anonymous.tmp", New FileInfo(currentRow("File_Name")).Name)

                    Dim newFileName = oldFileName
                    If Not useOldFileName Then
                        newFileName = getNewFileName(oldFileName) '取得新檔名 ex: 12345.txt        
                    End If

                    fis(index) = New FileInfo(apTempLocalDir & "\" & newFileName) '寫入APServer暫存檔路徑
                    FileTransferTool.convertByteArrayToFile(currentRow("FileByteArray"), apTempLocalDir & "\" & newFileName) '寫入暫存檔

                    If specialPath = "" Then
                        dirName(index) = getDirectoryName(currentRow("FileType"), currentRow("FileSub"), currentRow("FileTime")) '取得File Server 路徑
                        fidString(index) = getNewFID(newFileName, dirName(index)) '取得新的FID，從路徑及檔名產生
                    Else
                        dirName(index) = specialPath
                        fidString(index) = specialPath.Substring(0, 3) & SNCDelegate.getInstance.getFileSerialNo & Now.ToString("HHmmssfff") 'getNewFID(newFileName, dirName(index)) '取得新的FID，從路徑及檔名產生
                    End If

                    'dirName(index) = getDirectoryName(currentRow("FileType"), currentRow("FileSub"), currentRow("FileTime")) '取得File Server 路徑

                    'fidString(index) = getNewFID(newFileName, dirName(index)) '取得新的FID，從路徑及檔名產生

                    Dim rowPubFileMap As DataRow = dtPubFileMap.NewRow
                    rowPubFileMap("FID") = fidString(index)
                    rowPubFileMap("File_Name") = oldFileName
                    rowPubFileMap("Order_Seq") = currentRow("Order_Seq")
                    If (Not currentRow("Image_Thumb") Is Nothing) OrElse (Not currentRow("Image_Thumb") Is DBNull.Value) Then
                        rowPubFileMap("Image_Thumb") = currentRow("Image_Thumb")
                    End If
                    rowPubFileMap("File_Note") = currentRow("File_Note")
                    rowPubFileMap("Create_User") = currentRow("Create_User")
                    rowPubFileMap("Create_Time") = currentTime
                    rowPubFileMap("Modified_User") = currentRow("Modified_User")
                    rowPubFileMap("Modified_Time") = currentTime
                    dtPubFileMap.Rows.Add(rowPubFileMap)
                Next

                '將AP暫存檔案，移轉到 File Server 0=Ftpserver  , 1=網路芳鄰
                If transferFlag = 1 Then
                    NetworkDriveAccess.getInstance.moveFileToFileServer(dirName, fis)
                Else
                    For i As Integer = 0 To dirName.Length - 1
                        FTPTool.FtpUploadFile(dirName(i), fis(i))
                    Next
                End If

                dsPubFileMap.Tables.Add(dtPubFileMap)
                PubFileMapBO.GetInstance.insertByAssignCreateTime(dsPubFileMap, currentTime, conn)
                If Not fileVersionData Is Nothing Then
                    PubFileVersionBO.GetInstance.insertByAssignCreateTime(fileVersionData, currentTime, conn)
                End If
            End If
            Return fidString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 上傳檔案(可透過AppSetting.config的Tag設定來指定下載路徑)
    ''' </summary>
    ''' <param name="data">上傳檔案資料</param>
    ''' <param name="fileVersionData">檔案版本資訊</param>
    ''' <returns>FID</returns>
    ''' <remarks></remarks>
    Public Shared Function uploadNewFile(ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, ByVal inAccessPWTag As String, _
                                         ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing, Optional ByRef specialPath As String = "", Optional ByRef useOldFileName As Boolean = False, Optional ByVal overWriteExists As Boolean = False) As String()
        Try
            Dim fidString As String() = Nothing
            Dim currentTime = Now
            If data IsNot Nothing AndAlso data.Tables(FileTransferDataFormat.tableName) IsNot Nothing AndAlso data.Tables(FileTransferDataFormat.tableName).Rows.Count > 0 Then
                fidString = New String(data.Tables(FileTransferDataFormat.tableName).Rows.Count - 1) {}
                Dim dirName As String() = New String(data.Tables(FileTransferDataFormat.tableName).Rows.Count - 1) {}
                Dim fis As FileInfo() = New FileInfo(data.Tables(FileTransferDataFormat.tableName).Rows.Count - 1) {}

                Dim dataTable As DataTable = FileTransferDataFormat.getDataTableWithSchema
                Dim dtPubFileMap As DataTable = PubFileMapDataTableFactory.getDataTableWithSchema
                Dim dsPubFileMap As DataSet = New DataSet(PubFileMapDataTableFactory.tableName)

                For index As Integer = 0 To data.Tables(FileTransferDataFormat.tableName).Rows.Count - 1
                    Dim currentRow As DataRow = data.Tables(FileTransferDataFormat.tableName).Rows(index)
                    Dim oldFileName As String = IIf(StringUtil.nvl(currentRow("File_Name")) = "", "anonymous.tmp", New FileInfo(currentRow("File_Name")).Name)

                    Dim newFileName As String = oldFileName
                    If Not useOldFileName Then
                        newFileName = getNewFileName(oldFileName) '取得新檔名 ex: 12345.txt        
                    End If

                    fis(index) = New FileInfo(apTempLocalDir & "\" & newFileName) '寫入APServer暫存檔路徑
                    FileTransferTool.convertByteArrayToFile(currentRow("FileByteArray"), apTempLocalDir & "\" & newFileName) '寫入暫存檔

                    If specialPath = "" Then
                        dirName(index) = getDirectoryName(currentRow("FileType"), currentRow("FileSub"), currentRow("FileTime")) '取得File Server 路徑
                        fidString(index) = getNewFID(newFileName, dirName(index)) '取得新的FID，從路徑及檔名產生
                    Else
                        dirName(index) = specialPath
                        fidString(index) = specialPath.Substring(0, 3) & SNCDelegate.getInstance.getFileSerialNo & Now.ToString("HHmmssfff") 'getNewFID(newFileName, dirName(index)) '取得新的FID，從路徑及檔名產生
                    End If


                    'dirName(index) = getDirectoryName(currentRow("FileType"), currentRow("FileSub"), currentRow("FileTime")) '取得File Server 路徑

                    'fidString(index) = getNewFID(newFileName, dirName(index)) '取得新的FID，從路徑及檔名產生

                    Dim rowPubFileMap As DataRow = dtPubFileMap.NewRow
                    rowPubFileMap("FID") = fidString(index)
                    rowPubFileMap("File_Name") = oldFileName
                    rowPubFileMap("Order_Seq") = currentRow("Order_Seq")
                    If (Not currentRow("Image_Thumb") Is Nothing) OrElse (Not currentRow("Image_Thumb") Is DBNull.Value) Then
                        rowPubFileMap("Image_Thumb") = currentRow("Image_Thumb")
                    End If
                    rowPubFileMap("File_Note") = currentRow("File_Note")
                    rowPubFileMap("Create_User") = currentRow("Create_User")
                    rowPubFileMap("Create_Time") = currentTime
                    rowPubFileMap("Modified_User") = currentRow("Modified_User")
                    rowPubFileMap("Modified_Time") = currentTime
                    dtPubFileMap.Rows.Add(rowPubFileMap)
                Next

                '將AP暫存檔案，移轉到 File Server 0=Ftpserver  , 1=網路芳鄰
                If transferFlag = 1 Then
                    NetworkDriveAccessByPath.getInstance.moveFileToFileServer(inUNCPathTag, inAccessIDTag, inAccessPWTag, dirName, fis)
                Else
                    For i As Integer = 0 To dirName.Length - 1
                        FTPTool.FtpUploadFile(dirName(i), fis(i))
                    Next
                End If

                dsPubFileMap.Tables.Add(dtPubFileMap)
                PubFileMapBO.GetInstance.insertByAssignCreateTime(dsPubFileMap, currentTime)
                If Not fileVersionData Is Nothing Then
                    PubFileVersionBO.GetInstance.insertByAssignCreateTime(fileVersionData, currentTime)
                End If
            End If
            Return fidString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "    下載檔案"

    ''' <summary>
    ''' 下載檔案
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <param name="old_file_name">是否使用上傳時的原擋名</param>
    ''' <returns>(0) 檔案資料byte() , (1) client端的預設檔名</returns>
    ''' <remarks></remarks>
    Public Shared Function downloadFile(ByRef FID As String, Optional ByRef old_file_name As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As Object()


        Dim connFlag As Boolean = conn Is Nothing
        Dim returnObject = New Object(3) {}

        Try


            If connFlag Then
                conn = Syscom.Server.SQL.SQLConnFactory.getInstance.getPubDBSqlConn
                conn.Open()
            End If
            Dim newFileName As String = FID '預設原始擋名就是 FID
            Dim fileNote As String = ""
            Dim orderSeq As Integer = 0
            Dim ds As DataSet = PubFileMapBO.GetInstance.queryByPK(FID, conn)
            If (Not ds Is Nothing) AndAlso ds.Tables.Count > 0 AndAlso (Not ds.Tables(PubFileMapDataTableFactory.tableName) Is Nothing) AndAlso ds.Tables(PubFileMapDataTableFactory.tableName).Rows.Count > 0 Then
                newFileName = ds.Tables(PubFileMapDataTableFactory.tableName).Rows(0).Item("File_Name")
                fileNote = ds.Tables(PubFileMapDataTableFactory.tableName).Rows(0).Item("File_Note")
                orderSeq = ds.Tables(PubFileMapDataTableFactory.tableName).Rows(0).Item("Order_Seq")
            End If
            If old_file_name Then '以當初上傳的檔名回傳
                If (newFileName Is Nothing) OrElse newFileName.Length = 0 Then
                    newFileName = FID
                End If
            End If

            Dim fsPath As String = getFilePathFromFID(FID)
            If Not fsPath Is Nothing Then
                Dim fi = New FileInfo(fsPath)
                returnObject(3) = orderSeq
                returnObject(2) = fileNote
                returnObject(1) = apTempLocalDir & "\" & newFileName

                If transferFlag = 1 Then
                    returnObject(0) = NetworkDriveAccess.getInstance.getFileFromFileServer(fsPath)
                Else
                    returnObject(0) = FTPTool.FtpDownloadFile(fsPath, apTempLocalDir)
                End If

            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"上傳"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
        Return returnObject

    End Function

    ''' <summary>
    ''' 下載檔案(可透過AppSetting.config的Tag設定來指定下載路徑)
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <param name="inUNCPathTag">UNCPath Tag</param>
    ''' <param name="inAccessIDTag">AccessID Tag</param>
    ''' <param name="inAccessPWTag">AccessPW Tag</param>
    ''' <param name="inExtensionName">副檔名，例:txt或xml</param>
    ''' <param name="old_file_name">是否使用上傳時的原擋名</param>
    ''' <returns>(0) 檔案資料byte() , (1) client端的預設檔名</returns>
    ''' <remarks></remarks>
    Public Shared Function downloadFile(ByRef FID As String, ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, ByVal inAccessPWTag As String, _
                                        ByVal inExtensionName As String, Optional ByRef old_file_name As Boolean = False) As Object()

        Dim newFileName As String = FID '預設原始擋名就是 FID
        Dim fileNote As String = ""
        Dim orderSeq As Integer = 0
        Dim ds As DataSet = PubFileMapBO.GetInstance.queryByPK(FID)
        If (Not ds Is Nothing) AndAlso ds.Tables.Count > 0 AndAlso (Not ds.Tables(PubFileMapDataTableFactory.tableName) Is Nothing) AndAlso ds.Tables(PubFileMapDataTableFactory.tableName).Rows.Count > 0 Then
            newFileName = ds.Tables(PubFileMapDataTableFactory.tableName).Rows(0).Item("File_Name")
            fileNote = ds.Tables(PubFileMapDataTableFactory.tableName).Rows(0).Item("File_Note")
            orderSeq = ds.Tables(PubFileMapDataTableFactory.tableName).Rows(0).Item("Order_Seq")
        End If
        If old_file_name Then '以當初上傳的擋名回傳
            If (newFileName Is Nothing) OrElse newFileName.Length = 0 Then
                newFileName = FID
            End If
        End If

        Dim fsPath = getFilePathFromFID(FID)

        If inExtensionName <> "" Then
            fsPath = fsPath & "." & inExtensionName
        End If
        Dim returnObject = New Object(3) {}
        If Not fsPath Is Nothing Then
            Dim fi = New FileInfo(fsPath)
            returnObject(3) = orderSeq
            returnObject(2) = fileNote
            returnObject(1) = apTempLocalDir & "\" & newFileName

            Dim inst As New NetworkDriveAccessByPath
            inst = NetworkDriveAccessByPath.getInstance
            If transferFlag = 1 Then
                returnObject(0) = inst.getFileFromFileServer(inUNCPathTag, inAccessIDTag, inAccessPWTag, fsPath)
            Else
                returnObject(0) = FTPTool.FtpDownloadFile(fsPath, apTempLocalDir)
            End If

        End If
        Return returnObject

    End Function

#End Region

    ''' <summary>
    ''' 取得縮圖
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <returns>縮圖的byte array</returns>
    ''' <remarks></remarks>
    Public Shared Function getImageThumb(ByRef FID As String) As Byte()
        Dim ds As DataSet = PubFileMapBO.GetInstance.queryByPK(FID)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(PubFileMapDataTableFactory.tableName) IsNot Nothing AndAlso ds.Tables(PubFileMapDataTableFactory.tableName).Rows.Count > 0 Then
            Return IIf(ds.Tables(PubFileMapDataTableFactory.tableName).Rows(0).Item("Image_Thumb") Is DBNull.Value, Nothing, ds.Tables(PubFileMapDataTableFactory.tableName).Rows(0).Item("Image_Thumb"))
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 取得檔案新的名稱
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getNewFileName(ByRef fileName As String) As String
        Dim fi As New FileInfo(fileName)
        Return SNCDelegate.getInstance.getFileSerialNo & fi.Extension.ToLower
    End Function

    ''' <summary>
    ''' 取得FID
    ''' </summary>
    ''' <param name="newFileName">新檔名</param>    
    ''' <param name="newDirName">新路徑</param>    
    ''' <returns>FID</returns>
    ''' <remarks></remarks>
    Private Shared Function getNewFID(ByRef newFileName As String, ByRef newDirName As String) As String
        Return newDirName.Replace("\", "") & newFileName
    End Function

    ''' <summary>
    ''' 取得檔案歸屬 File Server 上的目錄名稱
    ''' </summary>   
    ''' <param name="fileType">(length=1) 代表檔案類型。T 一般樣板、G 一般資料、R 報表資料、O EMR門診資料、E EMR急診資料)、I EMR住院資料</param>
    ''' <param name="subCode">(length=8) 各系統自行定義的次分類代碼。</param>
    ''' <param name="dateTime">檔案時間</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getDirectoryName(ByRef fileType As String, ByRef subCode As String, Optional ByRef dateTime As DateTime = Nothing) As String
        Try
            If (Not subCode Is Nothing) AndAlso subCode.Length > 0 Then
                subCode = subCode.ToUpper.PadRight(8, "0")
            Else
                subCode = "".PadRight(8, "0")
            End If

            If (Not fileType Is Nothing) AndAlso fileType.Length > 0 Then
                fileType = fileType.ToUpper.Chars(0)
            Else
                fileType = "G" '沒有填寫，以G為主 一般資料
            End If

            Dim dirName As StringBuilder = New StringBuilder()

            Dim dirSubDir() As String = New String(6) {"", "", "", "", "", "", ""}
            dirSubDir(0) = IIf(dateTime.Ticks = 0, "9999", dateTime.ToString("yyyy"))
            dirSubDir(1) = IIf(dateTime.Ticks = 0, "99", dateTime.ToString("MM"))
            dirSubDir(2) = IIf(dateTime.Ticks = 0, "99", dateTime.ToString("dd"))
            dirSubDir(3) = fileType
            dirSubDir(4) = subCode.Substring(0, 3)
            dirSubDir(5) = subCode.Substring(3, 3)
            dirSubDir(6) = subCode.Substring(6, 2)

            For i = 0 To 6
                dirName.Append(dirSubDir(i))
                If i <> 6 Then
                    dirName.Append("\")
                End If
            Next
            Return dirName.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 利用FID取得目錄及檔名
    ''' </summary>
    ''' <param name="FID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getFilePathFromFID(ByRef FID As String) As String
        Try
            If (Not FID Is Nothing) AndAlso FID.Length > 17 Then
                Dim dirSubDir() As String = New String(7) {"", "", "", "", "", "", "", ""}
                Dim fileName = New StringBuilder
                dirSubDir(0) = FID.Substring(0, 4)
                dirSubDir(1) = FID.Substring(4, 2)
                dirSubDir(2) = FID.Substring(6, 2)
                dirSubDir(3) = FID.Substring(8, 1)
                dirSubDir(4) = FID.Substring(9, 3)
                dirSubDir(5) = FID.Substring(12, 3)
                dirSubDir(6) = FID.Substring(15, 2)
                dirSubDir(7) = FID.Substring(17, FID.Length - 17) ' 此為黨名
                For i = 0 To 7
                    fileName.Append(dirSubDir(i))
                    If i <> 7 Then
                        fileName.Append("\")
                    End If
                Next
                Return fileName.ToString
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "新版 FTM 在此 by roger 990706"

    ''' <summary>
    ''' 上傳檔案
    ''' </summary>
    ''' <param name="fi">檔案上傳到 AP Server 的實體位置</param>
    ''' <param name="data">上傳檔案資料</param>  
    ''' <returns>FID</returns>
    ''' <remarks></remarks>
    Public Shared Function uploadFTMFile(ByRef fi As FileInfo, ByRef data As DataRow, Optional ByRef fileVersionData As DataRow = Nothing) As String
        Try
            Dim fidString As String = ""
            Dim currentTime = Now
            If (Not data Is Nothing) Then

                Dim dirName As String = ""
                Dim dataTable As DataTable = FileTransferDataFormat.getDataTableWithSchema
                Dim dsPubFileMap As DataSet = New DataSet(PubFileMapDataTableFactory.tableName)
                Dim dtPubFileMap As DataTable = PubFileMapDataTableFactory.getDataTableWithSchema
                Dim currentRow = data
                Dim oldFileName = IIf(StringUtil.nvl(currentRow("File_Name")) = "", "anonymous.tmp", New FileInfo(currentRow("File_Name")).Name)
                Dim newFileName = getNewFileName(fi.Name) '取得新檔名 ex: 12345.txt       

                dirName = getDirectoryName(currentRow("FileType"), currentRow("FileSub"), currentRow("FileTime")) '取得File Server 路徑

                fi.MoveTo(fi.DirectoryName + "\" + newFileName)

                fidString = getNewFID(newFileName, dirName) '取得新的FID，從路徑及檔名產生

                Dim rowPubFileMap As DataRow = dtPubFileMap.NewRow
                rowPubFileMap("FID") = fidString
                rowPubFileMap("File_Name") = oldFileName
                rowPubFileMap("Order_Seq") = currentRow("Order_Seq")
                If (Not currentRow("Image_Thumb") Is Nothing) OrElse (Not currentRow("Image_Thumb") Is DBNull.Value) Then
                    rowPubFileMap("Image_Thumb") = currentRow("Image_Thumb")
                End If
                rowPubFileMap("File_Note") = currentRow("File_Note")
                rowPubFileMap("Create_User") = currentRow("Create_User")
                rowPubFileMap("Create_Time") = currentTime
                rowPubFileMap("Modified_User") = currentRow("Modified_User")
                rowPubFileMap("Modified_Time") = currentTime
                dtPubFileMap.Rows.Add(rowPubFileMap)


                '將AP暫存檔案，移轉到 File Server 0=Ftpserver  , 1=網路芳鄰
                If transferFlag = 1 Then
                    NetworkDriveAccess.getInstance.moveFileToFileServer(dirName, fi)
                Else
                   FTPTool.FtpUploadFile(dirName, fi)
                End If

                dsPubFileMap.Tables.Add(dtPubFileMap)
                PubFileMapBO.GetInstance.insertByAssignCreateTime(dsPubFileMap, currentTime)

                If fileVersionData IsNot Nothing Then
                    Dim ds = New DataSet
                    Dim dt = PubFileVersionDataTableFactory.getDataTableWithSchema
                    dt.ImportRow(fileVersionData)
                    ds.Tables.Add(dt)
                    PubFileVersionBO.GetInstance.insert(ds)
                End If
            End If

            Return fidString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 下載檔案
    ''' </summary>
    ''' <param name="FID"></param>
    ''' <param name="old_file_name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function downloadFTMFile(ByRef FID As String, Optional ByRef old_file_name As Boolean = False) As FileInfo
        Try

            Dim oldFile = New FileInfo(apTempLocalDir & "\" & FID)

            If oldFile.Exists Then
                oldFile.Delete()
            End If

            '下載  File  0=Ftpserver  , 1=網路芳鄰
            Dim fsPath = getFilePathFromFID(FID)
            If transferFlag = 1 Then
                downloadFTMFile = NetworkDriveAccess.getInstance.getFileFromFileServerWithFile(FID, fsPath)
            Else
                'FTP Download
            End If
            Return downloadFTMFile

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

End Class
