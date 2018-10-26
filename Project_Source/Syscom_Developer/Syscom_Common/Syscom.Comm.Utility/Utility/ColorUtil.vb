Imports System.Drawing

Public Class ColorUtil

    ''' <summary>
    ''' 取得顏色
    ''' </summary>
    ''' <param name="ColorValue"></param>
    ''' <param name="DefaultColor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetColor(ByVal ColorValue As String, Optional ByVal DefaultColor As String = "White") As Color

        Try

            Dim _rtnValue As Color = Color.FromName(DefaultColor)

            '===Color.RGB 1. RGB = 255,255,255
            '===Color.Name 2. Black or Red....
            'Public Shared ReadOnly Sign_Spilt As String = ";"
            If ColorValue.IndexOf(";") > -1 Then

                Dim _color() As String = ColorValue.Split(";")
                If _color.Length = 3 Then
                    _rtnValue = Color.FromArgb(_color(0), _color(1), _color(2))
                End If

            Else

                _rtnValue = Color.FromName(ColorValue)

            End If

            Return _rtnValue

        Catch ex As Exception
            Throw New Exception("取得顏色失敗!", ex)
        End Try

    End Function

    ''' <summary>
    ''' 取得顏色RGB
    ''' </summary>
    ''' <param name="_color"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetColorRGB(ByRef _color As Color) As String
        Try
            Return _color.R & ";" & _color.G & ";" & _color.B
        Catch ex As Exception
            Throw New Exception("取得顏色RGB失敗!!", ex)
        End Try
    End Function

End Class
