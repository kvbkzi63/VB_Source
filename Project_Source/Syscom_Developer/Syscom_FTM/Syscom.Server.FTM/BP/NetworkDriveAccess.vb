Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Configuration
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP

Public Class NetworkDriveAccess

    Private Shared ReadOnly apTempLocalDir As String = ConfigurationManager.AppSettings.Item("TempFile")

    Private Shared ReadOnly instance As New NetworkDriveAccess
    Private UNCPath As String
    Private accessID As String
    Private accessPW As String
    Private NetUseShell As String
    Dim log As LOGDelegate
    Private isDeviceFlag As String = "0"

    Private Sub New()
        log = LOGDelegate.getInstance
        UNCPath = ConfigurationManager.AppSettings.Item("UNCPath")
        accessID = ConfigurationManager.AppSettings.Item("fsUserID")
        accessPW = ConfigurationManager.AppSettings.Item("fsUserPW")
        NetUseShell = "net use " & UNCPath & " /user:" & accessID & " " & accessPW
        '取得設定檔 使用網路芳鄰=1或Ftp=0
        isDeviceFlag = ConfigurationManager.AppSettings.Item("isDeviceFlag")
    End Sub

    Public Shared Function getInstance() As NetworkDriveAccess
        Return instance
    End Function

    Public Sub retrieveShareFolder()
        If isDeviceFlag = "1" Then '網路芳鄰
            If Not checkShareFolder() Then '如果已存在且已有創建目錄的權限就不執行 NET USE 
                log.fileDebugMsg("NET USE Command thread id：" & CStr(Shell(NetUseShell)))
                log.fileDebugMsg("Wait 5 Sec. For ""net use"" Command Effected ")
                Threading.Thread.Sleep(5000)
                If Not checkShareFolder() Then '執行過 NET USE，又找不到目錄或是創建目錄的權限，丟出例外
                    log.fileWarnMsg("NET USE Command 失敗：" & NetUseShell)
                    Throw New FTMBusinessException("FTMUNCA008", New String() {UNCPath})
                End If
            End If
        Else
            '網路磁碟機
        End If
    End Sub

    ''' <summary>
    ''' 檢核過目錄是否存在,以及創建目錄的權限
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkShareFolder() As Boolean

        Dim dir As DirectoryInfo = New DirectoryInfo(UNCPath)
        
            If Not dir.Exists Then
                log.fileWarnMsg("無法找到 Share 目錄：" & UNCPath)
                Return False
            Else
                Try
                    Dim subdirectory = dir.CreateSubdirectory("TST")
                    If Not subdirectory.Exists Then
                        Throw New FTMBusinessException("CMMCMMB300", New String() {"創建子目錄成功，但目錄不存在：" & subdirectory.FullName})
                    End If
                Catch cmex As CommonException
                    Throw cmex
                Catch ex As Exception
                    Throw New FTMBusinessException("CMMCMMB300", New String() {"創建子目錄出現例外，代表連接有問題，需要重新連線。"})
                End Try
                Return True
            End If
        
    End Function

    ''' <summary>
    ''' 寫檔至 File Server
    ''' </summary>
    ''' <param name="fspath">路徑 such as \20090909\EMR\</param>
    ''' <param name="file">檔案</param>
    ''' <returns>File Ｓerver 路徑跟檔名</returns>
    ''' <remarks></remarks>
    Public Function moveFileToFileServer(ByRef fspath As String(), ByRef file As FileInfo()) As String()
        Dim fullFilePathName As String() = New String(fspath.Count) {}

        retrieveShareFolder()

        For i = 0 To fspath.Count - 1
            '創建目錄，如果已存在，不影響
            Dim fsRoot As DirectoryInfo = New DirectoryInfo(UNCPath & "\")
            Dim subdirectory = fsRoot.CreateSubdirectory(fspath(i))

            '判斷創建目錄是否存在
            If Not subdirectory.Exists Then
                log.fileWarnMsg("創建目錄不存在：" & fspath(i))
                Throw New FTMBusinessException("FTMUNCA009", New String() {fspath(i)})
            End If

            '判斷來源檔是否存在
            If (file(i) Is Nothing) OrElse (Not file(i).Exists) Then
                log.fileWarnMsg("來源檔不存在：" & (CStr(IIf(file Is Nothing, "", file(i).FullName))))
                Throw New FTMBusinessException("FTMUNCA010", New String() {(CStr(IIf(file Is Nothing, "", file(i).FullName)))})
            End If

            '寫入　File Server
            fullFilePathName(i) = subdirectory.FullName & "\" & file(i).Name
            moveFile(file(i).FullName, fullFilePathName(i))

            '判斷寫入的檔案是否存在
            Dim fi As New FileInfo(fullFilePathName(i))
            If Not fi.Exists Then
                log.fileWarnMsg("寫入的檔案不存在：" & fullFilePathName(i))
                Throw New FTMBusinessException("FTMUNCA011", New String() {fullFilePathName(i)})
            End If

        Next

        Return fullFilePathName
    End Function

    ''' <summary>
    ''' 寫檔至 File Server
    ''' </summary>
    ''' <param name="fspath">路徑 such as \20090909\EMR\</param>
    ''' <param name="file">檔案</param>
    ''' <returns>File Ｓerver 路徑跟檔名</returns>
    ''' <remarks></remarks>
    Public Function moveFileToFileServer(ByRef fspath As String, ByRef file As FileInfo) As String

        Dim _fspath As String() = New String() {fspath}
        Dim _file As FileInfo() = New FileInfo() {file}

        Return moveFileToFileServer(_fspath, _file)(0)

    End Function

    ''' <summary>
    ''' 從 File Server 讀檔
    ''' </summary>
    ''' <param name="fileName">Full Path File Name in File Server </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getFileFromFileServer(ByRef fileName As String) As Byte()

        retrieveShareFolder()

        '讀檔，轉成 byte() 資料流
        Dim fileStream = FileTransferTool.convertFileToByteArray(UNCPath & "\" & fileName)

        Return fileStream
    End Function

    ''' <summary>
    ''' 從 File Server 讀檔
    ''' </summary>
    ''' <param name="fid">FID for temp local file name</param>
    ''' <param name="fileName">Full Path File Name in File Server </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getFileFromFileServerWithFile(ByRef fid As String, ByRef fileName As String) As FileInfo

        retrieveShareFolder()
        Dim srcFile As New FileInfo(UNCPath & "\" & fileName)
        Dim dstFile As New FileInfo(apTempLocalDir & "\" & fid)
        If copyFile(srcFile, dstFile) Then
            Return dstFile
        Else
            Throw New FTMBusinessException("CMMCMMB300", New String() {"複製 File Server 檔案失敗"})
        End If


    End Function

#Region "copy and move function"
    Public Shared Function moveFile(ByRef srcFilePath As String, ByRef dstFilePath As String) As Boolean
        Return moveFile(New FileInfo(srcFilePath), New FileInfo(dstFilePath))
    End Function
    Public Shared Function moveFile(ByRef srcFile As FileInfo, ByRef dstFile As FileInfo) As Boolean
        Try
            If copyFile(srcFile, dstFile) Then
                'srcFile.Delete() '暫時不刪
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMB300", New String() {"移動檔案失敗於 File Server"})
        End Try
    End Function
    Public Shared Function copyFile(ByRef srcFilePath As String, ByRef dstFilePath As String) As Boolean
        Return copyFile(New FileInfo(srcFilePath), New FileInfo(dstFilePath))
    End Function
    Public Shared Function copyFile(ByRef srcFile As FileInfo, ByRef dstFile As FileInfo) As Boolean
        Try
            Dim mBinaryAry(4096) As Byte
            Dim cnt As Integer
            Using fs As FileStream = IO.File.Open(srcFile.FullName, IO.FileMode.Open, IO.FileAccess.Read), fsout As FileStream = IO.File.OpenWrite(dstFile.FullName)

                '每一次從圖形讀取 4096 個位元組
                'Read 方法不僅可將讀取資料填入 Byte 陣列中，還會傳回實際讀取的位元組數
                cnt = fs.Read(mBinaryAry, 0, 4096)

                While cnt > 0  ' 判斷是否到達檔案的尾端
                    fsout.Write(mBinaryAry, 0, cnt)
                    cnt = fs.Read(mBinaryAry, 0, 4096)
                End While

                fsout.Flush()
                fsout.Close()
                fs.Close()
            End Using
            Return True
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMB300", New String() {"複製檔案失敗於 File Server"})
        End Try

    End Function
#End Region

End Class
