Imports System.IO
Imports System.Drawing
Imports System.Reflection
Imports Syscom.Comm.EXP
Imports System.Text
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class ImageTool

    Private Shared ReadOnly initialWidth As Int16 = 30  '預設縮圖寬
    Private Shared ReadOnly initialHeight As Int16 = 30 '預設縮圖高

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 根據檔名來判斷使用哪一種格式處理圖片
    ''' </summary>
    ''' <param name="fileName">檔名</param>
    ''' <returns>圖檔格式</returns>
    ''' <remarks></remarks>
    Public Shared Function getFormatByFileName(ByRef fileName As String) As Imaging.ImageFormat
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim result As Imaging.ImageFormat = Nothing
            Dim fileExtension = System.IO.Path.GetExtension(fileName).ToLower
            If IsImage(fileName) Then
                If ".jpg".Equals(fileExtension) Or ".jpeg".Equals(fileExtension) Then
                    result = Imaging.ImageFormat.Jpeg
                ElseIf ".bmp".Equals(fileExtension) Then
                    result = Imaging.ImageFormat.Bmp
                ElseIf ".tif".Equals(fileExtension) Or ".tiff".Equals(fileExtension) Then
                    result = Imaging.ImageFormat.Tiff
                ElseIf ".gif".Equals(fileExtension) Then
                    result = Imaging.ImageFormat.Gif
                ElseIf ".icon".Equals(fileExtension) Then
                    result = Imaging.ImageFormat.Icon
                ElseIf ".png".Equals(fileExtension) Then
                    result = Imaging.ImageFormat.Png
                ElseIf ".wmf".Equals(fileExtension) Then
                    result = Imaging.ImageFormat.Wmf
                ElseIf ".exif".Equals(fileExtension) Then
                    result = Imaging.ImageFormat.Exif
                ElseIf ".emf".Equals(fileExtension) Then
                    result = Imaging.ImageFormat.Emf
                End If
            End If
            Return result
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 根據副檔名來判斷使用哪一種格式處理圖片
    ''' </summary>
    ''' <param name="fileExtension">檔名</param>
    ''' <returns>圖檔格式</returns>
    ''' <remarks></remarks>
    Public Shared Function getFormatByFileExtension(ByRef fileExtension As String) As Imaging.ImageFormat
        Dim result As Imaging.ImageFormat = Nothing

        fileExtension = fileExtension.ToLower

        If "jpg".Equals(fileExtension) Or "jpeg".Equals(fileExtension) Then
            result = Imaging.ImageFormat.Jpeg
        ElseIf "bmp".Equals(fileExtension) Then
            result = Imaging.ImageFormat.Bmp
        ElseIf "tif".Equals(fileExtension) Or "tiff".Equals(fileExtension) Then
            result = Imaging.ImageFormat.Tiff
        ElseIf "gif".Equals(fileExtension) Then
            result = Imaging.ImageFormat.Gif
        ElseIf "icon".Equals(fileExtension) Then
            result = Imaging.ImageFormat.Icon
        ElseIf "png".Equals(fileExtension) Then
            result = Imaging.ImageFormat.Png
        ElseIf "wmf".Equals(fileExtension) Then
            result = Imaging.ImageFormat.Wmf
        ElseIf "exif".Equals(fileExtension) Then
            result = Imaging.ImageFormat.Exif
        ElseIf "emf".Equals(fileExtension) Then
            result = Imaging.ImageFormat.Emf
        End If

        Console.WriteLine(result)
        Return result
    End Function

    ''' <summary>
    ''' 判斷可否為.net讀取的圖檔格式
    ''' </summary>
    ''' <param name="fileName">檔案位置</param>
    ''' <returns>true 代表為可判讀的圖檔，false 反之</returns>
    ''' <remarks></remarks>
    Public Shared Function IsImage(ByRef fileName As String) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim imageFile As Image = Nothing
        Dim _fileExtension As String = System.IO.Path.GetExtension(fileName).ToLower
        '使用串流讀取在本機端的檔案，以避免檔案鎖定
        Try
            If fileName <> "" Then

                If _fileExtension = ".pdf" Then
                    Return False
                Else
                    Dim fs As New IO.FileStream(fileName, IO.FileMode.Open, IO.FileAccess.Read)
                    imageFile = Image.FromStream(fs)
                    fs.Close()
                    Return True
                End If
            Else
                Return False
            End If
        Catch fileEx As FileNotFoundException
            Return False
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        Finally
            If Not imageFile Is Nothing Then
                imageFile.Dispose()
                imageFile = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 取得縮圖，大小為預設
    ''' </summary>
    ''' <param name="fileName">檔案位置</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getThumbnailImage(ByRef fileName As String) As Image
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return getThumbnailImage(fileName, initialWidth, initialHeight)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 取得縮圖
    ''' </summary>
    ''' <param name="fileName">檔案位置</param>
    ''' <param name="width">縮圖寬</param>
    ''' <param name="height">縮圖高</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getThumbnailImage(ByRef fileName As String, ByRef width As Integer, ByRef height As Integer) As Image
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If IsImage(fileName) Then
                Dim image As Image = image.FromFile(fileName)
                Return getThumbnailImage(image, width, height)
            Else
                Return Nothing
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 取得縮圖，大小為預設
    ''' </summary>
    ''' <param name="image">image</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getThumbnailImage(ByRef image As Image) As Image
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return getThumbnailImage(image, initialWidth, initialHeight)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 取得縮圖
    ''' </summary>
    ''' <param name="image">image</param>
    ''' <param name="width">縮圖寬</param>
    ''' <param name="height">縮圖高</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getThumbnailImage(ByRef image As Image, ByRef width As Integer, ByRef height As Integer) As Image
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If Not image Is Nothing Then
                Return image.GetThumbnailImage(width, height, Nothing, IntPtr.Zero)
            Else
                Return Nothing
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 取得縮圖-新(等比例)
    ''' </summary>
    ''' <param name="OrigImage">原圖</param>
    ''' <param name="pWidth">縮圖寬</param>
    ''' <param name="pHeight">縮圖高</param>
    ''' <returns></returns>
    ''' <remarks>2013.05.08 add by Bella</remarks>
    Public Shared Function getThumbnailImageNew(ByRef OrigImage As Image, ByRef pWidth As Integer, ByRef pHeight As Integer) As Image
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            '取得原始大小
            Dim oldWidth As Integer = OrigImage.Width
            Dim oldHeight As Integer = OrigImage.Height

            '計算縮放比例
            Dim zWidth As Double
            Dim zHeight As Double
            Dim z As Double
            zWidth = (pWidth / oldWidth)
            zHeight = (pHeight / oldHeight)
            z = IIf((zWidth <= zHeight), zWidth, zHeight)
            oldWidth = z * oldWidth
            oldHeight = z * oldHeight

            '將圖重繪並壓縮
            Dim m_Image As New Bitmap(oldWidth, oldHeight)
            Dim g As Graphics = Graphics.FromImage(m_Image)
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.DrawImage(OrigImage, 0, 0, oldWidth, oldHeight)
            g.Dispose()
            OrigImage.Dispose()

            Return m_Image
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try

    End Function

    ''' <summary>
    ''' 將　Image 檔案內容 轉成　byte array
    ''' </summary>
    ''' <param name="fileName">目標 Image 檔名</param>
    ''' <remarks></remarks>
    Public Shared Function convertImageToByteArray(ByRef fileName As String) As Byte()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return convertImageToByteArray(fileName, getFormatByFileName(fileName))
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將　Image 檔案內容 轉成　byte array
    ''' </summary>
    ''' <param name="fileName">目標 Image 檔案</param>
    ''' <returns>byte array</returns>
    ''' <remarks></remarks>
    Public Shared Function convertImageToByteArray(ByRef fileName As String, ByRef ImageFormat As Imaging.ImageFormat) As Byte()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim result() As Byte = Nothing
            If IsImage(fileName) Then
                Dim img As Image = Image.FromFile(fileName)
                result = convertImageToByteArray(img, ImageFormat)
            End If

            Return result
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將　Image  轉成　byte array
    ''' </summary>
    ''' <param name="img">目標 Image</param>
    ''' <returns>byte array</returns>
    ''' <remarks></remarks>
    Public Shared Function convertImageToByteArray(ByRef img As Image, ByRef ImageFormat As Imaging.ImageFormat) As Byte()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim result() As Byte = Nothing
            If ImageFormat Is Nothing Then '判斷格式是否存在
                ImageFormat = Imaging.ImageFormat.Jpeg
            End If
            If Not img Is Nothing Then
                Dim ms As New MemoryStream
                img.Save(ms, ImageFormat)
                result = ms.ToArray
            End If

            Return result
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將　byte array  轉成　Image
    ''' </summary>
    ''' <param name="imgData">目標 byte array</param>
    ''' <returns>Image</returns>
    ''' <remarks></remarks>
    Public Shared Function convertByteArrayToImage(ByRef imgData As Byte()) As Image
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim result As Image = Nothing
            If (Not imgData Is Nothing) AndAlso imgData.Count > 0 Then
                Dim ms As New MemoryStream(imgData, 0, imgData.Length)
                ms.Write(imgData, 0, imgData.Length)
                result = Image.FromStream(ms, True)
            End If

            Return result
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#Region " 內部 - 重新調整圖形大小 "

    ''' <summary>
    ''' 重新調整圖形大小
    ''' </summary>
    ''' <param name="img">圖檔</param>
    ''' <param name="vintWidth">寬度</param>
    ''' <param name="vintHeight">高度</param>
    ''' <param name="resize">重新調整的比例</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ResizeImage(ByVal img As Image, ByVal vintWidth As Integer, ByVal vintHeight As Integer, _
                                      Optional ByVal resize As Integer = 100) As Image
        Try
            Dim width As Integer = vintWidth * CDbl(resize) / 100  'image width. 
            Dim height As Integer = vintHeight * CDbl(resize) / 100 'image height
            Dim thumb As New Bitmap(width, height)
            Dim g As Graphics = Graphics.FromImage(thumb)

            'g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, New Rectangle(0, 0, width, height), New Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel)
            Return thumb
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " 內部 - 重新調整圖形大小 From Bella"

    ''' <summary>
    ''' 重新調整圖形大小 From Bella
    ''' </summary>
    ''' <param name="imgPath">圖檔路徑</param> 
    ''' <returns></returns>
    ''' <remarks>Copy from Bella by Sean 2014-03-27</remarks>
    Private Shared Function ResizeImageBella(ByVal imgPath As String, ByVal img As Image, ByVal strChartNO As String, ByVal strCaseNO As String, ByVal strCREATEDATETIME As String, ByVal IntPicIndex As Integer) As Image
        Dim strError As New StringBuilder
        Try
            '縮圖的路徑
            Dim savePath As String = imgPath.Substring(0, imgPath.Length - 4) & "_Resize" & IntPicIndex & imgPath.Substring(imgPath.Length - 4 - 1)

            strError.AppendLine("Start  把圖讀進來")

            '2014-04-25 重前面的Method 傳入
            'Dim img As New Bitmap(imgPath) '把圖讀進來

            strError.AppendLine("End  把圖讀進來")

            Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
            'Dim bmpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Bmp)

            Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
            Dim myEncoderParameters As New EncoderParameters(1)
            Dim myEncoderParameter As New EncoderParameter(myEncoder, 50&) '壓縮品質%數
            myEncoderParameters.Param(0) = myEncoderParameter

            strError.AppendLine("Start  另存壓縮")

            img.Save(savePath, jgpEncoder, myEncoderParameters) '另存壓縮
            'img.Save(savePath, bmpEncoder, myEncoderParameters) '另存壓縮

            strError.AppendLine("End  另存壓縮")

            strError.AppendLine("Start  把壓完的圖片讀進來")

            'sean的話 把壓完的圖片(savePath)讀進來->轉byte->轉base64 夾入xml
            '把壓完的圖片讀進來
            Dim imgResize As New Bitmap(savePath)

            strError.AppendLine("End  把壓完的圖片讀進來")

            Return imgResize
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 編碼
    ''' </summary> 
    ''' <returns></returns>
    ''' <remarks>Copy from Bella by Sean 2014-03-27</remarks>
    Private Shared Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()
        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing
    End Function

#End Region

#Region "       Base64轉換"

    ''' <summary>
    ''' 將Image File轉為Base64字串
    ''' </summary>
    ''' <param name="srcFile">Image檔案來源</param>
    ''' <returns></returns>
    ''' <remarks>2013.10.15 add by Alan</remarks>
    Public Overloads Shared Function ImageToBase64(ByVal srcFile As String) As String
        Dim srcBT As Byte()
        Dim dest As String

        Dim sr As New IO.FileStream(srcFile, IO.FileMode.Open)

        ReDim srcBT(sr.Length)

        sr.Read(srcBT, 0, sr.Length)


        sr.Close()

        dest = System.Convert.ToBase64String(srcBT)

        Return dest
    End Function

    ''' <summary>
    ''' 將圖片轉成Base64字串
    ''' </summary>
    ''' <param name="image"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ImageToBase64(ByVal image As Image) As String
        Using stream As New MemoryStream()
            image.Save(stream, image.RawFormat)
            Return Convert.ToBase64String(stream.ToArray())
        End Using
    End Function

    ''' <summary>
    ''' 將Base64 轉回string
    ''' </summary>
    ''' <param name="strBase64"></param>
    ''' <returns></returns>
    ''' <remarks>2013.11.13 add by Bella</remarks>
    Public Shared Function Base64ToString(ByVal strBase64 As String) As String
        Dim newString As String = ""
        If StringUtil.nvl(strBase64).Length > 0 Then
            Dim b As Byte() = Convert.FromBase64String(strBase64)
            newString = System.Text.Encoding.UTF8.GetString(b)
        End If
        Return newString
    End Function

#End Region

#Region "       圖片比較"

    ''' <summary>
    ''' 將圖片轉成Byte()比較, 是否相同
    ''' </summary>
    ''' <param name="Img1"></param>
    ''' <param name="Img2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CompareImage(ByRef Img1 As Image, ByRef Img2 As Image) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim result As Boolean = False
            'If convertImageToByteArray(Img1, Img2.RawFormat).ToString = convertImageToByteArray(Img2, Img2.RawFormat).ToString Then
            '    result = True
            'End If
            If BitConverter.ToString(convertImageToByteArray(Img1, Img2.RawFormat)) = _
                BitConverter.ToString(convertImageToByteArray(Img2, Img2.RawFormat)) Then
                result = True
            End If

            Return result

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將圖片轉成Byte()比較, 是否相同
    ''' </summary>
    ''' <param name="fileName1"></param>
    ''' <param name="fileName2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CompareImage(ByVal fileName1 As String, ByVal fileName2 As String) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim result As Boolean = False

            If CompareImage(Image.FromFile(fileName1), Image.FromFile(fileName2)) Then
                result = True
            End If

            Return result

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region
    ''' <summary>
    ''' 將原圖縮圖後覆蓋原檔案後傳回路徑
    ''' </summary>
    ''' <param name="bmpPathFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function reSizeImgByFullPath(ByVal bmpPathFile As String, ByVal _width As Int32, ByVal _high As Int16) As String
        Try
            'Dim p As New StartProcess
            'If p.Start("convert.exe", " -density 200 -resize 264 " & bmpPathFile & " " & bmpPathFile, 5, False) = "" Then
            '    Return bmpPathFile
            'End If
            'Return bmpPathFile

            Dim bm As New System.Drawing.Bitmap(bmpPathFile)

            Dim width As Integer = _width    ' bm.Width - (bm.Width * 0.9) 'image width. 

            Dim height As Integer = _high  ' bm.Height - (bm.Height * 0.9)

            Dim thumb As New System.Drawing.Bitmap(width, height) '(132, 132)

            Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(thumb)

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear

            g.DrawImage(bm, New System.Drawing.Rectangle(0, 0, width, height), New System.Drawing.Rectangle(0, 0, bm.Width, bm.Height), System.Drawing.GraphicsUnit.Pixel)

            g.Dispose()


            If Not System.IO.Directory.Exists("C:\TempFile") Then System.IO.Directory.CreateDirectory("C:\TempFile")
            Dim newFile As String = "C:\TempFile\" & Date.Now.ToString("ddhhmmss") & ".jpg"
            'image path. better to make this dynamic. I am hardcoding a path just for example sake
            thumb.Save(newFile, System.Drawing.Imaging.ImageFormat.Jpeg) 'can use any image format 
            thumb.Dispose()

            bm.Dispose()

            System.IO.File.Copy(newFile, bmpPathFile, True)
            System.IO.File.Delete(newFile)

            Return bmpPathFile
        Catch ex As Exception
            Throw ex
        End Try


    End Function

End Class
