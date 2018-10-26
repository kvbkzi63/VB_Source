Option Explicit On
Imports System
Imports System.Collections
Public Module ColorUtil

    Private mRedColor As Integer = 192 '255
    Private mGreenColor As Integer = 192 '224
    Private mBlueColor As Integer = 192
    Public Function getRedColor() As Integer
        Return mRedColor
    End Function
    Public Function getGreenColor() As Integer
        Return mGreenColor
    End Function
    Public Function getBlueColor() As Integer
        Return mBlueColor
    End Function
    Public Property RedColor() As Integer
        Get
            Return mRedColor
        End Get
        Set(ByVal Value As Integer)
            mRedColor = Value
        End Set
    End Property
    Public Property GreenColor() As Integer
        Get
            Return mGreenColor
        End Get
        Set(ByVal Value As Integer)
            mGreenColor = Value
        End Set
    End Property
    Public Property BlueColor() As Integer
        Get
            Return mBlueColor
        End Get
        Set(ByVal Value As Integer)
            mBlueColor = Value
        End Set
    End Property

End Module