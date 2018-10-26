Imports System.Transactions
Imports System.IO
Imports Syscom.Comm.BASE
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.SQL

Public Class FTMDelegate

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As FTMDelegate
        Get
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New FTMDelegate()
    End Class

#End Region

    ''' <summary>
    ''' 上傳包藥機檔案
    ''' </summary>
    ''' <param name="data">上傳包藥機檔案</param>
    ''' <param name="fileVersionData">檔案版本資訊</param>
    ''' <returns>FID</returns>
    ''' <remarks></remarks>
    Public Function uploadDrugPackFile(ByRef path As String, ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing) As String()
        Dim rtn As String()
        Try
            Using tx As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                rtn = FileTransfer.uploadDrugPackFile(path, data, fileVersionData)
                tx.Complete()
            End Using
            Return rtn
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
    Public Function uploadNewFile(ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String()
        Dim connFlag As Boolean = conn Is Nothing
        Dim rtn As String()
        Try
            Using tx As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                If connFlag Then
                    conn = SQLConnFactory.getInstance.getPubDBSqlConn
                    conn.Open()
                End If
                rtn = FileTransfer.uploadNewFile(data, fileVersionData, conn:=conn)
                tx.Complete()
            End Using
            Return rtn
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    ''' <summary>
    ''' 透過FTP上傳檔案
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="fileVersionData"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function uploadFtpFile(ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String()
        Dim connFlag As Boolean = conn Is Nothing
        Dim rtn As String()
        Try
            Using tx As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                If connFlag Then
                    conn = SQLConnFactory.getInstance.getPubDBSqlConn
                    conn.Open()
                End If
                rtn = FileTransfer.uploadNewFile(data, conn:=conn)
                tx.Complete()
            End Using
            Return rtn
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
    Public Function uploadNewFile(ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, ByVal inAccessPWTag As String, _
                                  ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing) As String()
        Dim rtn As String()
        Try
            Using tx As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                rtn = FileTransfer.uploadNewFile(inUNCPathTag, inAccessIDTag, inAccessPWTag, data, fileVersionData)
                tx.Complete()
            End Using
            Return rtn
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 下載檔案
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <param name="old_file_name">是否使用上傳時的原擋名</param>
    ''' <returns>(0) 檔案資料byte() , (1) client端的預設檔名</returns>
    ''' <remarks></remarks>
    Public Function downloadFile(ByRef FID As String, Optional ByRef old_file_name As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As Object()
        Try
            Return FileTransfer.downloadFile(FID, old_file_name, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
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
    Public Function downloadFile(ByRef FID As String, ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, _
                                 ByVal inAccessPWTag As String, ByVal inExtensionName As String, Optional ByRef old_file_name As Boolean = False) As Object()
        Try
            Return FileTransfer.downloadFile(FID, inUNCPathTag, inAccessIDTag, inAccessPWTag, inExtensionName, old_file_name)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 一次下載多個檔案
    ''' </summary>
    ''' <param name="FIDs">FIDs</param>
    ''' <param name="old_file_name">是否使用上傳時的原擋名</param>
    ''' <returns>Hashtable 以 FID 當 key </returns>
    ''' <remarks></remarks>
    Public Function downloadFiles(ByRef FIDs As String(), Optional ByRef old_file_name As Boolean = False) As Hashtable
        Try
            Dim fidTable = New Hashtable
            For Each FID As String In FIDs
                Dim fileObject = downloadFile(FID, old_file_name)
                fidTable.Add(FID, fileObject)
            Next
            Return fidTable
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 取得縮圖
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <returns>縮圖的byte array</returns>
    ''' <remarks></remarks>
    Public Function getImageThumb(ByRef FID As String) As Byte()
        Try
            Return FileTransfer.getImageThumb(FID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#Region "新版 FTM 在此 by roger 990706"

    Function UploadFTMFile(ByRef fi As FileInfo, ByRef data As DataRow, Optional ByRef fileVersionData As DataRow = Nothing) As String
        Try
            Return FileTransfer.uploadFTMFile(fi, data, fileVersionData)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Function DownloadFTMFile(ByRef FID As String, ByRef old_file_name As Boolean) As FileInfo
        Try
            Return FileTransfer.downloadFTMFile(FID, old_file_name)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "包藥機 FTP"
    Public Function ftpDrugpack(ByVal fi As System.IO.FileInfo)
        Try
            Return FTM.FTPTool.uploadFile(fi)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

End Class
