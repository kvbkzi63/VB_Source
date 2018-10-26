Imports System.Drawing
Imports System.Windows.Forms
Imports Com.Syscom.WinFormsUI.Docking

Namespace Customization
	Friend Class DockHelper
		Public Shared Function IsDockStateAutoHide(dockState__1 As DockState) As Boolean
			If dockState__1 = DockState.DockLeftAutoHide OrElse dockState__1 = DockState.DockRightAutoHide OrElse dockState__1 = DockState.DockTopAutoHide OrElse dockState__1 = DockState.DockBottomAutoHide Then
				Return True
			Else
				Return False
			End If
		End Function

		Public Shared Function IsDockStateDocked(dockState__1 As DockState) As Boolean
			Return (dockState__1 = DockState.DockLeft OrElse dockState__1 = DockState.DockRight OrElse dockState__1 = DockState.DockTop OrElse dockState__1 = DockState.DockBottom)
		End Function

		Public Shared Function IsDockBottom(dockState__1 As DockState) As Boolean
			Return If((dockState__1 = DockState.DockBottom OrElse dockState__1 = DockState.DockBottomAutoHide), True, False)
		End Function

		Public Shared Function IsDockLeft(dockState__1 As DockState) As Boolean
			Return If((dockState__1 = DockState.DockLeft OrElse dockState__1 = DockState.DockLeftAutoHide), True, False)
		End Function

		Public Shared Function IsDockRight(dockState__1 As DockState) As Boolean
			Return If((dockState__1 = DockState.DockRight OrElse dockState__1 = DockState.DockRightAutoHide), True, False)
		End Function

		Public Shared Function IsDockTop(dockState__1 As DockState) As Boolean
			Return If((dockState__1 = DockState.DockTop OrElse dockState__1 = DockState.DockTopAutoHide), True, False)
		End Function

		Public Shared Function IsDockStateValid(dockState__1 As DockState, dockableAreas As DockAreas) As Boolean
			If ((dockableAreas And DockAreas.Float) = 0) AndAlso (dockState__1 = DockState.Float) Then
				Return False
			ElseIf ((dockableAreas And DockAreas.Document) = 0) AndAlso (dockState__1 = DockState.Document) Then
				Return False
			ElseIf ((dockableAreas And DockAreas.DockLeft) = 0) AndAlso (dockState__1 = DockState.DockLeft OrElse dockState__1 = DockState.DockLeftAutoHide) Then
				Return False
			ElseIf ((dockableAreas And DockAreas.DockRight) = 0) AndAlso (dockState__1 = DockState.DockRight OrElse dockState__1 = DockState.DockRightAutoHide) Then
				Return False
			ElseIf ((dockableAreas And DockAreas.DockTop) = 0) AndAlso (dockState__1 = DockState.DockTop OrElse dockState__1 = DockState.DockTopAutoHide) Then
				Return False
			ElseIf ((dockableAreas And DockAreas.DockBottom) = 0) AndAlso (dockState__1 = DockState.DockBottom OrElse dockState__1 = DockState.DockBottomAutoHide) Then
				Return False
			Else
				Return True
			End If
		End Function

		Public Shared Function IsDockWindowState(state As DockState) As Boolean
			If state = DockState.DockTop OrElse state = DockState.DockBottom OrElse state = DockState.DockLeft OrElse state = DockState.DockRight OrElse state = DockState.Document Then
				Return True
			Else
				Return False
			End If
		End Function

		Public Shared Function IsValidRestoreState(state As DockState) As Boolean
			If state = DockState.DockLeft OrElse state = DockState.DockRight OrElse state = DockState.DockTop OrElse state = DockState.DockBottom OrElse state = DockState.Document Then
				Return True
			Else
				Return False
			End If
		End Function

		Public Shared Function ToggleAutoHideState(state As DockState) As DockState
			If state = DockState.DockLeft Then
				Return DockState.DockLeftAutoHide
			ElseIf state = DockState.DockRight Then
				Return DockState.DockRightAutoHide
			ElseIf state = DockState.DockTop Then
				Return DockState.DockTopAutoHide
			ElseIf state = DockState.DockBottom Then
				Return DockState.DockBottomAutoHide
			ElseIf state = DockState.DockLeftAutoHide Then
				Return DockState.DockLeft
			ElseIf state = DockState.DockRightAutoHide Then
				Return DockState.DockRight
			ElseIf state = DockState.DockTopAutoHide Then
				Return DockState.DockTop
			ElseIf state = DockState.DockBottomAutoHide Then
				Return DockState.DockBottom
			Else
				Return state
			End If
		End Function
	End Class
End Namespace
