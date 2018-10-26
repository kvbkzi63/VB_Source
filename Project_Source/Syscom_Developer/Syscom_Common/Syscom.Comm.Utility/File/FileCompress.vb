Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Collections
Imports Syscom.Comm.EXP

Public Class FileCompress

    ''' <summary>
    ''' 阻止外部直接宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

    End Sub

#Region "   壓縮文件"

    ''' <summary>
    ''' 對目標文件夾進行壓縮
    ''' </summary>
    ''' <param name="sourcePath">目標文件夾</param>
    ''' <param name="destname">壓縮檔案名</param>
    ''' <remarks></remarks>
    Public Shared Sub CompressFolder(ByVal sourcePath As String, ByVal destName As String)
        Try
            Dim list As New ArrayList

            For Each filepath In Directory.GetFiles(sourcePath)
                Dim destBuffer() As Byte = File.ReadAllBytes(filepath)
                Dim sf As SerializeFileInfo = New SerializeFileInfo(filepath, destBuffer)
                list.Add(sf)
            Next

            Dim formatter As IFormatter = New BinaryFormatter
            Using ms As New MemoryStream
                formatter.Serialize(ms, list)
                ms.Position = 0
                CreateCompressFile(ms, destName)
            End Using
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 壓縮檔案
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="destName"></param>
    ''' <remarks></remarks>
    Public Shared Sub CreateCompressFile(ByVal source As Stream, ByVal destName As String)
        Try
            Using destination As Stream = New FileStream(destName, FileMode.Create, FileAccess.Write)
                Using output As GZipStream = New GZipStream(destination, CompressionMode.Compress)
                    Dim bytes(4096) As Byte

                    Dim n As Integer = source.Read(bytes, 0, bytes.Length)

                    While n <> 0
                        output.Write(bytes, 0, n)
                        n = source.Read(bytes, 0, bytes.Length)
                    End While

                End Using
            End Using
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Sub

#End Region

#Region "   解壓縮文件"

    ''' <summary>
    ''' 對目標文件進行解壓
    ''' </summary>
    ''' <param name="sourcePath">目標壓縮檔</param>
    ''' <param name="destPath">解壓縮的目的路徑</param>
    ''' <remarks></remarks>
    Public Shared Sub DecompressFolder(ByVal sourcePath As String, ByVal destPath As String)
        Try
            Using source As Stream = File.OpenRead(sourcePath)
                Using dest As Stream = New MemoryStream

                    Using input As GZipStream = New GZipStream(source, CompressionMode.Decompress, True)
                        Dim bytes(4096) As Byte
                        Dim n As Integer = input.Read(bytes, 0, bytes.Length)

                        While n <> 0
                            dest.Write(bytes, 0, n)
                            n = input.Read(bytes, 0, bytes.Length)
                        End While

                    End Using

                    dest.Flush()
                    dest.Position = 0
                    DeSerializeFiles(dest, destPath)

                End Using
            End Using
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 解壓檔案
    ''' </summary>
    ''' <param name="stream"></param>
    ''' <param name="dirPath"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeSerializeFiles(ByVal stream As Stream, ByVal dirPath As String)
        Try
            Dim bf As BinaryFormatter = New BinaryFormatter
            Dim list As ArrayList = CType(bf.Deserialize(stream), ArrayList)

            For Each sf As SerializeFileInfo In list
                Dim newName As String = dirPath & Path.GetFileName(sf.FileName)
                Using fs As FileStream = New FileStream(newName, FileMode.Create, FileAccess.Write)
                    fs.Write(sf.FileBuffer, 0, sf.FileBuffer.Length)
                    fs.Close()
                End Using
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Sub

#End Region
   
End Class
