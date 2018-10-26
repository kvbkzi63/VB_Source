Imports System
Imports System.Text
Imports System.Collections
Imports System.IO
Imports ICode.ZipLib.Zip
Imports ICode.ZipLib.Core
Imports ICode.ZipLib
Public Class ZipAPI

#Region "    壓縮"

#Region "    壓縮(有密碼，Default:密碼)"

    Public Function ZipDir(ByVal sourceDir As String, ByVal targetName As String) As String
        'Dim sourceDir As String = "e:\1\0312\2011-03-12\" '"e:\7206H\"
        'Dim targetName As String = "E:\2011-03-12.zip"
        Dim astrFileNames() As String = Directory.GetFiles(sourceDir)
        Dim strmZipOutputStream As ZipOutputStream

        strmZipOutputStream = New ZipOutputStream(File.Create(targetName))
        Try

            REM Compression Level: 0-9
            REM 0: no(Compression)
            REM 9: maximum compression
            strmZipOutputStream.SetLevel(9)
            'set PAssword
            strmZipOutputStream.Password = "SyscoM@123"

            Dim strFile As String
            Dim abyBuffer(4096) As Byte

            For Each strFile In astrFileNames
                Dim strmFile As FileStream = File.OpenRead(strFile)
                Try
                    Dim objZipEntry As ZipEntry = New ZipEntry(strFile)
                    objZipEntry.DateTime = DateTime.Now
                    objZipEntry.Size = strmFile.Length

                    strmZipOutputStream.PutNextEntry(objZipEntry)
                    StreamUtils.Copy(strmFile, strmZipOutputStream, abyBuffer)
                Finally
                    strmFile.Close()
                End Try
            Next

            strmZipOutputStream.Finish()

        Finally
            strmZipOutputStream.Close()
        End Try

        Return ""
    End Function

#End Region


#Region "    壓縮(無密碼)"


    Public Function ZipDirNoPwd(ByVal sourceDir As String, ByVal targetName As String) As String
        'Dim sourceDir As String = "e:\1\0312\2011-03-12\" '"e:\7206H\"
        'Dim targetName As String = "E:\2011-03-12.zip"
        Dim astrFileNames() As String = Directory.GetFiles(sourceDir)
        Dim strmZipOutputStream As ZipOutputStream

        strmZipOutputStream = New ZipOutputStream(File.Create(targetName))
        Try

            REM Compression Level: 0-9
            REM 0: no(Compression)
            REM 9: maximum compression
            strmZipOutputStream.SetLevel(9)
            'set PAssword
            'strmZipOutputStream.Password = "SyscoM@123"

            Dim strFile As String
            Dim abyBuffer(4096) As Byte

            For Each strFile In astrFileNames
                Dim strmFile As FileStream = File.OpenRead(strFile)
                Try
                    Dim objZipEntry As ZipEntry = New ZipEntry(strFile)
                    objZipEntry.DateTime = DateTime.Now
                    objZipEntry.Size = strmFile.Length

                    strmZipOutputStream.PutNextEntry(objZipEntry)
                    StreamUtils.Copy(strmFile, strmZipOutputStream, abyBuffer)
                Finally
                    strmFile.Close()
                End Try
            Next

            strmZipOutputStream.Finish()

        Finally
            strmZipOutputStream.Close()
        End Try

        Return ""
    End Function

#End Region


#End Region


#Region "    解壓縮"



#Region "    解壓縮(有密碼，Default:密碼)"


    Public Function unZipFiles(ByVal zipFile As String, ByVal localBasePath As String, ByVal isFullPathName As Boolean) As Array
        Dim newFileName As String = ""
        Dim strmZipInputStream As ZipInputStream = New ZipInputStream(File.OpenRead(zipFile))
        Dim directoryName As String = ""
        Dim theEntry As ZipEntry = Nothing
        Dim ItemList As New ArrayList()
        theEntry = strmZipInputStream.GetNextEntry()
        Try

            strmZipInputStream.Password = "SyscoM@123"
            While IsNothing(theEntry) = False

                Console.WriteLine(theEntry.Name)
                If Not Directory.Exists(localBasePath) Then
                    Directory.CreateDirectory(localBasePath)
                End If
                If isFullPathName = True Then
                    directoryName = Path.GetDirectoryName(theEntry.Name)
                Else
                    directoryName = localBasePath
                End If

                'Dim directoryName As String = "C:\PrintBuffer" 'Path.GetDirectoryName(theEntry.Name)
                Dim fileName As String = Path.GetFileName(theEntry.Name)

                ' create directory
                If directoryName.Length > 0 Then
                    If Not Directory.Exists(directoryName) Then
                        Directory.CreateDirectory(directoryName)
                    End If

                End If

                If fileName <> [String].Empty Then

                    Using streamWriter As FileStream = File.Create(directoryName & "\" & fileName)

                        Dim size As Integer = 2048
                        Dim data As Byte() = New Byte(2048) {}
                        While True
                            size = strmZipInputStream.Read(data, 0, data.Length)
                            If size > 0 Then
                                streamWriter.Write(data, 0, size)
                            Else
                                Exit While
                            End If
                        End While
                    End Using
                End If
                ItemList.Add(directoryName & "\" & fileName)
                theEntry = strmZipInputStream.GetNextEntry()
            End While

            Return ItemList.ToArray
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



#End Region


#Region "    解壓縮(無密碼)"

    Public Function unZipFilesNoPwd(ByVal zipFile As String, ByVal localBasePath As String, ByVal isFullPathName As Boolean) As Array
        Dim newFileName As String = ""
        Dim strmZipInputStream As ZipInputStream = New ZipInputStream(File.OpenRead(zipFile))
        Dim directoryName As String = ""
        Dim theEntry As ZipEntry = Nothing
        Dim ItemList As New ArrayList()
        theEntry = strmZipInputStream.GetNextEntry()
        Try

            ' strmZipInputStream.Password = "SyscoM@123"
            While IsNothing(theEntry) = False

                Console.WriteLine(theEntry.Name)
                If Not Directory.Exists(localBasePath) Then
                    Directory.CreateDirectory(localBasePath)
                End If
                If isFullPathName = True Then
                    directoryName = Path.GetDirectoryName(theEntry.Name)
                Else
                    directoryName = localBasePath
                End If

                'Dim directoryName As String = "C:\PrintBuffer" 'Path.GetDirectoryName(theEntry.Name)
                Dim fileName As String = Path.GetFileName(theEntry.Name)

                ' create directory
                If directoryName.Length > 0 Then
                    If Not Directory.Exists(directoryName) Then
                        Directory.CreateDirectory(directoryName)
                    End If

                End If

                If fileName <> [String].Empty Then

                    Using streamWriter As FileStream = File.Create(directoryName & "\" & fileName)

                        Dim size As Integer = 2048
                        Dim data As Byte() = New Byte(2048) {}
                        While True
                            size = strmZipInputStream.Read(data, 0, data.Length)
                            If size > 0 Then
                                streamWriter.Write(data, 0, size)
                            Else
                                Exit While
                            End If
                        End While
                    End Using
                End If
                ItemList.Add(directoryName & "\" & fileName)
                theEntry = strmZipInputStream.GetNextEntry()
            End While

            Return ItemList.ToArray
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



#End Region


#End Region





End Class
