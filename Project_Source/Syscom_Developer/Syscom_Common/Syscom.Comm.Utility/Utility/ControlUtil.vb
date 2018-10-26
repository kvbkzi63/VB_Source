Imports System.Windows.Forms
Imports System.Drawing

Public Module ControlUtil

    ''' <summary>
    ''' 傳回System.Collections.Generic.IEnumerable(Of T)物件，其中泛型參數T為System.Windows.Forms.Control。這個物件可以在LINQ運算式或方法查詢中使用
    ''' </summary>
    ''' <param name="controls"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension> _
    Public Iterator Function AsEnumerable(controls As System.Windows.Forms.Control.ControlCollection) As System.Collections.Generic.IEnumerable(Of System.Windows.Forms.Control)

        For Each child As System.Windows.Forms.Control In controls
            Yield child
        Next

    End Function

    ''' <summary>
    ''' 此Control是否為Type T
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="control"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension> _
    Public Function IsTypeOf(Of T)(control As System.Windows.Forms.Control) As Boolean

        Return control.GetType Is GetType(T)
    End Function

    ''' <summary>
    ''' 檢查座標是否落在 Control 中
    ''' </summary>
    ''' <param name="_ctrl"></param>
    ''' <param name="_point"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckLocRange(ByRef _ctrl As Control, ByVal _point As Point) As Boolean

        Try

            Dim _p2 As Point = _ctrl.PointToClient(_point)

            Dim _rtnValue As Boolean = True

            If Not (_ctrl.Location.X <= _point.X AndAlso _point.X <= _ctrl.Location.X + _ctrl.Width) Then
                _rtnValue = False
            End If

            If Not (_ctrl.Location.Y <= _point.Y AndAlso _point.Y <= _ctrl.Location.Y + _ctrl.Height) Then
                _rtnValue = False
            End If

            Return _rtnValue

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 檢查觸發事件元件是否屬於此作業
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="ref"></param>
    ''' <param name="formName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckParentContainsSender(ByRef sender As Object, ByRef ref As Object, ByVal formName As String) As Boolean
        Try

            Dim result As Boolean = False

            If ref.IsDisposed Then
                Return False
            End If

            Dim ctrlSend As Control = sender
            While ctrlSend.Name <> formName

                If ctrlSend.Parent IsNot Nothing Then
                    ctrlSend = ctrlSend.Parent
                Else
                    ctrlSend = Nothing
                    Exit While
                End If
            End While

            Dim ctrlRef As Control = ref
            While ctrlRef.Name <> formName

                If ctrlRef.Parent IsNot Nothing Then
                    ctrlRef = ctrlRef.Parent
                Else
                    ctrlRef = Nothing
                    Exit While
                End If
            End While

            If ctrlRef Is Nothing OrElse ctrlSend Is Nothing Then
                result = False
            ElseIf ctrlRef.Handle = ctrlSend.Handle Then
                result = True
            End If

            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Module
