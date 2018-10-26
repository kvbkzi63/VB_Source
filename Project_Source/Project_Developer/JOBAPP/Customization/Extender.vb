Imports System.Drawing
Imports Com.Syscom.WinFormsUI.Docking

Namespace Customization
	Public Class Extender
		Public Enum Schema
			VS2005
			VS2003
		End Enum

        'Private Class VS2003DockPaneStripFactory
        '	Implements DockPanelExtender.IDockPaneStripFactory
        '	Public Function CreateDockPaneStrip(pane As DockPane) As DockPaneStripBase
        '              Return New VS2003DockPaneStrip(pane)
        '	End Function
        'End Class

        'Private Class VS2003AutoHideStripFactory
        '	Implements DockPanelExtender.IAutoHideStripFactory
        '	Public Function CreateAutoHideStrip(panel As DockPanel) As AutoHideStripBase
        '		Return New VS2003AutoHideStrip(panel)
        '	End Function
        'End Class

        'Private Class VS2003DockPaneCaptionFactory
        '	Implements DockPanelExtender.IDockPaneCaptionFactory
        '	Public Function CreateDockPaneCaption(pane As DockPane) As DockPaneCaptionBase
        '		Return New VS2003DockPaneCaption(pane)
        '	End Function
        'End Class

		Public Shared Sub SetSchema(dockPanel As DockPanel, schema As Extender.Schema)
            'If schema = Extender.Schema.VS2005 Then
            '             dockPanel.Extender.AutoHideStripFactory = Nothing
            '             dockPanel.Extender.DockPaneCaptionFactory = Nothing
            '             dockPanel.Extender.DockPaneStripFactory = Nothing
            'ElseIf schema = Extender.Schema.VS2003 Then
            '             dockPanel.Extender.DockPaneCaptionFactory = New VS2003DockPaneCaptionFactory()
            '             dockPanel.Extender.AutoHideStripFactory = New VS2003AutoHideStripFactory()
            '             dockPanel.Extender.DockPaneStripFactory = New VS2003DockPaneStripFactory()
            'End If
		End Sub
	End Class
End Namespace
