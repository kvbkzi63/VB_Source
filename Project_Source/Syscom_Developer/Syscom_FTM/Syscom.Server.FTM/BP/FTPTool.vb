Imports System.Net
Imports System.IO
Imports System.Configuration
Imports Syscom.Comm.EXP

''' <summary>
''' 連接 ftp Server
''' </summary>
''' <remarks></remarks>
Public Class FTPTool
    Private Shared ReadOnly ftpURI As String = ConfigurationManager.AppSettings.Item("ftpURL")
    Private Shared ReadOnly ftpID As String = ConfigurationManager.AppSettings.Item("ftpUser")
    Private Shared ReadOnly ftpPW As String = ConfigurationManager.AppSettings.Item("ftpPwd")
    Private Shared ReadOnly ftpQRCURI As String = ConfigurationManager.AppSettings.Item("ftpQRCURL")
    Private Shared ReadOnly ftpQRCID As String = ConfigurationManager.AppSettings.Item("ftpQRCUser")
    Private Shared ReadOnly ftpQRCPW As String = ConfigurationManager.AppSettings.Item("ftpQRCPwd")

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

#Region "網路芳鄰 存入FileServer"
    Public Shared Function uploadFile(ByRef file As System.IO.FileInfo) As Boolean
        Try


            Dim retFlag As Boolean = False
            If file IsNot Nothing AndAlso file.Exists Then
                writeFTPList(file.FullName, "上傳開始")
                Dim rename = False

                If isFileExists(file.Name) Then
                    rename = True
                    file = file.CopyTo(file.DirectoryName & "/" & Now.ToString("ren-yyyMMdd-HHssfff-") & file.Name)
                End If
                file.CreationTime = Now
                file.LastWriteTime = Now
                writeFTPList(file.FullName, "更新檔案創建時間為" + file.CreationTime.ToString("yyyy/MM/dd HH:mm:ss.ffff"))
                Dim myRequest As FtpWebRequest = FtpWebRequest.Create(ftpURI & "/" & file.Name)
                myRequest.Credentials = New Net.NetworkCredential(ftpID, ftpPW)
                myRequest.KeepAlive = False
                myRequest.Method = Net.WebRequestMethods.Ftp.UploadFile
                myRequest.UseBinary = True
                Const BufferSize As Integer = 2048
                Dim content(BufferSize - 1) As Byte, dataRead As Integer
                Using fs As FileStream = file.OpenRead()
                    Try
                        Using rs As Stream = myRequest.GetRequestStream
                            Do
                                dataRead = fs.Read(content, 0, BufferSize)
                                rs.Write(content, 0, dataRead)
                            Loop Until dataRead < BufferSize
                            rs.Close()
                        End Using
                    Catch ex As Exception
                        Throw ex
                    Finally
                        'ensure file closed
                        fs.Close()
                    End Try
                End Using

                If rename Then
                    file.Delete()
                End If
                writeFTPList(file.FullName, "上傳結束")
                retFlag = True
            Else
                'Throw New Exception("FTP Source File " + file.FullName + " Not Found")
                retFlag = False
            End If
            Return retFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Shared Function isFileExists(ByRef fileName As String) As Boolean

        Try
            Dim myRequest As FtpWebRequest = FtpWebRequest.Create(ftpURI & "/" & fileName)
            myRequest.Credentials = New Net.NetworkCredential(ftpID, ftpPW)
            myRequest.KeepAlive = False
            myRequest.Method = Net.WebRequestMethods.Ftp.GetFileSize
            myRequest.UseBinary = True

            Dim result As String = ""
            Using response As FtpWebResponse = myRequest.GetResponse
                Dim size As Long = response.ContentLength
                Using datastream As Stream = response.GetResponseStream
                    Using sr As New StreamReader(datastream)
                        result = sr.ReadToEnd()
                        sr.Close()
                    End Using
                    datastream.Close()
                End Using
                response.Close()
            End Using
            If result IsNot Nothing Then
                Return True
            End If
        Catch ex As Exception
            If TypeOf ex Is System.Net.WebException Then
                'file does not exist/no rights error = 550
                If ex.Message.Contains("550") Then
                    'clear 
                    Return False
                Else
                    Throw ex
                End If
            Else
                Throw ex
            End If
        End Try


    End Function
#End Region

#Region "FTP 存入FileServer"
    Public Shared Function FtpUploadFile(ByRef path As String, ByRef file As System.IO.FileInfo, Optional ByRef specialPath As String = "") As Boolean
        Try
            Dim A As String = path
            Dim newFilePath As String = A.Replace("\", "/")
            Dim ftpFullPathFileName As String = ""

            Dim retFlag As Boolean = False

            If specialPath = "" Then
                ftpFullPathFileName = ftpURI & "/" & newFilePath & "/" & file.Name
            Else
                ftpFullPathFileName = ftpURI & "/" & specialPath & "/" & file.Name
                newFilePath = specialPath
            End If

            If file IsNot Nothing AndAlso file.Exists Then
                writeFTPList(file.FullName, "上傳開始")
                Dim rename = False

                If ftpFileExists(newFilePath, file.Name) Then
                    rename = True
                    file = file.CopyTo(file.DirectoryName & "/" & Now.ToString("ren-yyyMMdd-HHssfff-") & file.Name)
                End If
                file.CreationTime = Now
                file.LastWriteTime = Now
                writeFTPList(file.FullName, "更新檔案創建時間為" + file.CreationTime.ToString("yyyy/MM/dd HH:mm:ss.ffff"))
                Dim myRequest As FtpWebRequest = FtpWebRequest.Create(ftpFullPathFileName)
                myRequest.Credentials = New Net.NetworkCredential(ftpID, ftpPW)
                myRequest.KeepAlive = False
                myRequest.Method = Net.WebRequestMethods.Ftp.UploadFile
                myRequest.UseBinary = True
                Const BufferSize As Integer = 2048
                Dim content(BufferSize - 1) As Byte, dataRead As Integer
                Using fs As FileStream = file.OpenRead()
                    Try
                        Using rs As Stream = myRequest.GetRequestStream
                            Do
                                dataRead = fs.Read(content, 0, BufferSize)
                                rs.Write(content, 0, dataRead)
                            Loop Until dataRead < BufferSize
                            rs.Close()
                        End Using
                    Catch ex As Exception
                        Throw ex
                    Finally
                        'ensure file closed
                        fs.Close()
                    End Try
                End Using

                If rename Then
                    file.Delete()
                End If
                writeFTPList(file.FullName, "上傳結束")
                retFlag = True
            Else
                'Throw New Exception("FTP Source File " + file.FullName + " Not Found")
                retFlag = False
            End If
            Return retFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Shared Function ftpFileExists(ByRef _path As String, ByRef fileName As String) As Boolean

        Try
            createFtpFolder(_path)
            Dim myRequest As FtpWebRequest = FtpWebRequest.Create(ftpURI & "/" & _path & "/" & fileName)
            myRequest.Credentials = New Net.NetworkCredential(ftpID, ftpPW)
            myRequest.KeepAlive = False
            myRequest.Method = Net.WebRequestMethods.Ftp.GetFileSize
            myRequest.UseBinary = True

            Dim result As String = ""
            Using response As FtpWebResponse = myRequest.GetResponse
                Dim size As Long = response.ContentLength
                Using datastream As Stream = response.GetResponseStream
                    Using sr As New StreamReader(datastream)
                        result = sr.ReadToEnd()
                        sr.Close()
                    End Using
                    datastream.Close()
                End Using
                response.Close()
            End Using
            If result IsNot Nothing Then
                Return True
            End If
        Catch ex As Exception
            If TypeOf ex Is System.Net.WebException Then
                'file does not exist/no rights error = 550
                If ex.Message.Contains("550") Then
                    'clear 
                    Return False
                Else
                    Throw ex
                End If
            Else
                Throw ex
            End If
        End Try


    End Function

    Public Shared Function createFtpFolder(ByVal _path As String)
        Try
            Dim myRequest As FtpWebRequest = FtpWebRequest.Create(ftpURI & "/" & _path & "/")
            myRequest.Credentials = New Net.NetworkCredential(ftpID, ftpPW)
            myRequest.KeepAlive = False
            myRequest.Method = Net.WebRequestMethods.Ftp.MakeDirectory
            Dim response As FtpWebResponse = myRequest.GetResponse
            response.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Shared Sub writeFTPList(ByRef fileName As String, ByRef action As String)
        Try
            Dim strSet = ftpURI.Split("/")
            Dim ftpServer = strSet(2)

            Dim runTimeObject = New FileInfo(System.Reflection.Assembly.GetExecutingAssembly.Location())
            Dim runTimeObjectPath = runTimeObject.Directory.Parent.FullName
            Dim fi As New FileInfo(runTimeObjectPath + "\FTP " & ftpServer & " " & Now.Date.ToLongDateString() + ".txt")
            Dim fis = fi.AppendText()
            fis.Write("FTP " + action + " " + fileName + "  @" + Now.ToString("yyyy/MM/dd HH:mm:ss.ffff"))
            fis.WriteLine()
            fis.Flush()
            fis.Close()
        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "FTP 上傳 for QRCode(二維條碼路徑)"
    Public Shared Function FtpUploadFileQRCode(ByRef path As String, ByRef file As System.IO.FileInfo, Optional ByRef specialPath As String = "") As Boolean
        Try
            Dim A As String = path
            Dim newFilePath As String = A.Replace("\", "/")
            Dim ftpFullPathFileName As String = ""

            Dim retFlag As Boolean = False

            If specialPath = "" Then
                ftpFullPathFileName = ftpQRCURI & "/QRCODE/" & newFilePath & "/" & file.Name
            Else
                ftpFullPathFileName = ftpQRCURI & "/QRCODE/" & specialPath & "/" & file.Name
                newFilePath = specialPath
            End If

            If file IsNot Nothing AndAlso file.Exists Then
                writeFTPListQRC(file.FullName, "上傳開始")
                Dim rename = False

                If ftpFileExistsQRC(newFilePath, file.Name) Then
                    rename = True
                    file = file.CopyTo(file.DirectoryName & "/" & Now.ToString("ren-yyyMMdd-HHssfff-") & file.Name)
                End If
                file.CreationTime = Now
                file.LastWriteTime = Now
                writeFTPListQRC(file.FullName, "更新檔案創建時間為" + file.CreationTime.ToString("yyyy/MM/dd HH:mm:ss.ffff"))
                Dim myRequest As FtpWebRequest = FtpWebRequest.Create(ftpFullPathFileName)
                myRequest.Credentials = New Net.NetworkCredential(ftpQRCID, ftpQRCPW)
                myRequest.KeepAlive = False
                myRequest.Method = Net.WebRequestMethods.Ftp.UploadFile
                myRequest.UseBinary = True
                Const BufferSize As Integer = 2048
                Dim content(BufferSize - 1) As Byte, dataRead As Integer
                Using fs As FileStream = file.OpenRead()
                    Try
                        Using rs As Stream = myRequest.GetRequestStream
                            Do
                                dataRead = fs.Read(content, 0, BufferSize)
                                rs.Write(content, 0, dataRead)
                            Loop Until dataRead < BufferSize
                            rs.Close()
                        End Using
                    Catch ex As Exception
                        Throw ex
                    Finally
                        'ensure file closed
                        fs.Close()
                    End Try
                End Using

                If rename Then
                    file.Delete()
                End If
                writeFTPListQRC(file.FullName, "上傳結束")
                retFlag = True
            Else
                'Throw New Exception("FTP Source File " + file.FullName + " Not Found")
                retFlag = False
            End If
            Return retFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Shared Function ftpFileExistsQRC(ByRef _path As String, ByRef fileName As String) As Boolean

        Try
            createFtpFolderQRC(_path)
            Dim myRequest As FtpWebRequest = FtpWebRequest.Create(ftpQRCURI & "/" & _path & "/" & fileName)
            myRequest.Credentials = New Net.NetworkCredential(ftpQRCID, ftpQRCPW)
            myRequest.KeepAlive = False
            myRequest.Method = Net.WebRequestMethods.Ftp.GetFileSize
            myRequest.UseBinary = True

            Dim result As String = ""
            Using response As FtpWebResponse = myRequest.GetResponse
                Dim size As Long = response.ContentLength
                Using datastream As Stream = response.GetResponseStream
                    Using sr As New StreamReader(datastream)
                        result = sr.ReadToEnd()
                        sr.Close()
                    End Using
                    datastream.Close()
                End Using
                response.Close()
            End Using
            If result IsNot Nothing Then
                Return True
            End If
        Catch ex As Exception
            If TypeOf ex Is System.Net.WebException Then
                'file does not exist/no rights error = 550
                If ex.Message.Contains("550") Then
                    'clear 
                    Return False
                Else
                    Throw ex
                End If
            Else
                Throw ex
            End If
        End Try


    End Function

    Public Shared Function createFtpFolderQRC(ByVal _path As String)
        Try
            Dim myRequest As FtpWebRequest = FtpWebRequest.Create(ftpQRCURI & "/" & _path & "/")
            myRequest.Credentials = New Net.NetworkCredential(ftpQRCID, ftpQRCPW)
            myRequest.KeepAlive = False
            myRequest.Method = Net.WebRequestMethods.Ftp.MakeDirectory
            Dim response As FtpWebResponse = myRequest.GetResponse
            response.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Shared Sub writeFTPListQRC(ByRef fileName As String, ByRef action As String)
        Try
            Dim strSet = ftpURI.Split("/")
            Dim ftpServer = strSet(2)

            Dim runTimeObject = New FileInfo(System.Reflection.Assembly.GetExecutingAssembly.Location())
            Dim runTimeObjectPath = runTimeObject.Directory.Parent.FullName
            Dim fi As New FileInfo(runTimeObjectPath + "\FTP " & ftpServer & " " & Now.Date.ToLongDateString() + ".txt")
            Dim fis = fi.AppendText()
            fis.Write("FTP " + action + " " + fileName + "  @" + Now.ToString("yyyy/MM/dd HH:mm:ss.ffff"))
            fis.WriteLine()
            fis.Flush()
            fis.Close()
        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "FTP Download"

    Public Shared Function FtpDownloadFile(ByVal ftpFile As String, ByVal TargetPath As String) As Byte()

        'downloadUrl下載FTP的目錄ex : ftp//127.0.0.1/abc.xml , TargetPath本機存檔目錄,UserName使用者FTP登入帳號 , Password使用者登入密碼
        Dim responseStream As Stream = Nothing

        Dim fileStream As FileStream = Nothing

        Dim reader As StreamReader = Nothing

        Dim _file As String = ftpFile.Replace("\", "/")

        Try


            Dim downloadRequest As FtpWebRequest = FtpWebRequest.Create(ftpURI & "/" & _file)
            downloadRequest.Credentials = New Net.NetworkCredential(ftpID, ftpPW)
            downloadRequest.UseBinary = True
            'downloadRequest.UsePassive = True
            downloadRequest.KeepAlive = True

            downloadRequest.Timeout = 100000
            downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile
            '設定Method下載檔案

            Dim downloadResponse As FtpWebResponse = DirectCast(downloadRequest.GetResponse(), FtpWebResponse)

            responseStream = downloadResponse.GetResponseStream()
            '取得FTP伺服器回傳的資料流
            Dim fileName As String = Path.GetFileName(downloadRequest.RequestUri.AbsolutePath)

            If fileName.Length = 0 Then
                reader = New StreamReader(responseStream)
                Throw New Exception(reader.ReadToEnd())
            Else



                fileStream = File.Create(TargetPath & "\" & fileName)
                Dim buffer As Byte() = New Byte(2048) {}
                Dim bytesRead As Integer
                While True

                    '開始將資料流寫入到本機
                    bytesRead = responseStream.Read(buffer, 0, buffer.Length)
                    If bytesRead = 0 Then

                        Exit While
                    End If
                    fileStream.Write(buffer, 0, bytesRead)

                End While
            End If
            fileStream.Close()

            Dim _Stream = Comm.Utility.FileTransferTool.convertFileToByteArray(TargetPath & "\" & fileName)

            Return _Stream

        Catch ex As IOException
            'Return False
            Console.WriteLine(ex.Message)
            Throw New Exception(ex.Message)
        Finally

            If reader IsNot Nothing Then

                reader.Close()

            ElseIf responseStream IsNot Nothing Then

                responseStream.Close()
            End If

            If fileStream IsNot Nothing Then

                fileStream.Close()

            End If
        End Try

    End Function
#End Region









End Class
