Imports System.IO
Imports Syscom.Comm.EXP

Public Class FileTransferTool

    ''' <summary>
    ''' 阻止外部直接宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

    End Sub

    Public Shared FileType_T As String = "T" 'T(一般樣板)
    Public Shared FileType_G As String = "G" 'G(一般資料)
    Public Shared FileType_R As String = "R" 'R(報表資料)
    Public Shared FileType_O As String = "O" 'O(門診資料)
    Public Shared FileType_E As String = "E" 'E(急診資料)
    Public Shared FileType_I As String = "I" 'I(住院資料)

    Public Enum HandleType
        RENAME = 0
        OVERWRITE = 1
    End Enum

    ''' <summary>
    ''' 將檔案轉換成 byte()
    ''' </summary>
    ''' <param name="filename">檔案路徑</param>
    ''' <returns>byte()</returns>
    ''' <remarks></remarks>
    Public Shared Function convertFileToByteArray(ByRef fileName As String) As Byte()
        Try
            Dim fi As New FileInfo(fileName)
            If (fi Is Nothing) OrElse (Not fi.Exists) Then
                Throw New FTMBusinessException("FTMUNCA007", New String() {fileName})
            End If

            Dim fileData As Byte() = Nothing
            ' Open a file that is to be loaded into a byte array
            Dim oFile As New System.IO.FileInfo(fileName)
            Dim oFileStream As System.IO.FileStream = oFile.OpenRead()
            Dim lBytes As Long = oFileStream.Length

            If (lBytes > 0) Then
                fileData = New Byte(CInt(lBytes - 1)) {}

                ' Read the file into a byte array
                oFileStream.Read(fileData, 0, CInt(lBytes))
                oFileStream.Close()
                oFileStream.Dispose()
                oFileStream = Nothing
            End If
            Return fileData
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 將 byte()轉換成檔案
    ''' </summary>
    ''' <param name="fileData">檔案byte()</param>
    ''' <param name="filename">檔案路徑及名稱</param>
    ''' <remarks></remarks>
    Public Shared Sub convertByteArrayToFile(ByRef fileData As Byte(), ByRef fileName As String, Optional ByVal Type As HandleType = HandleType.RENAME)
        Try
            Dim fi As New FileInfo(fileName)
            If fi.Exists Then
                If Type = HandleType.RENAME Then
                    fi.MoveTo(fileName & "_old_" & fi.LastWriteTime.ToString("yyyyMMdd-HHmmss") & Now.ToString("fff"))
                ElseIf Type = HandleType.OVERWRITE Then
                    fi.Delete()
                End If
            End If

            Dim filePath = New DirectoryInfo(fi.DirectoryName)
            If Not filePath.Exists Then
                filePath.Create()
            End If

            ' Create a file and write the byte data to a file.
            Dim oFileStream As System.IO.FileStream
            oFileStream = New System.IO.FileStream(fileName, System.IO.FileMode.Create)
            oFileStream.Write(fileData, 0, fileData.Length)
            oFileStream.Close()
            oFileStream.Dispose()
            oFileStream = Nothing
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Sub

End Class
