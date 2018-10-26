
Imports System.Windows.Forms
Imports Syscom.Client.cmm
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.log
Imports System.Text


Public Class UCLGridRowUpDownUC

#Region "全域變數宣告"

    Private dgv As UCLDataGridViewUC = Nothing
    Private dgv_1 As DataGridView = Nothing
    Dim check As Boolean = False
    Private _IsLastRowEmptyRow As Boolean = False
#End Region

    Enum mode
        top = 0
        up = 1
        down = 2
        bottom = 3
    End Enum

    ''' <summary>
    ''' 最後一列是否是空白列
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property IsLastRowEmptyRow() As Boolean
        Get
            Return _IsLastRowEmptyRow
        End Get
        Set(ByVal value As Boolean)
            _IsLastRowEmptyRow = value
        End Set
    End Property

    ''' <summary>
    ''' 初始化設定
    ''' grid:要進行列交換的 UCLDataGridViewUI
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initial(ByRef grid As UCLDataGridViewUC)
        Try
            dgv = grid
            If dgv IsNot Nothing AndAlso dgv.Rows.Count > 0 Then
                check = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化設定
    ''' grid:要進行列交換的 DataGridView
    ''' </summary>
    ''' <remarks></remarks> 
    Public Sub Initial(ByRef grid As DataGridView)
        Try
            dgv_1 = grid
            If dgv_1 IsNot Nothing AndAlso dgv.Rows.Count > 0 Then
                check = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Event"

    ''' <summary>
    ''' 資料列交換完成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>2012-05-10 Added by Ken</remarks>
    Public Event SwapCompleted(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ''' <summary>
    ''' 往上按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Up.Click
        Try
            If dgv IsNot Nothing Then
                If dgv.Rows.IndexOf(dgv.SelectedRows.Item(0)) > 0 Then
                    If dgv.Rows.IndexOf(dgv.SelectedRows.Item(0)) > 0 AndAlso Not (IsLastRowEmptyRow AndAlso dgv.Rows.IndexOf(dgv.SelectedRows.Item(0)) = dgv.Rows.Count - 1) Then
                        swapRows(mode.up)
                    End If
                End If
            ElseIf dgv_1 IsNot Nothing Then
                If dgv_1.Rows.IndexOf(dgv_1.SelectedRows.Item(0)) > 0 Then
                    swapRows(mode.up)
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 往下按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Down.Click
        Try
            If dgv IsNot Nothing Then
                If dgv.Rows.IndexOf(dgv.SelectedRows.Item(0)) < dgv.Rows.Count AndAlso Not (IsLastRowEmptyRow AndAlso dgv.Rows.IndexOf(dgv.SelectedRows.Item(0)) = dgv.Rows.Count - 2) Then
                    swapRows(mode.down)
                End If
            ElseIf dgv_1 IsNot Nothing Then
                If dgv_1.Rows.IndexOf(dgv_1.SelectedRows.Item(0)) < dgv_1.Rows.Count Then
                    swapRows(mode.down)
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "資料列交換"

    ''' <summary>
    ''' 進行列交換
    ''' </summary>
    ''' <param name="range"></param>
    ''' <remarks></remarks>
    Private Sub swapRows(ByVal range As mode)
        Try
            If dgv IsNot Nothing Then
                Dim iSelectedRow As Integer = dgv.Rows.IndexOf(dgv.SelectedRows.Item(0))

                If iSelectedRow <> -1 Then
                    Dim sTmp(dgv.GetGridDS.Tables(0).Columns.Count) As String
                    For iTmp As Integer = 0 To dgv.GetGridDS.Tables(0).Columns.Count - 1
                        'If dgv.MultiSelect AndAlso dgv.uclColumnCheckBox Then
                        If dgv.GetGridDS.Tables(0).Rows(iSelectedRow).Item(iTmp) IsNot DBNull.Value Then
                            sTmp(iTmp) = dgv.GetGridDS.Tables(0).Rows(iSelectedRow).Item(iTmp)
                        Else
                            sTmp(iTmp) = Nothing
                        End If
                        'End If
                    Next

                    Dim iNewRow As Integer
                    If range = mode.down Then
                        iNewRow = iSelectedRow + 1
                    ElseIf range = mode.up Then
                        iNewRow = iSelectedRow - 1
                    End If

                    If range = mode.up Or range = mode.down Then
                        For iTmp As Integer = 0 To dgv.GetGridDS.Tables(0).Columns.Count - 1
                            If Not iNewRow = dgv.Rows.Count And Not iNewRow = -1 Then
                                dgv.GetGridDS.Tables(0).Rows(iSelectedRow).Item(iTmp) = dgv.GetGridDS.Tables(0).Rows(iNewRow).Item(iTmp)
                                dgv.GetDBDS.Tables(0).Rows(iSelectedRow).Item(iTmp) = dgv.GetDBDS.Tables(0).Rows(iNewRow).Item(iTmp)

                                If dgv.chkCellIndexList.Contains(iTmp + 1) Then
                                    If dgv.GetDBDS.Tables(0).Rows(iNewRow).Item(iTmp).ToString.Trim = "Y" Then
                                        dgv.Rows(iSelectedRow).Cells(iTmp + 1).Value = True
                                    ElseIf dgv.GetDBDS.Tables(0).Rows(iNewRow).Item(iTmp).ToString.Trim = "N" Then
                                        dgv.Rows(iSelectedRow).Cells(iTmp + 1).Value = False
                                    End If
                                End If

                                Try
                                    dgv.GetGridDS.Tables(0).Rows(iNewRow).Item(iTmp) = sTmp(iTmp)
                                    dgv.GetDBDS.Tables(0).Rows(iNewRow).Item(iTmp) = sTmp(iTmp)
                                Catch ex As Exception
                                    If sTmp(iTmp) Is Nothing Then
                                        dgv.GetGridDS.Tables(0).Rows(iNewRow).Item(iTmp) = DBNull.Value
                                        dgv.GetDBDS.Tables(0).Rows(iNewRow).Item(iTmp) = DBNull.Value
                                    End If
                                End Try


                                If dgv.chkCellIndexList.Contains(iTmp + 1) Then
                                    If sTmp(iTmp) = "Y" Then
                                        dgv.Rows(iNewRow).Cells(iTmp + 1).Value = True
                                    ElseIf sTmp(iTmp) = "N" Then
                                        dgv.Rows(iNewRow).Cells(iTmp + 1).Value = False
                                    End If
                                End If

                            End If
                        Next
                        If Not iNewRow = dgv.Rows.Count And Not iNewRow = -1 Then
                            toSelect(iNewRow)
                        End If
                    ElseIf range = mode.top Or range = mode.bottom Then
                        reshuffleRows(sTmp, iSelectedRow, range)
                    End If
                End If
            ElseIf dgv_1 IsNot Nothing Then

                Dim iSelectedRow As Integer = dgv_1.Rows.IndexOf(dgv_1.SelectedRows.Item(0))

                If iSelectedRow <> -1 Then
                    Dim sTmp(dgv_1.Columns.Count) As String
                    For iTmp As Integer = 0 To dgv_1.Columns.Count - 1
                        sTmp(iTmp) = dgv_1.Rows(iSelectedRow).Cells(iTmp).Value
                    Next

                    Dim iNewRow As Integer
                    If range = mode.down Then
                        iNewRow = iSelectedRow + 1
                    ElseIf range = mode.up Then
                        iNewRow = iSelectedRow - 1
                    End If

                    If range = mode.up Or range = mode.down Then
                        For iTmp As Integer = 0 To dgv_1.Columns.Count - 1
                            If Not iNewRow = dgv.Rows.Count And Not iNewRow = -1 Then
                                dgv_1.Rows(iSelectedRow).Cells(iTmp).Value = dgv_1.Rows(iNewRow).Cells(iTmp).Value
                                dgv_1.Rows(iNewRow).Cells(iTmp).Value = sTmp(iTmp)
                            End If
                        Next
                        If Not iNewRow = dgv_1.Rows.Count And Not iNewRow = -1 Then
                            toSelect(iNewRow)
                        End If
                    ElseIf range = mode.top Or range = mode.bottom Then
                        reshuffleRows(sTmp, iSelectedRow, range)
                    End If
                End If
            End If

            dgv.HideControlCell("All")
            RaiseEvent SwapCompleted(Me, New System.EventArgs())
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub toSelect(ByVal iNewRow As Integer)
        Try
            If dgv IsNot Nothing Then
                dgv.ClearSelection()
                dgv.Rows(iNewRow).Selected = True
            ElseIf dgv_1 IsNot Nothing Then
                dgv_1.ClearSelection()
                dgv_1.Rows(iNewRow).Selected = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub reshuffleRows(ByVal sTmp() As String, ByVal iSelectedRow As Integer, ByVal Range As mode)
        Try
            If dgv IsNot Nothing Then
                If Range = mode.top Then
                    Dim iFirstRow As Integer = 0
                    If iSelectedRow > iFirstRow Then
                        For iTmp As Integer = iSelectedRow To 1 Step -1
                            For iCol As Integer = 0 To dgv.Columns.Count - 1
                                dgv.Rows(iTmp).Cells(iCol).Value = dgv.Rows(iTmp - 1).Cells(iCol).Value
                            Next
                        Next
                        For iCol As Integer = 0 To dgv.Columns.Count - 1
                            dgv.Rows(iFirstRow).Cells(iCol).Value = sTmp(iCol).ToString
                        Next
                        toSelect(iFirstRow)
                    End If
                Else
                    Dim iLastRow As Integer = dgv.Rows.Count - 1
                    If iSelectedRow < iLastRow Then
                        For iTmp As Integer = iSelectedRow To iLastRow - 1
                            For iCol As Integer = 0 To dgv.Columns.Count - 1
                                dgv.Rows(iTmp).Cells(iCol).Value = dgv.Rows(iTmp + 1).Cells(iCol).Value
                            Next
                        Next
                        For iCol As Integer = 0 To dgv.Columns.Count - 1
                            dgv.Rows(iLastRow).Cells(iCol).Value = sTmp(iCol).ToString
                        Next
                        toSelect(iLastRow)
                    End If
                End If
            ElseIf dgv_1 IsNot Nothing Then
                If Range = mode.top Then
                    Dim iFirstRow As Integer = 0
                    If iSelectedRow > iFirstRow Then
                        For iTmp As Integer = iSelectedRow To 1 Step -1
                            For iCol As Integer = 0 To dgv_1.Columns.Count - 1
                                dgv_1.Rows(iTmp).Cells(iCol).Value = dgv_1.Rows(iTmp - 1).Cells(iCol).Value
                            Next
                        Next
                        For iCol As Integer = 0 To dgv_1.Columns.Count - 1
                            dgv_1.Rows(iFirstRow).Cells(iCol).Value = sTmp(iCol).ToString
                        Next
                        toSelect(iFirstRow)
                    End If
                Else
                    Dim iLastRow As Integer = dgv_1.Rows.Count - 1
                    If iSelectedRow < iLastRow Then
                        For iTmp As Integer = iSelectedRow To iLastRow - 1
                            For iCol As Integer = 0 To dgv_1.Columns.Count - 1
                                dgv_1.Rows(iTmp).Cells(iCol).Value = dgv_1.Rows(iTmp + 1).Cells(iCol).Value
                            Next
                        Next
                        For iCol As Integer = 0 To dgv_1.Columns.Count - 1
                            dgv_1.Rows(iLastRow).Cells(iCol).Value = sTmp(iCol).ToString
                        Next
                        toSelect(iLastRow)
                    End If
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

End Class
