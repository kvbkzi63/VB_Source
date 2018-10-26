Imports System.Text
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility
Imports System.Data.SqlClient
Imports Syscom.Comm.LOG
Imports Syscom.Comm.EXP
Imports Syscom.Comm.BASE
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Reflection
Imports Syscom.Client.CMM

Public Class PUBCheckIdNoBP

    Dim pub As IPubServiceManager = PubServiceManager.getInstance
 
    '檢查證號
    Public Function CheckIdNo(ByVal strIdNo As String, ByRef outputIdNo As String, Optional ByVal chkFlag As Integer = 0) As Integer

        Try

            If strIdNo.Length = 0 OrElse (strIdNo.Length = 11 AndAlso strIdNo.Substring(10, 1).ToUpper.Trim = "P") Then
                outputIdNo = strIdNo
                Return 0

            End If
 
            If strIdNo.Length = 10 AndAlso Asc(strIdNo.Substring(0, 1).ToUpper) >= 65 AndAlso Asc(strIdNo.Substring(0, 1).ToUpper) <= 90 AndAlso _
              (strIdNo.Substring(1, 1) = "1" OrElse strIdNo.Substring(1, 1) = "2") AndAlso IsNumeric(strIdNo.Substring(2, 8)) Then

   
                Dim ds As DataSet = Nothing

                If chkFlag <> 0 Then
                    'chkFlag：0不檢查(預設)； >0要檢查
                    ds = pub.queryPubPatientByIdno(strIdNo)
                End If


                If ds IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                    'outputIdNo = strIdNo + 第11碼填 'P’ (中間補空白)
                    'Return 88(統號與目前病歷號重複)

                    If checkId(strIdNo) Then
                        outputIdNo = strIdNo
                        Return 0 ' (統號OK)
                    Else
                        outputIdNo = strIdNo & "P"
                        Return 88
                    End If

                Else

                    If checkId(strIdNo) Then

                        outputIdNo = strIdNo
                        Return 0 ' (統號OK)
                    Else
                        outputIdNo = strIdNo & "P"
                        Return 99 ' (統號不合邏輯)

                    End If

                End If


                Else

                    If strIdNo.Trim.Length < 10 Then

                        For i As Integer = strIdNo.Trim.Length To 9
                            strIdNo = strIdNo & " "
                        Next

                    End If

                    outputIdNo = strIdNo & "P"

                    Return 77 ' (不為統號)

                End If

        Catch ex As Exception

            Return -1
        End Try




    End Function
 
    ''' <summary>
    ''' 身分證號檢驗 
    ''' id:身分證號
    ''' </summary>
    ''' <returns>True:身分證合格  False:身分證號不合格</returns>
    ''' <remarks></remarks>''' 
    Private Function checkId(ByVal id As String) As Boolean
        Try
 
            Dim idvalue As Integer, checkvalue As Integer

            If id.Length <> 10 Then
                Return False
            End If


            idvalue = Int(getCountyCode(Microsoft.VisualBasic.Left(id, 1)) / 10)
            idvalue = idvalue + (getCountyCode(Microsoft.VisualBasic.Left(id, 1)) Mod 10) * 9


            For i = 2 To 9
                idvalue = idvalue + Mid(id, i, 1) * (10 - i)
            Next

            checkvalue = (10 - (idvalue Mod 10)) Mod 10

            If (checkvalue = Microsoft.VisualBasic.Right(id, 1)) Then
                Return True
            Else

                Return False
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    ''' <summary>
    ''' 取得地區號 身分證驗證用
    ''' country:身分證號字母
    ''' </summary>
    ''' <returns>地區號</returns>
    ''' <remarks></remarks>''' 
    Private Function getCountyCode(ByVal county As String) As Integer
        Select Case UCase(county)
            Case "A" : getCountyCode = 10
            Case "B" : getCountyCode = 11
            Case "C" : getCountyCode = 12
            Case "D" : getCountyCode = 13
            Case "E" : getCountyCode = 14
            Case "F" : getCountyCode = 15
            Case "G" : getCountyCode = 16
            Case "H" : getCountyCode = 17
            Case "J" : getCountyCode = 18
            Case "K" : getCountyCode = 19
            Case "L" : getCountyCode = 20
            Case "M" : getCountyCode = 21
            Case "N" : getCountyCode = 22
            Case "P" : getCountyCode = 23
            Case "Q" : getCountyCode = 24
            Case "R" : getCountyCode = 25
            Case "S" : getCountyCode = 26
            Case "T" : getCountyCode = 27
            Case "U" : getCountyCode = 28
            Case "V" : getCountyCode = 29
            Case "W" : getCountyCode = 32
            Case "X" : getCountyCode = 30
            Case "Y" : getCountyCode = 31
            Case "Z" : getCountyCode = 33
            Case "I" : getCountyCode = 34
            Case "O" : getCountyCode = 35
        End Select
    End Function

End Class
