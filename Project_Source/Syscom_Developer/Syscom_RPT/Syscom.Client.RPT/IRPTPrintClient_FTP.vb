Imports System.Net
Imports System.IO
Imports Syscom.Client.Servicefactory

Public MustInherit Class IRPTPrintClient_FTP
    Inherits Syscom.Comm.RPT.IRPTPrint
    '取得報表資料
    Protected Overrides Function _queryRPTData(ByRef queryCondition As Object()) As DataSet
        Return queryRPTData(queryCondition)
    End Function
    ''產生報表
    'Protected Overrides Function _genReport(ByRef data As DataSet) As Object
    '    Return genReport(data)
    'End Function
    '列印報表
    Protected Overrides Sub _printReport(ByRef rpt As Object)
        printReport(rpt)
    End Sub
    '取得印表機

    Protected Overrides Function _getPrinterName(ByRef id As String) As String
        Return getPrinterName(id)
    End Function
    '取得報表列印 JOB ID
    Protected Overrides Function _getRpt_Print_Job_ID() As String
        Return getRpt_Print_Job_ID()
    End Function

    '取得報表資料
    Protected MustOverride Function queryRPTData(ByRef queryCondition As Object()) As DataSet
    '產生報表
    Protected MustOverride Function genReport(ByRef data As DataSet) As Object
    '列印報表
    Protected MustOverride Sub printReport(ByRef rpt As Object)


    '取得印表機
    Protected Overridable Function getPrinterName(ByRef id As String) As String
        Return RptServiceManager.getInstance.getPrinterName(id, Syscom.Comm.RPT.IRPTPrint.client, printerCondition)
    End Function
    '取得報表列印 JOB ID
    Protected Function getRpt_Print_Job_ID() As String
        Return RptServiceManager.getInstance.getReportID()
    End Function



    ''' <summary>
    ''' 將印表機名稱加入txt File中
    ''' </summary>
    ''' <param name="rpt">txt 檔</param>
    ''' <param name="printerName">印表機名稱</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function SetPrinterNameToTxtFile(ByRef rpt As FileInfo, ByRef printerName As String) As FileInfo
        Return SetPrinterNameToTxtFile(rpt, printerName, System.Text.Encoding.GetEncoding("big5"))
        'Return SetPrinterNameToTxtFile(rpt, printerName, System.Text.Encoding.Unicode)
    End Function
    ''' <summary>
    ''' 寫入Txt File
    ''' </summary>
    ''' <param name="reportData">寫入檔案的資料</param>
    ''' <returns>FileInfo</returns>
    ''' <remarks></remarks>
    Protected Overrides Function WriteTxtFile(ByRef reportData As String, ByRef reportId As String) As FileInfo
        Return WriteTxtFile(reportData, reportId, System.Text.Encoding.GetEncoding("big5"))
        'Return WriteTxtFile(reportData, reportId, System.Text.Encoding.Unicode)
    End Function



#Region "FTP Stuff"

    Protected Sub printByFTP(ByRef ftpURI As String, ByRef ftpID As String, ByRef ftpPW As String, ByRef file As System.IO.FileInfo)
        Try

            If file IsNot Nothing AndAlso file.Exists Then

                Dim rename = False

                If ftpFileExists(ftpURI, ftpID, ftpPW, file.Name) Then
                    rename = True
                    file = file.CopyTo(file.DirectoryName & "/" & Now.ToString("ren-yyyMMdd-HHssfff-") & file.Name)
                End If
                'file.CreationTime = Now
                'file.LastWriteTime = Now

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
            Else
                Throw New Exception("FTP Source File " + file.FullName + " Not Found")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Function ftpFileExists(ByRef ftpURI As String, ByRef ftpID As String, ByRef ftpPW As String, ByRef fileName As String) As Boolean
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
End Class
