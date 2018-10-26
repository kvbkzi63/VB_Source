Imports Syscom.Client.servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.cmm
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports System.Text

Public Class UCLCheckListBoxUC

#Region "全域變數宣告"


    Private _uclItemShowFieldIndexStr As String = ""
    Private _uclCodeFieldIndexStr As String = ""
    Private _uclNameFieldIndexStr As String = ""
    Private _uclSeparator = uclSeparatorType.OneSpace_Dash_OneSpace

    Private _uclSelectedItemIndex As String = ""
    Private _uclNonSelectedItemIndex As String = ""
    Private _uclDataSource As DataSet = Nothing

    Private _SelectIndex As Integer
    'Private _SelectedIndices As System.Windows.Forms.CheckedListBox.SelectedIndexCollection
    Private _Items As System.Windows.Forms.CheckedListBox.ObjectCollection
    Private _BackColor As Color

    Private _CheckedIndices As System.Windows.Forms.CheckedListBox.CheckedIndexCollection

    Private _SelectedItems As System.Windows.Forms.CheckedListBox.SelectedObjectCollection


    Dim SeparatorStr As String = ""
    Dim SeparatorType As uclSeparatorType


#End Region

#Region "屬性設定"

    ''' <summary>
    ''' 設定在元件上顯示資料的型態 1=空白字串連結   2='-'連結
    ''' </summary>
    ''' <remarks></remarks>
    Enum uclSeparatorType

        OneSpace = 1 ' " "
        OneSpace_Dash_OneSpace = 2  '  " - "

    End Enum
    ''' <summary>
    ''' 取得元件內的項目集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property SelectedItems() As System.Windows.Forms.CheckedListBox.SelectedObjectCollection
        Get
            Return CheckedListBox1.SelectedItems
        End Get

    End Property
    ''' <summary>
    ''' 取得元件内已被選取的項目集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property CheckedIndices() As System.Windows.Forms.CheckedListBox.CheckedIndexCollection
        Get

            Return CheckedListBox1.CheckedIndices
        End Get

    End Property

    Public Property SelectedIndex() As Integer
        Get

            Return CheckedListBox1.SelectedIndex
        End Get
        Set(ByVal value As Integer)
            CheckedListBox1.SelectedIndex = value
        End Set
    End Property
    ''' <summary>
    ''' 設定背景顏色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Overrides Property BackColor() As Color
        Get
            Return CheckedListBox1.BackColor
        End Get
        Set(ByVal value As Color)
            CheckedListBox1.BackColor = value
        End Set
    End Property

    Public ReadOnly Property Items() As System.Windows.Forms.CheckedListBox.ObjectCollection
        Get
            Return CheckedListBox1.Items
        End Get

    End Property
    ''' <summary>
    ''' 設定資料顯示模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclSeparator() As uclSeparatorType
        Get
            Return _uclSeparator
        End Get
        Set(ByVal value As uclSeparatorType)
            _uclSeparator = value
        End Set
    End Property

    ''' <summary>
    ''' 設定總共要取得哪幾個Index來做為顯示在畫面上的字串資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclItemShowFieldIndexStr() As String
        Get
            Return _uclItemShowFieldIndexStr
        End Get
        Set(ByVal value As String)
            _uclItemShowFieldIndexStr = value
        End Set
    End Property

    ''' <summary>
    ''' 設定vaule的Index名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclCodeFieldIndexStr() As String
        Get
            Return _uclCodeFieldIndexStr
        End Get
        Set(ByVal value As String)
            _uclCodeFieldIndexStr = value
        End Set
    End Property

    ''' <summary>
    ''' 設定項目名稱的Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclNameFieldIndexStr() As String
        Get
            Return _uclNameFieldIndexStr
        End Get
        Set(ByVal value As String)
            _uclNameFieldIndexStr = value
        End Set
    End Property


    ''' <summary>
    ''' 取得被選取的項目Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclSelectedItemIndex() As String
        Get
            _uclSelectedItemIndex = ""
            For i As Integer = 0 To CheckedListBox1.CheckedIndices.Count - 1
                If i < CheckedListBox1.CheckedIndices.Count - 1 Then
                    If CheckedListBox1.CheckedIndices(i).ToString() <> "0" Then
                        _uclSelectedItemIndex += CheckedListBox1.CheckedIndices(i).ToString() & ","
                    End If

                Else
                    If CheckedListBox1.CheckedIndices(i).ToString() <> "0" Then
                        _uclSelectedItemIndex += CheckedListBox1.CheckedIndices(i).ToString()
                    End If

                End If

            Next

            Return _uclSelectedItemIndex

        End Get
        Set(ByVal value As String)

            '    _uclNameFieldIndexStr = value
        End Set
    End Property


    ''' <summary>
    ''' 取得未被選取的項目Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclNonSelectedItemIndex() As String
        Get
            _uclNonSelectedItemIndex = ""
            For i As Integer = 1 To CheckedListBox1.Items.Count - 1
                If i < CheckedListBox1.Items.Count - 1 Then


                    If Not GetItemChecked(i) Then
                        _uclNonSelectedItemIndex += i.ToString() & ","
                    End If

                Else
                    If Not GetItemChecked(i) Then
                        _uclNonSelectedItemIndex += i.ToString()
                    End If

                End If

            Next

            Return _uclNonSelectedItemIndex

        End Get
        Set(ByVal value As String)

            '    _uclNameFieldIndexStr = value
        End Set
    End Property
    ''' <summary>
    ''' 資料來源DS
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclDataSource() As DataSet
        Get
            Return _uclDataSource
        End Get
        Set(ByVal value As DataSet)
            _uclDataSource = value
        End Set
    End Property


#End Region

#Region "初始化"


    ''' <summary>
    ''' 初始化設定
    ''' ds:來源資料
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Initial(ByVal ds As DataSet)
        Try


            CheckedListBox1.Items.Clear()


            CheckedListBox1.Items.Add("全選")
            uclDataSource = ds

            If _uclDataSource IsNot Nothing AndAlso _uclDataSource.Tables(0).Rows.Count > 0 AndAlso _uclItemShowFieldIndexStr.Trim().Length > 0 Then
                Dim rowCount As Integer = _uclDataSource.Tables(0).Rows.Count

                Dim itemStr(rowCount) As String

                Dim showIndex As String() = Split(_uclItemShowFieldIndexStr, ",")

                For i As Integer = 0 To rowCount - 1

                    For j As Integer = 0 To showIndex.Length - 1
                        If j < showIndex.Length - 1 Then

                            itemStr(i) += _uclDataSource.Tables(0).Rows(i).Item(CInt(showIndex(j))).ToString().Trim() & " - "
                        Else

                            itemStr(i) += _uclDataSource.Tables(0).Rows(i).Item(CInt(showIndex(j))).ToString().Trim()

                        End If

                    Next
                    If itemStr(i).Trim() <> "" Then
                        CheckedListBox1.Items.Add(itemStr(i), False)
                    End If


                Next

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

#End Region

#Region "外部函數"

    ''' <summary>
    ''' 取得Item是否有勾選
    ''' </summary>
    ''' <returns>True:勾 , False:沒勾</returns>
    ''' <remarks></remarks>''' 
    Public Function GetItemChecked(ByVal index As Integer) As Boolean
        Return CheckedListBox1.GetItemChecked(index)
    End Function

    Public Function GetSelected(ByVal index As Integer) As Boolean
        Return CheckedListBox1.GetSelected(index)
    End Function

    Public Function GetItemCheckState(ByVal index As Integer) As Boolean
        Return CheckedListBox1.GetItemCheckState(index)
    End Function

    Public Sub SetSelected(ByVal index As Integer, ByVal value As Boolean)
        CheckedListBox1.SetSelected(index, value)
    End Sub

    Public Sub SetItemChecked(ByVal index As Integer, ByVal value As Boolean)
        CheckedListBox1.SetItemChecked(index, value)
    End Sub

    Public Sub SetItemCheckState(ByVal index As Integer, ByVal value As System.Windows.Forms.CheckState)
        CheckedListBox1.SetItemCheckState(index, value)

    End Sub

    ''' <summary>
    ''' 取得未選取的項目代碼
    ''' </summary>
    ''' <returns>項目代碼陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function GetNonSelectedItemCodes() As String()
        Try

            If _uclCodeFieldIndexStr.Trim() <> "" Then


                Dim codeIndex As String() = Split(Me.uclCodeFieldIndexStr, ",")
                Dim nonSelectedIndex As String() = Split(Me.uclNonSelectedItemIndex, ",")
                Dim temp As String = ""

                If nonSelectedIndex.Length > 0 AndAlso uclNonSelectedItemIndex <> "" Then
                    Dim str(nonSelectedIndex.Length - 1) As String

                    For i As Integer = 0 To nonSelectedIndex.Length - 1
                        For j As Integer = 0 To codeIndex.Length - 1

                            If j < codeIndex.Length - 1 Then
                                temp += _uclDataSource.Tables(0).Rows(CType(nonSelectedIndex(i), Integer) - 1).Item(CType(codeIndex(j), Integer)).ToString().Trim() & ","
                            Else
                                temp += _uclDataSource.Tables(0).Rows(CType(nonSelectedIndex(i), Integer) - 1).Item(CType(codeIndex(j), Integer)).ToString().Trim()
                            End If
                        Next
                        str(i) = temp
                        temp = ""
                    Next
                    Return str
                End If

            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 取得未選取的項目名稱
    ''' </summary>
    ''' <returns>項目名稱陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function GetNonSelectedItemNames() As String()
        Try
            If _uclNameFieldIndexStr.Trim() <> "" Then


                Dim nameIndex As String() = Split(Me.uclNameFieldIndexStr, ",")
                Dim nonSelectedIndex As String() = Split(Me.uclNonSelectedItemIndex, ",")
                Dim temp As String = ""

                If nonSelectedIndex.Length > 0 AndAlso uclNonSelectedItemIndex <> "" Then
                    Dim str(nonSelectedIndex.Length - 1) As String

                    For i As Integer = 0 To nonSelectedIndex.Length - 1
                        For j As Integer = 0 To nameIndex.Length - 1
                            If j < nameIndex.Length - 1 Then
                                temp += _uclDataSource.Tables(0).Rows(CType(nonSelectedIndex(i), Integer) - 1).Item(CType(nameIndex(j), Integer)).ToString().Trim() & ","
                            Else
                                temp += _uclDataSource.Tables(0).Rows(CType(nonSelectedIndex(i), Integer) - 1).Item(CType(nameIndex(j), Integer)).ToString().Trim()
                            End If
                        Next
                        str(i) = temp
                        temp = ""
                    Next
                    Return str
                End If


            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' 取得選取的項目代碼
    ''' </summary>
    ''' <returns>項目代碼陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function GetSelectedItemCodes() As String()
        Try

            If _uclCodeFieldIndexStr.Trim() <> "" Then


                Dim codeIndex As String() = Split(Me.uclCodeFieldIndexStr, ",")
                Dim selectedIndex As String() = Split(Me.uclSelectedItemIndex, ",")
                Dim temp As String = ""

                If selectedIndex.Length > 0 AndAlso _uclSelectedItemIndex <> "" Then
                    Dim str(selectedIndex.Length - 1) As String

                    For i As Integer = 0 To selectedIndex.Length - 1
                        For j As Integer = 0 To codeIndex.Length - 1

                            If j < codeIndex.Length - 1 Then
                                temp += _uclDataSource.Tables(0).Rows(CType(selectedIndex(i), Integer) - 1).Item(CType(codeIndex(j), Integer)).ToString().Trim() & ","
                            Else
                                temp += _uclDataSource.Tables(0).Rows(CType(selectedIndex(i), Integer) - 1).Item(CType(codeIndex(j), Integer)).ToString().Trim()
                            End If
                        Next
                        str(i) = temp
                        temp = ""
                    Next
                    Return str
                End If

            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 取得選取的項目名稱
    ''' </summary>
    ''' <returns>項目名稱陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function GetSelectedItemNames() As String()
        Try
            If _uclNameFieldIndexStr.Trim() <> "" Then


                Dim nameIndex As String() = Split(Me.uclNameFieldIndexStr, ",")
                Dim selectedIndex As String() = Split(Me.uclSelectedItemIndex, ",")
                Dim temp As String = ""

                If selectedIndex.Length > 0 AndAlso _uclSelectedItemIndex <> "" Then
                    Dim str(selectedIndex.Length - 1) As String

                    For i As Integer = 0 To selectedIndex.Length - 1
                        For j As Integer = 0 To nameIndex.Length - 1
                            If j < nameIndex.Length - 1 Then
                                temp += _uclDataSource.Tables(0).Rows(CType(selectedIndex(i), Integer) - 1).Item(CType(nameIndex(j), Integer)).ToString().Trim() & ","
                            Else
                                temp += _uclDataSource.Tables(0).Rows(CType(selectedIndex(i), Integer) - 1).Item(CType(nameIndex(j), Integer)).ToString().Trim()
                            End If
                        Next
                        str(i) = temp
                        temp = ""
                    Next
                    Return str
                End If


            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 取消所有所取的項目
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub ClearSelected()
        CheckedListBox1.ClearSelected()
    End Sub

    ''' <summary>
    ''' 刪除某一個項目
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub RemoveItemAt(ByVal ItemIndex As Integer)
        If ItemIndex > 0 AndAlso ItemIndex <= CheckedListBox1.Items.Count - 1 Then
            CheckedListBox1.Items.RemoveAt(ItemIndex)
            uclDataSource.Tables(0).Rows.RemoveAt(ItemIndex - 1)
        End If
    End Sub

    ''' <summary>
    ''' 進行排序
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Sort(ByVal ColumnIndex As Integer)
        If uclDataSource IsNot Nothing Then

            If ColumnIndex >= 0 AndAlso ColumnIndex <= uclDataSource.Tables(0).Columns.Count - 1 Then
                Dim view As DataView
                view = uclDataSource.Tables(0).DefaultView
                view.Sort = uclDataSource.Tables(0).Columns(ColumnIndex).ColumnName
                Dim ds As New DataSet
                ds.Tables.Add(view.ToTable.Copy)
                Initial(ds)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 在指定位置中插入資料列
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub InsertAt(ByVal RowData As DataRow, ByVal RowIndex As Integer)
        If RowIndex >= 0 AndAlso RowIndex <= uclDataSource.Tables(0).Rows.Count Then
            Dim row As DataRow
            row = uclDataSource.Tables(0).NewRow

            row.ItemArray = RowData.ItemArray
            uclDataSource.Tables(0).Rows.InsertAt(row, RowIndex)
            Initial(uclDataSource)
        End If

    End Sub



#End Region

#Region "Event"


    Private Sub CheckedListBox1_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        Try


            If e.Index = 0 And CheckedListBox1.Items.Count > 1 Then
                For i As Integer = 1 To CheckedListBox1.Items.Count - 1
                    If e.CurrentValue = CheckState.Unchecked Then
                        CheckedListBox1.SetItemCheckState(i, CheckState.Checked)
                    Else
                        CheckedListBox1.SetItemCheckState(i, CheckState.Unchecked)
                    End If

                Next

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

End Class
