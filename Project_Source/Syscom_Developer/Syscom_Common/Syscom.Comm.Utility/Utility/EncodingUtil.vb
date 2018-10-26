Imports System.Text
Imports System.Reflection
Imports Syscom.Comm.EXP

Public Class EncodingUtil

    Public Shared defaultEncoder As Encoding = System.Text.Encoding.Default
    Public Shared unicodeEncoder As Encoding = System.Text.Encoding.Unicode
    Public Shared utf8Encoder As Encoding = System.Text.Encoding.UTF8

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 將 utf8 字串轉成 big5 字串
    ''' </summary>
    ''' <param name="inputString">utf8 字串</param>
    ''' <returns></returns>
    ''' <remarks>請確保輸入字串為 utf8 格式</remarks>
    Public Shared Function uftTobig5(ByRef inputString As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If inputString IsNot Nothing AndAlso inputString.Length > 0 Then '判斷字串不為空
                Return encodingTranslate(System.Text.Encoding.Unicode, System.Text.Encoding.GetEncoding("big5"), inputString)
            Else
                Return inputString
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將 big5 字串轉成 utf8 字串
    ''' </summary>
    ''' <param name="inputString">big5 字串</param>
    ''' <returns></returns>
    ''' <remarks>請確保輸入字串為 big5 格式</remarks>
    Public Shared Function big5Toutf8(ByRef inputString As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If inputString IsNot Nothing AndAlso inputString.Length > 0 Then '判斷字串不為空
                Return encodingTranslate(System.Text.Encoding.GetEncoding("big5"), System.Text.Encoding.Unicode, inputString)
            Else
                Return inputString
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將 A 格式編碼字串轉成 B 格式編碼字串
    ''' </summary>
    ''' <param name="srcEncoding">來源 格式編碼</param>
    ''' <param name="dstEncoding">目的地 格式編碼</param>
    ''' <param name="objectString">來源格式編碼字串</param>
    ''' <returns></returns>
    ''' <remarks>請確保輸入字串為來源格式編碼</remarks>
    Public Shared Function encodingTranslate(ByRef srcEncoding As Encoding, ByRef dstEncoding As Encoding, ByRef objectString As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If objectString IsNot Nothing AndAlso objectString.Length > 0 Then '判斷字串不為空
                Dim strByte As Byte() = srcEncoding.GetBytes(objectString) '取得原編碼字串的 byte array
                Dim dstByte As Byte() = System.Text.Encoding.Convert(srcEncoding, dstEncoding, strByte) '將原編碼字串的 byte array，轉換成所需的編碼
                Return dstEncoding.GetString(dstByte) '將所需編碼的 byte array 轉成 string
            Else
                Return objectString
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 字串轉byte陣列
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Str2ByteArray(ByRef str As String) As Byte()
        Dim encodeing As New ASCIIEncoding
        Return encodeing.GetBytes(str)
    End Function

    ''' <summary>
    ''' byte陣列轉字串
    ''' </summary>
    ''' <param name="byteAry"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ByteArray2Str(ByVal byteAry As Byte()) As String
        Dim encoding As New ASCIIEncoding
        Return encoding.GetString(byteAry)
    End Function


End Class
