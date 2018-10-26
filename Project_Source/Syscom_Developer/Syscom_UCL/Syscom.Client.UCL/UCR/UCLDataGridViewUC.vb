'/*
'*****************************************************************************
'*
'*    Page/Class Name:	UCLDataGridViewUI.vb
'*              Title:	DataGridView元件
'*        Description:	DataGridView元件 功能設計
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	James
'*        Create Date:
'*      Last Modifier:
'*   Last Modify Date:
'*
'*****************************************************************************
'*/
Imports System.Text
Imports System.Collections
Imports System.Windows.Forms.VisualStyles
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.UCL.UCLDateTimePickerUC
Imports Syscom.Client.CMM
Imports System.Configuration
Imports System.Globalization
Imports System.ComponentModel

''' <summary>
''' Class UCLDataGridViewUC.
''' </summary>
''' <seealso cref="System.Windows.Forms.UserControl" />
Public Class UCLDataGridViewUC

#Region "變數宣告"

    ''' <summary>
    ''' The ucl header text
    ''' </summary>
    Private _uclHeaderText As String = ""
    ''' <summary>
    ''' The ucl column width
    ''' </summary>
    Private _uclColumnWidth As String = ""
    ''' <summary>
    ''' The data set source
    ''' </summary>
    Private _DataSetSource As DataSet = Nothing '沒用到
    ''' <summary>
    ''' The ucl cell data type
    ''' </summary>
    Private _uclCellDataType As String = "" '沒用到
    ''' <summary>
    ''' The ucl column CheckBox
    ''' </summary>
    Private _uclColumnCheckBox As Boolean = False
    ''' <summary>
    ''' The ucl is alternating rows colors
    ''' </summary>
    Private _uclIsAlternatingRowsColors As Boolean = True
    ''' <summary>
    ''' The ucl column alignment
    ''' </summary>
    Private _uclColumnAlignment As String = ""  ' 0:靠左對齊 ,  1:靠右對齊 ,  2:置中
    ''' <summary>
    ''' The ucl show cell border
    ''' </summary>
    Private _uclShowCellBorder As Boolean = False
    ''' <summary>
    ''' The ucl Selected First Show Columns
    ''' </summary>
    Private _uclSelectedFirstShowCol As Integer = 0
    ''' <summary>
    ''' The ucl Selected Last Show Columns
    ''' </summary>
    Private _uclSelectedLastShowCol As Integer = -1
    ''' <summary>
    ''' The ucl Selected cell border
    ''' </summary>
    Private _uclSelectedCellBorder As Boolean = False
    ''' <summary>
    ''' The ucl Selected cell border colors
    ''' </summary>
    Private _uclSelectedCellBorderColors As Color = Color.DeepSkyBlue
    ''' <summary>
    ''' The ucl Selected cell border size
    ''' </summary>
    Private _uclSelectedCellBorderSize As Integer = 4
    ''' <summary>
    ''' The ucl is combox click trigger drop down
    ''' </summary>
    Private _uclIsComboxClickTriggerDropDown As Boolean = False
    ''' <summary>
    ''' The current cell address
    ''' </summary>
    Private _CurrentCellAddress As System.Drawing.Point
    ''' <summary>
    ''' The current cell
    ''' </summary>
    Private _CurrentCell As System.Windows.Forms.DataGridViewCell
    ''' <summary>
    ''' The current row
    ''' </summary>
    Private _CurrentRow As System.Windows.Forms.DataGridViewRow
    ''' <summary>
    ''' The rows
    ''' </summary>
    Private _Rows As System.Windows.Forms.DataGridViewRowCollection

    ''' <summary>
    ''' The columns
    ''' </summary>
    Private _Columns As System.Windows.Forms.DataGridViewColumnCollection

    ' Private _AllowUserToAddRows As Boolean = False

    ''' <summary>
    ''' The allow user to add rows
    ''' </summary>
    Private _AllowUserToAddRows As Boolean = False
    ''' <summary>
    ''' The allow user to resize columns
    ''' </summary>
    Private _AllowUserToResizeColumns As Boolean = True
    ''' <summary>
    ''' The allow user to order columns
    ''' </summary>
    Private _AllowUserToOrderColumns As Boolean = True
    ''' <summary>
    ''' The allow user to resize rows
    ''' </summary>
    Private _AllowUserToResizeRows As Boolean = False
    ''' <summary>
    ''' The automatic size columns mode
    ''' </summary>
    Private _AutoSizeColumnsMode As System.Windows.Forms.DataGridViewAutoSizeColumnMode = DataGridViewAutoSizeColumnMode.AllCells
    ''' <summary>
    ''' The automatic size rows mode
    ''' </summary>
    Private _AutoSizeRowsMode As System.Windows.Forms.DataGridViewAutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
    ''' <summary>
    ''' The edit mode
    ''' </summary>
    Private _EditMode As DataGridViewEditMode = DataGridViewEditMode.EditOnKeystroke
    ''' <summary>
    ''' The multi select
    ''' </summary>
    Private _MultiSelect As Boolean = False
    ''' <summary>
    ''' The section mode
    ''' </summary>
    Private _SectionMode As System.Windows.Forms.DataGridViewSelectionMode = DataGridViewSelectionMode.FullRowSelect
    ''' <summary>
    ''' The column headers visible
    ''' </summary>
    Private _ColumnHeadersVisible As Boolean = True
    ''' <summary>
    ''' The default cell style
    ''' </summary>
    Private _DefaultCellStyle As System.Windows.Forms.DataGridViewCellStyle
    ''' <summary>
    ''' The column headers default cell style
    ''' </summary>
    Private _ColumnHeadersDefaultCellStyle As System.Windows.Forms.DataGridViewCellStyle
    ''' <summary>
    ''' The item
    ''' </summary>
    Private _Item As System.Windows.Forms.DataGridViewCell

    ''' <summary>
    ''' The selected rows
    ''' </summary>
    Private _SelectedRows As System.Windows.Forms.DataGridViewSelectedRowCollection
    ''' <summary>
    ''' The selected columns
    ''' </summary>
    Private _SelectedColumns As System.Windows.Forms.DataGridViewSelectedColumnCollection
    ''' <summary>
    ''' The selected cells
    ''' </summary>
    Private _SelectedCells As System.Windows.Forms.DataGridViewSelectedCellCollection
    ''' <summary>
    ''' The ucl batch col index
    ''' </summary>
    Private _uclBatchColIndex As String = "" '可進行整批修改的欄位
    ''' <summary>
    ''' The ucl sort col index
    ''' </summary>
    Private _uclSortColIndex As String = ""
    ''' <summary>
    ''' The ucl multi select type
    ''' </summary>
    Private _uclMultiSelectType As SelectType = SelectType.SelectAll
    ''' <summary>
    ''' The ucl multi select show CheckBox header
    ''' </summary>
    Private _uclMultiSelectShowCheckBoxHeader As Boolean = True

    'cell的類型
    ''' <summary>
    ''' The ucl column control type
    ''' </summary>
    Private _uclColumnControlType As String = ""

    ''' <summary>
    ''' The allow drop
    ''' </summary>
    Private _AllowDrop As Boolean = False

    ''' <summary>
    ''' The DGV column header
    ''' </summary>
    Dim dgvColumnHeader As DGVColumnHeader
    ''' <summary>
    ''' The current row back color
    ''' </summary>
    Dim CurrentRowBackColor As Color
    ''' <summary>
    ''' The current row fore color
    ''' </summary>
    Dim CurrentRowForeColor As Color
    ''' <summary>
    ''' The drag box from mouse down
    ''' </summary>
    Private dragBoxFromMouseDown As Rectangle

    ''' <summary>
    ''' The row index from mouse down
    ''' </summary>
    Private rowIndexFromMouseDown As Integer

    ''' <summary>
    ''' The row index of item under mouse to drop
    ''' </summary>
    Private rowIndexOfItemUnderMouseToDrop As Integer

    '設定隱藏的欄位
    ''' <summary>
    ''' The ucl non visible col index
    ''' </summary>
    Private _uclNonVisibleColIndex As String = ""

    '設定顯示的欄位
    ''' <summary>
    ''' The ucl visible col index
    ''' </summary>
    Private _uclVisibleColIndex As String = ""

    ''' <summary>
    ''' The ucl has new row
    ''' </summary>
    Private _uclHasNewRow As Boolean = False  '最後一列是否為空白列

    '多選Header CheckBox
    ''' <summary>
    ''' The ck box
    ''' </summary>
    Dim ckBox As CheckBox

    ''' <summary>
    ''' The hash
    ''' </summary>
    Dim hash As Hashtable = Nothing
    ''' <summary>
    ''' The hash col cell type
    ''' </summary>
    Dim hashColCellType As Hashtable

    ''' <summary>
    ''' The ds database
    ''' </summary>
    Dim dsDB As DataSet
    ''' <summary>
    ''' The ds grid
    ''' </summary>
    Dim dsGrid As DataSet
    ''' <summary>
    ''' The ds DGV read only
    ''' </summary>
    Dim dsDgvReadOnly As DataSet

    ''' <summary>
    ''' Occurs when [cell enter].
    ''' </summary>
    Public Event CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    ''' <summary>
    ''' Occurs when [cell value changed].
    ''' </summary>
    Public Event CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    ''' <summary>
    ''' Occurs when [cell leave].
    ''' </summary>
    Public Event CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    ''' <summary>
    ''' Occurs when [cell click].
    ''' </summary>
    Public Event CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    ''' <summary>
    ''' Occurs when [key up].
    ''' </summary>
    Public Shadows Event KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    ''' <summary>
    ''' Occurs when [key down].
    ''' </summary>
    Public Shadows Event KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    ''' <summary>
    ''' Occurs when [cell double click].
    ''' </summary>
    Public Event CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    ''' <summary>
    ''' Occurs when [cell formatting].
    ''' </summary>
    Public Event CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
    ''' <summary>
    ''' Occurs when [column width changed].
    ''' </summary>
    Public Event ColumnWidthChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
    ''' <summary>
    ''' Occurs when [cell mouse enter].
    ''' </summary>
    Public Event CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    ''' <summary>
    ''' Occurs when [cell begin edit].
    ''' </summary>
    Public Event CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
    ''' <summary>
    ''' Occurs when [cell end edit].
    ''' </summary>
    Public Event CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    ''' <summary>
    ''' Occurs when [current cell dirty state changed].
    ''' </summary>
    Public Event CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Public Event KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    ''' <summary>
    ''' Occurs when [cell painting].
    ''' </summary>
    Public Event CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
    ''' <summary>
    ''' Occurs when [column header mouse click].
    ''' </summary>
    Public Event ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    ''' <summary>
    ''' Occurs when [current cell changed].
    ''' </summary>
    Public Event CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Occurs when [mouse move].
    ''' </summary>
    Public Shadows Event MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    ''' <summary>
    ''' Occurs when [data error].
    ''' </summary>
    Public Event DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
    ''' <summary>
    ''' Occurs when [mouse click].
    ''' </summary>
    Public Shadows Event MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    ''' <summary>
    ''' Occurs when [click].
    ''' </summary>
    Public Shadows Event Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ''' <summary>
    ''' Occurs when [ClickSelectAllChkBox].
    ''' </summary>
    Public Shadows Event ClickSelectAllChkBox(ByVal sender As System.Object, ByVal Is_Checked As Boolean)

    ''' <summary>
    ''' Occurs when [ComboBoxCellSelectedValueChangedAndLeave].
    ''' </summary>
    Public Shadows Event ComboBoxCellSelectedValueChangedAndLeave(ByVal RowIndex As Integer, ByVal ColIndex As Integer)


    ''' <summary>
    ''' Occurs when [cell mouse down].
    ''' </summary>
    Public Event CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

    ''' <summary>
    ''' Occurs when [text cell key up].
    ''' </summary>
    Public Event TxtCellKeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    ''' <summary>
    ''' The cbo cell
    ''' </summary>
    Dim cbo_cell As UCLComboBoxUC
    ''' <summary>
    ''' The cbo grid cell
    ''' </summary>
    Public cboGrid_cell As UCLComboBoxGridUC
    ''' <summary>
    ''' The cbo grid show cell
    ''' </summary>
    Dim cboGridShow_cell As UCLDataGridViewUC

    ''' <summary>
    ''' The DTP cell
    ''' </summary>
    Dim dtp_cell As UCLDateTimePickerCellUC
    ''' <summary>
    ''' The text cell
    ''' </summary>
    Dim WithEvents txt_cell As UCLTextBoxUC

    ''' <summary>
    ''' The textbox up
    ''' </summary>
    Dim textboxUp As UCLGridUpComboBoxUC

    ''' <summary>
    ''' The pop memo UI cell
    ''' </summary>
    Dim popMemoUICell As UCLPopMemoUI

    ''' <summary>
    ''' The maximum size
    ''' </summary>
    Const MaxSize As Integer = 10

    ''' <summary>
    ''' The CHK cell
    ''' </summary>
    Dim chk_cell(,) As System.Windows.Forms.CheckBox
    ''' <summary>
    ''' The BTN cell
    ''' </summary>
    Dim btn_cell(,) As System.Windows.Forms.Button

    ''' <summary>
    ''' The BTN col count
    ''' </summary>
    Dim btn_colCount As Integer = 0
    ''' <summary>
    ''' The CHK col count
    ''' </summary>
    Dim chk_colCount As Integer = 0

    ''' <summary>
    ''' The dt
    ''' </summary>
    Dim dt As DataTable

    ''' <summary>
    ''' The col ready
    ''' </summary>
    Dim colReady As Boolean = False
    ''' <summary>
    ''' The enter edit
    ''' </summary>
    Dim EnterEdit As Boolean = False

    ''' <summary>
    ''' The DTP column width
    ''' </summary>
    Public dtpColumnWidth As Integer = 10
    ' Dim hasCheckBoxCol As Boolean = False

    ''' <summary>
    ''' The do cell value change
    ''' </summary>
    Public doCellValueChange As Boolean = True

    ''' <summary>
    ''' The selected ComboBox code value
    ''' </summary>
    Dim SelectedComboBoxCodeValue As String = ""

    '隱藏隨輸隨選
    ''' <summary>
    ''' The hide ComboBox grid
    ''' </summary>
    Public hideComboBoxGrid As Boolean = True
    ''' <summary>
    ''' The ComboBox grid flag
    ''' </summary>
    Public ComboBoxGridFlag As Boolean = False

    '判斷是否已經設定隨輸隨選的值
    ''' <summary>
    ''' The is ComboBox grid set value
    ''' </summary>
    Public IsComboBoxGridSetValue As Boolean = False

    ''' <summary>
    ''' The ucl tree mode
    ''' </summary>
    Public _uclTreeMode As Boolean = False
    ''' <summary>
    ''' The hash tree
    ''' </summary>
    Dim hashTree As Hashtable

    ''' <summary>
    ''' The hash grid
    ''' </summary>
    Dim hashGrid As Hashtable               '記錄哪些 Row有 ChildGridView
    ''' <summary>
    ''' The row child grid collection
    ''' </summary>
    Dim RowChildGridCollection As ArrayList '記錄一個Row 所擁有的ChildGridView 集合
    ''' <summary>
    ''' 目前沒有用到
    ''' </summary>
    Dim TreeGridCol As Integer = 0

    ''' <summary>
    ''' The current tree level
    ''' </summary>
    Public CurrentTreeLevel As Integer = 0

    ''' <summary>
    ''' The send grid view name MGR
    ''' </summary>
    Dim WithEvents SendGridViewNameMgr As EventManager = EventManager.getInstance
    ''' <summary>
    ''' The is initial
    ''' </summary>
    Dim IsInitial As Boolean = True
    ''' <summary>
    ''' The ucl is ComboBox grid query
    ''' </summary>
    Private _uclIsComboBoxGridQuery As Boolean = True '化療藥ComboBoxGrid <=> ComboBox
    ''' <summary>
    ''' The ucl is sortable
    ''' </summary>
    Private _uclIsSortable As Boolean = False
    ''' <summary>
    ''' The ucl do cell enter
    ''' </summary>
    Private _uclDoCellEnter As Boolean = True
    ''' <summary>
    ''' The ucl click to check
    ''' </summary>
    Private _uclClickToCheck As Boolean = False

    ''' <summary>
    ''' The ucl is do order check
    ''' </summary>
    Private _uclIsDoOrderCheck As Boolean = True

    ''' <summary>
    ''' The ucl is do uclIsDoQueryComboBoxGrid
    ''' </summary>
    Private _uclIsDoQueryComboBoxGrid As Boolean = True

    ''' <summary>
    ''' The header click flag
    ''' </summary>
    Private HeaderClickFlag As Integer = 0

    ''' <summary>
    ''' The is process sorting
    ''' </summary>
    Dim IsProcessSorting As Boolean = False
    ''' <summary>
    ''' The ucl alternating rows colors
    ''' </summary>
    Dim _uclAlternatingRowsColors As Color = Color.White
    ''' <summary>
    ''' The DTP index list
    ''' </summary>
    Dim dtpIndexList As New ArrayList
    ''' <summary>
    ''' The CHK cell index list
    ''' </summary>
    Public chkCellIndexList As New ArrayList

#End Region

#Region "20090501 add by James ,共用元件  DataGridView"

#Region "Event"

    ''' <summary>
    ''' dgv_Click
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub dgv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv.Click
        If IsInitial Then
            Exit Sub
        End If
        RaiseEvent Click(sender, e)

    End Sub

    ''' <summary>
    ''' dgv_CellMouseEnter
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellMouseEnter
        ' SendMyName()

        If IsInitial Then
            Exit Sub
        End If

        RaiseEvent CellMouseEnter(sender, e)

    End Sub

    ''' <summary>
    ''' dgv_CellMouseDown
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellMouseEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDown
        ' SendMyName()

        If IsInitial Then
            Exit Sub
        End If

        RaiseEvent CellMouseDown(sender, e)

    End Sub

    ''' <summary>
    ''' dgv_CellFormatting
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellFormattingEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        '  SendMyName()
        If IsInitial Then
            Exit Sub
        End If

        '目前用不到,在一起InitialAllCell就可以把圖初始化了
        'If hash IsNot Nothing AndAlso hash.ContainsKey(e.ColumnIndex) Then
        '    '此ColumnIndex若有存在於hash中
        '    If hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ImageCell" Then
        '        Dim colName As String = dgv.Columns(e.ColumnIndex).Name
        '        If dsDB.Tables(0).Rows(e.RowIndex).Item(colName) Is Nothing Then
        '            dgv.Rows(e.RowIndex).Cells(colName).Value = Nothing
        '        Else
        '            dgv.Rows(e.RowIndex).Cells(colName).Value = My.Resources.Close_Window 'dsDB.Tables(0).Rows(e.RowIndex).Item(colName)
        '        End If
        '    End If
        'End If

        RaiseEvent CellFormatting(sender, e)

    End Sub

    ''' <summary>
    ''' dgv_CellPainting
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellPaintingEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv.CellPainting

        RaiseEvent CellPainting(sender, e)

        If uclSelectedCellBorder AndAlso dgv.CurrentCell IsNot Nothing Then
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor

            If e.ColumnIndex <> -1 AndAlso e.RowIndex <> -1 AndAlso dgv(e.ColumnIndex, e.RowIndex).Selected Then

                'Pen for bottom and right borders
                Using gridlinePen = New Pen(dgv.GridColor, 1)
                    'Pen for selected cell borders by top
                    Using selectedTopPen = New Pen(uclSelectedCellBorderColors, uclSelectedCellBorderSize - 1)
                        'Pen for selected cell borders
                        Using selectedPen = New Pen(uclSelectedCellBorderColors, uclSelectedCellBorderSize)
                            Dim topLeftPoint = New Point(e.CellBounds.Left, e.CellBounds.Top + 1)
                            Dim topRightPoint = New Point(e.CellBounds.Right - 1, e.CellBounds.Top + 1)
                            Dim bottomRightPoint = New Point(e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                            Dim bottomleftPoint = New Point(e.CellBounds.Left, e.CellBounds.Bottom - 1)
                            Dim col1topLeftPoint = New Point(e.CellBounds.Left + 1, e.CellBounds.Top + 1)
                            Dim col1bottomleftPoint = New Point(e.CellBounds.Left + 1, e.CellBounds.Bottom - 1)
                            'Draw selected cells here
                            If Me.dgv(e.ColumnIndex, e.RowIndex).Selected Then
                                'Paint all parts except borders.
                                e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.Border)

                                'Draw selected cells border here

                                'Left border of first column cells should be in background color
                                If e.ColumnIndex = uclSelectedFirstShowCol Then
                                    e.Graphics.DrawLine(selectedPen, col1topLeftPoint, col1bottomleftPoint)
                                End If

                                'Bottom border of last row cells should be in gridLine color
                                If e.RowIndex = dgv.CurrentCell.RowIndex Then
                                    e.Graphics.DrawLine(selectedPen, bottomRightPoint, bottomleftPoint)
                                    e.Graphics.DrawLine(selectedTopPen, topRightPoint, topLeftPoint)
                                End If

                                'Right border of last column cells should be in gridLine color
                                If uclSelectedLastShowCol = -1 Then
                                    If e.ColumnIndex = dgv.ColumnCount - 1 Then
                                        e.Graphics.DrawLine(selectedPen, bottomRightPoint, topRightPoint)
                                    End If
                                Else
                                    If e.ColumnIndex = uclSelectedLastShowCol Then
                                        e.Graphics.DrawLine(selectedPen, bottomRightPoint, topRightPoint)
                                    End If
                                End If

                                'Right border of last column cells should be in gridLine color
                                If uclSelectedLastShowCol = -1 Then
                                    If e.ColumnIndex <> dgv.ColumnCount - 1 Then
                                        e.Graphics.DrawLine(gridlinePen, bottomRightPoint, topRightPoint)
                                    End If
                                Else
                                    If e.ColumnIndex <> uclSelectedLastShowCol Then
                                        e.Graphics.DrawLine(gridlinePen, bottomRightPoint, topRightPoint)
                                    End If
                                End If


                                'We handled painting for this cell, Stop default rendering.
                                e.Handled = True
                            End If
                        End Using
                    End Using
                End Using
            End If
        End If

        If uclShowCellBorder AndAlso dgv.CurrentCell IsNot Nothing Then

            If e.ColumnIndex = dgv.CurrentCell.ColumnIndex AndAlso e.RowIndex = dgv.CurrentCell.RowIndex Then

                e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.Border)

                Using p As New Pen(Color.Red, 1)

                    Dim rect As Rectangle = e.CellBounds

                    rect.Width -= 1

                    rect.Height -= 1

                    e.Graphics.DrawRectangle(p, rect)
                End Using

                e.Handled = True

            End If

        End If
    End Sub

    ''' <summary>
    ''' dgv_CellBeginEdit
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellCancelEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgv.CellBeginEdit

        If IsInitial Then
            Exit Sub
        End If

        SendMyName()
        RaiseEvent CellBeginEdit(sender, e)

    End Sub

    ''' <summary>
    ''' dgv_CellEndEdit
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        If IsInitial Then
            Exit Sub
        End If

        SendMyName()
        RaiseEvent CellEndEdit(sender, e)

    End Sub

    ''' <summary>
    ''' dgv_CellDoubleClick
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

        Try

            SendMyName()
            RaiseEvent CellDoubleClick(sender, e)

        Catch ex As Exception

            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' dgv_DataError
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv.DataError
        Try

            RaiseEvent DataError(sender, e)

        Catch ex As Exception

            Debug.WriteLine(ex.ToString)   'Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' dgv_CellEnter
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellEnter

        If IsInitial Then
            Exit Sub
        End If

        If textboxUp IsNot Nothing AndAlso textboxUp.Visible Then
            textboxUp.Visible = False
        End If

        SendMyName()
        RaiseEvent CellEnter(sender, e)
        If Not uclDoCellEnter Then
            Exit Sub
        End If

        Try
            ' RaiseEvent CellEnter(sender, e)

            If cboGrid_cell IsNot Nothing Then
                cboGrid_cell.Visible = False
                If cboGridShow_cell IsNot Nothing Then
                    cboGridShow_cell.Visible = False
                End If

            End If

            If hash IsNot Nothing AndAlso hash.ContainsKey(e.ColumnIndex) AndAlso Not dsDgvReadOnly.Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex).ToString.Trim = "TRUE" Then

                If hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ComboBoxCell" Then

                    dt = CType(CType(hash(e.ColumnIndex), ComboBoxCell).Ds.Tables(0), DataTable)
                    '傳入dgv跟綁dgv的dataset

                    cbo_cell.InitialComboBoxCell(Me, dsDB, dsGrid, SelectedComboBoxCodeValue, e.ColumnIndex, e.RowIndex)

                    cbo_cell.FirstEnterGridCell = True

                    cbo_cell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    cbo_cell.DataSource = dt.Copy()

                    cbo_cell.uclDisplayIndex = CType(hash(e.ColumnIndex), ComboBoxCell).DisplayIndex
                    cbo_cell.uclValueIndex = CType(hash(e.ColumnIndex), ComboBoxCell).ValueIndex
                    cbo_cell.DropDownWidth = CType(hash(e.ColumnIndex), ComboBoxCell).DropDownWidth
                    cbo_cell.uclIsTextMode = CType(hash(e.ColumnIndex), ComboBoxCell).IsTextMode

                    dgv.Controls.Add(cbo_cell)

                    If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        ' Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        cbo_cell.Left = rect.Left
                        cbo_cell.Top = rect.Top
                        cbo_cell.Width = rect.Width
                        cbo_cell.Height = rect.Height
                        cbo_cell.ComboBox1.ImeMode = Windows.Forms.ImeMode.Off

                        If UCLFormUtil.isResizeable(Me) Then
                            cbo_cell.AutoScaleMode = Windows.Forms.AutoScaleMode.None
                            If UCLFormUtil.gblScreenWidth >= 1920 Then
                                cbo_cell.Font = New Font(UCLFormUtil.gblFont, UCLFormUtil.gblFontSize_1920_1080)
                            Else
                                cbo_cell.Font = New Font(UCLFormUtil.gblFont, UCLFormUtil.gblFontSize_1024_768)
                            End If
                        End If

                        'combox的值為cell value
                        If dgv.CurrentCell.Value Is DBNull.Value Then
                            cbo_cell.Text = ""
                        Else
                            cbo_cell.Text = dgv.CurrentCell.Value.ToString().Trim()
                        End If

                        cbo_cell.Visible = True
                        cbo_cell.SetPvtCheckFlag(False)

                        cbo_cell.BringToFront()
                        cbo_cell.SelectNextControl(Me, True, True, True, True)

                        cbo_cell.DroppedDown = False
                        If uclIsComboxClickTriggerDropDown Then
                            cbo_cell.DroppedDown = uclIsComboxClickTriggerDropDown
                        End If
                    End If

                ElseIf hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.TextBoxCell" Then

                    txt_cell.InitialTextBoxCell(Me, dsDB, dsGrid, e.ColumnIndex, e.RowIndex)
                    txt_cell.FirstEnterGridCell = True

                    txt_cell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    ' cbo_cell.DataSource = dt.Copy()

                    txt_cell.MaxLength = CType(hash(e.ColumnIndex), TextBoxCell).MaxLength
                    txt_cell.uclTextType = CType(hash(e.ColumnIndex), TextBoxCell).uclTextType
                    txt_cell.uclMinus = CType(hash(e.ColumnIndex), TextBoxCell).uclMinus
                    txt_cell.uclTransferForFractions = CType(hash(e.ColumnIndex), TextBoxCell).uclTransferForFractions
                    txt_cell.uclIntCount = CType(hash(e.ColumnIndex), TextBoxCell).uclIntCount
                    txt_cell.uclDotCount = CType(hash(e.ColumnIndex), TextBoxCell).uclDotCount
                    txt_cell.MaskedTextBox1.ImeMode = Windows.Forms.ImeMode.Off

                    dgv.Controls.Add(txt_cell)

                    If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        '  Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        txt_cell.Left = rect.Left
                        txt_cell.Top = rect.Top
                        txt_cell.Width = rect.Width
                        txt_cell.Height = rect.Height

                        If UCLFormUtil.isResizeable(Me) Then
                            txt_cell.AutoScaleMode = Windows.Forms.AutoScaleMode.None
                            If UCLFormUtil.gblScreenWidth >= 1920 Then
                                txt_cell.Font = New Font(UCLFormUtil.gblFont, UCLFormUtil.gblFontSize_1920_1080)
                            Else
                                txt_cell.Font = New Font(UCLFormUtil.gblFont, UCLFormUtil.gblFontSize_1024_768)
                            End If
                        End If

                        txt_cell.Visible = True

                        'textbox的值為cell value
                        txt_cell.Text = dgv.CurrentCell.Value.ToString().Trim()
                        txt_cell.BringToFront()
                        txt_cell.SelectNextControl(Me, True, True, True, True)

                    End If

                ElseIf hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.DtpCell" Then

                    dtp_cell.InitialDtpCell(Me, dsDB, dsGrid, e.ColumnIndex, e.RowIndex)

                    dtp_cell.FirstEnterGridCell = True

                    dgv.Controls.Add(dtp_cell)

                    dtp_cell.Visible = False

                    If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        '   Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        dtp_cell.Left = rect.Left
                        dtp_cell.Top = rect.Top

                        If UCLFormUtil.isResizeable(Me) Then
                            dtp_cell.Width = rect.Width

                            dtp_cell.AutoScaleMode = Windows.Forms.AutoScaleMode.None

                            If UCLFormUtil.gblScreenWidth >= 1920 Then
                                dtp_cell.Font = New Font(UCLFormUtil.gblFont, UCLFormUtil.gblFontSize_1920_1080)
                            Else
                                dtp_cell.Font = New Font(UCLFormUtil.gblFont, UCLFormUtil.gblFontSize_1024_768)
                            End If
                        End If

                        dtp_cell.Height = rect.Height
                        dtp_cell.Visible = True

                        Try
                            If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then
                                dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.TW

                                '顯示民國
                                If dgv.CurrentCell.Value.ToString().Trim() <> "" Then
                                    dtp_cell.SetValue(DateUtil.TransDateToWE(dgv.CurrentCell.Value.ToString().Trim()))
                                Else
                                    dtp_cell.SetValue(Now.ToShortDateString())
                                End If

                            Else
                                dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.US
                                'dtp的值為cell value
                                If dgv.CurrentCell.Value.ToString().Trim() <> "" Then
                                    dtp_cell.SetValue(dgv.CurrentCell.Value.ToString().Trim())
                                Else
                                    dtp_cell.SetValue(Now.ToShortDateString())
                                End If
                            End If
                        Catch ex As Exception
                            'dtp的值為cell value
                            dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.US
                            If dgv.CurrentCell.Value.ToString().Trim() <> "" Then
                                dtp_cell.SetValue(dgv.CurrentCell.Value.ToString().Trim())
                            Else
                                dtp_cell.SetValue(Now.ToShortDateString())
                            End If
                        End Try

                        dtp_cell.BringToFront()
                        dtp_cell.SelectNextControl(Me, True, True, True, True)
                        dtp_cell.SetFocus()
                    End If

                ElseIf hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ButtonCell" Then

                ElseIf hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ComboBoxGridCell" Then
                    EnterEdit = True
                    IsComboBoxGridSetValue = True
                    ' dt = CType(CType(hash(e.ColumnIndex), ComboBoxGridCell).Ds.Tables(0), DataTable)
                    '傳入dgv跟綁dgv的dataset

                    cboGrid_cell.InitialComboBoxGridCell(Me, dsDB, dsGrid, uclColumnCheckBox)

                    cboGrid_cell.FirstEnterGridCell = True

                    ' dgv.Controls.Add(cboGridShow_cell)
                    cboGrid_cell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    '  cbo_cell.DataSource = dt.Copy()

                    cboGrid_cell.uclDisplayIndex = CType(hash(e.ColumnIndex), ComboBoxGridCell).DisplayIndex
                    cboGrid_cell.uclValueIndex = CType(hash(e.ColumnIndex), ComboBoxGridCell).ValueIndex
                    cboGrid_cell.uclNonVisibleColIndex = CType(hash(e.ColumnIndex), ComboBoxGridCell).NonVisibleColIndex
                    cboGrid_cell.uclVisibleColIndex = CType(hash(e.ColumnIndex), ComboBoxGridCell).VisibleColIndex

                    cboGrid_cell.uclConnDBType = CType(hash(e.ColumnIndex), ComboBoxGridCell).ConnDBType
                    cboGrid_cell.uclQueryType = CType(hash(e.ColumnIndex), ComboBoxGridCell).QueryType
                    cboGrid_cell.uclQueryData = CType(hash(e.ColumnIndex), ComboBoxGridCell).QueryData
                    cboGrid_cell.uclStartQueryLength = CType(hash(e.ColumnIndex), ComboBoxGridCell).StartQueryLength
                    cboGrid_cell.uclHeaderText = CType(hash(e.ColumnIndex), ComboBoxGridCell).HeaderText
                    cboGrid_cell.uclColumnWidth = CType(hash(e.ColumnIndex), ComboBoxGridCell).ColumnWidth
                    cboGrid_cell.uclCtlName = CType(hash(e.ColumnIndex), ComboBoxGridCell).CtlName
                    cboGrid_cell.uclDiseaseTypeId = CType(hash(e.ColumnIndex), ComboBoxGridCell).DiseaseTypeId
                    cboGrid_cell.uclMultiDiseaseTypeId = CType(hash(e.ColumnIndex), ComboBoxGridCell).MultiDiseaseTypeId
                    cboGrid_cell.uclOrderTypeId = CType(hash(e.ColumnIndex), ComboBoxGridCell).OrderTypeId
                    cboGrid_cell.uclGridHeight = CType(hash(e.ColumnIndex), ComboBoxGridCell).GridHeight
                    cboGrid_cell.uclGridWidth = CType(hash(e.ColumnIndex), ComboBoxGridCell).GridWidth
                    cboGrid_cell.uclIsComboBoxGridQuery = uclIsComboBoxGridQuery
                    cboGrid_cell.uclEffectiveMode = CType(hash(e.ColumnIndex), ComboBoxGridCell).EffectiveMode
                    cboGrid_cell.uclIsFreeText = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsFreeText
                    cboGrid_cell.uclIsPriorReview = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsPriorReview
                    cboGrid_cell.uclSource = CType(hash(e.ColumnIndex), ComboBoxGridCell).Source
                    cboGrid_cell.uclIsOPD = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsOPD
                    cboGrid_cell.uclIsEPD = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsEPD
                    cboGrid_cell.uclIsIPD = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsIPD
                    cboGrid_cell.IcdType = CType(hash(e.ColumnIndex), ComboBoxGridCell).IcdType
                    cboGrid_cell.IsAllowIcd9Empty = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsAllowIcd9Empty
                    cboGrid_cell.IsAllowIcd10Empty = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsAllowIcd10Empty
                    cboGrid_cell.Is_ChemoDrug = CType(hash(e.ColumnIndex), ComboBoxGridCell).Is_ChemoDrug
                    cboGrid_cell.Is_AllChemoDrug = CType(hash(e.ColumnIndex), ComboBoxGridCell).Is_AllChemoDrug

                    cboGrid_cell.uclIsEqualMatch = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsEqualMatch
                    cboGrid_cell.uclIsCheckPubOrderDc = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsCheckPubOrderDc
                    cboGrid_cell.IsCanSelectDcOrder = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsCanSelectDcOrder
                    cboGrid_cell.uclBasicDateStr = CType(hash(e.ColumnIndex), ComboBoxGridCell).BasicDateStr

                    cboGrid_cell.uclMultiOrderTypeId = CType(hash(e.ColumnIndex), ComboBoxGridCell).MultiOrderTypeId
                    cboGrid_cell.uclEmpCode = CType(hash(e.ColumnIndex), ComboBoxGridCell).EmpCode
                    cboGrid_cell.uclDepCode = CType(hash(e.ColumnIndex), ComboBoxGridCell).DepCode
                    cboGrid_cell.ComboBox1.ImeMode = Windows.Forms.ImeMode.Off

                    dgv.Controls.Add(cboGrid_cell)

                    If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        'Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        cboGrid_cell.Left = rect.Left
                        cboGrid_cell.Top = rect.Top
                        cboGrid_cell.Width = rect.Width
                        cboGrid_cell.Height = rect.Height

                        cboGrid_cell.Visible = True

                        cboGrid_cell.uclDoTextChanged = False

                        '隨輸隨選 combox的值為cell value
                        If dgv.CurrentCell.Value Is DBNull.Value Then
                            cboGrid_cell.Text = ""
                        Else
                            cboGrid_cell.Text = dgv.CurrentCell.Value.ToString().Trim()
                        End If

                        cboGrid_cell.uclDoTextChanged = True

                        cboGrid_cell.SelectNextControl(Me, True, True, True, True)
                        ' cboGridShow_cell.SelectNextControl(Me, True, True, False, True)

                    End If
                ElseIf hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.UCLPopMemoUI" Then

                    'popMemoUI

                    popMemoUICell.InitialPopMemoCell(Me, dsDB, dsGrid, e.ColumnIndex, e.RowIndex)
                    popMemoUICell.FirstEnterGridCell = True

                    popMemoUICell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    ' cbo_cell.DataSource = dt.Copy()

                    popMemoUICell.setProperties(CType(hash(e.ColumnIndex), UCLPopMemoUI).MaxLength)

                    dgv.Controls.Add(popMemoUICell)

                    If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        '  Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        popMemoUICell.Left = rect.Left
                        popMemoUICell.Top = rect.Top
                        popMemoUICell.Width = rect.Width
                        popMemoUICell.Height = rect.Height
                        popMemoUICell.Visible = True

                        'popMemoUICell的值為cell value
                        popMemoUICell.setConfirmMessage(dgv.CurrentCell.Value.ToString())

                        popMemoUICell.BringToFront()
                        popMemoUICell.SelectNextControl(Me, True, True, True, True)

                    End If

                ElseIf hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ImageCell" Then

                End If

                EnterEdit = False
            End If
            uclDoCellEnter = True
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#Region "進入Cell的編輯"

    ''' <summary>
    ''' 進入Cell的編輯
    ''' </summary>
    ''' <param name="EnterEdit">是否可編輯</param>
    Private Sub EditCell(ByVal EnterEdit As Boolean)

        Try
            ' RaiseEvent CellEnter(sender, e)
            If IsInitial Then
                Exit Sub
            End If

            If cboGrid_cell IsNot Nothing Then
                cboGrid_cell.Visible = False
                If cboGridShow_cell IsNot Nothing Then
                    cboGridShow_cell.Visible = False
                End If

            End If

            If hash IsNot Nothing AndAlso hash.ContainsKey(dgv.CurrentCell.ColumnIndex) AndAlso EnterEdit AndAlso Not dsDgvReadOnly.Tables(0).Rows(dgv.CurrentCell.RowIndex).Item(dgv.CurrentCell.ColumnIndex).ToString.Trim = "TRUE" Then

                If hash(dgv.CurrentCell.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ComboBoxCell" Then

                    dt = CType(CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxCell).Ds.Tables(0), DataTable)
                    '傳入dgv跟綁dgv的dataset

                    cbo_cell.InitialComboBoxCell(Me, dsDB, dsGrid, SelectedComboBoxCodeValue, dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex)

                    cbo_cell.FirstEnterGridCell = True

                    cbo_cell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    cbo_cell.DataSource = dt.Copy()

                    cbo_cell.uclDisplayIndex = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxCell).DisplayIndex
                    cbo_cell.uclValueIndex = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxCell).ValueIndex
                    cbo_cell.DropDownWidth = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxCell).DropDownWidth
                    cbo_cell.uclIsTextMode = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxCell).IsTextMode

                    dgv.Controls.Add(cbo_cell)

                    Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                    ' Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                    cbo_cell.Left = rect.Left
                    cbo_cell.Top = rect.Top
                    cbo_cell.Width = rect.Width
                    cbo_cell.Height = rect.Height
                    cbo_cell.ComboBox1.ImeMode = Windows.Forms.ImeMode.Off

                    'combox的值為cell value
                    If dgv.CurrentCell.Value Is DBNull.Value Then
                        cbo_cell.Text = ""
                    Else
                        cbo_cell.Text = dgv.CurrentCell.Value.ToString().Trim()
                    End If

                    cbo_cell.Visible = True
                    cbo_cell.SetPvtCheckFlag(False)
                    cbo_cell.BringToFront()
                    cbo_cell.SelectNextControl(Me, True, True, True, True)

                    cbo_cell.DroppedDown = False
                    If uclIsComboxClickTriggerDropDown Then
                        cbo_cell.DroppedDown = uclIsComboxClickTriggerDropDown
                    End If

                ElseIf hash(dgv.CurrentCell.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.TextBoxCell" Then

                    txt_cell.InitialTextBoxCell(Me, dsDB, dsGrid, dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex)
                    txt_cell.FirstEnterGridCell = True

                    txt_cell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    ' cbo_cell.DataSource = dt.Copy()

                    txt_cell.MaxLength = CType(hash(dgv.CurrentCell.ColumnIndex), TextBoxCell).MaxLength
                    txt_cell.uclTextType = CType(hash(dgv.CurrentCell.ColumnIndex), TextBoxCell).uclTextType
                    txt_cell.uclMinus = CType(hash(dgv.CurrentCell.ColumnIndex), TextBoxCell).uclMinus
                    txt_cell.uclTransferForFractions = CType(hash(dgv.CurrentCell.ColumnIndex), TextBoxCell).uclTransferForFractions
                    txt_cell.uclIntCount = CType(hash(dgv.CurrentCell.ColumnIndex), TextBoxCell).uclIntCount
                    txt_cell.uclDotCount = CType(hash(dgv.CurrentCell.ColumnIndex), TextBoxCell).uclDotCount
                    txt_cell.MaskedTextBox1.ImeMode = Windows.Forms.ImeMode.Off

                    dgv.Controls.Add(txt_cell)

                    Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                    '  Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                    txt_cell.Left = rect.Left
                    txt_cell.Top = rect.Top
                    txt_cell.Width = rect.Width
                    txt_cell.Height = rect.Height
                    txt_cell.Visible = True

                    'textbox的值為cell value
                    txt_cell.Text = dgv.CurrentCell.Value.ToString().Trim()
                    txt_cell.BringToFront()
                    txt_cell.SelectNextControl(Me, True, True, True, True)

                ElseIf hash(dgv.CurrentCell.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.DtpCell" Then

                    dtp_cell.InitialDtpCell(Me, dsDB, dsGrid, dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex)

                    dtp_cell.FirstEnterGridCell = True

                    dgv.Controls.Add(dtp_cell)

                    dtp_cell.Visible = False

                    Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                    '   Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                    dtp_cell.Left = rect.Left
                    dtp_cell.Top = rect.Top
                    ' dtp_cell.Width = rect.Width
                    dtp_cell.Height = rect.Height
                    dtp_cell.Visible = True

                    Try
                        If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then
                            dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.TW

                            '顯示民國
                            If dgv.CurrentCell.Value.ToString().Trim() <> "" Then
                                dtp_cell.SetValue(DateUtil.TransDateToWE(dgv.CurrentCell.Value.ToString().Trim()))
                            Else
                                dtp_cell.SetValue(Now.ToShortDateString())
                            End If

                        Else
                            dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.US
                            'dtp的值為cell value
                            If dgv.CurrentCell.Value.ToString().Trim() <> "" Then
                                dtp_cell.SetValue(dgv.CurrentCell.Value.ToString().Trim())
                            Else
                                dtp_cell.SetValue(Now.ToShortDateString())
                            End If
                        End If
                    Catch ex As Exception
                        'dtp的值為cell value
                        dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.US
                        If dgv.CurrentCell.Value.ToString().Trim() <> "" Then
                            dtp_cell.SetValue(dgv.CurrentCell.Value.ToString().Trim())
                        Else
                            dtp_cell.SetValue(Now.ToShortDateString())
                        End If
                    End Try

                    dtp_cell.BringToFront()
                    dtp_cell.SelectNextControl(Me, True, True, True, True)
                    dtp_cell.SetFocus()

                ElseIf hash(dgv.CurrentCell.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ButtonCell" Then

                ElseIf hash(dgv.CurrentCell.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ComboBoxGridCell" Then
                    EnterEdit = True
                    IsComboBoxGridSetValue = True
                    ' dt = CType(CType(hash(e.ColumnIndex), ComboBoxGridCell).Ds.Tables(0), DataTable)
                    '傳入dgv跟綁dgv的dataset

                    cboGrid_cell.InitialComboBoxGridCell(Me, dsDB, dsGrid, uclColumnCheckBox)

                    cboGrid_cell.FirstEnterGridCell = True

                    ' dgv.Controls.Add(cboGridShow_cell)
                    cboGrid_cell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    '  cbo_cell.DataSource = dt.Copy()

                    cboGrid_cell.uclDisplayIndex = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).DisplayIndex
                    cboGrid_cell.uclValueIndex = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).ValueIndex
                    cboGrid_cell.uclNonVisibleColIndex = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).NonVisibleColIndex
                    cboGrid_cell.uclVisibleColIndex = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).VisibleColIndex

                    cboGrid_cell.uclConnDBType = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).ConnDBType
                    cboGrid_cell.uclQueryType = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).QueryType
                    cboGrid_cell.uclQueryData = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).QueryData
                    cboGrid_cell.uclStartQueryLength = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).StartQueryLength
                    cboGrid_cell.uclHeaderText = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).HeaderText
                    cboGrid_cell.uclColumnWidth = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).ColumnWidth
                    cboGrid_cell.uclCtlName = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).CtlName
                    cboGrid_cell.uclDiseaseTypeId = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).DiseaseTypeId
                    cboGrid_cell.uclMultiDiseaseTypeId = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).MultiDiseaseTypeId
                    cboGrid_cell.uclOrderTypeId = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).OrderTypeId
                    cboGrid_cell.uclGridHeight = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).GridHeight
                    cboGrid_cell.uclGridWidth = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).GridWidth
                    cboGrid_cell.uclIsComboBoxGridQuery = uclIsComboBoxGridQuery
                    cboGrid_cell.uclEffectiveMode = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).EffectiveMode
                    cboGrid_cell.uclIsFreeText = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IsFreeText
                    cboGrid_cell.uclIsPriorReview = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IsPriorReview

                    cboGrid_cell.uclSource = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).Source
                    cboGrid_cell.uclIsOPD = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IsOPD
                    cboGrid_cell.uclIsEPD = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IsEPD
                    cboGrid_cell.uclIsIPD = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IsIPD
                    cboGrid_cell.IcdType = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IcdType
                    cboGrid_cell.IsAllowIcd9Empty = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IsAllowIcd9Empty
                    cboGrid_cell.IsAllowIcd10Empty = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IsAllowIcd10Empty
                    cboGrid_cell.Is_ChemoDrug = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).Is_ChemoDrug
                    cboGrid_cell.Is_AllChemoDrug = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).Is_AllChemoDrug

                    cboGrid_cell.uclIsEqualMatch = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IsEqualMatch
                    cboGrid_cell.uclIsCheckPubOrderDc = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IsCheckPubOrderDc
                    cboGrid_cell.IsCanSelectDcOrder = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).IsCanSelectDcOrder

                    cboGrid_cell.uclBasicDateStr = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).BasicDateStr

                    cboGrid_cell.uclMultiOrderTypeId = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).MultiOrderTypeId

                    cboGrid_cell.uclEmpCode = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).EmpCode
                    cboGrid_cell.uclDepCode = CType(hash(dgv.CurrentCell.ColumnIndex), ComboBoxGridCell).DepCode
                    cboGrid_cell.ComboBox1.ImeMode = Windows.Forms.ImeMode.Off

                    dgv.Controls.Add(cboGrid_cell)

                    'If dgv.CurrentCell.ColumnIndex = dgv.CurrentCell.ColumnIndex Then

                    Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                    'Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                    cboGrid_cell.Left = rect.Left
                    cboGrid_cell.Top = rect.Top
                    cboGrid_cell.Width = rect.Width
                    cboGrid_cell.Height = rect.Height

                    cboGrid_cell.Visible = True
                    '   cboGridShow_cell.Visible = True
                    '隨輸隨選 combox的值為cell value

                    cboGrid_cell.uclDoTextChanged = False

                    If dgv.CurrentCell.Value Is DBNull.Value Then
                        cboGrid_cell.Text = ""
                    Else
                        cboGrid_cell.Text = dgv.CurrentCell.Value.ToString().Trim()
                    End If

                    cboGrid_cell.uclDoTextChanged = True

                    cboGrid_cell.SelectNextControl(Me, True, True, True, True)
                    ' cboGridShow_cell.SelectNextControl(Me, True, True, False, True)

                    'End If

                ElseIf hash(dgv.CurrentCell.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.UCLPopMemoUI" Then

                    'popMemoUI

                    popMemoUICell.InitialPopMemoCell(Me, dsDB, dsGrid, dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex)
                    popMemoUICell.FirstEnterGridCell = True

                    popMemoUICell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    ' cbo_cell.DataSource = dt.Copy()

                    popMemoUICell.setProperties(CType(hash(dgv.CurrentCell.ColumnIndex), UCLPopMemoUI).MaxLength)

                    dgv.Controls.Add(popMemoUICell)

                    ''If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                    Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                    '  Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                    popMemoUICell.Left = rect.Left
                    popMemoUICell.Top = rect.Top
                    popMemoUICell.Width = rect.Width
                    popMemoUICell.Height = rect.Height
                    popMemoUICell.Visible = True

                    'popMemoUICell的值為cell value
                    popMemoUICell.setConfirmMessage(dgv.CurrentCell.Value.ToString())

                    popMemoUICell.BringToFront()
                    popMemoUICell.SelectNextControl(Me, True, True, True, True)

                    'End If

                End If
                EnterEdit = False

            ElseIf hash(dgv.CurrentCell.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ImageCell" Then

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "設定要進入編輯的Cell"

    ''' <summary>
    ''' 設定要進入編輯的Cell
    ''' </summary>
    ''' <param name="RowIndex">Row Index</param>
    ''' <param name="ColIndex">Col Index</param>
    Public Sub SetEditCell(ByVal RowIndex As Integer, ByVal ColIndex As Integer)

        Try
            If IsInitial Then
                Exit Sub
            End If

            If cboGrid_cell IsNot Nothing Then
                cboGrid_cell.Visible = False
                If cboGridShow_cell IsNot Nothing Then
                    cboGridShow_cell.Visible = False
                End If

            End If

            HideControlCell("")
            If hash IsNot Nothing AndAlso hash.ContainsKey(ColIndex) AndAlso Not dsDgvReadOnly.Tables(0).Rows(RowIndex).Item(ColIndex).ToString.ToUpper.Trim = "TRUE" Then

                If hash(ColIndex).GetType().ToString() = "Syscom.Client.UCL.ComboBoxCell" Then

                    dt = CType(CType(hash(ColIndex), ComboBoxCell).Ds.Tables(0), DataTable)
                    '傳入dgv跟綁dgv的dataset

                    cbo_cell.InitialComboBoxCell(Me, dsDB, dsGrid, SelectedComboBoxCodeValue, ColIndex, RowIndex)

                    cbo_cell.FirstEnterGridCell = True

                    cbo_cell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    cbo_cell.DataSource = dt.Copy()

                    cbo_cell.uclDisplayIndex = CType(hash(ColIndex), ComboBoxCell).DisplayIndex
                    cbo_cell.uclValueIndex = CType(hash(ColIndex), ComboBoxCell).ValueIndex
                    cbo_cell.DropDownWidth = CType(hash(ColIndex), ComboBoxCell).DropDownWidth
                    cbo_cell.uclIsTextMode = CType(hash(ColIndex), ComboBoxCell).IsTextMode

                    dgv.Controls.Add(cbo_cell)

                    Dim rect As Rectangle = dgv.GetCellDisplayRectangle(ColIndex, RowIndex, False)

                    cbo_cell.Left = rect.Left
                    cbo_cell.Top = rect.Top
                    cbo_cell.Width = rect.Width
                    cbo_cell.Height = rect.Height
                    cbo_cell.ComboBox1.ImeMode = Windows.Forms.ImeMode.Off

                    'combox的值為cell value
                    If dgv.Rows(RowIndex).Cells(ColIndex).Value Is DBNull.Value Then
                        cbo_cell.Text = ""
                    Else
                        cbo_cell.Text = dgv.Rows(RowIndex).Cells(ColIndex).Value.ToString().Trim()
                    End If

                    cbo_cell.Visible = True
                    cbo_cell.SetPvtCheckFlag(False)
                    cbo_cell.BringToFront()
                    cbo_cell.SelectNextControl(Me, True, True, True, True)

                    cbo_cell.DroppedDown = False
                    If uclIsComboxClickTriggerDropDown Then
                        cbo_cell.DroppedDown = uclIsComboxClickTriggerDropDown
                    End If

                ElseIf hash(ColIndex).GetType().ToString() = "Syscom.Client.UCL.TextBoxCell" Then

                    txt_cell.InitialTextBoxCell(Me, dsDB, dsGrid, ColIndex, RowIndex)
                    txt_cell.FirstEnterGridCell = True

                    txt_cell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    ' cbo_cell.DataSource = dt.Copy()

                    txt_cell.MaxLength = CType(hash(ColIndex), TextBoxCell).MaxLength
                    txt_cell.uclTextType = CType(hash(ColIndex), TextBoxCell).uclTextType
                    txt_cell.uclMinus = CType(hash(ColIndex), TextBoxCell).uclMinus
                    txt_cell.uclTransferForFractions = CType(hash(ColIndex), TextBoxCell).uclTransferForFractions
                    txt_cell.uclIntCount = CType(hash(ColIndex), TextBoxCell).uclIntCount
                    txt_cell.uclDotCount = CType(hash(ColIndex), TextBoxCell).uclDotCount
                    txt_cell.MaskedTextBox1.ImeMode = Windows.Forms.ImeMode.Off

                    dgv.Controls.Add(txt_cell)

                    Dim rect As Rectangle = dgv.GetCellDisplayRectangle(ColIndex, RowIndex, False)
                    '  Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                    txt_cell.Left = rect.Left
                    txt_cell.Top = rect.Top
                    txt_cell.Width = rect.Width
                    txt_cell.Height = rect.Height
                    txt_cell.Visible = True

                    txt_cell.BringToFront()
                    txt_cell.SelectNextControl(Me, True, True, True, True)

                    'textbox的值為cell value
                    txt_cell.Text = dgv.Rows(RowIndex).Cells(ColIndex).Value.ToString().Trim()

                ElseIf hash(ColIndex).GetType().ToString() = "Syscom.Client.UCL.DtpCell" Then

                    dtp_cell.InitialDtpCell(Me, dsDB, dsGrid, ColIndex, RowIndex)

                    dtp_cell.FirstEnterGridCell = True

                    dgv.Controls.Add(dtp_cell)

                    dtp_cell.Visible = False

                    Dim rect As Rectangle = dgv.GetCellDisplayRectangle(ColIndex, RowIndex, False)
                    '   Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                    dtp_cell.Left = rect.Left
                    dtp_cell.Top = rect.Top
                    ' dtp_cell.Width = rect.Width
                    dtp_cell.Height = rect.Height
                    dtp_cell.Visible = True

                    Try
                        If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then
                            dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.TW

                            '顯示民國
                            If dgv.Rows(RowIndex).Cells(ColIndex).Value.ToString().Trim() <> "" Then
                                dtp_cell.SetValue(DateUtil.TransDateToWE(dgv.Rows(RowIndex).Cells(ColIndex).Value.ToString().Trim()))
                            Else
                                dtp_cell.SetValue(Now.ToShortDateString())
                            End If

                        Else
                            dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.US
                            'dtp的值為cell value
                            If dgv.Rows(RowIndex).Cells(ColIndex).Value.ToString().Trim() <> "" Then
                                dtp_cell.SetValue(dgv.Rows(RowIndex).Cells(ColIndex).Value.ToString().Trim())
                            Else
                                dtp_cell.SetValue(Now.ToShortDateString())
                            End If
                        End If
                    Catch ex As Exception
                        'dtp的值為cell value
                        dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.US
                        If dgv.Rows(RowIndex).Cells(ColIndex).Value.ToString().Trim() <> "" Then
                            dtp_cell.SetValue(dgv.Rows(RowIndex).Cells(ColIndex).Value.ToString().Trim())
                        Else
                            dtp_cell.SetValue(Now.ToShortDateString())
                        End If
                    End Try

                    dtp_cell.BringToFront()
                    dtp_cell.SelectNextControl(Me, True, True, True, True)
                    dtp_cell.SetFocus()

                ElseIf hash(ColIndex).GetType().ToString() = "Syscom.Client.UCL.ButtonCell" Then

                ElseIf hash(ColIndex).GetType().ToString() = "Syscom.Client.UCL.ComboBoxGridCell" Then
                    EnterEdit = True
                    IsComboBoxGridSetValue = True
                    ' dt = CType(CType(hash(e.ColumnIndex), ComboBoxGridCell).Ds.Tables(0), DataTable)
                    '傳入dgv跟綁dgv的dataset

                    cboGrid_cell.InitialComboBoxGridCell(Me, dsDB, dsGrid, uclColumnCheckBox)

                    cboGrid_cell.FirstEnterGridCell = True

                    ' dgv.Controls.Add(cboGridShow_cell)
                    cboGrid_cell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    '  cbo_cell.DataSource = dt.Copy()

                    cboGrid_cell.uclDisplayIndex = CType(hash(ColIndex), ComboBoxGridCell).DisplayIndex
                    cboGrid_cell.uclValueIndex = CType(hash(ColIndex), ComboBoxGridCell).ValueIndex
                    cboGrid_cell.uclNonVisibleColIndex = CType(hash(ColIndex), ComboBoxGridCell).NonVisibleColIndex
                    cboGrid_cell.uclVisibleColIndex = CType(hash(ColIndex), ComboBoxGridCell).VisibleColIndex

                    cboGrid_cell.uclConnDBType = CType(hash(ColIndex), ComboBoxGridCell).ConnDBType
                    cboGrid_cell.uclQueryType = CType(hash(ColIndex), ComboBoxGridCell).QueryType
                    cboGrid_cell.uclQueryData = CType(hash(ColIndex), ComboBoxGridCell).QueryData
                    cboGrid_cell.uclStartQueryLength = CType(hash(ColIndex), ComboBoxGridCell).StartQueryLength
                    cboGrid_cell.uclHeaderText = CType(hash(ColIndex), ComboBoxGridCell).HeaderText
                    cboGrid_cell.uclColumnWidth = CType(hash(ColIndex), ComboBoxGridCell).ColumnWidth
                    cboGrid_cell.uclCtlName = CType(hash(ColIndex), ComboBoxGridCell).CtlName
                    cboGrid_cell.uclDiseaseTypeId = CType(hash(ColIndex), ComboBoxGridCell).DiseaseTypeId

                    cboGrid_cell.uclMultiDiseaseTypeId = CType(hash(ColIndex), ComboBoxGridCell).MultiDiseaseTypeId

                    cboGrid_cell.uclOrderTypeId = CType(hash(ColIndex), ComboBoxGridCell).OrderTypeId
                    cboGrid_cell.uclGridHeight = CType(hash(ColIndex), ComboBoxGridCell).GridHeight
                    cboGrid_cell.uclGridWidth = CType(hash(ColIndex), ComboBoxGridCell).GridWidth
                    cboGrid_cell.uclIsComboBoxGridQuery = uclIsComboBoxGridQuery
                    cboGrid_cell.uclEffectiveMode = CType(hash(ColIndex), ComboBoxGridCell).EffectiveMode
                    cboGrid_cell.uclIsFreeText = CType(hash(ColIndex), ComboBoxGridCell).IsFreeText
                    cboGrid_cell.uclIsPriorReview = CType(hash(ColIndex), ComboBoxGridCell).IsPriorReview

                    cboGrid_cell.uclSource = CType(hash(ColIndex), ComboBoxGridCell).Source
                    cboGrid_cell.uclIsOPD = CType(hash(ColIndex), ComboBoxGridCell).IsOPD
                    cboGrid_cell.uclIsEPD = CType(hash(ColIndex), ComboBoxGridCell).IsEPD
                    cboGrid_cell.uclIsIPD = CType(hash(ColIndex), ComboBoxGridCell).IsIPD
                    cboGrid_cell.IcdType = CType(hash(ColIndex), ComboBoxGridCell).IcdType
                    cboGrid_cell.IsAllowIcd9Empty = CType(hash(ColIndex), ComboBoxGridCell).IsAllowIcd9Empty
                    cboGrid_cell.IsAllowIcd10Empty = CType(hash(ColIndex), ComboBoxGridCell).IsAllowIcd10Empty
                    cboGrid_cell.Is_ChemoDrug = CType(hash(ColIndex), ComboBoxGridCell).Is_ChemoDrug
                    cboGrid_cell.Is_AllChemoDrug = CType(hash(ColIndex), ComboBoxGridCell).Is_AllChemoDrug

                    cboGrid_cell.uclIsEqualMatch = CType(hash(ColIndex), ComboBoxGridCell).IsEqualMatch
                    cboGrid_cell.uclIsCheckPubOrderDc = CType(hash(ColIndex), ComboBoxGridCell).IsCheckPubOrderDc
                    cboGrid_cell.IsCanSelectDcOrder = CType(hash(ColIndex), ComboBoxGridCell).IsCanSelectDcOrder
                    cboGrid_cell.uclBasicDateStr = CType(hash(ColIndex), ComboBoxGridCell).BasicDateStr

                    cboGrid_cell.uclMultiOrderTypeId = CType(hash(ColIndex), ComboBoxGridCell).MultiOrderTypeId

                    cboGrid_cell.uclEmpCode = CType(hash(ColIndex), ComboBoxGridCell).EmpCode
                    cboGrid_cell.uclDepCode = CType(hash(ColIndex), ComboBoxGridCell).DepCode
                    cboGrid_cell.ComboBox1.ImeMode = Windows.Forms.ImeMode.Off

                    dgv.Controls.Add(cboGrid_cell)

                    Dim rect As Rectangle = dgv.GetCellDisplayRectangle(ColIndex, RowIndex, False)

                    cboGrid_cell.Left = rect.Left
                    cboGrid_cell.Top = rect.Top
                    cboGrid_cell.Width = rect.Width
                    cboGrid_cell.Height = rect.Height

                    cboGrid_cell.Visible = True
                    '   cboGridShow_cell.Visible = True

                    cboGrid_cell.uclDoTextChanged = False

                    '隨輸隨選 combox的值為cell value
                    If dgv.Rows(RowIndex).Cells(ColIndex).Value Is DBNull.Value Then
                        cboGrid_cell.Text = ""
                    Else
                        cboGrid_cell.Text = dgv.Rows(RowIndex).Cells(ColIndex).Value.ToString().Trim()
                    End If

                    cboGrid_cell.uclDoTextChanged = True

                    cboGrid_cell.SelectNextControl(Me, True, True, True, True)
                    ' cboGridShow_cell.SelectNextControl(Me, True, True, False, True)

                ElseIf hash(ColIndex).GetType().ToString() = "Syscom.Client.UCL.UCLPopMemoUI" Then

                    'popMemoUI

                    popMemoUICell.InitialPopMemoCell(Me, dsDB, dsGrid, ColIndex, RowIndex)
                    popMemoUICell.FirstEnterGridCell = True

                    popMemoUICell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    ' cbo_cell.DataSource = dt.Copy()

                    popMemoUICell.setProperties(CType(hash(ColIndex), UCLPopMemoUI).MaxLength)

                    dgv.Controls.Add(popMemoUICell)

                    If dgv.CurrentCell.ColumnIndex = ColIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        '  Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        popMemoUICell.Left = rect.Left
                        popMemoUICell.Top = rect.Top
                        popMemoUICell.Width = rect.Width
                        popMemoUICell.Height = rect.Height
                        popMemoUICell.Visible = True

                        'popMemoUICell的值為cell value
                        popMemoUICell.setConfirmMessage(dgv.CurrentCell.Value.ToString())

                        popMemoUICell.BringToFront()
                        popMemoUICell.SelectNextControl(Me, True, True, True, True)

                    End If

                End If
                EnterEdit = False

            ElseIf hash(ColIndex).GetType().ToString() = "Syscom.Client.UCL.ImageCell" Then

            Else
                dgv.CurrentCell = dgv.Rows(RowIndex).Cells(ColIndex)

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

    ''' <summary>
    ''' dgv_CellClick
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellClick
        Try
            If IsInitial Then
                Exit Sub
            End If

            SendMyName()
            RaiseEvent CellClick(sender, e)

            If textboxUp IsNot Nothing AndAlso textboxUp.Visible Then
                textboxUp.Visible = False
            End If

            '處理TreeGridView 顯示
            If uclTreeMode AndAlso e.ColumnIndex = 1 Then
                ShowChildGridView(dgv.CurrentRow.Index)
            End If

            Dim CurrentRowIndex As Integer = e.RowIndex

            Dim VisibleColIndex As Integer = 0

            If MultiSelect AndAlso uclColumnCheckBox Then
                VisibleColIndex = 1
            End If

            For i As Integer = 0 To dgv.Columns.Count - 1
                If dgv.Columns(i).Visible = True Then
                    VisibleColIndex = i
                    Exit For
                End If
            Next

            'EnterEdit = False

            If e.ColumnIndex = 0 AndAlso MultiSelect AndAlso uclColumnCheckBox AndAlso Not dgv.Rows(e.RowIndex).Cells(0).ReadOnly Then

                If CBool(dgv.CurrentCell.Value) Then

                    dgv.Item(0, dgv.CurrentCell.RowIndex).Value = False
                    dgv.Refresh()
                    dgv.RefreshEdit()
                    'SendKeys.Send("{TAB}")
                    If dgv.Rows(dgv.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.White OrElse dgv.Rows(dgv.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.DeepSkyBlue Then

                        'dgv.Rows(dgv.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.White
                        'dgv.Rows(dgv.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = Color.Black

                        'dgv.CurrentCell = dgv.Rows(dgv.CurrentCell.RowIndex).Cells(VisibleColIndex)
                    End If

                Else

                    dgv.Item(0, dgv.CurrentCell.RowIndex).Value = True
                    dgv.Refresh()
                    dgv.RefreshEdit()
                    'SendKeys.Send("{TAB}")
                    If dgv.Rows(dgv.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.White OrElse dgv.Rows(dgv.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.DeepSkyBlue Then

                        'dgv.Rows(dgv.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.DeepSkyBlue
                        'dgv.Rows(dgv.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = Color.Black

                        'dgv.CurrentCell = dgv.Rows(dgv.CurrentCell.RowIndex).Cells(VisibleColIndex)
                    End If

                End If

                'dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
            ElseIf e.ColumnIndex > 0 AndAlso MultiSelect AndAlso uclColumnCheckBox Then

                If dgv.Item(0, dgv.CurrentCell.RowIndex).Value <> True Then

                    If dgv.Rows(dgv.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.White OrElse dgv.Rows(dgv.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.DeepSkyBlue Then

                        'dgv.RowTemplate.DefaultCellStyle.ForeColor = Color.Black
                        'dgv.RowTemplate.DefaultCellStyle.BackColor = Color.White
                        'SendKeys.Send("{TAB}")
                        'dgv.CurrentCell = dgv.Rows(dgv.CurrentCell.RowIndex).Cells(VisibleColIndex)

                    End If
                End If

            End If

            If cboGrid_cell IsNot Nothing Then
                cboGrid_cell.Visible = False
                If cboGridShow_cell IsNot Nothing Then
                    cboGridShow_cell.Visible = False
                End If

            End If

            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso hash IsNot Nothing AndAlso hash.ContainsKey(e.ColumnIndex) AndAlso Not dsDgvReadOnly.Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex).ToString.Trim = "TRUE" Then

                HideControlCell("")

                If hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ComboBoxCell" Then

                    dt = CType(CType(hash(e.ColumnIndex), ComboBoxCell).Ds.Tables(0), DataTable)
                    '傳入dgv跟綁dgv的dataset

                    cbo_cell.InitialComboBoxCell(Me, dsDB, dsGrid, SelectedComboBoxCodeValue, e.ColumnIndex, e.RowIndex)

                    cbo_cell.FirstEnterGridCell = True

                    '一定要用copy,否則會對原本ds作用
                    cbo_cell.DataSource = dt.Copy()

                    cbo_cell.uclDisplayIndex = CType(hash(e.ColumnIndex), ComboBoxCell).DisplayIndex
                    cbo_cell.uclValueIndex = CType(hash(e.ColumnIndex), ComboBoxCell).ValueIndex
                    cbo_cell.DropDownWidth = CType(hash(e.ColumnIndex), ComboBoxCell).DropDownWidth
                    cbo_cell.uclIsTextMode = CType(hash(e.ColumnIndex), ComboBoxCell).IsTextMode

                    dgv.Controls.Add(cbo_cell)

                    If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        ' Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        cbo_cell.Left = rect.Left
                        cbo_cell.Top = rect.Top
                        cbo_cell.Width = rect.Width
                        cbo_cell.Height = rect.Height
                        cbo_cell.ComboBox1.ImeMode = Windows.Forms.ImeMode.Off

                        'combox的值為cell value
                        If dgv.CurrentCell.Value Is DBNull.Value Then
                            cbo_cell.Text = ""
                        Else
                            cbo_cell.Text = dgv.CurrentCell.Value.ToString().Trim()
                        End If

                        cbo_cell.Visible = True
                        cbo_cell.SetPvtCheckFlag(False)

                        cbo_cell.SelectNextControl(Me, True, True, True, True)

                        cbo_cell.DroppedDown = False
                        If uclIsComboxClickTriggerDropDown Then
                            cbo_cell.DroppedDown = uclIsComboxClickTriggerDropDown
                        End If
                    End If

                ElseIf hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.TextBoxCell" Then

                    txt_cell.InitialTextBoxCell(Me, dsDB, dsGrid, e.ColumnIndex, e.RowIndex)

                    txt_cell.FirstEnterGridCell = True

                    txt_cell.MaxLength = CType(hash(e.ColumnIndex), TextBoxCell).MaxLength
                    txt_cell.uclTextType = CType(hash(e.ColumnIndex), TextBoxCell).uclTextType
                    txt_cell.uclMinus = CType(hash(e.ColumnIndex), TextBoxCell).uclMinus
                    txt_cell.uclTransferForFractions = CType(hash(e.ColumnIndex), TextBoxCell).uclTransferForFractions
                    txt_cell.uclIntCount = CType(hash(e.ColumnIndex), TextBoxCell).uclIntCount
                    txt_cell.uclDotCount = CType(hash(e.ColumnIndex), TextBoxCell).uclDotCount
                    txt_cell.MaskedTextBox1.ImeMode = Windows.Forms.ImeMode.Off

                    dgv.Controls.Add(txt_cell)

                    If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        ' Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        txt_cell.Left = rect.Left
                        txt_cell.Top = rect.Top
                        txt_cell.Width = rect.Width
                        txt_cell.Height = rect.Height
                        txt_cell.Visible = True

                        'textbox的值為cell value
                        If dgv.CurrentCell.Value Is DBNull.Value Then
                            txt_cell.Text = ""
                        Else
                            txt_cell.Text = dgv.CurrentCell.Value.ToString().Trim()
                        End If

                        txt_cell.SelectNextControl(Me, True, True, True, True)

                    End If

                ElseIf hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.DtpCell" Then

                    dtp_cell.InitialDtpCell(Me, dsDB, dsGrid, e.ColumnIndex, e.RowIndex)

                    dtp_cell.FirstEnterGridCell = True

                    dgv.Controls.Add(dtp_cell)

                    If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        '  Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        dtp_cell.Left = rect.Left
                        dtp_cell.Top = rect.Top
                        ' dtp_cell.Width = rect.Width
                        dtp_cell.Height = rect.Height
                        dtp_cell.Visible = True

                        dtpColumnWidth = dgv.Columns(dgv.CurrentCell.ColumnIndex).Width
                        dgv.Columns(dgv.CurrentCell.ColumnIndex).Width = dtp_cell.Width

                        Try
                            If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then
                                dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.TW

                                '顯示民國
                                If dgv.CurrentCell.Value.ToString().Trim() <> "" Then
                                    dtp_cell.SetValue(DateUtil.TransDateToWE(dgv.CurrentCell.Value.ToString().Trim()))
                                Else
                                    dtp_cell.SetValue(Now.ToShortDateString())
                                End If

                            Else
                                dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.US
                                'dtp的值為cell value
                                If dgv.CurrentCell.Value.ToString().Trim() <> "" Then
                                    dtp_cell.SetValue(dgv.CurrentCell.Value.ToString().Trim())
                                Else
                                    dtp_cell.SetValue(Now.ToShortDateString())
                                End If
                            End If
                        Catch ex As Exception
                            'dtp的值為cell value
                            dtp_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.US
                            If dgv.CurrentCell.Value.ToString().Trim() <> "" Then
                                dtp_cell.SetValue(dgv.CurrentCell.Value.ToString().Trim())
                            Else
                                dtp_cell.SetValue(Now.ToShortDateString())
                            End If
                        End Try

                        dtp_cell.BringToFront()
                        dtp_cell.SelectNextControl(Me, True, True, True, True)

                        dtp_cell.SetFocus()

                    End If

                ElseIf hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.ComboBoxGridCell" Then

                    IsComboBoxGridSetValue = True
                    ' dt = CType(CType(hash(e.ColumnIndex), ComboBoxGridCell).Ds.Tables(0), DataTable)
                    '傳入dgv跟綁dgv的dataset

                    cboGrid_cell.InitialComboBoxGridCell(Me, dsDB, dsGrid, uclColumnCheckBox)

                    cboGrid_cell.FirstEnterGridCell = True

                    '  dgv.Controls.Add(cboGridShow_cell)

                    '一定要用copy,否則會對原本ds作用
                    ' cbo_cell.DataSource = dt.Copy()

                    cboGrid_cell.uclDisplayIndex = CType(hash(e.ColumnIndex), ComboBoxGridCell).DisplayIndex
                    cboGrid_cell.uclValueIndex = CType(hash(e.ColumnIndex), ComboBoxGridCell).ValueIndex
                    cboGrid_cell.uclNonVisibleColIndex = CType(hash(e.ColumnIndex), ComboBoxGridCell).NonVisibleColIndex
                    cboGrid_cell.uclVisibleColIndex = CType(hash(e.ColumnIndex), ComboBoxGridCell).VisibleColIndex

                    If CType(hash(e.ColumnIndex), ComboBoxGridCell).GridWidth <> 0 Then
                        cboGrid_cell.uclGridWidth = CType(hash(e.ColumnIndex), ComboBoxGridCell).GridWidth
                    End If
                    If CType(hash(e.ColumnIndex), ComboBoxGridCell).GridHeight <> 0 Then
                        cboGrid_cell.uclGridHeight = CType(hash(e.ColumnIndex), ComboBoxGridCell).GridHeight
                    End If

                    cboGrid_cell.uclConnDBType = CType(hash(e.ColumnIndex), ComboBoxGridCell).ConnDBType
                    cboGrid_cell.uclQueryType = CType(hash(e.ColumnIndex), ComboBoxGridCell).QueryType
                    cboGrid_cell.uclQueryData = CType(hash(e.ColumnIndex), ComboBoxGridCell).QueryData
                    cboGrid_cell.uclStartQueryLength = CType(hash(e.ColumnIndex), ComboBoxGridCell).StartQueryLength
                    cboGrid_cell.uclHeaderText = CType(hash(e.ColumnIndex), ComboBoxGridCell).HeaderText
                    cboGrid_cell.uclColumnWidth = CType(hash(e.ColumnIndex), ComboBoxGridCell).ColumnWidth
                    cboGrid_cell.uclCtlName = CType(hash(e.ColumnIndex), ComboBoxGridCell).CtlName
                    cboGrid_cell.uclDiseaseTypeId = CType(hash(e.ColumnIndex), ComboBoxGridCell).DiseaseTypeId
                    cboGrid_cell.uclMultiDiseaseTypeId = CType(hash(e.ColumnIndex), ComboBoxGridCell).MultiDiseaseTypeId
                    cboGrid_cell.uclIsComboBoxGridQuery = uclIsComboBoxGridQuery
                    cboGrid_cell.uclEffectiveMode = CType(hash(e.ColumnIndex), ComboBoxGridCell).EffectiveMode
                    cboGrid_cell.uclIsFreeText = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsFreeText
                    cboGrid_cell.uclIsPriorReview = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsPriorReview

                    cboGrid_cell.uclSource = CType(hash(e.ColumnIndex), ComboBoxGridCell).Source
                    cboGrid_cell.uclIsOPD = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsOPD
                    cboGrid_cell.uclIsEPD = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsEPD
                    cboGrid_cell.uclIsIPD = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsIPD
                    cboGrid_cell.IcdType = CType(hash(e.ColumnIndex), ComboBoxGridCell).IcdType
                    cboGrid_cell.IsAllowIcd9Empty = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsAllowIcd9Empty
                    cboGrid_cell.IsAllowIcd10Empty = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsAllowIcd10Empty
                    cboGrid_cell.Is_ChemoDrug = CType(hash(e.ColumnIndex), ComboBoxGridCell).Is_ChemoDrug
                    cboGrid_cell.Is_AllChemoDrug = CType(hash(e.ColumnIndex), ComboBoxGridCell).Is_AllChemoDrug

                    cboGrid_cell.uclIsEqualMatch = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsEqualMatch
                    cboGrid_cell.uclIsCheckPubOrderDc = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsCheckPubOrderDc
                    cboGrid_cell.IsCanSelectDcOrder = CType(hash(e.ColumnIndex), ComboBoxGridCell).IsCanSelectDcOrder
                    cboGrid_cell.uclBasicDateStr = CType(hash(e.ColumnIndex), ComboBoxGridCell).BasicDateStr

                    cboGrid_cell.uclOrderTypeId = CType(hash(e.ColumnIndex), ComboBoxGridCell).OrderTypeId

                    cboGrid_cell.uclMultiOrderTypeId = CType(hash(e.ColumnIndex), ComboBoxGridCell).MultiOrderTypeId

                    cboGrid_cell.uclEmpCode = CType(hash(e.ColumnIndex), ComboBoxGridCell).EmpCode
                    cboGrid_cell.uclDepCode = CType(hash(e.ColumnIndex), ComboBoxGridCell).DepCode
                    cboGrid_cell.ComboBox1.ImeMode = Windows.Forms.ImeMode.Off

                    dgv.Controls.Add(cboGrid_cell)

                    If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        'Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        cboGrid_cell.Left = rect.Left
                        cboGrid_cell.Top = rect.Top
                        cboGrid_cell.Width = rect.Width
                        cboGrid_cell.Height = rect.Height

                        cboGrid_cell.Visible = True

                        cboGrid_cell.uclDoTextChanged = False

                        If dgv.CurrentCell.Value Is DBNull.Value Then
                            cboGrid_cell.Text = ""
                        Else
                            cboGrid_cell.Text = dgv.CurrentCell.Value.ToString().Trim()
                        End If
                        cboGrid_cell.uclDoTextChanged = True

                        cboGrid_cell.SelectNextControl(Me, True, True, True, True)
                        'cboGridShow_cell.SelectNextControl(Me, True, True, False, True)

                    End If

                ElseIf hash(e.ColumnIndex).GetType().ToString() = "Syscom.Client.UCL.UCLPopMemoUI" Then

                    'popMemoUI

                    popMemoUICell.InitialPopMemoCell(Me, dsDB, dsGrid, e.ColumnIndex, e.RowIndex)
                    popMemoUICell.FirstEnterGridCell = True

                    popMemoUICell.Visible = False

                    '一定要用copy,否則會對原本ds作用
                    ' cbo_cell.DataSource = dt.Copy()

                    popMemoUICell.setProperties(CType(hash(e.ColumnIndex), UCLPopMemoUI).MaxLength)

                    dgv.Controls.Add(popMemoUICell)

                    If dgv.CurrentCell.ColumnIndex = e.ColumnIndex Then

                        Dim rect As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, False)
                        '  Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                        popMemoUICell.Left = rect.Left
                        popMemoUICell.Top = rect.Top
                        popMemoUICell.Width = rect.Width
                        popMemoUICell.Height = rect.Height
                        popMemoUICell.Visible = True

                        'popMemoUICell的值為cell value
                        popMemoUICell.setConfirmMessage(dgv.CurrentCell.Value.ToString())

                        popMemoUICell.BringToFront()
                        popMemoUICell.SelectNextControl(Me, True, True, True, True)

                    End If

                End If
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' dgv_ColumnHeaderMouseClick
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellMouseEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.ColumnHeaderMouseClick
        Try
            If IsInitial Then
                Exit Sub
            End If

            SendMyName()

            If cbo_cell IsNot Nothing Then
                cbo_cell.Visible = False
            End If

            If uclBatchColIndex.Trim <> "" Then

                Dim uclBatchColIndexStr() As String = Split(uclBatchColIndex.Trim, ",")

                If textboxUp IsNot Nothing AndAlso uclBatchColIndexStr.Contains(e.ColumnIndex.ToString) AndAlso SelectedIndex().Count > 0 Then

                    textboxUp.SetColumnHeaderIndex(e.ColumnIndex)

                    dgv.Controls.Add(textboxUp)

                    Dim rect As Rectangle = dgv.GetColumnDisplayRectangle(e.ColumnIndex, False)
                    'Dim sexValue As String = dgv.CurrentCell.Value.ToString()
                    textboxUp.Left = rect.Left
                    textboxUp.Top = rect.Top
                    textboxUp.Width = rect.Width
                    textboxUp.Height = rect.Height

                    '出現的地方在滑鼠點的位置
                    'Debug.WriteLine(MousePosition.X.ToString() + "   " + MousePosition.Y.ToString())
                    'Debug.WriteLine(e.X.ToString() + "   " + e.Y.ToString())
                    'Dim pt As Point = dgv.Location
                    'textboxUp.Location = dgv.PointToClient(New Point(MousePosition.X, MousePosition.Y))

                    textboxUp.BringToFront()

                    textboxUp.Visible = True
                    textboxUp.Focus()

                End If
            End If

            If uclIsSortable AndAlso Not IsProcessSorting Then

                HideControlCell("All")
                IsProcessSorting = True

                Dim view As DataView
                Dim tempDS As DataSet
                tempDS = dsGrid.Copy
                Dim FrozenCol As New ArrayList

                If uclHasNewRow OrElse hash IsNot Nothing Then

                    For i As Integer = 0 To dgv.Columns.Count - 1
                        If dgv.Columns(i).Visible Then
                            dgv.CurrentCell = dgv.Item(i, dgv.Rows.Count - 1)
                            'Exit For
                        End If
                        If dgv.Columns(i).Frozen Then
                            FrozenCol.Add(i)
                        End If
                    Next


                    If uclHasNewRow AndAlso tempDS.Tables(0).Rows.Count > 1 Then
                        tempDS.Tables(0).Rows.RemoveAt(tempDS.Tables(0).Rows.Count - 1)
                    End If
                End If

                view = tempDS.Tables(0).DefaultView
                If HeaderClickFlag = 0 Then
                    view.Sort = dgv.Columns(e.ColumnIndex).Name
                    HeaderClickFlag = 1
                Else
                    view.Sort = dgv.Columns(e.ColumnIndex).Name & " DESC"
                    HeaderClickFlag = 0
                End If

                'Dim ds As New DataSet
                tempDS.Tables.Clear()
                tempDS.Tables.Add(view.ToTable.Copy)

                If hash IsNot Nothing Then

                    SetDS(tempDS)

                    If uclHasNewRow AndAlso hash IsNot Nothing Then
                        AddNewRow()
                    End If

                Else

                    Initial(tempDS)

                    If uclHasNewRow Then
                        AddNewRow()
                    End If
                End If

                '修正Sort後 Frozen失效問題
                For i As Integer = 0 To dgv.Columns.Count - 1
                    If FrozenCol.Contains(i) Then
                        dgv.Columns(i).Frozen = True
                    End If
                Next

            End If

            RaiseEvent ColumnHeaderMouseClick(sender, e)

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        Finally
            IsProcessSorting = False
        End Try
    End Sub

    ''' <summary>
    ''' dgv_CurrentCellChanged
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv.CurrentCellChanged
        If IsInitial Then
            Exit Sub
        End If

        SendMyName()
        RaiseEvent CurrentCellChanged(sender, e)

        If hideComboBoxGrid Then
            HideControlCell("")
        End If
        hideComboBoxGrid = True

    End Sub

    ''' <summary>
    ''' dgv_Scroll
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.ScrollEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgv.Scroll

        Dim btnNo As Integer = 0
        SendMyName()
        ' If hideComboBoxGrid Then
        HideControlCell("")
        If cboGrid_cell IsNot Nothing AndAlso cboGrid_cell.Visible Then
            cboGrid_cell.Visible = False
            If cboGridShow_cell IsNot Nothing Then
                cboGridShow_cell.Visible = False
            End If
        End If

        ' End If
        '  hideComboBoxGrid = True

        If uclTreeMode Then
            ProcessTreeScoll(e)
        End If

    End Sub

    ''' <summary>
    ''' dgv_ColumnWidthChanged
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewColumnEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_ColumnWidthChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgv.ColumnWidthChanged
        SendMyName()
        If MultiSelect AndAlso uclColumnCheckBox Then
            dgv.Columns(0).Width = 40
        End If

        If uclTreeMode AndAlso dgv.ColumnCount >= 2 Then
            dgv.Columns(1).Width = 25

        End If

        RaiseEvent ColumnWidthChanged(sender, e)

        Dim btnNo As Integer = 0

        HideControlCell("")
        If cboGrid_cell IsNot Nothing AndAlso cboGrid_cell.Visible Then
            cboGrid_cell.Visible = False
            If cboGridShow_cell IsNot Nothing Then
                cboGridShow_cell.Visible = False
            End If
        End If

        EnterEdit = False
        dgv.Refresh()

    End Sub

    ''' <summary>
    ''' Handles the KeyPress event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgv.KeyPress
        SendMyName()
        '  Debug.WriteLine(Asc(e.KeyChar).ToString())
    End Sub

    ''' <summary>
    ''' Handles the CurrentCellDirtyStateChanged event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv.CurrentCellDirtyStateChanged

        Try
            Dim multiCellValue As Boolean
            SendMyName()

            If dgv.IsCurrentCellDirty Then

                '處理多選的checkBox的value
                If MultiSelect AndAlso uclColumnCheckBox AndAlso dgv.CurrentCell.ColumnIndex = 0 Then
                    multiCellValue = dgv.Item(0, dgv.CurrentCell.RowIndex).Value
                End If

                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)

                '處理多選的checkBox的value
                If MultiSelect AndAlso uclColumnCheckBox AndAlso dgv.CurrentCell.ColumnIndex = 0 Then
                    dgv.Item(0, dgv.CurrentCell.RowIndex).Value = multiCellValue
                    dgv.Refresh()
                    dgv.RefreshEdit()
                End If

                If hash IsNot Nothing AndAlso dgv.Columns(dgv.CurrentCell.ColumnIndex).GetType().ToString() = "System.Windows.Forms.DataGridViewCheckBoxColumn" Then

                    If dgv.CurrentCell.Value Then
                        If MultiSelect AndAlso dgv.CurrentCell.ColumnIndex > 0 Then '多選且非第一行
                            dsDB.Tables(0).Rows(dgv.CurrentCell.RowIndex).Item(dgv.CurrentCell.ColumnIndex - 1 - TreeGridCol) = "Y"
                            dsGrid.Tables(0).Rows(dgv.CurrentCell.RowIndex).Item(dgv.CurrentCell.ColumnIndex - 1 - TreeGridCol) = "Y"
                        ElseIf Not MultiSelect Then '單選
                            dsDB.Tables(0).Rows(dgv.CurrentCell.RowIndex).Item(dgv.CurrentCell.ColumnIndex - TreeGridCol) = "Y"
                            dsGrid.Tables(0).Rows(dgv.CurrentCell.RowIndex).Item(dgv.CurrentCell.ColumnIndex - TreeGridCol) = "Y"
                        End If

                    Else
                        If MultiSelect AndAlso dgv.CurrentCell.ColumnIndex > 0 Then '多選且非第一行
                            dsDB.Tables(0).Rows(dgv.CurrentCell.RowIndex).Item(dgv.CurrentCell.ColumnIndex - 1 - TreeGridCol) = "N"
                            dsGrid.Tables(0).Rows(dgv.CurrentCell.RowIndex).Item(dgv.CurrentCell.ColumnIndex - 1 - TreeGridCol) = "N"
                        ElseIf Not MultiSelect Then '單選
                            dsDB.Tables(0).Rows(dgv.CurrentCell.RowIndex).Item(dgv.CurrentCell.ColumnIndex - TreeGridCol) = "N"
                            dsGrid.Tables(0).Rows(dgv.CurrentCell.RowIndex).Item(dgv.CurrentCell.ColumnIndex - TreeGridCol) = "N"
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Handles the KeyUp event of the ComboBox1 control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    Private Sub ComboBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) ' Handles ComboBox1.KeyUp
        SendMyName()
        Select Case e.KeyCode
            Case Windows.Forms.Keys.Enter

        End Select
    End Sub

    ''' <summary>
    ''' Sets the cell date value.
    ''' </summary>
    ''' <param name="ConIndex">Index of the con.</param>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="UsDate">The us date.</param>
    Public Sub SetCellDateValue(ByVal ConIndex As Integer, ByVal RowIndex As Integer, ByVal UsDate As String)
        Try
            '要轉成民國
            If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then

                If MultiSelect AndAlso uclColumnCheckBox Then

                    If dtpIndexList.Contains(ConIndex - 1) AndAlso IsDate(UsDate) Then
                        Dim dateStr As String = DateUtil.TransDateToROC((CDate(UsDate).ToString("yyyy/MM/dd")))
                        If dateStr.Contains("-") AndAlso dateStr.Contains("/") Then
                            If (Split(dateStr, "/")(0)).Replace("-", "").Length = 1 Then
                                dateStr = "-00" & dateStr.Replace("-", "")
                            ElseIf (Split(dateStr, "/")(0)).Replace("-", "").Length = 2 Then
                                dateStr = "-0" & dateStr.Replace("-", "")
                            End If
                        End If
                        dgv.Rows(RowIndex).Cells(ConIndex).Value = dateStr
                        dsGrid.Tables(0).Rows(RowIndex).Item(ConIndex - 1) = dateStr
                        dsDB.Tables(0).Rows(RowIndex).Item(ConIndex - 1) = UsDate
                    End If
                Else
                    If dtpIndexList.Contains(ConIndex) AndAlso IsDate(UsDate) Then
                        Dim dateStr As String = DateUtil.TransDateToROC((CDate(UsDate).ToString("yyyy/MM/dd")))
                        If dateStr.Contains("-") AndAlso dateStr.Contains("/") Then
                            If (Split(dateStr, "/")(0)).Replace("-", "").Length = 1 Then
                                dateStr = "-00" & dateStr.Replace("-", "")
                            ElseIf (Split(dateStr, "/")(0)).Replace("-", "").Length = 2 Then
                                dateStr = "-0" & dateStr.Replace("-", "")
                            End If
                        End If
                        dgv.Rows(RowIndex).Cells(ConIndex).Value = dateStr
                        dsGrid.Tables(0).Rows(RowIndex).Item(ConIndex) = dateStr
                        dsDB.Tables(0).Rows(RowIndex).Item(ConIndex) = UsDate
                    End If
                End If

            Else
                '西元年
                If MultiSelect AndAlso uclColumnCheckBox Then
                    If dtpIndexList.Contains(ConIndex - 1) AndAlso IsDate(UsDate) Then
                        dgv.Rows(RowIndex).Cells(ConIndex).Value = UsDate
                        dsGrid.Tables(0).Rows(RowIndex).Item(ConIndex - 1) = UsDate
                        dsDB.Tables(0).Rows(RowIndex).Item(ConIndex - 1) = UsDate
                    End If
                Else
                    If dtpIndexList.Contains(ConIndex) AndAlso IsDate(UsDate) Then
                        dgv.Rows(RowIndex).Cells(ConIndex).Value = UsDate
                        dsGrid.Tables(0).Rows(RowIndex).Item(ConIndex) = UsDate
                        dsDB.Tables(0).Rows(RowIndex).Item(ConIndex) = UsDate
                    End If
                End If

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Handles the CellValueChanged event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
    Public Sub dgv_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValueChanged

        Try
            If IsInitial Then
                Exit Sub
            End If

            SendMyName()
            If doCellValueChange Then

                If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then
                    Exit Sub
                End If

                If AllowUserToAddRows AndAlso e.RowIndex = dgv.Rows.Count - 1 Then
                    If MultiSelect AndAlso uclColumnCheckBox AndAlso e.ColumnIndex = 0 Then

                        Exit Sub
                    End If
                    'AddNewRow()
                    dgv.Refresh()
                End If
                If dgv.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.Pink Then
                    dgv.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.White
                End If

                dgv.UpdateCellValue(e.ColumnIndex, e.RowIndex)
                '    Debug.WriteLine(sender.Name & "aaa")
                RaiseEvent CellValueChanged(sender, e)

                '要轉成民國
                'If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then
                '    doCellValueChange = False
                '    If MultiSelect AndAlso uclColumnCheckBox Then

                '        If dtpIndexList.Contains(e.ColumnIndex - 1) AndAlso IsDate(dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                '            Dim dateStr As String = DateUtil.TransDateToROC((CDate(dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("yyyy/MM/dd")))
                '            If dateStr.Contains("-") AndAlso dateStr.Contains("/") Then
                '                If (Split(dateStr, "/")(0)).Replace("-", "").Length = 1 Then
                '                    dateStr = "-00" & dateStr.Replace("-", "")
                '                ElseIf (Split(dateStr, "/")(0)).Replace("-", "").Length = 2 Then
                '                    dateStr = "-0" & dateStr.Replace("-", "")
                '                End If
                '            End If
                '            dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dateStr
                '            dsGrid.Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex - 1) = dateStr
                '        End If
                '    Else
                '        If dtpIndexList.Contains(e.ColumnIndex) AndAlso IsDate(dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                '            Dim dateStr As String = DateUtil.TransDateToROC((CDate(dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("yyyy/MM/dd")))
                '            If dateStr.Contains("-") AndAlso dateStr.Contains("/") Then
                '                If (Split(dateStr, "/")(0)).Replace("-", "").Length = 1 Then
                '                    dateStr = "-00" & dateStr.Replace("-", "")
                '                ElseIf (Split(dateStr, "/")(0)).Replace("-", "").Length = 2 Then
                '                    dateStr = "-0" & dateStr.Replace("-", "")
                '                End If
                '            End If
                '            dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dateStr
                '            dsGrid.Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex) = dateStr
                '        End If
                '    End If

                '    doCellValueChange = True
                'End If

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Handles the CellLeave event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellLeave
        If IsInitial Then
            Exit Sub
        End If

        SendMyName()
        RaiseEvent CellLeave(sender, e)
    End Sub

    ''' <summary>
    ''' Handles the MouseClick event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv.MouseClick
        SendMyName()
        RaiseEvent MouseClick(sender, e)

        If MultiSelect AndAlso uclColumnCheckBox AndAlso uclClickToCheck AndAlso dgv.HitTest(e.X, e.Y).ColumnIndex > 0 Then
            rowIndexFromMouseDown = dgv.HitTest(e.X, e.Y).RowIndex
            If rowIndexFromMouseDown >= 0 Then

                If dgv.Rows(rowIndexFromMouseDown).Cells(0).Value Is DBNull.Value OrElse dgv.Rows(rowIndexFromMouseDown).Cells(0).Value = False Then
                    dgv.Rows(rowIndexFromMouseDown).Cells(0).Value = True

                Else
                    dgv.Rows(rowIndexFromMouseDown).Cells(0).Value = False

                End If

            End If

        End If

    End Sub

    'txt_cell
    ''' <summary>
    ''' Handles the KeyUp event of the txt_cell control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    Private Sub txt_cell_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cell.KeyUp

        RaiseEvent TxtCellKeyUp(sender, e)
    End Sub

    ''' <summary>
    ''' Handles the KeyUp event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv.KeyUp
        SendMyName()
        RaiseEvent KeyUp(sender, e)

        Select Case e.KeyCode
            Case Windows.Forms.Keys.Up

            Case Windows.Forms.Keys.Down

            Case Windows.Forms.Keys.Left

            Case Windows.Forms.Keys.Right

            Case Keys.Tab

            Case Keys.Escape
            Case Keys.Enter

            Case Else
                If Not ComboBoxGridFlag Then
                    EditCell(True)
                End If
                ComboBoxGridFlag = False

        End Select

    End Sub

    ''' <summary>
    ''' Handles the KeyDown event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv.KeyDown
        SendMyName()
        RaiseEvent KeyDown(sender, e)
        If e.KeyData = Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    '
    ''' <summary>
    ''' Processes the command key.
    ''' </summary>
    ''' <param name="msg">以傳址方式傳遞的 <see cref="T:System.Windows.Forms.Message" />，表示要處理的視窗訊息。</param>
    ''' <param name="keyData">其中一個 <see cref="T:System.Windows.Forms.Keys" /> 值，表示要處理的按鍵。</param>
    ''' <returns>如果字元由控制項處理，為 true，否則為 false。</returns>
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try

            SendMyName()
            Select Case keyData
                Case Keys.Enter
                    If cbo_cell.Visible Then
                        cbo_cell.cellPressEnter()
                    ElseIf txt_cell.Visible Then
                        SendKeys.Send("{TAB}")
                    ElseIf cboGrid_cell.Visible Then
                        hideComboBoxGrid = False
                        cboGrid_cell.cellPressEnter()

                    End If
                    Return True '回傳True 才不下移一個Row
                Case Keys.Escape
                    HideControlCell("ESC")

                    Return True

                Case Keys.Up
                    Debug.WriteLine("Up")
                    Debug.WriteLine(dgv.CurrentCell.RowIndex.ToString & " Row " & dgv.CurrentCell.ColumnIndex.ToString & " ColIndex")
                    'SetEditCell(dgv.CurrentCell.RowIndex - 1, dgv.CurrentCell.ColumnIndex)
                    'Case Keys.Down
                    '    Debug.WriteLine("Down")
                    'SetEditCell(dgv.CurrentCell.RowIndex + 1, dgv.CurrentCell.ColumnIndex)
                    '  Return True

                Case Keys.Left
                    Debug.WriteLine("Left")
                    Debug.WriteLine(dgv.CurrentCell.RowIndex.ToString & " Row " & dgv.CurrentCell.ColumnIndex.ToString & " ColIndex")
                    ' SetEditCell(dgv.CurrentCell.RowIndex, dgv.CurrentCell.ColumnIndex - 1)
                Case Keys.Right
                    Debug.WriteLine("Right")
                    Debug.WriteLine(dgv.CurrentCell.RowIndex.ToString & " Row " & dgv.CurrentCell.ColumnIndex.ToString & " ColIndex")
                    ' SetEditCell(dgv.CurrentCell.RowIndex, dgv.CurrentCell.ColumnIndex + 1)
                Case Keys.Space
                Case Keys.Tab
                    Debug.WriteLine("Tab")
                Case Keys.Down
                    Debug.WriteLine("Down")
                    Debug.WriteLine(dgv.CurrentCell.RowIndex.ToString & " Row " & dgv.CurrentCell.ColumnIndex.ToString & " ColIndex")
                    '當按下往下時進行row移動
                    If cboGrid_cell IsNot Nothing AndAlso cboGrid_cell.dgv.Visible Then
                        cboGrid_cell.dgv.Focus()
                        Dim x As Integer = 0
                        If MultiSelect AndAlso uclColumnCheckBox Then
                            x = 1
                        End If

                        For i As Integer = x To cboGrid_cell.dgv.cbo_dgv.Columns.Count
                            If cboGrid_cell.dgv.cbo_dgv.Columns(i).Visible Then
                                cboGrid_cell.dgv.cbo_dgv.CurrentCell = cboGrid_cell.dgv.cbo_dgv.Rows(0).Cells(i)
                                Exit For
                            End If
                        Next

                        Return True
                    End If

            End Select
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    ''' <summary>
    ''' Hides the control cell.
    ''' </summary>
    ''' <param name="esc">The escape.</param>
    Public Sub HideControlCell(ByVal esc As String)
        Try

            EnterEdit = False
            If cbo_cell IsNot Nothing AndAlso cbo_cell.Visible Then
                cbo_cell.Visible = False

            ElseIf txt_cell IsNot Nothing AndAlso txt_cell.Visible Then
                txt_cell.Visible = False
            ElseIf dtp_cell IsNot Nothing AndAlso dtp_cell.Visible Then
                dtp_cell.Visible = False

            ElseIf cboGrid_cell IsNot Nothing AndAlso cboGrid_cell.Visible AndAlso esc = "ESC" Then
                cboGrid_cell.Visible = False
                If cboGridShow_cell IsNot Nothing Then
                    cboGridShow_cell.Visible = False
                End If

                '  cboGrid_cell.Text = "" '影響隨輸隨選的TextChanged

                'If dgv.Contains(cboGrid_cell) Then
                '    dgv.Controls.Remove(cboGrid_cell)
                'End If
            ElseIf popMemoUICell IsNot Nothing AndAlso popMemoUICell.Visible Then

                popMemoUICell.Visible = False

            ElseIf esc = "All" Then

                If cbo_cell IsNot Nothing Then
                    cbo_cell.Visible = False
                End If

                If cboGrid_cell IsNot Nothing Then
                    cboGrid_cell.Visible = False
                End If

                If cboGridShow_cell IsNot Nothing Then
                    cboGridShow_cell.Visible = False
                End If

                If dtp_cell IsNot Nothing Then
                    dtp_cell.Visible = False
                End If

                If txt_cell IsNot Nothing Then
                    txt_cell.Visible = False
                End If

                If popMemoUICell IsNot Nothing Then
                    popMemoUICell.Visible = False
                End If

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "屬性設定"

    ''' <summary>
    ''' Enum SelectType
    ''' </summary>
    Enum SelectType
        ''' <summary>
        ''' The select all
        ''' </summary>
        SelectAll
        ''' <summary>
        ''' The delete all
        ''' </summary>
        DeleteAll
        ''' <summary>
        ''' The doubt
        ''' </summary>
        Doubt
        ''' <summary>
        ''' The print
        ''' </summary>
        Print
    End Enum

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl multi select show CheckBox header].
    ''' </summary>
    ''' <value><c>true</c> if [ucl multi select show CheckBox header]; otherwise, <c>false</c>.</value>
    Public Property uclMultiSelectShowCheckBoxHeader() As Boolean
        Get
            Return _uclMultiSelectShowCheckBoxHeader
        End Get
        Set(ByVal value As Boolean)
            _uclMultiSelectShowCheckBoxHeader = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl do cell enter].
    ''' </summary>
    ''' <value><c>true</c> if [ucl do cell enter]; otherwise, <c>false</c>.</value>
    Public Property uclDoCellEnter() As Boolean
        Get
            Return _uclDoCellEnter
        End Get
        Set(ByVal value As Boolean)
            _uclDoCellEnter = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl is combox click trigger drop down].
    ''' </summary>
    ''' <value><c>true</c> if [ucl is combox click trigger drop down]; otherwise, <c>false</c>.</value>
    Public Property uclIsComboxClickTriggerDropDown() As Boolean
        Get
            Return _uclIsComboxClickTriggerDropDown
        End Get
        Set(ByVal value As Boolean)
            _uclIsComboxClickTriggerDropDown = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl is sortable].
    ''' </summary>
    ''' <value><c>true</c> if [ucl is sortable]; otherwise, <c>false</c>.</value>
    Public Property uclIsSortable() As Boolean
        Get
            Return _uclIsSortable
        End Get
        Set(ByVal value As Boolean)
            _uclIsSortable = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl is ComboBox grid query].
    ''' </summary>
    ''' <value><c>true</c> if [ucl is ComboBox grid query]; otherwise, <c>false</c>.</value>
    Public Property uclIsComboBoxGridQuery() As Boolean
        Get
            Return _uclIsComboBoxGridQuery
        End Get
        Set(ByVal value As Boolean)
            _uclIsComboBoxGridQuery = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the scroll bars.
    ''' </summary>
    ''' <value>The scroll bars.</value>
    Public Property ScrollBars() As System.Windows.Forms.ScrollBars
        Get
            Return dgv.ScrollBars
        End Get
        Set(ByVal value As System.Windows.Forms.ScrollBars)
            dgv.ScrollBars = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the get cell hash.
    ''' </summary>
    ''' <value>The get cell hash.</value>
    Public ReadOnly Property getCellHash() As Hashtable
        Get
            Return hash
        End Get
    End Property

    ''' <summary>
    ''' Gets the item.
    ''' </summary>
    ''' <value>The item.</value>
    Public ReadOnly Property Item(ByVal ColIndex As Integer, ByVal RowIndex As Integer) As System.Windows.Forms.DataGridViewCell
        Get
            Return dgv.Item(ColIndex, RowIndex)
        End Get
        'Set(ByVal value As System.Windows.Forms.DataGridViewCell)
        '    dgv.Item = value
        'End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl has new row].
    ''' </summary>
    ''' <value><c>true</c> if [ucl has new row]; otherwise, <c>false</c>.</value>
    Public Property uclHasNewRow() As Boolean
        Get
            Return _uclHasNewRow
        End Get
        Set(ByVal value As Boolean)
            _uclHasNewRow = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl tree mode].
    ''' </summary>
    ''' <value><c>true</c> if [ucl tree mode]; otherwise, <c>false</c>.</value>
    Public Property uclTreeMode() As Boolean
        Get
            Return _uclTreeMode
        End Get
        Set(ByVal value As Boolean)
            _uclTreeMode = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the column headers default cell style.
    ''' </summary>
    ''' <value>The column headers default cell style.</value>
    Public Property ColumnHeadersDefaultCellStyle() As DataGridViewCellStyle
        Get
            Return dgv.ColumnHeadersDefaultCellStyle
        End Get
        Set(ByVal value As DataGridViewCellStyle)
            dgv.ColumnHeadersDefaultCellStyle = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl read only].
    ''' </summary>
    ''' <value><c>true</c> if [ucl read only]; otherwise, <c>false</c>.</value>
    Public Property uclReadOnly() As Boolean
        Get
            Return dgv.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            dgv.ReadOnly = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the edit mode.
    ''' </summary>
    ''' <value>The edit mode.</value>
    Public Property EditMode() As DataGridViewEditMode
        Get
            Return dgv.EditMode
        End Get
        Set(ByVal value As DataGridViewEditMode)
            dgv.EditMode = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [column headers visible].
    ''' </summary>
    ''' <value><c>true</c> if [column headers visible]; otherwise, <c>false</c>.</value>
    Public Property ColumnHeadersVisible() As Boolean
        Get
            Return dgv.ColumnHeadersVisible
        End Get
        Set(ByVal value As Boolean)
            dgv.ColumnHeadersVisible = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the type of the multi select.
    ''' </summary>
    ''' <value>The type of the multi select.</value>
    Public Property MultiSelectType() As SelectType
        Get
            Return _uclMultiSelectType
        End Get
        Set(ByVal value As SelectType)
            _uclMultiSelectType = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the current cell.
    ''' </summary>
    ''' <value>The current cell.</value>
    Public Property CurrentCell() As System.Windows.Forms.DataGridViewCell
        Get
            Return dgv.CurrentCell
        End Get
        Set(ByVal value As System.Windows.Forms.DataGridViewCell)
            dgv.CurrentCell = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the type of the ucl column control.
    ''' </summary>
    ''' <value>The type of the ucl column control.</value>
    Public Property uclColumnControlType() As String
        Get
            Return _uclColumnControlType
        End Get
        Set(ByVal value As String)
            _uclColumnControlType = value
            SetColumnControlType()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl selected First Show Columns].
    ''' </summary>
    ''' <value>The ucl selected First Show Columns.</value>
    ''' <remarks>by ChenYu.Guo on 2017-05-04</remarks>
    Public Property uclSelectedFirstShowCol() As Integer
        Get
            Return _uclSelectedFirstShowCol
        End Get
        Set(ByVal value As Integer)
            _uclSelectedFirstShowCol = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl selected Last Show Columns].
    ''' </summary>
    ''' <value>The ucl selected Last Show Columns.</value>
    ''' <remarks>by ChenYu.Guo on 2017-05-03</remarks>
    Public Property uclSelectedLastShowCol() As Integer
        Get
            Return _uclSelectedLastShowCol
        End Get
        Set(ByVal value As Integer)
            _uclSelectedLastShowCol = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl selected cell border].
    ''' </summary>
    ''' <value><c>true</c> if [ucl selected cell border]; otherwise, <c>false</c>.</value>
    ''' <remarks>by ChenYu.Guo on 2017-05-02</remarks>
    Public Property uclSelectedCellBorder() As Boolean
        Get
            Return _uclSelectedCellBorder
        End Get
        Set(ByVal value As Boolean)
            _uclSelectedCellBorder = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ucl selected cell border colors.
    ''' </summary>
    ''' <value>The ucl selected cell border colors.</value>
    ''' <remarks>by ChenYu.Guo on 2017-05-02</remarks>
    Public Property uclSelectedCellBorderColors() As Color
        Get
            Return _uclSelectedCellBorderColors
        End Get
        Set(ByVal value As Color)
            _uclSelectedCellBorderColors = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl selected cell border size].
    ''' </summary>
    ''' <value>The ucl selected cell border size.</value>
    ''' <remarks>by ChenYu.Guo on 2017-05-03</remarks>
    Public Property uclSelectedCellBorderSize() As Integer
        Get
            Return _uclSelectedCellBorderSize
        End Get
        Set(ByVal value As Integer)
            _uclSelectedCellBorderSize = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl show cell border].
    ''' </summary>
    ''' <value><c>true</c> if [ucl show cell border]; otherwise, <c>false</c>.</value>
    Public Property uclShowCellBorder() As Boolean
        Get
            Return _uclShowCellBorder
        End Get
        Set(ByVal value As Boolean)
            _uclShowCellBorder = value
        End Set
    End Property

    ' DataGridView.Rows.InsertCopy or DataGridView.Rows.Insert function
    ''' <summary>
    ''' Gets or sets the index of the ucl sort col.
    ''' </summary>
    ''' <value>The index of the ucl sort col.</value>
    Public Property uclSortColIndex() As String
        Get
            Return _uclSortColIndex
        End Get
        Set(ByVal value As String)
            _uclSortColIndex = value
            If dsGrid IsNot Nothing AndAlso dsGrid.Tables.Count > 0 Then
                SortableColumnIndex()
            End If

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the index of the ucl batch col.
    ''' </summary>
    ''' <value>The index of the ucl batch col.</value>
    Public Property uclBatchColIndex() As String
        Get
            Return _uclBatchColIndex
        End Get
        Set(ByVal value As String)
            _uclBatchColIndex = value

        End Set
    End Property

    ''' <summary>
    ''' Gets the current cell address.
    ''' </summary>
    ''' <value>The current cell address.</value>
    Public ReadOnly Property CurrentCellAddress() As System.Drawing.Point
        Get

            Return dgv.CurrentCellAddress
        End Get

    End Property

    ''' <summary>
    ''' Gets or sets the default cell style.
    ''' </summary>
    ''' <value>The default cell style.</value>
    Public Property DefaultCellStyle() As System.Windows.Forms.DataGridViewCellStyle
        Get
            Return dgv.DefaultCellStyle
        End Get
        Set(ByVal value As System.Windows.Forms.DataGridViewCellStyle)
            dgv.DefaultCellStyle = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the automatic size columns mode.
    ''' </summary>
    ''' <value>The automatic size columns mode.</value>
    Public Property AutoSizeColumnsMode() As System.Windows.Forms.DataGridViewAutoSizeColumnMode
        Get
            Return dgv.AutoSizeColumnsMode
        End Get
        Set(ByVal value As System.Windows.Forms.DataGridViewAutoSizeColumnMode)
            dgv.AutoSizeColumnsMode = value

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the automatic size rows mode.
    ''' </summary>
    ''' <value>The automatic size rows mode.</value>
    Public Property AutoSizeRowsMode() As System.Windows.Forms.DataGridViewAutoSizeRowsMode
        Get
            Return dgv.AutoSizeRowsMode
        End Get
        Set(ByVal value As System.Windows.Forms.DataGridViewAutoSizeRowsMode)
            dgv.AutoSizeRowsMode = value

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the selection mode.
    ''' </summary>
    ''' <value>The selection mode.</value>
    Public Property SelectionMode() As System.Windows.Forms.DataGridViewSelectionMode
        Get
            Return dgv.SelectionMode
        End Get
        Set(ByVal value As System.Windows.Forms.DataGridViewSelectionMode)
            dgv.SelectionMode = value
        End Set
    End Property

    ''' <summary>
    ''' 取得或設定值，指出控制項是否能接受使用者拖放上來的資料。
    ''' </summary>
    ''' <value><c>true</c> if [allow drop]; otherwise, <c>false</c>.</value>
    ''' <PermissionSet>
    '''   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    '''   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    '''   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    '''   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ''' </PermissionSet>
    Public Overrides Property AllowDrop() As Boolean
        Get
            Return dgv.AllowDrop
        End Get
        Set(ByVal value As Boolean)
            dgv.AllowDrop = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [multi select].
    ''' </summary>
    ''' <value><c>true</c> if [multi select]; otherwise, <c>false</c>.</value>
    Public Property MultiSelect() As Boolean
        Get
            Return _MultiSelect
        End Get
        Set(ByVal value As Boolean)
            _MultiSelect = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [allow user to order columns].
    ''' </summary>
    ''' <value><c>true</c> if [allow user to order columns]; otherwise, <c>false</c>.</value>
    Public Property AllowUserToOrderColumns() As Boolean
        Get
            Return dgv.AllowUserToOrderColumns
        End Get
        Set(ByVal value As Boolean)
            dgv.AllowUserToOrderColumns = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [allow user to resize columns].
    ''' </summary>
    ''' <value><c>true</c> if [allow user to resize columns]; otherwise, <c>false</c>.</value>
    Public Property AllowUserToResizeColumns() As Boolean
        Get
            Return dgv.AllowUserToResizeColumns
        End Get
        Set(ByVal value As Boolean)
            dgv.AllowUserToResizeColumns = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [allow user to add rows].
    ''' </summary>
    ''' <value><c>true</c> if [allow user to add rows]; otherwise, <c>false</c>.</value>
    Public Property AllowUserToAddRows() As Boolean
        Get
            Return _AllowUserToAddRows
        End Get
        Set(ByVal value As Boolean)
            _AllowUserToAddRows = value

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [allow user to resize rows].
    ''' </summary>
    ''' <value><c>true</c> if [allow user to resize rows]; otherwise, <c>false</c>.</value>
    Public Property AllowUserToResizeRows() As Boolean
        Get
            Return dgv.AllowUserToResizeRows
        End Get
        Set(ByVal value As Boolean)
            dgv.AllowUserToResizeRows = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the selected cells.
    ''' </summary>
    ''' <value>The selected cells.</value>
    Public ReadOnly Property SelectedCells() As DataGridViewSelectedCellCollection
        Get
            Return dgv.SelectedCells
        End Get

    End Property
    ''' <summary>
    ''' Gets the selected rows.
    ''' </summary>
    ''' <value>The selected rows.</value>
    Public ReadOnly Property SelectedRows() As DataGridViewSelectedRowCollection
        Get

            Return dgv.SelectedRows
        End Get

    End Property

    ''' <summary>
    ''' Gets the selected columns.
    ''' </summary>
    ''' <value>The selected columns.</value>
    Public ReadOnly Property SelectedColumns() As DataGridViewSelectedColumnCollection
        Get
            Return dgv.SelectedColumns
        End Get

    End Property

    ''' <summary>
    ''' Gets the columns.
    ''' </summary>
    ''' <value>The columns.</value>
    Public ReadOnly Property Columns() As System.Windows.Forms.DataGridViewColumnCollection
        Get
            Return dgv.Columns
        End Get

    End Property

    ''' <summary>
    ''' Gets the rows.
    ''' </summary>
    ''' <value>The rows.</value>
    Public ReadOnly Property Rows() As System.Windows.Forms.DataGridViewRowCollection
        Get
            Return dgv.Rows
        End Get

    End Property
    ''' <summary>
    ''' Gets the current row.
    ''' </summary>
    ''' <value>The current row.</value>
    Public ReadOnly Property CurrentRow() As System.Windows.Forms.DataGridViewRow
        Get
            Return dgv.CurrentRow

        End Get

    End Property

    ''' <summary>
    ''' Sets the ds.
    ''' </summary>
    ''' <param name="ds">The ds.</param>
    Public Sub SetDS(ByRef ds As DataSet)

        If dsGrid IsNot Nothing Then

            If dsDB IsNot Nothing Then

                dsDB.Tables.Clear()

            End If

            dsGrid.Tables.Clear()
            If hash IsNot Nothing Then
                hash.Remove(-1)
                hash.Add(-1, ds)
                Initial(hash)
            End If

        End If

    End Sub

    ''' <summary>
    ''' Clears the ds.
    ''' </summary>
    Public Sub ClearDS()

        If dsGrid IsNot Nothing AndAlso dsGrid.Tables.Count > 0 Then
            dsGrid.Tables(0).Rows.Clear()
        End If
        If dsDB IsNot Nothing AndAlso dsDB.Tables.Count > 0 Then
            dsDB.Tables(0).Rows.Clear()
        End If

        If dsDgvReadOnly IsNot Nothing AndAlso dsDgvReadOnly.Tables.Count > 0 Then
            dsDgvReadOnly.Tables(0).Rows.Clear()
        End If

    End Sub

    ''' <summary>
    ''' Gets or sets the data source.
    ''' </summary>
    ''' <value>The data source.</value>
    Public Property DataSource() As DataSet
        Get
            Return dsDB
        End Get
        Set(ByVal value As DataSet)

            If value IsNot Nothing AndAlso value.Tables.Count > 0 Then
                dgv.DataSource = value.Tables(0)
                dsGrid = value.Copy
                dsDB = dsGrid.Copy()
                '設定Cell是否ReadOnly
                ProcessReadOnlyCell()
                dgv.ClearSelection()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the index of the ucl non visible col.
    ''' </summary>
    ''' <value>The index of the ucl non visible col.</value>
    Public Property uclNonVisibleColIndex() As String
        Get
            Return _uclNonVisibleColIndex
        End Get
        Set(ByVal value As String)
            _uclNonVisibleColIndex = value
            If dsGrid IsNot Nothing AndAlso _uclNonVisibleColIndex.Trim() <> "" Then
                SetNonVisibleCol()
            End If

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the index of the ucl visible col.
    ''' </summary>
    ''' <value>The index of the ucl visible col.</value>
    Public Property uclVisibleColIndex() As String
        Get
            Return _uclVisibleColIndex
        End Get
        Set(ByVal value As String)
            _uclVisibleColIndex = value
            If dsGrid IsNot Nothing AndAlso _uclVisibleColIndex.Trim() <> "" Then
                SetVisibleCol()
            End If

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ucl header text.
    ''' </summary>
    ''' <value>The ucl header text.</value>
    Public Property uclHeaderText() As String
        Get
            Return _uclHeaderText
        End Get
        Set(ByVal value As String)

            _uclHeaderText = value
            If dsGrid IsNot Nothing AndAlso dsGrid.Tables.Count > 0 AndAlso _uclHeaderText.Trim() <> "" Then

                SetHeaderText()
            End If

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the width of the ucl column.
    ''' </summary>
    ''' <value>The width of the ucl column.</value>
    Public Property uclColumnWidth() As String
        Get
            Return _uclColumnWidth
        End Get
        Set(ByVal value As String)
            If value <> "" AndAlso UCLFormUtil.isResizeable(Me) Then
                _uclColumnWidth = UCLFormUtil.ReSetGridWidth(Me, value)

            Else
                _uclColumnWidth = value
            End If

            If dsGrid IsNot Nothing AndAlso dsGrid.Tables.Count > 0 AndAlso _uclColumnWidth.Trim() <> "" Then
                SetColWidth()
            End If

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ucl column alignment.
    ''' </summary>
    ''' <value>The ucl column alignment.</value>
    Public Property uclColumnAlignment() As String
        Get
            Return _uclColumnAlignment
        End Get
        Set(ByVal value As String)
            _uclColumnAlignment = value
            If dsGrid IsNot Nothing AndAlso dsGrid.Tables.Count > 0 AndAlso _uclColumnAlignment.Trim() <> "" Then
                SetColumnAlignment()
            End If

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl column CheckBox].
    ''' </summary>
    ''' <value><c>true</c> if [ucl column CheckBox]; otherwise, <c>false</c>.</value>
    Public Property uclColumnCheckBox() As Boolean
        Get
            Return _uclColumnCheckBox
        End Get
        Set(ByVal value As Boolean)
            _uclColumnCheckBox = value
            If dsGrid IsNot Nothing Then

            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl click to check].
    ''' </summary>
    ''' <value><c>true</c> if [ucl click to check]; otherwise, <c>false</c>.</value>
    Public Property uclClickToCheck() As Boolean
        Get
            Return _uclClickToCheck
        End Get
        Set(ByVal value As Boolean)
            _uclClickToCheck = value
            If dsGrid IsNot Nothing Then

            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl is do order check].
    ''' </summary>
    ''' <value><c>true</c> if [ucl is do order check]; otherwise, <c>false</c>.</value>
    Public Property uclIsDoOrderCheck() As Boolean
        Get
            Return _uclIsDoOrderCheck
        End Get
        Set(ByVal value As Boolean)
            _uclIsDoOrderCheck = value

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl is uclIsDoQueryComboBoxGrid].
    ''' </summary>
    ''' <value><c>true</c> if [ucl is uclIsDoQueryComboBoxGrid]; otherwise, <c>false</c>.</value>
    Public Property uclIsDoQueryComboBoxGrid() As Boolean
        Get
            Return _uclIsDoQueryComboBoxGrid
        End Get
        Set(ByVal value As Boolean)
            _uclIsDoQueryComboBoxGrid = value

        End Set
    End Property


    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl is alternating rows colors].
    ''' </summary>
    ''' <value><c>true</c> if [ucl is alternating rows colors]; otherwise, <c>false</c>.</value>
    Public Property uclIsAlternatingRowsColors() As Boolean
        Get
            Return _uclIsAlternatingRowsColors
        End Get
        Set(ByVal value As Boolean)
            _uclIsAlternatingRowsColors = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ucl alternating rows colors.
    ''' </summary>
    ''' <value>The ucl alternating rows colors.</value>
    Public Property uclAlternatingRowsColors() As Color
        Get
            Return _uclAlternatingRowsColors
        End Get
        Set(ByVal value As Color)
            _uclAlternatingRowsColors = value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' DataGridView新增一空白列
    ''' </summary>
    Public Sub AddNewRow()
        Try
            If dsGrid IsNot Nothing AndAlso dsDB IsNot Nothing AndAlso dsGrid.Tables.Count > 0 AndAlso dsDB.Tables.Count > 0 Then

                Dim nullData1 = dsDB.Tables(0).NewRow()
                Dim nullData2 = dsGrid.Tables(0).NewRow()

                For i = 0 To dsGrid.Tables(0).Columns.Count - 1

                    If dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.STRING" Then
                        If dsGrid.Tables(0).Columns(i).DefaultValue IsNot DBNull.Value AndAlso dsGrid.Tables(0).Columns(i).DefaultValue.ToString.Trim <> "" Then
                            nullData1.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue.ToString.Trim
                            nullData2.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue.ToString.Trim
                        Else
                            nullData1.Item(i) = ""
                            nullData2.Item(i) = ""
                        End If

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.INTEGER" Then

                        If dsGrid.Tables(0).Columns(i).DefaultValue IsNot DBNull.Value AndAlso dsGrid.Tables(0).Columns(i).DefaultValue <> 0 Then
                            nullData1.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                            nullData2.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                        Else
                            nullData1.Item(i) = 0
                            nullData2.Item(i) = 0
                        End If

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.INT32" Then
                        If dsGrid.Tables(0).Columns(i).DefaultValue IsNot DBNull.Value AndAlso dsGrid.Tables(0).Columns(i).DefaultValue <> 0 Then
                            nullData1.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                            nullData2.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                        Else
                            nullData1.Item(i) = 0
                            nullData2.Item(i) = 0
                        End If
                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.INT64" Then
                        If dsGrid.Tables(0).Columns(i).DefaultValue IsNot DBNull.Value AndAlso dsGrid.Tables(0).Columns(i).DefaultValue <> 0 Then
                            nullData1.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                            nullData2.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                        Else
                            nullData1.Item(i) = 0
                            nullData2.Item(i) = 0
                        End If

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.DECIMAL" Then
                        If dsGrid.Tables(0).Columns(i).DefaultValue IsNot DBNull.Value AndAlso dsGrid.Tables(0).Columns(i).DefaultValue <> 0 Then
                            nullData1.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                            nullData2.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                        Else
                            nullData1.Item(i) = 0.0
                            nullData2.Item(i) = 0.0
                        End If

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.DATETIME" Then
                        If dsGrid.Tables(0).Columns(i).AllowDBNull Then
                            nullData1.Item(i) = DBNull.Value  ' Now.ToShortDateString()
                            nullData2.Item(i) = DBNull.Value ' Now.ToShortDateString()
                        Else
                            Try
                                If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then

                                    nullData1.Item(i) = Now.ToShortDateString() ' TranWE(CDate(Now.ToString("yyyy/MM/dd")), "/")
                                    nullData2.Item(i) = TranWE(CDate(Now.ToString("yyyy/MM/dd")), "/")

                                Else
                                    nullData1.Item(i) = Now.ToShortDateString()
                                    nullData2.Item(i) = Now.ToShortDateString()
                                End If
                            Catch ex As Exception
                                nullData1.Item(i) = Now.ToShortDateString()
                                nullData2.Item(i) = Now.ToShortDateString()
                            End Try

                        End If

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.DATA.DATASET" Then

                        nullData1.Item(i) = Nothing
                        nullData2.Item(i) = Nothing

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.TIMESPAN" Then
                        nullData1.Item(i) = "00.00"
                        nullData2.Item(i) = "00.00"

                    Else
                        nullData1.Item(i) = ""
                        nullData2.Item(i) = ""
                    End If
                Next

                dsDgvReadOnly.Tables(0).Rows.Add()
                dsDB.Tables(0).Rows.Add(nullData1)
                dsGrid.Tables(0).Rows.Add(nullData2)

            End If
        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"AddNewRow錯誤-" & ex.ToString.Trim}, "")
        End Try
    End Sub

    ''' <summary>
    ''' DataGridView新增一空白列
    ''' </summary>
    ''' <param name="RowIndex">Index of the row.</param>
    Public Sub AddNewRowAt(ByVal RowIndex As Integer)
        Try
            If dsGrid IsNot Nothing AndAlso dsDB IsNot Nothing AndAlso dsGrid.Tables.Count > 0 AndAlso dsDB.Tables.Count > 0 Then

                Dim nullData1 = dsDB.Tables(0).NewRow()
                Dim nullData2 = dsGrid.Tables(0).NewRow()

                For i = 0 To dsGrid.Tables(0).Columns.Count - 1

                    If dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.STRING" Then
                        If dsGrid.Tables(0).Columns(i).DefaultValue IsNot DBNull.Value AndAlso dsGrid.Tables(0).Columns(i).DefaultValue.ToString.Trim <> "" Then
                            nullData1.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue.ToString.Trim
                            nullData2.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue.ToString.Trim
                        Else
                            nullData1.Item(i) = ""
                            nullData2.Item(i) = ""
                        End If

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.INTEGER" Then

                        If dsGrid.Tables(0).Columns(i).DefaultValue IsNot DBNull.Value AndAlso dsGrid.Tables(0).Columns(i).DefaultValue <> 0 Then
                            nullData1.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                            nullData2.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                        Else
                            nullData1.Item(i) = 0
                            nullData2.Item(i) = 0
                        End If

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.INT32" Then
                        If dsGrid.Tables(0).Columns(i).DefaultValue IsNot DBNull.Value AndAlso dsGrid.Tables(0).Columns(i).DefaultValue <> 0 Then
                            nullData1.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                            nullData2.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                        Else
                            nullData1.Item(i) = 0
                            nullData2.Item(i) = 0
                        End If
                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.INT64" Then
                        If dsGrid.Tables(0).Columns(i).DefaultValue IsNot DBNull.Value AndAlso dsGrid.Tables(0).Columns(i).DefaultValue <> 0 Then
                            nullData1.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                            nullData2.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                        Else
                            nullData1.Item(i) = 0
                            nullData2.Item(i) = 0
                        End If

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.DECIMAL" Then
                        If dsGrid.Tables(0).Columns(i).DefaultValue IsNot DBNull.Value AndAlso dsGrid.Tables(0).Columns(i).DefaultValue <> 0 Then
                            nullData1.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                            nullData2.Item(i) = dsGrid.Tables(0).Columns(i).DefaultValue
                        Else
                            nullData1.Item(i) = 0.0
                            nullData2.Item(i) = 0.0
                        End If

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.DATETIME" Then
                        If dsGrid.Tables(0).Columns(i).AllowDBNull Then
                            nullData1.Item(i) = DBNull.Value  ' Now.ToShortDateString()
                            nullData2.Item(i) = DBNull.Value ' Now.ToShortDateString()
                        Else
                            Try
                                If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then

                                    nullData1.Item(i) = Now.ToShortDateString() ' TranWE(CDate(Now.ToString("yyyy/MM/dd")), "/")
                                    nullData2.Item(i) = TranWE(CDate(Now.ToString("yyyy/MM/dd")), "/")

                                Else
                                    nullData1.Item(i) = Now.ToShortDateString()
                                    nullData2.Item(i) = Now.ToShortDateString()
                                End If
                            Catch ex As Exception
                                nullData1.Item(i) = Now.ToShortDateString()
                                nullData2.Item(i) = Now.ToShortDateString()
                            End Try
                        End If

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.DATA.DATASET" Then

                        nullData1.Item(i) = Nothing
                        nullData2.Item(i) = Nothing

                    ElseIf dsGrid.Tables(0).Columns(i).DataType.ToString.ToUpper() = "SYSTEM.TIMESPAN" Then
                        nullData1.Item(i) = "00:00"
                        nullData2.Item(i) = "00:00"

                    Else
                        nullData1.Item(i) = ""
                        nullData2.Item(i) = ""
                    End If
                Next

                dsDB.Tables(0).Rows.InsertAt(nullData1, RowIndex)

                dsGrid.Tables(0).Rows.InsertAt(nullData2, RowIndex)
                dsDgvReadOnly.Tables(0).Rows.InsertAt(dsDgvReadOnly.Tables(0).NewRow, RowIndex)

            End If
        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"AddNewRowAt錯誤-" & ex.ToString.Trim}, "")
        End Try
    End Sub

    ''' <summary>
    ''' DataGridView刪除一資料列
    ''' </summary>
    ''' <param name="RowIndex">Index of the row.</param>
    Public Sub RemoveRowAt(ByVal RowIndex As Integer)
        Try
            If dsGrid IsNot Nothing AndAlso dsDB IsNot Nothing AndAlso dsGrid.Tables.Count > 0 AndAlso dsDB.Tables.Count > 0 Then
                If CheckMethodUtil.CheckHasValue(dsDB) Then
                    dsDB.Tables(0).Rows.RemoveAt(RowIndex)
                End If
                If CheckMethodUtil.CheckHasValue(dsGrid) Then
                    dsGrid.Tables(0).Rows.RemoveAt(RowIndex)
                End If
                dsDgvReadOnly.Tables(0).Rows.RemoveAt(RowIndex)

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString) 'MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"RemoveRowAt錯誤-" & ex.ToString.Trim}, "")
        End Try
    End Sub

    ''' <summary>
    ''' DataGridView插入一資料列
    ''' </summary>
    ''' <param name="rowData">The row data.</param>
    ''' <param name="RowIndex">Index of the row.</param>
    Public Sub InsertRowDbDsAt(ByVal rowData As DataRow, ByVal RowIndex As Integer)
        Try
            If RowIndex <= dsDB.Tables(0).Rows.Count Then
                Dim row As DataRow
                row = dsDB.Tables(0).NewRow
                row.ItemArray = rowData.ItemArray
                dsDB.Tables(0).Rows.InsertAt(row, RowIndex)

            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' DataGridView插入一資料列
    ''' </summary>
    ''' <param name="rowData">The row data.</param>
    ''' <param name="RowIndex">Index of the row.</param>
    Public Sub InsertRowGridDsAt(ByVal rowData As DataRow, ByVal RowIndex As Integer)
        Try
            If RowIndex <= dsGrid.Tables(0).Rows.Count Then
                Dim row As DataRow
                row = dsGrid.Tables(0).NewRow
                row.ItemArray = rowData.ItemArray
                dsGrid.Tables(0).Rows.InsertAt(row, RowIndex)
                dsDgvReadOnly.Tables(0).Rows.InsertAt(dsDgvReadOnly.Tables(0).NewRow, RowIndex)
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' DataGridView初始化 一般one dataset的grid用
    ''' ds:來源資料
    ''' </summary>
    ''' <param name="ds">The ds.</param>
    Public Overloads Sub Initial(ByVal ds As DataSet)

        Try
            Dim ColumnHeadersVisible As Boolean = dgv.ColumnHeadersVisible
            Me.Visible = False
            doCellValueChange = False
            IsInitial = True

            If dgv.Columns.Count > 0 Then

                If MultiSelect AndAlso uclColumnCheckBox Then
                    For i As Integer = dgv.Columns.Count - 1 To 1 Step -1
                        dgv.Columns.RemoveAt(i)
                    Next
                Else
                    For i As Integer = dgv.Columns.Count - 1 To 0 Step -1
                        dgv.Columns.RemoveAt(i)
                    Next
                End If

            End If

            '多選初始化
            MultiSelectInitial()
            If uclTreeMode AndAlso Not dgv.Columns.Contains("TreeCol") Then
                Dim a As New ArrayList

                hashTree = New Hashtable
                hashGrid = New Hashtable

                dgv.Columns.Add("TreeCol", " ")
                dgv.Columns(1).Width = 25
                TreeGridCol = 1

                AllowDrop = False
            Else
                TreeGridCol = 0
            End If

            dsGrid = ds
            dsDB = dsGrid.Copy()
            '設定Cell是否ReadOnly
            ProcessReadOnlyCell()

            If AllowUserToAddRows Then
                AddNewRow()
            End If

            If dsGrid IsNot Nothing AndAlso dsGrid.Tables.Count > 0 Then
                dgv.ColumnHeadersVisible = False
                dgv.DataSource = dsGrid.Tables(0).Clone

                Me.Visible = False
                SetHeaderText(False)
                Me.Visible = False
                SetColumnAlignment(False)
                Me.Visible = False
                SetColWidth(False)

                If MultiSelect AndAlso uclColumnCheckBox Then
                    dgv.Columns(0).Width = 40
                    dgv.Columns(0).Frozen = True
                End If

                SetColReadOnly()
                dgv.ClearSelection()
                SortableColumnIndex()

                If uclNonVisibleColIndex <> "" Then
                    SetNonVisibleCol(False)

                ElseIf uclVisibleColIndex <> "" Then
                    SetVisibleCol(False)
                End If

                dgv.DataSource = dsGrid.Tables(0)
            Else
                dgv.DataSource = Nothing

            End If
            dgv.ClearSelection()
            doCellValueChange = True
            dgv.ColumnHeadersVisible = ColumnHeadersVisible
            IsInitial = False
            Me.Visible = True

            If uclIsAlternatingRowsColors Then
                SetAlternatingRowsColors(Color.WhiteSmoke)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#Region " Initial"

#Region " dt "

    ''' <summary>
    ''' DataGridView初始化
    ''' dt:來源資料
    ''' </summary>
    ''' <param name="dt">要顯示的資料DataTable</param>
    Public Overloads Sub Initial(ByRef dt As DataTable)

        Dim dsTemp As New DataSet

        dsTemp.Tables.Add(dt.Copy)

        Initial(dsTemp)

    End Sub

#End Region

#Region " ht; ColumnText ; ColumnVisibleIndex "

    ''' <summary>
    ''' DataGridView初始化
    ''' ht:來源資料;ColumnText : "XXX,OOO,欄位名稱";ColumnVisibleIndex: "1,3,欄位顯示index"
    ''' </summary>
    ''' <param name="ht">要顯示的資料HashTable</param>
    ''' <param name="ColumnText">要顯示的欄位名稱 EX:"XXX,OOO"</param>
    ''' <param name="ColumnVisibleIndex">要顯示的欄位index EX:"1,3,4,5"</param>
    Public Overloads Sub Initial(ByRef ht As Hashtable, ByVal ColumnText As String, ByVal ColumnVisibleIndex As String)

        Try
            Initial(ht)

            uclHeaderText = ColumnText

            'uclColumnWidth = globalColumnWidthDgvDrug

            uclVisibleColIndex = ColumnVisibleIndex

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " dt; ColumnText ; ColumnVisibleIndex "

    ''' <summary>
    ''' DataGridView初始化
    ''' dt:來源資料;ColumnText : "XXX,OOO,欄位名稱";ColumnVisibleIndex: "1,3,欄位顯示index"
    ''' </summary>
    ''' <param name="dt">要顯示的資料DataTable</param>
    ''' <param name="ColumnText">要顯示的欄位名稱 EX:"XXX,OOO"</param>
    ''' <param name="ColumnVisibleIndex">要顯示的欄位index EX:"1,3,4,5"</param>
    Public Overloads Sub Initial(ByRef dt As DataTable, ByVal ColumnText As String, ByVal ColumnVisibleIndex As String)

        Try
            Initial(dt)

            uclHeaderText = ColumnText

            'uclColumnWidth = globalColumnWidthDgvDrug

            uclVisibleColIndex = ColumnVisibleIndex

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " ds; ColumnText; ColumnVisibleIndex "

    ''' <summary>
    ''' DataGridView初始化
    ''' ds:來源資料;ColumnText : "XXX,OOO,欄位名稱";ColumnVisibleIndex: "1,3,欄位顯示index"
    ''' </summary>
    ''' <param name="ds">要顯示的資料Dataset,</param>
    ''' <param name="ColumnText">要顯示的欄位名稱 EX:"XXX,OOO"</param>
    ''' <param name="ColumnVisibleIndex">要顯示的欄位index EX:"1,3,4,5"</param>
    Public Overloads Sub Initial(ByRef ds As DataSet, ByRef ColumnText As String, ByVal ColumnVisibleIndex As String)
        Try

            If ds.Tables.Count > 0 Then
                Initial(ds.Tables(0), ColumnText, ColumnVisibleIndex)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " ht; ColumnText ; ColumnVisibleIndex; ColumnWidth "

    ''' <summary>
    ''' DataGridView初始化
    ''' ht:來源資料;ColumnText : "XXX,OOO,欄位名稱";ColumnVisibleIndex: "1,3,欄位顯示index";ColumnWidth:"80,80,欄位寬度"
    ''' </summary>
    ''' <param name="ht">要顯示的資料HashTable</param>
    ''' <param name="ColumnText">要顯示的欄位名稱 EX:"XXX,OOO"</param>
    ''' <param name="ColumnVisibleIndex">要顯示的欄位index EX:"1,3,4,5"</param>
    ''' <param name="ColumnWidth">要顯示的欄位寬度 EX:"80,80,150"</param>
    Public Overloads Sub Initial(ByRef ht As Hashtable, ByVal ColumnText As String, ByVal ColumnVisibleIndex As String, ByVal ColumnWidth As String)

        Try

            Initial(ht, ColumnText, ColumnVisibleIndex)

            uclColumnWidth = ColumnWidth

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " dt; ColumnText ; ColumnVisibleIndex; ColumnWidth "

    ''' <summary>
    ''' DataGridView初始化
    ''' dt:來源資料;ColumnText : "XXX,OOO,欄位名稱";ColumnVisibleIndex: "1,3,欄位顯示index";ColumnWidth:"80,80,欄位寬度"
    ''' </summary>
    ''' <param name="dt">要顯示的資料DataTable</param>
    ''' <param name="ColumnText">要顯示的欄位名稱 EX:"XXX,OOO"</param>
    ''' <param name="ColumnVisibleIndex">要顯示的欄位index EX:"1,3,4,5"</param>
    ''' <param name="ColumnWidth">要顯示的欄位寬度 EX:"80,80,150"</param>
    Public Overloads Sub Initial(ByRef dt As DataTable, ByVal ColumnText As String, ByVal ColumnVisibleIndex As String, ByVal ColumnWidth As String)

        Try

            Initial(dt, ColumnText, ColumnVisibleIndex)

            uclColumnWidth = ColumnWidth

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " ds; ColumnText ; ColumnVisibleIndex; ColumnWidth  "

    ''' <summary>
    ''' DataGridView初始化 一般one dataset的grid用
    ''' ds:來源資料;ColumnText : "XXX,OOO,欄位名稱";ColumnVisibleIndex: "1,3,欄位顯示index";ColumnWidth:"80,80,欄位寬度"
    ''' </summary>
    ''' <param name="ds">要顯示的資料Dataset,</param>
    ''' <param name="ColumnText">要顯示的欄位名稱 EX:"XXX,OOO"</param>
    ''' <param name="ColumnVisibleIndex">要顯示的欄位index EX:"1,3,4,5"</param>
    ''' <param name="ColumnWidth">要顯示的欄位寬度 EX:"80,80,150"</param>
    Public Overloads Sub Initial(ByRef ds As DataSet, ByRef ColumnText As String, ByVal ColumnVisibleIndex As String, ByVal ColumnWidth As String)
        Try

            If ds.Tables.Count > 0 Then
                Initial(ds.Tables(0), ColumnText, ColumnVisibleIndex, ColumnWidth)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " Initial"

#End Region

#Region " Initial"

#End Region

#End Region

    ''' <summary>
    ''' DataGridView初始化 具ucl ComboBox,ComboBoxGrid...etc須傳多個dataset用
    ''' ht:來源資料
    ''' </summary>
    ''' <param name="ht">The ht.</param>
    Public Overloads Sub Initial(ByRef ht As Hashtable)

        Try

            '避免多次Initial hashTable
            'If dsGrid IsNot Nothing Then
            '    SetDS(CType(ht(-1), DataSet).Copy)
            '    Exit Sub
            'End If
            Dim ColumnHeadersVisible As Boolean = dgv.ColumnHeadersVisible
            IsInitial = True
            Me.Visible = False
            doCellValueChange = False
            dtpIndexList.Clear()

            ''會影響外部的DS
            ClearDS()
            If dgv.Columns.Count > 0 Then

                If MultiSelect AndAlso uclColumnCheckBox Then
                    For i As Integer = dgv.Columns.Count - 1 To 1 Step -1
                        dgv.Columns.RemoveAt(i)
                    Next
                Else
                    For i As Integer = dgv.Columns.Count - 1 To 0 Step -1
                        dgv.Columns.RemoveAt(i)
                    Next
                End If

            End If

            MultiSelectInitial()

            If uclTreeMode AndAlso Not dgv.Columns.Contains("TreeCol") Then

                hashTree = New Hashtable
                hashGrid = New Hashtable

                dgv.Columns.Add("TreeCol", " ")
                dgv.Columns(1).Width = 25
                TreeGridCol = 1

                AllowDrop = False

            Else
                TreeGridCol = 0
            End If

            hash = ht

            '  dsGrid = CType(hash(-1), DataSet)

            '=============
            'dsDB = CType(hash(-1), DataSet).Copy
            dsGrid = ProcessSourceDS(hash, CType(hash(-1), DataSet))
            dsGrid = ProcessDateTimePickerCellData(hash, dsGrid, dsDB)
            '=============

            'dsDB = dsGrid.Copy()
            ProcessReadOnlyCell()

            If AllowUserToAddRows Then
                AddNewRow()
            End If

            CreateUclCells()

            AddHandler cbo_cell.KeyUp, AddressOf ComboBox1_KeyUp
            AddHandler cbo_cell.ComboBoxCellSelectedValueChangedAndLeave, AddressOf RaiseComboBoxCellSelectedValueChangedAndLeaveEvent

            If dsGrid IsNot Nothing AndAlso dsGrid.Tables.Count > 0 Then
                dgv.ColumnHeadersVisible = False
                dgv.DataSource = dsGrid.Tables(0).Clone

                Me.Visible = False
                SetHeaderText(False)

                Me.Visible = False

                SetColumnAlignment(False)

                Me.Visible = False
                SetColWidth(False)

                If MultiSelect AndAlso uclColumnCheckBox Then
                    dgv.Columns(0).Width = 40
                    dgv.Columns(0).Frozen = True
                End If

                SetColReadOnly()

                dgv.ClearSelection()

                SortableColumnIndex()

                If uclNonVisibleColIndex <> "" Then
                    SetNonVisibleCol(False)
                ElseIf uclVisibleColIndex <> "" Then
                    SetVisibleCol(False)
                End If

                dgv.DataSource = dsGrid.Tables(0)

                InitialAllCell()

                colReady = True

                '此行會讓header無法手動調整,但會自動調整以顯示所有cell內容
                ' AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells

            End If

            dgv.ClearSelection()
            doCellValueChange = True
            dgv.ColumnHeadersVisible = ColumnHeadersVisible
            IsInitial = False
            Me.Visible = True

            If uclIsAlternatingRowsColors Then
                SetAlternatingRowsColors(Color.WhiteSmoke)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Processes the source ds.
    ''' </summary>
    ''' <param name="ht">The ht.</param>
    ''' <param name="ds">The ds.</param>
    ''' <returns>DataSet.</returns>
    Private Function ProcessSourceDS(ByVal ht As Hashtable, ByVal ds As DataSet) As DataSet
        Try

            If ht IsNot Nothing Then

                Dim tempDS As New DataSet
                tempDS.Tables.Add(ds.Tables(0).Clone)

                For i As Integer = 0 To ds.Tables(0).Columns.Count - 1
                    If (ht.ContainsKey(i) AndAlso ds.Tables(0).Columns(i).DataType = System.Type.GetType("System.DateTime")) Then
                        tempDS.Tables(0).Columns(i).DataType = System.Type.GetType("System.Object")
                    End If
                Next

                tempDS.Tables(0).Load(ds.Tables(0).CreateDataReader(), System.Data.LoadOption.OverwriteChanges)

                Return tempDS

            End If

            Return ds
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ds
        End Try
    End Function

    ''' <summary>
    ''' 處理ReadOnly Cell
    ''' </summary>
    Private Sub ProcessReadOnlyCell()
        Try

            dsDgvReadOnly = New DataSet
            dsDgvReadOnly.Tables.Add()

            If dsGrid IsNot Nothing AndAlso dsGrid.Tables.Count > 0 Then

                If MultiSelect AndAlso uclColumnCheckBox Then
                    For i As Integer = 0 To dsGrid.Tables(0).Columns.Count + TreeGridCol
                        dsDgvReadOnly.Tables(0).Columns.Add()
                    Next

                    For i As Integer = 0 To dsGrid.Tables(0).Rows.Count - 1
                        dsDgvReadOnly.Tables(0).Rows.Add()
                    Next

                Else

                    For i As Integer = 0 To dsGrid.Tables(0).Columns.Count - 1 + TreeGridCol
                        dsDgvReadOnly.Tables(0).Columns.Add()
                    Next

                    For i As Integer = 0 To dsGrid.Tables(0).Rows.Count - 1
                        dsDgvReadOnly.Tables(0).Rows.Add()
                    Next

                End If
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 多選功能初始化
    ''' </summary>
    Private Sub MultiSelectInitial()
        Try

            If MultiSelect AndAlso uclColumnCheckBox AndAlso ckBox Is Nothing Then

                Dim ch As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
                dgv.Columns.Add(ch)

                ckBox = New CheckBox()

                If UCLFormUtil.isResizeable(Me) Then
                    If UCLFormUtil.gblScreenWidth >= 1920 Then
                        ckBox.Font = New System.Drawing.Font(UCLFormUtil.gblFont, UCLFormUtil.gblFontSize_1920_1080, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
                        ckBox.Size = New Size(38 * (UCLFormUtil.gblScreenWidth / 1024), 21 * (UCLFormUtil.gblScreenHeight / 768))
                    Else
                        ckBox.Font = New System.Drawing.Font(UCLFormUtil.gblFont, UCLFormUtil.gblFontSize_1024_768, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
                        ckBox.Size = New Size(38, 21)
                    End If
                Else
                    ckBox.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
                    ckBox.Size = New Size(38, 21)
                End If

                ckBox.BackColor = Color.Transparent
                If MultiSelectType = SelectType.SelectAll Then
                    ckBox.Text = "選"
                ElseIf MultiSelectType = SelectType.DeleteAll Then
                    ckBox.Text = "刪"
                ElseIf MultiSelectType = SelectType.Doubt Then
                    ckBox.Text = "疑"
                ElseIf MultiSelectType = SelectType.Print Then
                    ckBox.Text = "印"
                End If

                'Get the column header cell bounds
                Dim rect As Rectangle = dgv.GetCellDisplayRectangle(0, -1, True)

                'Change the location of the CheckBox to make it stay on the header
                Dim P As New Point(rect.Location.X + 1, rect.Location.Y + 2)
                ckBox.Location = P

                AddHandler ckBox.CheckedChanged, AddressOf ckBox_CheckedChanged

                'Add the CheckBox into the DataGridView
                If uclMultiSelectShowCheckBoxHeader Then
                    dgv.Controls.Add(ckBox)
                End If

                dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                dgv.Columns(0).ReadOnly = False
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None

                dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Black
                dgv.RowsDefaultCellStyle.SelectionBackColor = Color.White

                dgv.ClearSelection()

            Else
                dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Black
                dgv.RowsDefaultCellStyle.SelectionBackColor = Color.Blue

            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Hides the multi select ck box column.
    ''' </summary>
    Public Sub HideMultiSelectCkBoxColumn()
        If ckBox IsNot Nothing Then
            ckBox.Visible = False
            dgv.Columns(0).Visible = False
        End If

    End Sub
    ''' <summary>
    ''' Sets the multi select box location.
    ''' </summary>
    ''' <param name="X">The x.</param>
    ''' <param name="Y">The y.</param>
    Public Sub SetMultiSelectBoxLocation(ByVal X As Integer, ByVal Y As Integer)
        Try
            Dim p As New Point(X, Y)

            ckBox.Location = p
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Sets the color of the multi select box size background.
    ''' </summary>
    ''' <param name="c">The c.</param>
    Public Sub SetMultiSelectBoxSizeBackgroundColor(ByVal c As Color)
        Try
            ckBox.BackColor = c
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Sets the size of the multi select box.
    ''' </summary>
    ''' <param name="Width">The width.</param>
    ''' <param name="Height">The height.</param>
    Public Sub SetMultiSelectBoxSize(ByVal Width As Integer, ByVal Height As Integer)
        Try
            ckBox.Size = New Size(Width, Height)
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' 建立自訂控制項Cell元件
    ''' </summary>
    Private Sub CreateUclCells()
        Try

            cbo_cell = New UCLComboBoxUC()
            cbo_cell.Visible = False

            txt_cell = New UCLTextBoxUC()
            txt_cell.Visible = False

            dtp_cell = New UCLDateTimePickerCellUC()
            dtp_cell.Visible = False

            cboGrid_cell = New UCLComboBoxGridUC()
            cboGrid_cell.Visible = False

            popMemoUICell = New UCLPopMemoUI
            popMemoUICell.Visible = False

            Dim cells As IDictionaryEnumerator = hash.GetEnumerator()
            cells.Reset()
            While cells.MoveNext()

                If cells.Value.ToString() = "Syscom.Client.UCL.ButtonCell" Then
                    btn_colCount += 1

                ElseIf cells.Value.ToString() = "Syscom.Client.UCL.CheckBoxCell" Then
                    chk_colCount += 1

                End If

            End While

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 初始化 grid cells values =&gt; codes to names
    ''' </summary>
    Private Sub InitialAllCell()

        Dim btnNo As Integer = 0

        Dim cells As IDictionaryEnumerator = hash.GetEnumerator()

        Try

            cells.Reset()
            chkCellIndexList.Clear()

            While cells.MoveNext()
                If cells.Value.ToString() = "Syscom.Client.UCL.ComboBoxCell" Then
                    ' Debug.WriteLine(CType(cells.Value, ComboBoxCell).Ds.Tables(0).Rows(0).Item(0) + " dd")
                    cbo_cell.InitialGridCellValue(Me, dsGrid, CType(cells.Value, ComboBoxCell).Ds, CInt(cells.Key), CType(cells.Value, ComboBoxCell).ValueIndex, CType(cells.Value, ComboBoxCell).DisplayIndex)

                ElseIf cells.Value.ToString() = "Syscom.Client.UCL.TextBoxCell" Then

                ElseIf cells.Value.ToString() = "Syscom.Client.UCL.DtpCell" Then

                ElseIf cells.Value.ToString() = "Syscom.Client.UCL.ButtonCell" Then

                    '  Dim btnCol As New DataGridViewButtonColumn()
                    Dim btnCol As New DataGridViewDisableButtonColumn()
                    btnCol.HeaderText = dgv.Columns(CInt(cells.Key)).HeaderText

                    dgv.Columns.RemoveAt(CInt(cells.Key))
                    dgv.Columns.Insert(CInt(cells.Key), btnCol)

                    btnCol.Text = CType(cells.Value, ButtonCell).Text
                    btnCol.UseColumnTextForButtonValue = True

                ElseIf cells.Value.ToString() = "Syscom.Client.UCL.CheckBoxCell" Then

                    Dim chkCol As New DataGridViewCheckBoxColumn(False)
                    chkCol.HeaderText = dgv.Columns(CInt(cells.Key)).HeaderText

                    dgv.Columns.RemoveAt(CInt(cells.Key))
                    dgv.Columns.Insert(CInt(cells.Key), chkCol)
                    chkCellIndexList.Add(CInt(cells.Key))

                    For i As Integer = 0 To dsGrid.Tables(0).Rows.Count - 1

                        'dsGrid的資料不見了~用dsDB的

                        If MultiSelect AndAlso uclColumnCheckBox Then
                            If dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - 1 - TreeGridCol).ToString().Trim() = "Y" Then
                                dgv.Rows(i).Cells(CInt(cells.Key)).Value = True

                            ElseIf dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - 1 - TreeGridCol).ToString().Trim() = "N" Then
                                dgv.Rows(i).Cells(CInt(cells.Key)).Value = False
                            End If
                        Else
                            If dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - TreeGridCol).ToString().Trim() = "Y" Then
                                dgv.Rows(i).Cells(CInt(cells.Key)).Value = True

                            ElseIf dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - TreeGridCol).ToString().Trim() = "N" Then
                                dgv.Rows(i).Cells(CInt(cells.Key)).Value = False
                            End If

                        End If

                    Next

                ElseIf cells.Value.ToString() = "Syscom.Client.UCL.ComboBoxGridCell" Then

                    'cboGrid_cell.Initial(cboGridShow_cell)
                    ' cboGridShow_cell.addPartnerCbo(cboGrid_cell)
                    ' cboGridShow_cell.Scrollable()

                ElseIf cells.Value.ToString() = "Syscom.Client.UCL.UCLPopMemoUI" Then
                    ' 20100112

                ElseIf cells.Value.ToString() = "Syscom.Client.UCL.ImageCell" Then
                    Dim dsDBColIdx As Integer
                    If MultiSelect AndAlso uclColumnCheckBox Then
                        dsDBColIdx = CInt(cells.Key) - 1 - TreeGridCol
                    Else
                        dsDBColIdx = CInt(cells.Key) - TreeGridCol
                    End If

                    Dim imgCol As New DataGridViewImageColumn()
                    imgCol.HeaderText = dgv.Columns(CInt(cells.Key)).HeaderText
                    imgCol.Name = dsDB.Tables(0).Columns(dsDBColIdx).ColumnName

                    dgv.Columns.RemoveAt(CInt(cells.Key))
                    dgv.Columns.Insert(CInt(cells.Key), imgCol)
                    '附予每個cell值
                    For i As Integer = 0 To dsGrid.Tables(0).Rows.Count - 1
                        'dsGrid的資料不見了~用dsDB的
                        If dsDB.Tables(0).Rows(i).Item(dsDBColIdx) Is Nothing Then
                            CType(dgv.Rows(i).Cells(CInt(cells.Key)), DataGridViewImageCell).Value = dsDB.Tables(0).Rows(i).Item(dsDBColIdx)
                        Else
                            CType(dgv.Rows(i).Cells(CInt(cells.Key)), DataGridViewImageCell).Value = dsDB.Tables(0).Rows(i).Item(dsDBColIdx)

                        End If

                    Next
                End If

            End While

            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Processes the date time picker cell data.
    ''' </summary>
    ''' <param name="ht">The ht.</param>
    ''' <param name="ds">The ds.</param>
    ''' <param name="dsDB">The ds database.</param>
    ''' <returns>DataSet.</returns>
    Function ProcessDateTimePickerCellData(ByVal ht As Hashtable, ByVal ds As DataSet, ByRef dsDB As DataSet) As DataSet

        Try

            Dim DateTimeColumnIndex As New ArrayList
            Dim tempDS As New DataSet

            For i As Integer = 0 To ds.Tables.Count - 1
                tempDS.Tables.Add(ds.Tables(i).Clone)

                For j As Integer = 0 To tempDS.Tables(i).Columns.Count - 1
                    tempDS.Tables(i).Columns(j).ReadOnly = False
                    tempDS.Tables(i).Columns(j).AllowDBNull = True
                    tempDS.Tables(i).Columns(j).DataType = ds.Tables(i).Columns(j).DataType ' System.Type.GetType("System.String")
                Next

                For j As Integer = 0 To ds.Tables(i).Rows.Count - 1
                    tempDS.Tables(i).Rows.Add(ds.Tables(i).Rows(j).ItemArray)
                Next

                'For j As Integer = 0 To tempDS.Tables(i).Rows.Count - 1
                '    For k As Integer = 0 To tempDS.Tables(i).Columns.Count - 1

                '        If tempDS.Tables(i).Rows(j).Item(k).ToString.Trim = "" Then
                '            tempDS.Tables(i).Rows(j).Item(k) = ""
                '        End If
                '    Next
                'Next
            Next

            dsDB = tempDS.Copy

            For i As Integer = 0 To ht.Count - 1
                If MultiSelect AndAlso uclColumnCheckBox Then

                    If ht.Values(i).ToString.Trim = "Syscom.Client.UCL.DtpCell" Then
                        dtpIndexList.Add(CInt(ht.Keys(i) - 1))
                    End If
                Else

                    If ht.Values(i).ToString = "Syscom.Client.UCL.DtpCell" Then
                        dtpIndexList.Add(CInt(ht.Keys(i)))
                    End If
                End If
            Next

            '要轉成民國
            If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then
                For x As Integer = 0 To dtpIndexList.Count - 1
                    For y As Integer = 0 To tempDS.Tables(0).Columns.Count - 1

                        If CType(dtpIndexList(x), Integer) = y Then
                            For z As Integer = 0 To tempDS.Tables(0).Rows.Count - 1

                                If IsDate(tempDS.Tables(0).Rows(z).Item(y)) Then
                                    'ds.Tables(0).Columns(y).ReadOnly = False
                                    'ds.Tables(0).Columns(y).AllowDBNull = True
                                    'ds.Tables(0).Columns(y).DataType = System.Type.GetType("System.String")
                                    tempDS.Tables(0).Rows(z).Item(y) = DateUtil.TransDateToROC((CDate(tempDS.Tables(0).Rows(z).Item(y)).ToString("yyyy/MM/dd")))
                                    If tempDS.Tables(0).Rows(z).Item(y).ToString.Contains("-") AndAlso tempDS.Tables(0).Rows(z).Item(y).ToString.Contains("/") Then
                                        If (Split(tempDS.Tables(0).Rows(z).Item(y).ToString, "/")(0)).Replace("-", "").Length = 1 Then
                                            tempDS.Tables(0).Rows(z).Item(y) = "-00" & tempDS.Tables(0).Rows(z).Item(y).ToString.Replace("-", "")
                                        ElseIf (Split(tempDS.Tables(0).Rows(z).Item(y).ToString, "/")(0)).Replace("-", "").Length = 2 Then
                                            tempDS.Tables(0).Rows(z).Item(y) = "-0" & tempDS.Tables(0).Rows(z).Item(y).ToString.Replace("-", "")
                                        End If
                                    End If
                                End If

                            Next

                        End If

                    Next

                Next
            End If
            Return tempDS
        Catch ex As Exception
            Return ds
        End Try
    End Function

    ''' <summary>
    ''' 西元年轉民國年
    ''' </summary>
    ''' <param name="value">日期</param>
    ''' <param name="delimiter">分隔字元</param>
    ''' <returns>System.String.</returns>
    Private Function TranWE(ByVal value As Date, ByVal delimiter As String) As String
        Try
            Dim us As CultureInfo = New CultureInfo("en-US", True)
            Dim tw As CultureInfo = New CultureInfo("zh-TW", True)
            Dim data As StringBuilder = New StringBuilder
            Dim twDate As String
            Dim year, month, day, format As String
            data.Length = 0
            If (value.Year <= 1911) Then
                year = (value.Year - 1912).ToString.PadLeft(3)
                month = appendChar(value.Month.ToString, CChar("0"), 2)
                day = appendChar(value.Day.ToString, CChar("0"), 2)
                twDate = (data.Append(year).Append(delimiter).Append(month).Append(delimiter).Append(day)).ToString
            Else
                format = (data.Append("yyyy").Append(delimiter).Append("MM").Append(delimiter).Append("dd")).ToString
                tw.DateTimeFormat.Calendar = New TaiwanCalendar
                twDate = value.ToString(format, tw)
            End If
            Return twDate
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Appends the character.
    ''' </summary>
    ''' <param name="srcString">The source string.</param>
    ''' <param name="apdChar">The apd character.</param>
    ''' <param name="totalLength">The total length.</param>
    ''' <returns>System.String.</returns>
    Private Function appendChar(ByVal srcString As String, ByVal apdChar As Char, ByVal totalLength As Integer) As String
        If (srcString Is Nothing) Then
            srcString = ""
        End If
        If srcString.Length > totalLength Then
            srcString = srcString.Substring(0, totalLength)
        ElseIf srcString.Length < totalLength Then
            For i = 1 To totalLength - srcString.Length
                srcString = apdChar & srcString
            Next
        End If
        Return srcString
    End Function

    ''' <summary>
    ''' 全選的header checkbox狀態改變
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Sub ckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim VisibleColIndex As Integer = 0
            Dim RowVisibleList As New ArrayList

            For i As Integer = 0 To dgv.Rows.Count - 1

                If dgv.Rows(i).Visible Then
                    RowVisibleList.Add("True")

                Else
                    RowVisibleList.Add("False")
                End If

            Next

            If MultiSelect AndAlso uclColumnCheckBox Then
                VisibleColIndex = 1
            End If

            For i As Integer = 0 To dgv.Columns.Count - 1
                If dgv.Columns(i).Visible = True Then
                    VisibleColIndex = i
                    Exit For
                End If
            Next

            ' dgv.ClearSelection()
            If uclHasNewRow Then
                For i = 0 To dgv.Rows.Count - 2   '不勾選最後的空白列

                    If Not dgv.Item(0, i).ReadOnly Then
                        dgv.Item(0, i).Value = ckBox.Checked
                    End If

                    ' Debug.WriteLine(dgv.Item(0, i).Value.ToString())
                Next

            Else
                For i = 0 To dgv.Rows.Count - 1
                    If Not dgv.Item(0, i).ReadOnly Then
                        dgv.Item(0, i).Value = ckBox.Checked
                    End If
                    ' Debug.WriteLine(dgv.Item(0, i).Value.ToString())
                Next

            End If

            dgv.CurrentCell = Nothing
            For i As Integer = 0 To dgv.Rows.Count - 1

                dgv.Rows(i).Visible = CBool(RowVisibleList(i))

            Next

            'For j = 0 To dgv.Rows.Count - 1
            '    If dgv.Item(0, j).Value = True Then

            '        '  dgv.Rows(j).DefaultCellStyle.BackColor = Color.DeepSkyBlue

            '        ' dgv.CurrentCell = dgv.Rows(j).Cells(VisibleColIndex)
            '        ' dgv.ClearSelection()
            '    Else

            '        ' dgv.Rows(j).DefaultCellStyle.BackColor = Color.White
            '        '  dgv.CurrentCell = dgv.Rows(j).Cells(VisibleColIndex)
            '        '  dgv.ClearSelection()
            '    End If

            'Next

            RaiseEvent Click(sender, e)
            RaiseEvent ClickSelectAllChkBox(sender, ckBox.Checked)

            dgv.EndEdit()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub 'ckBox_CheckedChanged


#Region "ComboBox Cell ValueChanged And Leave Event"
    ''' <summary>
    ''' ComboBox Cell ValueChanged And Leave Event
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RaiseComboBoxCellSelectedValueChangedAndLeaveEvent(ByVal RowIndex As Integer, ByVal ColIndex As Integer)
        RaiseEvent ComboBoxCellSelectedValueChangedAndLeave(RowIndex, ColIndex)
    End Sub
#End Region

#Region "設定 行唯讀,Header Text,Col Width,Col Alignment,排序,hide col"

    ''' <summary>
    ''' Set Col Read Only
    ''' </summary>
    Private Sub SetColReadOnly()
        Try

            Dim dataStartIndex As Integer
            If MultiSelect AndAlso uclColumnCheckBox Then
                dataStartIndex = 1
            Else
                dataStartIndex = 0
            End If

            For i As Integer = dataStartIndex To dgv.ColumnCount - 1
                dgv.Columns(i).ReadOnly = True
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Set Header Text；Visible,True:內部會開關 ,False:內部不會開關
    ''' </summary>
    ''' <param name="changeVisible">是某要在Method 內部改變Visible,True:內部會開關 ,False:內部不會開關</param>
    Private Sub SetHeaderText(Optional ByVal changeVisible As Boolean = True)
        Try
            If changeVisible Then
                Me.Visible = False
            End If

            If _uclHeaderText.Trim() <> "" Then

                Try
                    Dim headerStr As String() = Split(_uclHeaderText, ",")

                    If dsGrid.Tables(0).Columns.Count >= headerStr.Length Then

                        If MultiSelect AndAlso uclColumnCheckBox Then
                            For i As Integer = 1 To headerStr.Length
                                If headerStr(i - 1).Trim() <> "" AndAlso i >= 0 Then
                                    dgv.Columns(i + TreeGridCol).HeaderText = headerStr(i - 1).Trim()

                                End If
                            Next
                        Else

                            For i As Integer = 0 To headerStr.Length - 1
                                If headerStr(i).Trim() <> "" AndAlso i >= 0 Then
                                    dgv.Columns(i + TreeGridCol).HeaderText = headerStr(i).Trim()

                                End If
                            Next
                        End If

                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
                End Try
            End If

        Catch ex As Exception

        Finally
            If changeVisible Then
                Me.Visible = True
            End If
        End Try

    End Sub

    ''' <summary>
    ''' Set Col Width；Visible,True:內部會開關 ,False:內部不會開關
    ''' </summary>
    ''' <param name="changeVisible">是某要在Method 內部改變Visible,True:內部會開關 ,False:內部不會開關</param>
    Private Sub SetColWidth(Optional ByVal changeVisible As Boolean = True)

        Try
            If changeVisible Then
                Me.Visible = False
            End If

            If _uclColumnWidth.Trim() <> "" Then
                Try
                    Dim widthStr As String() = Split(_uclColumnWidth, ",")

                    If dsGrid.Tables(0).Columns.Count >= widthStr.Length Then

                        If MultiSelect AndAlso uclColumnCheckBox Then
                            For i As Integer = 1 To widthStr.Length
                                If widthStr(i - 1).Trim() <> "" AndAlso CInt(widthStr(i - 1).Trim()) > 0 AndAlso i >= 1 AndAlso i <= dgv.Columns.Count - 1 Then
                                    dgv.Columns(i + TreeGridCol).Width = CInt(widthStr(i - 1).Trim())

                                End If
                            Next
                        Else

                            For i As Integer = 0 To widthStr.Length - 1
                                If widthStr(i).Trim() <> "" AndAlso CInt(widthStr(i).Trim()) > 0 AndAlso i >= 0 AndAlso i <= dgv.Columns.Count - 1 Then
                                    dgv.Columns(i + TreeGridCol).Width = CInt(widthStr(i).Trim())

                                End If
                            Next
                        End If
                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
                End Try
            End If

        Catch ex As Exception

        Finally
            If changeVisible Then
                Me.Visible = True
            End If
        End Try

    End Sub

    ''' <summary>
    ''' Set Column Alignment；Visible,True:內部會開關 ,False:內部不會開關
    ''' </summary>
    ''' <param name="changeVisible">是某要在Method 內部改變Visible,True:內部會開關 ,False:內部不會開關</param>
    Private Sub SetColumnAlignment(Optional ByVal changeVisible As Boolean = True)
        Try

            If changeVisible Then
                Me.Visible = False
            End If

            If _uclColumnAlignment.Trim() <> "" Then

                Try

                    Dim colAlignStr As String() = Split(_uclColumnAlignment, ",")

                    If dsGrid.Tables(0).Columns.Count >= colAlignStr.Length Then

                        If MultiSelect AndAlso uclColumnCheckBox Then
                            For i As Integer = 1 To colAlignStr.Length
                                If colAlignStr(i - 1).Trim() <> "" AndAlso i >= 0 Then

                                    dgv.Columns(i + TreeGridCol).DefaultCellStyle.Alignment = GetColAlignment(colAlignStr(i - 1))
                                End If
                            Next
                        Else
                            For i As Integer = 0 To colAlignStr.Length - 1
                                If colAlignStr(i).Trim() <> "" AndAlso i >= 0 Then
                                    dgv.Columns(i + TreeGridCol).DefaultCellStyle.Alignment = GetColAlignment(colAlignStr(i))
                                End If
                            Next
                        End If

                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
                End Try
            End If

        Catch ex As Exception

        Finally
            If changeVisible Then
                Me.Visible = True
            End If
        End Try

    End Sub

    ''' <summary>
    ''' Get Col Alignment
    ''' </summary>
    ''' <param name="type">0靠左 , 1靠右 , 2置中</param>
    ''' <returns>DataGridViewContentAlignment.</returns>
    Private Function GetColAlignment(ByVal type As String) As DataGridViewContentAlignment

        If type.Trim() = "0" Then
            Return DataGridViewContentAlignment.MiddleLeft
        ElseIf type.Trim() = "1" Then
            Return DataGridViewContentAlignment.MiddleRight
        ElseIf type.Trim() = "2" Then
            Return DataGridViewContentAlignment.MiddleCenter
        Else
            Return DataGridViewContentAlignment.NotSet
        End If
    End Function

    ''' <summary>
    ''' Sortable Column Index
    ''' </summary>
    Public Sub SortableColumnIndex()

        Try

            For i = 0 To dgv.Columns.Count - 1
                dgv.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            If _uclSortColIndex <> "" Then

                Dim col As String() = Split(_uclSortColIndex, ",")
                If col.Length > 0 AndAlso col.Length <= dgv.Columns.Count Then
                    For i As Integer = 0 To col.Length - 1
                        dgv.Columns(CType(col(i), Integer)).SortMode = DataGridViewColumnSortMode.Automatic
                    Next

                End If
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' 設定隱藏的grid column；Visible,True:內部會開關 ,False:內部不會開關
    ''' </summary>
    ''' <param name="changeVisible">是某要在Method 內部改變Visible,True:內部會開關 ,False:內部不會開關</param>
    Public Sub SetNonVisibleCol(Optional ByVal changeVisible As Boolean = True)
        Try
            If changeVisible Then
                Me.Visible = False
            End If
            If MultiSelect AndAlso uclColumnCheckBox Then

                If _uclNonVisibleColIndex.Trim() <> "" Then
                    Dim colIndex As String() = Split(_uclNonVisibleColIndex.Trim(), ",")

                    For i As Integer = 0 To colIndex.Length - 1
                        If i >= 0 AndAlso CInt(colIndex(i)) >= 1 AndAlso CInt(colIndex(i)) <= dgv.Columns.Count - 1 Then
                            dgv.Columns(CInt(colIndex(i))).Visible = False
                        End If

                    Next
                End If

            Else

                If _uclNonVisibleColIndex.Trim() <> "" Then
                    Dim colIndex As String() = Split(_uclNonVisibleColIndex.Trim(), ",")

                    For i As Integer = 0 To colIndex.Length - 1
                        If i >= 0 AndAlso CInt(colIndex(i)) <= dgv.Columns.Count - 1 Then
                            dgv.Columns(CInt(colIndex(i))).Visible = False
                        End If

                    Next
                End If

            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        Finally
            If changeVisible Then
                Me.Visible = True
            End If
        End Try
    End Sub

    '設定顯示的grid column
    ''' <summary>
    ''' Sets the visible col.；Visible,True:內部會開關 ,False:內部不會開關
    ''' </summary>
    ''' <param name="changeVisible">是某要在Method 內部改變Visible,True:內部會開關 ,False:內部不會開關</param>
    Public Sub SetVisibleCol(Optional ByVal changeVisible As Boolean = True)
        Try
            If changeVisible Then
                Me.Visible = False
            End If

            If MultiSelect AndAlso uclColumnCheckBox Then

                If _uclVisibleColIndex.Trim() <> "" Then
                    Dim colIndex As String() = Split(_uclVisibleColIndex.Trim(), ",")

                    For i As Integer = 1 To dgv.Columns.Count - 1

                        dgv.Columns(i).Visible = False

                    Next

                    For i As Integer = 0 To colIndex.Length - 1
                        If i >= 0 AndAlso CInt(colIndex(i)) <= dgv.Columns.Count - 1 Then
                            dgv.Columns(CInt(colIndex(i))).Visible = True
                        End If

                    Next
                End If

            Else

                If _uclVisibleColIndex.Trim() <> "" Then
                    Dim colIndex As String() = Split(_uclVisibleColIndex.Trim(), ",")

                    For i As Integer = 0 To dgv.Columns.Count - 1

                        dgv.Columns(i).Visible = False

                    Next

                    For i As Integer = 0 To colIndex.Length - 1
                        If i >= 0 AndAlso CInt(colIndex(i)) <= dgv.Columns.Count - 1 Then
                            dgv.Columns(CInt(colIndex(i))).Visible = True
                        End If

                    Next

                End If

            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        Finally
            If changeVisible Then
                Me.Visible = True
            End If
        End Try
    End Sub

#End Region

    ''' <summary>
    ''' 設定整批修改元件
    ''' ctl:整批修改元件
    ''' </summary>
    ''' <param name="ctl">The control.</param>
    Public Sub AddGridUpControl(ByRef ctl As Control)

        textboxUp = CType(ctl, UCLGridUpComboBoxUC)

    End Sub

    ''' <summary>
    ''' 多選checkbox用,取得選擇項目的Row Index
    ''' </summary>
    ''' <returns>Row Index字串</returns>
    Public Function GetSelectedRowsIndex() As String
        Try

            Dim rowIndex As String = ""
            If MultiSelect AndAlso uclColumnCheckBox Then
                For j As Integer = 0 To dgv.Rows.Count - 1
                    If dgv.Item(0, j).Value = True Then
                        If rowIndex <> "" Then
                            rowIndex += "," & j.ToString()
                        Else
                            rowIndex += j.ToString()
                        End If

                    End If

                Next
            Else
                Return dgv.CurrentRow.Index.ToString
            End If

            Return rowIndex
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

#Region " 取得多選選擇的 DS "

    ''' <summary>
    ''' 取得多選選擇的 DS (使用Grid 本身的 Checkbox)
    ''' </summary>
    ''' <returns>DataSet.</returns>
    Public Function GetSelectedDS() As DataSet
        Try

            '取得沒被選擇的 RowIndex
            Dim rowIndexArray As Integer() = GetUnSelectedIndex()

            Dim ds As DataSet = GetDBDS.Copy

            If rowIndexArray Is Nothing Then
                Return ds
            End If
            '倒序移除沒被選擇的 Row
            For i As Integer = rowIndexArray.Count - 1 To 0 Step -1
                ds.Tables(0).Rows.RemoveAt(rowIndexArray(i))
            Next

            Return ds

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region " 取得沒被選擇的 DS "

    ''' <summary>
    ''' 取得沒被選擇的 DS(使用Grid 本身的 Checkbox)
    ''' </summary>
    ''' <returns>DataSet.</returns>
    Public Function GetUnSelectedDS() As DataSet
        Try

            '取得被選擇的 RowIndex
            Dim rowIndexArray As Integer() = GetSelectedIndex()

            Dim ds As DataSet = GetDBDS.Copy

            If rowIndexArray Is Nothing Then
                Return ds
            End If
            '倒序移除被選擇的 Row
            For i As Integer = rowIndexArray.Count - 1 To 0 Step -1
                ds.Tables(0).Rows.RemoveAt(rowIndexArray(i))
            Next

            Return ds

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

    ''' <summary>
    ''' 多選checkbox用index matrix
    ''' </summary>
    ''' <returns>System.Int32().</returns>
    Public Function GetSelectedIndex() As Integer()
        Try

            Dim rowIndex As String = ""
            If MultiSelect AndAlso uclColumnCheckBox AndAlso dgv.Rows.Count > 0 Then

                Dim indexCnt As Integer = 0

                For j As Integer = 0 To dgv.Rows.Count - 1
                    If dgv.Item(0, j).Value = True Then
                        indexCnt = indexCnt + 1
                    End If
                Next

                If indexCnt > 0 Then
                    Dim indexColumn(indexCnt - 1) As Integer

                    Dim index As Integer = 0

                    For j As Integer = 0 To dgv.Rows.Count - 1
                        If dgv.Item(0, j).Value = True Then

                            indexColumn(index) = CType(j.ToString(), Integer)

                            index = index + 1

                            'If rowIndex <> "" Then
                            '    rowIndex += "," & j.ToString()
                            'Else
                            '    rowIndex += j.ToString()
                            'End If

                        End If

                    Next

                    Return indexColumn
                Else
                    Return Nothing
                End If

            Else
                'Dim indexColumn(0) As Integer
                'If dgv.SelectedRows(0) Is Nothing Then
                '    Return Nothing
                'Else
                '    indexColumn(0) = dgv.SelectedRows(0).Index
                '    Return indexColumn
                'End If

                Return Nothing

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Gets the index of the un selected.
    ''' </summary>
    ''' <returns>System.Int32().</returns>
    ''' 多選checkbox用index matrix, 取得未選
    Public Function GetUnSelectedIndex() As Integer()
        Try

            Dim rowIndex As String = ""
            If MultiSelect AndAlso uclColumnCheckBox Then

                Dim indexCnt As Integer = 0

                For j As Integer = 0 To dgv.Rows.Count - 1
                    If dgv.Item(0, j).Value = False Then
                        indexCnt = indexCnt + 1
                    End If
                Next

                If indexCnt > 0 Then
                    Dim indexColumn(indexCnt - 1) As Integer

                    Dim index As Integer = 0

                    For j As Integer = 0 To dgv.Rows.Count - 1
                        If dgv.Item(0, j).Value = False Then

                            indexColumn(index) = CType(j.ToString(), Integer)

                            index = index + 1

                            'If rowIndex <> "" Then
                            '    rowIndex += "," & j.ToString()
                            'Else
                            '    rowIndex += j.ToString()
                            'End If

                        End If

                    Next

                    Return indexColumn
                Else
                    Return Nothing
                End If

            Else
                Dim indexColumn(0) As Integer
                If dgv.SelectedRows(0) Is Nothing Then
                    Return Nothing
                Else
                    indexColumn(0) = dgv.SelectedRows(0).Index
                    Return indexColumn
                End If

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 設定是否顯示DayaGridView
    ''' bool:True:顯示 ,False:隱藏
    ''' </summary>
    ''' <param name="bool">if set to <c>true</c> [bool].</param>
    Public Sub SetGridVisible(ByVal bool As Boolean)
        dgv.Visible = bool
    End Sub

    ''' <summary>
    ''' Selects all.
    ''' </summary>
    Public Sub SelectAll()
        dgv.SelectAll()
    End Sub

    ''' <summary>
    ''' BeginEdit
    ''' </summary>
    ''' <param name="SelectAll">if set to <c>true</c> [select all].</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    Public Function BeginEdit(ByVal SelectAll As Boolean) As Boolean
        Return dgv.BeginEdit(SelectAll)
    End Function

    ''' <summary>
    ''' EndEdit
    ''' </summary>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    Public Function EndEdit() As Boolean
        Return dgv.EndEdit()
    End Function

    ''' <summary>
    ''' 清除所選項目
    ''' </summary>
    Public Sub ClearSelection()
        dgv.ClearSelection()

    End Sub

    ''' <summary>
    ''' Sets the type of the column control.
    ''' </summary>
    Private Sub SetColumnControlType()
        Try
            If _uclColumnControlType.Trim() <> "" Then
                Dim colIndex As String() = Split(_uclColumnControlType.Trim(), ",")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 取得存儲DB用的DataSet
    ''' </summary>
    ''' <returns>DataSet.</returns>
    Public Function GetDBDS() As DataSet
        Return dsDB
    End Function

    ''' <summary>
    ''' 取得畫面Grid的DataSet
    ''' </summary>
    ''' <returns>DataSet.</returns>
    Public Function GetGridDS() As DataSet
        Return dsGrid
    End Function

    ''' <summary>
    ''' 取得存儲DB用的DataSet (MultiSelect)
    ''' </summary>
    ''' <returns>DataSet.</returns>
    Public Function GetMultiSelectDBDS() As DataSet
        If MultiSelect AndAlso uclColumnCheckBox Then
            Dim TempDS As New DataSet
            TempDS.Tables.Add(dsDB.Tables(0).Copy)
            Return TempDS
        Else
            Return dsDB
        End If
    End Function

    ''' <summary>
    ''' 取得畫面Grid的DataSet (MultiSelect)
    ''' </summary>
    ''' <returns>DataSet.</returns>
    Public Function GetMultiSelectGridDS() As DataSet
        If MultiSelect AndAlso uclColumnCheckBox Then
            Dim TempDS As New DataSet
            TempDS.Tables.Add(dsGrid.Tables(0).Copy)
            Return TempDS
        Else
            Return dsGrid
        End If
    End Function

    ''' <summary>
    ''' 取得畫面Grid ReadOnly設定 的DataSet
    ''' </summary>
    ''' <returns>DataSet.</returns>
    Public Function GetDgvReadOnlyDS() As DataSet
        Return dsDgvReadOnly
    End Function

    ''' <summary>
    ''' 設定拖拉功能
    ''' </summary>
    Public Sub Scrollable()
        dgv.ScrollBars = ScrollBars.Both
    End Sub

    ''' <summary>
    ''' Disable Button Cell
    ''' </summary>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="ColIndex">Index of the col.</param>
    Public Sub DisableButton(ByVal RowIndex As Integer, ByVal ColIndex As Integer)
        Try
            Dim buttonCell As DataGridViewDisableButtonCell = CType(dgv.Rows(RowIndex).Cells(ColIndex), DataGridViewDisableButtonCell)
            buttonCell.Enabled = False
            'dgv.Refresh()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 判斷Button是否Enable
    ''' </summary>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="ColIndex">Index of the col.</param>
    ''' <returns>True:Button is Enable , False:Button i Disable</returns>
    Public Function ButtonIsEnable(ByVal RowIndex As Integer, ByVal ColIndex As Integer) As Boolean
        Try
            Dim buttonCell As DataGridViewDisableButtonCell = CType(dgv.Rows(RowIndex).Cells(ColIndex), DataGridViewDisableButtonCell)
            Return buttonCell.Enabled
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    ''' <summary>
    ''' Enable Button Cell
    ''' </summary>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="ColIndex">Index of the col.</param>
    Public Sub EnableButton(ByVal RowIndex As Integer, ByVal ColIndex As Integer)
        Try

            Dim buttonCell As DataGridViewDisableButtonCell = CType(dgv.Rows(RowIndex).Cells(ColIndex), DataGridViewDisableButtonCell)
            buttonCell.Enabled = True
            'dgv.Refresh()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 快速確認目前Cell的變更
    ''' </summary>
    ''' <param name="Ax">The ax.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    Public Function CommitEdit(ByVal Ax As DataGridViewDataErrorContexts) As Boolean
        Return dgv.CommitEdit(Ax)
    End Function

    ''' <summary>
    ''' ComboBox Cell設定Code變換成Name
    ''' </summary>
    ''' <param name="Code">The code.</param>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="ColIndex">Index of the col.</param>
    Public Sub ComboBoxCellSelectedValue(ByVal Code As String, ByVal RowIndex As Integer, ByVal ColIndex As Integer)
        Try

            If hash IsNot Nothing AndAlso hash.ContainsKey(ColIndex) Then

                ' HideControlCell("")

                If hash(ColIndex).GetType().ToString() = "Syscom.Client.UCL.ComboBoxCell" Then

                    dt = CType(CType(hash(ColIndex), ComboBoxCell).Ds.Tables(0), DataTable)
                    '傳入dgv跟綁dgv的dataset

                    cbo_cell.FirstEnterGridCell = False

                    '一定要用copy,否則會對原本ds作用
                    cbo_cell.DataSource = dt.Copy()
                    cbo_cell.doTextChanged = False
                    cbo_cell.uclDisplayIndex = CType(hash(ColIndex), ComboBoxCell).DisplayIndex
                    cbo_cell.uclValueIndex = CType(hash(ColIndex), ComboBoxCell).ValueIndex
                    cbo_cell.doTextChanged = True
                    cbo_cell.SetPvtCheckFlag(True)
                    cbo_cell.SetComboBoxCellValue(Me, dsDB, dsGrid, Code.Trim, RowIndex, ColIndex)

                End If
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Sets the select all.
    ''' </summary>
    ''' <param name="value">if set to <c>true</c> [value].</param>
    Public Sub SetSelectAll(ByVal value As Boolean)
        If MultiSelect AndAlso uclColumnCheckBox Then
            ckBox.Checked = Not value
            ckBox.Checked = value

        End If

    End Sub

#Region "Row, Col , Cell 顏色設定"

    'cell
    ''' <summary>
    ''' Sets the color of the cell.
    ''' </summary>
    ''' <param name="ColIndex">Index of the col.</param>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="ColorValue">The color value.</param>
    Public Sub SetCellColor(ByVal ColIndex As Integer, ByVal RowIndex As Integer, ByVal ColorValue As Color)
        Try

            If ColIndex >= 0 AndAlso ColIndex <= dgv.Columns.Count - 1 AndAlso RowIndex >= 0 AndAlso RowIndex <= dgv.Rows.Count - 1 Then
                dgv.Item(ColIndex, RowIndex).Style.BackColor = ColorValue
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    'row
    ''' <summary>
    ''' Sets the color of the row.
    ''' </summary>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="ColorValue">The color value.</param>
    Public Sub SetRowColor(ByVal RowIndex As Integer, ByVal ColorValue As Color)
        Try

            If RowIndex >= 0 AndAlso RowIndex <= dgv.Rows.Count - 1 Then

                'For i As Integer = 0 To dgv.Columns.Count - 1
                '    dgv.Item(i, RowIndex).Style.BackColor = ColorValue
                'Next
                dgv.Rows(RowIndex).DefaultCellStyle.BackColor = ColorValue
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    'col
    ''' <summary>
    ''' Sets the color of the col.
    ''' </summary>
    ''' <param name="ColIndex">Index of the col.</param>
    ''' <param name="ColorValue">The color value.</param>
    Public Sub SetColColor(ByVal ColIndex As Integer, ByVal ColorValue As Color)
        Try

            If ColIndex >= 0 AndAlso ColIndex <= dgv.Columns.Count - 1 Then
                'For i As Integer = 0 To dgv.Rows.Count - 1
                '    dgv.Item(ColIndex, i).Style.BackColor = ColorValue
                'Next

                dgv.Columns(ColIndex).DefaultCellStyle.BackColor = ColorValue
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "Row, Col , Cell 前景顏色設定"

    'cell
    ''' <summary>
    ''' Sets the color of the cell fore.
    ''' </summary>
    ''' <param name="ColIndex">Index of the col.</param>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="ColorValue">The color value.</param>
    Public Sub SetCellForeColor(ByVal ColIndex As Integer, ByVal RowIndex As Integer, ByVal ColorValue As Color)
        Try

            If ColIndex >= 0 AndAlso ColIndex <= dgv.Columns.Count - 1 AndAlso RowIndex >= 0 AndAlso RowIndex <= dgv.Rows.Count - 1 Then
                dgv.Item(ColIndex, RowIndex).Style.ForeColor = ColorValue
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    'row
    ''' <summary>
    ''' Sets the color of the row fore.
    ''' </summary>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="ColorValue">The color value.</param>
    Public Sub SetRowForeColor(ByVal RowIndex As Integer, ByVal ColorValue As Color)
        Try

            If RowIndex >= 0 AndAlso RowIndex <= dgv.Rows.Count - 1 Then

                'For i As Integer = 0 To dgv.Columns.Count - 1
                '    dgv.Item(i, RowIndex).Style.BackColor = ColorValue
                'Next
                dgv.Rows(RowIndex).DefaultCellStyle.ForeColor = ColorValue
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    'col
    ''' <summary>
    ''' Sets the color of the col fore.
    ''' </summary>
    ''' <param name="ColIndex">Index of the col.</param>
    ''' <param name="ColorValue">The color value.</param>
    Public Sub SetColForeColor(ByVal ColIndex As Integer, ByVal ColorValue As Color)
        Try

            If ColIndex >= 0 AndAlso ColIndex <= dgv.Columns.Count - 1 Then
                'For i As Integer = 0 To dgv.Rows.Count - 1
                '    dgv.Item(ColIndex, i).Style.BackColor = ColorValue
                'Next

                dgv.Columns(ColIndex).DefaultCellStyle.ForeColor = ColorValue
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "Row, Col , Cell ReadOnly設定"

    'cell
    ''' <summary>
    ''' Sets the cell read only.
    ''' </summary>
    ''' <param name="ColIndex">Index of the col.</param>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="Value">if set to <c>true</c> [value].</param>
    Public Sub SetCellReadOnly(ByVal ColIndex As Integer, ByVal RowIndex As Integer, ByVal Value As Boolean)
        Try

            If ColIndex >= 0 AndAlso ColIndex <= dsDgvReadOnly.Tables(0).Columns.Count - 1 AndAlso RowIndex >= 0 AndAlso RowIndex <= dsDgvReadOnly.Tables(0).Rows.Count - 1 Then
                ' dgv.Item(ColIndex, RowIndex).ReadOnly = Value
                dsDgvReadOnly.Tables(0).Rows(RowIndex).Item(ColIndex) = Value.ToString.ToUpper

                If dgv.Columns(ColIndex).GetType.ToString = "System.Windows.Forms.DataGridViewCheckBoxColumn" OrElse
                   dgv.Columns(ColIndex).GetType.ToString = "System.Windows.Forms.DataGridViewTextBoxColumn" Then
                    dgv.Rows(RowIndex).Cells(ColIndex).ReadOnly = Value
                End If

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    'row
    ''' <summary>
    ''' Sets the row read only.
    ''' </summary>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="Value">if set to <c>true</c> [value].</param>
    Public Sub SetRowReadOnly(ByVal RowIndex As Integer, ByVal Value As Boolean)
        Try

            If RowIndex >= 0 AndAlso RowIndex <= dsDgvReadOnly.Tables(0).Rows.Count - 1 Then

                For i As Integer = 0 To dsDgvReadOnly.Tables(0).Columns.Count - 1
                    ' dgv.Item(i, RowIndex).ReadOnly = Value
                    dsDgvReadOnly.Tables(0).Rows(RowIndex).Item(i) = Value.ToString.ToUpper
                    If dgv.Columns(i).GetType.ToString = "System.Windows.Forms.DataGridViewCheckBoxColumn" Then
                        'Debug.WriteLine(dgv.Columns(i).GetType.ToString)
                        dgv.Rows(RowIndex).Cells(i).ReadOnly = Value
                    End If

                Next

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    'col
    ''' <summary>
    ''' Sets the col read only.
    ''' </summary>
    ''' <param name="ColIndex">Index of the col.</param>
    ''' <param name="Value">if set to <c>true</c> [value].</param>
    Public Sub SetColReadOnly(ByVal ColIndex As Integer, ByVal Value As Boolean)
        Try

            If ColIndex >= 0 AndAlso ColIndex <= dsDgvReadOnly.Tables(0).Columns.Count - 1 Then
                For i As Integer = 0 To dsDgvReadOnly.Tables(0).Rows.Count - 1
                    ' dgv.Item(ColIndex, i).ReadOnly = Value
                    dsDgvReadOnly.Tables(0).Rows(i).Item(ColIndex) = Value.ToString.ToUpper

                    If dgv.Columns(ColIndex).GetType.ToString = "System.Windows.Forms.DataGridViewCheckBoxColumn" Then
                        'Debug.WriteLine(dgv.Columns(i).GetType.ToString)
                        dgv.Rows(i).Cells(ColIndex).ReadOnly = Value
                    End If

                Next

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "排序功能"

    ''' <summary>
    ''' Sorts the specified col index.
    ''' </summary>
    ''' <param name="ColIndex">Index of the col.</param>
    Public Sub Sort(ByVal ColIndex As Integer)

    End Sub

#End Region

#Region "動態設定ComboBoxCell的DataSet"

    ''' <summary>
    ''' Sets the ComboBox cell data set.
    ''' </summary>
    ''' <param name="ds">The ds.</param>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="ColIndex">Index of the col.</param>
    Public Sub SetComboBoxCellDataSet(ByVal ds As DataSet, ByVal RowIndex As Integer, ByVal ColIndex As Integer)
        CType(hash(ColIndex), ComboBoxCell).Ds.Tables.Clear()
        CType(hash(ColIndex), ComboBoxCell).Ds.Tables.Add(ds.Tables(0).Copy)
    End Sub

#End Region

#Region "更新CellValue"

    ''' <summary>
    ''' Updates the cell value.
    ''' </summary>
    ''' <param name="ColumnIndex">Index of the column.</param>
    ''' <param name="RowIndex">Index of the row.</param>
    Public Sub UpdateCellValue(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)

        dgv.UpdateCellValue(ColumnIndex, RowIndex)

    End Sub

#End Region

    ''' <summary>
    ''' Sets me focus.
    ''' </summary>
    Public Sub SetMeFocus()
        Me.Focus()
    End Sub

    ''' <summary>
    ''' Gets the height of the row template.
    ''' </summary>
    ''' <returns>System.Int32.</returns>
    Public Function GetRowTemplateHeight() As Integer
        Return dgv.RowTemplate.Height
    End Function

    ''' <summary>
    ''' Sets the height of the row template.
    ''' </summary>
    ''' <param name="height">The height.</param>
    Public Sub SetRowTemplateHeight(ByVal height As Integer)
        dgv.RowTemplate.Height = height
    End Sub

#End Region

#Region "2011-12-08 added by Ken"

    ''' <summary>
    ''' Gets or sets the height of the column headers.
    ''' </summary>
    ''' <value>The height of the column headers.</value>
    Public Property ColumnHeadersHeight() As Int32
        Get
            Return dgv.ColumnHeadersHeight
        End Get
        Set(ByVal value As Int32)
            dgv.ColumnHeadersHeight = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the width of the row headers.
    ''' </summary>
    ''' <value>The width of the row headers.</value>
    Public Property RowHeadersWidth() As Int32
        Get
            Return dgv.RowHeadersWidth
        End Get
        Set(ByVal value As Int32)
            dgv.RowHeadersWidth = value
        End Set
    End Property

    ''' <summary>
    ''' 調整指定列的高度，以適合所有其儲存格的內容 (包含標題儲存格)
    ''' </summary>
    ''' <param name="rowindex">要調整大小之資料列索引</param>
    Public Sub AutoResizeRow(ByVal rowindex As Int32)
        dgv.AutoResizeRow(rowindex)
    End Sub

    ''' <summary>
    ''' 調整指定列的高度，以適合所有其儲存格的內容
    ''' </summary>
    ''' <param name="rowindex">要調整大小之資料列索引</param>
    ''' <param name="autoSizeRowMode">其中一個 System.Windows.Forms.DataGridViewAutoSizeRowMode 值</param>
    Public Sub AutoResizeRow(ByVal rowindex As Int32, ByVal autoSizeRowMode As System.Windows.Forms.DataGridViewAutoSizeRowMode)
        dgv.AutoResizeRow(rowindex, autoSizeRowMode)
    End Sub

    ''' <summary>
    ''' 使用指定的調整大小模式值來調整資料列的高度
    ''' </summary>
    ''' <param name="autoSizeRowMode">其中一個 System.Windows.Forms.DataGridViewAutoSizeRowsMode 值</param>
    Public Sub AutoResizeRows(ByVal autoSizeRowMode As System.Windows.Forms.DataGridViewAutoSizeRowsMode)
        dgv.AutoResizeRows(autoSizeRowMode)
    End Sub

    ''' <summary>
    ''' 調整指定資料行的寬度，以適合所有其儲存格的內容 (包含標題儲存格)
    ''' </summary>
    ''' <param name="columnindex">要調整大小之資料行索引</param>
    Public Sub AutoResizeColumn(ByVal columnindex As Int32)
        dgv.AutoResizeColumn(columnindex)
    End Sub

    ''' <summary>
    ''' 調整指定資料行的寬度，以適合所有其儲存格的內容
    ''' </summary>
    ''' <param name="columnindex">要調整大小之資料行索引</param>
    ''' <param name="autoSizeColumnMode">其中一個 System.Windows.Forms.DataGridViewAutoSizeRowMode 值</param>
    Public Sub AutoResizeColumn(ByVal columnindex As Int32, ByVal autoSizeColumnMode As System.Windows.Forms.DataGridViewAutoSizeColumnMode)
        dgv.AutoResizeColumn(columnindex, autoSizeColumnMode)
    End Sub

    ''' <summary>
    ''' 使用指定的調整大小模式值來調整資料行的寬度
    ''' </summary>
    ''' <param name="autoSizeColumnsMode">其中一個 System.Windows.Forms.DataGridViewAutoSizeColumnsMode 值</param>
    Public Sub AutoResizeColumns(ByVal autoSizeColumnsMode As System.Windows.Forms.DataGridViewAutoSizeColumnsMode)
        dgv.AutoResizeColumns(autoSizeColumnsMode)
    End Sub

#End Region

#Region "單筆資料拖拉 ,James 2009.04.20"
    '要先設定 AllowDrop=True ,  MultiSelect=False , uclColumnCheckBox=False
    '只能單筆拖拉
    '只能用於單選

    ''' <summary>
    ''' Handles the MouseMove event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv.MouseMove

        Try

            If AllowDrop Then

                If e.Button = Windows.Forms.MouseButtons.Left Then
                    If Not dragBoxFromMouseDown = Nothing And dragBoxFromMouseDown.Contains(e.X, e.Y) Then

                        dgv.DoDragDrop(dgv.Rows(rowIndexFromMouseDown), DragDropEffects.Move)

                    End If
                End If

                RaiseEvent MouseMove(sender, e)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Handles the MouseDown event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv.MouseDown
        Try

            If AllowDrop Then

                'Get the index of the item the mouse is below.
                rowIndexFromMouseDown = dgv.HitTest(e.X, e.Y).RowIndex

                If Not rowIndexFromMouseDown = -1 Then
                    Dim dragSize As Size = SystemInformation.DragSize
                    CurrentRowBackColor = dgv.Item(1, rowIndexFromMouseDown).Style.BackColor
                    CurrentRowForeColor = dgv.Item(1, rowIndexFromMouseDown).Style.ForeColor
                    dragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
                Else
                    dragBoxFromMouseDown = Nothing
                End If
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Handles the DragOver event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgv.DragOver
        If AllowDrop Then
            e.Effect = DragDropEffects.Move
        End If

    End Sub

    ''' <summary>
    ''' Handles the DragDrop event of the dgv control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
    Private Sub dgv_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgv.DragDrop

        If AllowDrop Then

            Dim pt As Point = dgv.PointToClient(New Point(e.X, e.Y))

            If Not AllowDrop Then
                Exit Sub
            End If
            rowIndexOfItemUnderMouseToDrop = dgv.HitTest(pt.X, pt.Y).RowIndex()

            Try

                If AllowUserToAddRows AndAlso dsGrid.Tables(0).Rows.Count - 1 = rowIndexFromMouseDown Then
                    Exit Sub

                End If
                If e.Effect = DragDropEffects.Move AndAlso Not MultiSelect Then
                    '單選的單筆拖拉
                    Dim rowToMove As DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)

                    ' dsGrid.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)

                    Dim drGrid, drDB, drReadOnly As DataRow
                    drGrid = dsGrid.Tables(0).NewRow()
                    drDB = dsDB.Tables(0).NewRow()
                    drReadOnly = dsDgvReadOnly.Tables(0).NewRow

                    For i As Integer = 0 To dsGrid.Tables(0).Columns.Count - 1
                        drGrid.Item(i) = dsGrid.Tables(0).Rows(rowIndexFromMouseDown).Item(i)

                        drDB.Item(i) = dsDB.Tables(0).Rows(rowIndexFromMouseDown).Item(i)
                        drReadOnly.Item(i) = dsDgvReadOnly.Tables(0).Rows(rowIndexFromMouseDown).Item(i)

                    Next

                    If rowIndexOfItemUnderMouseToDrop > -1 AndAlso dgv.AllowDrop Then

                        dsGrid.Tables(0).Rows.InsertAt(drGrid, rowIndexOfItemUnderMouseToDrop)
                        dsDB.Tables(0).Rows.InsertAt(drDB, rowIndexOfItemUnderMouseToDrop)
                        dsDgvReadOnly.Tables(0).Rows.InsertAt(drReadOnly, rowIndexOfItemUnderMouseToDrop)

                        If rowIndexOfItemUnderMouseToDrop < rowIndexFromMouseDown Then
                            rowIndexFromMouseDown = rowIndexFromMouseDown + 1
                            dsGrid.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                            dsDB.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                            dsDgvReadOnly.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                        Else
                            dsGrid.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                            dsDB.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                            dsDgvReadOnly.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                        End If

                        dgv.ClearSelection()
                        dgv.Rows(rowIndexOfItemUnderMouseToDrop).Selected = True

                    End If

                ElseIf e.Effect = DragDropEffects.Move AndAlso MultiSelect AndAlso uclColumnCheckBox Then
                    '可多選的單筆多拉

                    If uclTreeMode Then
                        If dgv.Rows(rowIndexFromMouseDown).Cells(1).Value = "－" Then
                            '展開的Row不給拖拉
                            Exit Sub
                        End If
                    End If

                    Dim rowToMove As DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
                    Dim IsThisRowSelected As Boolean
                    ' dsGrid.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)

                    Dim drGrid, drDB, drReadOnly As DataRow
                    drGrid = dsGrid.Tables(0).NewRow()
                    drDB = dsDB.Tables(0).NewRow()
                    drReadOnly = dsDgvReadOnly.Tables(0).NewRow

                    'rowIndexFromMouseDown : Start
                    'rowIndexOfItemUnderMouseToDrop : End
                    For i As Integer = 0 To dsGrid.Tables(0).Columns.Count - 1
                        drGrid.Item(i) = dsGrid.Tables(0).Rows(rowIndexFromMouseDown).Item(i)

                        drDB.Item(i) = dsDB.Tables(0).Rows(rowIndexFromMouseDown).Item(i)
                        drReadOnly.Item(i) = dsDgvReadOnly.Tables(0).Rows(rowIndexFromMouseDown).Item(i)

                    Next

                    IsThisRowSelected = dgv.Rows(rowIndexFromMouseDown).Cells(0).Value

                    If rowIndexOfItemUnderMouseToDrop > -1 AndAlso dgv.AllowDrop Then

                        dsGrid.Tables(0).Rows.InsertAt(drGrid, rowIndexOfItemUnderMouseToDrop)
                        dsDB.Tables(0).Rows.InsertAt(drDB, rowIndexOfItemUnderMouseToDrop)
                        dsDgvReadOnly.Tables(0).Rows.InsertAt(drReadOnly, rowIndexOfItemUnderMouseToDrop)

                        If rowIndexOfItemUnderMouseToDrop < rowIndexFromMouseDown Then
                            rowIndexFromMouseDown = rowIndexFromMouseDown + 1
                            dsGrid.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                            dsDB.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                            dsDgvReadOnly.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)

                        Else
                            dsGrid.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                            dsDB.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                            dsDgvReadOnly.Tables(0).Rows.RemoveAt(rowIndexFromMouseDown)
                        End If

                        dgv.ClearSelection()
                        dgv.Rows(rowIndexOfItemUnderMouseToDrop).Selected = True
                        '  SetRowColor(rowIndexOfItemUnderMouseToDrop, CurrentRowBackColor)
                        dgv.Rows(rowIndexOfItemUnderMouseToDrop).Cells(0).Value = IsThisRowSelected

                    End If

                End If

                '更新CheckBox Cell值
                If hash IsNot Nothing Then

                    Dim cells As IDictionaryEnumerator = hash.GetEnumerator()
                    cells.Reset()

                    While cells.MoveNext()

                        If cells.Value.ToString() = "Syscom.Client.UCL.CheckBoxCell" Then

                            Dim chkCol As New DataGridViewCheckBoxColumn(False)
                            chkCol.HeaderText = dgv.Columns(CInt(cells.Key)).HeaderText

                            dgv.Columns.RemoveAt(CInt(cells.Key))
                            dgv.Columns.Insert(CInt(cells.Key), chkCol)

                            For i As Integer = 0 To dsGrid.Tables(0).Rows.Count - 1

                                If MultiSelect Then
                                    'dsGrid的資料不見了~用dsDB的
                                    If dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - 1 - TreeGridCol).ToString().Trim() = "Y" OrElse dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - 1 - TreeGridCol).ToString().Trim().ToUpper = "TRUE" Then
                                        dgv.Rows(i).Cells(CInt(cells.Key)).Value = True
                                        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
                                        'SendKeys.Send("{TAB}")
                                        'dgv.CurrentCell = dgv.Rows(dgv.CurrentCell.RowIndex).Cells(1)

                                    ElseIf dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - 1 - TreeGridCol).ToString().Trim() = "N" OrElse dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - 1 - TreeGridCol).ToString().Trim().ToUpper = "FALSE" OrElse dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - 1).ToString().Trim().ToUpper = "" Then
                                        dgv.Rows(i).Cells(CInt(cells.Key)).Value = False
                                        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
                                        'SendKeys.Send("{TAB}")
                                        'dgv.CurrentCell = dgv.Rows(dgv.CurrentCell.RowIndex).Cells(1)

                                    End If
                                Else

                                    'dsGrid的資料不見了~用dsDB的
                                    If dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - TreeGridCol).ToString().Trim() = "Y" OrElse dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - TreeGridCol).ToString().Trim().ToUpper = "TRUE" Then
                                        dgv.Rows(i).Cells(CInt(cells.Key)).Value = True
                                        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
                                        'SendKeys.Send("{TAB}")
                                        'dgv.CurrentCell = dgv.Rows(dgv.CurrentCell.RowIndex).Cells(1)

                                    ElseIf dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - TreeGridCol).ToString().Trim() = "N" OrElse dsDB.Tables(0).Rows(i).Item(CInt(cells.Key) - TreeGridCol).ToString().Trim().ToUpper = "FALSE" Then
                                        dgv.Rows(i).Cells(CInt(cells.Key)).Value = False
                                        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
                                        'SendKeys.Send("{TAB}")
                                        'dgv.CurrentCell = dgv.Rows(dgv.CurrentCell.RowIndex).Cells(1)

                                    End If

                                End If

                            Next

                        End If
                    End While

                End If

                SetColWidth()
                For i As Integer = 0 To dsDgvReadOnly.Tables(0).Columns.Count - 1

                    For j As Integer = 0 To dsDgvReadOnly.Tables(0).Rows.Count - 1
                        If dsDgvReadOnly.Tables(0).Rows(j).Item(i) Is Nothing OrElse dsDgvReadOnly.Tables(0).Rows(j).Item(i).ToString.Trim = "" Then
                            SetCellReadOnly(i, j, False)
                        Else

                            SetCellReadOnly(i, j, True)

                        End If

                    Next
                Next
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Catch ex As Exception
                Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            End Try
        End If
    End Sub

#End Region

#Region "TreeGridView"

    ''' <summary>
    ''' Sets the child grid view.
    ''' </summary>
    ''' <param name="hashNodeSource">The hash node source.</param>
    ''' <param name="RowIndex">Index of the row.</param>
    ''' <param name="Tag">The tag.</param>
    Public Sub SetChildGridView(ByRef hashNodeSource As Hashtable, ByVal RowIndex As Integer, ByVal Tag As String)

        Try

            Dim ChildGridView As New UCLDataGridViewUC
            Dim tempControl As Control = Me
            Dim GridVewSN As Integer = 0
            Dim SetRowIndex As Integer = RowIndex

            For i As Integer = 0 To RowIndex - 1
                If GetGridDS.Tables(0).Rows(i).Item(0).ToString.Trim = "" Then
                    SetRowIndex -= 1
                End If
            Next

            While tempControl.Parent.GetType.ToString = "System.Windows.Forms.DataGridView"
                tempControl = tempControl.Parent
            End While

            If hashGrid.Contains(SetRowIndex) Then
                GridVewSN = CType(hashGrid(SetRowIndex), ArrayList).Count
            End If

            If Me.Parent.GetType.ToString <> "System.Windows.Forms.DataGridView" Then

                ChildGridView.Name = tempControl.Name & "/" & (CurrentTreeLevel + 1).ToString & SetRowIndex.ToString & GridVewSN.ToString
            Else
                ChildGridView.Name = Me.Name & "/" & (CurrentTreeLevel + 1).ToString & SetRowIndex.ToString & GridVewSN.ToString
            End If

            ChildGridView.CurrentTreeLevel = CurrentTreeLevel + 1
            ChildGridView.MultiSelect = True
            ChildGridView.AllowUserToAddRows = True
            ChildGridView.uclColumnCheckBox = True
            ChildGridView.uclTreeMode = True

            If hashNodeSource(2).GetType.ToString() = "Syscom.Client.UCL.ComboBoxGridCell" Then
                CType(hashNodeSource(2), ComboBoxGridCell).CtlName = ChildGridView.Name
            End If

            ChildGridView.Initial(hashNodeSource)

            If hashGrid.Contains(SetRowIndex) Then
                RowChildGridCollection = CType(hashGrid(SetRowIndex), ArrayList)

                hashGrid.Remove(SetRowIndex)
                ChildGridView.Columns(0).Frozen = True
                RowChildGridCollection.Add(ChildGridView)
                hashGrid.Add(RowIndex, RowChildGridCollection)
            Else
                RowChildGridCollection = New ArrayList
                ChildGridView.Columns(0).Frozen = True
                RowChildGridCollection.Add(ChildGridView)
                hashGrid.Add(SetRowIndex, RowChildGridCollection)
            End If

            doCellValueChange = False
            dgv.Rows(RowIndex).Cells(1).Value = "＋"
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
            doCellValueChange = True

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Shows the child grid view.
    ''' </summary>
    ''' <param name="RowIndex">Index of the row.</param>
    Public Sub ShowChildGridView(ByVal RowIndex As Integer)

        Try
            Dim ShowRowIndex As Integer = RowIndex
            Dim ChildGridViewHeight As Integer = 110

            For i As Integer = 0 To RowIndex - 1
                If GetGridDS.Tables(0).Rows(i).Item(0).ToString.Trim = "" Then
                    ShowRowIndex -= 1
                End If
            Next

            If Not hashGrid.Contains(ShowRowIndex) Then
                Exit Sub
            End If

            Dim ChildGridViewArray As ArrayList = CType(hashGrid(ShowRowIndex), ArrayList)
            Dim ChildGridView(ChildGridViewArray.Count - 1) As UCLDataGridViewUC

            If dgv.Rows(RowIndex).Cells(1).Value = "＋" Then

                dgv.Rows(RowIndex).Cells(1).Value = "－"

                Dim rect As Rectangle = dgv.GetCellDisplayRectangle(2, RowIndex, False)
                Dim totalHeight As Integer = 0

                For i As Integer = 0 To ChildGridViewArray.Count - 1
                    AddNewRowAt(RowIndex + 1)
                    dgv.Rows(RowIndex + 1).Height = ChildGridViewHeight

                    ChildGridView(i) = CType(ChildGridViewArray(i), UCLDataGridViewUC)
                    If i = 0 Then
                        ChildGridView(0).Left = rect.Left
                        ChildGridView(0).Top = rect.Top + rect.Height

                        If MultiSelect Then
                            ChildGridView(0).Width = dgv.Width - dgv.Columns(0).Width
                            If uclTreeMode Then
                                ChildGridView(0).Width = ChildGridView(0).Width - dgv.Columns(1).Width
                            End If
                        End If

                    Else
                        ChildGridView(i).Left = ChildGridView(i - 1).Left
                        ChildGridView(i).Top = ChildGridView(i - 1).Top + ChildGridView(i - 1).Height
                        If MultiSelect Then
                            ChildGridView(i).Width = dgv.Width - dgv.Columns(0).Width
                            If uclTreeMode Then
                                ChildGridView(i).Width = ChildGridView(i).Width - dgv.Columns(1).Width
                            End If
                        End If
                    End If

                    ChildGridView(i).Height = ChildGridViewHeight
                    totalHeight += ChildGridView(i).Height

                    ChildGridView(i).Visible = True

                    dgv.Controls.Add(ChildGridView(i))

                    ChildGridView(i).SelectNextControl(Me, True, True, True, True)
                    Me.ActiveControl = ChildGridView(i)

                    'Debug.WriteLine("TreeLevel:" & ChildGridView(i).CurrentTreeLevel.ToString)
                    'Debug.WriteLine(ChildGridView(i).Height.ToString & "   " & i.ToString)

                Next

            ElseIf dgv.Rows(RowIndex).Cells(1).Value = "－" Then

                dgv.Rows(RowIndex).Cells(1).Value = "＋"

                For i As Integer = 0 To ChildGridViewArray.Count - 1
                    ChildGridView(i) = CType(ChildGridViewArray(i), UCLDataGridViewUC)
                    RemoveRowAt(RowIndex + 1)
                Next

                For i As Integer = 0 To ChildGridViewArray.Count - 1
                    dgv.Controls.RemoveByKey(ChildGridView(i).Name)

                Next

            End If

            ClearSelection()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Gets the child grid view.
    ''' </summary>
    ''' <param name="ChildGridViewName">Name of the child grid view.</param>
    ''' <returns>UCLDataGridViewUC.</returns>
    Public Function GetChildGridView(ByVal ChildGridViewName As String) As UCLDataGridViewUC

        Dim TargetTreeLeve As Integer = 0

        Dim NodePath() As String = Split(ChildGridViewName, "/")

        TargetTreeLeve = NodePath.Length - 1

        If CurrentTreeLevel + 1 = TargetTreeLeve Then
            'CurrentLevel + ParentRowIndex + ParentRowGridNo
            'Dim hashGrid As Hashtable               '記錄哪些 Row有 ChildGridView
            'Dim RowChildGridCollection As ArrayList '記錄一個Row 所擁有的ChildGridView 集合

            'RowChildGridCollection.Add(ChildGridView)
            'hashGrid.Add(RowIndex, RowChildGridCollection)

            If hashGrid.Contains(CType(NodePath(NodePath.Length - 1).Substring(1, 1), Integer)) Then
                For i As Integer = 0 To CType(hashGrid(CType(NodePath(NodePath.Length - 1).Substring(1, 1), Integer)), ArrayList).Count - 1
                    If CType(CType(hashGrid(CType(NodePath(NodePath.Length - 1).Substring(1, 1), Integer)), ArrayList).Item(i), UCLDataGridViewUC).Name = ChildGridViewName Then
                        Return CType(CType(hashGrid(CType(NodePath(NodePath.Length - 1).Substring(1, 1), Integer)), ArrayList).Item(i), UCLDataGridViewUC)
                        Exit For
                    End If
                Next
            End If

            Return Nothing
        ElseIf CurrentTreeLevel < TargetTreeLeve Then

            If hashGrid.Contains(CType(NodePath(CurrentTreeLevel + 1).Substring(1, 1), Integer)) Then
                For i As Integer = 0 To CType(hashGrid(CType(NodePath(CurrentTreeLevel + 1).Substring(1, 1), Integer)), ArrayList).Count - 1
                    If CType(CType(hashGrid(CType(NodePath(CurrentTreeLevel + 1).Substring(1, 1), Integer)), ArrayList).Item(i), UCLDataGridViewUC).Name = NodePath(0) & "/" & NodePath(1) Then
                        Return CType(CType(hashGrid(CType(NodePath(CurrentTreeLevel + 1).Substring(1, 1), Integer)), ArrayList).Item(i), UCLDataGridViewUC).GetChildGridView(ChildGridViewName)
                        Exit For
                    End If
                Next
            End If

        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Processes the tree scoll.
    ''' </summary>
    ''' <param name="e">The <see cref="System.Windows.Forms.ScrollEventArgs"/> instance containing the event data.</param>
    Private Sub ProcessTreeScoll(ByVal e As System.Windows.Forms.ScrollEventArgs)

        'If hashGrid.Count = 0 Then
        '    Exit Sub
        'End If

        'Dim ChildGridViewArray As ArrayList = CType(hashGrid(dgv.CurrentCell.RowIndex), ArrayList)
        'Dim ChildGridView(ChildGridViewArray.Count - 1) As UCLDataGridViewUI
        'Dim totalHeight As Integer = 0
        'Dim rect As Rectangle = dgv.GetCellDisplayRectangle(2, dgv.CurrentCell.RowIndex, True)

        'For i As Integer = 0 To ChildGridViewArray.Count - 1
        '    ChildGridView(i) = CType(ChildGridViewArray(i), UCLDataGridViewUI)
        '    If i = 0 Then
        '        ChildGridView(0).Left = rect.Left
        '        ChildGridView(0).Top = rect.Top + rect.Height

        '        If MultiSelect Then
        '            ChildGridView(0).Width = dgv.Width - dgv.Columns(0).Width
        '            If uclTreeMode Then
        '                ChildGridView(0).Width = ChildGridView(0).Width - dgv.Columns(1).Width
        '            End If
        '        End If

        '    Else
        '        ChildGridView(i).Left = ChildGridView(i - 1).Left
        '        ChildGridView(i).Top = ChildGridView(i - 1).Top + ChildGridView(i - 1).Height
        '        If MultiSelect Then
        '            ChildGridView(i).Width = dgv.Width - dgv.Columns(0).Width
        '            If uclTreeMode Then
        '                ChildGridView(i).Width = ChildGridView(i).Width - dgv.Columns(1).Width
        '            End If
        '        End If
        '    End If

        '    ChildGridView(i).Height = 110
        '    totalHeight += ChildGridView(i).Height

        '  ChildGridView(i).Visible = True

        'dgv.Controls.Add(ChildGridView(i))

        ' ChildGridView(i).SelectNextControl(Me, True, True, False, True)

        'Next

    End Sub

    ''' <summary>
    ''' Gets the tree grid view all grid ds.
    ''' </summary>
    ''' <param name="IncludeFirstLevelData">if set to <c>true</c> [include first level data].</param>
    ''' <returns>DataSet.</returns>
    Public Function GetTreeGridViewAllGridDS(ByVal IncludeFirstLevelData As Boolean) As DataSet

        Dim AllGridDS As New DataSet
        Dim TempDS As New DataSet
        If IncludeFirstLevelData Then
            AllGridDS.Tables.Add(GetGridDS.Tables(0).Copy)

            'Dim hashGrid As Hashtable               '記錄哪些 Row有 ChildGridView
            'Dim RowChildGridCollection As ArrayList '記錄一個Row 所擁有的ChildGridView 集合

            TempDS.Tables.Add(GetGridDS.Tables(0).Copy)

            For s As Integer = 0 To TempDS.Tables(0).Rows.Count - 2

                If TempDS.Tables(0).Rows(s).Item(0).ToString.Trim = "" AndAlso TempDS.Tables(0).Rows(s).Item(1).ToString.Trim = "" Then
                    TempDS.Tables(0).Rows.RemoveAt(s)

                End If

            Next

            For i As Integer = 0 To TempDS.Tables(0).Rows.Count - 1
                If hashGrid.Contains(i) Then

                    For j As Integer = 0 To CType(hashGrid(i), ArrayList).Count - 1
                        CType(CType(hashGrid(i), ArrayList)(j), UCLDataGridViewUC).GetGridDS().Tables(0).TableName = CType(CType(hashGrid(i), ArrayList)(j), UCLDataGridViewUC).Name
                        AllGridDS.Tables.Add(CType(CType(hashGrid(i), ArrayList)(j), UCLDataGridViewUC).GetGridDS().Tables(0).Copy())
                        Dim TempDS2 As New DataSet
                        TempDS2.Tables.Add(CType(CType(hashGrid(i), ArrayList)(j), UCLDataGridViewUC).GetGridDS.Tables(0).Copy)

                        For q As Integer = 0 To TempDS.Tables(0).Rows.Count - 2

                            If TempDS.Tables(0).Rows(q).Item(0).ToString.Trim = "" AndAlso TempDS.Tables(0).Rows(q).Item(1).ToString.Trim = "" Then
                                TempDS.Tables(0).Rows.RemoveAt(q)

                            End If

                        Next

                        For k As Integer = 0 To TempDS2.Tables(0).Rows.Count - 1
                            If CType(CType(hashGrid(i), ArrayList)(j), UCLDataGridViewUC).hashGrid.Contains(k) Then
                                For h As Integer = 0 To CType(CType(CType(hashGrid(i), ArrayList)(j), UCLDataGridViewUC).hashGrid(k), ArrayList).Count - 1

                                    CType(CType(CType(CType(hashGrid(i), ArrayList)(j), UCLDataGridViewUC).hashGrid(k), ArrayList)(h), UCLDataGridViewUC).GetGridDS().Tables(0).TableName = CType(CType(CType(CType(hashGrid(i), ArrayList)(j), UCLDataGridViewUC).hashGrid(k), ArrayList)(h), UCLDataGridViewUC).Name
                                    AllGridDS.Tables.Add(CType(CType(CType(CType(hashGrid(i), ArrayList)(j), UCLDataGridViewUC).hashGrid(k), ArrayList)(h), UCLDataGridViewUC).GetGridDS().Tables(0).Copy())

                                Next

                            End If

                        Next

                    Next

                End If

            Next

        Else

        End If

        Return AllGridDS
    End Function

    ''' <summary>
    ''' Gets the tree grid view all DBDS.
    ''' </summary>
    ''' <param name="IncludeFirstLevelData">if set to <c>true</c> [include first level data].</param>
    ''' <returns>DataSet.</returns>
    Public Function GetTreeGridViewAllDBDS(ByVal IncludeFirstLevelData As Boolean) As DataSet

        Dim AllDBDS As New DataSet

        If IncludeFirstLevelData Then
            AllDBDS.Tables.Add(GetDBDS.Tables(0).Copy)

        Else

        End If

        Return AllDBDS
    End Function

    ''' <summary>
    ''' Sends my name.
    ''' </summary>
    Private Sub SendMyName()
        If uclTreeMode Then
            Try
                If SendGridViewNameMgr Is Nothing Then
                    SendGridViewNameMgr = EventManager.getInstance
                End If
                SendGridViewNameMgr.RaiseUclGetActiveTreeGridView(Me.Name)
            Catch ex As Exception
                Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            End Try

        End If

    End Sub

#End Region

#Region "動態設定隨輸隨選查詢"

    ''' <summary>
    ''' Sets the ComboBox grid.
    ''' </summary>
    ''' <param name="ColIndex">Index of the col.</param>
    ''' <param name="DisplayIndex">The display index.</param>
    ''' <param name="ValueIndex">Index of the value.</param>
    ''' <param name="NonVisibleColIndex">Index of the non visible col.</param>
    ''' <param name="GridWidth">Width of the grid.</param>
    ''' <param name="GridHeight">Height of the grid.</param>
    ''' <param name="QueryData">The query data.</param>
    ''' <param name="OrderTypeId">The order type identifier.</param>
    ''' <param name="QueryType">Type of the query.</param>
    ''' <param name="HeaderText">The header text.</param>
    ''' <param name="DBType">Type of the database.</param>
    Public Sub SetComboBoxGrid(ByVal ColIndex As Integer, ByVal DisplayIndex As String, ByVal ValueIndex As String, ByVal NonVisibleColIndex As String, ByVal GridWidth As Integer, ByVal GridHeight As Integer, ByVal QueryData As ComboBoxGridCell.Data, ByVal OrderTypeId As ComboBoxGridCell.OrderTypeIdData, ByVal QueryType As ComboBoxGridCell.By, ByVal HeaderText As String, Optional ByVal DBType As ComboBoxGridCell.DBType = ComboBoxGridCell.DBType.RemoteSqlServer)

        Dim tempComboBoxGridCell As ComboBoxGridCell = CType(hash(ColIndex), ComboBoxGridCell)

        hash.Remove(ColIndex)
        tempComboBoxGridCell.DisplayIndex = DisplayIndex
        tempComboBoxGridCell.ValueIndex = ValueIndex
        tempComboBoxGridCell.NonVisibleColIndex = NonVisibleColIndex
        tempComboBoxGridCell.GridWidth = GridWidth
        tempComboBoxGridCell.GridHeight = GridHeight
        tempComboBoxGridCell.QueryData = QueryData
        tempComboBoxGridCell.QueryType = QueryType
        tempComboBoxGridCell.HeaderText = HeaderText
        tempComboBoxGridCell.OrderTypeId = OrderTypeId
        tempComboBoxGridCell.ConnDBType = DBType

        hash.Add(ColIndex, tempComboBoxGridCell)

    End Sub
#End Region

#Region "動態設定隨輸隨選資料"

    ''' <summary>
    ''' Sets the ComboBox grid local data.
    ''' </summary>
    ''' <param name="ds">The ds.</param>
    Public Sub SetComboBoxGridLocalData(ByVal ds As DataSet)
        If cboGrid_cell IsNot Nothing Then
            cboGrid_cell.SetLocalData(ds)
            cboGrid_cell.IsLocalQuery = True
        End If
    End Sub

#End Region

#Region "##### 模組內共用 Add by Jen#####"

    ''' <summary>
    ''' 將column String陣列 轉成 header型式
    ''' </summary>
    ''' <param name="ColumnName">Name of the column.</param>
    ''' <returns>System.String.</returns>
    Public Shared Function convertColumnToHeader(ByRef ColumnName() As String) As String
        Dim CombineStr As StringBuilder = New StringBuilder
        If ColumnName IsNot Nothing AndAlso ColumnName.Length > 0 Then
            For i As Integer = 0 To (ColumnName.Length - 1)
                CombineStr.Append(ColumnName(i))
                If i <> (ColumnName.Length - 1) Then
                    CombineStr.Append(",")
                End If
            Next
            Return CombineStr.ToString
        Else
            Return ""
        End If
    End Function

#End Region

#Region "設定奇數列顏色"
    ''' <summary>
    ''' Sets the alternating rows colors.
    ''' </summary>
    ''' <param name="Value">The value.</param>
    Public Sub SetAlternatingRowsColors(ByVal Value As Color)
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Value
        uclAlternatingRowsColors = Value

    End Sub

#End Region

#Region "設定資料列交錯的顏色"

    ''' <summary>
    ''' 設定資料列交錯的顏色
    ''' </summary>
    ''' <param name="oddColor">奇數行顏色</param>
    ''' <param name="evenColor">偶數行顏色</param>
    ''' <remarks>by Sean.Lin on 2016-04-07</remarks>
    Public Sub SetStaggeredRowsColors(ByVal oddColor As Color, ByVal evenColor As Color)

        '設定底色(偶數行)
        dgv.RowsDefaultCellStyle.BackColor = evenColor

        '設定奇數列顏色
        SetAlternatingRowsColors(oddColor)

    End Sub

#End Region

    ''' <summary>
    ''' Automatics the resize rows.
    ''' </summary>
    Public Sub AutoResizeRows()
        dgv.AutoResizeRows()
    End Sub

    ''' <summary>
    ''' 移除User所勾選的所有資料,若User沒有勾選則return false,
    ''' 此方法僅移除畫面上的資料,資料庫的資料需要自己去移除
    ''' </summary>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    Public Function RemoveAllSelectedRow() As Boolean
        If GetSelectedIndex() IsNot Nothing AndAlso GetSelectedIndex.Count > 0 Then
            '刪除所勾選的資料
            Dim delIdx() As Integer = GetSelectedIndex()
            Dim idx As Integer
            '移除的動作需從最後一筆開始刪除
            For i As Integer = (delIdx.Length - 1) To 0 Step -1
                idx = delIdx(i)

                GetDBDS().Tables(0).Rows.RemoveAt(idx)
                GetDgvReadOnlyDS().Tables(0).Rows.RemoveAt(idx)
                GetGridDS.Tables(0).Rows.RemoveAt(idx)
            Next
        End If
    End Function

    ''' <summary>
    ''' Returns the number of rows displayed to the user.
    ''' </summary>
    ''' <param name="includePartialRow">true to include partial rows in the displayed row count; otherwise, false.</param>
    ''' <returns>System.Int32.</returns>
    Public Function DisplayedRowCount(includePartialRow As Boolean) As Integer
        Return dgv.DisplayedRowCount(includePartialRow)
    End Function

    ''' <summary>
    ''' 將DataGridView移至最後一列
    ''' </summary>
    Public Sub ScrollToLastRowOfDataGridView()
        If dgv IsNot Nothing AndAlso dgv.Rows.Count > 0 Then
            dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1
        End If
    End Sub

    ''' <summary>
    ''' 將DataGridView移至特定列數
    ''' </summary>
    ''' <param name="RowIndex">Index of the row.</param>
    Public Sub ScrollToPositionOfDataGridView(ByVal RowIndex As Int32)
        If dgv IsNot Nothing AndAlso dgv.Rows.Count > 0 Then
            dgv.FirstDisplayedScrollingRowIndex = RowIndex
        End If
    End Sub

    ''' <summary>
    ''' 將DataGridView移至最後一行
    ''' </summary>
    Public Sub ScrollToLastColumnOfDataGridView()
        If dgv IsNot Nothing AndAlso dgv.Columns.Count > 0 Then
            dgv.FirstDisplayedScrollingColumnIndex = dgv.Columns.Count - 1
        End If
    End Sub

    ''' <summary>
    ''' 將DataGridView移至特定行數
    ''' </summary>
    ''' <param name="ColumnIndex">Index of the column.</param>
    Public Sub ScrollToColumnOfDataGridView(ByVal ColumnIndex As Int32)
        If dgv IsNot Nothing AndAlso dgv.Columns.Count > 0 Then
            dgv.FirstDisplayedScrollingColumnIndex = ColumnIndex
        End If
    End Sub

End Class

#Region "各個Cell元件 Class ,20090521 add by James"

#Region "Class CheckBox Cell ,20090521 add by James"
''' <summary>
''' Class CheckBoxCell.
''' </summary>
Public Class CheckBoxCell

End Class
#End Region

#Region "Class Button Cell ,20090521 add by James"
''' <summary>
''' Class ButtonCell.
''' </summary>
Public Class ButtonCell
    ''' <summary>
    ''' The text
    ''' </summary>
    Private _Text As String = ""

    ''' <summary>
    ''' Gets or sets the text.
    ''' </summary>
    ''' <value>The text.</value>
    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property
End Class
#End Region

#Region "Class DateTimePicker Cell ,20090521 add by James"
''' <summary>
''' Class DtpCell.
''' </summary>
Public Class DtpCell

    ''' <summary>
    ''' The display locale
    ''' </summary>
    Private _DisplayLocale As UCLDateTimePickerUC.Locale

    ''' <summary>
    ''' Gets or sets the display locale.
    ''' </summary>
    ''' <value>The display locale.</value>
    Public Property DisplayLocale() As UCLDateTimePickerUC.Locale
        Get
            Return _DisplayLocale
        End Get
        Set(ByVal value As UCLDateTimePickerUC.Locale)
            _DisplayLocale = value
        End Set
    End Property

End Class
#End Region

#Region "Class TextBox Cell ,20090521 add by James"
''' <summary>
''' Class TextBoxCell.
''' </summary>
Public Class TextBoxCell

    ''' <summary>
    ''' The maximum length
    ''' </summary>
    Private _MaxLength As Integer = 20
    ''' <summary>
    ''' The ucl text type
    ''' </summary>
    Private _uclTextType = uclTextTypeData.Any_Type
    ''' <summary>
    ''' The ucl int count
    ''' </summary>
    Private _uclIntCount As Integer = 2  '整數位數
    ''' <summary>
    ''' The ucl dot count
    ''' </summary>
    Private _uclDotCount As Integer = 0  '小數點位數
    ''' <summary>
    ''' The ucl minus
    ''' </summary>
    Private _uclMinus As Boolean = False

    ''' <summary>
    ''' The uclTransferForFractions 
    ''' </summary>
    Private _uclTransferForFractions As Boolean = False

    ''' <summary>
    ''' Enum uclTextTypeData
    ''' </summary>
    Enum uclTextTypeData

        ''' <summary>
        ''' Any type
        ''' </summary>
        Any_Type = 1
        ''' <summary>
        ''' The integer type
        ''' </summary>
        Integer_Type = 2
        ''' <summary>
        ''' The money type
        ''' </summary>
        Money_Type = 3
        ''' <summary>
        ''' The identifier type
        ''' </summary>
        ID_Type = 4
        ''' <summary>
        ''' The time hour24 and minute
        ''' </summary>
        Time_Hour24AndMinute = 5
        ''' <summary>
        ''' The time hour12 and minute
        ''' </summary>
        Time_Hour12AndMinute = 6
        ''' <summary>
        ''' The time hour24
        ''' </summary>
        Time_Hour24 = 7
        ''' <summary>
        ''' The time hour12
        ''' </summary>
        Time_Hour12 = 8
        ''' <summary>
        ''' The time minute
        ''' </summary>
        Time_Minute = 9
        ''' <summary>
        ''' The time second
        ''' </summary>
        Time_Second = 10
        ''' <summary>
        ''' The database integer type
        ''' </summary>
        DBInteger_Type = 11
        ''' <summary>
        ''' The English letters type
        ''' </summary>
        OnlyEnCharacters = 12
    End Enum

    '設定或取得字串最大Bytes
    ''' <summary>
    ''' Gets or sets the maximum length.
    ''' </summary>
    ''' <value>The maximum length.</value>
    Public Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the type of the ucl text.
    ''' </summary>
    ''' <value>The type of the ucl text.</value>
    Public Property uclTextType() As uclTextTypeData
        Get
            Return _uclTextType
        End Get
        Set(ByVal value As uclTextTypeData)
            _uclTextType = value

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ucl int count.
    ''' </summary>
    ''' <value>The ucl int count.</value>
    Public Property uclIntCount() As Integer
        Get
            Return _uclIntCount
        End Get
        Set(ByVal value As Integer)
            _uclIntCount = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ucl dot count.
    ''' </summary>
    ''' <value>The ucl dot count.</value>
    Public Property uclDotCount() As Integer
        Get
            Return _uclDotCount
        End Get
        Set(ByVal value As Integer)
            _uclDotCount = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl minus].
    ''' </summary>
    ''' <value><c>true</c> if [ucl minus]; otherwise, <c>false</c>.</value>
    Public Property uclMinus() As Boolean
        Get
            Return _uclMinus
        End Get
        Set(ByVal value As Boolean)
            _uclMinus = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl read only].
    ''' </summary>
    ''' <value><c>true</c> if [ucl read only]; otherwise, <c>false</c>.</value>
    Public Property uclTransferForFractions() As Boolean
        Get
            Return _uclTransferForFractions
        End Get
        Set(ByVal value As Boolean)
            _uclTransferForFractions = value
        End Set
    End Property
End Class
#End Region

#Region "Class ComboBox Cell ,20090520 add by James"
''' <summary>
''' Class ComboBoxCell.
''' </summary>
Public Class ComboBoxCell

    ''' <summary>
    ''' The ds
    ''' </summary>
    Private _Ds As DataSet = Nothing
    ''' <summary>
    ''' The display index
    ''' </summary>
    Private _DisplayIndex As String = "0,1"
    ''' <summary>
    ''' The value index
    ''' </summary>
    Private _ValueIndex As String = "0"
    ''' <summary>
    ''' The drop down style
    ''' </summary>
    Private _DropDownStyle As System.Windows.Forms.ComboBoxStyle = ComboBoxStyle.DropDownList
    ''' <summary>
    ''' The drop down width
    ''' </summary>
    Private _DropDownWidth As Integer = 20
    ''' <summary>
    ''' The is text mode
    ''' </summary>
    Private _IsTextMode As Boolean = False

    ''' <summary>
    ''' The has initial
    ''' </summary>
    Private _HasInitial As Boolean = False

    ''' <summary>
    ''' Gets or sets a value indicating whether this instance is text mode.
    ''' </summary>
    ''' <value><c>true</c> if this instance is text mode; otherwise, <c>false</c>.</value>
    Public Property IsTextMode() As Boolean
        Get
            Return _IsTextMode
        End Get
        Set(ByVal value As Boolean)
            _IsTextMode = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether this instance has initial.
    ''' </summary>
    ''' <value><c>true</c> if this instance has initial; otherwise, <c>false</c>.</value>
    Public Property HasInitial() As Boolean
        Get
            Return _HasInitial
        End Get
        Set(ByVal value As Boolean)
            _HasInitial = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ds.
    ''' </summary>
    ''' <value>The ds.</value>
    Public Property Ds() As DataSet
        Get

            Return _Ds
        End Get
        Set(ByVal value As DataSet)
            _Ds = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the display index.
    ''' </summary>
    ''' <value>The display index.</value>
    Public Property DisplayIndex() As String
        Get
            Return _DisplayIndex
        End Get
        Set(ByVal value As String)
            _DisplayIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the index of the value.
    ''' </summary>
    ''' <value>The index of the value.</value>
    Public Property ValueIndex() As String
        Get
            Return _ValueIndex
        End Get
        Set(ByVal value As String)
            _ValueIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the drop down style.
    ''' </summary>
    ''' <value>The drop down style.</value>
    Public Property DropDownStyle() As System.Windows.Forms.ComboBoxStyle
        Get
            Return _DropDownStyle
        End Get
        Set(ByVal value As System.Windows.Forms.ComboBoxStyle)
            _DropDownStyle = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the width of the drop down.
    ''' </summary>
    ''' <value>The width of the drop down.</value>
    Public Property DropDownWidth() As Integer
        Get
            Return _DropDownWidth
        End Get
        Set(ByVal value As Integer)
            _DropDownWidth = value

        End Set
    End Property

End Class

#End Region

#Region "Class ComboBoxGrid Cell ,20090521 add by James"
''' <summary>
''' Class ComboBoxGridCell.
''' </summary>
Public Class ComboBoxGridCell

    ''' <summary>
    ''' The start query length
    ''' </summary>
    Private _StartQueryLength As Integer = 2
    ''' <summary>
    ''' The display index
    ''' </summary>
    Private _DisplayIndex As String = "0,1"
    ''' <summary>
    ''' The value index
    ''' </summary>
    Private _ValueIndex As String = "0"
    ''' <summary>
    ''' The non visible col index
    ''' </summary>
    Private _NonVisibleColIndex As String = ""
    ''' <summary>
    ''' The visible col index
    ''' </summary>
    Private _VisibleColIndex As String = ""
    ''' <summary>
    ''' The header text
    ''' </summary>
    Private _HeaderText As String = ""
    ''' <summary>
    ''' The column width
    ''' </summary>
    Private _ColumnWidth As String = ""
    ''' <summary>
    ''' The control name
    ''' </summary>
    Private _CtlName As String = ""
    ''' <summary>
    ''' The grid width
    ''' </summary>
    Private _GridWidth As Integer = 100
    ''' <summary>
    ''' The grid height
    ''' </summary>
    Private _GridHeight As Integer = 100
    ''' <summary>
    ''' The query type
    ''' </summary>
    Private _QueryType As By = By.Code
    ''' <summary>
    ''' The query data
    ''' </summary>
    Private _QueryData As Data = Data.PUB_Disease_IcdCode
    ''' <summary>
    ''' The connection database type
    ''' </summary>
    Private _ConnDBType As DBType = DBType.LocalAccess
    ''' <summary>
    ''' The disease type identifier
    ''' </summary>
    Private _DiseaseTypeId As DiseaseTypeIdData = DiseaseTypeIdData.None
    ''' <summary>
    ''' The order type identifier
    ''' </summary>
    Private _OrderTypeId As OrderTypeIdData = OrderTypeIdData.None
    ''' <summary>
    ''' The multi disease type identifier
    ''' </summary>
    Private _MultiDiseaseTypeId As String
    ''' <summary>
    ''' The ucl multi order type identifier
    ''' </summary>
    Private _uclMultiOrderTypeId As String
    ''' <summary>
    ''' The effective mode
    ''' </summary>
    Private _EffectiveMode As Boolean = False
    ''' <summary>
    ''' The basic date string
    ''' </summary>
    Private _BasicDateStr As String = ""
    ''' <summary>
    ''' The emp code
    ''' </summary>
    Private _EmpCode As String = ""
    ''' <summary>
    ''' The dep code
    ''' </summary>
    Private _DepCode As String = ""
    ''' <summary>
    ''' The is free text
    ''' </summary>
    Private _IsFreeText As Boolean = False

    ''' <summary>
    ''' The source
    ''' </summary>
    Private _Source As DBSource = DBSource.O

    ''' <summary>
    ''' The is opd
    ''' </summary>
    Private _IsOPD As OEIData = OEIData.N
    ''' <summary>
    ''' The is epd
    ''' </summary>
    Private _IsEPD As OEIData = OEIData.N
    ''' <summary>
    ''' The is ipd
    ''' </summary>
    Private _IsIPD As OEIData = OEIData.N
    ''' <summary>
    ''' The icd type
    ''' </summary>
    Private _IcdType As IcdTypeData = IcdTypeData.Icd9
    ''' <summary>
    ''' The is allow icd9 empty
    ''' </summary>
    Private _IsAllowIcd9Empty As YNData = YNData.Y
    ''' <summary>
    ''' The is allow icd10 empty
    ''' </summary>
    Private _IsAllowIcd10Empty As YNData = YNData.Y
    ''' <summary>
    ''' The is chemo drug
    ''' </summary>
    Private _Is_ChemoDrug As YNData = YNData.N
    ''' <summary>
    ''' The is all chemo drug
    ''' </summary>
    Private _Is_AllChemoDrug As YNData = YNData.N
    ''' <summary>
    ''' The is prior review
    ''' </summary>
    Private _IsPriorReview As String = ""

    'IsEqualMatch
    ''' <summary>
    ''' The is equal match
    ''' </summary>
    Private _IsEqualMatch As EqualMatchData = EqualMatchData.N
    ''' <summary>
    ''' The is check pub order dc
    ''' </summary>
    Private _IsCheckPubOrderDc As PubOrderDcData = PubOrderDcData.Y

    ''' <summary>
    ''' The is can select dc order
    ''' </summary>
    Private _IsCanSelectDcOrder As YNData = YNData.Y

    ''' <summary>
    ''' Enum OEIData
    ''' </summary>
    Enum OEIData
        ''' <summary>
        ''' The n
        ''' </summary>
        N = 0
        ''' <summary>
        ''' The y
        ''' </summary>
        Y = 1
        ''' <summary>
        ''' The c
        ''' </summary>
        C = 2
        ''' <summary>
        ''' The h
        ''' </summary>
        H = 3
    End Enum

    ''' <summary>
    ''' Enum YNData
    ''' </summary>
    Enum YNData
        ''' <summary>
        ''' The n
        ''' </summary>
        N = 0
        ''' <summary>
        ''' The y
        ''' </summary>
        Y = 1

    End Enum

    ''' <summary>
    ''' Enum EqualMatchData
    ''' </summary>
    Enum EqualMatchData
        ''' <summary>
        ''' The n
        ''' </summary>
        N = 0
        ''' <summary>
        ''' The y
        ''' </summary>
        Y = 1

    End Enum

    ''' <summary>
    ''' Enum PubOrderDcData
    ''' </summary>
    Enum PubOrderDcData
        ''' <summary>
        ''' The n
        ''' </summary>
        N = 0
        ''' <summary>
        ''' The y
        ''' </summary>
        Y = 1

    End Enum

    ''' <summary>
    ''' Enum DiseaseTypeIdData
    ''' </summary>
    Enum DiseaseTypeIdData
        ''' <summary>
        ''' The none
        ''' </summary>
        None = 0
        ''' <summary>
        ''' The out hospital
        ''' </summary>
        OutHospital = 1
        ''' <summary>
        ''' The operation
        ''' </summary>
        Operation = 2
        ''' <summary>
        ''' The accident
        ''' </summary>
        Accident = 3
        ''' <summary>
        ''' The tumour
        ''' </summary>
        Tumour = 4
    End Enum

    ''' <summary>
    ''' Enum DBType
    ''' </summary>
    Enum DBType
        ''' <summary>
        ''' The remote SQL server
        ''' </summary>
        RemoteSqlServer = 0
        ''' <summary>
        ''' The local access
        ''' </summary>
        LocalAccess = 1
        ''' <summary>
        ''' The remote then local
        ''' </summary>
        RemoteThenLocal = 2
        ''' <summary>
        ''' The local then remote
        ''' </summary>
        LocalThenRemote = 3
        ''' <summary>
        ''' The non query
        ''' </summary>
        NonQuery = 4
    End Enum

    ''' <summary>
    ''' Enum DBSource
    ''' </summary>
    Enum DBSource
        ''' <summary>
        ''' The o
        ''' </summary>
        O = 0
        ''' <summary>
        ''' The e
        ''' </summary>
        E = 1
        ''' <summary>
        ''' The i
        ''' </summary>
        I = 2

    End Enum

    ''' <summary>
    ''' Enum IcdTypeData
    ''' </summary>
    Enum IcdTypeData
        ''' <summary>
        ''' The icd9
        ''' </summary>
        Icd9 = 0
        ''' <summary>
        ''' The icd10
        ''' </summary>
        Icd10 = 1
        ''' <summary>
        ''' The only icd9
        ''' </summary>
        OnlyIcd9 = 2
        ''' <summary>
        ''' The only icd10
        ''' </summary>
        OnlyIcd10 = 3
    End Enum

    ''' <summary>
    ''' Enum OrderTypeIdData
    ''' </summary>
    Enum OrderTypeIdData

        ''' <summary>
        ''' The none
        ''' </summary>
        None = 0
        ''' <summary>
        ''' The e
        ''' </summary>
        E = 1 '藥品
        ''' <summary>
        ''' The d
        ''' </summary>
        D = 2 '-共通性處置(行政類醫令)
        ''' <summary>
        ''' The g
        ''' </summary>
        G = 3 '-衛材
        ''' <summary>
        ''' The h
        ''' </summary>
        H = 4 '-檢驗檢查
        ''' <summary>
        ''' The j
        ''' </summary>
        J = 5 '-手術
        ''' <summary>
        ''' The k
        ''' </summary>
        K = 6 ':麻醉
        ''' <summary>
        ''' The i
        ''' </summary>
        I = 7 '-健保申報用
        ''' <summary>
        ''' The ncku code
        ''' </summary>
        NckuCode = 8 '成大碼轉健保碼
    End Enum

    ''' <summary>
    ''' 使用Code 或 Name 查詢
    ''' </summary>
    Enum By
        ''' <summary>
        ''' The code
        ''' </summary>
        Code = 1
        ''' <summary>
        ''' The name
        ''' </summary>
        Name = 2
    End Enum

    ''' <summary>
    ''' Enum Data
    ''' </summary>
    Enum Data
        ''' <summary>
        ''' The pub disease icd code
        ''' </summary>
        PUB_Disease_IcdCode = 1 '醫囑診斷
        ''' <summary>
        ''' The oph pharmacy base only name
        ''' </summary>
        OPH_Pharmacy_Base_OnlyName = 0 '使用於輸入藥品代碼回傳藥名
        ''' <summary>
        ''' The oph pharmacy base normal
        ''' </summary>
        OPH_Pharmacy_Base_Normal = 2   '一般藥品
        ''' <summary>
        ''' The oph pharmacy base chemo
        ''' </summary>
        OPH_Pharmacy_Base_Chemo = 3   '化療藥品
        ''' <summary>
        ''' The oph pharmacy base TPN
        ''' </summary>
        OPH_Pharmacy_Base_TPN = 4   'TPN藥品
        ''' <summary>
        ''' The oph pharmacy base vaccine
        ''' </summary>
        OPH_Pharmacy_Base_Vaccine = 5   '疫苗接種藥品
        ''' <summary>
        ''' The pub order
        ''' </summary>
        PUB_Order = 6             '醫令
        ''' <summary>
        ''' The pub order material
        ''' </summary>
        PUB_Order_Material = 7   '醫令 -衛材
        ''' <summary>
        ''' The pub order cure
        ''' </summary>
        PUB_Order_Cure = 8   '醫令 -治療處置
        ''' <summary>
        ''' The pub order often
        ''' </summary>
        PUB_Order_Often = 9   '醫令 -常用處置維護
        ''' <summary>
        ''' The pub order dep often h
        ''' </summary>
        PUB_Order_DepOftenH = 10   '醫令 -科常用醫令 H
        ''' <summary>
        ''' The pub order examine
        ''' </summary>
        PUB_Order_Examine = 11   ' 醫令 -檢驗檢查
        ''' <summary>
        ''' The pub order operation
        ''' </summary>
        PUB_Order_Operation = 12   ' 醫令 -手術法
        ''' <summary>
        ''' The oph pharmacy base TPN and normal
        ''' </summary>
        OPH_Pharmacy_Base_TPNAndNormal = 13   'TPN 一般藥品
        ''' <summary>
        ''' The oph pharmacy base chemo and normal
        ''' </summary>
        OPH_Pharmacy_Base_ChemoAndNormal = 14   'Chemo 一般藥品
        ''' <summary>
        ''' The pub disease is severe disease
        ''' </summary>
        PUB_Disease_IsSevereDisease = 15 '醫囑診斷-重傷ICD
        ''' <summary>
        ''' The pub order insu code
        ''' </summary>
        PUB_Order_InsuCode = 16   ' 醫令 -成大碼轉健保碼
        ''' <summary>
        ''' The omo chemo dilute map
        ''' </summary>
        OMO_Chemo_Dilute_Map = 17 '化療藥 稀釋
        ''' <summary>
        ''' The oph pharmacy base TPN add
        ''' </summary>
        OPH_Pharmacy_Base_TPNAdd = 18   'TPN 添加藥品
        ''' <summary>
        ''' The pub order operation charge
        ''' </summary>
        PUB_Order_Operation_Charge = 19   ' 醫令 -手術法批價
        ''' <summary>
        ''' The eph pharmacy base normal
        ''' </summary>
        EPH_Pharmacy_Base_Normal = 20   '急診藥品
        ''' <summary>
        ''' The ihd appeal dispute reason
        ''' </summary>
        IHD_Appeal_Dispute_Reason = 24 '申復爭議作業
        ''' <summary>
        ''' The pub order mixed
        ''' </summary>
        PUB_Order_Mixed = 35 '混合開立
        ''' <summary>
        ''' The pub order insu
        ''' </summary>
        PUB_Order_Insu = 36   ' 醫令 -取得健保碼
    End Enum

    ''' <summary>
    ''' 來源
    ''' </summary>
    ''' <value>The source.</value>
    Public Property Source() As DBSource
        Get
            Return _Source
        End Get
        Set(ByVal value As DBSource)
            _Source = value

        End Set
    End Property

    ''' <summary>
    ''' 是否可選擇DC項目
    ''' </summary>
    ''' <value>The is can select dc order.</value>
    Public Property IsCanSelectDcOrder() As YNData
        Get
            Return _IsCanSelectDcOrder
        End Get
        Set(ByVal value As YNData)
            _IsCanSelectDcOrder = value
        End Set
    End Property

    ''' <summary>
    ''' 是否Order Code 完全符合
    ''' </summary>
    ''' <value>The is equal match.</value>
    Public Property IsEqualMatch() As EqualMatchData
        Get
            Return _IsEqualMatch
        End Get
        Set(ByVal value As EqualMatchData)
            _IsEqualMatch = value
        End Set
    End Property

    ''' <summary>
    ''' 是否檢查 PubOrderDc  (Y :SQL不檢查DC='Y')
    ''' </summary>
    ''' <value>The is check pub order dc.</value>
    Public Property IsCheckPubOrderDc() As PubOrderDcData
        Get
            Return _IsCheckPubOrderDc
        End Get
        Set(ByVal value As PubOrderDcData)
            _IsCheckPubOrderDc = value
        End Set
    End Property

    ''' <summary>
    ''' 是否為門診醫令
    ''' </summary>
    ''' <value>The is opd.</value>
    Public Property IsOPD() As OEIData
        Get
            Return _IsOPD
        End Get
        Set(ByVal value As OEIData)
            _IsOPD = value
        End Set
    End Property

    ''' <summary>
    ''' 是否為急診醫令
    ''' </summary>
    ''' <value>The is epd.</value>
    Public Property IsEPD() As OEIData
        Get
            Return _IsEPD
        End Get
        Set(ByVal value As OEIData)
            _IsEPD = value
        End Set
    End Property

    ''' <summary>
    ''' 是否為住院醫令
    ''' </summary>
    ''' <value>The is ipd.</value>
    Public Property IsIPD() As OEIData
        Get
            Return _IsIPD
        End Get
        Set(ByVal value As OEIData)
            _IsIPD = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the type of the icd.
    ''' </summary>
    ''' <value>The type of the icd.</value>
    Public Property IcdType() As IcdTypeData
        Get
            Return _IcdType
        End Get
        Set(ByVal value As IcdTypeData)
            _IcdType = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the is allow icd9 empty.
    ''' </summary>
    ''' <value>The is allow icd9 empty.</value>
    Public Property IsAllowIcd9Empty() As YNData
        Get
            Return _IsAllowIcd9Empty
        End Get
        Set(ByVal value As YNData)
            _IsAllowIcd9Empty = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the is allow icd10 empty.
    ''' </summary>
    ''' <value>The is allow icd10 empty.</value>
    Public Property IsAllowIcd10Empty() As YNData
        Get
            Return _IsAllowIcd10Empty
        End Get
        Set(ByVal value As YNData)
            _IsAllowIcd10Empty = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the is chemo drug.
    ''' </summary>
    ''' <value>The is chemo drug.</value>
    Public Property Is_ChemoDrug() As YNData
        Get
            Return _Is_ChemoDrug
        End Get
        Set(ByVal value As YNData)
            _Is_ChemoDrug = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the is all chemo drug.
    ''' </summary>
    ''' <value>The is all chemo drug.</value>
    Public Property Is_AllChemoDrug() As YNData
        Get
            Return _Is_AllChemoDrug
        End Get
        Set(ByVal value As YNData)
            _Is_AllChemoDrug = value
        End Set
    End Property

    ''' <summary>
    ''' 輸入幾位後開始進行隨選查詢
    ''' </summary>
    ''' <value>The start length of the query.</value>
    Public Property StartQueryLength() As Integer
        Get
            Return _StartQueryLength
        End Get
        Set(ByVal value As Integer)
            _StartQueryLength = value

        End Set
    End Property

    ''' <summary>
    ''' 是否為事審
    ''' </summary>
    ''' <value>The is prior review.</value>
    Public Property IsPriorReview() As String
        Get
            Return _IsPriorReview
        End Get
        Set(ByVal value As String)
            _IsPriorReview = value

        End Set
    End Property

    ''' <summary>
    ''' 員工代碼
    ''' </summary>
    ''' <value>The emp code.</value>
    Public Property EmpCode() As String
        Get
            Return _EmpCode
        End Get
        Set(ByVal value As String)
            _EmpCode = value

        End Set
    End Property

    ''' <summary>
    ''' 科別
    ''' </summary>
    ''' <value>The dep code.</value>
    Public Property DepCode() As String
        Get
            Return _DepCode
        End Get
        Set(ByVal value As String)
            _DepCode = value

        End Set
    End Property

    ''' <summary>
    ''' 隨選是否可Free Text
    ''' </summary>
    ''' <value><c>true</c> if this instance is free text; otherwise, <c>false</c>.</value>
    Public Property IsFreeText() As Boolean
        Get
            Return _IsFreeText
        End Get
        Set(ByVal value As Boolean)
            _IsFreeText = value
        End Set
    End Property

    ''' <summary>
    ''' 查詢最少的欄位 (目前沒用到)
    ''' </summary>
    ''' <value><c>true</c> if [effective mode]; otherwise, <c>false</c>.</value>
    Public Property EffectiveMode() As Boolean
        Get
            Return _EffectiveMode
        End Get
        Set(ByVal value As Boolean)
            _EffectiveMode = value
        End Set
    End Property

    ''' <summary>
    ''' 查詢起始日
    ''' </summary>
    ''' <value>The basic date string.</value>
    Public Property BasicDateStr() As String
        Get
            Return _BasicDateStr
        End Get
        Set(ByVal value As String)
            _BasicDateStr = value
        End Set
    End Property

    ''' <summary>
    ''' 醫令多重Order Type Id
    ''' </summary>
    ''' <value>The multi order type identifier.</value>
    Public Property MultiOrderTypeId() As String
        Get
            Return _uclMultiOrderTypeId
        End Get
        Set(ByVal value As String)
            _uclMultiOrderTypeId = value
        End Set
    End Property

    ''' <summary>
    ''' 醫令Order Type Id
    ''' </summary>
    ''' <value>The order type identifier.</value>
    Public Property OrderTypeId() As OrderTypeIdData
        Get
            Return _OrderTypeId
        End Get
        Set(ByVal value As OrderTypeIdData)
            _OrderTypeId = value
        End Set
    End Property

    ''' <summary>
    ''' 診斷Multi Disease Type Id
    ''' </summary>
    ''' <value>The multi disease type identifier.</value>
    Public Property MultiDiseaseTypeId() As String
        Get
            Return _MultiDiseaseTypeId
        End Get
        Set(ByVal value As String)
            _MultiDiseaseTypeId = value
        End Set
    End Property

    ''' <summary>
    ''' 診斷Disease Type Id
    ''' </summary>
    ''' <value>The disease type identifier.</value>
    Public Property DiseaseTypeId() As DiseaseTypeIdData
        Get
            Return _DiseaseTypeId
        End Get
        Set(ByVal value As DiseaseTypeIdData)
            _DiseaseTypeId = value
        End Set
    End Property

    ''' <summary>
    ''' 隨選 control Name
    ''' </summary>
    ''' <value>The name of the control.</value>
    Public Property CtlName() As String
        Get
            Return _CtlName
        End Get
        Set(ByVal value As String)
            _CtlName = value
        End Set
    End Property

    ''' <summary>
    ''' 隨選DisplayIndex
    ''' </summary>
    ''' <value>The display index.</value>
    Public Property DisplayIndex() As String
        Get
            Return _DisplayIndex
        End Get
        Set(ByVal value As String)
            _DisplayIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 隨選Value Index
    ''' </summary>
    ''' <value>The index of the value.</value>
    Public Property ValueIndex() As String
        Get
            Return _ValueIndex
        End Get
        Set(ByVal value As String)
            _ValueIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Header Text
    ''' </summary>
    ''' <value>The header text.</value>
    Public Property HeaderText() As String
        Get
            Return _HeaderText
        End Get
        Set(ByVal value As String)
            _HeaderText = value
        End Set
    End Property

    ''' <summary>
    ''' Column Width   (ex:"100,100,50")
    ''' </summary>
    ''' <value>The width of the column.</value>
    Public Property ColumnWidth() As String
        Get
            Return _ColumnWidth
        End Get
        Set(ByVal value As String)
            _ColumnWidth = value
        End Set
    End Property

    ''' <summary>
    ''' Non Visible Col Index  (ex:"1,2,5")  Col Index 1,2,5 不顯示
    ''' </summary>
    ''' <value>The index of the non visible col.</value>
    Public Property NonVisibleColIndex() As String
        Get
            Return _NonVisibleColIndex
        End Get
        Set(ByVal value As String)
            _NonVisibleColIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Visible Col Index (ex:"1,2,5")  Col Index 1,2,5 顯示
    ''' </summary>
    ''' <value>The index of the visible col.</value>
    Public Property VisibleColIndex() As String
        Get
            Return _VisibleColIndex
        End Get
        Set(ByVal value As String)
            _VisibleColIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Grid Width
    ''' </summary>
    ''' <value>The width of the grid.</value>
    Public Property GridWidth() As Integer
        Get
            Return _GridWidth
        End Get
        Set(ByVal value As Integer)
            If value <= 0 Then
                _GridWidth = 100
            Else
                _GridWidth = value
            End If

        End Set
    End Property

    ''' <summary>
    ''' Grid Height
    ''' </summary>
    ''' <value>The height of the grid.</value>
    Public Property GridHeight() As Integer
        Get
            Return _GridHeight
        End Get
        Set(ByVal value As Integer)
            If value <= 0 Then
                _GridHeight = 100
            Else
                _GridHeight = value
            End If

        End Set
    End Property

    ''' <summary>
    ''' 連線DB的Type
    ''' </summary>
    ''' <value>The type of the connection database.</value>
    Public Property ConnDBType() As DBType
        Get
            Return _ConnDBType
        End Get
        Set(ByVal value As DBType)
            _ConnDBType = value
        End Set
    End Property

    ''' <summary>
    ''' QueryType
    ''' </summary>
    ''' <value>The type of the query.</value>
    Public Property QueryType() As By
        Get
            Return _QueryType
        End Get
        Set(ByVal value As By)
            _QueryType = value
        End Set
    End Property

    ''' <summary>
    ''' QueryData
    ''' </summary>
    ''' <value>The query data.</value>
    Public Property QueryData() As Data
        Get
            Return _QueryData
        End Get
        Set(ByVal value As Data)
            _QueryData = value
        End Set
    End Property

End Class

#End Region

'-----------------------------------
'Add By Jen, RangeDialog
'-----------------------------------
#Region "Class UCLPopMemoUI Cell ,20100112 add by Jen"
'Public Class UCLPopMemoUI
'End Class
#End Region

#Region "Class Image Cell ,20110311 add by Barry"
''' <summary>
''' Class ImageCell.
''' </summary>
Public Class ImageCell

End Class
#End Region

#End Region

#Region "20090503 add by James ,共用元件  ColumnHeaderCheckBox"

''' <summary>
''' Class DGVColumnHeader.
''' </summary>
''' <seealso cref="System.Windows.Forms.DataGridViewColumnHeaderCell" />
Class DGVColumnHeader
    Inherits DataGridViewColumnHeaderCell

    ''' <summary>
    ''' The CheckBox region
    ''' </summary>
    Private CheckBoxRegion As Rectangle
    ''' <summary>
    ''' The check all
    ''' </summary>
    Private _checkAll As Boolean = False

    ''' <summary>
    ''' 繪製目前的 <see cref="T:System.Windows.Forms.DataGridViewColumnHeaderCell" />。
    ''' </summary>
    ''' <param name="graphics">用於繪製儲存格的 <see cref="T:System.Drawing.Graphics" />。</param>
    ''' <param name="clipBounds"><see cref="T:System.Drawing.Rectangle" />，表示需要重新繪製的 <see cref="T:System.Windows.Forms.DataGridView" /> 區域。</param>
    ''' <param name="cellBounds"><see cref="T:System.Drawing.Rectangle" />，其中包含所繪製之儲存格的界限。</param>
    ''' <param name="rowIndex">正在繪製的儲存格資料列索引。</param>
    ''' <param name="dataGridViewElementState">State of the data grid view element.</param>
    ''' <param name="value">儲存格的資料，該儲存格正在進行繪製。</param>
    ''' <param name="formattedValue">儲存格的已格式化資料，該儲存格正在進行繪製。</param>
    ''' <param name="errorText">與儲存格關聯的錯誤訊息。</param>
    ''' <param name="cellStyle"><see cref="T:System.Windows.Forms.DataGridViewCellStyle" />，包含有關儲存格的格式化和樣式資訊。</param>
    ''' <param name="advancedBorderStyle"><see cref="T:System.Windows.Forms.DataGridViewAdvancedBorderStyle" />，包含正在繪製之儲存格的邊框樣式。</param>
    ''' <param name="paintParts"><see cref="T:System.Windows.Forms.DataGridViewPaintParts" /> 值的位元組合，指定儲存格需要繪製的部分。</param>
    Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal dataGridViewElementState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)

        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)

        graphics.FillRectangle(New SolidBrush(cellStyle.BackColor), cellBounds)

        CheckBoxRegion = New Rectangle(cellBounds.Location.X + 1, cellBounds.Location.Y + 2, 25, cellBounds.Size.Height - 4)

        If Me.checkAll Then
            ControlPaint.DrawCheckBox(graphics, CheckBoxRegion, ButtonState.Checked)
        Else
            ControlPaint.DrawCheckBox(graphics, CheckBoxRegion, ButtonState.Normal)
        End If

        Dim normalRegion As Rectangle = New Rectangle(cellBounds.Location.X + 1 + 25, cellBounds.Location.Y, cellBounds.Size.Width - 26, cellBounds.Size.Height)

        graphics.DrawString(value.ToString(), cellStyle.Font, New SolidBrush(cellStyle.ForeColor), normalRegion)

    End Sub
    ''' <summary>
    ''' 當滑鼠指標在儲存格上，使用者按一下滑鼠按鈕時呼叫。
    ''' </summary>
    ''' <param name="e">包含事件資料的 <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs" />。</param>
    Protected Overrides Sub OnMouseClick(ByVal e As DataGridViewCellMouseEventArgs)

        '  //Convert the CheckBoxRegion
        Dim rec As Rectangle = New Rectangle(New Point(0, 0), Me.CheckBoxRegion.Size)
        Me.checkAll = Not Me.checkAll
        If (rec.Contains(e.Location)) Then

            Me.DataGridView.Invalidate()
        End If
        MyBase.OnMouseClick(e)
    End Sub

    ''' <summary>
    ''' Gets or sets a value indicating whether [check all].
    ''' </summary>
    ''' <value><c>true</c> if [check all]; otherwise, <c>false</c>.</value>
    Public Property checkAll() As Boolean
        Get
            Return _checkAll
        End Get
        Set(ByVal value As Boolean)
            _checkAll = value

        End Set
    End Property
End Class

#End Region

#Region "預掛取消按鈕disable 功能  by James"

''' <summary>
''' Class DataGridViewDisableButtonColumn.
''' </summary>
''' <seealso cref="System.Windows.Forms.DataGridViewButtonColumn" />
Public Class DataGridViewDisableButtonColumn
    Inherits DataGridViewButtonColumn

    ''' <summary>
    ''' Initializes a new instance of the <see cref="DataGridViewDisableButtonColumn"/> class.
    ''' </summary>
    Public Sub New()
        Me.CellTemplate = New DataGridViewDisableButtonCell()
    End Sub
End Class

''' <summary>
''' Class DataGridViewDisableButtonCell.
''' </summary>
''' <seealso cref="System.Windows.Forms.DataGridViewButtonCell" />
Public Class DataGridViewDisableButtonCell
    Inherits DataGridViewButtonCell

    ''' <summary>
    ''' The enabled value
    ''' </summary>
    Private enabledValue As Boolean
    ''' <summary>
    ''' Gets or sets a value indicating whether this <see cref="DataGridViewDisableButtonCell"/> is enabled.
    ''' </summary>
    ''' <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
    Public Property Enabled() As Boolean
        Get
            Return enabledValue
        End Get
        Set(ByVal value As Boolean)
            enabledValue = value
        End Set
    End Property

    ' Override the Clone method so that the Enabled property is copied.
    ''' <summary>
    ''' 建立與這個儲存格完全相同的複本。
    ''' </summary>
    ''' <returns><see cref="T:System.Object" />，代表複製的 <see cref="T:System.Windows.Forms.DataGridViewButtonCell" />。</returns>
    ''' <PermissionSet>
    '''   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    '''   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    '''   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    '''   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ''' </PermissionSet>
    Public Overrides Function Clone() As Object
        Dim Cell As DataGridViewDisableButtonCell =
            CType(MyBase.Clone(), DataGridViewDisableButtonCell)
        Cell.Enabled = Me.Enabled
        Return Cell
    End Function

    ' By default, enable the button cell.
    ''' <summary>
    ''' Initializes a new instance of the <see cref="DataGridViewDisableButtonCell"/> class.
    ''' </summary>
    Public Sub New()
        Me.enabledValue = True
    End Sub

    ''' <summary>
    ''' Paint動作
    ''' </summary>
    ''' <param name="graphics">graphics</param>
    ''' <param name="clipBounds">clipBounds</param>
    ''' <param name="cellBounds">cellBounds</param>
    ''' <param name="rowIndex">row Index</param>
    ''' <param name="elementState">elementState</param>
    ''' <param name="value">value</param>
    ''' <param name="formattedValue">formattedValue</param>
    ''' <param name="errorText">errorText</param>
    ''' <param name="cellStyle">cellStyle</param>
    ''' <param name="advancedBorderStyle">advancedBorderStyle</param>
    ''' <param name="paintParts">paintParts</param>
    Protected Overrides Sub Paint(ByVal graphics As Graphics,
        ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle,
        ByVal rowIndex As Integer,
        ByVal elementState As DataGridViewElementStates,
        ByVal value As Object, ByVal formattedValue As Object,
        ByVal errorText As String,
        ByVal cellStyle As DataGridViewCellStyle,
        ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle,
        ByVal paintParts As DataGridViewPaintParts)

        ' The button cell is disabled, so paint the border,
        ' background, and disabled button for the cell.
        If Not Me.enabledValue Then

            ' Draw the background of the cell, if specified.
            If (paintParts And DataGridViewPaintParts.Background) =
                DataGridViewPaintParts.Background Then

                Dim cellBackground As New SolidBrush(cellStyle.BackColor)
                graphics.FillRectangle(cellBackground, cellBounds)
                cellBackground.Dispose()
            End If

            ' Draw the cell borders, if specified.
            If (paintParts And DataGridViewPaintParts.Border) =
                DataGridViewPaintParts.Border Then

                PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                    advancedBorderStyle)
            End If

            ' Calculate the area in which to draw the button.
            Dim buttonArea As Rectangle = cellBounds
            Dim buttonAdjustment As Rectangle =
                Me.BorderWidths(advancedBorderStyle)
            buttonArea.X += buttonAdjustment.X
            buttonArea.Y += buttonAdjustment.Y
            buttonArea.Height -= buttonAdjustment.Height
            buttonArea.Width -= buttonAdjustment.Width

            ' Draw the disabled button.
            ButtonRenderer.DrawButton(graphics, buttonArea,
                PushButtonState.Disabled)

            Dim font As Font = New Font("新細明體", 12, FontStyle.Regular)
            'Me.DataGridView.Font

            ' Draw the disabled button text.
            If TypeOf Me.FormattedValue Is String Then
                TextRenderer.DrawText(graphics, CStr(Me.FormattedValue),
                    font, buttonArea, SystemColors.GrayText)
            End If

        Else
            ' The button cell is enabled, so let the base class
            ' handle the painting.
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex,
                elementState, value, formattedValue, errorText,
                cellStyle, advancedBorderStyle, paintParts)
        End If
    End Sub

End Class
#End Region


