
'*********************************************************************************************
'*    Page/Class Name:  RichTextBox
'*              Title:	RichTextBox
'*        Description:	共用元件
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	James
'*        Create Date:	2009/04/23
'*********************************************************************************************

Imports Syscom.Comm.Utility
Public Class UCLRichTextBoxUC

#Region "     變數宣告 "

    Private MaxLength As Integer = 200  '字串最大Bytes

    Private _Text As String
    Private _uclReadOnly As Boolean = False
    Private _uclWordWrap As Boolean = False
    Private _BackColor As Color = Color.White
    Private _ForeColor As Color = Color.Black

#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數)  "

    ''' <summary>
    ''' 設定背景顏色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property BackColor() As Color
        Get
            Return TextBox1.BackColor
        End Get
        Set(ByVal value As Color)
            TextBox1.BackColor = value
        End Set
    End Property
    ''' <summary>
    ''' 設定前景顏色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property ForeColor() As Color
        Get
            Return TextBox1.ForeColor
        End Get
        Set(ByVal value As Color)
            TextBox1.ForeColor = value
        End Set
    End Property

    ''' <summary>
    ''' 取得控制項内的文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property Text() As String
        Get
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property
    ''' <summary>
    ''' 設定控制項的可輸入總長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclMaxLength() As Integer
        Get
            Return TextBox1.MaxLength
        End Get
        Set(ByVal value As Integer)
            TextBox1.MaxLength = value
        End Set
    End Property
    ''' <summary>
    ''' 設定多行控制項是否唯讀
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclReadOnly() As Boolean
        Get
            Return TextBox1.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            TextBox1.ReadOnly = value
        End Set
    End Property
    ''' <summary>
    ''' 設定多行控制項是否會自動換行
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclWordWrap() As Boolean
        Get
            Return TextBox1.WordWrap
        End Get
        Set(ByVal value As Boolean)
            TextBox1.WordWrap = value
        End Set
    End Property

#End Region

End Class
