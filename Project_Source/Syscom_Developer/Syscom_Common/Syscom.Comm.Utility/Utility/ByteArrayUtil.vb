Imports System.Reflection
Imports Syscom.Comm.EXP

Public Class ByteArrayUtil

    Public Shared ReadOnly appendToLeft As Boolean = True
    Public Shared ReadOnly appendToRight As Boolean = False

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 取得 byte array 的 sub array
    ''' EX:getByteArray( {0,1,2,3,4,5,6,7} ,2 ,4 ) ==>  {2,4}
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="startIndex"></param>
    ''' <param name="endIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getByteArray(ByVal data As Byte(), ByVal startIndex As Integer, ByVal endIndex As Integer) As Byte()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim result(endIndex - startIndex) As Byte
            Dim rIndex = 0
            For i = startIndex To endIndex
                result(rIndex) = data(i)
                rIndex += 1
            Next
            Return result
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function
    ''' <summary>
    ''' 取得 byte array 的 sub array ,並轉成　String
    ''' EX:getByteArray( {"A","B","C","D","E"} ,0 ,1 ) ==>  {"A","B"}  ==> "AB"
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="startIndex"></param>
    ''' <param name="endIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getByteArrayToString(ByVal data As Byte(), ByVal startIndex As Integer, ByVal endIndex As Integer) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim result As String
            result = EncodingUtil.defaultEncoder.GetString(getByteArray(data, startIndex, endIndex))
            Return result
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function
    ''' <summary>
    ''' 取得 byte array 的 sub array ,並轉成　Integer
    ''' EX:getByteArray( {14, 205, 117, 1, 1} ,0 ,2 ,true) ==>  {14, 205, 117}  ==> 970101
    ''' EX:getByteArray( {"1", "0", "9", "0", "0"} ,0 ,2 ,false) ==>  {"1", "0", "9"}  ==> 109
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="startIndex"></param>
    ''' <param name="endIndex"></param>
    ''' <param name="isComp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getByteArrayToInteger(ByVal data As Byte(), ByVal startIndex As Integer, ByVal endIndex As Integer, ByVal isComp As Boolean) As Integer
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If isComp Then
                Return getCompToInteger(getByteArray(data, startIndex, endIndex))
            Else
                Return Integer.Parse(getByteArrayToString(data, startIndex, endIndex))
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function
    ''' <summary>
    ''' 取得 byte array 的 sub array ,並轉成　Decimal
    ''' EX:getByteArray( {"1", "1", "5", 1, 1} ,0 ,2 , 2, 1 ) ==>  {"1", "1", "5"} 再取　{"1","1"} + "." + {"5"} ==> 11.5
    ''' EX:getByteArray( {"1", "1", "5", 1, 1} ,0 ,2 , 1, 1 ) ==>  {"1", "1", "5"} 再取　{"1"} + "." + {"1"}     ==>  1.1
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="startIndex"></param>
    ''' <param name="endIndex"></param>
    ''' <param name="iLength"></param>
    ''' <param name="dLength"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getByteArrayToDecimal(ByVal data As Byte(), ByVal startIndex As Integer, ByVal endIndex As Integer, ByVal iLength As Integer, ByVal dLength As Integer) As Decimal
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim calArray() As Byte = getByteArray(data, startIndex, endIndex)
            Dim calString = getByteArrayToString(calArray, 0, iLength - 1) & "." & getByteArrayToString(calArray, iLength, iLength + dLength - 1)
            Return Decimal.Parse(calString)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function
    ''' <summary>
    ''' 將 Comp 值 轉成Integer
    ''' EX: getCompToInteger( {14, 205, 117} ) ==> 970101
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks>Last modified by Ken at 20090226</remarks>
    Public Shared Function getCompToInteger(ByVal data As Byte()) As Integer
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Array.Reverse(data)
            Dim result As Int64 = 0
            Dim base As Int64 = 1
            For i = 0 To data.Length - 1
                result += (data(i) * base)
                base *= 256
            Next
            Dim _tmpStr = result.ToString
            Return Int32.Parse(_tmpStr)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' Transform COMP into Int64
    ''' </summary>
    ''' <param name="data">byte array of COMP</param>
    ''' <returns>the original data before COMP</returns>
    ''' <remarks>Edit by Ken</remarks>
    Public Shared Function getCompToInt64(ByVal data As Byte()) As Int64
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Array.Reverse(data)
            Dim result As Int64 = 0
            Dim base As Int64 = 1
            For i = 0 To data.Length - 1
                result += (data(i) * base)
                base *= 256
            Next
            Return result
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 同StringUtil的appendChar 只是以Byte Array來處理　包含固定長度　也是指 byte attary 長度
    ''' </summary>
    ''' <param name="byteArray"></param>
    ''' <param name="apdChar"></param>
    ''' <param name="totalLength"></param>
    ''' <param name="appendDirection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function appendCharWithByteArray(ByVal byteArray As Byte(), ByVal apdChar As Char, ByVal totalLength As Integer, ByVal appendDirection As Boolean) As Byte()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim resultArray() As Byte = byteArray
            If byteArray.Length > totalLength Then
                resultArray = getByteArray(byteArray, 0, totalLength - 1)
            ElseIf byteArray.Length < totalLength Then
                ReDim resultArray(totalLength - 1)
                If appendDirection = appendToLeft Then

                    For i = 0 To resultArray.Length - 1

                        If i < totalLength - byteArray.Length Then
                            resultArray(i) = CByte(Asc(apdChar))
                        Else
                            resultArray(i) = byteArray(i - (totalLength - byteArray.Length))
                        End If
                    Next
                Else 'appendToRight
                    For i = 0 To resultArray.Length - 1
                        If i < byteArray.Length Then
                            resultArray(i) = byteArray(i)
                        Else
                            resultArray(i) = CByte(Asc(apdChar))
                        End If
                    Next
                End If
            End If
            Return resultArray
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function
    ''' <summary>
    ''' 取得數值轉 Comp 的 byte array
    ''' EX: getIntegerToComp(970101,4)  => byte{0,14,205,117}    or   getIntegerToComp(970101,3)  => byte{14,205,117}
    ''' 注意　COBOL 宣告　PIC S9(04) COMP ，在這裡的 compLength 為　2
    ''' </summary>
    ''' <param name="srcInteger"></param>
    ''' <param name="compLength"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getIntegerToComp(ByVal srcInteger As Integer, ByVal compLength As Integer) As Byte()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim result As ArrayList = New ArrayList
            '取得所有餘數，裝入ArrayList
            While srcInteger > 0
                result.Add(srcInteger Mod 256)
                srcInteger = srcInteger \ 256
            End While

            '超過指定長度，輸出 Exception
            If compLength < result.Count Then
                Throw New Exception("Over Comp Length Value")
            End If

            '將ArrayList的餘數，倒裝到 resultByteArray
            Dim resultByteArray(compLength - 1) As Byte
            Dim rIndex = compLength - 1
            For i = 0 To result.Count - 1
                resultByteArray(rIndex) = CByte(CType(result.Item(i), Integer))
                rIndex -= 1
            Next

            Return resultByteArray
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function
    ''' <summary>
    ''' 接合 byte array
    ''' appendArray( {1,2,3} , {A,B,C} )  ==> {1,2,3,A,B,C}
    ''' </summary>
    ''' <param name="srcArray"></param>
    ''' <param name="apdArray"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function appendArray(ByVal srcArray As Byte(), ByVal apdArray As Byte()) As Byte()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim fArray(srcArray.Length + apdArray.Length - 1) As Byte
            For i = 0 To srcArray.Length - 1
                fArray(i) = srcArray(i)
            Next
            For i = 0 To apdArray.Length - 1
                fArray(srcArray.Length + i) = apdArray(i)
            Next
            Return fArray
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function
    ''' <summary>
    ''' 調整 byte array 長度
    ''' fixByteArray( {1,2,3,4,5} , 2 ) ==> {1,2}
    ''' fixByteArray( {1,2,3,4,5} , 7 ) ==> {1,2,3,4,5,0,0}
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <param name="fixLength"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fixByteArray(ByVal bytes As Byte(), ByVal fixLength As Integer) As Byte()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim newByteArray(fixLength - 1) As Byte
            Dim maxLength As Integer = bytes.Length
            If fixLength < bytes.Length Then
                maxLength = fixLength
            End If
            For i = 0 To maxLength - 1
                newByteArray(i) = bytes(i)
            Next
            Return newByteArray
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

End Class
