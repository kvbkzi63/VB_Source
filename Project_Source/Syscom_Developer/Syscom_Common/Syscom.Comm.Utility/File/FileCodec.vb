Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports Syscom.Comm.EXP

Public Class FileCodec

    ''' <summary>
    ''' 阻止外部直接宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

    End Sub

#Region "DES檔案加密&解密"

    Private Shared ReadOnly DesKey As String = "b1D8q0F1" '八碼
    Private Shared ReadOnly DesIvs As String = "S9H7E3q2" '八碼

    ''' <summary>
    ''' DES檔案加密
    ''' </summary>
    ''' <param name="inFullName">輸入檔案名稱(路徑+檔案名稱)</param>
    ''' <param name="outFullName">輸出檔案名稱(路徑+檔案名稱)</param>
    ''' <remarks></remarks>
    Public Shared Sub DESEncryptFile(ByVal inFullName As String, ByVal outFullName As String)
        Try
            Dim btKey() As Byte = Encoding.UTF8.GetBytes(DesKey)
            Dim btIV() As Byte = Encoding.UTF8.GetBytes(DesIvs)
            'Create the file streams to handle the input and output files.
            Dim fin As New FileStream(inFullName, FileMode.Open, FileAccess.Read)
            Dim fout As New FileStream(outFullName, FileMode.OpenOrCreate, FileAccess.Write)
            fout.SetLength(0)

            Dim bin(4096) As Byte
            Dim rdlen As Long = 0
            Dim totlen As Long = fin.Length
            Dim len As Integer
            Dim des As New DESCryptoServiceProvider()
            Dim encStream As New CryptoStream(fout, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write)

            'Read from the input file, then encrypt and write to the output file.
            While rdlen < totlen
                len = fin.Read(bin, 0, 4096)
                encStream.Write(bin, 0, len)
                rdlen = Convert.ToInt32(rdlen + len / des.BlockSize * des.BlockSize)
            End While

            encStream.Close()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' DES檔案解密
    ''' </summary>
    ''' <param name="encryptFile">加密檔案(路徑+檔案名稱)</param>
    ''' <param name="decryptFile">解密檔案(路徑+檔案名稱)</param>
    ''' <remarks></remarks>
    Public Shared Sub DESDecryptFile(ByVal encryptFile As String, ByVal decryptFile As String)
        Try
            Dim des As New DESCryptoServiceProvider()
            Dim btKey As Byte() = Encoding.UTF8.GetBytes(DesKey)
            Dim btIV As Byte() = Encoding.UTF8.GetBytes(DesIvs)

            des.Key = btKey
            des.IV = btIV

            Using encryptStream As New FileStream(encryptFile, FileMode.Open, FileAccess.Read)
                Using decryptStream As New FileStream(decryptFile, FileMode.Create, FileAccess.Write)
                    Dim dataByteArray As Byte() = New Byte(encryptStream.Length - 1) {}
                    encryptStream.Read(dataByteArray, 0, dataByteArray.Length)
                    Using cs As New CryptoStream(decryptStream, des.CreateDecryptor(), CryptoStreamMode.Write)
                        cs.Write(dataByteArray, 0, dataByteArray.Length)
                        cs.FlushFinalBlock()
                    End Using
                End Using
            End Using
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Sub

#End Region

#Region "AES 檔案加密&解密"

    Private Shared ReadOnly AesKey As String = "b1D8q0F1xu/6fmp6mp6a83CS"
    Private Shared ReadOnly AesIvs As String = "CSmp6a83xu/6fmp6S9H7E3q2"
    Private Shared ReadOnly saltSize As Integer = 32

    Enum SaltType As Integer
        salt16 = 0
        salt32 = 1
    End Enum

    ''' <summary>
    ''' 使用密碼和 Salt 來衍生金鑰，不管打再長的密碼都會經過 Salt 亂數處理，以符合規則
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Function GeneratorRfc() As Dictionary(Of String, Byte())
        Try
            Dim dicRfc As New Dictionary(Of String, Byte())
            Dim salt As Byte() = New Byte(16) {}
            Dim key As Byte() = Encoding.UTF8.GetBytes(AesKey)
            Dim rfcKey As New Rfc2898DeriveBytes(key, salt, 16)
            Dim rfcIv As New Rfc2898DeriveBytes(AesIvs, salt, 16)
            Dim keyData As Byte() = rfcKey.GetBytes(16)
            Dim IVData As Byte() = rfcIv.GetBytes(16)

            dicRfc.Add("KEY", keyData)
            dicRfc.Add("IV", IVData)
            Return dicRfc
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Function


    ''' <summary>
    ''' 使用密碼和 Salt 來衍生金鑰，不管打再長的密碼都會經過 Salt 亂數處理，以符合規則
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Function GeneratorRfc32() As Dictionary(Of String, Byte())
        Try
            Dim dicRfc As New Dictionary(Of String, Byte())
            Dim salt As Byte() = New Byte(saltSize - 1) {}
            Dim key As Byte() = Encoding.UTF8.GetBytes(AesKey)
            Dim rfcKey As New Rfc2898DeriveBytes(key, salt, 16)
            Dim rfcIv As New Rfc2898DeriveBytes(AesIvs, salt, 16)
            Dim keyData As Byte() = rfcKey.GetBytes(32)
            Dim IVData As Byte() = rfcIv.GetBytes(16)

            dicRfc.Add("KEY", keyData)
            dicRfc.Add("IV", IVData)
            Return dicRfc
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Function

#Region "AES sha256Provide(不支援Windows XP)"

    ''' <summary>
    ''' AES檔案加密(Key使用SHA256Provider)
    ''' </summary>
    ''' <param name="inFullName">輸入檔案名稱(路徑+檔案名稱)</param>
    ''' <param name="outFullName">輸出檔案名稱(路徑+檔案名稱)</param>
    ''' <remarks></remarks>
    Public Shared Sub AESEncryptFile(ByVal inFullName As String, ByVal outFullName As String, Optional ByVal saltType As SaltType = SaltType.salt16)
        Try
            '使用密碼和 Salt 來衍生金鑰，不管打再長的密碼都會經過 Salt 亂數處理，以符合規則
            Dim dicAESKey As Dictionary(Of String, Byte()) = IIf(saltType = FileCodec.SaltType.salt16, GeneratorRfc(), GeneratorRfc32())
            Dim btKey() As Byte = dicAESKey("KEY")
            Dim btIV() As Byte = dicAESKey("IV")

            Using AESprovider As AesCryptoServiceProvider = New AesCryptoServiceProvider()
                Using sha256Provider As SHA256CryptoServiceProvider = New SHA256CryptoServiceProvider()
                    Using md5Provider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
                        AESprovider.Key = sha256Provider.ComputeHash(btKey)
                        AESprovider.IV = md5Provider.ComputeHash(btIV)

                        'Create the file streams to handle the input and output files.
                        Using sourceStream As New FileStream(inFullName, FileMode.Open, FileAccess.Read)
                            Using encryptStream As New FileStream(outFullName, FileMode.OpenOrCreate, FileAccess.Write)
                                '檔案加密
                                Dim dataByteArray As Byte() = New Byte(sourceStream.Length - 1) {}
                                sourceStream.Read(dataByteArray, 0, dataByteArray.Length)

                                Using cs As New CryptoStream(encryptStream, AESprovider.CreateEncryptor(), CryptoStreamMode.Write)
                                    cs.Write(dataByteArray, 0, dataByteArray.Length)
                                    cs.FlushFinalBlock()
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' AES檔案解密(Key使用SHA256Provider)
    ''' </summary>
    ''' <param name="encryptFile">加密檔案(路徑+檔案名稱)</param>
    ''' <param name="decryptFile">解密檔案(路徑+檔案名稱)</param>
    ''' <remarks></remarks>
    Public Shared Sub AESDecryptFile(ByVal encryptFile As String, ByVal decryptFile As String, Optional ByVal saltType As SaltType = SaltType.salt16)
        Try
            '使用密碼和 Salt 來衍生金鑰，不管打再長的密碼都會經過 Salt 亂數處理，以符合規則
            Dim dicAESKey As Dictionary(Of String, Byte()) = IIf(saltType = FileCodec.SaltType.salt16, GeneratorRfc(), GeneratorRfc32())
            Dim btKey() As Byte = dicAESKey("KEY")
            Dim btIV() As Byte = dicAESKey("IV")

            Using AESprovider As AesCryptoServiceProvider = New AesCryptoServiceProvider()
                Using sha256Provider As SHA256CryptoServiceProvider = New SHA256CryptoServiceProvider()
                    Using md5Provider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
                        AESprovider.Key = sha256Provider.ComputeHash(btKey)
                        AESprovider.IV = md5Provider.ComputeHash(btIV)

                        Using encryptStream As New FileStream(encryptFile, FileMode.Open, FileAccess.Read)
                            Using decryptStream As New FileStream(decryptFile, FileMode.Create, FileAccess.Write)
                                Dim dataByteArray As Byte() = New Byte(encryptStream.Length - 1) {}
                                encryptStream.Read(dataByteArray, 0, dataByteArray.Length)
                                Using cs As New CryptoStream(decryptStream, AESprovider.CreateDecryptor(), CryptoStreamMode.Write)
                                    cs.Write(dataByteArray, 0, dataByteArray.Length)
                                    cs.FlushFinalBlock()
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try
    End Sub

#End Region

#Region "AES md5Provider(for Windows XP)"

    ''' <summary>
    ''' AES檔案加密(Key使用MD5Provider)
    ''' </summary>
    ''' <param name="inFullName">輸入檔案名稱(路徑+檔案名稱)</param>
    ''' <param name="outFullName">輸出檔案名稱(路徑+檔案名稱)</param>
    ''' <remarks></remarks>
    Public Shared Sub AESEncryptFileByMD5(ByVal inFullName As String, ByVal outFullName As String, Optional ByVal saltType As SaltType = SaltType.salt16)
        Try
            '使用密碼和 Salt 來衍生金鑰，不管打再長的密碼都會經過 Salt 亂數處理，以符合規則
            Dim dicAESKey As Dictionary(Of String, Byte()) = IIf(saltType = FileCodec.SaltType.salt16, GeneratorRfc(), GeneratorRfc32())
            Dim btKey() As Byte = dicAESKey("KEY")
            Dim btIV() As Byte = dicAESKey("IV")

            Using AESprovider As AesCryptoServiceProvider = New AesCryptoServiceProvider()
                Using md5Provider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
                    AESprovider.Key = md5Provider.ComputeHash(btKey)
                    AESprovider.IV = md5Provider.ComputeHash(btIV)
                    'Create the file streams to handle the input and output files.
                    Using sourceStream As New FileStream(inFullName, FileMode.Open, FileAccess.Read)
                        Using encryptStream As New FileStream(outFullName, FileMode.OpenOrCreate, FileAccess.Write)
                            '檔案加密
                            Dim dataByteArray As Byte() = New Byte(sourceStream.Length - 1) {}
                            sourceStream.Read(dataByteArray, 0, dataByteArray.Length)

                            Using cs As New CryptoStream(encryptStream, AESprovider.CreateEncryptor(), CryptoStreamMode.Write)
                                cs.Write(dataByteArray, 0, dataByteArray.Length)
                                cs.FlushFinalBlock()
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try

    End Sub

    ''' <summary>
    ''' AES檔案解密(Key使用MD5Provider)
    ''' </summary>
    ''' <param name="encryptFile">加密檔案(路徑+檔案名稱)</param>
    ''' <param name="decryptFile">解密檔案(路徑+檔案名稱)</param>
    ''' <remarks></remarks>
    Public Shared Sub AESDecryptFileByMD5(ByVal encryptFile As String, ByVal decryptFile As String, Optional ByVal saltType As SaltType = SaltType.salt16)
        Try
            '使用密碼和 Salt 來衍生金鑰，不管打再長的密碼都會經過 Salt 亂數處理，以符合規則
            Dim dicAESKey As Dictionary(Of String, Byte()) = IIf(saltType = FileCodec.SaltType.salt16, GeneratorRfc(), GeneratorRfc32())
            Dim btKey() As Byte = dicAESKey("KEY")
            Dim btIV() As Byte = dicAESKey("IV")

            Using AESprovider As AesCryptoServiceProvider = New AesCryptoServiceProvider()
                Using md5Provider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
                    AESprovider.Key = md5Provider.ComputeHash(btKey)
                    AESprovider.IV = md5Provider.ComputeHash(btIV)

                    Using encryptStream As New FileStream(encryptFile, FileMode.Open, FileAccess.Read)
                        Dim dataByteArray As Byte() = New Byte(encryptStream.Length - 1) {}
                        encryptStream.Read(dataByteArray, 0, dataByteArray.Length)

                        Dim decryptor As ICryptoTransform = AESprovider.CreateDecryptor()
                        Dim original As Byte() = decryptor.TransformFinalBlock(dataByteArray, 0, dataByteArray.Length)
                        File.WriteAllBytes(decryptFile, original)

                    End Using
                End Using
            End Using
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New FTMBusinessException("CMMCMMD001", ex)
        End Try

    End Sub
#End Region

#End Region

End Class
