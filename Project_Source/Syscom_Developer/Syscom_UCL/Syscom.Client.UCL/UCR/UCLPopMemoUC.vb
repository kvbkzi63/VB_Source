'/*
'*****************************************************************************
'*
'*    Page/Class Name:	UCLPopMemoUI.vb
'*              Title:	UCLPopMemoUI元件
'*        Description:	彈出放大輸入範圍視窗的User Control, 用
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Jen
'*        Create Date:	
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

Public Class UCLPopMemoUI

#Region "宣告編輯訊息變數"
    Private confirmMessage As String = ""

    '用在datagridview的DTP
    Dim pop_dgv As UCLDataGridViewUC = Nothing
    Dim dsDB As DataSet = Nothing
    Dim dsGrid As DataSet = Nothing

    Dim cellRowIndex, cellColIndex As Integer

    Public MaxLength As Integer = 100

    Public FirstEnterGridCell As Boolean = False

#End Region

    Public Function setConfirmMessage(ByVal txtMessage As String) As Boolean
        If txtMessage IsNot Nothing Then
            ucl_txt_content.Text = txtMessage
            confirmMessage = txtMessage
        Else
            ucl_txt_content.Text = ""
            confirmMessage = ""
        End If
        Return True
    End Function

    Private Function getConfirmMessage() As String
        If ucl_txt_content.Text IsNot Nothing Then
            confirmMessage = ucl_txt_content.Text
        End If

        Return confirmMessage
    End Function

    Public Sub setProperties(ByVal popMaxLength As Integer)
        ucl_txt_content.MaxLength = popMaxLength
        MaxLength = popMaxLength
        'ucl_txt_content.uclTextType = CType(hash(e.ColumnIndex), TextBoxCell).uclTextType
        'ucl_txt_content.uclMinus = CType(hash(e.ColumnIndex), TextBoxCell).uclMinus
        'ucl_txt_content.uclIntCount = CType(hash(e.ColumnIndex), TextBoxCell).uclIntCount
        'ucl_txt_content.uclDotCount = CType(hash(e.ColumnIndex), TextBoxCell).uclDotCount

    End Sub

    Public Sub InitialPopMemoCell(ByRef grid As UCLDataGridViewUC, ByRef dDB As DataSet, ByRef dGrid As DataSet, ByVal ConIndex As Integer, ByVal RowIndex As Integer)
        Try
            pop_dgv = grid
            cellRowIndex = RowIndex
            cellColIndex = ConIndex

            dsDB = dDB
            dsGrid = dGrid
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Function ProcessLeave() As Boolean
        Try
            ucl_txt_content.BackColor = Color.White
            If pop_dgv IsNot Nothing AndAlso Not Me.FirstEnterGridCell Then
                Me.Visible = False

                If pop_dgv.MultiSelect Then
                    If getConfirmMessage() IsNot Nothing Then
                        pop_dgv.doCellValueChange = False
                        '更新Grid的Cell Value
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1) = confirmMessage
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1) = confirmMessage
                        pop_dgv.doCellValueChange = True
                    Else
                        '不更新
                    End If
                End If

            End If

        Catch ex As Exception

            ' Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Function




    Private Sub ucl_txt_content_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucl_txt_content.Enter

        '  datagridview cell剛轉為textbox時~~ textbox text為current cell值
        If pop_dgv IsNot Nothing AndAlso Me.FirstEnterGridCell Then
            If pop_dgv.CurrentCell.Value Is DBNull.Value Then
                setConfirmMessage("")
            Else
                setConfirmMessage(pop_dgv.CurrentCell.Value)
            End If

            '此行不可刪
            FirstEnterGridCell = False
        End If

    End Sub


    Private Sub btn_pop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pop.Click
        Dim previousMsg As String = ucl_txt_content.Text
        If previousMsg IsNot Nothing Then
            Dim popModifyMsgUI As UCLRangeInputUI = New UCLRangeInputUI(previousMsg, MaxLength)
            Dim result As Boolean = popModifyMsgUI.ShowAndPrepareReturnData

            If result Then
                ucl_txt_content.Text = popModifyMsgUI.getConfirmMessageAndLeave
            Else
                '無確認,照舊
            End If
        Else
            MessageBox.Show("輸入訊息錯誤!")
        End If

    End Sub

    Private Sub UCLPopMemoUI_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        ProcessLeave()
    End Sub


End Class
