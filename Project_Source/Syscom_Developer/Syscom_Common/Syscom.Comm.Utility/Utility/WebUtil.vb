Imports System.IO
Imports System.Reflection
Imports Syscom.Comm.EXP
Imports System.Text
Imports System.Net

Public Class WebUtil

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 呼叫外部系統API
    ''' </summary>
    ''' <param name="postUrl">呼叫外部系統API網址及傳入參數字串</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function doPost(ByVal postUrl As String) As String

        Dim resultStr As String = ""

        Try
            Dim postData As Byte() = Encoding.UTF8.GetBytes(postUrl)
            ' 將字串以UTF-8編碼轉換為byte[]
            Dim req As HttpWebRequest = DirectCast(HttpWebRequest.Create(postUrl), HttpWebRequest)
            ' 建立一個HttpWebRequest物件
            req.Method = "POST"
            ' 指定為POST
            req.ContentType = "application/x-www-form-urlencoded"
            ' 指定內容型態
            req.ContentLength = postData.Length
            ' 指定內容長度
            ' 提出要求
            Dim outputStream As Stream = req.GetRequestStream()
            outputStream.Write(postData, 0, postData.Length)
            outputStream.Close()
            ' 接收回應
            Dim response As HttpWebResponse = DirectCast(req.GetResponse(), HttpWebResponse)
            Dim responseStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(responseStream, Encoding.GetEncoding("utf-8"))
            ' 以UTF-8編碼接收傳回資料
            resultStr = reader.ReadToEnd()
            ' 傳回接收訊息，為JSON字串
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

        Return resultStr

    End Function

    ''' <summary>
    ''' 呼叫外部系統API
    ''' </summary>
    ''' <param name="inPostUrl">呼叫外部系統API網址</param>
    ''' <param name="inPostData">傳入已加密Base64參數字串</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function doPost(ByVal inPostUrl As String, ByVal inPostData As Byte()) As String

        Dim resultStr As String = ""

        Try

            ' 建立一個HttpWebRequest物件
            Dim req As HttpWebRequest = DirectCast(HttpWebRequest.Create(inPostUrl), HttpWebRequest)

            ' 指定為POST
            req.Method = "POST"

            '指定內容型態
            req.ContentType = "application/x-www-form-urlencoded"

            ' 指定內容長度
            req.ContentLength = inPostData.Length

            ' 提出要求
            Dim outputStream As Stream = req.GetRequestStream()
            outputStream.Write(inPostData, 0, inPostData.Length)
            outputStream.Close()

            ' 接收回應
            Dim response As HttpWebResponse = DirectCast(req.GetResponse(), HttpWebResponse)
            Dim responseStream As Stream = response.GetResponseStream()

            ' 以UTF-8編碼接收傳回資料
            Dim reader As New StreamReader(responseStream, Encoding.GetEncoding("utf-8"))

            ' 傳回接收訊息，為JSON字串
            resultStr = reader.ReadToEnd()

        Catch ex As Exception
            Throw ex
        End Try

        Return resultStr

    End Function

    ''' <summary>
    ''' 確認位置是否存在
    ''' </summary>
    ''' <param name="url">Ex: Http:// url </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckUrlExist(ByVal url As String) As Boolean
        Dim ExistBol As Boolean = False

        Try

            Dim ReqUrl As New System.Uri(url)
            Dim req As System.Net.WebRequest
            req = System.Net.WebRequest.Create(url)
            Dim resp As System.Net.WebResponse
            Try
                resp = req.GetResponse()
                resp.Close()
                req = Nothing
                ExistBol = True
            Catch ex As Exception
                req = Nothing
                ExistBol = False
            End Try

        Catch ex As Exception
            Throw ex
        End Try

        Return ExistBol
    End Function

End Class
