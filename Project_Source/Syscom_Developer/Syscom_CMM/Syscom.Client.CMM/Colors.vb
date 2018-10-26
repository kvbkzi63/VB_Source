Imports System.Drawing
Public Class Colors

    '''當畫面上有錯誤輸入時將背景顏色替換掉
    Public Shared BACK_COLOR_ERROR_INPUT As Color = Color.Pink
    '''畫面上輸入的預設顏色
    Public Shared BACK_COLOR_DEFAULT As Color = SystemColors.Control

    '''輸入元件的預設顏色
    Public Shared BACK_COLOR_DEFAULT_INPUT As Color = SystemColors.Window
    '''一般字的預設顏色
    Public Shared FORE_COLOR_DEFAULT As Color = SystemColors.ControlText
    '''必輸的顏色
    Public Shared FORE_COLOR_PKEY As Color = Color.Red

    Private Sub New()
    End Sub
End Class
