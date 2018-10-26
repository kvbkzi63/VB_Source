Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.Design.SelectionRules


Public Class FixedHeightControlDesigner
    Inherits System.Windows.Forms.Design.ControlDesigner

    Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
        Get
            Return LeftSizeable Or RightSizeable Or Moveable Or Visible
        End Get
    End Property
End Class