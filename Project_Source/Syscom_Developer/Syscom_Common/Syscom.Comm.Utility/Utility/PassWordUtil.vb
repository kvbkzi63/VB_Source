'/*
'*****************************************************************************
'*
'*    Page/Class Name:  密碼的壓縮、解密相關功能
'*              Title:	PassWordUtil
'*        Description:	密碼的壓縮、解密
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2013-09-02
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2013-09-02
'*
'*****************************************************************************
'*/

Imports System.Security.Cryptography
Imports System.Text
Imports System.Reflection
Imports Syscom.Comm.EXP

Public Class PassWordUtil

    '主要金鑰
    Private Shared PrimaryKey As String = "abcdefgh"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 取得密碼的加密金鑰
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-9-2</remarks>
    Public Shared ReadOnly Property getPrimaryKey() As String
        Get
            Return PrimaryKey
        End Get
    End Property

    ''' <summary>
    ''' 密碼的加密相關功能
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-9-2 Copy from Lits</remarks>
    Public Shared Function Encrypt(ByVal pToEncrypt As String, ByVal sKey As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte
            inputByteArray = Encoding.Default.GetBytes(pToEncrypt)
            '建立加密對象的密鑰和偏移量
            '原文使用ASCIIEncoding.ASCII方法的GetBytes方法
            '使得輸入密碼必須輸入英文文本
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey)
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey)
            '寫二進制數組到加密流
            '(把內存流中的內容全部寫入)
            Dim ms As New System.IO.MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor, CryptoStreamMode.Write)
            '寫二進制數組到加密流
            '(把內存流中的內容全部寫入)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()

            '建立輸出字符串     
            Dim ret As New StringBuilder()
            Dim b As Byte
            For Each b In ms.ToArray()
                ret.AppendFormat("{0:X2}", b)
            Next

            Return ret.ToString()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 密碼的解密相關功能
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-9-2 Copy from Lits</remarks>
    Public Shared Function Decrypt(ByVal pToDecrypt As String, ByVal sKey As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim des As New DESCryptoServiceProvider()
            '把字符串放入byte數組
            Dim len As Integer
            len = pToDecrypt.Length / 2 - 1
            Dim inputByteArray(len) As Byte
            Dim x, i As Integer
            For x = 0 To len
                i = Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16)
                inputByteArray(x) = CType(i, Byte)
            Next
            '建立加密對象的密鑰和偏移量，此值重要，不能修改
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey)
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey)
            Dim ms As New System.IO.MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor, CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Encoding.Default.GetString(ms.ToArray)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

End Class

