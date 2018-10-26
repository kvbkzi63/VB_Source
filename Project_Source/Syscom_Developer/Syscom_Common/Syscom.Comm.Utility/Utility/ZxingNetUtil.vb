Imports ZXing
Imports ZXing.QrCode.Internal
Imports System.Drawing

Public Class ZxingNetUtil
    Dim gblQRString As String = ""
    Dim gblPageNo As Integer = 1

    ''' <summary>
    ''' 產生QR Code圖形檔
    ''' </summary>
    ''' <param name="inQRString">來源內容字串</param>
    ''' <param name="inMaxLength">QR Code最大字串長度：建議用1024 Bytes</param>
    ''' <param name="inErrorCorrectionLevel">容錯等級: L(7%) , M(15%) , Q(25%) ,H(30%) </param>
    ''' <param name="inCharacterSet">字元集: "ISO-8859-1" , "UTF-8" </param>
    ''' <param name="inHW">圖檔長寬</param>
    ''' <param name="inNextStr">換頁符號</param>
    ''' <param name="inEndStr">結束符號</param>     
    ''' <returns></returns>
    ''' <History>Created by Alan in 2013-10-22  </History>
    ''' <Remark></Remark>
    Public Function EncodeProcess(ByVal inQRString As String, ByVal inMaxLength As Integer, _
                                  ByVal inErrorCorrectionLevel As String, ByVal inCharacterSet As String, _
                                  ByVal inHW As Integer, ByVal inNextStr As String, ByVal inEndStr As String) As ArrayList

        Dim Imagedata As New ArrayList

        Dim writer As New ZXing.QrCode.QRCodeWriter()

        Dim hints As New Dictionary(Of EncodeHintType, Object)()

        'hints.Add(EncodeHintType.AZTEC_LAYERS, inVersion)

        hints.Add(EncodeHintType.HEIGHT, inHW)

        hints.Add(EncodeHintType.WIDTH, inHW)

        Select Case inErrorCorrectionLevel
            Case "L"
                hints.Add(EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.L)

            Case "M"
                hints.Add(EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.M)

            Case "Q"
                hints.Add(EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.Q)

            Case "H"
                hints.Add(EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.H)

        End Select

        hints.Add(EncodeHintType.CHARACTER_SET, inCharacterSet)

        hints.Add(EncodeHintType.MARGIN, 0)


        Dim StrArrayList As New ArrayList

        '切割字串
        StrArrayList = CutPrintMultiLines(inQRString, inMaxLength)

        For i = 1 To StrArrayList.Count

            Dim renderer As New ZXing.Rendering.BitmapRenderer
            Dim matrix As ZXing.Common.BitMatrix
            Dim bitmap As Bitmap
            Dim processStr As String = ""

            '讀取字串
            '2014-02-14 判斷若有傳入換頁符號時，才需加頁次
            If inNextStr <> "" Then
                If i <> StrArrayList.Count Then
                    processStr = StrArrayList(i - 1).ToString & inNextStr & i
                Else
                    processStr = StrArrayList(i - 1).ToString & inEndStr & i
                End If
            Else
                If i <> StrArrayList.Count Then
                    processStr = StrArrayList(i - 1).ToString
                Else
                    processStr = StrArrayList(i - 1).ToString
                End If
            End If
            
            matrix = writer.encode(processStr, BarcodeFormat.QR_CODE, inHW, inHW, hints)
            bitmap = renderer.Render(matrix, BarcodeFormat.QR_CODE, processStr)

            Imagedata.Add(bitmap)

        Next

        Return Imagedata

    End Function

    Public Function CutPrintMultiLines(ByVal vstrData As String, ByVal vintCountPerLine As Integer) As ArrayList
        Dim aryLines() As String = Split(vstrData, vbCrLf)
        Dim strT As String
        Dim colLine As New Collection
        Dim returnStr As New ArrayList
        For Each strT In aryLines
            Dim intLen As Integer, i As Integer
            intLen = 0
            strT = strT.ToString.TrimStart
            Do While True
                For i = 1 To strT.Length
                    If Math.Abs(AscW(Mid(strT, i, 1))) > 255 Then '非英文字寬度是2
                        intLen = intLen + 2
                    Else
                        intLen = intLen + 1
                    End If

                    If intLen > vintCountPerLine Then
                        Dim strTemp As String
                        strTemp = Mid(strT, 1, i - 1)
                        If Math.Abs(AscW(Microsoft.VisualBasic.Right(strTemp, 1))) > 255 Then '最後一字是中文可斷行
                            strT = Mid(strT, i)
                        ElseIf AscW(Mid(strT, i, 1)) = 32 Or Math.Abs(AscW(Mid(strT, i, 1))) > 255 Then '下一字是空白或中文，可斷行 
                            strT = Mid(strT, i)
                        Else '最後一字是英文，且下一個字不是空白與中文，代表不能斷行
                            Dim k As Integer
                            For k = strTemp.Length To 1 Step -1
                                If AscW(Mid(strTemp, k, 1)) = 32 Or Math.Abs(AscW(Mid(strTemp, k, 1))) > 255 Then '遇上空白或中文字
                                    Exit For
                                End If
                            Next
                            If k = 0 Then '向前找沒有找到中文或Space，只好斷行
                                k = vintCountPerLine
                            End If
                            strTemp = Mid(strTemp, 1, k)
                            strT = Mid(strT, k + 1)
                        End If
                        colLine.Add(strTemp)
                        intLen = 0
                        Exit For
                    End If
                Next
                If intLen <> 0 Or strT.Length = 0 Then
                    colLine.Add(strT)
                    Exit Do
                End If
            Loop
        Next

        Dim j As Integer
        For j = 0 To colLine.Count - 1
            returnStr.Add(If(Mid(colLine.Item(j + 1), 1, 1) = " ", Mid(colLine.Item(j + 1), 2), colLine.Item(j + 1)))
        Next

        Return returnStr
    End Function

    ''' <summary>
    ''' QR Code圖形檔解碼
    ''' </summary>
    ''' <param name="inQRBitmap">QR Code圖形檔Bitmap</param>    
    ''' <returns></returns>
    ''' <History>Created by Alan in 2014-02-14  </History>
    ''' <Remark></Remark>
    Public Function DecodeProcess(ByVal inQRBitmap As Bitmap) As String
        ' create a barcode reader instance
        Dim reader As IBarcodeReader = New BarcodeReader()
        ' load a bitmap
        Dim barcodeBitmap = inQRBitmap 'DirectCast(Bitmap.FromFile("C:\Temp\Pic" & gblPageNo & ".jpg"), Bitmap)
        ' detect and decode the barcode inside the bitmap
        Dim result = reader.Decode(barcodeBitmap)
        ' do something with the result
        If result Is Nothing Then
            Return ""
        Else
            Return result.ToString
        End If

    End Function

End Class
