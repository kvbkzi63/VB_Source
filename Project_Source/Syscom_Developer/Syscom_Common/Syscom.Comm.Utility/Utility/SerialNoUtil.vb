Public Class SerialNoUtil

    Private Shared instance As SerialNoUtil

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As SerialNoUtil
        Try
            If (instance Is Nothing) Then
                instance = New SerialNoUtil
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return instance
    End Function

#Region "檢測"
    ''' <summary>
    ''' 是否合法領藥號序號
    ''' </summary>
    ''' <param name="PharmacySerialNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsLegalPharmacySerialNo(ByRef PharmacySerialNo As String) As Boolean

        If StringUtil.isStringContainsInfo(PharmacySerialNo) Then
            Dim SerialNo As String = PharmacySerialNo.Replace("-", "")
            Dim parseInt = 0

            Try
                parseInt = CType(SerialNo, Integer)
            Catch ex As Exception
                parseInt = 0
            End Try

            If parseInt > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

#End Region


End Class

