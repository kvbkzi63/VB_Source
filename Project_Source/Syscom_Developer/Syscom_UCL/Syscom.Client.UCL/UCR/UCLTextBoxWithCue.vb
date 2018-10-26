Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

''' <summary>
''' TextBox with Cue Banner.
''' </summary>
''' <remarks></remarks>
Public Class UCLTextBoxWithCue
    Inherits TextBox

#Region "Fields"
    Private _bitmap As Bitmap
    Private _paintedFirstTime As Boolean = False

    Const WM_PAINT As Integer = &HF
    Const WM_PRINT As Integer = &H317

    Const PRF_CLIENT As Integer = &H4
    Const PRF_ERASEBKGND As Integer = &H8

    Private _cue As String
#End Region

#Region "Properties"
    <System.ComponentModel.Description("題示文字"), System.ComponentModel.Category("自定義屬性")> _
    Public Property Cue() As String
        Get
            Return _cue
        End Get
        Set(value As String)
            _cue = value
            Invalidate(True)
        End Set
    End Property

    Public Shadows Property BorderStyle() As BorderStyle
        Get
            Return MyBase.BorderStyle
        End Get
        Set(value As BorderStyle)
            If _paintedFirstTime Then
                SetStyle(ControlStyles.UserPaint, False)
            End If
            MyBase.BorderStyle = value
            If _paintedFirstTime Then
                SetStyle(ControlStyles.UserPaint, True)
            End If
        End Set
    End Property

    Public Overrides Property Multiline() As Boolean
        Get
            Return MyBase.Multiline
        End Get
        Set(value As Boolean)
            If _paintedFirstTime Then
                SetStyle(ControlStyles.UserPaint, False)
            End If
            MyBase.Multiline = value
            If _paintedFirstTime Then
                SetStyle(ControlStyles.UserPaint, True)
            End If
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()
        SetStyle(ControlStyles.UserPaint, False)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
    End Sub
#End Region

#Region "Functions"
    <DllImport("USER32.DLL", EntryPoint:="SendMessage")> _
    Public Shared Function SendMessage(hwnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr) As Integer
    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        If _bitmap IsNot Nothing Then
            _bitmap.Dispose()
        End If

        MyBase.Dispose(disposing)
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_PAINT Then
            _paintedFirstTime = True
            CaptureBitmap()
            SetStyle(ControlStyles.UserPaint, True)
            MyBase.WndProc(m)
            SetStyle(ControlStyles.UserPaint, False)
            Return
        End If

        MyBase.WndProc(m)
    End Sub

    Private Sub CaptureBitmap()
        If _bitmap IsNot Nothing Then
            _bitmap.Dispose()
        End If

        _bitmap = New Bitmap(Me.ClientRectangle.Width, Me.ClientRectangle.Height, PixelFormat.Format32bppArgb)

        Using graphics__1 = Graphics.FromImage(_bitmap)
            Dim lParam As Integer = PRF_CLIENT Or PRF_ERASEBKGND

            Dim hdc As System.IntPtr = graphics__1.GetHdc()
            SendMessage(Me.Handle, WM_PRINT, hdc, New IntPtr(lParam))
            graphics__1.ReleaseHdc(hdc)
        End Using
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        SetStyle(ControlStyles.UserPaint, True)
        If _bitmap Is Nothing Then
            e.Graphics.FillRectangle(Brushes.CornflowerBlue, ClientRectangle)
        Else
            e.Graphics.DrawImageUnscaled(_bitmap, 0, 0)
        End If

        If _cue IsNot Nothing AndAlso Text.Length = 0 Then
            e.Graphics.DrawString(_cue, Font, Brushes.Gray, -1.0F, 1.0F)
        End If

        SetStyle(ControlStyles.UserPaint, False)
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
        MyBase.OnKeyUp(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        If _paintedFirstTime Then
            SetStyle(ControlStyles.UserPaint, False)
        End If
        MyBase.OnFontChanged(e)
        If _paintedFirstTime Then
            SetStyle(ControlStyles.UserPaint, True)
        End If
    End Sub
#End Region

End Class
